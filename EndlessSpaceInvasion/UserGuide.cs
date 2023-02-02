using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndlessSpaceInvasion
{
    public partial class UserGuide : Form
    {
        public UserGuide()
        {
            InitializeComponent();
            
            richTextBoxGuide.Text = File.ReadAllText("Content/UserGuide.txt");
        }

        private void UserGuide_Load(object sender, EventArgs e)
        {

        }
    }
}
