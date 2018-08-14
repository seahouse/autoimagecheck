using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace dengfen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            var tmp = new List<PointF>();

            tmp.Add(new PointF(100, 100));
            tmp.Add(new PointF(200, 100));
            tmp.Add(new PointF(300, 200));
            //tmp.Add(new PointF(200, 500));
            //tmp.Add(new PointF(200, 400));
            //tmp.Add(new PointF(100, 300));
            //tmp.Add(new PointF(200, 200));

            //var txt = System.IO.File.ReadAllLines("data.txt");
            //foreach (var row in txt)
            //{
            //    var a = row.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            //    if (a.Length == 2)
            //    {
            //        var x = Convert.ToSingle(a[0]);
            //        var y = Convert.ToSingle(a[1]);
            //        tmp.Add(new PointF(x, y));
            //    }
            //}


            plist = tmp.ToArray();

            initDPList();
            computeLine(-10);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            g.TranslateTransform(20, 20);
            g.DrawPolygon(new Pen(Color.Green, 2f), plist);

            g.DrawPolygon(new Pen(Color.Red, 2f), newList.ToArray());
        }

        PointF[] plist; //= new[] { new PointF(0, 0), new PointF(0, 100), new PointF(100, 100), new PointF(50, 50), new PointF(100, 0) };
        List<PointF> dpList = new List<PointF>();
        List<PointF> ndpList = new List<PointF>();
        List<PointF> newList = new List<PointF>();

        void initDPList()
        {
            for (int i = 0; i < plist.Length; i++)
            {
                dpList.Add(Minus(plist[i == plist.Length - 1 ? 0 : i + 1], plist[i]));

                ndpList.Add(Star(dpList[i], Convert.ToSingle((1.0 / Math.Sqrt(Star(dpList[i], dpList[i]))))));
            }
        }

        void computeLine(double dist)
        {
            var count = plist.Length;

            for (var index = 0; index < count; index++)
            {

                var startIndex = index == 0 ? count - 1 : index - 1;
                var endIndex = index;

                var sina = DoubleStar(ndpList[startIndex], ndpList[endIndex]);
                var length = dist / sina;
                var vector = Minus(ndpList[endIndex], ndpList[startIndex]);
                var point = Add(plist[index], Star(vector, Convert.ToSingle(length)));

                newList.Add(point);
            }
        }

        static PointF Add(PointF left, PointF right)
        {
            return new PointF(left.X + right.X, left.Y + right.Y);
        }

        static PointF Minus(PointF left, PointF right)
        {
            return new PointF(left.X - right.X, left.Y - right.Y);
        }

        static double Star(PointF left, PointF right)
        {
            return left.X * right.X + left.Y + right.Y;
        }

        static PointF Star(PointF left, float value)
        {
            return new PointF(left.X * value, left.Y * value);
        }

        static double DoubleStar(PointF left, PointF right)
        {
            return left.X * right.Y - left.Y * right.X;
        }
    }
}
