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

            return EnforceBoardBoundariesByMirroringMove(adjacentCell);
            
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

            private CellIndices EnforceBoardBoundariesByMirroringMove(CellIndices indices)
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

        public CellIndices[] GetMoves()
        {
            var emptyPos = board.GetEmptyCellPos();

            var moves = GetAllNonDiagonalMoves();
            TruncateMovesToBoard(ref moves);

            return MakeValidMovesFromUnsafeMoves(moves);
            
        }

            private CellIndices[] GetAllNonDiagonalMoves()
            {
                var moves = new CellIndices[4];
                var emptyPos = board.GetEmptyCellPos();

                moves[0] = new CellIndices(emptyPos.column + 1, emptyPos.row);
                moves[1] = new CellIndices(emptyPos.column - 1, emptyPos.row);
                moves[2] = new CellIndices(emptyPos.column, emptyPos.row + 1);
                moves[3] = new CellIndices(emptyPos.column, emptyPos.row - 1);

                return moves;

            }

            private void TruncateMovesToBoard(ref CellIndices[] moves)
            {
                for (int i = 0; i < moves.Length; ++i)
                {
                    moves[i] = TruncateMoveToBoardBoundaries(moves[i]);
                }

            }

                private CellIndices TruncateMoveToBoardBoundaries(CellIndices move)
                {
                    if (move.column >= board.SizeInCells())
                    {
                        move.column -= 1;
                    }

                    if (move.row >= board.SizeInCells())
                    {
                        move.row -= 1;
                    }

                    if (move.column < 0)
                    {
                        move.column += 1;
                    }

                    if (move.row < 0)
                    {
                        move.row += 1;
                    }

                    return move;

                }

            private CellIndices[] MakeValidMovesFromUnsafeMoves(CellIndices[] moves)
            {
                CellIndices[] validMoves = null;


                var validMoveCount = GetValidMoveAmount(ref moves);
                validMoves = new CellIndices[validMoveCount];

                foreach (CellIndices move in moves)
                {
                    if (IsMoveInsideBoundariesValid(move))
                    {
                        validMoves[validMoveCount - 1] = move;
                        --validMoveCount;
                    }

                }

                return validMoves;
            
            }

                private int GetValidMoveAmount(ref CellIndices[] moves)
                {
                    int validMoveCount = 0;
                    foreach (CellIndices move in moves)
                    {
                        if (IsMoveInsideBoundariesValid(move))
                        {
                            ++validMoveCount;
                        }
                    }

                    return validMoveCount;

                }

                private bool IsMoveInsideBoundariesValid(CellIndices move)
                {
                    return move != board.GetEmptyCellPos();

                }
        

    }


}
