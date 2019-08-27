using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuzzleApp;
using PuzzleApp.MVC;

namespace PuzzleTests
{
    [TestClass]
    public class PuzzleSolverTests
    {
        [TestMethod]
        public void Solve3x3()
        {
            var board = new SquareBoard(3);
            var game = new Game(new NotifiableGameView(), board);
            var solver = new PuzzleSolver(board);

            var solutionPath = solver.GetMovesToSolution();
            Assert.IsTrue(solutionPath.Count > 0, "The puzzle was already solved");

            ApplySolutionPathToGame(game, solutionPath);

            Assert.IsTrue(game.IsCompleted());


        }

            private void ApplySolutionPathToGame(Game game, List<CellIndices> solutionPath)
            {
                foreach (CellIndices move in solutionPath)
                {
                    game.OnCellClicked(move);
                }

            }

        [TestMethod]
        public void Solve4x4()
        {
            var board = new SquareBoard(4);
            var game = new Game(new NotifiableGameView(), board);
            var solver = new PuzzleSolver(board);

            var solutionPath = solver.GetMovesToSolution();
            Assert.IsTrue(solutionPath.Count > 0, "The puzzle was already solved");

            ApplySolutionPathToGame(game, solutionPath);

            Assert.IsTrue(game.IsCompleted());


        }

        [TestMethod]
        public void Solve5x5()
        {
            var board = new SquareBoard(5);
            var game = new Game(new NotifiableGameView(), board);
            var solver = new PuzzleSolver(board);

            var solutionPath = solver.GetMovesToSolution();
            Assert.IsTrue(solutionPath.Count > 0, "The puzzle was already solved");

            ApplySolutionPathToGame(game, solutionPath);

            Assert.IsTrue(game.IsCompleted());


        }

    }
}
