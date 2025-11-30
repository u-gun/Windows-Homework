using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9_1113;
public partial class keyboard_basic : Form
{
    public keyboard_basic()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        this.button1.BackColor = SystemColors.Control; // 고유 색상
        this.button2.Focus(); // 버튼2에 포커스 지정
        if (this.button2.Focused) // 버튼2가 정상적으로 포커스를 받았다면?
            this.button2.BackColor = SystemColors.ControlDark;
    }

    private void button2_Click(object sender, EventArgs e)
    {
        this.button2.BackColor = SystemColors.Control;
        this.button1.Focus(); // 버튼1에 포커스 지정
        if (this.button1.Focused)
            this.button1.BackColor = SystemColors.ControlDark;
    }
}
