using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainMenuApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 열기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text += 열기OToolStripMenuItem.Text + Environment.NewLine;
                // 실제 열기 로직을 넣어야함
           
        }

        private void 새파일ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text += 새파일ToolStripMenuItem.Text + Environment.NewLine;
            // 새파일을 선택하면 textbox에 이름이 뜬다.
            toolStripStatusLabel1.Text = 새파일ToolStripMenuItem.Text;

        }

        private void 저장SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text += 저장SToolStripMenuItem.Text + Environment.NewLine;
            MessageBox.Show("저장했습니다");
        }

        private void 종료XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            // 프로그램을 종료시키는 코드
        }

        private void 프로그램정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)   
        {                   // Context Menu 설정 코드
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(e.Location);

            }
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            LblMouseLocation.Text = $"(X, Y) = ({e.X}, {e.Y})";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            button1.Focus();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            새파일ToolStripMenuItem_Click(sender, e);

        }
    }
}
