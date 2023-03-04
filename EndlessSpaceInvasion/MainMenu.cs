using System;
using System.Windows.Forms;

namespace EndlessSpaceInvasion
{
    public partial class MainMenu : Form
    {
        private readonly DataStoreService _dataStoreService;

        public MainMenu(DataStoreService dataStoreService)
        {
            _dataStoreService = dataStoreService;

            InitializeComponent();

            textBoxUsername.Text = RandomNameGenerator.Create();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            new GameForm(_dataStoreService, textBoxUsername.Text);

            Show();
        }

        private void buttonLeaderboard_Click(object sender, EventArgs e)
        {
            var highScores = new HighScores(_dataStoreService);
            highScores.ShowDialog();

            Show();
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
