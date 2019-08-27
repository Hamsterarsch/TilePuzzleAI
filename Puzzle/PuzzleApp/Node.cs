using System.Collections.Generic;


namespace PuzzleApp
{
    class Node : Priority
    {
        public SquareBoard board;
        public int estimation;
        private readonly int cost;
        private readonly Node parent;
        private readonly CellIndices moveToThis;


        public Node(SquareBoard board, int cost, int estimation, Node parent, CellIndices moveToThis)
        {
            this.parent = parent;
            this.board = board;
            this.cost = cost;
            this.estimation = estimation;
            this.moveToThis = moveToThis;
        }



        public static bool operator ==(Node Lhs, Node Rhs)
        {
            if (object.ReferenceEquals(Lhs, null))
            {
                return object.ReferenceEquals(Rhs, null);
            }

            if (object.ReferenceEquals(Rhs, null))
            {
                return object.ReferenceEquals(Lhs, null);
            }

            return Lhs.estimation == Rhs.estimation
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
                var hash = (board.GetHashCode() * 397) ^ estimation;
                hash = (hash * 17) ^ cost;
                hash = (hash * 17) ^ moveToThis.GetHashCode();
                return hash;
            }
        }

        public float Priority()
        {
            return estimation;

        }

        public int Cost()
        {
            return cost;

        }

        public bool HasAParent()
        {
            return parent != null;

        }

        public Node Parent()
        {
            return parent;

        }

        public CellIndices GetMoveToThis()
        {
            return moveToThis;

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


}
