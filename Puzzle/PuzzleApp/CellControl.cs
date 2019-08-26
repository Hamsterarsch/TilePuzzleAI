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


        public CellControl(GameController controller, CellIndices position, CellIndices correctPos, Image backgroundImage)
        {
            this.controller = controller;
            this.position = position;
            this.correctPos = correctPos;
            this.puzzleImage = backgroundImage;

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

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            var rect = ClientRectangle;
            rect.Width = rect.Width - puzzleImage.Width;
            rect.Height = rect.Height - puzzleImage.Height;

            e.Graphics.DrawImage(puzzleImage, rect);

        }


        public void UpdatePosition(CellIndices position)
        {
            this.position = position;

        }


    }


}
