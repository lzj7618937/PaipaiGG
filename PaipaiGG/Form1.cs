using dmNet;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PaipaiGG
{
    public partial class Form1 : Form
    {
        private Point webBrowerP;
        private dmsoft dm;
        Bitmap bitmap;
        Graphics graphics;  //创建画笔

        public Form1()
        {
            InitializeComponent();
            AutoRegCom("regsvr32 C:\\dm.dll /s");
        }

        //登录
        private void button1_Click(object sender, EventArgs e)
        {
            //Console.Write("Button1点击事件");
            //System.Diagnostics.Debug.WriteLine("信息:" + this.Left + "," + this.Top);
            //MessageBox.Show("Frame坐标：" + this.Top + "-" + this.Left);
            
            //MessageBox.Show("Brower坐标：" + webBrowerP.X + "-" + webBrowerP.Y);
            int x = 620 + webBrowerP.X;
            int y1 = 210 + webBrowerP.Y;
            Mouse.MouseLefDownEvent(x, y1, 0);
            SendKeys.Send("88888888");

            int y2 = 265 + webBrowerP.Y;
            Mouse.MouseLefDownEvent(x, y2, 0);
            SendKeys.Send("8888");
                    
            int y3 = 320 + webBrowerP.Y;
            Mouse.MouseLefDownEvent(x,y3, 0);
            //VerifyCodeInput verifyCodeForm = new VerifyCodeInput();
            //verifyCodeForm.ShowDialog();
            //String verifyCode = verifyCodeForm.text;
            //SendKeys.Send(verifyCode);

            //dmsoft dm = new dmsoft();
            //dm.SetPath("C:\\dm");
            //dm.SetDict(0, "系统字库数字.txt");
            //int verifyCodeLeft  = 741 + webBrowerP.X, verifyCodeTop = 304 + webBrowerP.Y, verifyCodeRight = 857 + webBrowerP.X, verifyCodeBottom = 332 + webBrowerP.Y;
            //System.Diagnostics.Debug.WriteLine("信息:" + verifyCodeTop +","+ verifyCodeLeft + "," + verifyCodeBottom + "," + verifyCodeRight);
            //price = dm.Ocr(priceX1, priceY1, priceX2, priceY2, "ff0000-000000", 1.0)
            //price = dm.Ocr(priceX1, priceY1, priceX2, priceY2, "b@ffffff-0d0d0d", 1.0)
            //String price = dm.Ocr(verifyCodeLeft, verifyCodeTop, verifyCodeRight, verifyCodeBottom, "b@FFFFFF", 0.8);
            //MessageBox.Show(price);
            //System.Diagnostics.Debug.WriteLine("信息:" + price);
        }

        //首次出价
        private void button2_Click(object sender, EventArgs e)
        {
            int x1 = 780 + this.Left;
            int y1 = 315 + this.Top;
            //MessageBox.Show("top,left:" + this.Left + "," + this.Top);
            //MessageBox.Show("x1y1:" + x1 + "," + y1);
            Mouse.MouseLefDownEvent(x1, y1, 0);
            Thread.Sleep(200);
            SendKeys.Send("100");

            int x2 = 780 + this.Left;
            int y2 = 370 + this.Top;
            //MessageBox.Show("x2y2:" + x2 + "," + y2);
            Mouse.MouseLefDownEvent(x2, y2, 0);
            Thread.Sleep(200);
            SendKeys.Send("100");

            Thread.Sleep(200);
            ocrCode();
            int x3 = 850 + this.Left;
            int y3 = 370 + this.Top;
            //MessageBox.Show("x3y3:" + x3 + "," + y3);
            Mouse.MouseLefDownEvent(x3, y3, 0);

            Thread th2 = new Thread(copyScan);
            th2.Start();
        }

        private void copyScan()
        {
            try { 
            Thread.Sleep(2000);
            int verifyCodeLeft = 542 + webBrowerP.X, verifyCodeTop = 378 + webBrowerP.Y;
            if (!Directory.Exists(" c:\\dm"))  //判断目录是否存在,不存在就创建
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(" c:\\dm");
                directoryInfo.Create();
            }
            //创建图片对象
            int width = 111;
            int height = 40;
            //设置图像的大小
            this.bitmap = new Bitmap(width, height);
            this.graphics = Graphics.FromImage(bitmap);  //创建画笔
            //Thread.Sleep(7000);
            //从指定的区域中复制图形
            graphics.CopyFromScreen(verifyCodeLeft, verifyCodeTop, 0, 0, bitmap.Size);//截屏
            //把图形放在PictureBox中显示
            pictureBox1.Image = bitmap;
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");//获得系统时间
            time = System.Text.RegularExpressions.Regex.Replace(time, @"[^0-9]+", "");//提取数字
            string fileName = time + ".bmp"; //创建文件名
            MessageBox.Show(fileName);
            bitmap.Save("c:\\dm\\" + fileName); //保存为文件  ,注意格式是否正确.
            //不能使用Dispose，不然图片就没有了，同时也会引起异常
            bitmap.Dispose();//关闭对象
            graphics.Dispose();//关闭画笔
            }
            catch (Exception e)
            {
                Trace.TraceError("出现异常:" + e.Message);//记录日志
            }
        }

        private void ocrCode()
        {
            Trace.TraceError("这是一个Error级别的日志");
            Trace.TraceWarning("这是一个Warning级别的日志");
            Trace.TraceInformation("这是一个Info级别的日志");
            Trace.WriteLine("这是一个普通日志");
            Trace.Flush();//立即输出
            this.timer2.Interval = 1000;
            this.timer2.Tick += new EventHandler(Price_Tick);
            this.timer2.Start();
        }

        private void Price_Tick(object sender, EventArgs e)
        {
            int verifyCodeLeft = 204 + webBrowerP.X, verifyCodeTop = 390 + webBrowerP.Y, verifyCodeRight = 242 + webBrowerP.X, verifyCodeBottom = 403 + webBrowerP.Y;
            String price = dm.Ocr(verifyCodeLeft, verifyCodeTop, verifyCodeRight, verifyCodeBottom, "b@ffffff-0d0d0d", 1.0);
            textBox1.Text = price;
        }

        private void Form1_Load(object sender, EventArgs e)
        {           
            this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(Timer_Tick);
            this.timer1.Start();
            this.webBrowser1.Url = new Uri("http://test.alltobid.com/moni/gerenlogin.html");
            this.webBrowerP = webBrowser1.PointToScreen(this.webBrowser1.Location);
            this.dm = new dmsoft();
            this.dm.SetPath("C:\\dm");
            this.dm.SetDict(0, "系统字库数字.txt");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        //注册大漠插件register dm.dll
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

        //浏览器加载完毕后
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            int dx = 815 + this.webBrowerP.X;
            int dy = 500 + this.webBrowerP.Y;
            Mouse.MouseLefDownEvent(dx, dy, 0);
            Thread.Sleep(1000);
            Mouse.MouseLefDownEvent(dx, dy, 0);
            //MessageBox.Show("xy:" + dx + "-" + dy);
        }

        //截屏按钮
        private void button4_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Brower坐标：" + webBrowerP.X + "-" + webBrowerP.Y);
            int verifyCodeLeft = 741 + webBrowerP.X, verifyCodeTop = 304 + webBrowerP.Y, verifyCodeRight = 857 + webBrowerP.X, verifyCodeBottom = 332 + webBrowerP.Y;
            //MessageBox.Show("坐标:(" + verifyCodeLeft + "," + verifyCodeTop + ")-(" + verifyCodeRight + "," + verifyCodeBottom + ")");
            
            if (!Directory.Exists(" c:\\dm"))  //判断目录是否存在,不存在就创建
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(" c:\\dm");
                directoryInfo.Create();
            }
            //创建图片对象
            int width = 116;
            int height = 28;
            //设置图像的大小
            Bitmap bmp2 = new Bitmap(width, height);
            Graphics g2 = Graphics.FromImage(bmp2);  //创建画笔
            //从指定的区域中复制图形
            g2.CopyFromScreen(verifyCodeLeft, verifyCodeTop,0,0, bmp2.Size);//截屏
            //把图形放在PictureBox中显示
            pictureBox1.Image = bmp2;
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");//获得系统时间
            time = System.Text.RegularExpressions.Regex.Replace(time, @"[^0-9]+", "");//提取数字
            string fileName = time + ".bmp"; //创建文件名
            bmp2.Save("c:\\dm\\" + fileName); //保存为文件  ,注意格式是否正确.
            //不能使用Dispose，不然图片就没有了，同时也会引起异常
            //bmp2.Dispose();//关闭对象
            g2.Dispose();//关闭画笔

            //string imgsrc = @"C:\Users\Administrator\Desktop\a.jpg";
            //Image image = Image.FromFile(imgsrc);  
            //image.Save(@"C:\Users\Administrator\Desktop\a1.png", ImageFormat.Png);//绝对路径  
            /* //图片截取一部分 
            Bitmap image = new Bitmap(imgsrc); 
            Bitmap image1 = new Bitmap(200,100); 
            int width = image.Width; 
            int height = image.Height; 
            Graphics g = Graphics.FromImage(image1); 
            Rectangle rect = new Rectangle(0, 0, 200, 100); 
            g.DrawImage(image,0,0,rect, GraphicsUnit.Pixel); 
            image1.Save(@"C:\Users\Administrator\Desktop\a1.png", ImageFormat.Png); 
            */
            /* //图片的放大和缩小 
            Bitmap image = new Bitmap(imgsrc); 
            Bitmap image1 = new Bitmap(300, 300); 
            Graphics g = Graphics.FromImage(image1); 
            Rectangle rect = new Rectangle(0, 0, 300, 300); 
            g.DrawImage(image, rect); 
            image1.Save(@"C:\Users\Administrator\Desktop\a1.jpg", ImageFormat.Jpeg); 
            */
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Brower坐标：" + webBrowerP.X + "-" + webBrowerP.Y);
            int verifyCodeLeft = 204 + webBrowerP.X, verifyCodeTop = 390 + webBrowerP.Y, verifyCodeRight = 242 + webBrowerP.X, verifyCodeBottom = 403 + webBrowerP.Y;
            //MessageBox.Show("坐标:(" + verifyCodeLeft + "," + verifyCodeTop + ")-(" + verifyCodeRight + "," + verifyCodeBottom + ")");

            String price = dm.Ocr(verifyCodeLeft, verifyCodeTop, verifyCodeRight, verifyCodeBottom, "b@ffffff-0d0d0d", 1.0);
            //String price = dm.Ocr(verifyCodeLeft, verifyCodeTop, verifyCodeRight, verifyCodeBottom, "b@FFFFFF", 0.8);
            textBox1.Text = price;

            /*
            if (!Directory.Exists(" c:\\dm"))  //判断目录是否存在,不存在就创建
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(" c:\\dm");
                directoryInfo.Create();
            }
            //创建图片对象
            int width = 116;
            int height = 28;
            //设置图像的大小
            Bitmap bmp2 = new Bitmap(width, height);
            Graphics g2 = Graphics.FromImage(bmp2);  //创建画笔
            //从指定的区域中复制图形
            g2.CopyFromScreen(verifyCodeLeft, verifyCodeTop, 0, 0, bmp2.Size);//截屏
            */
            /*
            tessnet2.Tesseract ocr = new tessnet2.Tesseract();//声明一个OCR类
            ocr.SetVariable("tessedit_char_whitelist", "0123456789"); //设置识别变量，当前只能识别数字。
            //ocr.Init(Application.StartupPath + @"\\tmpe", "eng", true); //应用当前语言包。注，Tessnet2是支持多国语的。语言包下载链接：http://code.google.com/p/tesseract-ocr/downloads/list
            List<tessnet2.Word> result = ocr.DoOCR(bmp2, Rectangle.Empty);//执行识别操作
            string code = result[0].Text;
            textBox1.Text = code;
            */
        }
    }
}
