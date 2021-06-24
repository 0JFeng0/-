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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        string strcon = "data source=DESKTOP-NT1HALM;initial catalog =门诊挂号收费系统;integrated security = true";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string strcmd = "select * from Diagnosis where Pname='{0}' and Dname='{1}' and Diatime='{2}'";
                strcmd = string.Format(strcmd, textBox1.Text.Trim(), textBox8.Text.Trim(), textBox7.Text.Trim());
                SqlDataAdapter da = new SqlDataAdapter(strcmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
