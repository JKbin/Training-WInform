using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenFileDlgApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = "C:\\";                  // 역슬래시(\)를 나타낼때는 특수문자를 나타낸다는 \를 사용하고 적야한다.
            openFileDialog1.Filter = "텍스트 파일(*.txt)|*.txt";         // 텍스트파일만 취급하겠다
            openFileDialog1.Multiselect = true;                         // opendialog1의 속성에 multiselect를 true로 하는것이랑 똑같은 것 (여러가지 txt파일 선택가능)
            openFileDialog1.ShowDialog();

            foreach (var item in openFileDialog1.FileNames)
            {
                textBox1.Text += item;
                textBox1.Text += Environment.NewLine;                   // 줄바꿈 코드

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                BackColor = colorDialog1.Color;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button3.BackColor = colorDialog1.Color;
            }
        }
    }
}
