namespace _9_1113;

partial class keyboard_application
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
        showKeypress = new Button();
        textBox_timeNow = new TextBox();
        SuspendLayout();
        // 
        // showKeypress
        // 
        showKeypress.Location = new Point(290, 103);
        showKeypress.Name = "showKeypress";
        showKeypress.Size = new Size(278, 29);
        showKeypress.TabIndex = 0;
        showKeypress.Text = "무슨 키를 눌렀니:";
        showKeypress.UseVisualStyleBackColor = true;
        showKeypress.KeyUp += showKeypress_KeyUp;
        // 
        // textBox_timeNow
        // 
        textBox_timeNow.CausesValidation = false;
        textBox_timeNow.Location = new Point(290, 68);
        textBox_timeNow.Name = "textBox_timeNow";
        textBox_timeNow.Size = new Size(278, 27);
        textBox_timeNow.TabIndex = 1;
        textBox_timeNow.TextAlign = HorizontalAlignment.Center;
        // 
        // keyboard_application
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(textBox_timeNow);
        Controls.Add(showKeypress);
        Name = "keyboard_application";
        Text = "keyboard_application";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button showKeypress;
    private TextBox textBox_timeNow;
}