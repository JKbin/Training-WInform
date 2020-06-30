using MetroFramework;
using MetroFramework.Forms;
using System.Windows.Forms;

namespace BookRentalShop20
{
    public partial class MainForm : MetroForm       // MetroForm 적용
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();                     //loginForm 을 윈도우폼에 띄우는거

        }

     
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MetroMessageBox.Show(this, "정말 종료하시겠습니까?", "종료",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Form item in this.MdiChildren)
                {
                    item.Close();
                }

                e.Cancel = false;               // 종료 o
            }

            else
            {
                e.Cancel = true;                // 종료 x
            }
        }

        private void InitChildForm(Form form, string strFormTitle)
        {
            form.Text = strFormTitle;
            form.Dock = DockStyle.Fill;
            form.MdiParent = this;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }

        private void MnuItemDivMng_Click(object sender, System.EventArgs e)         // 구분코드관리
        {
            DivForm form = new DivForm();
            InitChildForm(form, "구분코드 관리");

            //form.Text = "구분코드 관리";
            //form.Dock = DockStyle.Fill;
            //form.MdiParent = this;                                              
            //form.Show();
            //form.WindowState = FormWindowState.Maximized;                       


        }

        private void 사용자관리UToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            UserForm form = new UserForm();
            InitChildForm(form, "사용자 관리");

            //form.Text = "사용자 관리";
            //form.Dock = DockStyle.Fill;
            //form.MdiParent = this;
            //form.Show();
            //form.WindowState = FormWindowState.Maximized;         
        }

        private void 회원관리NToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            MemberForm form = new MemberForm();
            InitChildForm(form, "회원관리");                    //회원관리 생성

        }

        private void MainForm_Activated(object sender, System.EventArgs e)
        {
            LblUserID.Text = Commons.LOGINUSERID;
        }

        private void 책관리BToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            BooksForm form = new BooksForm();
            InitChildForm(form, "책관리");

        }

        private void 대여관리RToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            RentalForm form = new RentalForm();
            InitChildForm(form, "대여관리");
        }
    }
}
