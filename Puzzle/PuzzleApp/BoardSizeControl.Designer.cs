namespace PuzzleApp
{
    partial class BoardSizeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rad_3x3 = new System.Windows.Forms.RadioButton();
            this.rad_4x4 = new System.Windows.Forms.RadioButton();
            this.rad_5x5 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rad_3x3
            // 
            this.rad_3x3.AutoSize = true;
            this.rad_3x3.Location = new System.Drawing.Point(20, 12);
            this.rad_3x3.Name = "rad_3x3";
            this.rad_3x3.Size = new System.Drawing.Size(42, 17);
            this.rad_3x3.TabIndex = 0;
            this.rad_3x3.TabStop = true;
            this.rad_3x3.Text = "3x3";
            this.rad_3x3.UseVisualStyleBackColor = true;
            this.rad_3x3.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rad_4x4
            // 
            this.rad_4x4.AutoSize = true;
            this.rad_4x4.Location = new System.Drawing.Point(20, 35);
            this.rad_4x4.Name = "rad_4x4";
            this.rad_4x4.Size = new System.Drawing.Size(42, 17);
            this.rad_4x4.TabIndex = 1;
            this.rad_4x4.TabStop = true;
            this.rad_4x4.Text = "4x4";
            this.rad_4x4.UseVisualStyleBackColor = true;
            this.rad_4x4.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rad_5x5
            // 
            this.rad_5x5.AutoSize = true;
            this.rad_5x5.Location = new System.Drawing.Point(20, 58);
            this.rad_5x5.Name = "rad_5x5";
            this.rad_5x5.Size = new System.Drawing.Size(42, 17);
            this.rad_5x5.TabIndex = 2;
            this.rad_5x5.TabStop = true;
            this.rad_5x5.Text = "5x5";
            this.rad_5x5.UseVisualStyleBackColor = true;
            this.rad_5x5.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // BoardSizeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rad_5x5);
            this.Controls.Add(this.rad_4x4);
            this.Controls.Add(this.rad_3x3);
            this.Name = "BoardSizeControl";
            this.Size = new System.Drawing.Size(80, 83);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rad_3x3;
        private System.Windows.Forms.RadioButton rad_4x4;
        private System.Windows.Forms.RadioButton rad_5x5;
    }
}
