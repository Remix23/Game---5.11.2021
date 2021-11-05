using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game___5._11._2021
{
    class Game
    {
        public int PolygonRSize {  get; set; }
        public int PolygonN {  get; set; }

        public Polygon Polygon {  get; set; }

        public List<Mause> Mauses {  get; set; }

        public Game(int polygon_r_size, int polygon_n)
        {
            PolygonRSize = polygon_r_size;
            PolygonN = polygon_n;

            // initialize polygon
            Polygon = new Polygon(polygon_n, polygon_r_size);

            // initialize point and diagonals
            Polygon.GenPoints();
            Polygon.GenDiagonals();

            // initialize all mauses 
            Mauses = new List<Mause>();
            for (int i = 0; i < Polygon.N; i++)
            {
                Mauses.Add(new Mause(Polygon.Points[i]));
            }
        }
    }
}
