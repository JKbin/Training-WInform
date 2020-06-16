using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListControlTestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)      // button1 = Add
        {
            if (textBox1.Text != "")
            {
                listBox1.Items.Add(textBox1.Text);               //textbox에 입력하고 추가를 누르면 listbox에 value가 들어간다.
                comboBox1.Items.Add(textBox1.Text);              //textbox에 입력하고 추가를 누르면 combobox에 value가 들어간다.

                textBox1.Text = " ";                            //추가를 누르고 textbox의 값을 지워준다.
                textBox1.Focus();                               //커서가 textbox로 향한다.
            }
            

        }

        private void button2_Click(object sender, EventArgs e)      // button2 = Remove
        {
           if (listBox1.SelectedIndex > -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = comboBox1.SelectedItem.ToString();

        }
    }
}
