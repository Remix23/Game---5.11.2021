using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game___5._11._2021
{
    public class Game
    {
        public int MauseSize {  get; set; }
        public Point PolygonPos { get; set; }
        public int PolygonRSize {  get; set; }
        public int PolygonN {  get; set; }

        public Polygon Polygon {  get; set; }

        public List<Mause> Mauses {  get; set; }

        public int FinishedMouses {  get; set; }

        public Font myFont {  get; set; }

        public Game(int mause_size, Point polygon_pos, int polygon_r_size, int polygon_n)
        {

            PolygonRSize = polygon_r_size;
            PolygonN = polygon_n;
            MauseSize = mause_size;
            PolygonPos = polygon_pos;

            // initialize polygon
            Polygon = new Polygon(polygon_n, polygon_r_size, PolygonPos);

            // initialize all mauses 
            Mauses = new List<Mause>();
            for (int i = 0; i < Polygon.N; i++)
            {
                Mauses.Add(new Mause(Polygon, Polygon.Points[i], MauseSize));
            }
            FinishedMouses = 0;

            myFont = new Font("Arial", 20);
        }

        public void Update()
        {
            FinishedMouses = 0;
            foreach (Mause mause in Mauses)
            {
                mause.ChooseDiagonal();
                mause.Update();
                if (mause.Finished) FinishedMouses++;
            }
        }
        public void Draw(Graphics g)
        {
            Polygon.Draw(g);
            foreach (Mause mause in Mauses)
            {
                mause.Draw(g);
            }
            if (FinishedMouses >= Mauses.Count)
            {
                g.DrawString("Finish", myFont, Brushes.Black, new Point(20, 20));
            }
        }
    }
}
