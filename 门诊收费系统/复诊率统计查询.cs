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
    public partial class 复诊率统计查询 : Form
    {
        public 复诊率统计查询()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string strCon = "data source=10.5.201.135; user id=admain;password=123456;initial catalog=门诊挂号收费系统";
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select 初诊次数,复诊次数,总诊断次数,ROUND(CONVERT(DECIMAL(18, 2), 初诊次数) / 总诊断次数 , 4) AS 初诊率,ROUND(CONVERT(DECIMAL(18, 2), 复诊次数) / 总诊断次数 , 4) AS 复诊率 from (select Count(Clcsort) from Registration where Clcsort = '初诊') AS Reg1(初诊次数),(select Count(Clcsort) from Registration where Clcsort = '复诊') AS Reg2(复诊次数),(select Count(*) from Registration) AS Reg(总诊断次数) ";
                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
