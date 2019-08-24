using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleApp.MVC
{
    interface OberservableGameView
    {
        void SetEventOnCellMoved(Action<CellIndices, CellIndices> Event);
        void SetEventOnGameWon(Action Event);

    }

    class NotifiableGameView : OberservableGameView
    {
        private Action<CellIndices, CellIndices> OnCellMoved;
        private Action OnGameWon;


        public void SetEventOnCellMoved(Action<CellIndices, CellIndices> Event)
        {
            OnCellMoved = Event;

        }

        public void NotifyOnCellMoved(CellIndices FromPos, CellIndices ToPos)
        {
            OnCellMoved.Invoke(FromPos, ToPos);

        }


        public void SetEventOnGameWon(Action Event)
        {
            OnGameWon = Event;

        }

        public void NotifyOnGameWon()
        {
            OnGameWon.Invoke();

        }
        
        
    }


}
