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
    public partial class 个人中心 : Form
    {
        public 个人中心()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strCon = "data source=10.5.201.135; user id=admain;password=123456;initial catalog=门诊挂号收费系统";
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select * from Staff ";
                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string strCon1 = "data source=10.5.201.135; user id=admain;password=123456;initial catalog=门诊挂号收费系统";
            using (SqlConnection con = new SqlConnection(strCon1))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string strCmd2 = "select * from Staff  where  Staffid='{0}' ";
                    strCmd2 = string.Format(strCmd2, textBox1.Text);
                    SqlCommand command1 = new SqlCommand(strCmd2, con);

                    SqlDataReader dr1 = command1.ExecuteReader();

                    while (dr1.Read())
                    {
                        object[] data1 = new object[dr1.FieldCount];
                        dr1.GetValues(data1);
                        textBox2.Text = data1[5].ToString();
                    }
                    dr1.Close();
                    command1.Cancel();
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string strCon1 = "data source=10.5.201.135; user id=admain;password=123456;initial catalog=门诊挂号收费系统";
            if (textBox2.Text != string.Empty)
            {
                using (SqlConnection con = new SqlConnection(strCon1)) //不用的话释放连接
                {

                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        string strCmd2 = "update Staff set Password='{0}' where Staffid='{1}' ";
                        strCmd2 = string.Format(strCmd2, textBox3.Text, textBox1.Text);
                        SqlCommand command = new SqlCommand(strCmd2, con);
                        command.ExecuteNonQuery();

                        MessageBox.Show("密码修改成功！");
                    }
                    con.Close();
                }
            }
            else { MessageBox.Show("原密码不能为空！"); }
        }
    }
}


