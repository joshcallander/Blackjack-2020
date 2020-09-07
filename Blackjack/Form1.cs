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
        int bet = 0;

        // Create the lists for the cards
        List<Card> playercardList = new List<Card>()
        {
            new Card() { Value  = 0, Name = "null", Image = "null" }
        };

        List<Card> bankercardList = new List<Card>()
        {
            new Card() { Value  = 0, Name = "null", Image = "null" }
        };

        // Create varibles for blackjack
        int playercardSum = 0;
        int bankercardSum = 0;
        int chipCount = 1000;
        Random random = new Random();

        // Create lists
        List<int> usedCards = new List<int>();
        List<PictureBox> bankerbox = new List<PictureBox>();
        List<PictureBox> playerbox = new List<PictureBox>();

        // Declare varibles for welcome screen chips
        Graphics g;
        Rectangle[] chipContainer = new Rectangle[14];
        int[] chipSpeed = new int[13]; 
        int[] chipColour = new int[13];
        int y = 20, x = 20;
        bool showChips = true;

        // Create the list for the deck
        List<Card> deck = new List<Card>()
            {
                #region spades

                new Card() { Value  = 2, Name = "Two Spades", Image = "2S.png" },
                new Card() { Value = 3, Name = "Three Spades", Image = "3S.png"},
                new Card() { Value = 4, Name =  "Four Spades", Image = "4S.png"},
                new Card() { Value = 5, Name = "Five Spades", Image = "5S.png" },
                new Card() { Value = 6, Name = "Six Spades", Image = "6S.png" },
                new Card() { Value = 7, Name = "Seven Spades", Image = "7S.png" },
                new Card() { Value = 8, Name = "Eight Spades", Image = "8S.png" },
                new Card() { Value = 9, Name = "Nine Spades", Image = "9S.png" },
                new Card() { Value = 10, Name = "Ten Spades", Image = "10S.png" },
                new Card() { Value = 10, Name = "Jack Spades", Image = "JS.png" },
                new Card() { Value = 10, Name = "Queen Spades", Image = "QS.png" },
                new Card(){ Value = 10, Name = "King Spades", Image = "KS.png" },
                new Card(){ Value = 11, Name = "Ace Spades", Image = "AS.png" },

                #endregion

                #region diamonds

                new Card() { Value  = 2, Name = "Two Diamonds", Image = "2D.png" },
                new Card() { Value = 3, Name = "Three Diamonds", Image = "3D.png" },
                new Card() { Value = 4, Name =  "Four Diamonds", Image = "4D.png"},
                new Card() { Value = 5, Name = "Five Diamonds", Image = "5D.png" },
                new Card() { Value = 6, Name = "Six Diamonds", Image = "6D.png" },
                new Card(){ Value = 7, Name = "Seven Diamonds", Image = "7D.png" },
                new Card() { Value = 8, Name = "Eight Diamonds", Image = "8D.png" },
                new Card() { Value = 9, Name = "Nine Diamonds", Image = "9D.png" },
                new Card() { Value = 10, Name = "Ten Diamonds", Image = "10D.png" },
                new Card() { Value = 10, Name = "Jack Diamonds", Image = "JD.png" },
                new Card() { Value = 10, Name = "Queen Diamonds", Image = "QD.png" },
                new Card(){ Value = 10, Name = "King Diamonds", Image = "KD.png" },
                new Card(){ Value = 11, Name = "Ace Diamonds", Image = "AD.png" },

                #endregion

                #region clubs

                new Card() { Value  = 2, Name = "Two Clubs", Image = "2C.png" },
                new Card() { Value = 3, Name = "Three Clubs", Image = "3C.png" },
                new Card() { Value = 4, Name =  "Four Clubs", Image = "4C.png"},
                new Card() { Value = 5, Name = "Five Clubs", Image = "5C.png" },
                new Card() { Value = 6, Name = "Six Clubs", Image = "6C.png" },
                new Card(){ Value = 7, Name = "Seven Clubs", Image = "7C.png" },
                new Card() { Value = 8, Name = "Eight Clubs", Image = "8C.png" },
                new Card() { Value = 9, Name = "Nine Clubs", Image= "9C.png" },
                new Card() { Value = 10, Name = "Ten Clubs", Image = "10C.png" },
                new Card() { Value = 10, Name = "Jack Clubs", Image = "JC.png" },
                new Card() { Value = 10, Name = "Queen Clubs", Image = "QC.png" },
                new Card(){ Value = 10, Name = "King Clubs", Image = "KC.png" },
                new Card(){ Value = 11, Name = "Ace Clubs", Image = "AC.png" },

                #endregion

                #region hearts

                new Card() { Value  = 2, Name = "Two Hearts", Image = "2H.png" },
                new Card() { Value = 3, Name = "Three Hearts", Image = "3H.png" },
                new Card() { Value = 4, Name =  "Four Hearts", Image = "4H.png"},
                new Card() { Value = 5, Name = "Five Hearts", Image = "5H.png" },
                new Card() { Value = 6, Name = "Six Hearts", Image = "6H.png" },
                new Card(){ Value = 7, Name = "Seven Hearts", Image = "7H.png" },
                new Card() { Value = 8, Name = "Eight Hearts", Image = "8H.png" },
                new Card() { Value = 9, Name = "Nine Hearts", Image = "9H.png" },
                new Card() { Value = 10, Name = "Ten Hearts", Image = "10H.png" },
                new Card() { Value = 10, Name = "Jack Hearts", Image = "JH.png" },
                new Card() { Value = 10, Name = "Queen Hearts", Image = "QH.png" },
                new Card(){ Value = 10, Name = "King Hearts", Image = "KH.png" },
                new Card(){ Value = 11, Name = "Ace Hearts", Image = "AH.png" }

                #endregion
        };

        public Form1()
        {
            InitializeComponent();

            // Remove double buffering
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, PnlGame, new object[] { true });

            for (int i = 0; i <= 12; i++)
            {
                // Declare the rectangle to put the shark image in for each shark
                chipContainer[i] = new Rectangle(y, x + 46 * i, 30, 30);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resetGame();
        }

        private void PnlGame_Paint(object sender, PaintEventArgs e)
        {
            // Get the methods from the graphic's class to paint on the panel
            g = e.Graphics;

            if (showChips == true)
            {
                // Use the DrawImage method to draw each of the sharks onto the panel
                for (int i = 0; i <= 12; i++)
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
            if (showChips == true)
            {
                for (int i = 0; i <= 12; i++)
                { // Run the code for each of the 5 sharks
                    chipSpeed[i] = random.Next(10, 23);

                    chipContainer[i].X += chipSpeed[i]; // Set each shark to the correct speed

                    if (chipContainer[i].X > PnlGame.Width)
                    { // If the shark reaches the end of the panel
                        chipContainer[i].X = -25; // Move the shark back to the begining of the panel
                    }
                }
            }

            PnlGame.Invalidate();
        }

        //start the game 
        private void startButton_Click(object sender, EventArgs e)
        {
            if (playercardSum > 0)
            {
                resultLabel.Text = String.Format("Already started.");
            }

            else
            {
                playercardSum = 0;
                bankercardSum = 0;

                sumPlayerCards();

                if (playercardSum == 21)
                {
                    resultLabel.Text = String.Format("The sum of your cards is: {0}, you win!", playercardSum);
                    MessageBox.Show("You win!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    resetGame();
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
            if (playercardSum == 0)
            {
                resultLabel.Text = "Click the Start button...";
                //displayCardBack(pictureBox3);
            }

            else
            {
                if (playercardSum > 100) //to be changed
                {
                    resetGame();
                    resultLabel.Text = "Resetting game...";
                }

                else
                {
                    playercardSum = 0;
                    int randomCard = selectRandomCard();
                    Card card = deck[randomCard];
                    usedCards.Add(randomCard);

                    if (usedCards.Contains(randomCard)) randomCard = selectRandomCard();
                    else randomCard = 1 * randomCard;

                    //player new card
                    PictureBox p3 = new PictureBox();
                    p3.Width = 71;
                    p3.Height = 96;
                    p3.Location = new Point(154 + 77 + playerbox.Count * 77, 137);
                    p3.ImageLocation = card.Image;
                    p3.SizeMode = PictureBoxSizeMode.AutoSize;
                    this.Controls.Add(p3);

                    playerbox.Add(p3);

                    playercardList.Add(card);
                    sumPlayerCards();
                    if (playercardSum > 21)
                    {
                        resultLabel.Text = String.Format("The sum of your cards is: {0}, you lose!", playercardSum);
                        MessageBox.Show("You lose!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        resetGame();
                    }
                    else if (playercardSum == 21)
                    {
                        resultLabel.Text = String.Format("The sum of your cards is: {0}, you win!", playercardSum);
                        MessageBox.Show("You win!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        resetGame();
                    }
                }
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            resetGame();
        }

        private void resetGame()
        {
            resultLabel.Text = null;

            displayCardBack(pictureBox1);
            displayCardBack(pictureBox2);
            displayCardBack(pictureBox4);

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
            resultLabel.Text = "Player choice";

            chipCount = chipCount + bet;
        }

        private void displayCardBack(PictureBox picturebox)
        {
            picturebox.ImageLocation = "b1fv.png";
            picturebox.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        // palyer stop move
        private void PlayerStopButton_Click(object sender, EventArgs e)
        {
            if (playercardSum == 0)
            {
                resultLabel.Text = "Click the Start button...";
                return;
            }

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
                p4.ImageLocation = card.Image;
                p4.SizeMode = PictureBoxSizeMode.AutoSize;
                this.Controls.Add(p4);

                bankerbox.Add(p4);

                bankercardList.Add(card);
                sumBankerCards();
            }

            if (bankercardSum > 21)
            {
                resultLabel.Text = String.Format("The sum of banker cards is: {0}, you lose!", bankercardSum);
                MessageBox.Show("You win!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                resetGame();
            }
            else if (playercardSum <= bankercardSum)
            {
                resultLabel.Text = String.Format("The sum of your cards is: {0}, you lose!", playercardSum);
                MessageBox.Show("You lose!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                resetGame();
            }
            else
            {
                resultLabel.Text = String.Format("The sum of your cards is: {0}, you win!", playercardSum);
                MessageBox.Show("You win!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                resetGame();
            }

        }
    }
}