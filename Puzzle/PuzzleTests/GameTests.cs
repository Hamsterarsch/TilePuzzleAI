using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuzzleApp;
using PuzzleApp.MVC;

namespace PuzzleTests
{
    [TestClass]
    public class GameTests
    {
        private const int boardSize = 4;

        [TestMethod]
        public void GameCreation()
        {
            var view = new NotifiableGameView();
            var game = new Game(view, new Board(boardSize));

            var controller = new GameController(game);

        }
        

    }


}
