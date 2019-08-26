using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuzzleApp.MVC;

namespace PuzzleApp
{
    class DefaultApp : IDisposable, App
    {
        private Window mainWindow;
        private string controlSearchName;
        private DefaultGameController controller;
        private ObservableGameView view;
        private BoardRenderer boardRenderer;


        public DefaultApp()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var notifyableView = new NotifiableGameView();;
            this.view = notifyableView;
            var board = new SquareBoard(4);
            var game = new Game(notifyableView, board);
            this.controller = new DefaultGameController(game);
            mainWindow = new Window(view, controller);

            var outputControl = FindControl("BoardOutputTarget");
            var defaultImage = Image.FromFile("C:\\Users\\Hamsterarsch\\Desktop\\LnkdinPB.png");
            var cellFactory = new BoardCellFactory(controller, defaultImage);
            this.boardRenderer = new BoardRenderer(outputControl, board, cellFactory);
            view.SetEventOnCellMoved(boardRenderer.SwapCells);
            
            view.SetEventOnBoardChanged(boardRenderer.Render);

            boardRenderer.Render(board);


        }

        private void ChangePuzzleImage(string path)
        {
            Image image = null;
            try
            {
                image = Image.FromFile(path);
            }
            catch (Exception e)
            {
                //do nothing if the path is invalid
                return;
            }

            var cellFactory = new BoardCellFactory(controller, image);
            boardRenderer.SetCellFactory(cellFactory);
            boardRenderer.Render();

        }

        public void Startup()
        {
            Application.Run(mainWindow);

        }

        public void Dispose()
        {
            Shutdown();

        }

        private void Shutdown()
        {
            Application.Exit();

        }
        
        public Control FindControl(string name)
        {
            controlSearchName = name;

            var foundControls = mainWindow.Controls.Find(controlSearchName, true);
            return ValidateAndGetControl(foundControls);
        }
        
        private Control ValidateAndGetControl(Control[] foundTargets)
        {
            if (SearchIsAmbiguous(foundTargets))
            {
                throw new AmbiguousSearchException("Found multiple controls named " + controlSearchName + " to render the board to.");
            }

            if (NoResultExistsIn(foundTargets))
            {
                throw new ArgumentException("Could not find a control named " + controlSearchName + " to render the board to.");
            }

            return foundTargets[0];

        }

        private bool SearchIsAmbiguous(Control[] foundTargets)
        {
            return foundTargets.Length != 1;

        }

        private bool NoResultExistsIn(Control[] foundTargets)
        {
            return foundTargets.Length == 0;
        }


    }


}
