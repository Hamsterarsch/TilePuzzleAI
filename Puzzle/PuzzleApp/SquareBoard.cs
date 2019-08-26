﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PuzzleApp
{
    class SquareBoard
    {
        private int size;
        private Cell[,] cells;
        private CellIndices emptyCellPos;
        private int correctlyOrderedCells;

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
            return EmptyCelIsInTheSameColumnAndAdjacentRow(indices) 
                   || EmptyCellIsInTheSameRowAndAdjacentColumn(indices);

        }

            private bool EmptyCelIsInTheSameColumnAndAdjacentRow(CellIndices indices)
            {
                return indices.column == emptyCellPos.column 
                       && Math.Abs(emptyCellPos.row - indices.row) == 1;

            }

            private bool EmptyCellIsInTheSameRowAndAdjacentColumn(CellIndices indices)
            {
                return indices.row == emptyCellPos.row
                       && Math.Abs(emptyCellPos.column - indices.column) == 1;

            }
        

    }


}
