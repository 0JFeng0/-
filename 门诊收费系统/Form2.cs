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
    public partial class Form2 : Form
    {

        string strCon = "data source=10.5.201.135 ; user id=admain; password=123456; initial catalog=门诊挂号收费系统";

        public Form2()
        {
            InitializeComponent();
        }


        public void InitPatient()
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select * from Patient ";
                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
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

        private void Form2_Load(object sender, EventArgs e)
        {
            InitPatient();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            InitPatient();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells["PatientId"].Value;

            string name = dataGridView1.CurrentRow.Cells["Pname"].Value.ToString();

            Form3 f3 = new Form3();

            f3.Show();

            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {

                    string strCmd1 = "Select * from Patient where PatientId={0}";
                    strCmd1 = string.Format(strCmd1, id);
                    SqlCommand command1 = new SqlCommand(strCmd1, con);

                    SqlDataReader dr1 = command1.ExecuteReader();

                    while (dr1.Read())
                    {
                        object[] data1 = new object[dr1.FieldCount];
                        dr1.GetValues(data1);

                        f3.p0.Text = data1[0].ToString();
                        f3.p1.Text = data1[1].ToString();
                        f3.p2.Text = data1[2].ToString();
                        f3.p3.Text = data1[3].ToString();
                        f3.p4.Text = data1[4].ToString();
                        f3.p5.Text = data1[5].ToString();
                        f3.p6.Text = data1[6].ToString();
                    }

                    dr1.Close();
                    command1.Cancel();


                    string strCmd2 = "Select * from Diagnosis where Pname='{0}' ";
                    strCmd2 = string.Format(strCmd2, name);
                    SqlCommand command2 = new SqlCommand(strCmd2, con);

                    SqlDataReader dr2 = command2.ExecuteReader();

                    while (dr2.Read())
                    {
                        object[] data2 = new object[dr2.FieldCount];
                        dr2.GetValues(data2);

                        f3.D1.Text = data2[1].ToString();
                        f3.D2.Text = data2[2].ToString();
                        f3.D3.Text = data2[3].ToString();
                        f3.D4.Text = data2[4].ToString();
                        f3.D5.Text = data2[5].ToString();
                        f3.D6.Text = data2[5].ToString();
                    }
                    dr2.Close();
                    command2.Cancel();


                    string strCmd3 = "select cost from Cost, Doctor where Cost.Sgtsort = Doctor.Dtitle and Doctor.Dname = '{0}' ";
                    strCmd3 = string.Format(strCmd3, f3.D1.Text);
                    SqlCommand command3 = new SqlCommand(strCmd3, con);

                    SqlDataReader dr3 = command3.ExecuteReader();

                    while (dr3.Read())
                    {
                        object[] data3 = new object[dr3.FieldCount];
                        dr3.GetValues(data3);

                        f3.cost.Text = string.Format("{0:N2}",data3[0]);
                    }
                    dr3.Close();
                    command3.Cancel();



                    string strCmd4 = "select Vaccine, Detripst, Sicktl  from Pestilence, Preinquiry  where   Pestilence.Pname=Preinquiry.Pname  and Pestilence.Pname='{0}' ";
                    strCmd4 = string.Format(strCmd4, name);
                    SqlCommand command4 = new SqlCommand(strCmd4, con);

                    SqlDataReader dr4 = command4.ExecuteReader();

                    while (dr4.Read())
                    {
                        object[] data4 = new object[dr4.FieldCount];
                        dr4.GetValues(data4);

                        f3.Pest0.Text = data4[0].ToString();
                        f3.Pest1.Text = data4[1].ToString();
                        f3.Pest2.Text = data4[2].ToString();

                    }
                    dr4.Close();
                    command4.Cancel();




                }
            



                }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

