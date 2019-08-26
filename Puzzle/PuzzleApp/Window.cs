using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuzzleApp.MVC;

namespace PuzzleApp
{
    partial class Window : Form
    {
        private ObservableGameView view;


        public Window(ObservableGameView view, GameController controller)
        {
            InitializeComponent();

            this.view = view;

            this.ctrl_boardSize.OnNewSizeSelected += controller.ChangeBoardSize;


        }

        private void Window_Load(object sender, EventArgs e)
        {

        }
    }


}
