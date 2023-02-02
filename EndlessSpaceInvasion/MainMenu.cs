using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace EndlessSpaceInvasion
{
    public partial class MainMenu : Form
    {
        private readonly DataStoreService _dataStoreService;

        public MainMenu()
        {
            InitializeComponent();

            _dataStoreService = new DataStoreService();

            textBoxUsername.Text = RandomNameGenerator.Create();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            new GameForm(textBoxUsername.Text);

            _dataStoreService.SaveScore(textBoxUsername.Text, 10);

            Show();
        }

        private void buttonLeaderboard_Click(object sender, EventArgs e)
        {
            var highScores = _dataStoreService.GetHighScores();
        }

        private void buttonUserGuide_Click(object sender, EventArgs e)
        {
            var userGuide = new UserGuide();
            userGuide.ShowDialog();

            Show();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
