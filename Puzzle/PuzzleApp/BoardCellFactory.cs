using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using PuzzleApp.MVC;

namespace PuzzleApp
{


    class BoardCellFactory
    {
        private GameController controller;
        private Image cellImage;


        public BoardCellFactory(GameController controller, Image cellImage)
        {
            this.controller = controller;
            this.cellImage = cellImage;

        }

        public CellControl MakeBoardCell(CellIndices currentPos, CellIndices correctPos, Rectangle cellRect)
        {
            var cell = new CellControl(controller, currentPos, correctPos, cellImage, cellRect)
            {
                Anchor = ~AnchorStyles.None,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };
            

            return cell;

        }


    }


}