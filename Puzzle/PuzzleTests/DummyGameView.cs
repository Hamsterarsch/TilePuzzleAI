using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuzzleApp;
using PuzzleApp.MVC;

namespace PuzzleTests
{
    class DummyGameView : ObservableGameView
    {
        public void SetEventOnCellMoved(Action<CellIndices, CellIndices> Event)
        {
        }

        public void SetEventOnGameWon(Action<int> Event)
        {
        }

        public void SetEventOnBoardChanged(Action<SquareBoard> Event)
        {
        }

        public void SetEventOnSolutionFound(Action<int> Event)
        {
        }

        public void SetEventOnSolutionStepUpdated(Action<int> Event)
        {
        }

        public void SetEventOnDrawCountChanged(Action<int> Event)
        {
        }


    }


}
