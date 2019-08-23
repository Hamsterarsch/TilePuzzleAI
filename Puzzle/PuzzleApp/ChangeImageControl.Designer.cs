namespace PuzzleApp
{
    partial class ChangeImageControl
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
            this.btn_LoadNew = new System.Windows.Forms.Button();
            this.prompt_OpenImageFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btn_LoadNew
            // 
            this.btn_LoadNew.Location = new System.Drawing.Point(3, 3);
            this.btn_LoadNew.Name = "btn_LoadNew";
            this.btn_LoadNew.Size = new System.Drawing.Size(164, 53);
            this.btn_LoadNew.TabIndex = 0;
            this.btn_LoadNew.Text = "Load New Image";
            this.btn_LoadNew.UseVisualStyleBackColor = true;
            this.btn_LoadNew.Click += new System.EventHandler(this.btn_LoadNew_Click);
            // 
            // prompt_OpenImageFile
            // 
            this.prompt_OpenImageFile.FileName = "None";
            this.prompt_OpenImageFile.Filter = "Images|*.png;*.jpg;*.jpeg";
            // 
            // ChangeImageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_LoadNew);
            this.Name = "ChangeImageControl";
            this.Size = new System.Drawing.Size(170, 59);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_LoadNew;
        private System.Windows.Forms.OpenFileDialog prompt_OpenImageFile;
    }
}
