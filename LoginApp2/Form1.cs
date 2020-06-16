using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = $"ID : {textBox1.Text} \n  Password : {textBox2.Text}";

            if ((textBox1.Text == "admin") && (textBox2.Text == "p@ssw0rd!"))
            {
                MessageBox.Show("관리자로그인!!");
            }
        }
    }
}
