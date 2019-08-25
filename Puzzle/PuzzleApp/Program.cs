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

            var controller = new GameController(game);
            var app = new DefaultApp();
            
            var outputControl = app.FindControl("BoardOutputTarget");
            var cellFactory = new BoardCellFactory();
            var boardRenderer = new BoardRenderer(outputControl, board, cellFactory);

            boardRenderer.Render();

            app.Startup();


        }


    }


}
