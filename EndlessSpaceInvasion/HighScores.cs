using System.Windows.Forms;

namespace EndlessSpaceInvasion
{
    public partial class HighScores : Form
    {
        public HighScores(DataStoreService dataStoreService)
        {
            InitializeComponent();

            var highScores = dataStoreService.GetHighScores();

            // TODO: Bind highscores to datagrid
        }
    }
}
