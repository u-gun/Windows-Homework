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
public partial class Form_Paint : Form
{
    public string handleTool = "brush";
    List<Point> selectedPoints = new List<Point>();
    List<RectangleF> rectangleFs = new List<RectangleF>();

    Bitmap Bitmap = new Bitmap(1920, 1080);
    Pen myPen = new Pen(Color.Black, 5);
    bool IsDrawing = false;

    ColorDialog colorDlg = new ColorDialog();
    Color selectedColor = Color.Black;
    public Form_Paint()
    {
        InitializeComponent();
    }

    private void selector_Click(object sender, EventArgs e)
    {
        // 클릭 요소
        ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
        if (clickedItem == null || string.IsNullOrEmpty(clickedItem.Name)) return;

        // 부모 요소
        if (clickedItem.OwnerItem == null) return;
        ToolStripDropDownButton parent = (ToolStripDropDownButton)clickedItem.OwnerItem;

        // 선택했던 요소 해제
        foreach (ToolStripItem item in parent.DropDownItems)
        {
            // 현재 항목이 ToolStripMenuItem이 아니면 다음 항목으로 건너뛰기
            ToolStripMenuItem menuItem = item as ToolStripMenuItem;
            if (menuItem == null) continue;

            menuItem.Checked = false;
        }

        clickedItem.Checked = true;

        parent.Image = clickedItem.Image;

        // 선택 모드 업데이트
        handleTool = clickedItem.Name;
    }

    private void color_selector_Click(object sender, EventArgs e)
    {
        // 대화 상자를 띄우고 사용자가 '확인'을 눌렀는지 확인
        if (colorDlg.ShowDialog() == DialogResult.OK)
        {
            selectedColor = colorDlg.Color;
            selectColorSample.BackColor = selectedColor;
        }
        else
        {
            // 사용자가 '취소'를 누르거나 창을 닫은 경우
            // 특별한 동작 없음
        }
    }

    private void Form_Paint_MouseDown(object sender, MouseEventArgs e)
    {
        if (handleTool == "brush") IsDrawing = true;
        else if (handleTool.Contains("selector"))
        {
            selectedPoints.Add(e.Location);
        }
    }

    private void Board_PB_MouseUp(object sender, MouseEventArgs e)
    {
        IsDrawing = false;

    }

    private void Board_PB_MouseMove(object sender, MouseEventArgs e)
    {
        if (IsDrawing)
        {
            Graphics Grp = Graphics.FromImage(Bitmap);
            Grp.DrawRectangle(myPen, e.X, e.Y, 3, 1);
        }
    }

    private void select_brush_Click(object sender, EventArgs e)
    {
        handleTool = "brush";
    }
}
