using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleApp.MVC
{
    interface ObservableGameView
    {
        void SetEventOnCellMoved(Action<CellIndices, CellIndices> Event);
        void SetEventOnGameWon(Action Event);
        void SetEventOnBoardChanged(Action<SquareBoard> Event);

    }

    class NotifiableGameView : ObservableGameView
    {
        private Action<CellIndices, CellIndices> OnCellMoved;
        private Action OnGameWon;
        private Action<SquareBoard> OnBoardChanged;


        public void SetEventOnCellMoved(Action<CellIndices, CellIndices> Event)
        {
            OnCellMoved = Event;

        }

        public void NotifyOnCellMoved(CellIndices FromPos, CellIndices ToPos)
        {
            OnCellMoved?.Invoke(FromPos, ToPos);

        }



        public void SetEventOnGameWon(Action Event)
        {
            OnGameWon = Event;

        }

        public void NotifyOnGameWon()
        {
            OnGameWon?.Invoke();

        }
        


        public void SetEventOnBoardChanged(Action<SquareBoard> Event)
        {
            OnBoardChanged = Event;

        }
        
        public void NotifyOnBoardChanged(SquareBoard Board)
        {
            OnBoardChanged?.Invoke(Board);

        }


    }


}
