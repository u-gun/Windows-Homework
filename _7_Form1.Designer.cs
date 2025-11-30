namespace _7_1016_1
{
    partial class _7_Form1
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
            getTimeNow = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            closer = new Button();
            panel1 = new Panel();
            button5 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // getTimeNow
            // 
            getTimeNow.BackgroundImage = _9_1113.Properties.Resources.개슴츠레한_고양이;
            getTimeNow.BackgroundImageLayout = ImageLayout.Stretch;
            getTimeNow.Font = new Font("맑은 고딕", 13F);
            getTimeNow.ForeColor = Color.RosyBrown;
            getTimeNow.Location = new Point(3, 12);
            getTimeNow.Name = "getTimeNow";
            getTimeNow.Size = new Size(196, 253);
            getTimeNow.TabIndex = 0;
            getTimeNow.Text = "현재시간";
            getTimeNow.UseVisualStyleBackColor = true;
            getTimeNow.Click += getTimeNow_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // button1
            // 
            button1.Location = new Point(301, 166);
            button1.Name = "button1";
            button1.Size = new Size(116, 29);
            button1.TabIndex = 1;
            button1.Text = "버튼색 변경";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // closer
            // 
            closer.Location = new Point(301, 128);
            closer.Name = "closer";
            closer.Size = new Size(94, 29);
            closer.TabIndex = 2;
            closer.Text = "파아국이다";
            closer.UseVisualStyleBackColor = true;
            closer.Click += closer_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DimGray;
            panel1.Location = new Point(439, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(249, 223);
            panel1.TabIndex = 3;
            panel1.Click += ThisButtonColor_Click;
            panel1.Paint += panel_Painte;
            // 
            // button5
            // 
            button5.BackgroundImage = _9_1113.Properties.Resources.랩탑불타파덕;
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            button5.Font = new Font("맑은 고딕", 7F);
            button5.ForeColor = Color.RosyBrown;
            button5.Location = new Point(476, 271);
            button5.Name = "button5";
            button5.Size = new Size(101, 125);
            button5.TabIndex = 1;
            button5.Text = "패널 바탕색 조작";
            button5.UseVisualStyleBackColor = true;
            button5.Click += ThisButtonColor_Click;
            button5.Enter += ThisButtonColor_Click;
            // 
            // button2
            // 
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Font = new Font("맑은 고딕", 7F);
            button2.ForeColor = Color.RosyBrown;
            button2.Location = new Point(316, 268);
            button2.Name = "button2";
            button2.Size = new Size(119, 30);
            button2.TabIndex = 2;
            button2.Text = " 폼 바탕색 조작";
            button2.UseVisualStyleBackColor = true;
            button2.Click += backgroundColor_Click;
            // 
            // _7_Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(761, 428);
            Controls.Add(button5);
            Controls.Add(button2);
            Controls.Add(panel1);
            Controls.Add(closer);
            Controls.Add(button1);
            Controls.Add(getTimeNow);
            Name = "_7_Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Paint += form1_Painte;
            ResumeLayout(false);
        }

        #endregion

        private Button getTimeNow;
        private System.Windows.Forms.Timer timer1;
        private Button button1;
        private Button closer;
        private Panel panel1;
        private Button button5;
        private Button button2;
    }
}
