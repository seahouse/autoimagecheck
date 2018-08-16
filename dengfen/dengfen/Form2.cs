using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dengfen
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();



        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            var p0 = new PointF(2, 1);
            var p1 = new PointF(3, 2);

            g.DrawLine(new Pen(Color.Green, 2f), p0, p1);

            var k = (p1.Y - p0.Y) / (p1.X - p0.X);
            //y=kx+b0
            var b0 = p0.Y - k * p0.X;
            //y=-kx+b1
            var b1 = p0.Y + k * p0.X;

            var d = 2;
            //k=d/
        }
    }
}
