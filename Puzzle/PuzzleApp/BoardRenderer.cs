using System;
using System.Drawing;
using System.Windows.Forms;


namespace PuzzleApp
{
    class BoardRenderer
    {
        private SquareBoard board;
        private Control outputControl;
        private TableLayoutPanel boardLayoutPanel;
        private BoardCellFactory cellFactory;


        public BoardRenderer(Control outputControl, SquareBoard board, BoardCellFactory cellFactory)
        {
            this.outputControl = outputControl;
            this.board = board;
            this.cellFactory = cellFactory;

        }



        public int GetExpectedBoardControlCount()
        {
            return board.GetCellAmount() + 1;//add the layout control too

        }

        public bool DoesBoardWidthEqual(int width)
        {
            return width == boardLayoutPanel.Width;

        }

        public bool DoesBoardHeightEqual(int height)
        {
            return height == boardLayoutPanel.Height;

        }

        public void SetCellFactory(BoardCellFactory cellFactory)
        {
            this.cellFactory = cellFactory;

        }

        public void Render(SquareBoard board)
        {
            this.board = board;
            Render();

        }

        public void Render()
        {
            boardLayoutPanel?.Dispose();
            boardLayoutPanel = CreateBoardLayoutPanel();

            AddCellsToBoardLayout(boardLayoutPanel);

            outputControl.Controls.Add(boardLayoutPanel);
            outputControl.Invalidate();

        }
        
            private TableLayoutPanel CreateBoardLayoutPanel()
            {
                var layout = new TableLayoutPanel
                {
                    RowCount = board.SizeInCells(),
                    ColumnCount = board.SizeInCells(),
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
                            Height = GetCellSizePercent()
                        };

                    }

                        private int GetCellSizePercent()
                        {
                            var normalizedPercent = 1f / board.SizeInCells();
                            return (int)Math.Floor(100 * normalizedPercent);

                        }

                    private ColumnStyle MakeColumnStyle()
                    {
                        return new ColumnStyle
                        {
                            SizeType = SizeType.Percent,
                            Width = GetCellSizePercent()
                        };

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
                        return board.GetEmptyCellPos() != indices;
                        
                    }

                    private void AddCellToBoardAt(CellIndices indices)
                    {
                        var correctPos = board.GetCorrectCellPosForCellAt(indices);
                        
                        boardLayoutPanel.Controls.Add
                        (
                            cellFactory.MakeBoardCell(indices, correctPos, MakeCellBackgroundRectangle(indices)),
                            indices.column, indices.row
                        );
                        
                    }

                        private Rectangle MakeCellBackgroundRectangle(CellIndices cellIndices)
                        {
                            var backgroundRect = OffsetBackgroundRect(boardLayoutPanel.ClientRectangle, cellIndices);
                            return ScaleBackgroundRectToBorder(backgroundRect);

                        }

                            private Rectangle OffsetBackgroundRect(Rectangle rect, CellIndices cellIndices)
                            {
                                var correctPos = board.GetCorrectCellPosForCellAt(cellIndices);
                                var cellIncrement = GetCellIncrementForBoard();

                                rect.X -= cellIncrement * correctPos.column;
                                rect.Y -= cellIncrement * correctPos.row;

                                return rect;

                            }

                                private int GetCellIncrementForBoard()
                                {
                                    return boardLayoutPanel.ClientRectangle.Width / board.SizeInCells();

                                }

                            private Rectangle ScaleBackgroundRectToBorder(Rectangle rect)
                            {
                                int Scale = 6;

                                rect.X -= Scale/2;
                                rect.Y -= Scale/2;

                                rect.Width += Scale;
                                rect.Height += Scale;

                                return rect;

                            }
        
        public void SwapCells(CellIndices firstIndices, CellIndices secondIndices)
        {
            var firstCell = GetCellAt(firstIndices);
            var secondCell = GetCellAt(secondIndices);

            SetCellPosition(firstCell, secondIndices);
            SetCellPosition(secondCell, firstIndices);
            
        }
        
            private CellControl GetCellAt(CellIndices indices)
            {
                return boardLayoutPanel.GetControlFromPosition(indices.column, indices.row) as CellControl;

            }

            private void SetCellPosition(CellControl cell, CellIndices newPos)
            {
                if (cell != null)
                {
                    boardLayoutPanel.SetCellPosition
                    (
                        cell,
                        new TableLayoutPanelCellPosition(newPos.column, newPos.row)
                    );
                    cell.UpdatePosition(newPos);
                }

            }


    }
    

}
