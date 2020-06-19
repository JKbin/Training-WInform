using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BookRentalShop20
{
    public partial class DivForm : MetroForm
    {
        string strConnString = "Data Source=192.168.0.83;Initial Catalog=BookRentalDB;Persist Security Info=True;User ID=sa;Password=p@ssw0rd!";
        string mode = "";
        public DivForm()
        {
            InitializeComponent();
        }

        private void DivForm_Load(object sender, System.EventArgs e)
        {
            UpdateData();   // 데이터그리드 DB 데이터 로딩하기
        }

        private void UpdateData()
        {
            //throw new NotImplementedException();

            using (SqlConnection conn = new SqlConnection(strConnString))               //strConnString : 데이터문자열 (이게있어야 DB연동가능)
            {
                conn.Open();    // DB열기
                string strQuery = "SELECT Division ,Names FROM divtbl ";                //마지막에 띄어쓰기(쿼리문에 띄어쓰기, 아니면 Errotr가 날 수도있음)
                //SqlCommand cmd = new SqlCommand(strQuery, conn);                        //데이터그리드에 데이터넣기 (코딩으로)
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();                                             //데이터를 받는 통
                dataAdapter.Fill(ds, "divtbl");

                GrdDivTbl.DataSource = ds;                                              //데이터를 부었다.
                GrdDivTbl.DataMember = "divtbl";

            }

        }


        private void GrdDivTbl_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrdDivTbl.Rows[e.RowIndex];                  //DataGridViewRow의 collection (묶음) 
                TxtDivision.Text = data.Cells[0].Value.ToString();
                TxtNames.Text = data.Cells[1].Value.ToString();
                TxtDivision.ReadOnly = true;                                        //TxtDivision 수정이 안되게하는 것 (보는것만 = readOnly)
                TxtDivision.BackColor = Color.Beige;                                //메트로폼이라 색이안바뀜
                mode = "UPDATE";                                                    //수정은 UPDATE
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            TxtDivision.Text = TxtNames.Text = "";
            TxtDivision.ReadOnly = false;
            mode = "INSERT";                                                        //신규는 INSERT
                    
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TxtDivision.Text) || string.IsNullOrEmpty(TxtNames.Text))
            {
                MetroMessageBox.Show(this, "빈 값은 저장할 수 없습니다.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            SaveProcess();
            UpdateData();
            ClearTextControls();

        }

        private void ClearTextControls()
        {
            TxtDivision.Text = TxtNames.Text = "";
            TxtDivision.ReadOnly = false;
            TxtDivision.BackColor = Color.White;
            TxtDivision.Focus();

        }

        private void SaveProcess()
        {  
            if (string.IsNullOrEmpty(mode))
            {
                MetroMessageBox.Show(this, "신규버튼을 누르고 데이터를 저장하세요", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            //DB저장프로세스
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string strQuery = "";

                if (mode == "UPDATE")
                {
                    strQuery = "UPDATE dbo.divtbl " +
                        " SET Names = @Names " +
                        " WHERE Division = @Division ";
                }

                else if (mode == "INSERT")
                {
                    strQuery = "INSERT INTO dbo.divtbl (Division, Names) " + 
                                " VALUES(@Division, @Names) ";
                    cmd.CommandText = strQuery;
                }

                SqlParameter parmNames = new SqlParameter("@Names", SqlDbType.NVarChar, 45);
                parmNames.Value = TxtNames.Text;
                cmd.Parameters.Add(parmNames);

                SqlParameter parmDivision = new SqlParameter("@Division", SqlDbType.Char, 4);
                parmDivision.Value = TxtDivision.Text;
                cmd.Parameters.Add(parmDivision);

                cmd.ExecuteNonQuery();                      //쿼리문실행

            }
        }

        private void TxtNames_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                BtnSave_Click(sender, new EventArgs());
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtDivision.Text) || string.IsNullOrEmpty(TxtNames.Text))
            {
                MetroMessageBox.Show(this, "빈 값은 삭제할 수 없습니다.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DeleteProcess();
            UpdateData();
            ClearTextControls();

        }

        private void DeleteProcess()
        {
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = " DELETE FROM dbo.divtbl WHERE Division = @Division ";
                SqlParameter parmDivision = new SqlParameter("@Division", SqlDbType.Char, 4);
                parmDivision.Value = TxtDivision.Text;
                cmd.Parameters.Add(parmDivision);

                cmd.ExecuteNonQuery();

            }
        }
    }
}
