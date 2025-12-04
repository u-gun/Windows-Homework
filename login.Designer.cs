namespace _9_1113;

partial class Login
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
        login_button = new Button();
        singUp_button = new Button();
        label_ID = new Label();
        label_PW = new Label();
        textBox_PW = new TextBox();
        textBox_ID = new TextBox();
        SuspendLayout();
        // 
        // login_button
        // 
        login_button.Location = new Point(66, 137);
        login_button.Name = "login_button";
        login_button.Size = new Size(94, 29);
        login_button.TabIndex = 2;
        login_button.Text = "확인";
        login_button.UseVisualStyleBackColor = true;
        login_button.Click += login_button_Click;
        // 
        // singUp_button
        // 
        singUp_button.Location = new Point(166, 137);
        singUp_button.Name = "singUp_button";
        singUp_button.Size = new Size(94, 29);
        singUp_button.TabIndex = 3;
        singUp_button.Text = "회원가입";
        singUp_button.UseVisualStyleBackColor = true;
        singUp_button.Click += singUp_button_Click;
        // 
        // label_ID
        // 
        label_ID.AutoSize = true;
        label_ID.Location = new Point(48, 63);
        label_ID.Name = "label_ID";
        label_ID.Size = new Size(24, 20);
        label_ID.TabIndex = 4;
        label_ID.Text = "ID";
        // 
        // label_PW
        // 
        label_PW.AutoSize = true;
        label_PW.Location = new Point(40, 96);
        label_PW.Name = "label_PW";
        label_PW.Size = new Size(32, 20);
        label_PW.TabIndex = 5;
        label_PW.Text = "PW";
        // 
        // textBox_PW
        // 
        textBox_PW.Location = new Point(78, 96);
        textBox_PW.Name = "textBox_PW";
        textBox_PW.PasswordChar = '*';
        textBox_PW.Size = new Size(182, 27);
        textBox_PW.TabIndex = 1;
        // 
        // textBox_ID
        // 
        textBox_ID.Location = new Point(78, 63);
        textBox_ID.Name = "textBox_ID";
        textBox_ID.Size = new Size(182, 27);
        textBox_ID.TabIndex = 0;
        // 
        // login
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(313, 207);
        Controls.Add(textBox_ID);
        Controls.Add(textBox_PW);
        Controls.Add(label_PW);
        Controls.Add(label_ID);
        Controls.Add(singUp_button);
        Controls.Add(login_button);
        Name = "login";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button login_button;
    private Button singUp_button;
    private Label label_ID;
    private Label label_PW;
    private TextBox textBox_PW;
    private TextBox textBox_ID;
}