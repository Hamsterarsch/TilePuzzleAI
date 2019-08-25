using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using PuzzleApp.MVC;

namespace PuzzleApp
{


    class BoardCellFactory
    {
        private GameController controller;


        public BoardCellFactory(GameController controller)
        {
            this.controller = controller;

        }

        public CellControl MakeBoardCell(CellIndices indices)
        {
            var cell = new CellControl(controller, indices)
            {
                Anchor = ~AnchorStyles.None,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };
            
            return cell;

        }


    }


}