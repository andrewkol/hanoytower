using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace WindowsFormsApp20
{
    class HanoyMethod
    {
        private int N;
        private List<HanoyRing> HR;
        private Stack<HanoyRing> zero, first, second;
        private List<HanoyRing> base_rings;
        public HanoyMethod(int n)
        {
            N = n;
            HR = new List<HanoyRing>();
            zero = new Stack<HanoyRing>();
            first = new Stack<HanoyRing>();
            second = new Stack<HanoyRing>();
            base_rings = new List<HanoyRing>();
        }
        public int goOut { get { return second.Count; } }

        public void Hanoy(int from, int to)
        {
            StartMethod();
            HanoyPriv(N, from, to);
        }
        private void HanoyPriv(int nthis, int from, int to)
        {
            if (nthis < 0)
                throw new Exception("Колец нет.");
            if (nthis == 0)
                return;
            HanoyPriv(nthis - 1, from, 3 - from - to);
            MoveTo(from, to);
            Thread.Sleep(800);
            HanoyPriv(nthis - 1, 3 - from - to, to);
        }
        public void FillTower()
        {
            base_rings.Add(new HanoyRing(20, 330, 200, 20, -1));
            base_rings.Add(new HanoyRing(250, 330, 200, 20, -1));
            base_rings.Add(new HanoyRing(480, 330, 200, 20, -1));
            base_rings.Add(new HanoyRing(115, 100, 10, 230, -1));
            base_rings.Add(new HanoyRing(345, 100, 10, 230, -1));
            base_rings.Add(new HanoyRing(575, 100, 10, 230, -1));
            HR.Add(new HanoyRing(30, 310, 180, 20, 0));
            for(int i = 0; i < N - 1; i++)
            {
                HR.Add(new HanoyRing(HR[HR.Count - 1].StartX + 10, HR[HR.Count - 1].StartY - 20, HR[HR.Count - 1].Width - 20, HR[HR.Count - 1].Height, i + 1));
            }

        }
        public Graphics DrawTower(Graphics g)
        {
            g.Clear(Color.White);
            foreach (var item in base_rings)
            {
                item.DrawRect(g);
            }
            foreach (var items in HR)
            {
                items.Draw(g);
            }
            return g;
        }
        public void Clear()
        {
            zero.Clear();
            first.Clear();
            second.Clear();
            HR.Clear();
            base_rings.Clear();
        }
        public void StartMethod()
        {
            for (int i = 0; i < HR.Count; i++)
            {
                zero.Push(HR[i]);
            }
        }
        private void MoveTo(int l, int m)
        {
            HanoyRing currentring;
            if(l == 0)
            {
                currentring = zero.Peek();
                if(m == 1)
                {
                    if (first.Count > 0)
                    {
                        HanoyRing nextring = first.Peek();
                        currentring.reRect(nextring.StartX + 10, nextring.StartY - 20, nextring.Width - 20, nextring.Height);
                    }
                    else
                    {
                        currentring.reRect(260, 310, 180, 20);
                    }
                    first.Push(zero.Pop());
                }
                if(m == 2)
                {
                    if(second.Count > 0)
                    {
                        HanoyRing nextring = second.Peek();
                        currentring.reRect(nextring.StartX + 10, nextring.StartY - 20, nextring.Width - 20, nextring.Height);
                    }   
                    else
                    {
                        currentring.reRect(490, 310, 180, 20);
                    }
                    second.Push(zero.Pop());
                }
            }
            if(l == 1)
            {
                currentring = first.Peek();
                if (m == 0)
                {
                    if(zero.Count > 0)
                    {
                        HanoyRing nextring = zero.Peek();
                        currentring.reRect(nextring.StartX + 10, nextring.StartY - 20, nextring.Width - 20, nextring.Height);
                    }
                    else
                    {
                        currentring.reRect(30, 310, 180, 20);
                    }
                    zero.Push(first.Pop());
                }
                if(m == 2)
                {
                    if (second.Count > 0)
                    {
                        HanoyRing nextring = second.Peek();
                        currentring.reRect(nextring.StartX + 10, nextring.StartY - 20, nextring.Width - 20, nextring.Height);
                    }
                    else
                    {
                        currentring.reRect(490, 310, 180, 20);
                    }
                    second.Push(first.Pop());
                }
            }
            if(l == 2)
            {
                currentring = second.Peek();
                if (m == 0)
                {
                    if (zero.Count > 0)
                    {
                        HanoyRing nextring = zero.Peek();
                        currentring.reRect(nextring.StartX + 10, nextring.StartY - 20, nextring.Width - 20, nextring.Height);
                    }
                    else
                    {
                        currentring.reRect(30, 310, 180, 20);
                    }
                    zero.Push(second.Pop());
                }
                if(m == 1)
                {
                    if (first.Count > 0)
                    {
                        HanoyRing nextring = first.Peek();
                        currentring.reRect(nextring.StartX + 10, nextring.StartY - 20, nextring.Width - 20, nextring.Height);
                    }
                    else
                    {
                        currentring.reRect(260, 310, 180, 20);
                    }
                    first.Push(second.Pop());
                }
            }
        }
    }
}
