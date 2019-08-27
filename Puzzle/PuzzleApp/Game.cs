using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PuzzleApp.MVC;


namespace PuzzleApp
{
    class Game
    {
        private NotifiableGameView view;
        private SquareBoard board;
        private bool isGameBeingSolved;
        private List<CellIndices> currentSolution;
        private int nextSolutionStepIndex;
        private System.Windows.Forms.Timer solveTimer;
        private int drawCounter;

        private const int replayStepTimeInMs = 350;
        private const int disorderingMoveAmount = 100;


        public Game(NotifiableGameView view, SquareBoard board)
        {
            this.view = view;
            this.board = board;
            this.isGameBeingSolved = false;
            this.drawCounter = 0;

            this.solveTimer = new System.Windows.Forms.Timer();
            solveTimer.Interval = replayStepTimeInMs;

            DisorderBoard();

        }
        


        public void OnCellClicked(CellIndices indices)
        {
            if (isGameBeingSolved)
            {
                return;
            }

            MoveCellAccordingToRules(indices);
            ++drawCounter;
            view.NotifyOnDrawCountChanged(drawCounter);

            if (IsCompleted())
            {
                view.NotifyOnGameWon(drawCounter);
                drawCounter = 0;

            }

        }

            private void MoveCellAccordingToRules(CellIndices indices)
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
            if (isGameBeingSolved)
            {
                return;
            }

            this.board = new SquareBoard(size);
            DisorderBoard();

            view.NotifyOnBoardChanged(board);

        }

        public void SolvePuzzle()
        {
            if (isGameBeingSolved)
            {
                return;

            }
            isGameBeingSolved = true;

            var solver = new PuzzleSolver(board);
            currentSolution = solver.GetMovesToSolution();
            if (SolutionIsValid())
            {
                BeginReplaySolution();
            }
            

        }

            private bool SolutionIsValid()
            {
                return currentSolution.Count > 0;

            }

            private void BeginReplaySolution()
            {
                nextSolutionStepIndex = 0;
                view.NotifyOnSoltutionFound(currentSolution.Count);

                
                solveTimer = new Timer();//timers seem to be stateful, so create a new one to work with the newest game state
                solveTimer.Interval = replayStepTimeInMs;
                solveTimer.Tick += ExecuteSolutionStep;
                solveTimer.Start();

            }

                private void ExecuteSolutionStep(object o, EventArgs e)
                {
                    MoveCellAccordingToRules(currentSolution[nextSolutionStepIndex]);
                    ++nextSolutionStepIndex;

                    view.NotifyOnSolutionStepUpdated(currentSolution.Count - nextSolutionStepIndex);

                    if (IsCompleted())
                    {
                        solveTimer.Stop();
                        isGameBeingSolved = false;
                    }

                }

        public bool IsCompleted()
        {
            return board.GetCorrectCellAmount() == board.GetCellAmount();

        }

        public void DisorderBoard()
        {
            var moveGenerator = new MoveGenerator(board);
            
            for (int i = 0; i < disorderingMoveAmount; ++i)
            {
                var move = moveGenerator.GetMove();
                MoveCellAccordingToRules(move);
            }

            MoveEmptyPosToRightmostColumn();
            MoveEmptyPosToLowestRow();

        }

            private void MoveEmptyPosToRightmostColumn()
            {
                var boundary = board.SizeInCells() - 1;
                while (board.GetEmptyCellPos().column < boundary)
                {
                    var emptyPos = board.GetEmptyCellPos();
                    emptyPos.column += 1;

                    MoveCellAccordingToRules(emptyPos);
                }

            }

            private void MoveEmptyPosToLowestRow()
            {
                var boundary = board.SizeInCells() - 1;
                while (board.GetEmptyCellPos().row < boundary)
                {
                    var emptyPos = board.GetEmptyCellPos();
                    emptyPos.row += 1;

                    MoveCellAccordingToRules(emptyPos);

                }

            }


    }


}
