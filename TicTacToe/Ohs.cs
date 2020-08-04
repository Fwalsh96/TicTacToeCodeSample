using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace TicTacToe
{
    public class Ohs : Shape
    {
        public override void drawShape(int xAxis, int yAxis, Form1 disGuy)
        {
            shapeGraphics = disGuy.CreateGraphics();

           shapeGraphics.DrawEllipse(BluePen, xAxis, yAxis, 50, 50);
        }

        
    }
}
