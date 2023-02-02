namespace EndlessSpaceInvasion
{
    partial class MainMenu
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
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonLeaderboard = new System.Windows.Forms.Button();
            this.buttonUserGuide = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackColor = System.Drawing.SystemColors.InfoText;
            this.buttonPlay.Font = new System.Drawing.Font("Segoe UI", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonPlay.ForeColor = System.Drawing.Color.Lime;
            this.buttonPlay.Location = new System.Drawing.Point(12, 147);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(403, 82);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Play !!!";
            this.buttonPlay.UseVisualStyleBackColor = false;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonLeaderboard
            // 
            this.buttonLeaderboard.BackColor = System.Drawing.Color.Black;
            this.buttonLeaderboard.Font = new System.Drawing.Font("Segoe UI", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLeaderboard.ForeColor = System.Drawing.Color.Lime;
            this.buttonLeaderboard.Location = new System.Drawing.Point(12, 235);
            this.buttonLeaderboard.Name = "buttonLeaderboard";
            this.buttonLeaderboard.Size = new System.Drawing.Size(403, 82);
            this.buttonLeaderboard.TabIndex = 1;
            this.buttonLeaderboard.Text = "Leaderboard";
            this.buttonLeaderboard.UseVisualStyleBackColor = false;
            this.buttonLeaderboard.Click += new System.EventHandler(this.buttonLeaderboard_Click);
            // 
            // buttonUserGuide
            // 
            this.buttonUserGuide.BackColor = System.Drawing.Color.Black;
            this.buttonUserGuide.Font = new System.Drawing.Font("Segoe UI", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonUserGuide.ForeColor = System.Drawing.Color.Lime;
            this.buttonUserGuide.Location = new System.Drawing.Point(12, 323);
            this.buttonUserGuide.Name = "buttonUserGuide";
            this.buttonUserGuide.Size = new System.Drawing.Size(403, 82);
            this.buttonUserGuide.TabIndex = 2;
            this.buttonUserGuide.Text = "User Guide";
            this.buttonUserGuide.UseVisualStyleBackColor = false;
            this.buttonUserGuide.Click += new System.EventHandler(this.buttonUserGuide_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.BackColor = System.Drawing.Color.Black;
            this.buttonQuit.Font = new System.Drawing.Font("Segoe UI", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonQuit.ForeColor = System.Drawing.Color.Lime;
            this.buttonQuit.Location = new System.Drawing.Point(12, 411);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(403, 82);
            this.buttonQuit.TabIndex = 3;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = false;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlText;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Ivory;
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 74);
            this.label1.TabIndex = 4;
            this.label1.Text = "Space Invaders";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(16, 118);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.PlaceholderText = "Enter Username";
            this.textBoxUsername.Size = new System.Drawing.Size(399, 23);
            this.textBoxUsername.TabIndex = 5;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(425, 504);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.buttonUserGuide);
            this.Controls.Add(this.buttonLeaderboard);
            this.Controls.Add(this.buttonPlay);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonLeaderboard;
        private System.Windows.Forms.Button buttonUserGuide;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUsername;
    }
}