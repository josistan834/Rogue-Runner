namespace Rogue_Runner
{
    partial class ScoreInputScreen
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
            this.letter3Output = new System.Windows.Forms.Button();
            this.letter2Output = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.letter1Output = new System.Windows.Forms.Button();
            this.playAgainButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // letter3Output
            // 
            this.letter3Output.BackColor = System.Drawing.Color.White;
            this.letter3Output.Enabled = false;
            this.letter3Output.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letter3Output.Location = new System.Drawing.Point(537, 284);
            this.letter3Output.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.letter3Output.Name = "letter3Output";
            this.letter3Output.Size = new System.Drawing.Size(160, 148);
            this.letter3Output.TabIndex = 254;
            this.letter3Output.TabStop = false;
            this.letter3Output.Text = "A";
            this.letter3Output.UseVisualStyleBackColor = false;
            this.letter3Output.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.letter3Output_PreviewKeyDown);
            // 
            // letter2Output
            // 
            this.letter2Output.BackColor = System.Drawing.Color.White;
            this.letter2Output.Enabled = false;
            this.letter2Output.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letter2Output.Location = new System.Drawing.Point(371, 284);
            this.letter2Output.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.letter2Output.Name = "letter2Output";
            this.letter2Output.Size = new System.Drawing.Size(160, 148);
            this.letter2Output.TabIndex = 253;
            this.letter2Output.TabStop = false;
            this.letter2Output.Text = "A";
            this.letter2Output.UseVisualStyleBackColor = false;
            this.letter2Output.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.letter2Output_PreviewKeyDown);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.White;
            this.exitButton.Enabled = false;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSalmon;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitButton.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(143, 500);
            this.exitButton.Margin = new System.Windows.Forms.Padding(5);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(259, 95);
            this.exitButton.TabIndex = 256;
            this.exitButton.TabStop = false;
            this.exitButton.Text = "Menu";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.Enter += new System.EventHandler(this.exitButton_Enter);
            this.exitButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.exitButton_PreviewKeyDown);
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameOverLabel.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameOverLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.gameOverLabel.Location = new System.Drawing.Point(0, 60);
            this.gameOverLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(900, 207);
            this.gameOverLabel.TabIndex = 251;
            this.gameOverLabel.Text = "Game Over";
            this.gameOverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // letter1Output
            // 
            this.letter1Output.BackColor = System.Drawing.Color.White;
            this.letter1Output.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letter1Output.Location = new System.Drawing.Point(204, 284);
            this.letter1Output.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.letter1Output.Name = "letter1Output";
            this.letter1Output.Size = new System.Drawing.Size(160, 148);
            this.letter1Output.TabIndex = 252;
            this.letter1Output.TabStop = false;
            this.letter1Output.Text = "A";
            this.letter1Output.UseVisualStyleBackColor = false;
            this.letter1Output.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.letter1Output_PreviewKeyDown);
            // 
            // playAgainButton
            // 
            this.playAgainButton.BackColor = System.Drawing.Color.White;
            this.playAgainButton.Enabled = false;
            this.playAgainButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.playAgainButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SpringGreen;
            this.playAgainButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SpringGreen;
            this.playAgainButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.playAgainButton.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playAgainButton.Location = new System.Drawing.Point(491, 500);
            this.playAgainButton.Margin = new System.Windows.Forms.Padding(5);
            this.playAgainButton.Name = "playAgainButton";
            this.playAgainButton.Size = new System.Drawing.Size(259, 95);
            this.playAgainButton.TabIndex = 255;
            this.playAgainButton.TabStop = false;
            this.playAgainButton.Text = "Play Again";
            this.playAgainButton.UseVisualStyleBackColor = false;
            this.playAgainButton.Click += new System.EventHandler(this.playAgainButton_Click);
            this.playAgainButton.Enter += new System.EventHandler(this.playAgainButton_Enter);
            this.playAgainButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.playAgainButton_PreviewKeyDown);
            // 
            // ScoreInputScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::Rogue_Runner.Properties.Resources.big_room;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.letter3Output);
            this.Controls.Add(this.letter2Output);
            this.Controls.Add(this.letter1Output);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.playAgainButton);
            this.Controls.Add(this.gameOverLabel);
            this.DoubleBuffered = true;
            this.Name = "ScoreInputScreen";
            this.Size = new System.Drawing.Size(900, 700);
            this.Load += new System.EventHandler(this.ScoreInputScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button letter3Output;
        private System.Windows.Forms.Button letter2Output;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.Button letter1Output;
        private System.Windows.Forms.Button playAgainButton;
    }
}
