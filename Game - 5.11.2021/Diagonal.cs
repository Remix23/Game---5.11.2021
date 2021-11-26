using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game___5._11._2021
{
    public class Diagonal
    {  
        static int NumOfDiagonals {  get; set; }
        public int Id { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint {  get; set; }

        public int Value;

        public Diagonal(Point start, Point end, int value)
        {
            NumOfDiagonals = NumOfDiagonals + 1;
            Id = NumOfDiagonals;
            StartPoint = start;
            EndPoint = end;
            Value = value;
        }

        public void Draw(Graphics g)
        {
            g.DrawLine(Pens.Black, this.StartPoint, this.EndPoint);
        }
    }
}
