using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModalDlgApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form2 form = new Form2();                 //Modal = 뒤에 창이 안닫히는거
            ////form.ShowDialog();                      //form1 에서 form2 열기 , showDialog는 모달
            //form.Show();                              //show는 모달리스 






            MessageBox.Show("텍스트입니다", "제목", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Information);

        }
    }
}
