namespace Rogue_Runner
{
    partial class Leaderboard
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
            this.nameHeader = new System.Windows.Forms.Label();
            this.timeHeader = new System.Windows.Forms.Label();
            this.enemyHeader = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.nameOutput = new System.Windows.Forms.Label();
            this.timeOutput = new System.Windows.Forms.Label();
            this.enemiesOutput = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameHeader
            // 
            this.nameHeader.BackColor = System.Drawing.Color.Transparent;
            this.nameHeader.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameHeader.ForeColor = System.Drawing.SystemColors.Control;
            this.nameHeader.Location = new System.Drawing.Point(41, 130);
            this.nameHeader.Name = "nameHeader";
            this.nameHeader.Size = new System.Drawing.Size(122, 50);
            this.nameHeader.TabIndex = 0;
            this.nameHeader.Text = "Name";
            // 
            // timeHeader
            // 
            this.timeHeader.BackColor = System.Drawing.Color.Transparent;
            this.timeHeader.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeHeader.ForeColor = System.Drawing.SystemColors.Control;
            this.timeHeader.Location = new System.Drawing.Point(197, 130);
            this.timeHeader.Name = "timeHeader";
            this.timeHeader.Size = new System.Drawing.Size(419, 50);
            this.timeHeader.TabIndex = 1;
            this.timeHeader.Text = "Time";
            this.timeHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // enemyHeader
            // 
            this.enemyHeader.BackColor = System.Drawing.Color.Transparent;
            this.enemyHeader.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemyHeader.ForeColor = System.Drawing.SystemColors.Control;
            this.enemyHeader.Location = new System.Drawing.Point(612, 130);
            this.enemyHeader.Name = "enemyHeader";
            this.enemyHeader.Size = new System.Drawing.Size(254, 50);
            this.enemyHeader.TabIndex = 2;
            this.enemyHeader.Text = "Enemies Killed";
            // 
            // headerLabel
            // 
            this.headerLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerLabel.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.headerLabel.Location = new System.Drawing.Point(36, 38);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(830, 92);
            this.headerLabel.TabIndex = 3;
            this.headerLabel.Text = "Longest Run Leaderboard";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nameOutput
            // 
            this.nameOutput.BackColor = System.Drawing.Color.Transparent;
            this.nameOutput.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameOutput.ForeColor = System.Drawing.SystemColors.Control;
            this.nameOutput.Location = new System.Drawing.Point(41, 180);
            this.nameOutput.Name = "nameOutput";
            this.nameOutput.Size = new System.Drawing.Size(184, 456);
            this.nameOutput.TabIndex = 4;
            this.nameOutput.Text = "AAA";
            // 
            // timeOutput
            // 
            this.timeOutput.BackColor = System.Drawing.Color.Transparent;
            this.timeOutput.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeOutput.ForeColor = System.Drawing.SystemColors.Control;
            this.timeOutput.Location = new System.Drawing.Point(338, 180);
            this.timeOutput.Name = "timeOutput";
            this.timeOutput.Size = new System.Drawing.Size(243, 456);
            this.timeOutput.TabIndex = 0;
            this.timeOutput.Text = "00:00.00";
            // 
            // enemiesOutput
            // 
            this.enemiesOutput.BackColor = System.Drawing.Color.Transparent;
            this.enemiesOutput.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemiesOutput.ForeColor = System.Drawing.SystemColors.Control;
            this.enemiesOutput.Location = new System.Drawing.Point(612, 180);
            this.enemiesOutput.Name = "enemiesOutput";
            this.enemiesOutput.Size = new System.Drawing.Size(237, 456);
            this.enemiesOutput.TabIndex = 6;
            this.enemiesOutput.Text = "0";
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Black;
            this.backButton.FlatAppearance.BorderSize = 3;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Century Gothic", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Location = new System.Drawing.Point(679, 591);
            this.backButton.Margin = new System.Windows.Forms.Padding(2);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(185, 72);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // Leaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::Rogue_Runner.Properties.Resources.big_room;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.enemiesOutput);
            this.Controls.Add(this.timeOutput);
            this.Controls.Add(this.nameOutput);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.enemyHeader);
            this.Controls.Add(this.timeHeader);
            this.Controls.Add(this.nameHeader);
            this.DoubleBuffered = true;
            this.Name = "Leaderboard";
            this.Size = new System.Drawing.Size(900, 700);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label nameHeader;
        private System.Windows.Forms.Label timeHeader;
        private System.Windows.Forms.Label enemyHeader;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label nameOutput;
        private System.Windows.Forms.Label timeOutput;
        private System.Windows.Forms.Label enemiesOutput;
        private System.Windows.Forms.Button backButton;
    }
}
