using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game___5._11._2021
{
    public class Mause
    {
        public int Id { get; set; } 
        public Point Pos {  get; set; }

        public int Size { get; set; }

        public Random rng;

        private Color _color;
        private Brush _brush;
        private Pen _pen;
        private List<Diagonal> _possibleChoices;
        public Polygon Parent;
        public bool Finished { get; set; }

        private int _lastDiagonalValue;

        static int NumMauses;

        public Mause (Polygon parent, Point pos, int size)
        {
            rng = new Random();
            NumMauses++;
            Id = NumMauses;
            Parent = parent;
            Pos = pos;
            Size = size;
            Finished = false;
            _possibleChoices = new List<Diagonal>();
            _lastDiagonalValue = -1;
            _color = Color.FromArgb(rng.Next(256), rng.Next(256), rng.Next(256));
            _brush = new SolidBrush(_color);
            _pen = new Pen(_brush);
        }

        public void ChooseDiagonal()
        {
            if (!Finished) _possibleChoices = Parent.GetDiagonalsFromPoint(Pos, _lastDiagonalValue);

            if (_possibleChoices.Count == 0)
            {
                Finished = true;
                return;
            }
            Diagonal choice = _possibleChoices.First();
            for (int i = 1; i < _possibleChoices.Count; i++)
            {
                if ((_possibleChoices[i].StartPoint == Pos || _possibleChoices[i].EndPoint == Pos) && _possibleChoices[i].Value < choice.Value) // check if mause is on the diagonal
                {
                    choice = _possibleChoices[i];
                }
            }
            _possibleChoices.Clear();
            _possibleChoices.Add(choice);
        }

        public void Update () 
        {
            if (Finished) return;
            if (Pos == _possibleChoices.First().StartPoint)
            {
                Pos = _possibleChoices.First().EndPoint;
            }
            else if (Pos == _possibleChoices.First().EndPoint)
            {
                Pos = _possibleChoices.First().StartPoint;
            }
            _lastDiagonalValue = _possibleChoices.First().Value;
        }
        public void Draw (Graphics g)
        {
            using (Font myFont = new Font("Arial", 14))
            {
                g.DrawString(Convert.ToString(this.Id), myFont, Brushes.Black, Pos);
            }
            g.FillEllipse(_brush, Pos.X - Size / 2, Pos.Y - Size / 2, Size, Size);
        }
    }
}
