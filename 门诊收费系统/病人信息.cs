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
    public partial class 病人信息 : Form
    {
        string strCon = "data source=10.5.201.135; user id=admain;password=123456;initial catalog=门诊挂号收费系统";
        public 病人信息()
        {
            InitializeComponent();
        }
        public void Init()
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select  PatientId 病人ID,Pname 病人姓名,Birthdate 出生日期,Page 年龄,Pphone 电话, Paddress 住址 from Patient";
                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }





        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string id = dataGridView1.CurrentRow.Cells["Patientld"].Value.ToString();
                    string strCmd = "delete from Patient where Patientld={0}";
                    strCmd = string.Format(strCmd, id);
                    SqlCommand command = new SqlCommand(strCmd, con);
                    command.ExecuteNonQuery();

                }
            }
            病人诊疗卡管理 z = new 病人诊疗卡管理();
            z.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != string.Empty)
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    string strCmd = "select  PatientId 病人ID,Pname 病人姓名,Birthdate 出生日期,Page 年龄,Pphone 电话,Paddress 住址from from patient where Patientld={0}";

                    strCmd = string.Format(strCmd, textBox7.Text);

                    SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;

                }
            }
            else { MessageBox.Show("病人ID不能为空！"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string id = dataGridView1.CurrentRow.Cells["Patientld"].Value.ToString();
                  
                  
                    string strCmd = "update patient set Patientld={0},Pname='{1}', Psex='{2}', Birthdate='{3}', Page='{4}', Pphone='{5}', Paddress='{6}' ";
                    strCmd = string.Format(strCmd, textBox7.Text, textBox1.Text, textBox6.Text, textBox4.Text, textBox2.Text, textBox5.Text, textBox3.Text);
                    SqlCommand command = new SqlCommand(strCmd, con);
                    command.ExecuteNonQuery();

                }
            }
            病人诊疗卡管理 z = new 病人诊疗卡管理();
            z.Show();
        }

        private void 病人信息_Load(object sender, EventArgs e)
        {
            Init();

        }
    }
}