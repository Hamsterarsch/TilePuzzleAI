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

        private NotifiableGameView view;
        private SquareBoard board;
        private Game game;
        private GameController controller;


        [TestInitialize]
        public void Init()
        {
            this.view = new NotifiableGameView();
            this.board = new SquareBoard(boardSize);
            this.game = new Game(view, board);

            this.controller = new DefaultGameController(game);

        }

        [TestMethod]
        public void CellAdjacentToEmptyCellIsMovedOnClick()
        {
            controller.OnCellClicked(new CellIndices(3, 3));
            controller.OnCellClicked(new CellIndices(2, 3));

            Assert.IsFalse(board.IsCellCorrect(new CellIndices(3, 3)) );
            
        }
        

    }


}
