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
    public partial class BoardSizeControl : UserControl
    {
        public Action<int> OnNewSizeSelected;

        public BoardSizeControl()
        {
            InitializeComponent();

        }
        
        private void CheckedChanged(object sender, EventArgs e)
        {
            if (rad_3x3.Checked)
            {
                OnNewSizeSelected?.Invoke(3);
            }
            else if (rad_4x4.Checked)
            {
                OnNewSizeSelected?.Invoke(4);
            }
            else if (rad_5x5.Checked)
            {
                OnNewSizeSelected?.Invoke(5);
            }

        }


    }


}
