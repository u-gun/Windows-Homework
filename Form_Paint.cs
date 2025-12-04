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
    // 선택자 전역 변수
    private enum selectOptions : int
    {
        point,
        rectangle,
        all,
    }
    public int selectMode = (int)selectOptions.point;
    List<Point> selectedPoints = new List<Point>();
    List<RectangleF> rectangleFs = new List<RectangleF>();

    Bitmap Bitmap = new Bitmap(1920, 1080);

    public Form_Paint()
    {
        InitializeComponent();
    }

    private void panel_board_Paint(object sender, PaintEventArgs e)
    {

    }

    private void panel_board_MouseDown(object sender, MouseEventArgs e)
    {
    }

    private void panel_board_MouseUp(object sender, MouseEventArgs e)
    {

    }

    private void selector_Click(object sender, EventArgs e)
    {
        // 클릭 요소
        ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
        if (clickedItem == null || string.IsNullOrEmpty(clickedItem.Name)) return;

        // name 요소에서 '_' 뒤쪽 문자열 추출해서 enem으로 파싱
        string[] nameParts = clickedItem.Name.ToString().Split('_');
        selectOptions selectIdx = (selectOptions)Enum.Parse(typeof(selectOptions), nameParts[1]);

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
        selectMode = (int)selectIdx;
    }
}
