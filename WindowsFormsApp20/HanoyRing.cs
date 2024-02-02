using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp20
{
    class HanoyRing
    {
        private int startX, startY, width, height, num;
        private Rectangle rect;
        private Color color;
        private StringFormat format1;
        public HanoyRing(int sX, int stY, int wid, int hei,int num)
        {
            startX = sX;
            startY = stY;
            width = wid;
            height = hei;
            this.num = num;
            rect = new Rectangle(sX, stY, wid, hei);
            color = Color.FromArgb(Util.GetRandom(), Util.GetRandom(), Util.GetRandom());
            format1 = new StringFormat();
            format1.LineAlignment = StringAlignment.Center;
            format1.Alignment = StringAlignment.Center;
        }
        public int StartX { get { return startX; } }
        public int StartY { get { return startY; } }
        public int Height { get { return height; } }
        public int Width { get { return width; } }
        public Graphics Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(color), rect);
            g.DrawString(Convert.ToString(num) + "- кольцо", new Font("Arial", 15), new SolidBrush(Color.Red), rect, format1);
            return g;
        }
        public void reRect(int sX, int stY, int wid, int hei)
        {
            rect = new Rectangle(sX, stY, wid, hei);
            startX = sX;
            startY = stY;
            width = wid;
            height = hei;
        }
        public Graphics DrawRect(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Black), rect);
            return g;
        }
    }
}
