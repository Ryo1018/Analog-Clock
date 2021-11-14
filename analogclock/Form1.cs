using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace analogclock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            label1.Text = d.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics(); //線を書くことができる
            g.DrawLine(Pens.Aqua, 0, 0, 100, 200); //(Pens.色. 最初の座標X,Y,目的の座標X,Y)
            g.Dispose(); //リソースの開放 C#にはusingというのもある
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            //g.Clear(Color.Black);//指定した色で全体的に消す
            g.DrawLine(Pens.Black, 0, 0, 100, 200);
            g.Dispose(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
