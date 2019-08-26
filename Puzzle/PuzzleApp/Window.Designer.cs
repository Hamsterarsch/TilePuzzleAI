namespace PuzzleApp
{
    partial class Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BoardOutputTarget = new System.Windows.Forms.Panel();
            this.ctrl_boardSize = new PuzzleApp.BoardSizeControl();
            this.ctrl_ChangeImage = new PuzzleApp.ChangeImageControl();
            this.SuspendLayout();
            // 
            // BoardOutputTarget
            // 
            this.BoardOutputTarget.Location = new System.Drawing.Point(12, 12);
            this.BoardOutputTarget.Name = "BoardOutputTarget";
            this.BoardOutputTarget.Size = new System.Drawing.Size(600, 600);
            this.BoardOutputTarget.TabIndex = 0;
            // 
            // ctrl_boardSize
            // 
            this.ctrl_boardSize.Location = new System.Drawing.Point(678, 12);
            this.ctrl_boardSize.Name = "ctrl_boardSize";
            this.ctrl_boardSize.Size = new System.Drawing.Size(75, 84);
            this.ctrl_boardSize.TabIndex = 1;
            // 
            // ctrl_ChangeImage
            // 
            this.ctrl_ChangeImage.Location = new System.Drawing.Point(628, 102);
            this.ctrl_ChangeImage.Name = "ctrl_ChangeImage";
            this.ctrl_ChangeImage.Size = new System.Drawing.Size(170, 59);
            this.ctrl_ChangeImage.TabIndex = 2;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 623);
            this.Controls.Add(this.ctrl_ChangeImage);
            this.Controls.Add(this.ctrl_boardSize);
            this.Controls.Add(this.BoardOutputTarget);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puzzle";
            this.Load += new System.EventHandler(this.Window_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel BoardOutputTarget;
        private BoardSizeControl ctrl_boardSize;
        private ChangeImageControl ctrl_ChangeImage;
    }
}

