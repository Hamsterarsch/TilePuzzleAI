using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PuzzleApp
{


    class BoardCellFactory
    {
        public Button MakeBoardCell(CellIndices Indices)
        {
            var cell = new Button
            {
                Anchor = ~AnchorStyles.None,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };
            
            return cell;

        }


    }


}