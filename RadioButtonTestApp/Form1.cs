using System;
using System.Diagnostics;       //49번코드에서 alt+enter를 눌러 추가를 시켜줘야 49번코드에 빨간줄이 안뜬다.
using System.Windows.Forms;

namespace RadioButtonTestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = radioButton2.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = radioButton3.Text;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = radioButton4.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = string.Empty;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel1.Text);             //process에서 alt+enter를 눌러서 2번코드 Diagnostics를 추가시켜야함

        }
    }
}
