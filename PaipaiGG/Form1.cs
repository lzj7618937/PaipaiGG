using dmNet;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PaipaiGG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AutoRegCom("regsvr32 D:\\dm.dll /s");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.Write("Button1点击事件");
            //MessageBox.Show("Frame坐标：" + this.Top + "-" + this.Left);
            //MessageBox.Show("Brower坐标：" + this.webBrowser1.Location.X + "-" + this.webBrowser1.Location.X);
            int x1 = 670;
            int y1 = 240;
            Mouse.MouseLefDownEvent(x1+this.Left, y1+this.Top, 0);
            SendKeys.Send("88888888");

            int x2 = 670;
            int y2 = 295;
            Mouse.MouseLefDownEvent(x2 + this.Left, y2 + this.Top, 0);
            SendKeys.Send("8888");
                    
            int x3 = 670;
            int y3 = 345;
            Mouse.MouseLefDownEvent(x3 + this.Left, y3 + this.Top, 0);
            //VerifyCodeInput verifyCodeForm = new VerifyCodeInput();
            //verifyCodeForm.ShowDialog();
            //String verifyCode = verifyCodeForm.text;
            //SendKeys.Send(verifyCode);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dmsoft dm = new dmsoft();
            //textBox1.Text = dm.FindWindow("", "t").ToString();
            dm.MoveTo(30, 30);
            //Mouse.MouseLefDownEvent(100, 200, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(Timer_Tick);
            this.timer1.Start();
            this.webBrowser1.Url = new Uri("http://test.alltobid.com/moni/gerenlogin.html");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        //register dm.dll
        static string AutoRegCom(string strCmd)
        {
            strCmd = "regsvr32 D:\\dm.dll /s";
            string rInfo;
            try
            {
                Process myProcess = new Process();
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo("cmd.exe");
                myProcessStartInfo.UseShellExecute = false;
                myProcessStartInfo.CreateNoWindow = true;
                myProcessStartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo = myProcessStartInfo;
                myProcessStartInfo.Arguments = "/c " + strCmd;
                myProcess.Start();
                StreamReader myStreamReader = myProcess.StandardOutput;
                rInfo = myStreamReader.ReadToEnd();
                myProcess.Close();
                rInfo = strCmd + "\r\n" + rInfo;
                return rInfo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            int dx = 820 + this.Left;
            int dy = 540 + this.Top;
            Mouse.MouseLefDownEvent(dx, dy, 0);
            Thread.Sleep(1000);
            Mouse.MouseLefDownEvent(dx, dy, 0);
            //MessageBox.Show("xy:" + dx + "-" + dy);
        }
    }
}
