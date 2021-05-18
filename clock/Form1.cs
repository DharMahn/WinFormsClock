using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clock
{
    public partial class Form1 : Form
    {
        float hLength;
        float mLength;
        float sLength;

        Pen hPen = new Pen(Brushes.Blue, 5);
        Pen mPen = new Pen(Brushes.Red, 3);
        Pen sPen = new Pen(Brushes.Orange, 1);

        Point center;

        double oneSec = Math.PI / 30;
        double oneHour = Math.PI / 6;

        float circleRadius;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            center = new Point(ClientRectangle.Width / 2, ClientRectangle.Height / 2);
            circleRadius = ClientRectangle.Height / 2;
            hLength = ClientRectangle.Height / 4;
            mLength = ClientRectangle.Height / 2.5f;
            sLength = ClientRectangle.Height / 2.5f;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            for (int i = 0; i < 60; i++)
            {
                if (i % 5 == 0)
                {
                    e.Graphics.DrawLine(Pens.Black, center.X + (float)Math.Cos(oneSec * i) * circleRadius*0.85f, center.Y + (float)Math.Sin(oneSec * i) * circleRadius * 0.85f, center.X + (float)Math.Cos(oneSec * i) * circleRadius * 0.98f, center.Y + (float)Math.Sin(oneSec * i) * circleRadius * 0.98f);
                }
                else
                {
                    e.Graphics.DrawLine(Pens.Black, center.X + (float)Math.Cos(oneSec * i) * circleRadius * 0.92f, center.Y + (float)Math.Sin(oneSec * i) * circleRadius * 0.92f, center.X + (float)Math.Cos(oneSec * i) * circleRadius * 0.98f, center.Y + (float)Math.Sin(oneSec * i) * circleRadius * 0.98f);
                }
            }
            e.Graphics.DrawEllipse(Pens.Brown, new RectangleF(center.X - circleRadius, center.Y - circleRadius, circleRadius * 2, circleRadius * 2));            
            e.Graphics.DrawLine(hPen, center.X, center.Y, center.X + (float)Math.Cos((DateTime.Now.Hour - 3 + (DateTime.Now.Minute / 60f) + (DateTime.Now.Second/3600f)) * oneHour) * hLength, center.Y + (float)Math.Sin((DateTime.Now.Hour - 3 + (DateTime.Now.Minute / 60f) + (DateTime.Now.Second / 3600f)) * oneHour)  * hLength);
            e.Graphics.DrawLine(mPen, center.X, center.Y, center.X + (float)Math.Cos((DateTime.Now.Minute - 15 + (DateTime.Now.Second) / 60f) * oneSec) * mLength, center.Y + (float)Math.Sin((DateTime.Now.Minute - 15 + (DateTime.Now.Second) / 60f) * oneSec) * mLength);
            e.Graphics.DrawLine(sPen, center.X, center.Y, center.X + (float)Math.Cos((DateTime.Now.Second - 15) * oneSec) * sLength, center.Y + (float)Math.Sin((DateTime.Now.Second - 15) * oneSec) * sLength);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            center = new Point(ClientRectangle.Width / 2, ClientRectangle.Height / 2);
            circleRadius = ClientRectangle.Height / 2;
            hLength = ClientRectangle.Height / 4;
            mLength = ClientRectangle.Height / 2.5f;
            sLength = ClientRectangle.Height / 2.5f;
            Invalidate();
        }
    }
}
