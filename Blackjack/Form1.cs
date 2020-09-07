using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Blackjack
{
    public partial class Form1 : Form
    {
        // Create the lists for the cards
        List<Card> playercardList = new List<Card>()
        {
            new Card() { Value  = 0, Name = "null", Image = null }
        };

        List<Card> bankercardList = new List<Card>()
        {
            new Card() { Value  = 0, Name = "null", Image = null }
        };

        // Create varibles for total card values
        int playercardSum = 0;
        int bankercardSum = 0;
        
        // Set up the chip amounts
        int chipCount = 1000;
        int bet = 0;
        
        Random random = new Random();

        // Create lists
        List<int> usedCards = new List<int>();
        List<PictureBox> bankerbox = new List<PictureBox>();
        List<PictureBox> playerbox = new List<PictureBox>();

        // Declare varibles for welcome screen chips
        Graphics g;
        Rectangle[] chipContainer = new Rectangle[10];
        int[] chipSpeed = new int[9]; 
        int[] chipColour = new int[9];
        int y = 20, x = 20;
        bool showChips = true;

        // Create the list for the deck
        List<Card> deck = new List<Card>()
        {
            new Card() { Value  = 2, Name = "Two Spades", Image = Blackjack.Properties.Resources._2S },
            new Card() { Value = 3, Name = "Three Spades", Image = Blackjack.Properties.Resources._3S },
            new Card() { Value = 4, Name =  "Four Spades", Image = Blackjack.Properties.Resources._4S },
            new Card() { Value = 5, Name = "Five Spades", Image = Blackjack.Properties.Resources._5S },
            new Card() { Value = 6, Name = "Six Spades", Image = Blackjack.Properties.Resources._6S },
            new Card() { Value = 7, Name = "Seven Spades", Image = Blackjack.Properties.Resources._7S },
            new Card() { Value = 8, Name = "Eight Spades", Image = Blackjack.Properties.Resources._8S },
            new Card() { Value = 9, Name = "Nine Spades", Image = Blackjack.Properties.Resources._9S },
            new Card() { Value = 10, Name = "Ten Spades", Image = Blackjack.Properties.Resources._10S },
            new Card() { Value = 10, Name = "Jack Spades", Image = Blackjack.Properties.Resources.JS },
            new Card() { Value = 10, Name = "Queen Spades", Image = Blackjack.Properties.Resources.QS },
            new Card(){ Value = 10, Name = "King Spades", Image = Blackjack.Properties.Resources.KS },
            new Card(){ Value = 11, Name = "Ace Spades", Image = Blackjack.Properties.Resources.AS },

            new Card() { Value  = 2, Name = "Two Diamonds", Image = Blackjack.Properties.Resources._2D },
            new Card() { Value = 3, Name = "Three Diamonds", Image = Blackjack.Properties.Resources._3D },
            new Card() { Value = 4, Name =  "Four Diamonds", Image = Blackjack.Properties.Resources._4D },
            new Card() { Value = 5, Name = "Five Diamonds", Image = Blackjack.Properties.Resources._5D },
            new Card() { Value = 6, Name = "Six Diamonds", Image = Blackjack.Properties.Resources._6D },
            new Card() { Value = 7, Name = "Seven Diamonds", Image = Blackjack.Properties.Resources._7D },
            new Card() { Value = 8, Name = "Eight Diamonds", Image = Blackjack.Properties.Resources._8D },
            new Card() { Value = 9, Name = "Nine Diamonds", Image = Blackjack.Properties.Resources._9D },
            new Card() { Value = 10, Name = "Ten Diamonds", Image = Blackjack.Properties.Resources._10D },
            new Card() { Value = 10, Name = "Jack Diamonds", Image = Blackjack.Properties.Resources.JD },
            new Card() { Value = 10, Name = "Queen Diamonds", Image = Blackjack.Properties.Resources.QD },
            new Card(){ Value = 10, Name = "King Diamonds", Image = Blackjack.Properties.Resources.KD },
            new Card(){ Value = 11, Name = "Ace Diamonds", Image = Blackjack.Properties.Resources.AD },

            new Card() { Value  = 2, Name = "Two Clubs", Image = Blackjack.Properties.Resources._2C },
            new Card() { Value = 3, Name = "Three Clubs", Image = Blackjack.Properties.Resources._3C },
            new Card() { Value = 4, Name =  "Four Clubs", Image = Blackjack.Properties.Resources._4C },
            new Card() { Value = 5, Name = "Five Clubs", Image = Blackjack.Properties.Resources._5C },
            new Card() { Value = 6, Name = "Six Clubs", Image = Blackjack.Properties.Resources._6C },
            new Card() { Value = 7, Name = "Seven Clubs", Image = Blackjack.Properties.Resources._7C },
            new Card() { Value = 8, Name = "Eight Clubs", Image = Blackjack.Properties.Resources._8C },
            new Card() { Value = 9, Name = "Nine Clubs", Image = Blackjack.Properties.Resources._9C },
            new Card() { Value = 10, Name = "Ten Clubs", Image = Blackjack.Properties.Resources._10C },
            new Card() { Value = 10, Name = "Jack Clubs", Image = Blackjack.Properties.Resources.JC },
            new Card() { Value = 10, Name = "Queen Clubs", Image = Blackjack.Properties.Resources.QC },
            new Card(){ Value = 10, Name = "King Clubs", Image = Blackjack.Properties.Resources.KC },
            new Card(){ Value = 11, Name = "Ace Clubs", Image = Blackjack.Properties.Resources.AC },

            new Card() { Value  = 2, Name = "Two Hearts", Image = Blackjack.Properties.Resources._2H },
            new Card() { Value = 3, Name = "Three Hearts", Image = Blackjack.Properties.Resources._3H },
            new Card() { Value = 4, Name =  "Four Hearts", Image = Blackjack.Properties.Resources._4H },
            new Card() { Value = 5, Name = "Five Hearts", Image = Blackjack.Properties.Resources._5H },
            new Card() { Value = 6, Name = "Six Hearts", Image = Blackjack.Properties.Resources._6H },
            new Card() { Value = 7, Name = "Seven Hearts", Image = Blackjack.Properties.Resources._7H },
            new Card() { Value = 8, Name = "Eight Hearts", Image = Blackjack.Properties.Resources._8H },
            new Card() { Value = 9, Name = "Nine Hearts", Image = Blackjack.Properties.Resources._9H },
            new Card() { Value = 10, Name = "Ten Hearts", Image = Blackjack.Properties.Resources._10H },
            new Card() { Value = 10, Name = "Jack Hearts", Image = Blackjack.Properties.Resources.JH },
            new Card() { Value = 10, Name = "Queen Hearts", Image = Blackjack.Properties.Resources.QH },
            new Card(){ Value = 10, Name = "King Hearts", Image = Blackjack.Properties.Resources.KH },
            new Card(){ Value = 11, Name = "Ace Hearts", Image = Blackjack.Properties.Resources.AH }
        };

        public Form1()
        {
            InitializeComponent();

            // Prevent buffering
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, PnlGame, new object[] { true });

            // Loop through creating a container for each chip
            for (int i = 0; i <= 8; i++)
            {
                chipContainer[i] = new Rectangle(y, x + 49 * i, 30, 30);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Reset the game
            resetGame();
        }

        private void PnlGame_Paint(object sender, PaintEventArgs e)
        {
            // Get the methods from the graphic's class to paint on the panel
            g = e.Graphics;

            // If showChips is enabled
            if (showChips == true)
            {
                // Use the DrawImage method to draw each of the chips onto the panel
                for (int i = 0; i <= 8; i++)
                {
                    chipColour[i] = random.Next(1, 5);

                    if (chipColour[i] == 1)
                    {
                        g.DrawImage(Blackjack.Properties.Resources.blue_chip, chipContainer[i]);
                    }

                    else if (chipColour[i] == 2)
                    {
                        g.DrawImage(Blackjack.Properties.Resources.green_chip, chipContainer[i]);
                    }

                    else if (chipColour[i] == 3)
                    {
                        g.DrawImage(Blackjack.Properties.Resources.red_chip, chipContainer[i]);
                    }

                    else if (chipColour[i] == 4)
                    {
                        g.DrawImage(Blackjack.Properties.Resources.white_chip, chipContainer[i]);
                    }

                    else if (chipColour[i] == 5)
                    {
                        g.DrawImage(Blackjack.Properties.Resources.black_chip, chipContainer[i]);
                    }
                }
            }
        }

        private void TmrChips_Tick(object sender, EventArgs e)
        {
            // If showChips is enabled
            if (showChips == true)
            {
                // Loop through each of the chips on tick of the timer
                for (int i = 0; i <= 8; i++)
                {
                    chipSpeed[i] = random.Next(10, 23);

                    chipContainer[i].X += chipSpeed[i]; // Set each chip to the correct speed

                    if (chipContainer[i].X > PnlGame.Width)
                    { // If the chip reaches the end of the panel
                        chipContainer[i].X = -25; // Move the chip back to the begining of the panel
                    }
                }
            }

            PnlGame.Invalidate();
        }

        //start the game
        private void startButton_Click(object sender, EventArgs e)
        {
            if (betValue.Text == "" || betValue.Text == "0" || (Convert.ToInt32(betValue.Text) < 1) || (Convert.ToInt32(betValue.Text) > chipCount))
            { // If the bet amount is invalid
                bet = Convert.ToInt32(betValue.Text); // Get the bet value textbox and set the bet intiger to it
                MessageBox.Show("Please enter a valid bet amount!"); // Display an error message
            }

            else
            { // Else the bet amount is valid
                playercardSum = 0;
                bankercardSum = 0;

                int randomCard1 = selectRandomCard();
                Card card1 = deck[randomCard1];
                usedCards.Add(randomCard1);
                int randomCard2 = selectRandomCard();
                while (usedCards.Contains(randomCard2))
                {
                    randomCard2 = selectRandomCard();
                }

                randomCard2 = 1 * randomCard2;

                Card card2 = deck[randomCard2];
                usedCards.Add(randomCard2);

                playercardList.Add(card1);
                playercardList.Add(card2);

                pictureBox1.Image = card1.Image;
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

                pictureBox2.Image = card2.Image;
                pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;

                int randomCard3 = selectRandomCard();
                while (usedCards.Contains(randomCard3))
                {
                    randomCard3 = selectRandomCard();
                }

                randomCard3 = 1 * randomCard3;
                Card card3 = deck[randomCard3];
                usedCards.Add(randomCard3);

                bankercardList.Add(card3);

                pictureBox4.Image = card3.Image;
                pictureBox4.SizeMode = PictureBoxSizeMode.AutoSize;

                sumPlayerCards();

                PlayerStopButton.Visible = true;
                dealButton.Visible = true;
                resetButton.Visible = true;

                pictureBox1.Visible = true;
                pictureBox2.Visible = true;

                lblBetAmount.Visible = false;
                betValue.Visible = false;
                startButton.Visible = false;

                showChips = false;

                if (playercardSum == 21)
                { // If the score is 21
                    MessageBox.Show(String.Format("You win! The sum of your cards is: {0}", playercardSum)); // Show the message box
                    resetGame(); // Call the reset the game function
                }
            }
        }

        private int selectRandomCard()
        {
            int randomCard;
            randomCard = random.Next(0, deck.Count);
            return randomCard;
        }

        private void sumPlayerCards()
        {
            playercardSum = 0;
            
            for (int i = 0; i < playercardList.Count; i++)
            {
                playercardSum += playercardList[i].Value;
            }

            if (playercardSum > 21)
            {
                foreach (Card c in playercardList)
                {
                    if (c.Value == 11)
                    {
                        playercardSum -= 10;
                        if (playercardSum <= 21)
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void sumBankerCards()
        {
            bankercardSum = 0;
            
            for (int i = 0; i < bankercardList.Count; i++)
            {
                bankercardSum += bankercardList[i].Value;
            }

            if (bankercardSum > 21)
            {
                foreach (Card c in bankercardList)
                {
                    if (c.Value == 11)
                    {
                        bankercardSum -= 10;
                        if (bankercardSum <= 21)
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void DealButton_Click(object sender, EventArgs e)
        {
                playercardSum = 0;
                
                int randomCard = selectRandomCard();
                Card card = deck[randomCard];
                usedCards.Add(randomCard);

                if (usedCards.Contains(randomCard)) { randomCard = selectRandomCard(); }
                else { randomCard = 1 * randomCard; }

                //player new card
                PictureBox p3 = new PictureBox();
                p3.Width = 71;
                p3.Height = 96;
                p3.Visible = true;
                p3.Location = new Point(154 + 77 + playerbox.Count * 77, 137);
                p3.Image = card.Image;
                p3.SizeMode = PictureBoxSizeMode.AutoSize;
                this.Controls.Add(p3);

                playerbox.Add(p3);

                playercardList.Add(card);

                sumPlayerCards();

                if (playercardSum > 21)
                {
                    MessageBox.Show(String.Format("You lose! The sum of your cards is: {0}", playercardSum)); // Show the result - the player has lost the game
                    resetGame(); // Call the reset game function
                    
                    chipCount = chipCount - bet; // Decrease the chip count by the amount bet
                    lblChips.Text = chipCount.ToString(); // Change the text of the chip count label to the new chip count
                }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            resetGame(); // Call the reset game function
        }

        private void resetGame()
        {
            resultLabel.Text = null;

            foreach (PictureBox pb in playerbox)
            {
                this.Controls.Remove(pb);
            }

            playerbox = new List<PictureBox>();
            foreach (PictureBox pb in bankerbox)
            {
                this.Controls.Remove(pb);
            }

            bankerbox = new List<PictureBox>();

            playercardSum = 0;
            bankercardSum = 0;
            chipCount = 1000;
            playercardList.Clear();
            bankercardList.Clear();
            usedCards.Clear();
            resultLabel.Text = "Please enter bet amount";

            PlayerStopButton.Visible = false;
            dealButton.Visible = false;
            resetButton.Visible = false;

            lblBetAmount.Visible = true;
            betValue.Visible = true;
            startButton.Visible = true;

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox4.Visible = false;

            showChips = true;
        }

        // palyer stop move
        private void PlayerStopButton_Click(object sender, EventArgs e)
        {
            sumBankerCards();

            while (bankercardSum <= 16)
            {
                int randomCard = selectRandomCard();
                Card card = deck[randomCard];
                usedCards.Add(randomCard);

                if (usedCards.Contains(randomCard)) randomCard = selectRandomCard();
                else randomCard = 1 * randomCard;

                PictureBox p4 = new PictureBox();
                p4.Width = 71;
                p4.Height = 96;
                p4.Location = new Point(154 + bankerbox.Count * 77, 12);
                p4.Image = card.Image;
                p4.SizeMode = PictureBoxSizeMode.AutoSize;
                this.Controls.Add(p4);

                bankerbox.Add(p4);

                bankercardList.Add(card);
                sumBankerCards();
            }

            if (playercardSum > bankercardSum && playercardSum <= 21)
            { // If the sum of the players cards is greater than the sum of the dealers cards and the sum of the players cards is less than or equal to 21
                MessageBox.Show(String.Format("You win! The sum of dealers cards is: {0}", bankercardSum)); // Show the result - the player has won the game
                resetGame(); // Call the reset game function
                    
                chipCount = chipCount + bet; // Decrease the chip count by the amount bet
                lblChips.Text = chipCount.ToString(); // Change the text of the chip count label to the new chip count
            }

            else if (playercardSum == bankercardSum && playercardSum <= 21)
            { // If the sum of the players cards is equal to the sum of the bankers cards and the sum of the players cards is less than or euqal to 21
                MessageBox.Show(String.Format("You lose! The sum of the dealers cards is: {0}", bankercardSum)); // Show the result - the player has lost the game
                resetGame(); // Call the reset game function
                
                chipCount = chipCount - bet; // Decrease the chip count by the amount bet
                lblChips.Text = chipCount.ToString(); // Change the text of the chip count label to the new chip count
            }

            else if (playercardSum < bankercardSum && bankercardSum <= 21)
            { // If the sum of the players cards is less than the sum of the dealers cards and the sum of the dealers cards is less than or equal to 21
                MessageBox.Show(String.Format("You win! The sum of the dealers cards is: {0}", bankercardSum));; // Show the result - the player has lost the game
                resetGame(); // Call the reset game function
                
                chipCount = chipCount - bet; // Decrease the chip count by the amount bet
                lblChips.Text = chipCount.ToString(); // Change the text of the chip count label to the new chip count
            }

        }
    }
}
