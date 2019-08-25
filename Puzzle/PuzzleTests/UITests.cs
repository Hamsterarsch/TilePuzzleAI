using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuzzleApp;

namespace PuzzleTests
{
    [TestClass]
    public class UITests
    {
        [TestMethod]
        public void CanWindowBeCreated()
        {
            var board = new Board(TestValueProvider.BoardSize);
            var window = new Window(new DummyGameView());

        }


    }


}
