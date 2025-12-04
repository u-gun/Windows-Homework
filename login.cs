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
public partial class Login : Form
{
    public Login()
    {
        InitializeComponent();
    }

    private void login_button_Click(object sender, EventArgs e)
    {
        string ID = textBox_ID.Text;
        string PW = textBox_PW.Text;

        if (ID == "debug")
        {
            switch (PW)
            {
                case "paint":
                    _9_1113.Form_Paint CF_paint = new _9_1113.Form_Paint();
                    this.Hide();
                    CF_paint.ShowDialog();
                    this.Show();
                    break;
                default:
                    MessageBox.Show("접속 실패!\n" + PW + "는 존재하지 않습니다!");
                    textBox_PW.Focus();
                    textBox_PW.Clear();
                    break;

            }
        }
        else if (ID != "abc")
        {
            MessageBox.Show("로그인 실패!\nID가 일치하지 않습니다!");
            textBox_ID.Focus();
            textBox_ID.Clear();
            textBox_PW.Clear();
        }
        else if (PW != "1234")
        {
            MessageBox.Show("로그인 실패!\nPassward가 일치하지 않습니다!");
            textBox_PW.Focus();
            textBox_PW.Clear();
        }
        else
        {
            MessageBox.Show("로그인 성공!");
            _9_1113._9_Form Main = new _9_1113._9_Form();
            this.Hide();
            Main.ShowDialog();
            this.Close();
        }
    }

    private void singUp_button_Click(object sender, EventArgs e)
    {

    }
}
