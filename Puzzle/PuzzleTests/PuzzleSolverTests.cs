using System;
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

            solver.Solve();

            Assert.IsTrue(game.IsCompleted());


        }
    }
}
