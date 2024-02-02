using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp20
{
    public partial class Form1 : Form
    {
        Graphics g;
        HanoyMethod dk;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dk.goOut < 1)
            {
                Thread t = new Thread(delegate () {
                    while (true)
                    {
                        dk.DrawTower(g);
                        Thread.Sleep(400);
                    }
                });
                t.Start();
                dk.Hanoy(0, 2);
                t.Abort();
            }
            else
            {
                MessageBox.Show(
        "Создайте модель заново.",
        "Ошибка",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information,
        MessageBoxDefaultButton.Button1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            dk = new HanoyMethod(Convert.ToInt32(numericUpDown1.Value));
            dk.FillTower();
            dk.DrawTower(g);
        }
    }
}
