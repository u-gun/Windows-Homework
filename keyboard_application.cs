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
public partial class keyboard_application : Form
{
    public keyboard_application()
    {
        InitializeComponent();
    }

    public int xPt, yPt; // 버튼의 좌표값 저장하는 포인트 객체
    public static readonly int MOVE = 20; // 이동거리 20포인트

    private void showKeypress_KeyUp(object sender, KeyEventArgs e)
    {
        this.xPt = this.showKeypress.Location.X; // 버튼 꼭지점의 x 좌표
        this.yPt = this.showKeypress.Location.Y; // 버튼 꼭지점의 y 좌표
        switch (e.KeyCode)
        { // 입력 키가 방향키일 경우에는 버튼 이동
            case Keys.Left: xPt -= MOVE; break; // 왼쪽 이동
            case Keys.Right: xPt += MOVE; break; // 오른쪽 이동
            case Keys.Up: yPt -= MOVE; break; // 위쪽 이동
            case Keys.Down: yPt += MOVE; break; // 아래쪽 이동
        }
        // 방향키가 아닐 경우, 키 값을 버튼에 표시
        this.showKeypress.Text = e.KeyCode.ToString(); // 키 코드를 버튼에 표시
        this.showKeypress.Location = new Point(xPt, yPt); // 버튼 꼭지점 좌표 셋팅

        DateTime timeNow = DateTime.Now;
        textBox_timeNow.Text = timeNow.ToString();
    }
}
