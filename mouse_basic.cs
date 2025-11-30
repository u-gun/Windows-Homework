using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9_1113;
public partial class mouse_basic : Form
{
    public mouse_basic()
    {
        InitializeComponent();
    }

    public void MouseStatuseUpdate(string msg, int x, int y, MouseEventArgs e)
    {
        // 시간, 마우스 위치, 클릭한 객체 등 리스트 박스에 삽입
        string mouseData = "";
        string mouseFormat = string.Format("{0}, X:{1}, Y:{2}", msg, x, y);
        mouseData += DateTime.Now.ToShortDateString();
        mouseData += " " + mouseFormat;


        //레이블의 텍스트로 보여줄 문자열(클릭 횟수, 휠, 버튼종류)를 작성
        if (e != null)
        {
            MouseStatuseLavel.Text = string.Format("Clicks:{0}, Delta:{1}," + "Buttons:{2}",
                e.Clicks, e.Delta, e.Button.ToString());
        }
        else MouseStatuseLavel.Text = string.Format("Clicks: {0}, ", 2, msg); // 더블 클릭이면

        MouseStatuseListBox.Items.Insert(0, mouseData);
        MouseStatuseListBox.TopIndex = 0;
    }

    private void MouseStatuseListBox_MouseUp(object sender, MouseEventArgs e)
    {
        MouseStatuseUpdate("(MouseStatuseList)MouseUp", e.X, e.Y, e);
    }

    private void MouseStatuseListBox_Click(object sender, EventArgs e)
    {

    }

    private void MouseStatuseListBox_DoubleClick(object sender, EventArgs e)
    {
        Point mousePos = PointToClient(MousePosition);
        MouseStatuseUpdate("(MouseStatuseList)MouseUp", mousePos.X, mousePos.Y, null);
    }
}
