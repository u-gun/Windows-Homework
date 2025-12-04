using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9_1113;
public partial class _12Form : Form
{
    public _12Form()
    {
        InitializeComponent();
    }
    private void _12Form_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        Rectangle[] rects =
        {
            new Rectangle(10, 10, 150, 150),
            new Rectangle(200, 10, 150, 150),
            new Rectangle(390, 10, 150, 150),
            new Rectangle(580, 10, 150, 150),
            new Rectangle(770, 10, 150, 150),

            new Rectangle(10, 200, 150, 150),
            new Rectangle(200, 200, 150, 150),

            new Rectangle(390, 200, 150, 150),
            new Rectangle(580, 200, 150, 150),

            new Rectangle(770, 200, 150, 150),
            new Rectangle(1000, 10, 240, 300),
        };
        g.DrawRectangles(new Pen(Color.BlueViolet), rects);

        SolidBrush brush = new SolidBrush(Color.Linen);
        g.FillRectangle(brush, rects[0]);

        TextureBrush brush_img = new TextureBrush(new Bitmap("C:\\Users\\jug\\Desktop\\윈도우즈 실습\\_9_1113\\Resource\\랩탑불타파덕.jpg"));
        g.FillRectangle(brush_img, rects[1]);

        HatchBrush brush_hatch = new HatchBrush(HatchStyle.Cross, Color.BurlyWood, Color.DeepPink);
        g.FillRectangle(brush_hatch, rects[2]);

        LinearGradientBrush brush_linearGradient = new LinearGradientBrush(new Point(580, 10), new Point(730, 160), Color.Blue, Color.Red);
        g.FillRectangle(brush_linearGradient, rects[3]);


        Point[] pts = { //r5 내의 기준점 3개 사용
            new Point((770+750)/2, 10),
            new Point(770, 10+150),
            new Point(770+150, 10+150)
        };
        PathGradientBrush bruch_pathGradient = new PathGradientBrush(pts);
        g.FillRectangle(bruch_pathGradient, rects[4]); // 사각형을 3방향 흑백 변환으로 채움

        // 정원, 타원 그리기
        g.DrawEllipse(new Pen(Color.Red), rects[5]);
        g.FillEllipse(brush, rects[6]);

        // 호 파이 그리기
        g.DrawArc(new Pen(Color.Red), rects[7], 45, 270);
        g.DrawPie(new Pen(Color.Red), rects[8], 45, 270);


        // 패곡선 그리기
        Point[] pts_CC = {
            new Point(115, 30), new Point(140, 90),
            new Point(200, 115), new Point(140, 140),
            new Point(115, 200), new Point(90, 140),
            new Point(30, 115), new Point(90, 90)
        };
        //g.FillClosedCurve(Brushes.Yellow, pts3);
        g.DrawClosedCurve(Pens.Navy, pts_CC);


        // 글자 그리기
        Font font_KD = new Font("맑은 고딕", 8, FontStyle.Italic);
        Font font_SIN = new Font("신명조", 12);
        g.DrawString("이것은 가장 완벽한 12글자", font_KD, Brushes.Navy, rects[9]);

        // 이미지 그리기
        g.DrawImage(new Bitmap("C:\\Users\\jug\\Desktop\\윈도우즈 실습\\_9_1113\\Resource\\랩탑불타파덕.jpg"), rects[10]);
    }
}
