using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuzzleApp.MVC;

namespace PuzzleApp
{
    class Game
    {
        private NotifiableGameView view;
        private SquareBoard board;


        public Game(NotifiableGameView view, SquareBoard board)
        {
            this.view = view;
            this.board = board;

            DisorderBoard();

        }

        public void OnCellClicked(CellIndices indices)
        {
            if (board.CellIsAdjacentToEmpty(indices))
            {
                var moveToPos = board.GetEmptyCellPos();

                board.SwapCells(indices, moveToPos);
                
                view.NotifyOnCellMoved(indices, moveToPos);
            }
            
        }
        
        public void ChangeBoardSize(int size)
        {
            this.board = new SquareBoard(size);
            DisorderBoard();

            view.NotifyOnBoardChanged(board);

        }

        public bool IsCompleted()
        {
            return board.GetCorrectCellAmount() == board.GetCellAmount();

        }

        public void DisorderBoard()
        {
            //todo: fix magic tokens and abstraction levels
            var moveGenerator = new MoveGenerator(board);

            const int disorderSteps = 80;
            for (int i = 0; i < disorderSteps; ++i)
            {
                var move = moveGenerator.GetMove();
                OnCellClicked(move);
            }

            //this may be too predictable
            //align column
            while (board.GetEmptyCellPos().column != board.SizeInCells() - 1)
            {
                var emptyPos = board.GetEmptyCellPos();
                emptyPos.column += 1;

                OnCellClicked(emptyPos);

            }

            //align row
            while (board.GetEmptyCellPos().row != board.SizeInCells() - 1)
            {
                var emptyPos = board.GetEmptyCellPos();
                emptyPos.row += 1;

                OnCellClicked(emptyPos);

            }


        }


    }


}
