using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BookRentalShop20
{
    public partial class RentalForm : MetroForm
    {
        string mode = "";
        public RentalForm()
        {
            InitializeComponent();
        }

        private void RentalForm_Load(object sender, System.EventArgs e)
        {
            DtpRentalDate.CustomFormat = " ";
            DtpRentalDate.Format = DateTimePickerFormat.Custom;

            DtpReturnDate.CustomFormat = " ";
            DtpReturnDate.Format = DateTimePickerFormat.Custom;

            UpdateData();
            UpdateCbomemIdx();
            UpdateCbobookIdx();
        }

        private void UpdateCbobookIdx()
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT bookIdx FROM rentaltbl ";
                SqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, string> temps = new Dictionary<string, string>();
                //       key     value                          key    value
                while (reader.Read())
                {
                    temps.Add(reader[0].ToString(), reader[1].ToString());
                }

                CbobookIdx.DataSource = new BindingSource(temps, null);
                CbobookIdx.DisplayMember = "Value";
                CbobookIdx.ValueMember = "Key";
                CbobookIdx.SelectedIndex = -1;                 

            }
        }

        private void UpdateCbomemIdx()
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT memberIdx FROM rentaltbl ";
                SqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, string> temps = new Dictionary<string, string>();
                //       key     value                          key    value
                while (reader.Read())
                {
                    temps.Add(reader[0].ToString(), reader[1].ToString());
                }

                CbomemIdx.DataSource = new BindingSource(temps, null);
                CbomemIdx.DisplayMember = "Value";
                CbomemIdx.ValueMember = "Key";
                CbomemIdx.SelectedIndex = -1;                 

            }

        }

        private void UpdateData()
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                string strQuery = "SELECT r.idx , r.MemberIdx,b.idx as 'BookIdx', " +
                                  " r.RentalDate, r.ReturnDate " +
                                  " FROM rentaltbl AS r " +
                                  " INNER JOIN membertbl AS m " +
                                  " ON r.memberIdx = m.Idx " +
                                  " INNER JOIN bookstbl AS b " +
                                  " ON r.bookIdx = b.Idx " +
                                  " INNER JOIN divtbl AS t " +
                                  " ON b.division = t.division ";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "rentaltbl");

                GrdRtlTbl.DataSource = ds;
                GrdRtlTbl.DataMember = "rentaltbl";
            }
            //DataGridViewColumn column = GrdRtlTbl.Columns[1];      
            //column.Visible = false;
            //DataGridViewColumn column1 = GrdRtlTbl.Columns[2];
            //column.Visible = false;

        }

        private void GrdRtlTbl_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                DataGridViewRow data = GrdRtlTbl.Rows[e.RowIndex];
                TxTIdx.Text = data.Cells[0].Value.ToString();

                CbomemIdx.SelectedIndex = CbomemIdx.FindString(data.Cells[1].Value.ToString());
                CbomemIdx.SelectedValue = data.Cells[1].Value;

                CbobookIdx.SelectedIndex = CbobookIdx.FindString(data.Cells[2].Value.ToString());
                CbobookIdx.SelectedValue = data.Cells[2].Value;



                DtpRentalDate.CustomFormat = "yyyy-MM-dd";
                DtpRentalDate.Format = DateTimePickerFormat.Custom;
                DtpRentalDate.Value = DateTime.Parse(data.Cells[3].Value.ToString());

                DtpReturnDate.CustomFormat = "yyyy-MM-dd";
                DtpReturnDate.Format = DateTimePickerFormat.Custom;
                DtpReturnDate.Value = DateTime.Parse(data.Cells[4].Value.ToString());



                mode = "UPDATE";
                TxTIdx.ReadOnly = true;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ClearTextControls();
            mode = "INSERT";
        }

        private void ClearTextControls()
        {
            TxTIdx.Text = "";
            CbobookIdx.SelectedIndex = CbomemIdx.SelectedIndex = -1;

            DtpRentalDate.CustomFormat = "";
            DtpRentalDate.Format = DateTimePickerFormat.Custom;

            DtpReturnDate.CustomFormat = "";
            DtpReturnDate.Format = DateTimePickerFormat.Custom;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TxTIdx.Text) || string.IsNullOrEmpty(CbomemIdx.Text) ||
                string.IsNullOrEmpty(CbobookIdx.Text) || string.IsNullOrEmpty(DtpRentalDate.Text) ||
                string.IsNullOrEmpty(DtpReturnDate.Text))
            {
                MetroMessageBox.Show(this, "빈 값은 저장할 수 없습니다.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateData();
            ClearTextControls();
            SaveProcess();

        }

        private void SaveProcess()
        {
            if(string.IsNullOrEmpty(mode))
            {
                MetroMessageBox.Show(this, "신규버튼을 누르고 저장하세요", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string strQuery = "";

                if (mode == "UPDATE")
                {
                    strQuery = " UPDATE dbo.rentaltbl " +
                               " SET memberIdx = @memberIdx " +
                               " , bookIdx = @bookIdx , rentalDate = @rentalDate " +
                               " , returnDate = @returnDate " +
                               " WHERE idx = @idx ";
                    cmd.CommandText = strQuery;
                }
                else if(mode == "INSERT")
                {
                    strQuery = " INSERT INTO dbo.rentaltbl " +
                               " (memberIdx, bookIdx, rentalDate, returnDate) " +
                               " VALUES (@memberIdx, @bookIdx, @rentalDate, @returnDate ";
                    cmd.CommandText = strQuery;
                }

                SqlParameter parmmemberIdx = new SqlParameter("@memberIdx", SqlDbType.Int);
                parmmemberIdx.Value = CbomemIdx.SelectedValue;                                 //콤보박스 데이터
                cmd.Parameters.Add(parmmemberIdx);

                SqlParameter parmbookIdx = new SqlParameter("@bookIdx", SqlDbType.Int);
                parmbookIdx.Value = CbobookIdx.SelectedValue;                                 //콤보박스 데이터
                cmd.Parameters.Add(parmbookIdx);

                SqlParameter parmrentalDate = new SqlParameter("@rentalDate", SqlDbType.Date);
                parmrentalDate.Value = parmrentalDate.Value;
                cmd.Parameters.Add(parmrentalDate);                                        //Dtp 데이터

                SqlParameter parmreturnDate = new SqlParameter("@returnDate", SqlDbType.Date);
                parmreturnDate.Value = parmreturnDate.Value;
                cmd.Parameters.Add(parmreturnDate);

                if (mode == "UPDATE")
                {
                    SqlParameter parmIdx = new SqlParameter("@Idx", SqlDbType.Int);

                }
                cmd.ExecuteNonQuery();


            }
        }
    }
}
