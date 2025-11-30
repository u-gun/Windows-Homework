namespace _9_1113;

partial class mouse_basic
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
        MouseStatuseListBox = new ListBox();
        MouseStatuseLavel = new Label();
        SuspendLayout();
        // 
        // MouseStatuseListBox
        // 
        MouseStatuseListBox.FormattingEnabled = true;
        MouseStatuseListBox.Location = new Point(12, 7);
        MouseStatuseListBox.Name = "MouseStatuseListBox";
        MouseStatuseListBox.Size = new Size(668, 404);
        MouseStatuseListBox.TabIndex = 0;
        MouseStatuseListBox.Click += MouseStatuseListBox_Click;
        MouseStatuseListBox.DoubleClick += MouseStatuseListBox_DoubleClick;
        MouseStatuseListBox.MouseUp += MouseStatuseListBox_MouseUp;
        // 
        // MouseStatuseLavel
        // 
        MouseStatuseLavel.AutoSize = true;
        MouseStatuseLavel.Location = new Point(12, 421);
        MouseStatuseLavel.Name = "MouseStatuseLavel";
        MouseStatuseLavel.Size = new Size(89, 20);
        MouseStatuseLavel.TabIndex = 1;
        MouseStatuseLavel.Text = "마우스 상태";
        // 
        // mouse_basic
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(MouseStatuseLavel);
        Controls.Add(MouseStatuseListBox);
        Name = "mouse_basic";
        Text = "Form2";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ListBox MouseStatuseListBox;
    private Label MouseStatuseLavel;
}