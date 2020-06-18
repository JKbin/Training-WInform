using MetroFramework.Forms;

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
    }
}
