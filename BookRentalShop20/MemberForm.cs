using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BookRentalShop20
{
    public partial class MemberForm : MetroForm
    {
        string strConnString = "Data Source=192.168.0.83;Initial Catalog=BookRentalDB;Persist Security Info=True;User ID=sa;Password=p@ssw0rd!";
        string mode = "";
        public MemberForm()
        {
            InitializeComponent();
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            UpdateData();
        }


        private void UpdateData()
        {
            //throw new NotImplementedException();

            using (SqlConnection conn = new SqlConnection(strConnString))               
            {
                conn.Open();    // DB가져오기(Membertbl 가져오기)
                string strQuery = " SELECT Idx, Names, Levels, Addr, Mobile, Email " + 
                                  " FROM dbo.membertbl ";                
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();                                            
                dataAdapter.Fill(ds, "Membertbl");

                GrdMemberTbl.DataSource = ds;                                              
                GrdMemberTbl.DataMember = "Membertbl";

            }

        }


        private void GrdDivTbl_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrdMemberTbl.Rows[e.RowIndex];                  
                TxtIdx.Text = data.Cells[0].Value.ToString();
                TxtNames.Text = data.Cells[1].Value.ToString();
                CboLevels.SelectedIndex = CboLevels.FindString(data.Cells[2].Value.ToString());     //콤보박스에 지정된 데이터를 불러온다.
                TxtAddr.Text = data.Cells[3].Value.ToString();
                TxtMobile.Text = data.Cells[4].Value.ToString();
                TxtEmail.Text = data.Cells[5].Value.ToString();

                TxtIdx.ReadOnly = true;                                       
                TxtIdx.BackColor = Color.Beige;                                
                mode = "UPDATE";                                                    
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            TxtIdx.Text = TxtNames.Text = "";
            TxtIdx.ReadOnly = false;
            mode = "INSERT";                                                        
                    
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TxtAddr.Text) || string.IsNullOrEmpty(TxtNames.Text)
                || string.IsNullOrEmpty(TxtMobile.Text) || string.IsNullOrEmpty(TxtEmail.Text))     //addr, names, mobile, email을 안 집어넣으면 안된다.
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
            TxtIdx.Text = TxtNames.Text = TxtAddr.Text = TxtMobile.Text = TxtEmail.Text = "";
            CboLevels.SelectedIndex = -1;
            TxtIdx.ReadOnly = true;
            TxtIdx.BackColor = Color.Beige;
            TxtNames.Focus();

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
                    strQuery = " UPDATE dbo.membertbl " +
                                " SET Names = @Names " +
                                "   , Levels = @Levels " +
                                "   , Addr = @Addr " +
                                "   , Mobile = @Mobile " +
                                "   , Email = @Email " +
                                " WHERE Idx = @Idx ";
                    cmd.CommandText = strQuery;
                }

                else if (mode == "INSERT")
                {
                    strQuery = " INSERT INTO dbo.membertbl (Names, Levels, Addr, Mobile, Email) " +
                                " VALUES(@Names, @Levels, @Addr, @Mobile, @Email) ";
                    cmd.CommandText = strQuery;
                }

                SqlParameter parmNames = new SqlParameter("@Names", SqlDbType.NVarChar, 45);
                parmNames.Value = TxtNames.Text;
                cmd.Parameters.Add(parmNames);

                SqlParameter parmLevels = new SqlParameter("@Levels", SqlDbType.Char, 1);
                parmLevels.Value = CboLevels.SelectedItem;                                 //콤보박스 데이터
                cmd.Parameters.Add(parmLevels);

                SqlParameter parmAddr = new SqlParameter("@Addr", SqlDbType.VarChar, 100);
                parmAddr.Value = TxtAddr.Text;
                cmd.Parameters.Add(parmAddr);

                SqlParameter parmMobile = new SqlParameter("@Mobile", SqlDbType.VarChar, 13);
                parmMobile.Value = TxtMobile.Text;
                cmd.Parameters.Add(parmMobile);

                SqlParameter parmEmail = new SqlParameter("@Email", SqlDbType.VarChar, 50);
                parmEmail.Value = TxtEmail.Text;
                cmd.Parameters.Add(parmEmail);

                if (mode == "UPDATE")
                {
                    SqlParameter parmIdx = new SqlParameter("@Idx", SqlDbType.Int);
                    parmIdx.Value = TxtIdx.Text;
                    cmd.Parameters.Add(parmIdx);
                }
                
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
            if (string.IsNullOrEmpty(TxtIdx.Text) || string.IsNullOrEmpty(TxtNames.Text))
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
                parmDivision.Value = TxtIdx.Text;
                cmd.Parameters.Add(parmDivision);

                cmd.ExecuteNonQuery();

            }
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
