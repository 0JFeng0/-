using Microsoft.Data.SqlClient;
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
    public partial class 一键挂号与挂号查询 : Form
    {
        public 一键挂号与挂号查询()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strCon = "data source=10.5.201.135; user id=admain;password=123456;initial catalog=门诊挂号收费系统";
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select * from Patient  where  PatientId='{0}' ";

                strCmd = string.Format(strCmd, textBox1.Text);

                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Form5_Load(object sender, EventArgs e)
        {
            string strCon = "data source=10.5.201.135; user id=admain;password=123456;initial catalog=门诊挂号收费系统";
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select * from Patient ";
                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            new 挂号管理主页面().Show();
        }
    }
}

