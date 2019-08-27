using System;
using System.Diagnostics;


namespace PuzzleApp
{
    class SquareBoard
    {
        private int size;
        private Cell[,] cells;
        private CellIndices emptyCellPos;
        private int correctlyOrderedCells;


        public static bool operator ==(SquareBoard Lhs, SquareBoard Rhs)
        {
            return Lhs.correctlyOrderedCells == Rhs.correctlyOrderedCells
                   && Lhs.emptyCellPos == Rhs.emptyCellPos
                   && AreCellsEqual(Lhs.cells, Rhs.cells);

        }

            private static bool AreCellsEqual(Cell[,] cells1, Cell[,] cells2)
            {
                bool bCellsAreEqual = true;

                for (int columnIndex = 0; columnIndex <= cells1.GetUpperBound(0); ++columnIndex)
                {
                    for (int rowIndex = 0; rowIndex <= cells1.GetUpperBound(1); ++rowIndex)
                    {
                        bCellsAreEqual &= cells1[columnIndex, rowIndex] == cells2[columnIndex, rowIndex];
                        if (!bCellsAreEqual)
                        {
                            return false;
                        }

                    }
                }

                return true;
            }
        
        public static bool operator !=(SquareBoard Lhs, SquareBoard Rhs)
        {
            return !(Lhs == Rhs);

        }




        public SquareBoard(int size)
        {
            this.size = size;
            this.cells = new Cell[size, size];
            this.correctlyOrderedCells = GetCellAmount();
            
            InitCells(cells);

        }

            private void InitCells(Cell[,] cells)
            {
                for (int columnIndex = 0; columnIndex <= cells.GetUpperBound(0); ++columnIndex)
                {
                    InitCellColumn(cells, columnIndex);
                }

            }

                private void InitCellColumn(Cell[,] cells, int columnIndex)
                {
                    for (int rowIndex = 0; rowIndex <= cells.GetUpperBound(1); ++rowIndex)
                    {
                        var CellIndices = new CellIndices(columnIndex, rowIndex);
                        InitCell(ref this[CellIndices], CellIndices);
                    }

                }

                    private void InitCell(ref Cell cell, CellIndices currentPosition)
                    {
                        if (IsNotLowerRightPos(currentPosition))
                        {
                            cell = new Cell(currentPosition);
                        }
                        else
                        {
                            this.emptyCellPos = currentPosition;
                        }

                    }

                        private bool IsNotLowerRightPos(CellIndices indices)
                        {
                            return indices.column != cells.GetUpperBound(0) 
                                   || indices.row != cells.GetUpperBound(1);

                        }

                    private ref Cell this[CellIndices indices]
                    {
                        get { return ref cells[indices.column, indices.row]; }

                    }

        public SquareBoard(SquareBoard other)
        {
            this.size = other.size;
            this.correctlyOrderedCells = other.correctlyOrderedCells;
            this.emptyCellPos = other.emptyCellPos;

            this.cells = new Cell[size, size];
            CopyCellsFrom(ref other.cells, ref this.cells);

        }

            private void CopyCellsFrom(ref Cell[,] from, ref Cell[,] to)
            {
                for (int columnIndex = 0; columnIndex <= from.GetUpperBound(0); ++columnIndex)
                {
                    CopyCellColumns(ref from, ref to, columnIndex);
                }

            }

                private void CopyCellColumns(ref Cell[,] from, ref Cell[,] to, int columnIndex)
                {
                    for (int rowIndex = 0; rowIndex <= from.GetUpperBound(1); ++rowIndex)
                    {
                        CopyCells(ref from, ref to, columnIndex, rowIndex);
                    }

                }

