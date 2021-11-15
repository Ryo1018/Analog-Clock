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

            //画面を消す
            Graphics g = this.CreateGraphics();
            g.Clear(Color.Black);
            g.Dispose();

            //針を書く
            draw(6, Pens.Aqua, d.Second, 100); //秒針 6→360÷60
            draw(6, Pens.Yellow, d.Minute, 80);  //分 
            draw(30, Pens.Pink, d.Hour, 50);    //時  15→360÷12(時間) 短針は一日に二周するため2倍
        }
        
        private void draw(int 倍率, Pen pen, int time, int 針の長さ)
        {
            int cx = 150;
            int cy = 150;

            //原点
            int x1 = cx;
            int y1 = cy;

            //針
            double 角度1度あたり = Math.PI / 180;
            double 角度 = 角度1度あたり * 倍率 * time - Math.PI / 2;

            //int 針の長さ = 100;
            int x2 = cx + (int)(Math.Cos(角度) * 針の長さ); //引数はラジアンで渡す必要がある
            int y2 = cy + (int)(Math.Sin(角度) * 針の長さ);

            Graphics g = this.CreateGraphics();
            //g.Clear(Color.Black);
            g.DrawLine(pen , x1, y1, x2, y2);
            g.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            Graphics g = this.CreateGraphics(); //線を書くことができる
            g.DrawLine(Pens.Aqua, 0, 0, 100, 200); //(Pens.色. 最初の座標X,Y,目的の座標X,Y)
            g.Dispose(); //リソースの開放 C#にはusingというのもある
            */
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
