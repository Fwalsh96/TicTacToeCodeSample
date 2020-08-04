using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TicTacToe
{
    public abstract class Shape
    {
        // Graphics Reference within the Shape Class
        public static Graphics shapeGraphics;
        public static Pen RedPen = new Pen(Color.Red, 3);
        public static Pen BluePen = new Pen(Color.Blue, 3);

        //public abstract void initilizeGraphic();
        public abstract void drawShape(int xAxis, int yAxis, Form1 disGuy);

        public void clearShapes()
        {
            if (shapeGraphics != null)
            {
                shapeGraphics.Clear(Color.White);
            }
            
        }

    }
}
