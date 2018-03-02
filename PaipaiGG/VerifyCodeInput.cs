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
    public partial class VerifyCodeInput : Form
    {
        public VerifyCodeInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.text = this.textBox1.Text;
        }
    }
}
