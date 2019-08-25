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

        public void SetEventOnGameWon(Action Event)
        {
            
        }


    }


}
