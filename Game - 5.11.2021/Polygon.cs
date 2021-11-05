using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game___5._11._2021
{
    class Polygon
    {
        public int N {  get; set; }
        public int NumDiagonals { get; set; }
        public int Size {  get; set; }

        public List<Point> Points { get; set; }
        public List<Diagonal> Diagonals {  get; set; }

        public Polygon (int n, int size)
        {
            N = n;
            Size = size;
            NumDiagonals = n * (n - 3) / 2;
            Points = new List<Point>();
            Diagonals = new List<Diagonal>();
        }

        public void GenPoints()
        {
            for (int i = 0; i < N; i++)
            {
                int point_x = Convert.ToInt32(Size * Math.Cos(2 * Math.PI / N * i));
                int point_y = Convert.ToInt32(Size * Math.Sin(2 * Math.PI / N * i));
                Points.Add(new Point(point_x, point_y));
            }
        }
        public void GenDiagonals()
        {
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = i + 1; j < N - 1; j++)
                {
                    Point start = Points[i];
                    Point end = Points[j];
                    Diagonals.Add(new Diagonal(start, end));
                }
            }
        }
    }
}
