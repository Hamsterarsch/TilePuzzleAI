using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleApp.MVC
{
    class GameController
    {
        private Game targetGame;

        public GameController(Game targetGame)
        {
            this.targetGame = targetGame;

        }

        //start game
        void StartGame()
        {
            

        }
        
        //field clicked
        void OnCellClicked(CellIndices Indices)
        {

        }
        

    }
}
