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

            var tmp = new List<PointF>();
            var txt = System.IO.File.ReadAllLines("data.txt");
            foreach (var row in txt)
            {
                if (row.Length >= 22)
                {
                    var x = Convert.ToSingle(row.Substring(0, 9)) * 100;
                    var y = Convert.ToSingle(row.Substring(12, 9)) * 100;
                    tmp.Add(new PointF(x, y));
                }
            }
            plist = tmp.ToArray();

            newPoint();
        }

        PointF[] plist;
        List<PointF> newList = new List<PointF>();

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;


            g.TranslateTransform(300, 50);
            g.RotateTransform(180);

            g.DrawLines(new Pen(Color.Green, 2f), plist);

            //g.DrawEllipse(Pens.Red)


            g.DrawLines(new Pen(Color.Red, 2f), newList.ToArray());
        }

        void newPoint()
        {
            //tan(45*PI()/180)
            //var tmp = Convert.ToSingle(Math.Tan(i * Math.PI / 180) * 100);

            //var p0 = new PointF(0, 0);
            //var p1 = new PointF(100, tmp);

            for (int i = 1; i < plist.Length; i++)
            {
                var p0 = plist[i - 1];
                var p1 = plist[i];


                PointF p00, p10;

                var d = 10f;

                if (p0.X == p1.X)
                {
                    p00 = new PointF(p0.X - d, p0.Y);
                    p10 = new PointF(p0.X - d, p1.Y);
                }
                else if (p0.Y == p1.Y)
                {
                    p00 = new PointF(p0.X, p0.Y - d);
                    p10 = new PointF(p1.X, p1.Y - d);
                }
                else
                {
                    var k = (p1.Y - p0.Y) / (p1.X - p0.X);

                    //y=kx+b0
                    var b0 = p0.Y - k * p0.X;

                    //y=-kx+b1
                    var b1 = p0.Y + k * p0.X;

                    //b=sqrt(d^2/k^2+d^2)
                    var b = Math.Sqrt(Math.Pow(d / k, 2) + Math.Pow(d, 2));

                    //p00: x-b,y
                    p00 = new PointF(Convert.ToSingle(p0.X - b), p0.Y);
                    p10 = new PointF(Convert.ToSingle(p1.X - b), p1.Y);
                }

                newList.Add(p00);
                newList.Add(p10);
            }
        }
    }
}
