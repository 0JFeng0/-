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
    public partial class Form4 : Form
    {


        string strCon = "data source=10.5.201.135 ; user id=admain; password=123456; initial catalog=门诊挂号收费系统";



        public void initType()
        {
            comboBox1.Items.Add("初诊");
            comboBox1.Items.Add("复诊");
        }




        public void initRoom()
        {
            comboBox2.Items.Add("K501");
            comboBox2.Items.Add("K502");
            comboBox2.Items.Add("K503");
            comboBox2.Items.Add("K504");
            comboBox2.Items.Add("L555");
        }



        public void initDepart()
        {
            comboBox3.Items.Add("外科部");
            comboBox3.Items.Add("脑科部");
            comboBox3.Items.Add("妇产科部");
            comboBox3.Items.Add("内科部");
            comboBox3.Items.Add("儿科部");
        }


        public void initTime()
        {
            comboBox5.Items.Add("周一上午");
            comboBox5.Items.Add("周一下午");
            comboBox5.Items.Add("周二上午");
            comboBox5.Items.Add("周二下午");
            comboBox5.Items.Add("周三上午");
            comboBox5.Items.Add("周三下午");
            comboBox5.Items.Add("周四上午");
            comboBox5.Items.Add("周四下午");
            comboBox5.Items.Add("周五上午");
            comboBox5.Items.Add("周五下午");
        }


        public Form4()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            initType();
            initRoom();
            initDepart();
            initTime();

       }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            comboBox4.Items.Clear();

            if (comboBox2.Text !="" && comboBox3.Text != "" && comboBox5.Text=="")
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        string strCmd = "select  distinct Dname from Doctor  where  Roomnb= '{0}' and Dptname = '{1}'  ";
                        strCmd = string.Format(strCmd, comboBox2.Text,comboBox3.Text);
                        SqlCommand command = new SqlCommand(strCmd, con);

                        //读取信息
                        SqlDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            object[] data = new object[dr.FieldCount];
                            dr.GetValues(data);

                            for (int k = 0; k < data.Length; k++)
                            {
                                comboBox4.Items.Add(data[k]);
                            }

                        }
                        dr.Close();

                    }
                }
            }


            else if (comboBox2.Text == "" && comboBox3.Text == "" && comboBox5.Text == "")
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        string strCmd = "select  distinct Dname from Doctor  ";
                        strCmd = string.Format(strCmd);
                        SqlCommand command = new SqlCommand(strCmd, con);

                        //读取信息
                        SqlDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            object[] data = new object[dr.FieldCount];
                            dr.GetValues(data);

                            for (int k = 0; k < data.Length; k++)
                            {
                                comboBox4.Items.Add(data[k]);
                            }

                        }
                        dr.Close();

                    }
                }
            }


            else if (comboBox2.Text != "" && comboBox3.Text == "" && comboBox5.Text == "")
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        string strCmd = "select  distinct  Dname from Doctor where Roomnb='{0}'  ";
                        strCmd = string.Format(strCmd,comboBox2.Text);
                        SqlCommand command = new SqlCommand(strCmd, con);

                        //读取信息
                        SqlDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            object[] data = new object[dr.FieldCount];
                            dr.GetValues(data);

                            for (int k = 0; k < data.Length; k++)
                            {
                                comboBox4.Items.Add(data[k]);
                            }

                        }
                        dr.Close();

                    }
                }
            }


           else if (comboBox3.Text != "" && comboBox2.Text == "" && comboBox5.Text == "")
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        string strCmd = "select  distinct Dname from Doctor where  Dptname='{0}'  ";
                        strCmd = string.Format(strCmd, comboBox3.Text);
                        SqlCommand command = new SqlCommand(strCmd, con);

                        //读取信息
                        SqlDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            object[] data = new object[dr.FieldCount];
                            dr.GetValues(data);

                            for (int k = 0; k < data.Length; k++)
                            {
                                comboBox4.Items.Add(data[k]);
                            }

                        }
                        dr.Close();

                    }
                }
            }



           else if (comboBox2.Text != "" && comboBox3.Text != "" && comboBox5.Text != "")
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        string strCmd = "select  distinct Dname from Doctor  where  Roomnb= '{0}' and Dptname = '{1}'  and Duty='{2}' ";
                        strCmd = string.Format(strCmd, comboBox2.Text, comboBox3.Text,comboBox5.Text);
                        SqlCommand command = new SqlCommand(strCmd, con);

                        //读取信息
                        SqlDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            object[] data = new object[dr.FieldCount];
                            dr.GetValues(data);

                            for (int k = 0; k < data.Length; k++)
                            {
                                comboBox4.Items.Add(data[k]);
                            }

                        }
                        dr.Close();

                    }
                }
            }


            else if (comboBox2.Text == "" && comboBox3.Text == "" && comboBox5.Text != "")
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        string strCmd = "select  distinct Dname from Doctor  where Duty='{0}' ";
                        strCmd = string.Format(strCmd,comboBox5.Text);
                        SqlCommand command = new SqlCommand(strCmd, con);

                        //读取信息
                        SqlDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            object[] data = new object[dr.FieldCount];
                            dr.GetValues(data);

                            for (int k = 0; k < data.Length; k++)
                            {
                                comboBox4.Items.Add(data[k]);
                            }

                        }
                        dr.Close();

                    }
                }
            }


            else if (comboBox2.Text != "" && comboBox3.Text == "" && comboBox5.Text != "")
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        string strCmd = "select  distinct  Dname from Doctor where Roomnb='{0}'  and Duty='{1}' ";
                        strCmd = string.Format(strCmd, comboBox2.Text,comboBox5.Text);
                        SqlCommand command = new SqlCommand(strCmd, con);

                        //读取信息
                        SqlDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            object[] data = new object[dr.FieldCount];
                            dr.GetValues(data);

                            for (int k = 0; k < data.Length; k++)
                            {
                                comboBox4.Items.Add(data[k]);
                            }

                        }
                        dr.Close();

                    }
                }
            }


            else if (comboBox3.Text != "" && comboBox2.Text == "" && comboBox5.Text != "")
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        string strCmd = "select  distinct Dname from Doctor where  Dptname='{0}'  and Duty='{1}' ";
                        strCmd = string.Format(strCmd, comboBox3.Text,comboBox5.Text);
                        SqlCommand command = new SqlCommand(strCmd, con);

                        //读取信息
                        SqlDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            object[] data = new object[dr.FieldCount];
                            dr.GetValues(data);

                            for (int k = 0; k < data.Length; k++)
                            {
                                comboBox4.Items.Add(data[k]);
                            }

                        }
                        dr.Close();

                    }
                }
            }






        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox5.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int i = r.Next(1000,10000);
            textBox2.Text = i.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text != "" && textBox3.Text != "" && comboBox3.Text != ""&& comboBox4.Text != ""&& comboBox1.Text!=""&&comboBox5.Text!="") {
                DialogResult dr = MessageBox.Show("保存确定", "保存提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {

                    using (SqlConnection con = new SqlConnection(strCon))
                    {
                        con.Open();
                        if (con.State == ConnectionState.Open)
                        {
                            string strCmd1 = "insert Registration values({0},'{1}','{2}','{3}','{4}','{5}','{6}')";
                            strCmd1 = string.Format(strCmd1, textBox2.Text, comboBox3.Text, textBox3.Text, comboBox4.Text, comboBox1.Text, comboBox5.Text, DateTime.Now.ToLongTimeString());
                            SqlCommand command = new SqlCommand(strCmd1, con);
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("保存成功！");
                }
            }

            else
            {
                MessageBox.Show("请把信息填完！","警告提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
       

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();

            f5.Show();

            f5.d1.Text =comboBox1.Text;
            f5.d2.Text =comboBox2.Text;
            f5.d3.Text =textBox3.Text;
            f5.d4.Text =comboBox4.Text;
            f5.d5.Text =comboBox3.Text;
            f5.d6.Text =textBox1.Text;

            f5.label3.Text =textBox2.Text;
            f5.label4.Text = comboBox5.Text;

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {

                    string strCmd = "select cost from Cost, Doctor where Cost.Sgtsort = Doctor.Dtitle and Doctor.Dname = '{0}' ";
                    strCmd = string.Format(strCmd, comboBox4.Text);
                    SqlCommand command = new SqlCommand(strCmd, con);

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        object[] data = new object[dr.FieldCount];
                        dr.GetValues(data);

                        textBox1.Text = string.Format("{0:N2}", data[0]);
                    }
                    dr.Close();
                    command.Cancel();

                }
            }
        }
    }
}
