using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuzzleApp;

namespace PuzzleTests
{
    [TestClass]
    public class MoveGeneratorTests
    {
        [TestMethod]
        public void GetRandomMove()
        {
            var board = new SquareBoard(4);
            var generator = new MoveGenerator(board);

            const int repeat = 10000;
            for (int i = 0; i < repeat; ++i)
            {
                var cellIndices = generator.GetMove();
                Assert.IsTrue(board.CellIsAdjacentToEmpty(cellIndices));
            }

        }


    }


}
