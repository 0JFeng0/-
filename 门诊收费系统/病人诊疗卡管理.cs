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
    public partial class 病人诊疗卡管理 : Form
    {
        public 病人诊疗卡管理()
        {
            InitializeComponent();
        }

        private void 病人诊疗卡管理_Load(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            病人信息 z = new 病人信息();
            this.Hide();
            z.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.Visible=true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
