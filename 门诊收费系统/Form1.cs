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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string strcon = "data source=10.5.201.135 ; user id=admain; password=123456; initial catalog=门诊挂号收费系统";
            SqlConnection con = new()
            {
                ConnectionString = strcon
            };
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string strcom = "select * from Staff where Logindify='{0}' and Account='{1}' and Password ='{2}'";
                strcom = string.Format(strcom, comboBox1.Text.Trim(), textBox1.Text.Trim(), textBox2.Text.Trim());
                SqlCommand sqlCommand = new()
                {
                    Connection = con,
                    CommandText = strcom
                };
                SqlCommand com = sqlCommand;
                SqlDataReader re = com.ExecuteReader();
                if (re.HasRows & comboBox1.Text.Trim()=="医生")
                {
                    //隐藏登录窗口,显示主窗口
                    this.Hide();
                    new Form2().Show();
                }
                else if (re.HasRows & comboBox1.Text.Trim() == "挂号员")
                {
                    //隐藏登录窗口,显示主窗口
                    this.Hide();
                    new Form3().Show();
                }
                else if(re.HasRows & comboBox1.Text.Trim() == "系统管理员")
                {
                    //隐藏登录窗口,显示主窗口
                    this.Hide();
                    new Form4().Show();
                }
                else
                {
                    MessageBox.Show("用户名或者密码不正确！");
                }
            }
            else
            {
                MessageBox.Show("用户名或者密码不正确！");
            }

        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
