using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game___5._11._2021
{
    public partial class Form1 : Form
    {
        public Game Game;
        public Form1()
        {
            InitializeComponent();
            Game = new Game(10, new Point(pictureBox1.Width / 2, pictureBox1.Height / 2) , 200, 20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            Game.Update();
            pictureBox1.Invalidate();

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Game.Draw(g);
        }
    }
}
