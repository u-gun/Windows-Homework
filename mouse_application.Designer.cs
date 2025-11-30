namespace _9_1113;

partial class mouse_application
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
        ResetButton = new Button();
        SuspendLayout();
        // 
        // ResetButton
        // 
        ResetButton.Dock = DockStyle.Bottom;
        ResetButton.Location = new Point(0, 468);
        ResetButton.Name = "ResetButton";
        ResetButton.Size = new Size(517, 30);
        ResetButton.TabIndex = 0;
        ResetButton.Text = "초기화";
        ResetButton.UseVisualStyleBackColor = true;
        // 
        // mouse_application
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(517, 498);
        Controls.Add(ResetButton);
        Name = "mouse_application";
        Text = "mouse_application";
        Load += mouse_application_Load;
        Paint += mouse_application_Paint;
        MouseUp += mouse_application_MouseUp;
        Resize += mouse_application_Resize;
        ResumeLayout(false);
    }

    #endregion

    private Button ResetButton;
}