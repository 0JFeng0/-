﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 门诊收费系统
{
    public partial class yuyue : Form
    {
        string strCon = "data source=10.5.201.135; user id=admain;password=123456;initial catalog=门诊挂号收费系统";
        public yuyue()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void yuyue_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string strCmd = "insert Preinquiry values('{0}','{1}','{2}','{3}');";
                    strCmd = string.Format(strCmd, textBox2.Text, richTextBox2.Text, richTextBox1.Text, textBox5.Text);
                    SqlCommand command = new SqlCommand(strCmd, con);
                    command.ExecuteNonQuery();
                    
                }
            }
        }
    }
}
