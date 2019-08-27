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
        private GameController controller;

        public Window(ObservableGameView view, GameController controller)
        {
            InitializeComponent();

            this.view = view;
            this.controller = controller;

            this.ctrl_boardSize.OnNewSizeSelected += controller.ChangeBoardSize;
            view.SetEventOnSolutionFound(OnSolutionFound);
            view.SetEventOnSolutionStepUpdated(OnSolutionStepChanged);

        }

        public void SetEventOnNewImageSelected(Action<string> Event)
        {
            this.ctrl_ChangeImage.SetEventOnNewImageSelected(Event);

        }

        private void Window_Load(object sender, EventArgs e)
        {

        }

        private void btn_Solve_Click(object sender, EventArgs e)
        {
            controller.SolvePuzzle();

        }

        private void OnSolutionFound(int SolutionSteps)
        {
            txt_SolutionSteps.Text = SolutionSteps.ToString();
            txt_SoltionStepsRemaining.Text = SolutionSteps.ToString();

            pnl_SolutionInfo.Visible = true;
            
        }

        private void OnSolutionStepChanged(int StepsRemaining)
        {
            txt_SoltionStepsRemaining.Text = StepsRemaining.ToString();

        }


    }


}
