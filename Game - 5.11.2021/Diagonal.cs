using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game___5._11._2021
{
    class Diagonal
    {  

        static int NumOfDiagonals {  get; set; }
        public int Id { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint {  get; set; }

        public Diagonal(Point start, Point end)
        {
            Id = NumOfDiagonals + 1;
            NumOfDiagonals = NumOfDiagonals + 1;
            StartPoint = start;
            EndPoint = end;
        }
    }
}
