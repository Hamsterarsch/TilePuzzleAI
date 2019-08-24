using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleApp
{
    class Game
    {
        private const int defaultBoardSize = 4;
        private const string renderTargetControlName = "BoardOutputTarget";

        private Board board;
        private BoardRenderer renderer;
        private Window mainWindow;
        private BoardCellFactory currentCellProvider;
        private App targetApp;

        public Game(App targetApp)
        {
            this.targetApp = targetApp;

        }

        public void Start()
        {
            CreateBoardAndRenderer();

            renderer.Render();
            
        }

        private void CreateBoardAndRenderer()
        {
            board = new Board(defaultBoardSize);
            renderer = CreateBoardRendererAndCellProviderFor(board);

        }
        
        private BoardRenderer CreateBoardRendererAndCellProviderFor(Board board)
        {
            var targetControl = targetApp.FindControl(renderTargetControlName);
            currentCellProvider = new BoardCellFactory();
            return new BoardRenderer(targetControl, board, currentCellProvider);

        }
        

    }


}
