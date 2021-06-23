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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strcon = "server=DESKTOP-NT1HALM; database =门诊挂号收费系统;Integrated security=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = strcon;
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string strcom = "select * from Staff where Logindify='{0}' and Account='{1}' and Password ='{2}'";
                strcom = string.Format(strcom, comboBox1.Text.Trim(), textBox1.Text.Trim(), textBox2.Text.Trim());
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = strcom;
                SqlDataReader re = com.ExecuteReader();
            }
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
