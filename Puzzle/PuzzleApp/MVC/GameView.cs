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
        void SetEventOnSolutionFound(Action<int> Event);
        void SetEventOnSolutionStepUpdated(Action<int> Event);

    }

    class NotifiableGameView : ObservableGameView
    {
        private Action<CellIndices, CellIndices> OnCellMoved;
        private Action OnGameWon;
        private Action<SquareBoard> OnBoardChanged;
        private Action<int> OnSolutionFound;
        private Action<int> OnSolutionStepUpdated;


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




        public void SetEventOnSolutionFound(Action<int> Event)
        {
            OnSolutionFound = Event;

        }

        public void NotifyOnSoltutionFound(int Steps)
        {
            OnSolutionFound?.Invoke(Steps);

        }



        public void SetEventOnSolutionStepUpdated(Action<int> Event)
        {
            OnSolutionStepUpdated = Event;

        }

        public void NotifyOnSolutionStepUpdated(int StepsRemaining)
        {
            OnSolutionStepUpdated?.Invoke(StepsRemaining);

        }


    }


}
