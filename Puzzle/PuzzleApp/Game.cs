using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using PuzzleApp.MVC;

namespace PuzzleApp
{
    class Game
    {
        private NotifiableGameView view;
        private SquareBoard board;
        private bool bIsGameBeingSolved;

        private List<CellIndices> currentSolution;
        private int nextSolutionStepIndex;
        private System.Windows.Forms.Timer solveTimer;
        private int drawCounter;

        public Game(NotifiableGameView view, SquareBoard board)
        {
            this.view = view;
            this.board = board;
            this.bIsGameBeingSolved = false;
            this.drawCounter = 0;

            DisorderBoard();

        }

        public void OnCellClicked(CellIndices indices)
        {
            if (bIsGameBeingSolved)
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
            if (bIsGameBeingSolved)
            {
                return;
            }

            this.board = new SquareBoard(size);
            DisorderBoard();

            view.NotifyOnBoardChanged(board);

        }

        public void SolvePuzzle()
        {
            if (bIsGameBeingSolved)
            {
                return;

            }

            bIsGameBeingSolved = true;

            var solver = new PuzzleSolver(board);

            currentSolution = solver.GetMovesToSolution();
            nextSolutionStepIndex = 0;
            if (currentSolution.Count == 0)
            {
                return;
            }

            view.NotifyOnSoltutionFound(currentSolution.Count);

            solveTimer = new System.Windows.Forms.Timer();
            solveTimer.Interval = 350;
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
                    bIsGameBeingSolved = false;
                }

            }

        public bool IsCompleted()
        {
            return board.GetCorrectCellAmount() == board.GetCellAmount();

        }

        public void DisorderBoard()
        {
            //todo: fix magic tokens and abstraction levels
            var moveGenerator = new MoveGenerator(board);

            const int disorderSteps = 100;
            for (int i = 0; i < disorderSteps; ++i)
            {
                var move = moveGenerator.GetMove();
                MoveCellAccordingToRules(move);
            }

            //this may be too predictable
            //align column
            var boundary = board.SizeInCells() - 1;
            while (board.GetEmptyCellPos().column < boundary)
            {
                var emptyPos = board.GetEmptyCellPos();
                emptyPos.column += 1;

                MoveCellAccordingToRules(emptyPos);

            }

            //align row
            while (board.GetEmptyCellPos().row < boundary)
            {
                var emptyPos = board.GetEmptyCellPos();
                emptyPos.row += 1;

                MoveCellAccordingToRules(emptyPos);

            }


        }


    }


}
