using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        // Variables
        private int mTurn = 0;
        private int turnsTaken = 0;

        public int MTurn 
        {
            get { return mTurn; }
            set { mTurn = value; }
        }

        public int TurnsTaken
        {
            get { return turnsTaken; }
            set { turnsTaken = value; }
        }

        // The Grid made up of boxes
        public box[] Grid = new box[9];

        // Shapes
        public Exes Xbox;
        public Ohs Oreos;

        // String for winner text and turn text
        public String winText;
        public String turnText;

        // Sets the variable for the turn text, Turn text is used to set the label in the form
        public void setTurnText(int shape)
        {
            if (shape == 0)
            {
                turnText = "O's Turn!";
            }
            else if (shape == 1)
            {
                turnText = "X's Turn!";
            }
        }

        // Sets the variable in game for winning text, winning text is used to set the label in the form
        public void setWinText(int shape)
        {
            if (shape == 1)
            {
                winText = "O's Win!";
            }
            else if (shape == 0)
            {
                winText = "X's Win!";
            }
            else if (shape == 3)
            {
                winText = "Tie Game!";
            }
        }
        
        // Game function, handles turns and stuff
        public Game(int xCenter, int yCenter) 
        {
            // Set box locations

            // =============================================
            // Top Row
            //============================================

            // Top left
            Grid[0] = new box(xCenter, yCenter, -90, -90);

            // Top Middle
            Grid[1] = new box(xCenter, yCenter, -30, -90);

            // Top Right
            Grid[2] = new box(xCenter, yCenter, 35, -90);


            //===========================================
            // Middle Row
            //============================================

                // Middle Left
            Grid[3] = new box(xCenter, yCenter, -90, -30);

            // Middle Middle
            Grid[4] = new box(xCenter, yCenter, -30, -25);

            // Middle Right
            Grid[5] = new box(xCenter, yCenter, 35, -30);

            //===========================================
            // Bottom Row
            //===========================================
            // Left
            Grid[6] = new box(xCenter, yCenter, -90, 35);
            // Middle
            Grid[7] = new box(xCenter, yCenter, -30, 35);
            // Right
            Grid[8] = new box(xCenter, yCenter, 35, 35);

        }

        public bool isGameOver()
        {
            // Is there 3 in a row?
            if (isWin() == true)
            {
                if (mTurn == 0)
                {
                    Console.WriteLine("X's Win");
                    setWinText(1);
                }
                if (mTurn == 1)
                {
                    Console.WriteLine("O's Win");
                    setWinText(0);
                }

                return true;
            }
            // Is it a Tie?
            else if (TurnsTaken >= 9)
            {
                Console.WriteLine("There is likely a Tie");
                setWinText(3);
                return true;
            }

            // Dummy Return statement for now.
            return false;
        }

        public bool isWin()
        {
            // Top Row Three
            if ((Grid[0].isEmpty() == false) && (Grid[1].isEmpty() == false) && (Grid[2].isEmpty() == false) && ((Grid[0].shapeType == Grid[1].shapeType) && Grid[0].shapeType == Grid[2].shapeType))
            {
                
                return true;
            }
            // Middle Row
            else if ((Grid[3].isEmpty() == false) && (Grid[4].isEmpty() == false) && (Grid[5].isEmpty() == false) && ((Grid[3].shapeType == Grid[4].shapeType) && Grid[3].shapeType == Grid[5].shapeType))
            {
                return true;
            }
            // Bottom Row
            else if ((Grid[6].isEmpty() == false) && (Grid[7].isEmpty() == false) && (Grid[8].isEmpty() == false) && ((Grid[6].shapeType == Grid[7].shapeType) && Grid[6].shapeType == Grid[8].shapeType))
            {
                return true;
            }
            // Left Side
            else if ((Grid[0].isEmpty() == false) && (Grid[3].isEmpty() == false) && (Grid[6].isEmpty() == false) && ((Grid[0].shapeType == Grid[3].shapeType) && Grid[0].shapeType == Grid[6].shapeType))
            {
                return true;
            }
            // Right Side
            else if ((Grid[2].isEmpty() == false) && (Grid[5].isEmpty() == false) && (Grid[8].isEmpty() == false) && ((Grid[2].shapeType == Grid[5].shapeType) && Grid[2].shapeType == Grid[8].shapeType))
            {
                return true;
            }
            // Middle Column
            else if ((Grid[1].isEmpty() == false) && (Grid[4].isEmpty() == false) && (Grid[7].isEmpty() == false) && ((Grid[1].shapeType == Grid[4].shapeType) && Grid[1].shapeType == Grid[7].shapeType))
            {
                return true;
            }
            // Diagonal from 0 to 8
            else if ((Grid[0].isEmpty() == false) && (Grid[4].isEmpty() == false) && (Grid[8].isEmpty() == false) && ((Grid[0].shapeType == Grid[4].shapeType) && Grid[0].shapeType == Grid[8].shapeType))
            {
                return true;
            }
            // Diagonal from 2 to 6
            else if ((Grid[2].isEmpty() == false) && (Grid[4].isEmpty() == false) && (Grid[6].isEmpty() == false) && ((Grid[2].shapeType == Grid[4].shapeType) && Grid[2].shapeType == Grid[6].shapeType))
            {
                return true;
            }
            else return false;
        }

        public void useBox(int index, Form1 mainForm)
        {
            // If this box on the grid is empty
            if (Grid[index].isEmpty() == true)
            {
                // If O's Turn
                if (this.MTurn == 0)
                {
                    this.Oreos.drawShape(this.Grid[index].shapeX, this.Grid[index].shapeY, mainForm);
                    this.MTurn = 1;
                    setTurnText(mTurn);
                    this.turnsTaken++;
                    Grid[index].shapeType = 0;
                }

                // If X's Turn
                else if (this.MTurn == 1)
                {
                    this.Xbox.drawShape(this.Grid[index].shapeX, this.Grid[index].shapeY, mainForm);
                    this.MTurn = 0;
                    setTurnText(mTurn);
                    this.turnsTaken++;
                    Grid[index].shapeType = 1;
                }
            }
            else
            {
                Console.WriteLine("Space filled use a differnet spot");
            }
        }

        public void resetGame()
        {
            // Reset mTurn
            mTurn = 0;
            setTurnText(0);

            // Reset Turns taken
            turnsTaken = 0;
            
            // Reset Grid Values and Stuff
            for (int i = 0; i < 9; i++)
            {
                this.Grid[i].shapeType = -1;
            }
        }
    }


    // A box represents each of the squares within the gird
    public class box
    {
        // Boxes are 55 by 55 at the default window height
        // Maxes 
        public int xMax;
        public int yMax;

        // Mins
        public int xMin;
        public int yMin;

        // Where to draw shape
        public int shapeX;
        public int shapeY;

        // Box constructor
        public box(int xGrid, int yGrid, int xOffSet, int yOffSet) 
        {
            // Set the center of the shape
            shapeX = xGrid + xOffSet;
            shapeY = yGrid + yOffSet;

            // Set Maxes
            xMax = shapeX + 50;
            yMax = shapeY - 50;

            // Set Mins
            xMin = shapeX - 50;
            yMin = shapeY + 50;
        }

        // The Shape that occupies the Box
        // Shapetype if -1, empty
        // Shapetype if 0, O
        // Shapetype if 1, X
        public int shapeType = -1;

        public bool isEmpty()
        {
            if (shapeType == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}
