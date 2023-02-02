namespace EndlessSpaceInvasion
{
    partial class UserGuide
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
            this.richTextBoxGuide = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxGuide
            // 
            this.richTextBoxGuide.Location = new System.Drawing.Point(11, 10);
            this.richTextBoxGuide.Name = "richTextBoxGuide";
            this.richTextBoxGuide.Size = new System.Drawing.Size(402, 482);
            this.richTextBoxGuide.TabIndex = 0;
            this.richTextBoxGuide.Text = "";
            // 
            // UserGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 504);
            this.Controls.Add(this.richTextBoxGuide);
            this.Name = "UserGuide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Guide";
            this.Load += new System.EventHandler(this.UserGuide_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxGuide;
    }
}