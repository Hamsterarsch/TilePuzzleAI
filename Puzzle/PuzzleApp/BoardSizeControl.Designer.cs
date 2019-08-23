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
            this.btn_Decrease = new System.Windows.Forms.Button();
            this.btn_Increase = new System.Windows.Forms.Button();
            this.txtb_Current = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Decrease
            // 
            this.btn_Decrease.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Decrease.Location = new System.Drawing.Point(0, 0);
            this.btn_Decrease.Name = "btn_Decrease";
            this.btn_Decrease.Size = new System.Drawing.Size(40, 36);
            this.btn_Decrease.TabIndex = 0;
            this.btn_Decrease.Text = "<";
            this.btn_Decrease.UseVisualStyleBackColor = true;
            // 
            // btn_Increase
            // 
            this.btn_Increase.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Increase.Location = new System.Drawing.Point(144, 0);
            this.btn_Increase.Name = "btn_Increase";
            this.btn_Increase.Size = new System.Drawing.Size(44, 36);
            this.btn_Increase.TabIndex = 1;
            this.btn_Increase.Text = ">";
            this.btn_Increase.UseVisualStyleBackColor = true;
            // 
            // txtb_Current
            // 
            this.txtb_Current.Location = new System.Drawing.Point(46, 9);
            this.txtb_Current.Name = "txtb_Current";
            this.txtb_Current.ReadOnly = true;
            this.txtb_Current.Size = new System.Drawing.Size(92, 20);
            this.txtb_Current.TabIndex = 2;
            // 
            // BoardSizeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtb_Current);
            this.Controls.Add(this.btn_Increase);
            this.Controls.Add(this.btn_Decrease);
            this.Name = "BoardSizeControl";
            this.Size = new System.Drawing.Size(188, 36);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Decrease;
        private System.Windows.Forms.Button btn_Increase;
        private System.Windows.Forms.TextBox txtb_Current;
    }
}
