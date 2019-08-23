using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PuzzleApp
{
    struct CellIndices
    {
        public int column;
        public int row;

    }

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