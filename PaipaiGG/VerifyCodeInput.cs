using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using WindowsAPI;

namespace PaipaiGG
{
    public partial class VerifyCodeInput : Form
    {
        public string verifyCode;
        private Bitmap bitmap;
        private Graphics graphics;  //创建画笔
        private int picTop,picLeft;

        public VerifyCodeInput(int left, int top)
        {
            InitializeComponent();
            this.picLeft = left;
            this.picTop = top;
            //创建图片对象
            int width = 111;
            int height = 40;
            //设置图像的大小
            this.bitmap = new Bitmap(width, height);
            this.graphics = Graphics.FromImage(bitmap);  //创建画笔
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.verifyCode = this.textBox1.Text;
            closeGraphics();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.verifyCode = "";
            closeGraphics();
            this.Close();
        }

        //关闭画笔，并保存图片
        private void closeGraphics()
        {
            if (!Directory.Exists(" c:\\dm"))  //判断目录是否存在,不存在就创建
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(" c:\\dm");
                directoryInfo.Create();
            }
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");//获得系统时间
            time = System.Text.RegularExpressions.Regex.Replace(time, @"[^0-9]+", "");//提取数字
            string fileName = time + ".bmp"; //创建文件名
            Trace.TraceInformation(message: "首次出价验证码文件名保存为：" + fileName);
            bitmap.Save("c:\\dm\\" + fileName); //保存为文件  ,注意格式是否正确.
            //不能使用Dispose，不然图片就没有了，同时也会引起异常
            this.bitmap.Dispose();//关闭对象
            this.graphics.Dispose();//关闭画笔
        }

        ///
        /// Resize图片
        ///
        /// 原始Bitmap
        /// 新的宽度
        /// 新的高度
        /// 保留着，暂时未用
        /// 处理以后的图片
        public static Bitmap KiResizeImage(Bitmap bmp, int newW, int newH)
        {
            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }

        private void VerifyCodeInput_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            this.timer1.Interval = 200;
            this.timer1.Tick += new EventHandler(Pic_Tick);
            this.timer1.Start();
        }

        //验证码显示
        private void Pic_Tick(object sender, EventArgs e)
        {
            try
            {
                //从指定的区域中复制图形
                graphics.CopyFromScreen(picLeft, picTop, 0, 0, bitmap.Size);//截屏
                //把图形放在PictureBox中显示
                System.Drawing.Image sourImage = bitmap;
                this.pictureBox1.Image = KiResizeImage(bitmap, sourImage.Width * 2, sourImage.Height * 2);
            }
            catch (Exception ex)
            {
                TraceHelper.GetInstance().Error(ex, "验证码截取出错");
            }
        }
    }
}
