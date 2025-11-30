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
public partial class mouse_application : Form
{
    public mouse_application()
    {
        InitializeComponent();
    }

    // mine game const
    protected const int xNum = 15; // 가로박스 개수
    protected const int yNum = 15; // 세로박스 개수
    protected int cxBlock, cyBlock; // 박스 가로너비, 세로 높이
    protected bool[,] Check = new bool[yNum, xNum]; //체크 여부
    protected bool[,] Mine = new bool[yNum, xNum]; //지뢰 위치 여부

    private bool[,] creatMine()
    {
        bool[,] result = new bool[yNum, xNum];

        Random random = new Random();
        for (int i = 0; i < yNum; i++)
        {
            for (global::System.Int32 j = 0; j < xNum; j++)
            {
                result[i,j] = random.Next(0, 2) == 0;
            }
        }

        return result; 
    }


    private void mouse_application_Load(object sender, EventArgs e)
    {
        mouse_application_Resize(sender, e);
    }

    private void mouse_application_Resize(object sender, EventArgs e)
    {
        cxBlock = ClientSize.Width / xNum;
        cyBlock = (ClientSize.Height - ResetButton.Height) / yNum;
        Invalidate();
    }

    private void mouse_application_MouseUp(object sender, MouseEventArgs e)
    {
        int x = e.X / cxBlock;
        int y = e.Y / cyBlock;



        if (x < cxBlock && y < cyBlock)
        {
            // x < cxBlock && y < cyBlock 연산이 정수로 결과값이 나와 범위를 벋어남에도 true 처리되는 경우가 생김
            // 따라서 Check[x, y] 범위를 벗어난 참조 발생
            if (Mine[x, y])
            {
                // 지뢰 찾음!
            }

            Check[x, y] ^= true;
            Invalidate(new Rectangle(x*cxBlock, y*cyBlock, cxBlock, cyBlock));
        }
    }

    private void mouse_application_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Pen p = new Pen(ForeColor);
        for (int y = 0; y < yNum; y++)
            for (int x = 0; x < xNum; x++)
            {
                g.DrawRectangle(p, x * cxBlock, y * cyBlock, cxBlock, cyBlock);

                if (Check[x, y])
                {
                    g.DrawLine(p, x * cxBlock, y * cyBlock, (x + 1) * cxBlock, (y + 1) * cyBlock);
                    g.DrawLine(p, x * cxBlock, (y + 1) * cyBlock, (x + 1) * cxBlock, y * cyBlock);
                }

            }
    }
}
