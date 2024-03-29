﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleApp
{
    public partial class ChangeImageControl : UserControl
    {
        private Image currentImage;
        private Action<string> OnImageSelected;

        public ChangeImageControl()
        {
            InitializeComponent();

            prompt_OpenImageFile.FileOk += Prompt_OpenImageFile_FileOk;

        }

        public void SetEventOnNewImageSelected(Action<string> Event)
        {
            OnImageSelected = Event;

        }

        private void btn_LoadNew_Click(object sender, EventArgs e)
        {
            prompt_OpenImageFile.ShowDialog();

        }

        private void Prompt_OpenImageFile_FileOk(object sender, CancelEventArgs e)
        {
            OnImageSelected?.Invoke(prompt_OpenImageFile.FileName);

        }
        

    }


}
