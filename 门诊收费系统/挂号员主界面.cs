using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 门诊收费系统
{
    public partial class 挂号员主界面 : Form
    {
        public 挂号员主界面()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            new 个人中心().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToLongDateString() +"   "+ DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new 挂号管理主页面().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new 病人诊疗卡管理().Show();
        }
    }
}
