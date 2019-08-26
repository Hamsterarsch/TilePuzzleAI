using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
            var app = new DefaultApp();
            
            
            
            app.Startup();


        }


    }


}
