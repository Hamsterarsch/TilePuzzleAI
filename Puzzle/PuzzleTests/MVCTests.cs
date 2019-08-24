using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuzzleApp;
using PuzzleApp.MVC;

namespace PuzzleTests
{
    [TestClass]
    public class MvcViewTests
    {
        private NotifiableGameView gameView;
        private ObservableGameView view;
        private bool bWasGameWonTriggered;
        private bool bWasMoveEventTriggered;
        private readonly CellIndices FromPos = new CellIndices(0, 1);
        private readonly CellIndices ToPos = new CellIndices(1, 2);

        [TestMethod]
        public void ViewReceivesWinEvent()
        {
            CreateObservableAndGameView();

            RegisterAndTriggerWinEvent();

            Assert.IsTrue(bWasGameWonTriggered);

        }
        
        private void CreateObservableAndGameView()
        {
            gameView = new NotifiableGameView();
            view = gameView;

        }

        private void RegisterAndTriggerWinEvent()
        {
            view.SetEventOnGameWon(OnGameWon);
            gameView.NotifyOnGameWon();

        }

        private void OnGameWon()
        {
            bWasGameWonTriggered = true;
        }



        [TestMethod]
        public void ViewReceivesMoveEvent()
        {
            CreateObservableAndGameView();

            RegisterAndTriggerMoveEvent();

            Assert.IsTrue(bWasMoveEventTriggered);

        }

        private void RegisterAndTriggerMoveEvent()
        {
            view.SetEventOnCellMoved(OnCellMoved);
            gameView.NotifyOnCellMoved(FromPos, ToPos);

        }

        private void OnCellMoved(CellIndices FromPos, CellIndices ToPos)
        {
            bWasMoveEventTriggered = bWasMoveEventTriggered = true;

            if (FromPos != this.FromPos || ToPos != this.ToPos)
            {
                Assert.Fail("The parameter ordering of the cell moved event is incorrect.");

            }

        }

        
    }


}
