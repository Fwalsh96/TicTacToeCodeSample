using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TicTacToe
{
    public class Exes : Shape
    {

        public override void drawShape(int xAxis, int yAxis, Form1 theForm)
        {
            shapeGraphics = theForm.CreateGraphics();
            shapeGraphics.DrawLine(RedPen, xAxis, yAxis,xAxis+50,yAxis+50 );
            shapeGraphics.DrawLine(RedPen, xAxis+50,yAxis,xAxis,yAxis+50);
        }
    }
}
