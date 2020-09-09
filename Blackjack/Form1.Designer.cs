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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.startButton = new System.Windows.Forms.Button();
            this.stayButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.hitButton = new System.Windows.Forms.Button();
            this.PnlGame = new System.Windows.Forms.Panel();
            this.betValue = new System.Windows.Forms.TextBox();
            this.lblBetAmount = new System.Windows.Forms.Label();
            this.TmrChips = new System.Windows.Forms.Timer(this.components);
            this.lblChips = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PnlGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(18, 78);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stayButton
            // 
            this.stayButton.Location = new System.Drawing.Point(516, 429);
            this.stayButton.Name = "stayButton";
            this.stayButton.Size = new System.Drawing.Size(75, 23);
            this.stayButton.TabIndex = 5;
            this.stayButton.Text = "Stay";
            this.stayButton.UseVisualStyleBackColor = true;
            this.stayButton.Visible = false;
            this.stayButton.Click += new System.EventHandler(this.stayButton_Click);
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
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // hitButton
            // 
            this.hitButton.Location = new System.Drawing.Point(613, 429);
            this.hitButton.Name = "hitButton";
            this.hitButton.Size = new System.Drawing.Size(75, 23);
            this.hitButton.TabIndex = 7;
            this.hitButton.Text = "Hit";
            this.hitButton.UseVisualStyleBackColor = true;
            this.hitButton.Visible = false;
            this.hitButton.Click += new System.EventHandler(this.hitButton_Click);
            // 
            // PnlGame
            // 
            this.PnlGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(85)))));
            this.PnlGame.Controls.Add(this.betValue);
            this.PnlGame.Controls.Add(this.lblBetAmount);
            this.PnlGame.Controls.Add(this.startButton);
            this.PnlGame.Location = new System.Drawing.Point(1, 1);
            this.PnlGame.Name = "PnlGame";
            this.PnlGame.Size = new System.Drawing.Size(799, 410);
            this.PnlGame.TabIndex = 8;
            this.PnlGame.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlGame_Paint);
            // 
            // betValue
            // 
            this.betValue.Location = new System.Drawing.Point(18, 43);
            this.betValue.Name = "betValue";
            this.betValue.Size = new System.Drawing.Size(100, 20);
            this.betValue.TabIndex = 5;
            // 
            // lblBetAmount
            // 
            this.lblBetAmount.AutoSize = true;
            this.lblBetAmount.Location = new System.Drawing.Point(15, 18);
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
            // lblChips
            // 
            this.lblChips.AutoSize = true;
            this.lblChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChips.Location = new System.Drawing.Point(67, 429);
            this.lblChips.Name = "lblChips";
            this.lblChips.Size = new System.Drawing.Size(40, 18);
            this.lblChips.TabIndex = 9;
            this.lblChips.Text = "1000";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(19, 424);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 464);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblChips);
            this.Controls.Add(this.hitButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.stayButton);
            this.Controls.Add(this.PnlGame);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PnlGame.ResumeLayout(false);
            this.PnlGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stayButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button hitButton;
        private System.Windows.Forms.Panel PnlGame;
        private System.Windows.Forms.Timer TmrChips;
        private System.Windows.Forms.Label lblChips;
        private System.Windows.Forms.TextBox betValue;
        private System.Windows.Forms.Label lblBetAmount;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

