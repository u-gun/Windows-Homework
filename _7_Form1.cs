namespace _7_1016_1
{
    public partial class _7_Form1 : Form
    {

        DateTime ojTime;
        public _7_Form1()
        {
            InitializeComponent();
            this.BackColor = Color.DarkCyan;
        }
        private void getTimeNow_Click(object sender, EventArgs e)
        {
            getTimeNow.BackColor = Color.White;
            ojTime = DateTime.Now;
            MessageBox.Show(ojTime.ToString(), "현재 시간");
        }
        private void ThisButtonColor_Click(object sender, EventArgs e)
        {
            panel1.Invalidate(); // ȭ�� ����
        }
        private void panel_Painte(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Random r = new Random();
            Color randomColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
            g.FillRectangle(new SolidBrush(randomColor), e.ClipRectangle);

        }
        private void backgroundColor_Click(object sender, EventArgs e)
        {
            Invalidate(); // ȭ�� ����
        }
        private void form1_Painte(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Random r = new Random();
            Color randomColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
            g.FillRectangle(new SolidBrush(randomColor), e.ClipRectangle);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            getTimeNow.BackColor = Color.DarkOrange;
        }

        private void closer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("파아국이 다가온다!", "종료",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2)
               == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("쳇 아직인가.", "확인",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
