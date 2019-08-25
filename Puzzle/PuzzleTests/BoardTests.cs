using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuzzleApp;

namespace PuzzleTests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void AreCellsCorrectlySetUp()
        {
            var board = new Board(4);

            Assert.IsTrue(board.IsCellCorrect(new CellIndices(0, 0)) );
            Assert.IsTrue(board.IsCellCorrect(new CellIndices(2, 3)) );
            Assert.IsTrue(board.IsCellCorrect(new CellIndices(3, 3)) );

        }

        [TestMethod]
        public void CellsCanBeSwapped()
        {
            var board = new Board(4);
            var CellIndices00 = new CellIndices(0, 0);
            var CellIndices22 = new CellIndices(2, 2);

            board.SwapCells(CellIndices00, CellIndices22);

            Assert.IsFalse(board.IsCellCorrect(CellIndices00));

            board.SwapCells(CellIndices00, CellIndices22);

            Assert.IsTrue(board.IsCellCorrect(CellIndices00));
            Assert.IsTrue(board.IsCellCorrect(CellIndices22));

        }

        [TestMethod]
        public void EmptyAdjacency()
        {
            var board = new Board(4);

            var CellIndices32 = new CellIndices(3, 2);
            Assert.IsTrue(board.CellIsAdjacentToEmpty(CellIndices32));

            var CellIndices22 = new CellIndices(2, 2);
            Assert.IsFalse(board.CellIsAdjacentToEmpty(CellIndices22));
            
            var CellIndices12 = new CellIndices(1, 2);
            Assert.IsFalse(board.CellIsAdjacentToEmpty(CellIndices12));

        }


    }


}
