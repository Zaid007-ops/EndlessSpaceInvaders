namespace EndlessSpaceInvasion
{
    partial class HighScores
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
            this.dataGridViewHighScores = new System.Windows.Forms.DataGridView();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.labelSort = new System.Windows.Forms.Label();
            this.labelLimit = new System.Windows.Forms.Label();
            this.comboBoxLimit = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHighScores)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHighScores
            // 
            this.dataGridViewHighScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHighScores.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewHighScores.Name = "dataGridViewHighScores";
            this.dataGridViewHighScores.RowTemplate.Height = 25;
            this.dataGridViewHighScores.Size = new System.Drawing.Size(401, 450);
            this.dataGridViewHighScores.TabIndex = 0;
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(338, 12);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter.TabIndex = 1;
            this.buttonFilter.Text = "Filter";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Items.AddRange(new object[] {
            "ASC",
            "DESC"});
            this.comboBoxSort.Location = new System.Drawing.Point(49, 13);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(121, 23);
            this.comboBoxSort.TabIndex = 2;
            // 
            // labelSort
            // 
            this.labelSort.AutoSize = true;
            this.labelSort.Location = new System.Drawing.Point(12, 16);
            this.labelSort.Name = "labelSort";
            this.labelSort.Size = new System.Drawing.Size(31, 15);
            this.labelSort.TabIndex = 3;
            this.labelSort.Text = "Sort:";
            // 
            // labelLimit
            // 
            this.labelLimit.AutoSize = true;
            this.labelLimit.Location = new System.Drawing.Point(176, 16);
            this.labelLimit.Name = "labelLimit";
            this.labelLimit.Size = new System.Drawing.Size(37, 15);
            this.labelLimit.TabIndex = 4;
            this.labelLimit.Text = "Limit:";
            // 
            // comboBoxLimit
            // 
            this.comboBoxLimit.FormattingEnabled = true;
            this.comboBoxLimit.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.comboBoxLimit.Location = new System.Drawing.Point(220, 13);
            this.comboBoxLimit.Name = "comboBoxLimit";
            this.comboBoxLimit.Size = new System.Drawing.Size(112, 23);
            this.comboBoxLimit.TabIndex = 5;
            // 
            // HighScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 504);
            this.Controls.Add(this.comboBoxLimit);
            this.Controls.Add(this.labelLimit);
            this.Controls.Add(this.labelSort);
            this.Controls.Add(this.comboBoxSort);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.dataGridViewHighScores);
            this.Name = "HighScores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "High Scores";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHighScores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHighScores;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.Label labelSort;
        private System.Windows.Forms.Label labelLimit;
        private System.Windows.Forms.ComboBox comboBoxLimit;
    }
}