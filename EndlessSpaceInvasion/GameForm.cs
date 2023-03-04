using System.Threading;
using System.Windows.Forms;

namespace EndlessSpaceInvasion
{
    public partial class GameForm : Form
    {
        public GameForm(DataStoreService dataStoreService, string username)
        {
            InitializeComponent();

            LoadGame(dataStoreService, username);
        }

        private static void LoadGame(DataStoreService dataStoreService, string username)
        {
            var thread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                var game = new Game1(dataStoreService, username);
                game.Run();
            });

            thread.Start();

            thread.Join(); // Waits for thread to complete
        }
    }
}

