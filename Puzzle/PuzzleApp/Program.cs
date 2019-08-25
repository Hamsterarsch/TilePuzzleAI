using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuzzleApp.MVC;

namespace PuzzleApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var view = new NotifiableGameView();
            var board = new Board(4);
            var game = new Game(view, board);

            var controller = new DefaultGameController(game);
            var app = new DefaultApp(view);
            
            var outputControl = app.FindControl("BoardOutputTarget");
            var cellFactory = new BoardCellFactory(controller);

            var boardRenderer = new BoardRenderer(outputControl, board, cellFactory);
            view.SetEventOnCellMoved(boardRenderer.SwapCells);

            boardRenderer.Render();

            app.Startup();


        }


    }


}
