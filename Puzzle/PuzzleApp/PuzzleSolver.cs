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


        public static bool operator ==(Node Lhs, Node Rhs)
        {
            return  Lhs.estimation == Rhs.estimation
                    && Lhs.board == Rhs.board;

        }

        public static bool operator !=(Node Lhs, Node Rhs)
        {
            return !(Lhs == Rhs);

        }


        public override int GetHashCode()
        {
            unchecked
            {
                return (board.GetHashCode() * 397) ^ estimation;
            }
        }

        public float Priority()
        {
            return estimation;

        }


    }

    class NodeEqualityComparer : IEqualityComparer<Node>
    {
        public bool Equals(Node x, Node y)
        {
            return x == y;

        }

        public int GetHashCode(Node obj)
        {
            return obj.GetHashCode();

        }

    }

    class PuzzleSolver
    {
        private SquareBoard board;
        private PriorityQueue<Node> open;
        private HashSet<Node> closed;

        public PuzzleSolver(SquareBoard board)
        {
            this.board = board;
            closed = new HashSet<Node>(new NodeEqualityComparer());
            open = new PriorityQueue<Node>();

        }

        public void Solve()
        {

        }


    }


}
