using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game___5._11._2021
{
    class Mause
    {
        public int Id { get; set; } 
        public Point Pos {  get; set; }

        static int NumMauses;

        public Mause (Point pos)
        {
            NumMauses = NumMauses + 1;
            Id = NumMauses;
            Pos = pos;
        }

        public Diagonal choose_diagonal(Polygon polygon)
        {
            Diagonal choice = polygon.Diagonals[0];
            for (int i = 0; i < polygon.NumDiagonals; i++)
            {
                Diagonal diagonal = polygon.Diagonals[i];
                if (diagonal.StartPoint == Pos || diagonal.EndPoint == Pos) // check if mause is on the diagonal
                {   
                    if (i == 0 || (i != 0 && diagonal.Id < choice.Id)) // check if diagonal should be added to 
                    {
                        choice = diagonal;
                    } 
                    
                }
            }
            return choice;
        }

        public void update()
        {

        }
        public void draw ()
        {

        }
    }
}
