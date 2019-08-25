using System;
using System.Collections.Generic;
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


        public DefaultApp(ObservableGameView view)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainWindow = new Window(view);


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
