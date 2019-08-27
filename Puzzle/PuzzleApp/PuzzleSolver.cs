using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PuzzleApp
{
    interface Priority
    {
        float Priority();

    }

    class Node : Priority
    {
        public SquareBoard board;
        public int estimation;
        public readonly int cost;//does this matter as property of the state in open closed searches ?
        public readonly Node parent;
        public readonly CellIndices moveToThis;

        public Node(SquareBoard board, int cost, Node parent, CellIndices moveToThis)
        {
            this.parent = parent;
            this.board = board;
            this.cost = cost;
            this.estimation = board.GetManhattenDistFromSolution() + cost;
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
            open.Enqueue(new Node(board, 0, null, new CellIndices(0,0)));
            
        }

        public List<CellIndices> GetMovesToSolution()
        {
            while (ThereAreUnexaminedStates())
            {
                var state = GetNextState();
                if (StateIsGoalState(state))
                {
                    return GetMovesToGoalState(state);
                }

                AddSuccessorsToOpen(state);
                closed.Add(state);
            }

            return new List<CellIndices>();

        }

            private bool ThereAreUnexaminedStates()
            {
                return !open.IsEmpty();

            }

            private Node GetNextState()
            {
                return open.Dequeue();

            }

            private bool StateIsGoalState(Node state)
            {
                return state.board.GetCellAmount() == state.board.GetCorrectCellAmount();

            }

            private List<CellIndices> GetMovesToGoalState(Node state)
            {
                var solutionPath = new List<CellIndices>();
                var currentState = state;
                while (currentState.parent != null)
                {
                    solutionPath.Add(currentState.moveToThis);
                    currentState = currentState.parent;
                }

                solutionPath.Reverse();
                return solutionPath;

            }

            private void AddSuccessorsToOpen(Node state)
            {
                foreach (Node node in GetSuccessorStates(state))
                {
                    var bIsInClosed = closed.Contains(node);
                    var bIsInOpen = open.Contains(node);

                    if ((bIsInClosed || bIsInOpen))
                    {
                        continue;
                    }

                    if (!bIsInOpen)
                    {
                        open.Enqueue(node);
                    }
                }

            }

            private Node[] GetSuccessorStates(Node state)
            {
                var generator = new MoveGenerator(state.board);
                var moves = generator.GetMoves();

                var successors = new Node[moves.Length];
                for (int i = 0; i < moves.Length; ++i)
                {
                    var board = new SquareBoard(state.board);
                    board.SwapCells(board.GetEmptyCellPos(), moves[i]);

                    successors[i] = new Node(board, state.cost + 1, state, moves[i]);
                }

                return successors;

            }


    }


}
