namespace _9_1113
{
    partial class _9_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_9_Form));
            textBox1 = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            열기ToolStripMenuItem = new ToolStripMenuItem();
            복사하기ToolStripMenuItem = new ToolStripMenuItem();
            붙여넣기ToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            fontDialog1 = new FontDialog();
            colorDialog1 = new ColorDialog();
            printDialog1 = new PrintDialog();
            printPreviewDialog1 = new PrintPreviewDialog();
            saveFileDialog1 = new SaveFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            menuStrip1 = new MenuStrip();
            파일FToolStripMenuItem = new ToolStripMenuItem();
            새파일NToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            열기OToolStripMenuItem = new ToolStripMenuItem();
            저장SToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            인쇄PToolStripMenuItem = new ToolStripMenuItem();
            미리보기VToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            종료XToolStripMenuItem = new ToolStripMenuItem();
            편집EToolStripMenuItem = new ToolStripMenuItem();
            되돌리기UToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            오려두기XToolStripMenuItem = new ToolStripMenuItem();
            복사하기CToolStripMenuItem = new ToolStripMenuItem();
            붙여넣기VToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            모두선택AToolStripMenuItem = new ToolStripMenuItem();
            보기VToolStripMenuItem = new ToolStripMenuItem();
            글꼴FToolStripMenuItem = new ToolStripMenuItem();
            색상CToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            폴더탐색SToolStripMenuItem = new ToolStripMenuItem();
            프로젝트ToolStripMenuItem = new ToolStripMenuItem();
            장ToolStripMenuItem = new ToolStripMenuItem();
            장ToolStripMenuItem1 = new ToolStripMenuItem();
            장ToolStripMenuItem2 = new ToolStripMenuItem();
            마우스ToolStripMenuItem = new ToolStripMenuItem();
            기본ToolStripMenuItem = new ToolStripMenuItem();
            응용ToolStripMenuItem = new ToolStripMenuItem();
            키보드ToolStripMenuItem = new ToolStripMenuItem();
            기본ToolStripMenuItem1 = new ToolStripMenuItem();
            응용ToolStripMenuItem1 = new ToolStripMenuItem();
            장ToolStripMenuItem3 = new ToolStripMenuItem();
            장ToolStripMenuItem4 = new ToolStripMenuItem();
            창WToolStripMenuItem = new ToolStripMenuItem();
            도움말HToolStripMenuItem = new ToolStripMenuItem();
            매뉴얼MToolStripMenuItem = new ToolStripMenuItem();
            제작자PToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.ContextMenuStrip = contextMenuStrip1;
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(0, 28);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1291, 425);
            textBox1.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 열기ToolStripMenuItem, 복사하기ToolStripMenuItem, 붙여넣기ToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(139, 76);
            // 
            // 열기ToolStripMenuItem
            // 
            열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            열기ToolStripMenuItem.Size = new Size(138, 24);
            // 
            // 복사하기ToolStripMenuItem
            // 
            복사하기ToolStripMenuItem.Name = "복사하기ToolStripMenuItem";
            복사하기ToolStripMenuItem.Size = new Size(138, 24);
            복사하기ToolStripMenuItem.Text = "복사하기";
            복사하기ToolStripMenuItem.Click += TextCopy_Click;
            // 
            // 붙여넣기ToolStripMenuItem
            // 
            붙여넣기ToolStripMenuItem.Name = "붙여넣기ToolStripMenuItem";
            붙여넣기ToolStripMenuItem.Size = new Size(138, 24);
            붙여넣기ToolStripMenuItem.Text = "붙여넣기";
            붙여넣기ToolStripMenuItem.Click += TextPaste_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.InitialDirectory = "C:\\Users\\jug\\Desktop\\윈도우즈 실습\\_9_1113";
            openFileDialog1.Multiselect = true;
            // 
            // fontDialog1
            // 
            fontDialog1.ShowApply = true;
            fontDialog1.ShowColor = true;
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 파일FToolStripMenuItem, 편집EToolStripMenuItem, 보기VToolStripMenuItem, 프로젝트ToolStripMenuItem, 창WToolStripMenuItem, 도움말HToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1291, 28);
            menuStrip1.TabIndex = 15;
            menuStrip1.Text = "menuStrip1";
            // 
            // 파일FToolStripMenuItem
            // 
            파일FToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 새파일NToolStripMenuItem, toolStripMenuItem1, 열기OToolStripMenuItem, 저장SToolStripMenuItem, toolStripSeparator1, 인쇄PToolStripMenuItem, 미리보기VToolStripMenuItem, toolStripSeparator2, 종료XToolStripMenuItem });
            파일FToolStripMenuItem.Name = "파일FToolStripMenuItem";
            파일FToolStripMenuItem.Size = new Size(70, 24);
            파일FToolStripMenuItem.Text = "파일(&F)";
            // 
            // 새파일NToolStripMenuItem
            // 
            새파일NToolStripMenuItem.Name = "새파일NToolStripMenuItem";
            새파일NToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            새파일NToolStripMenuItem.Size = new Size(218, 26);
            새파일NToolStripMenuItem.Text = "새 파일(&N)";
            새파일NToolStripMenuItem.Click += NewFileOpen_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(215, 6);
            // 
            // 열기OToolStripMenuItem
            // 
            열기OToolStripMenuItem.Name = "열기OToolStripMenuItem";
            열기OToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            열기OToolStripMenuItem.Size = new Size(218, 26);
            열기OToolStripMenuItem.Text = "열기(&O)";
            열기OToolStripMenuItem.Click += FileOpen_Click;
            // 
            // 저장SToolStripMenuItem
            // 
            저장SToolStripMenuItem.Name = "저장SToolStripMenuItem";
            저장SToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            저장SToolStripMenuItem.Size = new Size(218, 26);
            저장SToolStripMenuItem.Text = "저장(&S)";
            저장SToolStripMenuItem.Click += FileSave;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(215, 6);
            // 
            // 인쇄PToolStripMenuItem
            // 
            인쇄PToolStripMenuItem.Name = "인쇄PToolStripMenuItem";
            인쇄PToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.P;
            인쇄PToolStripMenuItem.Size = new Size(218, 26);
            인쇄PToolStripMenuItem.Text = "인쇄(&P)";
            인쇄PToolStripMenuItem.Click += FilePrint_Click;
            // 
            // 미리보기VToolStripMenuItem
            // 
            미리보기VToolStripMenuItem.Name = "미리보기VToolStripMenuItem";
            미리보기VToolStripMenuItem.Size = new Size(218, 26);
            미리보기VToolStripMenuItem.Text = "미리보기(&V)";
            미리보기VToolStripMenuItem.Click += FilePrintPreview_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(215, 6);
            // 
            // 종료XToolStripMenuItem
            // 
            종료XToolStripMenuItem.Name = "종료XToolStripMenuItem";
            종료XToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            종료XToolStripMenuItem.Size = new Size(218, 26);
            종료XToolStripMenuItem.Text = "종료(&X)";
            종료XToolStripMenuItem.Click += Close_Click;
            // 
            // 편집EToolStripMenuItem
            // 
            편집EToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 되돌리기UToolStripMenuItem, toolStripSeparator3, 오려두기XToolStripMenuItem, 복사하기CToolStripMenuItem, 붙여넣기VToolStripMenuItem, toolStripSeparator4, 모두선택AToolStripMenuItem });
            편집EToolStripMenuItem.Name = "편집EToolStripMenuItem";
            편집EToolStripMenuItem.Size = new Size(71, 24);
            편집EToolStripMenuItem.Text = "편집(&E)";
            // 
            // 되돌리기UToolStripMenuItem
            // 
            되돌리기UToolStripMenuItem.Name = "되돌리기UToolStripMenuItem";
            되돌리기UToolStripMenuItem.Size = new Size(173, 26);
            되돌리기UToolStripMenuItem.Text = "되돌리기(&U)";
            되돌리기UToolStripMenuItem.Click += TextUndo_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(170, 6);
            // 
            // 오려두기XToolStripMenuItem
            // 
            오려두기XToolStripMenuItem.Name = "오려두기XToolStripMenuItem";
            오려두기XToolStripMenuItem.Size = new Size(173, 26);
            오려두기XToolStripMenuItem.Text = "오려두기(&X)";
            오려두기XToolStripMenuItem.Click += TextCut_Click;
            // 
            // 복사하기CToolStripMenuItem
            // 
            복사하기CToolStripMenuItem.Name = "복사하기CToolStripMenuItem";
            복사하기CToolStripMenuItem.Size = new Size(173, 26);
            복사하기CToolStripMenuItem.Text = "복사하기(&C)";
            복사하기CToolStripMenuItem.Click += TextCopy_Click;
            // 
            // 붙여넣기VToolStripMenuItem
            // 
            붙여넣기VToolStripMenuItem.Name = "붙여넣기VToolStripMenuItem";
            붙여넣기VToolStripMenuItem.Size = new Size(173, 26);
            붙여넣기VToolStripMenuItem.Text = "붙여넣기(&V)";
            붙여넣기VToolStripMenuItem.Click += TextPaste_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(170, 6);
            // 
            // 모두선택AToolStripMenuItem
            // 
            모두선택AToolStripMenuItem.Name = "모두선택AToolStripMenuItem";
            모두선택AToolStripMenuItem.Size = new Size(173, 26);
            모두선택AToolStripMenuItem.Text = "모두선택(&A)";
            모두선택AToolStripMenuItem.Click += TextSelectAll_Click;
            // 
            // 보기VToolStripMenuItem
            // 
            보기VToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 글꼴FToolStripMenuItem, 색상CToolStripMenuItem, toolStripSeparator5, 폴더탐색SToolStripMenuItem });
            보기VToolStripMenuItem.Name = "보기VToolStripMenuItem";
            보기VToolStripMenuItem.Size = new Size(104, 24);
            보기VToolStripMenuItem.Text = "유틸리티(&U)";
            // 
            // 글꼴FToolStripMenuItem
            // 
            글꼴FToolStripMenuItem.Name = "글꼴FToolStripMenuItem";
            글꼴FToolStripMenuItem.Size = new Size(170, 26);
            글꼴FToolStripMenuItem.Text = "글꼴(&F)";
            글꼴FToolStripMenuItem.Click += Font_Click;
            // 
            // 색상CToolStripMenuItem
            // 
            색상CToolStripMenuItem.Name = "색상CToolStripMenuItem";
            색상CToolStripMenuItem.Size = new Size(170, 26);
            색상CToolStripMenuItem.Text = "색상(&C)";
            색상CToolStripMenuItem.Click += Color_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(167, 6);
            // 
            // 폴더탐색SToolStripMenuItem
            // 
            폴더탐색SToolStripMenuItem.Name = "폴더탐색SToolStripMenuItem";
            폴더탐색SToolStripMenuItem.Size = new Size(170, 26);
            폴더탐색SToolStripMenuItem.Text = "폴더탐색(&S)";
            폴더탐색SToolStripMenuItem.Click += FileSearch_Click;
            // 
            // 프로젝트ToolStripMenuItem
            // 
            프로젝트ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 장ToolStripMenuItem, 장ToolStripMenuItem1, 장ToolStripMenuItem2, 장ToolStripMenuItem3, 장ToolStripMenuItem4 });
            프로젝트ToolStripMenuItem.Name = "프로젝트ToolStripMenuItem";
            프로젝트ToolStripMenuItem.Size = new Size(72, 24);
            프로젝트ToolStripMenuItem.Text = "실습(&P)";
            // 
            // 장ToolStripMenuItem
            // 
            장ToolStripMenuItem.Name = "장ToolStripMenuItem";
            장ToolStripMenuItem.Size = new Size(224, 26);
            장ToolStripMenuItem.Text = "7장";
            장ToolStripMenuItem.Click += modal_7page_Click;
            // 
            // 장ToolStripMenuItem1
            // 
            장ToolStripMenuItem1.Name = "장ToolStripMenuItem1";
            장ToolStripMenuItem1.Size = new Size(224, 26);
            장ToolStripMenuItem1.Text = "8장";
            장ToolStripMenuItem1.Click += modaless_8page_Click;
            // 
            // 장ToolStripMenuItem2
            // 
            장ToolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { 마우스ToolStripMenuItem, 키보드ToolStripMenuItem });
            장ToolStripMenuItem2.Name = "장ToolStripMenuItem2";
            장ToolStripMenuItem2.Size = new Size(224, 26);
            장ToolStripMenuItem2.Text = "10장";
            // 
            // 마우스ToolStripMenuItem
            // 
            마우스ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 기본ToolStripMenuItem, 응용ToolStripMenuItem });
            마우스ToolStripMenuItem.Name = "마우스ToolStripMenuItem";
            마우스ToolStripMenuItem.Size = new Size(137, 26);
            마우스ToolStripMenuItem.Text = "마우스";
            // 
            // 기본ToolStripMenuItem
            // 
            기본ToolStripMenuItem.Name = "기본ToolStripMenuItem";
            기본ToolStripMenuItem.Size = new Size(122, 26);
            기본ToolStripMenuItem.Text = "기본";
            기본ToolStripMenuItem.Click += Mouse_basic_Click;
            // 
            // 응용ToolStripMenuItem
            // 
            응용ToolStripMenuItem.Name = "응용ToolStripMenuItem";
            응용ToolStripMenuItem.Size = new Size(122, 26);
            응용ToolStripMenuItem.Text = "응용";
            응용ToolStripMenuItem.Click += Mouse_application_Click;
            // 
            // 키보드ToolStripMenuItem
            // 
            키보드ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 기본ToolStripMenuItem1, 응용ToolStripMenuItem1 });
            키보드ToolStripMenuItem.Name = "키보드ToolStripMenuItem";
            키보드ToolStripMenuItem.Size = new Size(137, 26);
            키보드ToolStripMenuItem.Text = "키보드";
            // 
            // 기본ToolStripMenuItem1
            // 
            기본ToolStripMenuItem1.Name = "기본ToolStripMenuItem1";
            기본ToolStripMenuItem1.Size = new Size(122, 26);
            기본ToolStripMenuItem1.Text = "기본";
            기본ToolStripMenuItem1.Click += 기본ToolStripMenuItem1_Click;
            // 
            // 응용ToolStripMenuItem1
            // 
            응용ToolStripMenuItem1.Name = "응용ToolStripMenuItem1";
            응용ToolStripMenuItem1.Size = new Size(122, 26);
            응용ToolStripMenuItem1.Text = "응용";
            응용ToolStripMenuItem1.Click += 응용ToolStripMenuItem1_Click;
            // 
            // 장ToolStripMenuItem3
            // 
            장ToolStripMenuItem3.Name = "장ToolStripMenuItem3";
            장ToolStripMenuItem3.Size = new Size(224, 26);
            장ToolStripMenuItem3.Text = "11장";
            장ToolStripMenuItem3.Click += _11ToolStripMenuItem3_Click;
            // 
            // 장ToolStripMenuItem4
            // 
            장ToolStripMenuItem4.Name = "장ToolStripMenuItem4";
            장ToolStripMenuItem4.Size = new Size(224, 26);
            장ToolStripMenuItem4.Text = "12장";
            // 
            // 창WToolStripMenuItem
            // 
            창WToolStripMenuItem.Name = "창WToolStripMenuItem";
            창WToolStripMenuItem.Size = new Size(73, 24);
            창WToolStripMenuItem.Text = "창작(&C)";
            // 
            // 도움말HToolStripMenuItem
            // 
            도움말HToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 매뉴얼MToolStripMenuItem, 제작자PToolStripMenuItem });
            도움말HToolStripMenuItem.Name = "도움말HToolStripMenuItem";
            도움말HToolStripMenuItem.Size = new Size(89, 24);
            도움말HToolStripMenuItem.Text = "도움말(&H)";
            // 
            // 매뉴얼MToolStripMenuItem
            // 
            매뉴얼MToolStripMenuItem.Name = "매뉴얼MToolStripMenuItem";
            매뉴얼MToolStripMenuItem.Size = new Size(161, 26);
            매뉴얼MToolStripMenuItem.Text = "매뉴얼(&M)";
            매뉴얼MToolStripMenuItem.Click += Manual_Click;
            // 
            // 제작자PToolStripMenuItem
            // 
            제작자PToolStripMenuItem.Name = "제작자PToolStripMenuItem";
            제작자PToolStripMenuItem.Size = new Size(161, 26);
            제작자PToolStripMenuItem.Text = "제작자(&P)";
            제작자PToolStripMenuItem.Click += Producer_Click;
            // 
            // _9_Form
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1291, 453);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(textBox1);
            Controls.Add(menuStrip1);
            Name = "_9_Form";
            Text = "_9_Form";
            contextMenuStrip1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private OpenFileDialog openFileDialog1;
        private FontDialog fontDialog1;
        private ColorDialog colorDialog1;
        private PrintDialog printDialog1;
        private PrintPreviewDialog printPreviewDialog1;
        private SaveFileDialog saveFileDialog1;
        private FolderBrowserDialog folderBrowserDialog1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 파일FToolStripMenuItem;
        private ToolStripMenuItem 편집EToolStripMenuItem;
        private ToolStripMenuItem 보기VToolStripMenuItem;
        private ToolStripMenuItem 프로젝트ToolStripMenuItem;
        private ToolStripMenuItem 창WToolStripMenuItem;
        private ToolStripMenuItem 도움말HToolStripMenuItem;
        private ToolStripMenuItem 새파일NToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem 열기OToolStripMenuItem;
        private ToolStripMenuItem 저장SToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem 인쇄PToolStripMenuItem;
        private ToolStripMenuItem 미리보기VToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem 종료XToolStripMenuItem;
        private ToolStripMenuItem 되돌리기UToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem 오려두기XToolStripMenuItem;
        private ToolStripMenuItem 복사하기CToolStripMenuItem;
        private ToolStripMenuItem 붙여넣기VToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem 모두선택AToolStripMenuItem;
        private ToolStripMenuItem 글꼴FToolStripMenuItem;
        private ToolStripMenuItem 색상CToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem 폴더탐색SToolStripMenuItem;
        private ToolStripMenuItem 장ToolStripMenuItem;
        private ToolStripMenuItem 장ToolStripMenuItem1;
        private ToolStripMenuItem 장ToolStripMenuItem2;
        private ToolStripMenuItem 장ToolStripMenuItem3;
        private ToolStripMenuItem 장ToolStripMenuItem4;
        private ToolStripMenuItem 매뉴얼MToolStripMenuItem;
        private ToolStripMenuItem 제작자PToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 열기ToolStripMenuItem;
        private ToolStripMenuItem 복사하기ToolStripMenuItem;
        private ToolStripMenuItem 붙여넣기ToolStripMenuItem;
        private ToolStripMenuItem 마우스ToolStripMenuItem;
        private ToolStripMenuItem 키보드ToolStripMenuItem;
        private ToolStripMenuItem 기본ToolStripMenuItem;
        private ToolStripMenuItem 응용ToolStripMenuItem;
        private ToolStripMenuItem 기본ToolStripMenuItem1;
        private ToolStripMenuItem 응용ToolStripMenuItem1;
    }
}
