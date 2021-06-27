using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 门诊收费系统
{
    public partial class 挂号管理主页面 : Form
    {
        public 挂号管理主页面()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            new 一键挂号与挂号查询().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new 挂号记录表().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            new 挂号员主界面().Show();
        }
    }
}
