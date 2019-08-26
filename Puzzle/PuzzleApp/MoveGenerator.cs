using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleApp
{
    class MoveGenerator
    {
        private SquareBoard board;
        private Random random;


        public MoveGenerator(SquareBoard board)
        {
            this.board = board;
            random = new Random();

        }

        public CellIndices GetMove()
        {
            var displacement = GetRandomNonDiagonalIndexDisplacement();

            var adjacentCell = board.GetEmptyCellPos();
            adjacentCell.column += displacement.column;
            adjacentCell.row += displacement.row;

            return EnforceBoardBoundaries(adjacentCell);
            
        }

            private CellIndices GetRandomNonDiagonalIndexDisplacement()
            {
                var displacement = GetRandomIndexDisplacements();
                while (DisplacementIsZero(ref displacement) || DisplacementIsDiagonal(ref displacement))
                {
                    displacement = GetRandomIndexDisplacements();
                }

                return displacement;

            }

                private CellIndices GetRandomIndexDisplacements()
                {
                    return new CellIndices
                    {
                        column = random.Next(-1, 2),
                        row = random.Next(-1, 2)
                    };

                }

                private bool DisplacementIsZero(ref CellIndices displacement)
                {
                    return displacement.row == 0 && displacement.column == 0;

                }

                private bool DisplacementIsDiagonal(ref CellIndices displacement)
                {
                    return Math.Abs(displacement.column) == Math.Abs(displacement.row);

                }

            private CellIndices EnforceBoardBoundaries(CellIndices indices)
            {
                if (indices.column >= board.SizeInCells())
                {
                    indices.column -= 2;
                }

                if (indices.row >= board.SizeInCells())
                {
                    indices.row -= 2;
                }

                if (indices.column < 0)
                {
                    indices.column += 2;
                }

                if (indices.row < 0)
                {
                    indices.row += 2;
                }

                return indices;

            }
        

    }


}
