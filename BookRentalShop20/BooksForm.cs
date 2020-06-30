using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security;
using System.Windows.Forms;

namespace BookRentalShop20
{
    public partial class BooksForm : MetroForm
    {
        string strConnString = "Data Source=192.168.0.83;Initial Catalog=BookRentalDB;Persist Security Info=True;User ID=sa;Password=p@ssw0rd!";
        string mode = "";
        public BooksForm()
        {
            InitializeComponent();
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            DtpReleaseDate.CustomFormat = " ";
            DtpReleaseDate.Format = DateTimePickerFormat.Custom;

            UpdateData();

            UpdateCboDivision();

        }

        private void UpdateCboDivision()
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT Division, Names FROM divtbl ";
                SqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, string> temps = new Dictionary<string, string>();
                    //       key     value                          key    value
                while (reader.Read())
                {
                 temps.Add(reader[0].ToString(), reader[1].ToString());
                }

                CboDivision.DataSource = new BindingSource(temps, null);
                CboDivision.DisplayMember = "Value";
                CboDivision.ValueMember = "Key";
                CboDivision.SelectedIndex = -1;                 //최초값은 아무것도 나타내지마라!

            }
        }



        private void UpdateData()
        {
            //throw new NotImplementedException();

            using (SqlConnection conn = new SqlConnection(strConnString))               
            {
                conn.Open();    // DB가져오기(bookstbl, divtbl INNER JOIN 데이터 가져오기)
                string strQuery = " SELECT  b.Idx, b.Author, b.Division, " +
                                  " d.Names AS 'DivNames', " +
                                  " b.Names, b.ReleaseDate, b.ISBN, " +
                                  " REPLACE(CONVERT(VARCHAR, CONVERT(MONEY, b.Price), 1), '.00', '') " +
                                  " FROM dbo.bookstbl AS b " +
                                  " INNER JOIN dbo.divtbl as d " +
                                  " ON b.Division = d.Division ";
                
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();                                            
                dataAdapter.Fill(ds, "bookstbl");

                GrdBooksTbl.DataSource = ds;                                              
                GrdBooksTbl.DataMember = "bookstbl";
            }

            DataGridViewColumn column = GrdBooksTbl.Columns[2];      //Division컬럼
            column.Visible = false;

        }


        private void GrdDivTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrdBooksTbl.Rows[e.RowIndex];                  
                TxtIdx.Text = data.Cells[0].Value.ToString();
                TxtAuthor.Text = data.Cells[1].Value.ToString();
                CboDivision.SelectedIndex = CboDivision.FindString(data.Cells[2].Value.ToString());
                // "로맨스" , "SF/판타지"
                //CboDivision.SelectedIndex = CboDivision.FindString(data.Cells[3].Value.ToString());
                // "B001" , "B006"
                CboDivision.SelectedValue = data.Cells[2].Value;

                TxtNames.Text = data.Cells[4].Value.ToString();

                DtpReleaseDate.CustomFormat = "yyyy-MM-dd";
                DtpReleaseDate.Format = DateTimePickerFormat.Custom;

                DtpReleaseDate.Value = DateTime.Parse(data.Cells[5].Value.ToString());
                TxtISBN.Text = data.Cells[6].Value.ToString();
                TxtPrice.Text = data.Cells[7].Value.ToString();

                TxtIdx.ReadOnly = true;                                       
                TxtIdx.BackColor = Color.Beige;                                
                mode = "UPDATE";                                                    
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearTextControls();
            mode = "INSERT";                                                        
                    
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TxtNames.Text) || string.IsNullOrEmpty(TxtAuthor.Text)
               || string.IsNullOrEmpty(TxtISBN.Text))     //나머지 text박스도 검사
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
            TxtIdx.Text = TxtAuthor.Text = TxtNames.Text =  TxtISBN.Text = "";
            TxtPrice.Text = "";
            CboDivision.SelectedIndex = -1;
            TxtIdx.ReadOnly = true;
            TxtIdx.BackColor = Color.Beige;
            TxtAuthor.Focus();

            DtpReleaseDate.CustomFormat = "";
            DtpReleaseDate.Format = DateTimePickerFormat.Custom;


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
                    strQuery = "UPDATE dbo.bookstbl " +
                        " SET Author = @Author, " +
                        " Division = @Division, " +
                        " Names = @Names," +
                        " ReleaseDate = @ReleaseDate, " +
                        " ISBN = @ISBN, " +
                        " Price = @Price " +
                        " WHERE idx = @Idx ";
                    cmd.CommandText = strQuery;
                }

                else if (mode == "INSERT")
                {
                    strQuery = " INSERT INTO "+
                               " dbo.bookstbl (Author, Division, Names, ReleaseDate, ISBN, Price) " +
                                " VALUES(@Author, @Division, @Names, @ReleaseDate, @ISBN, @Price)" ;
                    cmd.CommandText = strQuery;
                }

                SqlParameter parmAuthor = new SqlParameter("@Author", SqlDbType.VarChar, 45);
                parmAuthor.Value = TxtAuthor.Text;
                cmd.Parameters.Add(parmAuthor);

                SqlParameter parmDivision = new SqlParameter("@Division", SqlDbType.Char, 4);
                parmDivision.Value = CboDivision.SelectedValue;                                 //콤보박스 데이터
                cmd.Parameters.Add(parmDivision);

                SqlParameter parmNames = new SqlParameter("@Names", SqlDbType.VarChar, 100);
                parmNames.Value = TxtNames.Text;
                cmd.Parameters.Add(parmNames);

                SqlParameter parmReleaseDate = new SqlParameter("@ReleaseDate", SqlDbType.Date);
                parmReleaseDate.Value = DtpReleaseDate.Text;
                cmd.Parameters.Add(parmReleaseDate);

                SqlParameter parmISBN = new SqlParameter("@ISBN", SqlDbType.VarChar, 200);
                parmISBN.Value = TxtISBN.Text;
                cmd.Parameters.Add(parmISBN);

                SqlParameter parmPrice = new SqlParameter("@Price", SqlDbType.Decimal);
                parmPrice.Value = TxtPrice.Text;
                cmd.Parameters.Add(parmPrice);

                

                if (mode == "UPDATE")
                {
                    SqlParameter parmidx = new SqlParameter("@Idx", SqlDbType.Int);
                    parmidx.Value = TxtIdx.Text;
                    cmd.Parameters.Add(parmidx);
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
            if (string.IsNullOrEmpty(TxtIdx.Text) || string.IsNullOrEmpty(TxtAuthor.Text))
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

        private void DtpReleaseDate_ValueChanged(object sender, EventArgs e)
        {
            DtpReleaseDate.CustomFormat = "yyyy-MM-dd";
            DtpReleaseDate.Format = DateTimePickerFormat.Custom;
        }
    }
}
