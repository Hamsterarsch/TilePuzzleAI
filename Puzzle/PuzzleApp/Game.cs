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
        private Board board;

        public Game(NotifiableGameView view, Board board)
        {
            this.view = view;
            this.board = board;

        }

    }


}
