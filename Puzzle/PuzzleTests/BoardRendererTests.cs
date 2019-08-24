using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuzzleApp;

namespace PuzzleTests
{
    [TestClass]
    public class BoardRendererTests
    {
        private Board board;
        private Window window;
        private BoardRenderer boardRenderer;

        [TestMethod]
        public void DoesBoardRenderingAddControls()
        {
            CreateWindowAndRenderNewBoard();

            var windowDescendantCount = GetAmountOfDescendingControls(window);
            var expectedControlCount = boardRenderer.GetExpectedBoardControlCount();

            Assert.AreNotEqual(0, expectedControlCount, "Expected control count was zero.");
            Assert.IsTrue
            (
                 windowDescendantCount >= expectedControlCount,
                "The window did not contain enough ui elements after the board was added."
            );

        }

        private void CreateWindowAndRenderNewBoard()
        {
            board = new Board(TestValueProvider.BoardSize);
            window = new Window();
            var boardCellFactory = new BoardCellFactory();
            
            boardRenderer = new BoardRenderer(window, board, boardCellFactory);
            boardRenderer.Render();

        }

        private int GetAmountOfDescendingControls(Control control)
        {
            int ControlCount = 0;
            foreach (Control childControl in control.Controls)
            {
                ControlCount += childControl.Controls.Count;
                ControlCount += GetAmountOfDescendingControls(childControl);
            }
            
            return ControlCount;

        }

        [TestMethod]
        public void BoardHeightEqualsWindowHeight()
        {
            CreateWindowAndRenderNewBoard();

            Assert.IsTrue
            (
                boardRenderer.DoesBoardHeightEqual(window.Height),
                "The rendered board height does not take the whole window"
            );

        }

        [TestMethod]
        public void BoardWidthEqualsWindowWidth()
        {
            CreateWindowAndRenderNewBoard();

            Assert.IsTrue
            (
                boardRenderer.DoesBoardWidthEqual(window.Width),
                "The rendered board width does not take the whole window"
            );

        }


    }


}
