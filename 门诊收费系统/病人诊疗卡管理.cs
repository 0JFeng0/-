using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;


namespace 门诊收费系统
{
    public partial class 病人诊疗卡管理 : Form
    {
        string strCon = "data source=10.5.201.135 ; user id=admain; password=123456; initial catalog=门诊挂号收费系统";
        public 病人诊疗卡管理()
        {
            InitializeComponent();
        }





        private void 病人诊疗卡管理_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            panel1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            病人信息 z = new 病人信息();
            this.Hide();
            z.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox16.Clear();
            textBox15.Clear();
            textBox14.Clear();
            textBox13.Clear();
            textBox12.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
            panel2.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string strCmd = "insert Patient values({0},'{1}','{2}','{3}',{4},'{5}','{6}');";
                    strCmd = string.Format(strCmd, textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text, textBox4.Text, textBox6.Text, textBox7.Text);
                    SqlCommand command = new SqlCommand(strCmd, con);
                    command.ExecuteNonQuery();
                    Random rm = new Random();
                    int num = rm.Next(1000, 10000);
                    string strCmd1 = "insert Medicalcard values({0},'{1}','{2}',);";
                    strCmd = string.Format(strCmd1, num, textBox1.Text, textBox8.Text);
                    panel1.Hide();
                    MessageBox.Show("新建成功");




                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select  * from patient where Patientld={0}";

                strCmd = string.Format(strCmd, textBox9.Text);

                SqlCommand command = new SqlCommand(strCmd, con);
                SqlDataReader dr1 = command.ExecuteReader();
                while (dr1.Read())
                {
                    object[] data1 = new object[dr1.FieldCount];
                    dr1.GetValues(data1);

                    textBox16.Text = data1[0].ToString();
                    textBox15.Text = data1[1].ToString();
                    textBox14.Text = data1[2].ToString();
                    textBox12.Text = data1[3].ToString();
                    textBox13.Text = data1[4].ToString();
                    textBox11.Text = data1[5].ToString();
                    textBox10.Text = data1[6].ToString();
                }

                dr1.Close();
                command.Cancel();
                string strCmd1 = "select Balance from Medicalcard where Pname='{0}'";

                strCmd = string.Format(strCmd1, textBox17.Text);
                SqlCommand command1 = new SqlCommand(strCmd, con);
                command1.ExecuteNonQuery();

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "delete from Medicalcard where Pname='{0}'";

                strCmd = string.Format(strCmd, textBox15.Text);
                SqlCommand command = new SqlCommand(strCmd, con);
                command.ExecuteNonQuery();
                MessageBox.Show("删除成功");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }
    }
}