                    private void CopyCells(ref Cell[,] from, ref Cell[,] to, int columnIndex, int rowIndex)
                    {
                        if (from[columnIndex, rowIndex] == null)
                        {
                            return;
                        }

                        to[columnIndex, rowIndex] = new Cell(from[columnIndex, rowIndex]);

                    }

        

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = size;
                hashCode = (hashCode * 397) ^ GetCellHash();
                hashCode = (hashCode * 397) ^ emptyCellPos.GetHashCode();
                hashCode = (hashCode * 397) ^ correctlyOrderedCells;
                return hashCode;
            }

        }

            private int GetCellHash()
            {
                var hashCode = cells.Length;
                foreach (Cell cell in cells)
                {
                    unchecked
                    {
                        hashCode = hashCode * (cell == null ? 0 : cell.GetHashCode());
                    }
                }

                return hashCode;

            }



        public int SizeInCells()
        {
            return size;
        }

        public int GetCellAmount()
        {
            return size * size - 1;

        }

        public int GetCorrectCellAmount()
        {
            return correctlyOrderedCells;

        }

        public bool CellIsCorrect(CellIndices indices)
        {
            if (this[indices] != null)
            {
                return this[indices].correctPosition == indices;
            }
            return true;

        }

        public CellIndices GetEmptyCellPos()
        {
            return emptyCellPos;

        }

        public CellIndices GetCorrectCellPosForCellAt(CellIndices indices)
        {
            return this[indices].correctPosition;

        }

        public void SwapCells(CellIndices firstCell, CellIndices secondCell)
        {
            Debug.Assert(firstCell != secondCell);

            UpdateCorrectCellState(firstCell, secondCell);

            var tempCell = this[firstCell];
            this[firstCell] = this[secondCell];
            this[secondCell] = tempCell;
            
            if (CellIsEmpty(firstCell))
            {
                emptyCellPos = firstCell;
            }

            if (CellIsEmpty(secondCell))
            {
                emptyCellPos = secondCell;
            }
            
        }

            private void UpdateCorrectCellState(CellIndices firstCell, CellIndices secondCell)
            {
                if (CellMovesFromCorrectToIncorrectPos(firstCell, secondCell))
                {
                    --correctlyOrderedCells;
                }

                if (CellMovesFromCorrectToIncorrectPos(secondCell, firstCell))
                {
                    --correctlyOrderedCells;
                }

                if (CellMovesFromIncorrectToCorrectPos(firstCell, secondCell))
                {
                    ++correctlyOrderedCells;
                }

                if (CellMovesFromIncorrectToCorrectPos(secondCell, firstCell))
                {
                    ++correctlyOrderedCells;
                }

            }

                private bool CellMovesFromCorrectToIncorrectPos(CellIndices cellIndices, CellIndices moveTo)
                {
                    if (CellIsNotEmpty(cellIndices))
                    {
                        return this[cellIndices].correctPosition == cellIndices;
                    }
                    return false;

                }

                    private bool CellIsNotEmpty(CellIndices indices)
                    {
                        return !CellIsEmpty(indices);

                    }

                    private bool CellIsEmpty(CellIndices indices)
                    {
                        return this[indices] == null;

                    }

                private bool CellMovesFromIncorrectToCorrectPos(CellIndices cellIndices, CellIndices moveTo)
                {
                    if (CellIsNotEmpty(cellIndices))
                    {
                        return this[cellIndices].correctPosition == moveTo;
                    }
                    return false;

                }

        public bool CellIsAdjacentToEmpty(CellIndices indices)
        {
            return EmptyCellIsInTheSameColumnAndAdjacentRow(indices) 
                   || EmptyCellIsInTheSameRowAndAdjacentColumn(indices);

        }

            private bool EmptyCellIsInTheSameColumnAndAdjacentRow(CellIndices indices)
            {
                return indices.column == emptyCellPos.column 
                       && Math.Abs(emptyCellPos.row - indices.row) == 1;

            }

            private bool EmptyCellIsInTheSameRowAndAdjacentColumn(CellIndices indices)
            {
                return indices.row == emptyCellPos.row
                       && Math.Abs(emptyCellPos.column - indices.column) == 1;

            }



        public int GetManhattanDistFromCompletion()
        {
            int summedDistance = 0;
            for (int columnIndex = 0; columnIndex < SizeInCells(); ++columnIndex)
            {
                summedDistance += SumColumnDistanceFromCorrectPosition(columnIndex);
            }

            return summedDistance;

        }

            private int SumColumnDistanceFromCorrectPosition(int columnIndex)
            {
                int sum = 0;
                for (int rowIndex = 0; rowIndex < SizeInCells(); ++rowIndex)
                {
                    sum += CalculateCellDistanceFromCorrectPosition(new CellIndices(columnIndex, rowIndex));
                }

                return sum;

            }

                private int CalculateCellDistanceFromCorrectPosition(CellIndices indices)
                {
                    if (CellIsEmpty(indices))
                    {
                        return 0;
                    }

                    var cell = this[indices];
                    return Math.Abs(cell.correctPosition.row - indices.row)  +  Math.Abs(cell.correctPosition.column - indices.column);

                }


    }


}
