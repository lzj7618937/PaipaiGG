using System;
using System.Windows.Forms;

namespace PaipaiGG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.Write("Button1点击事件");
            MessageBox.Show("Button1点击事件2！" + this.Top + "-" + this.Left);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mouse.MouseLefDownEvent(100, 200, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(Timer_Tick);
            this.timer1.Start();
            this.webBrowser1.Url = new Uri("https://www.baidu.com");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
