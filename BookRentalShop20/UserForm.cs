﻿using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BookRentalShop20
{
    public partial class UserForm : MetroForm
    {
        string strConnString = "Data Source=192.168.0.83;Initial Catalog=BookRentalDB;Persist Security Info=True;User ID=sa;Password=p@ssw0rd!";
        string mode = "";
        public UserForm()
        {
            InitializeComponent();
        }

        private void DivForm_Load(object sender, System.EventArgs e)
        {
            UpdateData();   // 데이터그리드 DB 데이터 로딩하기
        }
        /// <summary>
        /// 사용자 데이터 가져오기
        /// </summary>
        private void UpdateData()
        {
            //throw new NotImplementedException();

            using (SqlConnection conn = new SqlConnection(strConnString))               //strConnString : 데이터문자열 (이게있어야 DB연동가능)
            {
                conn.Open();    // DB열기
                string strQuery = "SELECT id,userID,password,lastLoginDt,loginIpAddr " +
                                    " FROM dbo.userTbl ";               
                //SqlCommand cmd = new SqlCommand(strQuery, conn);                        //데이터그리드에 데이터넣기 (코딩으로)
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();                                             //데이터를 받는 통
                dataAdapter.Fill(ds, "divtbl");

                GrdUserTbl.DataSource = ds;                                              //데이터를 부었다.
                GrdUserTbl.DataMember = "divtbl";

            }
            DataGridViewColumn column = GrdUserTbl.Columns[0];      //id컬럼
            column.Width = 40;
            column.HeaderText = "순번";
            column = GrdUserTbl.Columns[1];         //userID 컬럼
            column.Width = 80;
            column.HeaderText = "아이디";
            column = GrdUserTbl.Columns[2];       //Password컬럼  
            column.Width = 100;
            column.HeaderText = "패스워드";
            column = GrdUserTbl.Columns[3];         //최종접속시간
            column.Width = 120;
            column.HeaderText = "최종접속시간";
            column = GrdUserTbl.Columns[4];         //userID 컬럼
            column.Width = 150;
            column.HeaderText = "접속아이피주소";      //접속아이피주소


        }
        /// <summary>
        /// 그리드 셀클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdDivTbl_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrdUserTbl.Rows[e.RowIndex];                  //DataGridViewRow의 collection (묶음) 
                TxtId.Text = data.Cells[0].Value.ToString();
                TxtUserID.Text = data.Cells[1].Value.ToString();
                TxtPassword.Text = data.Cells[2].Value.ToString();
                mode = "UPDATE";                                                    //수정은 UPDATE
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            TxtUserID.Text = TxtPassword.Text = "";
            TxtUserID.ReadOnly = false;
            mode = "INSERT";                                                        //신규는 INSERT
                    
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TxtUserID.Text) || string.IsNullOrEmpty(TxtPassword.Text))
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
            TxtId.Text = TxtUserID.Text = TxtPassword.Text = "";
            //TxtUserID.ReadOnly = false;
            //TxtUserID.BackColor = Color.White;
            TxtUserID.Focus();

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
                    strQuery = " UPDATE dbo.userTbl " +
                               " SET userID = @UserID " +
                               " , Password = @Password " + 
                               " WHERE Id = @Id ";
                }

                else if (mode == "INSERT")
                {
                    strQuery = " INSERT INTO dbo.userTbl(userID, password) " +
                               " VALUES (@UserID, @Password) ";
  
                }

                cmd.CommandText = strQuery;

                SqlParameter parmUserID = new SqlParameter("@UserID", SqlDbType.VarChar, 12);
                parmUserID.Value = TxtUserID.Text;
                cmd.Parameters.Add(parmUserID);

                SqlParameter parmPassword = new SqlParameter("@Password", SqlDbType.VarChar, 20);
                parmPassword.Value = TxtPassword.Text;
                cmd.Parameters.Add(parmPassword);

                if (mode == "UPDATE")
                {
                    SqlParameter parmId = new SqlParameter("@Id", SqlDbType.Int);
                    parmId.Value = TxtId.Text;
                    cmd.Parameters.Add(parmId);

                }

                cmd.ExecuteNonQuery();                      //쿼리문실행
            }
        }

       
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtUserID.Text) || string.IsNullOrEmpty(TxtPassword.Text))
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
                parmDivision.Value = TxtUserID.Text;
                cmd.Parameters.Add(parmDivision);

                cmd.ExecuteNonQuery();

            }
        }
    }
}
