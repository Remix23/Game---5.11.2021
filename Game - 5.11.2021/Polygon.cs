using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game___5._11._2021
{
    public class Polygon
    {
        public int N;

        public int NumDiagonals;

        public int Size;

        public List<Point> Points;

        public List<Diagonal> Diagonals;

        private List<int> _diagonalsValues;

        public Random rng;

        public Point Pos {  get; set; }

        public Polygon (int n, int size, Point pos)
        {
            N = n;
            Size = size;
            Pos = pos;
            NumDiagonals = n * (n - 3) / 2;
            Points = new List<Point>();
            Diagonals = new List<Diagonal>();
            _diagonalsValues = new List<int>();
            _diagonalsValues = Enumerable.Range(1, NumDiagonals).ToList();
            rng = new Random();
            _genPoints();
            _genDiagonals();
        }

        private void _genPoints()
        {
            for (int i = 0; i < N; i++)
            {
                int point_x = Convert.ToInt32(Size * Math.Cos(2 * Math.PI / N * i));
                int point_y = Convert.ToInt32(Size * Math.Sin(2 * Math.PI / N * i));
                Points.Add(new Point(point_x + this.Pos.X, point_y + this.Pos.Y));
            }
        }

        public List<Diagonal> GetDiagonalsFromPoint (Point pos, int lastVisited)
        {
            List<Diagonal> possibleChoices = new List<Diagonal>();
            foreach (Diagonal diagonal in Diagonals)
            {
                if ((diagonal.StartPoint == pos || diagonal.EndPoint == pos) && diagonal.Value > lastVisited)
                {
                    possibleChoices.Add(diagonal);
                }
            }
            return possibleChoices;
        }
        private void _genDiagonals()
        {
            int diagonal_value;
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = i + 2; j < N; j++)
                {
                    if (i == 0 && j == N - 1) continue;
                    Point start = Points[i];
                    Point end = Points[j];
                    diagonal_value = _diagonalsValues[rng.Next(_diagonalsValues.Count)];
                    _diagonalsValues.Remove(diagonal_value);
                    Diagonals.Add(new Diagonal(start, end, diagonal_value));
                }
            }
        }
        public void Draw(Graphics g)
        {
            foreach (Diagonal diagonal in Diagonals)
            {
                diagonal.Draw(g);
            }
            g.DrawLine(Pens.Black, Points[0], Points[Points.Count - 1]);
            for (int i = 1; i < N; i++)
            {
                g.DrawLine(Pens.Black, Points[i - 1], Points[i]);
            }
        }
    }
}
