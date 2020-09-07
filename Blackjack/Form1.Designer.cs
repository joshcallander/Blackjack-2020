namespace Blackjack
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.resultLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.startButton = new System.Windows.Forms.Button();
            this.PlayerStopButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.dealButton = new System.Windows.Forms.Button();
            this.PnlGame = new System.Windows.Forms.Panel();
            this.betValue = new System.Windows.Forms.TextBox();
            this.lblBetAmount = new System.Windows.Forms.Label();
            this.TmrChips = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.PnlGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.Location = new System.Drawing.Point(14, 371);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(117, 18);
            this.resultLabel.TabIndex = 0;
            this.resultLabel.Text = "Game Loading...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(18, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 96);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(113, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(71, 96);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(206, 21);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(71, 96);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(345, 263);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // PlayerStopButton
            // 
            this.PlayerStopButton.Location = new System.Drawing.Point(516, 429);
            this.PlayerStopButton.Name = "PlayerStopButton";
            this.PlayerStopButton.Size = new System.Drawing.Size(75, 23);
            this.PlayerStopButton.TabIndex = 5;
            this.PlayerStopButton.Text = "Stay";
            this.PlayerStopButton.UseVisualStyleBackColor = true;
            this.PlayerStopButton.Visible = false;
            this.PlayerStopButton.Click += new System.EventHandler(this.PlayerStopButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(713, 429);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 6;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Visible = false;
            // 
            // dealButton
            // 
            this.dealButton.Location = new System.Drawing.Point(613, 429);
            this.dealButton.Name = "dealButton";
            this.dealButton.Size = new System.Drawing.Size(75, 23);
            this.dealButton.TabIndex = 7;
            this.dealButton.Text = "Deal";
            this.dealButton.UseVisualStyleBackColor = true;
            this.dealButton.Visible = false;
            // 
            // PnlGame
            // 
            this.PnlGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(85)))));
            this.PnlGame.Controls.Add(this.betValue);
            this.PnlGame.Controls.Add(this.lblBetAmount);
            this.PnlGame.Controls.Add(this.pictureBox1);
            this.PnlGame.Controls.Add(this.pictureBox2);
            this.PnlGame.Controls.Add(this.startButton);
            this.PnlGame.Controls.Add(this.pictureBox4);
            this.PnlGame.Controls.Add(this.resultLabel);
            this.PnlGame.Location = new System.Drawing.Point(1, 1);
            this.PnlGame.Name = "PnlGame";
            this.PnlGame.Size = new System.Drawing.Size(799, 410);
            this.PnlGame.TabIndex = 8;
            this.PnlGame.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlGame_Paint);
            // 
            // betValue
            // 
            this.betValue.Location = new System.Drawing.Point(345, 224);
            this.betValue.Name = "betValue";
            this.betValue.Size = new System.Drawing.Size(100, 20);
            this.betValue.TabIndex = 5;
            // 
            // lblBetAmount
            // 
            this.lblBetAmount.AutoSize = true;
            this.lblBetAmount.Location = new System.Drawing.Point(342, 199);
            this.lblBetAmount.Name = "lblBetAmount";
            this.lblBetAmount.Size = new System.Drawing.Size(62, 13);
            this.lblBetAmount.TabIndex = 4;
            this.lblBetAmount.Text = "Bet Amount";
            // 
            // TmrChips
            // 
            this.TmrChips.Enabled = true;
            this.TmrChips.Tick += new System.EventHandler(this.TmrChips_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 439);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "1000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 464);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dealButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.PlayerStopButton);
            this.Controls.Add(this.PnlGame);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.PnlGame.ResumeLayout(false);
            this.PnlGame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button PlayerStopButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button dealButton;
        private System.Windows.Forms.Panel PnlGame;
        private System.Windows.Forms.Timer TmrChips;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox betValue;
        private System.Windows.Forms.Label lblBetAmount;
    }
}

