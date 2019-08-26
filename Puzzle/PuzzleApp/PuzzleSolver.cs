using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleApp
{
    interface Priority
    {
        float Priority();

    }

    class Node : Priority
    {
        private SquareBoard board;
        private int estimation;

        public Node(SquareBoard board)
        {
            this.board = board;
            this.estimation = board.GetCorrectCellAmount();

        }

        public float Priority()
        {
            return estimation;

        }

    }

    class PuzzleSolver
    {
        private SquareBoard board;
        private SortedList<int, Node> d;

        public PuzzleSolver(SquareBoard board)
        {
            this.board = board;
            
        }

        public void Solve()
        {

        }


    }


}
