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
            this.btn_Solve = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_SolutionSteps = new System.Windows.Forms.Label();
            this.txt_SoltionStepsRemaining = new System.Windows.Forms.Label();
            this.pnl_SolutionInfo = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_DrawAmount = new System.Windows.Forms.Label();
            this.pnl_SolutionInfo.SuspendLayout();
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
            // btn_Solve
            // 
            this.btn_Solve.Location = new System.Drawing.Point(632, 167);
            this.btn_Solve.Name = "btn_Solve";
            this.btn_Solve.Size = new System.Drawing.Size(162, 46);
            this.btn_Solve.TabIndex = 3;
            this.btn_Solve.Text = "Solve Puzzle";
            this.btn_Solve.UseVisualStyleBackColor = true;
            this.btn_Solve.Click += new System.EventHandler(this.btn_Solve_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Solution Steps:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Steps Remaining:";
            // 
            // txt_SolutionSteps
            // 
            this.txt_SolutionSteps.AutoSize = true;
            this.txt_SolutionSteps.Location = new System.Drawing.Point(109, 11);
            this.txt_SolutionSteps.Name = "txt_SolutionSteps";
            this.txt_SolutionSteps.Size = new System.Drawing.Size(14, 13);
            this.txt_SolutionSteps.TabIndex = 6;
            this.txt_SolutionSteps.Text = "X";
            // 
            // txt_SoltionStepsRemaining
            // 
            this.txt_SoltionStepsRemaining.AutoSize = true;
            this.txt_SoltionStepsRemaining.Location = new System.Drawing.Point(109, 45);
            this.txt_SoltionStepsRemaining.Name = "txt_SoltionStepsRemaining";
            this.txt_SoltionStepsRemaining.Size = new System.Drawing.Size(14, 13);
            this.txt_SoltionStepsRemaining.TabIndex = 7;
            this.txt_SoltionStepsRemaining.Text = "X";
            // 
            // pnl_SolutionInfo
            // 
            this.pnl_SolutionInfo.Controls.Add(this.label1);
            this.pnl_SolutionInfo.Controls.Add(this.txt_SoltionStepsRemaining);
            this.pnl_SolutionInfo.Controls.Add(this.label2);
            this.pnl_SolutionInfo.Controls.Add(this.txt_SolutionSteps);
            this.pnl_SolutionInfo.Location = new System.Drawing.Point(649, 254);
            this.pnl_SolutionInfo.Name = "pnl_SolutionInfo";
            this.pnl_SolutionInfo.Size = new System.Drawing.Size(132, 68);
            this.pnl_SolutionInfo.TabIndex = 8;
            this.pnl_SolutionInfo.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(651, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Your Draws:";
            // 
            // txt_DrawAmount
            // 
            this.txt_DrawAmount.AutoSize = true;
            this.txt_DrawAmount.Location = new System.Drawing.Point(758, 229);
            this.txt_DrawAmount.Name = "txt_DrawAmount";
            this.txt_DrawAmount.Size = new System.Drawing.Size(13, 13);
            this.txt_DrawAmount.TabIndex = 10;
            this.txt_DrawAmount.Text = "0";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 623);
            this.Controls.Add(this.txt_DrawAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnl_SolutionInfo);
            this.Controls.Add(this.btn_Solve);
            this.Controls.Add(this.ctrl_ChangeImage);
            this.Controls.Add(this.ctrl_boardSize);
            this.Controls.Add(this.BoardOutputTarget);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puzzle";
            this.Load += new System.EventHandler(this.Window_Load);
            this.pnl_SolutionInfo.ResumeLayout(false);
            this.pnl_SolutionInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel BoardOutputTarget;
        private BoardSizeControl ctrl_boardSize;
        private ChangeImageControl ctrl_ChangeImage;
        private System.Windows.Forms.Button btn_Solve;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txt_SolutionSteps;
        private System.Windows.Forms.Label txt_SoltionStepsRemaining;
        private System.Windows.Forms.Panel pnl_SolutionInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txt_DrawAmount;
    }
}

