using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaipaiGG
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            //http请求测试
            string status = null;
            String res = HttpClientHelp.GetResponse("http://api.mydeershow.com/mobile/app/main/latest/good", out status);
            MessageBox.Show(status + "-" + res);
        }
    }
}
