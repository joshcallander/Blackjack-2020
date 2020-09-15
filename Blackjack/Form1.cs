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

        List<int> usedCards = new List<int>(); // Create a list that all the cards that are used can be added to
        List<PictureBox> playerBox = new List<PictureBox>(); // Create a picture box list of all the players cards

        // Create varibles for total card values
        int playercardSum = 0;
        int bankercardSum = 0;
        Image chipImage; // Set up a image to place the chip inside

        int chipCount = 1000; // Set the initial chip count to 1,000
        int bet = 0; // Set the bet to 0
        
        Random random = new Random(); // Create a random varible

        Graphics g; // Declare the graphics object called g
        Chip[] chip = new Chip[8]; // Create 8 chips
        int[] chipSpeed = new int[8]; // Declare 8 speeds for each chip
        int[] chipColour = new int[8]; // Declare 8 colours for each chip
        bool showChips = true; // Create a bool to hide and show the chips on open screen

        // Create the list for all cards in the deck with value, name and image
        List<Card> deck = new List<Card>()
        {
            new Card() { Value  = 2, Name = "Two of Spades", Image = Blackjack.Properties.Resources._2S },
            new Card() { Value = 3, Name = "Three of Spades", Image = Blackjack.Properties.Resources._3S },
            new Card() { Value = 4, Name =  "Four of Spades", Image = Blackjack.Properties.Resources._4S },
            new Card() { Value = 5, Name = "Five of Spades", Image = Blackjack.Properties.Resources._5S },
            new Card() { Value = 6, Name = "Six of Spades", Image = Blackjack.Properties.Resources._6S },
            new Card() { Value = 7, Name = "Seven of Spades", Image = Blackjack.Properties.Resources._7S },
            new Card() { Value = 8, Name = "Eight of Spades", Image = Blackjack.Properties.Resources._8S },
            new Card() { Value = 9, Name = "Nine of Spades", Image = Blackjack.Properties.Resources._9S },
            new Card() { Value = 10, Name = "Ten of Spades", Image = Blackjack.Properties.Resources._10S },
            new Card() { Value = 10, Name = "Jack of Spades", Image = Blackjack.Properties.Resources.JS },
            new Card() { Value = 10, Name = "Queen of Spades", Image = Blackjack.Properties.Resources.QS },
            new Card() { Value = 10, Name = "King of Spades", Image = Blackjack.Properties.Resources.KS },
            new Card() { Value = 11, Name = "Ace of Spades", Image = Blackjack.Properties.Resources.AS },

            new Card() { Value  = 2, Name = "Two of Diamonds", Image = Blackjack.Properties.Resources._2D },
            new Card() { Value = 3, Name = "Three of Diamonds", Image = Blackjack.Properties.Resources._3D },
            new Card() { Value = 4, Name =  "Four of Diamonds", Image = Blackjack.Properties.Resources._4D },
            new Card() { Value = 5, Name = "Five of Diamonds", Image = Blackjack.Properties.Resources._5D },
            new Card() { Value = 6, Name = "Six of Diamonds", Image = Blackjack.Properties.Resources._6D },
            new Card() { Value = 7, Name = "Seven of Diamonds", Image = Blackjack.Properties.Resources._7D },
            new Card() { Value = 8, Name = "Eight of Diamonds", Image = Blackjack.Properties.Resources._8D },
            new Card() { Value = 9, Name = "Nine of Diamonds", Image = Blackjack.Properties.Resources._9D },
            new Card() { Value = 10, Name = "Ten of Diamonds", Image = Blackjack.Properties.Resources._10D },
            new Card() { Value = 10, Name = "Jack of Diamonds", Image = Blackjack.Properties.Resources.JD },
            new Card() { Value = 10, Name = "Queen of Diamonds", Image = Blackjack.Properties.Resources.QD },
            new Card() { Value = 10, Name = "King of Diamonds", Image = Blackjack.Properties.Resources.KD },
            new Card() { Value = 11, Name = "Ace of Diamonds", Image = Blackjack.Properties.Resources.AD },

            new Card() { Value  = 2, Name = "Two of Clubs", Image = Blackjack.Properties.Resources._2C },
            new Card() { Value = 3, Name = "Three of Clubs", Image = Blackjack.Properties.Resources._3C },
            new Card() { Value = 4, Name =  "Four of Clubs", Image = Blackjack.Properties.Resources._4C },
            new Card() { Value = 5, Name = "Five of Clubs", Image = Blackjack.Properties.Resources._5C },
            new Card() { Value = 6, Name = "Six of Clubs", Image = Blackjack.Properties.Resources._6C },
            new Card() { Value = 7, Name = "Seven of Clubs", Image = Blackjack.Properties.Resources._7C },
            new Card() { Value = 8, Name = "Eight of Clubs", Image = Blackjack.Properties.Resources._8C },
            new Card() { Value = 9, Name = "Nine of Clubs", Image = Blackjack.Properties.Resources._9C },
            new Card() { Value = 10, Name = "Ten of Clubs", Image = Blackjack.Properties.Resources._10C },
            new Card() { Value = 10, Name = "Jack of Clubs", Image = Blackjack.Properties.Resources.JC },
            new Card() { Value = 10, Name = "Queen of Clubs", Image = Blackjack.Properties.Resources.QC },
            new Card() { Value = 10, Name = "King of Clubs", Image = Blackjack.Properties.Resources.KC },
            new Card() { Value = 11, Name = "Ace of Clubs", Image = Blackjack.Properties.Resources.AC },

            new Card() { Value  = 2, Name = "Two of Hearts", Image = Blackjack.Properties.Resources._2H },
            new Card() { Value = 3, Name = "Three of Hearts", Image = Blackjack.Properties.Resources._3H },
            new Card() { Value = 4, Name =  "Four of Hearts", Image = Blackjack.Properties.Resources._4H },
            new Card() { Value = 5, Name = "Five of Hearts", Image = Blackjack.Properties.Resources._5H },
            new Card() { Value = 6, Name = "Six of Hearts", Image = Blackjack.Properties.Resources._6H },
            new Card() { Value = 7, Name = "Seven of Hearts", Image = Blackjack.Properties.Resources._7H },
            new Card() { Value = 8, Name = "Eight of Hearts", Image = Blackjack.Properties.Resources._8H },
            new Card() { Value = 9, Name = "Nine of Hearts", Image = Blackjack.Properties.Resources._9H },
            new Card() { Value = 10, Name = "Ten of Hearts", Image = Blackjack.Properties.Resources._10H },
            new Card() { Value = 10, Name = "Jack of Hearts", Image = Blackjack.Properties.Resources.JH },
            new Card() { Value = 10, Name = "Queen of Hearts", Image = Blackjack.Properties.Resources.QH },
            new Card() { Value = 10, Name = "King of Hearts", Image = Blackjack.Properties.Resources.KH },
            new Card() { Value = 11, Name = "Ace of Hearts", Image = Blackjack.Properties.Resources.AH }
        };

        public Form1()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, PnlGame, new object[] { true }); // Prevent buffering

            for (int i = 0; i < 8; i++)
            { // Loop through 8 times (the number of chips)
                int y = 20 + (49 * i); // Create the y co-ordinate
                chip[i] = new Chip(y); // Create a new chip calling the Chip method in the Chip.cs class and passing through the y value
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        { // On click of the start button
            if (betValue.Text == "" || betValue.Text == "0" || (Convert.ToInt32(betValue.Text) < 1) || (Convert.ToInt32(betValue.Text) > chipCount))
            { // If the bet amount is invalid
                MessageBox.Show("Please enter a valid bet amount!"); // Display an error message
            }

            else
            { // Else the bet amount is valid
                playercardSum = 0; // Set the sum of the players cards to 0
                bankercardSum = 0; // Set the sum of the dealers cards to 0

                bet = Convert.ToInt32(betValue.Text); // Get the bet value textbox and set the bet intiger to it

                // Set up for the first card
                int randomCardOne = selectRandomCard(); // Select a random card
                Card cardOne = deck[randomCardOne]; // Create it as cardOne from the deck geting the value, name and image
                usedCards.Add(randomCardOne); // Add the card id to the usedCards list to prevent it being reused
                playercardList.Add(cardOne);  // Add cardOne to the playercardList

                PictureBox p1 = new PictureBox(); // Create a new picture box to put the card image inside
                p1.Size = new Size(71, 96); // Set the size of the picture box to 71 in width and 96 in height
                p1.Location = new Point(20 + playerBox.Count * 91, 20); // Set the location of the picture box to 20 + (the number of cards * 91) for 20 in spacing between cards and 20 from the top of the form
                p1.Image = cardOne.Image; // Set the image of the picture box to the image value of cardOne
                p1.SizeMode = PictureBoxSizeMode.AutoSize; // Set the size mode of the picture box to auto so the image is displayed in the picture box correctly
                this.Controls.Add(p1); // Add the picture box to the form
                p1.BringToFront(); // Bring the picture box to sit ontop of the panel
                playerBox.Add(p1); // Add the picture box to the playerBox picture box list

                // Set up for the second card
                int randomCardTwo = selectRandomCard(); // Select a random card

                while (usedCards.Contains(randomCardTwo))
                { // While the card generated has already been used in the usedCards list
                    randomCardTwo = selectRandomCard(); // Select a new random card
                }
                randomCardTwo = 1 * randomCardTwo; // Set the random card intiger to the random card value

                Card cardTwo = deck[randomCardTwo]; // Create it as cardTwo from the deck geting the value, name and image
                usedCards.Add(randomCardTwo); // Add the card id to the usedCards list to prevent it being reused
                playercardList.Add(cardTwo);  // Add cardTwo to the playercardList

                PictureBox p2 = new PictureBox(); // Create a new picture box to put the card image inside
                p2.Size = new Size(71, 96); // Set the size of the picture box to 71 in width and 96 in height
                p2.Location = new Point(20 + playerBox.Count * 91, 20); // Set the location of the picture box to 20 + (the number of cards * 91) for 20 in spacing between cards and 20 from the top of the form
                p2.Image = cardTwo.Image; // Set the image of the picture box to the image value of cardOne
                p2.SizeMode = PictureBoxSizeMode.AutoSize; // Set the size mode of the picture box to auto so the image is displayed in the picture box correctly
                this.Controls.Add(p2); // Add the picture box to the form
                p2.BringToFront(); // Bring the picture box to sit ontop of the panel
                playerBox.Add(p2); // Add the picture box to the playerBox picture box list

                // Set up the dealers hand
                int randomCardDealer = selectRandomCard(); // Select a random card

                while (usedCards.Contains(randomCardDealer))
                { // While the card generated has already been used in the usedCards list
                    randomCardDealer = selectRandomCard(); // Select a new random card
                }
                randomCardDealer = 1 * randomCardDealer; // Set the random card intiger to the random card value

                Card cardDealer = deck[randomCardDealer]; // Create it as cardDealer from the deck geting the value, name and image
                usedCards.Add(randomCardDealer); // Add the card id to the usedCards list to prevent it being reused
                bankercardList.Add(cardDealer);  // Add cardDealer to the bankercardList

                sumPlayerCards(); // Sum the players cards

                // Show blackjack items and remove welcome screen items
                stayButton.Visible = true;
                hitButton.Visible = true;
                resetButton.Visible = true;
                lblBetAmount.Visible = false;
                betValue.Visible = false;
                startButton.Visible = false;
                showChips = false;
            }
        }

        private void hitButton_Click(object sender, EventArgs e)
        { // Onclick of the hit button
            playercardSum = 0; // Set the sum of the players cards to 0
            int randomCard = 0; // Set the randomCard initger to 0
                
            randomCard = selectRandomCard(); // Deal a new random card
            while (usedCards.Contains(randomCard))
            { // While the usedCards list contains the card that has just been dealt
                randomCard = selectRandomCard(); // Deal a new random card
            }
            randomCard = 1 * randomCard;

            Card card = deck[randomCard]; // Create it as card from the deck geting the value, name and image
            usedCards.Add(randomCard); // Add the card id to the usedCards list to prevent it being reused
            playercardList.Add(card);  // Add cardTwo to the playercardList

            // Create a new card
            PictureBox p = new PictureBox(); // Create a new picture box to put the card image inside
            p.Size = new Size(71, 96); // Set the size of the picture box to 71 in width and 96 in height
            p.Location = new Point(20 + playerBox.Count * 91, 20); // Set the location of the picture box to 20 + (the number of cards * 91) for 20 in spacing between cards and 20 from the top of the form
            p.Image = card.Image; // Set the image of the picture box to the image value of card
            p.SizeMode = PictureBoxSizeMode.AutoSize; // Set the size mode of the picture box to auto so the image is displayed in the picture box correctly
            this.Controls.Add(p); // Add the picture box to the form
            p.BringToFront(); // Bring the picture box to sit ontop of the panel
            playerBox.Add(p); // Add the picture box to the playerBox picture box list

            sumPlayerCards(); // Call the sumPlayerCards function

            if (playercardSum > 21)
            { // If the sum of the players cards are greater than 21 (they are bust)
                MessageBox.Show(String.Format("You lose! The sum of your cards are {0}", playercardSum)); // Show the result - the player has lost the game
                resetGame(); // Call the reset game function
                    
                chipCount = chipCount - bet; // Decrease the chip count by the amount bet
                lblChips.Text = chipCount.ToString(); // Change the text of the chip count label to the new chip count
            }

            else
            { // Else the player is not bust so let them keep playing
                MessageBox.Show(String.Format("You were dealt a {0}, so the sum of your cards are {1}. Would you like to hit or stay?", card.Name, playercardSum)); // Show the result - the player has lost the game
            }
        }

        private void stayButton_Click(object sender, EventArgs e)
        { // If the player decides to stay
            sumBankerCards(); // Sum the dealers cards

            while (bankercardSum <= 16)
            { // If the sum of the bankers cards is less than or equal to 16
                int randomCard = selectRandomCard(); // Deal a new random card
                Card card = deck[randomCard];
                usedCards.Add(randomCard); // Add the card just dealt to the used card list

                if (usedCards.Contains(randomCard))
                { // If the used cards list contains the card that has just been dealt
                    randomCard = selectRandomCard(); // Then deal a new card
                }

                else
                { // Else its fine to use this card
                    randomCard = 1 * randomCard; // So get the value of the card as an interger
                }

                bankercardList.Add(card); // Add the card to the 
                sumBankerCards(); // Sum the bankers cards again
            }

            if (playercardSum > bankercardSum && playercardSum <= 21)
            { // If the sum of the players cards is greater than the sum of the dealers cards and the sum of the players cards is less than or equal to 21
                MessageBox.Show(String.Format("You win! The sum of dealers cards are {0}", bankercardSum)); // Show the result - the player has won the game
                resetGame(); // Call the reset game function

                chipCount = chipCount + bet; // Decrease the chip count by the amount bet
                lblChips.Text = chipCount.ToString(); // Change the text of the chip count label to the new chip count
            }

            else if (playercardSum == bankercardSum && playercardSum <= 21)
            { // If the sum of the players cards is equal to the sum of the bankers cards and the sum of the players cards is less than or euqal to 21
                MessageBox.Show(String.Format("You lose! The sum of the dealers cards are {0}", bankercardSum)); // Show the result - the player has lost the game
                resetGame(); // Call the reset game function

                chipCount = chipCount - bet; // Decrease the chip count by the amount bet
                lblChips.Text = chipCount.ToString(); // Change the text of the chip count label to the new chip count
            }

            else if (playercardSum < bankercardSum && bankercardSum <= 21)
            { // If the sum of the players cards is less than the sum of the dealers cards and the sum of the dealers cards is less than or equal to 21
                MessageBox.Show(String.Format("You lose! The sum of the dealers cards are {0}", bankercardSum)); ; // Show the result - the player has lost the game
                resetGame(); // Call the reset game function

                chipCount = chipCount - bet; // Decrease the chip count by the amount bet
                lblChips.Text = chipCount.ToString(); // Change the text of the chip count label to the new chip count
            }

            else
            {
                MessageBox.Show(String.Format("You win! The sum of dealers cards are {0}", bankercardSum)); // Show the result - the player has won the game
                resetGame(); // Call the reset game function

                chipCount = chipCount + bet; // Decrease the chip count by the amount bet
                lblChips.Text = chipCount.ToString(); // Change the text of the chip count label to the new chip count
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        { // On click of the rest button
            chipCount = chipCount - bet; // Decrease the chip count by the amount bet
            lblChips.Text = chipCount.ToString(); // Change the text of the chip count label to the new chip count

            resetGame(); // Call the reset game function
        }

        private int selectRandomCard()
        { // When the selectRandomCard function is called
            int randomCard; // Create a randomCard intiger
            randomCard = random.Next(0, deck.Count); // Set the randomCard value to a random value between 0 and the number of cards in the deck list
            return randomCard; // Return the result
        }

        private void sumPlayerCards()
        { // When the sumPlayerCards function is called
            playercardSum = 0; // Set the sum of the players cards to 0

            for (int i = 0; i < playercardList.Count; i++)
            { // Loop through the number of cards (count) in the playercardList
                playercardSum += playercardList[i].Value; // Increase the sum of the total of the players cards by the value of each card in the playercardList
            }

            if (playercardSum > 21)
            { // If the sum of all the players cards are greater than 21 (they are bust)
                foreach (Card c in playercardList)
                { // Loop through each card in the playercardList
                    if (c.Value == 11)
                    { // If a cards value is 11 (an ace)
                        playercardSum -= 10; // Subtract 10 from the total of the players cards so the ace is only dealt as a 1

                        if (playercardSum <= 21)
                        { // If the player is no longer bust
                            break; // Exit the loop and allow them to continue playing
                        }
                    }
                }
            }
        }

        private void sumBankerCards()
        { // When the sumBankerCards function is called
            bankercardSum = 0; // Set the sum of the dealers cards to 0

            for (int i = 0; i < bankercardList.Count; i++)
            { // Loop through the number of cards (count) in the bankercardList
                bankercardSum += bankercardList[i].Value; // Increase the sum of the total of the dealers cards by the value of each card in the bankercardList
            }

            if (bankercardSum > 21)
            { // If the sum of all the dealers cards are greater than 21 (they are bust)
                foreach (Card c in bankercardList)
                { // Loop through each card in the bankercardList
                    if (c.Value == 11)
                    { // If a cards value is 11 (an ace)
                        bankercardSum -= 10; // Subtract 10 from the total of the dealers cards so the ace is only dealt as a 1
                        if (bankercardSum <= 21)
                        { // If the player is no longer bust
                            break; // Exit the loop
                        }
                    }
                }
            }
        }

        private void resetGame()
        { // When the resetGame function is called
            foreach (PictureBox pb in playerBox)
            { // Loop through all the picture boxes in the playerBox list
                this.Controls.Remove(pb); // Remove the picture box from the form
            }

            // Set the total of the cards to 0
            playercardSum = 0;
            bankercardSum = 0;

            // Clear all the lists
            playercardList.Clear();
            bankercardList.Clear();
            usedCards.Clear();
            playerBox.Clear();

            // Show and hide relavant things
            stayButton.Visible = false;
            hitButton.Visible = false;
            resetButton.Visible = false;

            lblBetAmount.Visible = true;
            betValue.Visible = true;
            startButton.Visible = true;

            showChips = true; // Enable the show chips on welcome screen
        }

        private void Form1_Load(object sender, EventArgs e)
        { // On load of the form
            resetGame(); // Call the reset game function

            MessageBox.Show("Enter your bet amount and click the start button. The number of chips you have is shown at the bottom. Press hit to be dealt a new card and stay when you are close to 21. Aim is to get 21, good luck!"); // Show game instructions
        }

        private void PnlGame_Paint(object sender, PaintEventArgs e)
        { // Paint the panel (PnlGame)
            g = e.Graphics; // Get the methods from the graphic's class to paint on the panel

            if (showChips == true)
            { // If showChips is enabled
                for (int i = 0; i < 8; i++)
                { // Loop through 8 times (the number of chips)
                    chipColour[i] = random.Next(1, 5); // Create a random colour intiger for each chip

                    if (chipColour[i] == 1)
                    { // If the random number for the chip colour is 1
                        chipImage = Blackjack.Properties.Resources.blue_chip; // Set the image to the blue chip
                        chip[i].drawChip(g, chipImage); // Call the drawChip method for each chip passing the the graphics and image to the Chip.cs class
                    }

                    else if (chipColour[i] == 2)
                    { // If the random number for the chip colour is 2
                        chipImage = Blackjack.Properties.Resources.green_chip; // Set the image to the green chip
                        chip[i].drawChip(g, chipImage); // Call the drawChip method for each chip passing the the graphics and image to the Chip.cs class
                    }

                    else if (chipColour[i] == 3)
                    { // If the random number for the chip colour is 3
                        chipImage = Blackjack.Properties.Resources.red_chip; // Set the image to the red chip
                        chip[i].drawChip(g, chipImage); // Call the drawChip method for each chip passing the the graphics and image to the Chip.cs class
                    }

                    else if (chipColour[i] == 4)
                    { // If the random number for the chip colour is 4
                        chipImage = Blackjack.Properties.Resources.white_chip; // Set the image to the white chip
                        chip[i].drawChip(g, chipImage); // Call the drawChip method for each chip passing the the graphics and image to the Chip.cs class
                    }

                    else if (chipColour[i] == 5)
                    { // If the random number for the chip colour is 5
                        chipImage = Blackjack.Properties.Resources.black_chip; // Set the image to the black chip
                        chip[i].drawChip(g, chipImage); // Call the drawChip method for each chip passing the the graphics and image to the Chip.cs class
                    }
                }
            }
        }

        private void TmrChips_Tick(object sender, EventArgs e)
        { // On tick of the TmrChips timer
            if (showChips == true)
            { // If showChips is enabled
                for (int i = 0; i < 8; i++)
                { // Loop through each of the chips on tick of the timer
                    chip[i].moveChip(); // Call the moveChip method in the Chip.cs class for the particular chip

                    chipSpeed[i] = random.Next(10, 23); // Select a random speed between 10 and 22
                    chip[i].x += chipSpeed[i]; // Set each chip to the correct speed

                    if (chip[i].x > PnlGame.Width)
                    { // If the chip reaches the end of the panel (x value is greater than width of panel)
                        chip[i].x = 20; // Move the chip back to the begining of the panel (x = 20)
                    }
                }
            }

            PnlGame.Invalidate();
        }
    }
}