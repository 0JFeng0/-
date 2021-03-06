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
    public partial class 诊断记录 : Form
    {
        public 诊断记录()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox7.Text = DateTime.Now.ToLocalTime().ToString();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox7.Text = DateTime.Now.ToLocalTime().ToString();
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
            if (textBox1.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("诊断记录（病人和医生）不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("病人诊断记录一经提交无法修改，确认提交？", "提示", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();
                        if (con.State == ConnectionState.Open)
                        {
                            string strcmd = "select * from Diagnosis where Diatime='{0}' ";
                            strcmd = string.Format(strcmd, textBox7.Text);
                            SqlDataAdapter da = new SqlDataAdapter(strcmd, con);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            if (ds.Tables[0].Rows.Count == 0)
                            {
                                //向诊断记录表中插入信息
                                string strcmd1 = "insert into Diagnosis values('{0}','{1}','{2}','{3}','{4}','{5}')";
                                strcmd1 = string.Format(strcmd1, textBox8.Text.Trim(), textBox1.Text.Trim(), richTextBox1.Text.Trim(),
                                    richTextBox2.Text.Trim(), textBox9.Text.Trim(), textBox7.Text.Trim());
                                SqlCommand com1 = new SqlCommand(strcmd1, con);
                                com1.ExecuteNonQuery();

                                //向处方记录表中插入信息
                                string strcmd2 = "insert into Prescription values('{0}','{1}','{2}','{3}','{4}')";
                                strcmd2 = string.Format(strcmd2, textBox9.Text.Trim(), textBox8.Text.Trim(), richTextBox3.Text.Trim(),
                                    textBox7.Text.Trim(), textBox10.Text.Trim());
                                SqlCommand com2 = new SqlCommand(strcmd2, con);
                                com2.ExecuteNonQuery();

                            }
                            else
                            {
                                MessageBox.Show("不可重复增加诊断记录!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    //向诊断记录表中插入信息
                    //using (SqlConnection con = new SqlConnection(strcon))
                    //{
                    //    con.Open();
                    //    if (con.State == ConnectionState.Open)
                    //    {
                    //        string strcmd = "insert into Diagnosis values('{0}','{1}','{2}','{3}','{4}','{5}')";
                    //        strcmd = string.Format(strcmd,textBox8.Text.Trim(), textBox1.Text.Trim(), richTextBox1.Text.Trim(), 
                    //            richTextBox2.Text.Trim(), textBox9.Text.Trim(),textBox7.Text.Trim());
                    //        SqlCommand com = new SqlCommand(strcmd, con);
                    //        com.ExecuteNonQuery();
                    //    }
                    //}
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();
                        if (con.State == ConnectionState.Open)
                        {
                            string strcmd = "select Pname 患者姓名 ,Dname 诊断医师 ,Sichis 过往病史,Disease 诊断病症," +
                            "Psiname 药方名称,Diatime 诊断时间  from Diagnosis where Diatime='{0}' ";
                            strcmd = string.Format(strcmd, textBox7.Text);
                            SqlDataAdapter da = new SqlDataAdapter(strcmd, con);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dataGridView1.DataSource = ds.Tables[0].DefaultView;
                        }
                    }
                    //向处方记录表中插入信息
                    //using (SqlConnection con = new SqlConnection(strcon))
                    //{
                    //    con.Open();
                    //    if (con.State == ConnectionState.Open)
                    //    {
                    //        string strcmd = "insert into Prescription values('{0}','{1}','{2}','{3}','{4}')";
                    //        strcmd = string.Format(strcmd, textBox9.Text.Trim(), textBox8.Text.Trim(), richTextBox3.Text.Trim(),
                    //            textBox7.Text.Trim(), textBox10.Text.Trim());
                    //        SqlCommand com = new SqlCommand(strcmd, con);
                    //        com.ExecuteNonQuery();
                    //    }
                    //}
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();
                        if (con.State == ConnectionState.Open)
                        {
                            string strcmd = "select Psiname 药方名称 ,Dname 开方医生 ,Psicontent 药方内容," +
                            "Diatime 诊断时间, Psicost 价格 from Prescription  where Diatime='{0}' ";
                            strcmd = string.Format(strcmd, textBox7.Text);
                            SqlDataAdapter da = new SqlDataAdapter(strcmd, con);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dataGridView2.DataSource = ds.Tables[0].DefaultView;
                        }
                    }
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        string strcmd = "select * from Patient where Pname='{0}';";
                        strcmd = string.Format(strcmd, textBox1.Text.Trim());
                        SqlCommand com = new SqlCommand(strcmd, con);
                        SqlDataReader read = com.ExecuteReader();
                        read.Read();
                        textBox2.Text = read["Psex"].ToString();
                        textBox3.Text = read["Page"].ToString();
                        textBox4.Text = read["Birthdate"].ToString();
                        textBox5.Text = read["Pphone"].ToString();
                        textBox6.Text = read["Paddress"].ToString();
                    }
                }
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        string strcmd1 = "select * from Preinquiry where Pname='{0}';";
                        strcmd1 = string.Format(strcmd1, textBox1.Text.Trim());
                        SqlCommand com1 = new SqlCommand(strcmd1, con);
                        SqlDataReader read1 = com1.ExecuteReader();
                        if (read1.Read())
                        {
                            richTextBox1.Text = read1["Sichis"].ToString();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请输病人姓名!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox7.Text = DateTime.Now.ToLocalTime().ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            new 登录().Show();
        }
    }
}
