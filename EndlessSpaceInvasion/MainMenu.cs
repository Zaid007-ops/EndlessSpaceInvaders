using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace EndlessSpaceInvasion
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

            textBoxUsername.Text = RandomNameGenerator.Create();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            new GameForm(textBoxUsername.Text);

            Show();
        }

        private void buttonLeaderboard_Click(object sender, EventArgs e)
        {
            var highScores = new HighScores();
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
