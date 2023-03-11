using System.Collections.Generic;
using System.Windows.Forms;

namespace EndlessSpaceInvasion
{
    public partial class HighScores : Form
    {
        private readonly DataStoreService _dataStoreService;
        private const string DefaultSort = "DESC";
        private const int DefaultLimit = 10;

        public HighScores(DataStoreService dataStoreService)
        {
            _dataStoreService = dataStoreService;

            InitializeComponent();

            comboBoxSort.SelectedIndex = 1;
            comboBoxLimit.SelectedIndex = 0;

            BindData(dataStoreService.GetHighScores(DefaultSort, DefaultLimit));
        }

        private void buttonFilter_Click(object sender, System.EventArgs e)
        {
            var sort = comboBoxSort.Text ?? DefaultSort;
            
            var limit = 0;

            if(!int.TryParse(comboBoxLimit.Text, out limit))
            {
                limit = DefaultLimit;
            }

            BindData(_dataStoreService.GetHighScores(sort, limit));
        }

        private void BindData(List<HighScore> highCcores)
        {
            dataGridViewHighScores.Rows.Clear();

            foreach (var highScore in highCcores)
                dataGridViewHighScores.Rows.Add(highScore.Username, highScore.Score, highScore.Level, highScore.Created);
        }
    }
}
