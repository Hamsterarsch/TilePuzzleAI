using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           // var game = new Game();


            /*

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            const int boardSize = 4;
            var board = new Board(boardSize);
            var window = new Window();

            var cellFactory = new BoardCellFactory();

            var foundControls = window.Controls.Find("BoardOutputTarget", false);

            if (foundControls.Length > 1)
            {
                throw new Exception("Found multiple controls named 'BoardOutputTarget' to render the board to");
            }
            else if (foundControls.Length == 0)
            {
                throw new Exception("Could not find a control named 'BoardOutputTarget' to render the board to");
            }
            
            var boardRenderer = new BoardRenderer(foundControls[0], board, cellFactory);
            boardRenderer.Render();

            Application.Run(window);
            */
        }


    }


}
