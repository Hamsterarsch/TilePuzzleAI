﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuzzleApp;

namespace PuzzleTests
{
    class DummyApp : App
    {
        public Control FindControl(string name)
        {
            return new Panel();

        }


    }


}
