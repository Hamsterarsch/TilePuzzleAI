using System.Collections.Generic;


namespace PuzzleApp
{
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
            AddInitialStateToOpen();

        }

            private void AddInitialStateToOpen()
            {
                open.Enqueue(new Node(board, 0, 0, null, new CellIndices(0, 0)));
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
                while (currentState.HasAParent())
                {
                    solutionPath.Add(currentState.GetMoveToThis());
                    currentState = currentState.Parent();
                }

                solutionPath.Reverse();
                return solutionPath;

            }

            private void AddSuccessorsToOpen(Node state)
            {
                foreach (Node successor in GetSuccessorStates(state))
                {
                    var openContainsSucessor = open.Contains(successor);

                    if (closed.Contains(successor) || openContainsSucessor)
                    {
                        continue;
                    }

                    if (!openContainsSucessor)
                    {
                        open.Enqueue(successor);
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

                        var successorCost = state.Cost() + 1;
                        successors[i] = new Node
                        (
                            board,
                            successorCost,
                            board.GetManhattanDistFromCompletion() + successorCost,
                            state,
                            moves[i]
                        );
                    }

                    return successors;

                }

                    


    }


}
