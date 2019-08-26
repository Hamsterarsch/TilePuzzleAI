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
        private CellIndices correctPos;
        private Image puzzleImage;
        private Rectangle cellRect;


        public CellControl(GameController controller, CellIndices position, CellIndices correctPos, Image backgroundImage, Rectangle cellRect)
        {
            this.controller = controller;
            this.position = position;
            this.correctPos = correctPos;
            this.puzzleImage = backgroundImage;
            this.cellRect = cellRect;

            SetStyle(ControlStyles.Selectable, false);



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

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(puzzleImage, cellRect);
         
        }


        public void UpdatePosition(CellIndices position)
        {
            this.position = position;

        }


    }


}
