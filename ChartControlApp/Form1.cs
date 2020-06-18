using MetroFramework;
using System;
using System.Windows.Forms;

namespace ChartControlApp
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Using Chart Control";

            // 10명의 학생 랜덤 점수 생성 및 차트 바인딩
            Random rand = new Random();                 // 점수가 랜덤이므로 실행될때마다 점수가 랜덤으로 생성됨
            chart1.Titles.Add("중간고사 성적");         // 차트의 제목
            for (int i = 0; i < 10; i++)                
            { int val = rand.Next(10, 100);
                chart1.Series["Score"].Points.Add(val);      // 최소 10 최대 100까지의 점수에서 랜덤으로 만듬
                //chart1.Series["Score"].LabelToolTip = val.ToString();


            }
            chart1.Series["Score"].LegendText = "과학점수";                      // LegendText = 범례
            chart1.Series["Score"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;    
            //차트의 모양을 선택



        }

        private void button1_Click(object sender, EventArgs e)
        {
            //차트의 데이터를 삭제
            chart1.Series["Score"].Points.Clear();
            MetroMessageBox.Show(this, "데이터를 지웠습니다.", "처리",             //메트로폼 적용하기
            MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
