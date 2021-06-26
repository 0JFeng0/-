using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Data.SqlClient;

namespace 门诊收费系统
{
    public partial class 查询统计主页面 : Form
    {

        public 查询统计主页面()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            复诊率统计查询 form3 = new 复诊率统计查询();
            form3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strCon = "data source=10.5.201.135; user id=admain;password=123456;initial catalog=门诊挂号收费系统";
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select Sgtnumber,Pname,Dname,Clcsort,Addate,Adtime,Registration.Sgtsort,cost from Registration,Cost where Registration.Sgtsort=Cost.Sgtsort ";
                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;

                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string strCmd1 = "select Count(distinct Pname) as 挂号总人数,sum(cost)as 挂号总费用 from Registration,Cost where Registration.Sgtsort=Cost.Sgtsort";
                    strCmd1 = string.Format(strCmd1, con);
                    SqlCommand command1 = new SqlCommand(strCmd1, con);

                    SqlDataReader dr1 = command1.ExecuteReader();

                    while (dr1.Read())
                    {
                        object[] data1 = new object[dr1.FieldCount];
                        dr1.GetValues(data1);

                        textBox1.Text = data1[0].ToString();
                        textBox2.Text = data1[1].ToString();
                    }

                    dr1.Close();
                    command1.Cancel();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            工作量查询 form2 = new 工作量查询();
            form2.Show();

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            个人中心 form1 = new 个人中心();
            form1.Show();
        }
    }
}
