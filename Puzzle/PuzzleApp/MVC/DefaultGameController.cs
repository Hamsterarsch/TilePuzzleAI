using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleApp.MVC
{
    interface GameController
    {
        void OnCellClicked(CellIndices indices);


    }

    class DefaultGameController : GameController
    {
        private Game targetGame;

        public DefaultGameController(Game targetGame)
        {
            this.targetGame = targetGame;

        }

       public void OnCellClicked(CellIndices indices)
       {
           targetGame.OnCellClicked(indices);

       }
        

    }


}
