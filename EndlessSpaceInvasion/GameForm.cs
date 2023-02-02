using System.Threading;
using System.Windows.Forms;

namespace EndlessSpaceInvasion
{
    public partial class GameForm : Form
    {
        public GameForm(string username)
        {
            InitializeComponent();

            LoadGame(username);
        }

        private static void LoadGame(string username)
        {
            var thread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                var game = new Game1(username);
                game.Run();
            });

            thread.Start();

            thread.Join(); // Waits for thread to complete
        }
    }
}

