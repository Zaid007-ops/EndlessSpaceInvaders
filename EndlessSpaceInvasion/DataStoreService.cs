using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EndlessSpaceInvasion
{
    public class DataStoreService
    {
        private readonly SQLiteConnection _connection;
        private const string TableName = "TopScores";

        public DataStoreService()
        {
            _connection = CreateConnection();

            if (!TableExists(_connection))
                CreateTable(_connection);
        }

        private static SQLiteConnection CreateConnection()
        {
            var sqlite_conn = new SQLiteConnection("Data Source=EndlessSpaceInvasion.db;Version=3;New=True;Compress=True;");

            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                // ignored
            }

            return sqlite_conn;
        }

        private static bool TableExists(SQLiteConnection conn)
        {
            var command = conn.CreateCommand();
            command.CommandText = $"SELECT name FROM sqlite_master  WHERE type = 'table' AND name = '{TableName}';";
            var reader = command.ExecuteReader();

            if (!reader.HasRows)
                return false;

            while (reader.Read())
            {
                var tableName = reader[0].ToString();
                return TableName.Equals(tableName);
            }

            return false;
        }

        private static void CreateTable(SQLiteConnection conn)
        {
            var command = conn.CreateCommand();
            command.CommandText = $"CREATE TABLE {TableName} (Id INTEGER PRIMARY KEY AUTOINCREMENT, Username VARCHAR(50), HighScore INT, Created DATETIME)";
            command.ExecuteNonQuery();
        }

        public void SaveScore(string username, int score)
        {
            var command = _connection.CreateCommand();
            command.CommandText = $"INSERT INTO {TableName}(Id, Username, HighScore, Created) VALUES(@Id, @Username, @HighScore, @Created)";
            command.Parameters.AddWithValue("@Id", null);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@HighScore", score);
            command.Parameters.AddWithValue("@Created", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            command.ExecuteNonQuery();
        }

        public List<HighScore> GetHighScores()
        {
            var highscores = new List<HighScore>();

            var command = _connection.CreateCommand();
            command.CommandText = $"SELECT Id, Username, HighScore, Created FROM {TableName} ORDER BY HighScore DESC LIMIT 10";
            var reader = command.ExecuteReader();

            if (!reader.HasRows)
                return highscores;

            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                var username = reader.GetString(1);
                var highscore = reader.GetInt32(2);
                var created = reader.GetDateTime(3);

                highscores.Add(new HighScore
                {
                    Id = id,
                    Username = username,
                    Score = highscore,
                    Created = created
                });
            }

            return highscores;
        }
    }
}
