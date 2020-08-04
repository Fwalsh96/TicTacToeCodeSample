using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        // Pens
        Pen gridPen = new Pen(Color.Black, 9);
        Pen blue = new Pen(Color.Blue);
        Pen Red = new Pen(Color.Red);
        Pen Green = new Pen(Color.Green);

        // General Game Variable
        Game Stuff;

        // The center of the Form Variables
        int xCenter; //= DisplayRectangle.Width / 2;
        int yCenter; //= DisplayRectangle.Height / 2;

        int gridCenterX;
        int gridCenterY;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set Centers
            xCenter = DisplayRectangle.Width / 2;
            yCenter = DisplayRectangle.Height / 2;

            // Makes the form not sizable
            FormBorderStyle = FormBorderStyle.FixedDialog;

            // Make a new instance of Game
            Stuff = new Game(xCenter, yCenter);

            // Initilizes shapes in the game.
            Stuff.Oreos = new Ohs();
            Stuff.Xbox = new Exes();

            // Set the turn text
            Stuff.setTurnText(0);
            lblGameText.Text = Stuff.turnText;

        }
        
        // Menu Exit Button
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Menu Reset Button
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Keeps the Grid from being deleted
            this.Invalidate();
            
            //G.Clear(Color.White);
            Stuff.Oreos.clearShapes();
            Stuff.Xbox.clearShapes();

            // Restart the game
            Stuff.resetGame();
            lblGameText.Text = Stuff.turnText;

        }

        // Form 1 Paint Event
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Assign the center variables.
            gridCenterX = DisplayRectangle.Width / 2;
            gridCenterY = DisplayRectangle.Height / 2;

            // Paint the Grid
            // Issues May need to adjust the grid, and if we plan on doing the resize then we will need to make these values change with the size
            // Vertical lines
            e.Graphics.DrawLine(gridPen, xCenter-30, yCenter-90, xCenter-30, yCenter+90);
            e.Graphics.DrawLine(gridPen, xCenter+30, yCenter-90, xCenter+30, yCenter+90);
            // Horizontal Lines
            e.Graphics.DrawLine(gridPen, xCenter+90, yCenter+30, xCenter-90, yCenter+30);
            e.Graphics.DrawLine(gridPen, xCenter+90, yCenter-30, xCenter-90, yCenter-30);

            /*
            // Draw each of the boxes to get a good idea of their location in x and y
            // Top Left // Pen, Coordniate pair, Width, HEight
            G.DrawRectangle(blue, xCenter-90,yCenter-90,55,55);
            // Top Middle
            G.DrawRectangle(Red, xCenter - 30, yCenter - 90, 55, 55);
            //Top Right
            G.DrawRectangle(Green, xCenter+35, yCenter-90, 55, 55);

            //Middle Left
            G.DrawRectangle(blue, xCenter-90, yCenter-30, 55, 55);
            // Middle Middle
            G.DrawRectangle(Red, xCenter - 30, yCenter - 25, 55, 55);
            // Middle Right
            G.DrawRectangle(Green, xCenter+35, yCenter-30, 55, 55);

            // Bottom Left
            G.DrawRectangle(blue, xCenter -90, yCenter +35, 55, 55);
            // Bottom Middle
            G.DrawRectangle(Red, xCenter-30, yCenter + 35, 55, 55);
            // Bottom Right
            G.DrawRectangle(Green, xCenter + 35, yCenter+35, 55, 55);
            */
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        { 
            // Updates the Label

            if (Stuff.isGameOver() == true && Stuff.isWin() == false)
            {
                Stuff.setWinText(3);
                lblGameText.Text = "Tie Game";
            }
            else if (Stuff.isGameOver() == true)
            {
                Stuff.setWinText(Stuff.MTurn);
                lblGameText.Text = Stuff.winText;
            }
            else 
            {
                lblGameText.Text = Stuff.turnText;
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            // Test Values
            txtXval.Text = e.X.ToString();
            txtYVal.Text = e.Y.ToString();

            // Flag
            bool isfound = false;

            // Index
            int I=0;

            // Makes sure the mouse click is within the grid
            if ((e.X < 250 && e.X > 61) && (e.Y < 272 && e.Y > 98))
            {
                while (isfound == false && Stuff.isGameOver() == false)
                {
                    if ((e.X <= Stuff.Grid[I].xMax && e.X >= Stuff.Grid[I].xMin) && (e.Y <= Stuff.Grid[I].yMin && e.Y >= Stuff.Grid[I].yMax))
                    {
                        Stuff.useBox(I, this);
                        isfound = true;
                    }

                    // Increment 
                    I++;
                }
            }
           

            // Checks to see if the game has ended.
            if (Stuff.TurnsTaken >= 3)
            {
                Stuff.isGameOver();
            }


        }
    }
}
