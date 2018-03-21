using dmNet;
using PaipaiGG.Properties;
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
        private int first_priceLeft,first_priceTop,first_priceRight,first_priceBottom,modify_priceLeft,modify_priceTop,modify_priceRight,modify_priceBottom;
        private Thread workThread;
        private SynchronizationContext mainThreadSynContext;

        public Form1()
        {
            InitializeComponent();
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
            int x1 = 684 + webBrowerP.X;
            int y1 = 280 + webBrowerP.Y;
            Mouse.MouseLefDownEvent(x1, y1, 0);
            Thread.Sleep(200);
            SendKeys.Send("100");

            int x2 = 688 + webBrowerP.X;
            int y2 = 340 + webBrowerP.Y;
            //MessageBox.Show("x2y2:" + x2 + "," + y2);
            Mouse.MouseLefDownEvent(x2, y2, 0);
            Thread.Sleep(200);
            SendKeys.Send("100");

            Thread.Sleep(200);
            int x3 = 844 + webBrowerP.X;
            int y3 = 340 + webBrowerP.Y;
            //MessageBox.Show("x3y3:" + x3 + "," + y3);
            Mouse.MouseLefDownEvent(x3, y3, 0);

            Thread.Sleep(500);
            int x4 = 750 + webBrowerP.X;
            int y4 = 390 + webBrowerP.Y;
            Mouse.MouseLefDownEvent(x4, y4, 0);

            Thread.Sleep(500);
            mainThreadSynContext = SynchronizationContext.Current; //在这里记录主线程的上下文
            workThread = new Thread(new ThreadStart(copyScan));
            workThread.Start();
        }

        //修改出价
        private void button3_Click(object sender, EventArgs e)
        {
            int x1 = 690 + webBrowerP.X;
            int y1 = 380 + webBrowerP.Y;

            String price = textBox1.Text;

            int minPrice = Convert.ToInt32(price);
            price = (minPrice + 100) + "";

            Mouse.MouseLefDownEvent(x1, y1, 0);
            SendKeys.Send(price);
        }

        //输入验证码
        private void inputVerifyCode(object verifyCode)
        {
            String code = verifyCode.ToString();
            if (!code.Equals("cancel")) { 
                int x1 = 750 + webBrowerP.X;
                int y1 = 390 + webBrowerP.Y;
                Mouse.MouseLefDownEvent(x1, y1, 0);
                SendKeys.Send(code);

                //确定按钮
                int x2 = 600 + webBrowerP.X;
                int y2 = 470 + webBrowerP.Y;
                Mouse.MouseLefDownEvent(x2, y2, 0);

                //确认按钮
                Thread.Sleep(2000);
                int x3 = 707 + webBrowerP.X;
                int y3 = 445 + webBrowerP.Y;
                Mouse.MouseLefDownEvent(x3, y3, 0);
            }
            else
            {
                //取消按钮
                int x2 = 780 + webBrowerP.X;
                int y2 = 470 + webBrowerP.Y;
                Mouse.MouseLefDownEvent(x2, y2, 0);
            }
        }

        //拷贝验证码
        private void copyScan()
        {
            try { 
                //Thread.Sleep(1000);
                int verifyCodeLeft = 542 + webBrowerP.X, verifyCodeTop = 378 + webBrowerP.Y;
                //if (!Directory.Exists(" c:\\dm"))  //判断目录是否存在,不存在就创建
                //{
                //    DirectoryInfo directoryInfo = new DirectoryInfo(" c:\\dm");
                //    directoryInfo.Create();
                //}
                ////创建图片对象
                //int width = 111;
                //int height = 40;
                ////设置图像的大小
                //this.bitmap = new Bitmap(width, height);
                //this.graphics = Graphics.FromImage(bitmap);  //创建画笔
                ////从指定的区域中复制图形
                //graphics.CopyFromScreen(verifyCodeLeft, verifyCodeTop, 0, 0, bitmap.Size);//截屏
                ////把图形放在PictureBox中显示
                //pictureBox1.Image = bitmap;
                //string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");//获得系统时间
                //time = System.Text.RegularExpressions.Regex.Replace(time, @"[^0-9]+", "");//提取数字
                //string fileName = time + ".bmp"; //创建文件名
                //Trace.TraceInformation(message: "首次出价验证码文件名保存为：" + fileName);
                //MessageBox.Show(fileName);
                String verifyCode = "";
                VerifyCodeInput verifyCodeInput = new VerifyCodeInput(verifyCodeLeft, verifyCodeTop);
                if (DialogResult.OK == verifyCodeInput.ShowDialog())
                    verifyCode = verifyCodeInput.verifyCode;
                else
                    verifyCode = "cancel";
                //bitmap.Save("c:\\dm\\" + fileName); //保存为文件  ,注意格式是否正确.
                ////不能使用Dispose，不然图片就没有了，同时也会引起异常
                //bitmap.Dispose();//关闭对象
                //graphics.Dispose();//关闭画笔
                mainThreadSynContext.Post(new SendOrPostCallback(inputVerifyCode), verifyCode);//通知主线程
            }
            catch (Exception ex)
            {
                TraceHelper.GetInstance().Error(ex, "验证码截取出错");
                //Trace.TraceError("出现异常:" + ex.Message);//记录日志
                //Trace.TraceError("异常信息：" + ex.Message);
                //Trace.TraceError("异常对象：" + ex.Source);
                //Trace.TraceError("调用堆栈：\n" + ex.StackTrace.Trim());
                //Trace.TraceError("触发方法：" + ex.TargetSite);
            }
        }

        //识别最低成交价
        private void ocrPrice()
        {
            this.timer2.Interval = 500;
            this.timer2.Tick += new EventHandler(Price_Tick);
            this.timer2.Start();
        }

        //最低成效价显示
        private void Price_Tick(object sender, EventArgs e)
        {
            if (this.webBrowerP.X > 0 && this.webBrowerP.Y > 0) { 
                int verifyCodeLeft, verifyCodeTop, verifyCodeRight, verifyCodeBottom;
                verifyCodeLeft = 155 + webBrowerP.X;
                verifyCodeTop = 338 + webBrowerP.Y;
                verifyCodeRight = 184 + webBrowerP.X;
                verifyCodeBottom = 356 + webBrowerP.Y;
                String word = dm.Ocr(verifyCodeLeft, verifyCodeTop, verifyCodeRight, verifyCodeBottom, "b@ffffff-0d0d0d", 1.0);
                String price = "";
                if (word.Equals("修改"))
                {
                    label3.Text = "修改最低价：";
                    price = dm.Ocr(modify_priceLeft, modify_priceTop, modify_priceRight, modify_priceBottom, "b@ffffff-0d0d0d", 1.0);
                }
                else
                {
                    label3.Text = "首次最低价：";
                    price = dm.Ocr(first_priceLeft, first_priceTop, first_priceRight, first_priceBottom, "b@ffffff-0d0d0d", 1.0);
                }
                textBox1.Text = price;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //设置当前路径
            Trace.TraceInformation(message: "程序当前运行路径：" + Application.StartupPath);
            byte[] resDmNet = Resources.dmNet;
            FileStream fsDmNet = new FileStream(Application.StartupPath + "\\dmNet.dll", FileMode.Create, FileAccess.Write);
            fsDmNet.Write(resDmNet, 0, resDmNet.Length);
            fsDmNet.Close();

            byte[] resDm = Resources.dm;
            FileStream fsDm = new FileStream(Application.StartupPath + "\\dm.dll", FileMode.Create, FileAccess.Write);
            fsDm.Write(resDm, 0, resDm.Length);
            fsDm.Close();

            String resOcrChar = Resources.ocrChar;
            StreamWriter fsOcrChar = new StreamWriter(Application.StartupPath + "\\ocrChar.txt", false);
            fsOcrChar.Write(resOcrChar, 0, resOcrChar.Length);
            fsOcrChar.Close();

            this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(Timer_Tick);
            this.timer1.Start();
            this.webBrowser1.Url = new Uri("http://test.alltobid.com/moni/gerenlogin.html");

            AutoRegCom("regsvr32 " + Application.StartupPath + "\\dm.dll /s");
            this.dm = new dmsoft();
            this.dm.SetPath(Application.StartupPath);
            this.dm.SetDict(0, "ocrChar.txt");
            location();
            ocrPrice();
        }

        //设置各个关键位置坐标
        private void location()
        {
            this.webBrowerP = webBrowser1.PointToScreen(this.webBrowser1.Location);
            //首次出价最低成交价图片位置
            first_priceLeft = 204 + webBrowerP.X;
            first_priceTop = 390 + webBrowerP.Y;
            first_priceRight = 242 + webBrowerP.X;
            first_priceBottom = 403 + webBrowerP.Y;
            //修改出价阶段最低成交价图片位置
            modify_priceLeft = 204 + webBrowerP.X;
            modify_priceTop = 374 + webBrowerP.Y;
            modify_priceRight = 242 + webBrowerP.X;
            modify_priceBottom = 387 + webBrowerP.Y;
            //把异常信息输出到文件
            //Trace.TraceError("这是一个Error级别的日志");
            //Trace.TraceWarning("这是一个Warning级别的日志");
            //Trace.TraceInformation("这是一个Info级别的日志");
            //Trace.WriteLine("这是一个普通日志");
            //Trace.Flush();//立即输出
            //TraceHelper.GetInstance().Error("This is an error message", "Main Function");
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            location();
        }

        //本地时间显示
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        //注册大漠插件register dm.dll
        static string AutoRegCom(string strCmd)
        {
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

            verifyCodeLeft = 155 + webBrowerP.X;
            verifyCodeTop = 338 + webBrowerP.Y;
            verifyCodeRight = 184 + webBrowerP.X;
            verifyCodeBottom = 356 + webBrowerP.Y;
            String word = dm.Ocr(verifyCodeLeft, verifyCodeTop, verifyCodeRight, verifyCodeBottom, "b@ffffff-0d0d0d", 1.0);
            MessageBox.Show(word);

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
