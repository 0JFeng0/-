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
    public partial class 工作量查询 : Form
    {
        public 工作量查询()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strCon = "data source=10.5.201.135; user id=admain;password=123456;initial catalog=门诊挂号收费系统";
            using (SqlConnection con = new SqlConnection(strCon))
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    string strCmd = "select Staffid,Staffname,Logindify,Workload from Staff where Logindify='挂号员' ";
                    SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    string strCmd2 = "select Staffid,Staffname,Logindify,Workload  from Staff where Logindify='医生' ";
                    SqlDataAdapter da2 = new SqlDataAdapter(strCmd2, con);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    dataGridView2.DataSource = ds2.Tables[0].DefaultView;
                }


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
