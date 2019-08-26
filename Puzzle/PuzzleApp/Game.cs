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
            view.NotifyOnBoardChanged(board);

        }

        private void DisorderBoard()
        {

        }
        /*
        private CellIndices GetValidMove()
        {
            //board.GetCellAdjacentToEmpty()
        }*/

    }


}
