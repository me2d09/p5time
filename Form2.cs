using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using P5Time;

namespace P5Time
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Common.ConnectionSettings con = Common.GetServerSettings();
            server.Text = con.Server;
            userid.Text = con.UserId;
            password.Text = con.Password;
            txtDatabase.Text = con.Database;

            checkBox1.Checked = Common.AutoStart;
            textBox1.Text = Common.ExcelTemplate;
            textBox2.Text = Common.MysqldumpPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Common.SetServerSettings(new Common.ConnectionSettings(server.Text, userid.Text, password.Text, txtDatabase.Text));
            Common.AutoStart = checkBox1.Checked;
            Common.ExcelTemplate = textBox1.Text;
            Common.MysqldumpPath = textBox2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            textBox2.Text = openFileDialog2.FileName;
        }

       
    }
}
