using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleApp
{
    public partial class ChangeImageControl : UserControl
    {
        public ChangeImageControl()
        {
            InitializeComponent();
        }

        private void btn_LoadNew_Click(object sender, EventArgs e)
        {
            prompt_OpenImageFile.ShowDialog();
        }
    }
}
