using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Blackjack
{
    class Chip
    {
        // Declare the fields to use in the class
        public int x, y, width, height; // Variables for the rectangle

        public Rectangle chipRectangle; // Variable for a rectangle to place image inside

        // Create a constructor
        public Chip(int spacing)
        {
            x = 20;
            y = spacing;
            width = 30;
            height = 30;

            chipRectangle = new Rectangle(x, y, width, height);
        }

        // Draw chip method
        public void drawChip(Graphics g, Image chipImage)
        {
            chipRectangle = new Rectangle(x, y, width, height); // Create the rectangle
            g.DrawImage(chipImage, chipRectangle); // Create the rectangle with the image inside
        }

        // Move the chip method
        public void moveChip()
        {
            chipRectangle.Location = new Point(x, y);
        }
    }
}