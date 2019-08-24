using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleApp
{
    class BoardRenderer
    {
        private Board board;
        private Control outputControl;
        private TableLayoutPanel boardLayoutPanel;
        private BoardCellFactory cellFactory;


        public BoardRenderer(Control outputControl, Board board, BoardCellFactory cellFactory)
        {
            this.outputControl = outputControl;
            this.board = board;
            this.cellFactory = cellFactory;

        }

        public int GetExpectedBoardControlCount()
        {
            return board.size * 2 + 1;

        }

        public bool DoesBoardWidthEqual(int width)
        {
            return width == boardLayoutPanel.Width;

        }

        public bool DoesBoardHeightEqual(int height)
        {
            return height == boardLayoutPanel.Height;

        }

        public void Render()
        {
            boardLayoutPanel = CreateBoardLayoutPanel();

            AddCellsToBoardLayout(boardLayoutPanel);

            outputControl.Controls.Add(boardLayoutPanel);
            outputControl.Invalidate();

        }

        private TableLayoutPanel CreateBoardLayoutPanel()
        {
            var layout = new TableLayoutPanel
            {
                RowCount = board.size,
                ColumnCount = board.size,
                Width = outputControl.Width,
                Height = outputControl.Height
            };

            AddStyleToRowsAndColumns(layout);
            return layout;

        }

        private void AddStyleToRowsAndColumns(TableLayoutPanel layout)
        {
            
            for (var rowIndex = 0; rowIndex < layout.RowCount; ++rowIndex)
            {
                layout.RowStyles.Add(MakeRowStyle());
            }

            for (var columnIndex = 0; columnIndex < layout.ColumnCount; ++columnIndex)
            {
                layout.ColumnStyles.Add(MakeColumnStyle());
            }
            
        }

        private RowStyle MakeRowStyle()
        {
            return new RowStyle
            {
                SizeType = SizeType.Percent,
                Height = GetRowHeightPercent()
            };

        }

        private ColumnStyle MakeColumnStyle()
        {
            return new ColumnStyle
            {
                SizeType = SizeType.Percent,
                Width = GetColumnWidthPercent()
            };

        }

        private int GetRowHeightPercent()
        {
            var normalizedPercent = 1f / board.size;
            return (int)Math.Floor(100 * normalizedPercent);

        }

        private int GetColumnWidthPercent()
        {
            var normalizedPercent = 1f / board.size;
            return (int)Math.Floor(100 * normalizedPercent);

        }


        private void AddCellsToBoardLayout(TableLayoutPanel layout)
        {
            for (int columnIndex = 0; columnIndex < layout.ColumnCount; ++columnIndex)
            {
                AddCellsToLayoutAtColumn(columnIndex);
            }
            
        }

        private void AddCellsToLayoutAtColumn(int columnIndex)
        {
            for (int rowIndex = 0; rowIndex < boardLayoutPanel.RowCount; ++rowIndex)
            {
                var cellIndices = new CellIndices
                {
                    column = columnIndex,
                    row = rowIndex
                };

                if (IsNotLowerRightCell(cellIndices))
                {
                    AddCellToBoardAt(cellIndices);
                }
            }

        }

        private bool IsNotLowerRightCell(CellIndices indices)
        {
            var threshold = board.size - 1;
            return indices.column != threshold || indices.row != threshold;

        }

        private void AddCellToBoardAt(CellIndices indices)
        {
            boardLayoutPanel.Controls.Add
            (
                cellFactory.MakeBoardCell(indices),
                indices.column, indices.row
            );
            
        }


    }


}
