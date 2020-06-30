namespace BookRentalShop20
{
    partial class RentalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GrdRtlTbl = new MetroFramework.Controls.MetroGrid();
            this.TxTIdx = new MetroFramework.Controls.MetroTextBox();
            this.CbomemIdx = new MetroFramework.Controls.MetroComboBox();
            this.CbobookIdx = new MetroFramework.Controls.MetroComboBox();
            this.DtpRentalDate = new System.Windows.Forms.DateTimePicker();
            this.DtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.BtnUpdate = new MetroFramework.Controls.MetroButton();
            this.BtnSave = new MetroFramework.Controls.MetroButton();
            this.BtnCancle = new MetroFramework.Controls.MetroButton();
            this.bookRentalDBDataSet = new BookRentalShop20.BookRentalDBDataSet();
            this.bookRentalDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRtlTbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookRentalDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookRentalDBDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(20, 60);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GrdRtlTbl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.BtnCancle);
            this.splitContainer1.Panel2.Controls.Add(this.BtnSave);
            this.splitContainer1.Panel2.Controls.Add(this.BtnUpdate);
            this.splitContainer1.Panel2.Controls.Add(this.metroLabel5);
            this.splitContainer1.Panel2.Controls.Add(this.metroLabel4);
            this.splitContainer1.Panel2.Controls.Add(this.metroLabel3);
            this.splitContainer1.Panel2.Controls.Add(this.metroLabel2);
            this.splitContainer1.Panel2.Controls.Add(this.metroLabel1);
            this.splitContainer1.Panel2.Controls.Add(this.DtpReturnDate);
            this.splitContainer1.Panel2.Controls.Add(this.DtpRentalDate);
            this.splitContainer1.Panel2.Controls.Add(this.CbobookIdx);
            this.splitContainer1.Panel2.Controls.Add(this.CbomemIdx);
            this.splitContainer1.Panel2.Controls.Add(this.TxTIdx);
            this.splitContainer1.Size = new System.Drawing.Size(760, 370);
            this.splitContainer1.SplitterDistance = 356;
            this.splitContainer1.TabIndex = 0;
            // 
            // GrdRtlTbl
            // 
            this.GrdRtlTbl.AllowUserToAddRows = false;
            this.GrdRtlTbl.AllowUserToDeleteRows = false;
            this.GrdRtlTbl.AllowUserToResizeRows = false;
            this.GrdRtlTbl.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.GrdRtlTbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdRtlTbl.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GrdRtlTbl.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrdRtlTbl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.GrdRtlTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrdRtlTbl.DefaultCellStyle = dataGridViewCellStyle14;
            this.GrdRtlTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdRtlTbl.EnableHeadersVisualStyles = false;
            this.GrdRtlTbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.GrdRtlTbl.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.GrdRtlTbl.Location = new System.Drawing.Point(0, 0);
            this.GrdRtlTbl.Name = "GrdRtlTbl";
            this.GrdRtlTbl.ReadOnly = true;
            this.GrdRtlTbl.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrdRtlTbl.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.GrdRtlTbl.RowHeadersWidth = 51;
            this.GrdRtlTbl.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GrdRtlTbl.RowTemplate.Height = 27;
            this.GrdRtlTbl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdRtlTbl.Size = new System.Drawing.Size(356, 370);
            this.GrdRtlTbl.TabIndex = 0;
            this.GrdRtlTbl.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdRtlTbl_CellClick);
            // 
            // TxTIdx
            // 
            // 
            // 
            // 
            this.TxTIdx.CustomButton.Image = null;
            this.TxTIdx.CustomButton.Location = new System.Drawing.Point(159, 1);
            this.TxTIdx.CustomButton.Name = "";
            this.TxTIdx.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TxTIdx.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxTIdx.CustomButton.TabIndex = 1;
            this.TxTIdx.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxTIdx.CustomButton.UseSelectable = true;
            this.TxTIdx.CustomButton.Visible = false;
            this.TxTIdx.Lines = new string[0];
            this.TxTIdx.Location = new System.Drawing.Point(184, 54);
            this.TxTIdx.MaxLength = 32767;
            this.TxTIdx.Name = "TxTIdx";
            this.TxTIdx.PasswordChar = '\0';
            this.TxTIdx.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxTIdx.SelectedText = "";
            this.TxTIdx.SelectionLength = 0;
            this.TxTIdx.SelectionStart = 0;
            this.TxTIdx.ShortcutsEnabled = true;
            this.TxTIdx.Size = new System.Drawing.Size(181, 23);
            this.TxTIdx.TabIndex = 0;
            this.TxTIdx.UseSelectable = true;
            this.TxTIdx.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxTIdx.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // CbomemIdx
            // 
            this.CbomemIdx.FormattingEnabled = true;
            this.CbomemIdx.ItemHeight = 24;
            this.CbomemIdx.Location = new System.Drawing.Point(184, 98);
            this.CbomemIdx.Name = "CbomemIdx";
            this.CbomemIdx.Size = new System.Drawing.Size(181, 30);
            this.CbomemIdx.TabIndex = 1;
            this.CbomemIdx.UseSelectable = true;
            // 
            // CbobookIdx
            // 
            this.CbobookIdx.FormattingEnabled = true;
            this.CbobookIdx.ItemHeight = 24;
            this.CbobookIdx.Location = new System.Drawing.Point(184, 144);
            this.CbobookIdx.Name = "CbobookIdx";
            this.CbobookIdx.Size = new System.Drawing.Size(181, 30);
            this.CbobookIdx.TabIndex = 2;
            this.CbobookIdx.UseSelectable = true;
            // 
            // DtpRentalDate
            // 
            this.DtpRentalDate.Location = new System.Drawing.Point(184, 204);
            this.DtpRentalDate.Name = "DtpRentalDate";
            this.DtpRentalDate.Size = new System.Drawing.Size(200, 25);
            this.DtpRentalDate.TabIndex = 3;
            // 
            // DtpReturnDate
            // 
            this.DtpReturnDate.Location = new System.Drawing.Point(184, 257);
            this.DtpReturnDate.Name = "DtpReturnDate";
            this.DtpReturnDate.Size = new System.Drawing.Size(200, 25);
            this.DtpReturnDate.TabIndex = 4;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(44, 56);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(26, 20);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Idx";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(44, 108);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(79, 20);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "MemberIdx";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(44, 154);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(57, 20);
            this.metroLabel3.TabIndex = 3;
            this.metroLabel3.Text = "BookIdx";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(44, 204);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(76, 20);
            this.metroLabel4.TabIndex = 3;
            this.metroLabel4.Text = "RentalDate";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(44, 257);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(79, 20);
            this.metroLabel5.TabIndex = 3;
            this.metroLabel5.Text = "ReturnDate";
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(44, 302);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(95, 44);
            this.BtnUpdate.TabIndex = 5;
            this.BtnUpdate.Text = "신규";
            this.BtnUpdate.UseSelectable = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(167, 302);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(95, 44);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "저장";
            this.BtnSave.UseSelectable = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancle
            // 
            this.BtnCancle.Location = new System.Drawing.Point(289, 302);
            this.BtnCancle.Name = "BtnCancle";
            this.BtnCancle.Size = new System.Drawing.Size(95, 44);
            this.BtnCancle.TabIndex = 7;
            this.BtnCancle.Text = "취소";
            this.BtnCancle.UseSelectable = true;
            // 
            // bookRentalDBDataSet
            // 
            this.bookRentalDBDataSet.DataSetName = "BookRentalDBDataSet";
            this.bookRentalDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookRentalDBDataSetBindingSource
            // 
            this.bookRentalDBDataSetBindingSource.DataSource = this.bookRentalDBDataSet;
            this.bookRentalDBDataSetBindingSource.Position = 0;
            // 
            // RentalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "RentalForm";
            this.Text = "RentalForm";
            this.Load += new System.EventHandler(this.RentalForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdRtlTbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookRentalDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookRentalDBDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private MetroFramework.Controls.MetroGrid GrdRtlTbl;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DateTimePicker DtpReturnDate;
        private System.Windows.Forms.DateTimePicker DtpRentalDate;
        private MetroFramework.Controls.MetroComboBox CbobookIdx;
        private MetroFramework.Controls.MetroComboBox CbomemIdx;
        private MetroFramework.Controls.MetroTextBox TxTIdx;
        private MetroFramework.Controls.MetroButton BtnSave;
        private MetroFramework.Controls.MetroButton BtnUpdate;
        private MetroFramework.Controls.MetroButton BtnCancle;
        private System.Windows.Forms.BindingSource bookRentalDBDataSetBindingSource;
        private BookRentalDBDataSet bookRentalDBDataSet;
    }
}