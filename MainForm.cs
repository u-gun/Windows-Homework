using _7_1016_1;
using _8_1030;
using System.Diagnostics;
using System.Drawing.Printing;

namespace _9_1113
{
    public partial class _9_Form : Form
    {
        public _9_Form()
        {
            InitializeComponent();
        }

        private void modal_7page_Click(object sender, EventArgs e)
        {
            _7_1016_1._7_Form1 form7 = new _7_1016_1._7_Form1();
            this.Hide();
            form7.ShowDialog();
        }
        private void modaless_8page_Click(object sender, EventArgs e)
        {
            _8_1030._8_Form1 form8 = new _8_1030._8_Form1();
            this.Hide();
            form8.Show();
        }


        /* 마우스 폼 열기
         */
        private void Mouse_basic_Click(object sender, EventArgs e)
        {
            this.Hide();
            _9_1113.mouse_basic MB = new _9_1113.mouse_basic(); MB.Show();
        }
        private void Mouse_application_Click(object sender, EventArgs e)
        {
            this.Hide();
            _9_1113.mouse_application MB = new _9_1113.mouse_application(); MB.Show();
        }


        private void 기본ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _9_1113.keyboard_basic keyboard_Basic = new _9_1113.keyboard_basic();
            this.Hide();
            keyboard_Basic.Show();
        }

        private void 응용ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _9_1113.keyboard_application keyboard_Application = new _9_1113.keyboard_application();
            this.Hide();
            keyboard_Application.Show();
        }


        private void _11ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            _9_1113._11_Form _11_Form = new _9_1113._11_Form();
            this.Hide();
            _11_Form.Show();
        }



        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            string str = textBox1.Text;
            Font printFont = textBox1.Font;
            if (e.Graphics != null)
                e.Graphics.DrawString(str, printFont, Brushes.Black, 10, 10);
        }

        //메뉴
        private void FileOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter =
                "Text Files|*.txt| All Files|*.*";
            openFileDialog1.ShowDialog();

            foreach (string filename in openFileDialog1.FileNames)
            {
                textBox1.Text += File.ReadAllText(filename) + "\r\n";
                //Process.Start("notepad.exe", openFileDialog1.FileNames);
            }
        }

        private void FileSave(object sender, EventArgs e)
        {
            saveFileDialog1.Filter =
                "Text Files|*.txt| All Files|*.*";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                System.IO.StreamWriter sw =
                    new System.IO.StreamWriter(fs);
                sw.WriteLine(textBox1.Text);
                sw.Close();
            }
        }

        private void FilePrint_Click(object sender, EventArgs e)
        {
            PrinterSettings printer = new PrinterSettings();
            printDialog1.PrinterSettings = printer;
            PrintDocument pd = new PrintDocument();
            printDialog1.Document = pd;

            pd.PrintPage += new PrintPageEventHandler(this.PrintPage);
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void FilePrintPreview_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();

            pd.PrintPage += new PrintPageEventHandler(this.PrintPage);
            printPreviewDialog1.Document = pd;
            printPreviewDialog1.ShowDialog();
        }

        private void Close_Click(object sender, EventArgs e)
        {

        }

        private void Font_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            textBox1.Font = fontDialog1.Font;
            textBox1.ForeColor = fontDialog1.Color;
        }

        private void TextUndo_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void TextCut_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectedText != "") textBox1.Cut();
        }

        private void TextCopy_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionLength > 0) textBox1.Copy();
        }

        private void TextPaste_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.SelectedText)) textBox1.Paste();
        }

        private void TextSelectAll_Click(object sender, EventArgs e)
        {
            //if (textBox1.SelectedText != "") 
            textBox1.SelectAll();
        }

        private void Color_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            textBox1.BackColor = colorDialog1.Color;
        }

        private void Manual_Click(object sender, EventArgs e)
        {
            MessageBox.Show("뭐 어려운게 있다고 도움말을 찾아보시나...\n보이는게 답니다.");
        }

        private void Producer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("정_유건 JUNG_UGeong\n청운대학교 컴퓨터공학과 20220442");
        }

        private void FileSearch_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath.ToString();
        }

        private void NewFileOpen_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("현재 파일을 저장하시겠습니까?", "확인",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                saveFileDialog1.Filter = "텍스트|*.txt|도큐먼트|*.doc | 이미지문서 | *.pdf";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(textBox1.Text);
                    sw.Close(); fs.Close();
                }
            }
            textBox1.Text = "";
        }

    }
}
