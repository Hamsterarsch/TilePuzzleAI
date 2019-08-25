using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuzzleApp.MVC;

namespace PuzzleApp
{
    class CellControl : Button
    {
        private GameController controller;
        private CellIndices position;


        public CellControl(GameController controller, CellIndices position)
        {
            this.controller = controller;
            this.position = position;

            SetStyle(ControlStyles.Selectable, false);
            //FlatStyle = FlatStyle.Flat;
            //FlatAppearance.BorderSize = 1;
            //FlatAppearance.MouseOverBackColor =


        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            controller.OnCellClicked(position);

        }

        protected override bool ShowFocusCues
        {
            get { return false; }
        }
        


        public void UpdatePosition(CellIndices position)
        {
            this.position = position;

        }


    }


}
