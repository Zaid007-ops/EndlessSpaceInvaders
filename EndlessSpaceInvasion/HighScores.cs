using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndlessSpaceInvasion
{
    public partial class HighScores : Form
    {
        private readonly DataStoreService _dataStoreService;

        public HighScores()
        {
            InitializeComponent();

            _dataStoreService = new DataStoreService();

            var highScores = _dataStoreService.GetHighScores();

            // TODO: Bind highscores to datagrid
        }
    }
}
