using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace EndlessSpaceInvasion
{
    public class DataStoreService
    {
        private static string ConnectionString = "Data Source=EndlessSpaceInvasion.db;Version=3;New=True;Compress=True;Pooling=false;";
        private const string TableName = "TopScores";

        public DataStoreService()
        {
            if (!TableExists())
                CreateTable();

            //SQLiteDatabase.setLockingEnabled(false);
        }

        private static bool TableExists()
        {
            var query = $"SELECT name FROM sqlite_master  WHERE type = 'table' AND name = '{TableName}';";

            using (var conn = new SQLiteConnection(ConnectionString))
            using (var command = new SQLiteCommand(query, conn))
            {
                try
                {
                    conn.Open();

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
                finally
                {
                    conn.Close();
                    conn.Dispose();
                    command.Dispose();
                }
            }
        }

        private static void CreateTable()
        {
            var query = $"CREATE TABLE {TableName} (Id INTEGER PRIMARY KEY AUTOINCREMENT, Username VARCHAR(50), HighScore INT, Created DATETIME)";

            using (var conn = new SQLiteConnection(ConnectionString))
            using (var command = new SQLiteCommand(query, conn))
            {
                try
                {
                    conn.Open();

                    command.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                    command.Dispose();
                }
            }
        }

        public void SaveScore(string username, int score)
        {
            var query = $"INSERT INTO {TableName}(Id, Username, HighScore, Created) VALUES(@Id, @Username, @HighScore, @Created)";

            using (var conn = new SQLiteConnection(ConnectionString))
            using (var command = new SQLiteCommand(query, conn))
            {
                try
                {
                    conn.Open();

                    command.Parameters.AddWithValue("@Id", null);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@HighScore", score);
                    command.Parameters.AddWithValue("@Created", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                    command.Dispose();
                }
            }
        }

        public List<HighScore> GetHighScores(string sort, int limit)
        {
            var highscores = new List<HighScore>();

            var query = $"SELECT Id, Username, HighScore, Created FROM {TableName} ORDER BY HighScore {sort} LIMIT {limit}";

            using (var conn = new SQLiteConnection(ConnectionString))
            using (var command = new SQLiteCommand(query, conn))
            {
                try
                {
                    conn.Open();

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
                finally
                {
                    conn.Close();
                    conn.Dispose();
                    command.Dispose();
                }
            }
        }
    }
}
