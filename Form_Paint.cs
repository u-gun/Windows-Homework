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
public partial class Form_Paint : Form
{
    public string handleTool = "brush";
    List<Point> selectedPoints = new List<Point>();
    List<RectangleF> rectangleFs = new List<RectangleF>();

    Bitmap Bitmap = new Bitmap(1920, 1080);
    Pen myPen = new Pen(Color.Black, 5);
    bool IsDrawing = false;

    private Stack<Bitmap> undoStack = new Stack<Bitmap>();
    private Stack<Bitmap> redoStack = new Stack<Bitmap>();
    private const int MAX_UNDO_LEVELS = 10; // 최대 Undo 단계

    private Point selectionStartPoint;
    private Point selectionEndPoint;
    private bool IsSelecting = false;
    private Rectangle selectionRectangle = Rectangle.Empty;

    ColorDialog colorDlg = new ColorDialog();
    Color selectedColor = Color.Black;

    private void SaveState()
    {
        // 최대 Undo 단계 제한
        if (undoStack.Count > MAX_UNDO_LEVELS)
        {
            // Stack의 가장 오래된 항목(맨 아래)을 제거합니다.
            // Stack은 직접 제거가 어려우므로, List로 변환하여 처리합니다.
            List<Bitmap> list = undoStack.Reverse().ToList();
            list.RemoveAt(0);
            undoStack = new Stack<Bitmap>(list.Reverse<Bitmap>());
        }

        // 현재 비트맵의 복사본을 저장 (깊은 복사)
        undoStack.Push((Bitmap)Bitmap.Clone());
        redoStack.Clear(); // 새로운 작업이 시작되면 Redo 스택은 초기화
    }

    public void undo_Click(object sender, EventArgs e)
    {
        // 최소한 두 개의 상태가 있어야 함: 초기 상태와 현재 상태
        if (undoStack.Count > 1)
        {
            // 1. 현재 상태를 undoStack에서 제거하고 redoStack에 저장
            Bitmap currentState = undoStack.Pop();
            redoStack.Push(currentState);

            // 2. 이전 상태를 복원
            Bitmap previousState = undoStack.Peek();
            Bitmap = (Bitmap)previousState.Clone();
            Board_PB.Image = Bitmap;
            Board_PB.Invalidate();
        }
    }

    public void redo_Click(object sender, EventArgs e)
    {
        if (redoStack.Count > 0)
        {
            // 1. redoStack에서 다음 상태를 가져옴
            Bitmap nextState = redoStack.Pop();

            // 2. 이 상태를 undoStack에 다시 저장
            undoStack.Push(nextState);

            // 3. 비트맵을 복원
            Bitmap = (Bitmap)nextState.Clone();
            Board_PB.Image = Bitmap;
            Board_PB.Invalidate();
        }
    }

    public Form_Paint()
    {
        InitializeComponent();
        Board_PB.Paint += Board_PB_Paint;

        SaveState();
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

        toolView.Text = "Tool: ";
        toolView.Text = toolView.Text.Replace("Tool: ", "Tool: " + handleTool.ToString());
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

        toolView.Text = "Tool: ";
        toolView.Text = toolView.Text.Replace("Tool: ", "Tool: " + handleTool.ToString());
    }

    private void Board_PB_MouseDown(object sender, MouseEventArgs e)
    {
        if (handleTool == "brush")
        {
            IsDrawing = true;
            // 다른 도구 사용 후 재선택을 위해 선택 영역 초기화
            selectionRectangle = Rectangle.Empty;
            Board_PB.Invalidate();
        }
        else if (handleTool.StartsWith("selector")) // 'selector'로 시작하는 모든 도구
        {
            IsDrawing = false; // 드로잉 상태 비활성화

            // 사각형 선택 로직
            IsSelecting = true;
            selectionStartPoint = e.Location;
            selectionEndPoint = e.Location;
            selectionRectangle = Rectangle.Empty; // 새 선택 시작

            // 기존의 다각형 선택 로직이 있었다면 주석 처리 또는 제거합니다.
            // selectedPoints.Add(e.Location); 
        }
        else
        {
            selectionRectangle = Rectangle.Empty; // 다른 도구 선택 시 선택 영역 초기화
            Board_PB.Invalidate();
        }
    }

    private void Board_PB_MouseUp(object sender, MouseEventArgs e)
    {
        if (IsDrawing)
        {
            IsDrawing = false;
            SaveState(); // 드로잉이 완료되면 상태 저장
        }
        else if (IsSelecting)
        {
            IsSelecting = false;
            // 최종 선택 영역 확정은 MouseMove에서 완료.
            // 선택 영역이 너무 작으면 무시
            if (selectionRectangle.Width <= 0 || selectionRectangle.Height <= 0)
            {
                selectionRectangle = Rectangle.Empty;
            }
            Board_PB.Invalidate(); // 최종 선택 영역 표시를 위해 갱신
        }
    }

    private void Board_PB_MouseMove(object sender, MouseEventArgs e)
    {
        if (IsDrawing)
        {
            Graphics Grp = Graphics.FromImage(Bitmap);
            // 브러시 드로잉 (이전 점과 현재 점 사이에 선을 그리는 것이 더 부드러운 브러시 구현이지만, 기존 코드를 유지)
            Grp.DrawRectangle(myPen, e.X, e.Y, 3, 1);
            Board_PB.Image = Bitmap;
        }
        else if (IsSelecting)
        {
            selectionEndPoint = e.Location;
            // 선택 영역을 계산
            selectionRectangle = new Rectangle(
                Math.Min(selectionStartPoint.X, selectionEndPoint.X),
                Math.Min(selectionStartPoint.Y, selectionEndPoint.Y),
                Math.Abs(selectionStartPoint.X - selectionEndPoint.X),
                Math.Abs(selectionStartPoint.Y - selectionEndPoint.Y)
            );
            Board_PB.Invalidate(); // 선택 영역을 다시 그리기 위해 갱신
        }
    }

    // Form_Paint 클래스에 추가
    private void Board_PB_Paint(object sender, PaintEventArgs e)
    {
        // 선택 도구이고 선택 영역이 유효한 경우에만 점선 그리기
        if (handleTool.StartsWith("selector") && !selectionRectangle.IsEmpty)
        {
            // 점선 스타일 펜 생성 (빨간색 점선으로 표시)
            using (Pen dashedPen = new Pen(Color.Red, 1))
            {
                dashedPen.DashStyle = DashStyle.Dash;
                e.Graphics.DrawRectangle(dashedPen, selectionRectangle);
            }
        }
    }

    private void select_brush_Click(object sender, EventArgs e)
    {
        handleTool = "brush";
        toolView.Text = "Tool: ";
        toolView.Text = toolView.Text.Replace("Tool: ", "Tool: " + handleTool.ToString());
    }


    public void crop_Click(object sender, EventArgs e)
    {
        if (!selectionRectangle.IsEmpty)
        {
            // 1. 잘라내기 작업 전에 현재 상태 저장 (Undo를 위해)
            SaveState();

            try
            {
                // 선택 영역 유효성 검사 및 조정 (캔버스 경계 넘어가지 않도록)
                Rectangle cropRect = selectionRectangle;
                if (cropRect.X < 0) cropRect.X = 0;
                if (cropRect.Y < 0) cropRect.Y = 0;
                if (cropRect.Right > Bitmap.Width) cropRect.Width = Bitmap.Width - cropRect.X;
                if (cropRect.Bottom > Bitmap.Height) cropRect.Height = Bitmap.Height - cropRect.Y;

                // 유효한 영역만 복사
                if (cropRect.Width > 0 && cropRect.Height > 0)
                {
                    Bitmap croppedBitmap = new Bitmap(cropRect.Width, cropRect.Height);
                    using (Graphics g = Graphics.FromImage(croppedBitmap))
                    {
                        // 원본 비트맵의 선택 영역을 새 비트맵의 (0, 0) 위치에 그립니다.
                        g.DrawImage(Bitmap,
                                    new Rectangle(0, 0, cropRect.Width, cropRect.Height),
                                    cropRect,
                                    GraphicsUnit.Pixel);
                    }

                    // 기존 비트맵 해제 및 새 비트맵으로 교체
                    Bitmap.Dispose();
                    Bitmap = croppedBitmap;

                    // PictureBox 크기 조정 (캔버스 크기를 잘린 이미지 크기에 맞춤)
                    Board_PB.Width = Bitmap.Width;
                    Board_PB.Height = Bitmap.Height;
                    Board_PB.Image = Bitmap;

                    // 2. 선택 영역 초기화
                    selectionRectangle = Rectangle.Empty;
                    Board_PB.Invalidate();
                }
                else
                {
                    // 유효하지 않은 선택 영역 (예: 캔버스 밖을 드래그한 경우)
                    undoStack.Pop(); // 직전에 저장한 상태를 취소
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"이미지 자르기 오류: {ex.Message}");
                undoStack.Pop(); // 오류 발생 시 저장한 상태를 취소
            }
        }
    }

    private void textBox_Click(object sender, EventArgs e)
    {
        handleTool = "testBox";
        toolView.Text = "Tool: ";
        toolView.Text = toolView.Text.Replace("Tool: ", "Tool: " + handleTool.ToString());
    }

    private void element_Click(object sender, EventArgs e)
    {
        handleTool = "element";
        toolView.Text = "Tool: ";
        toolView.Text = toolView.Text.Replace("Tool: ", "Tool: " + handleTool.ToString());
    }

    private void fill_Click(object sender, EventArgs e)
    {

    }

    private void Board_PB_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        // 
    }


    private void selectColorSample_Click(object sender, EventArgs e)
    {
        ToolStripMenuItem box = (ToolStripMenuItem)sender;
        myPen.Color = box.BackColor;
    }

    private void element_MouseUp(object sender, MouseEventArgs e)
    {
        if (handleTool == "element")
        {
        }
    }

    public List<Point> GetPolygonCoordinates(IEnumerable<Point> points)
    {
        // 입력받은 IEnumerable<Point> (배열, 리스트 모두 가능)를 List로 변환하여 반환합니다.
        return new List<Point>(points);
    }

    private void DrawMyPolygon(Graphics g)
    {
        Point[] polygonPoints = new Point[]
        {
        new Point(50, 50),
        new Point(150, 50),
        new Point(200, 150),
        new Point(100, 200),
        new Point(0, 150)
        };

        using (Pen blackPen = new Pen(Color.Black, 3))
        {
            // DrawPolygon 메서드는 마지막 꼭짓점에서 첫 번째 꼭짓점으로 자동으로 선을 이어 닫힌 다각형을 만듭니다.
            g.DrawPolygon(blackPen, polygonPoints);
        }
    }

    
    /// <summary>
    /// 두 다각형이 좌표 공간에서 겹치는지 여부를 반환합니다.
    /// </summary>
    /// <param name="polygonA">첫 번째 다각형의 꼭짓점 배열.</param>
    /// <param name="polygonB">두 번째 다각형의 꼭짓점 배열.</param>
    /// <returns>두 다각형이 겹치면 True, 아니면 False.</returns>
    public bool DoPolygonsIntersect(Point[] polygonA, Point[] polygonB)
    {
        // GDI+의 GraphicsPath를 사용하여 다각형 영역을 정의합니다.
        using (GraphicsPath pathA = new GraphicsPath())
        using (GraphicsPath pathB = new GraphicsPath())
        {
            // 다각형 A의 경로를 추가
            if (polygonA.Length >= 3)
                pathA.AddPolygon(polygonA);

            // 다각형 B의 경로를 추가
            if (polygonB.Length >= 3)
                pathB.AddPolygon(polygonB);

            // A의 영역을 나타내는 Region 객체를 만듭니다.
            Region regionA = new Region(pathA);

            // RegionA와 PathB가 교차하는지 확인합니다.
            // IntersectWith() 메서드는 regionA 자체를 변경하므로,
            // 이를 테스트하는 목적으로 사용하기 위해 새로운 Region을 만들어야 합니다.
            // 또는 IsVisible을 사용합니다. 여기서는 GetBounds와 IsVisible을 혼합 사용합니다.

            // 1. 다각형 B의 경계를 사용하여 Region A와 교차하는지 테스트
            RectangleF boundsB = pathB.GetBounds();

            if (regionA.IsVisible(boundsB))
            {
                // 경계 상자가 겹치면 더 정밀하게 확인합니다.
                // B의 꼭짓점 중 하나라도 A 영역 내에 있는지 확인합니다.
                if (polygonB.Any(p => pathA.IsVisible(p)))
                    return true;
            }

            // 2. 다각형 A의 경계를 사용하여 Region B와 교차하는지 테스트
            Region regionB = new Region(pathB);
            RectangleF boundsA = pathA.GetBounds();

            if (regionB.IsVisible(boundsA))
            {
                if (polygonA.Any(p => pathB.IsVisible(p)))
                    return true;
            }

            // 완전한 교차 감지를 위해서는 더 복잡한 SAT(Separating Axis Theorem) 알고리즘이 필요하지만,
            // GDI+를 사용한 이 방법은 간단한 WinForms 환경에서 근사적인 충돌 감지에 유용합니다.

            // 간단한 테스트: A의 바운딩 박스가 B의 바운딩 박스와 겹치는지 확인
            return pathA.GetBounds().IntersectsWith(pathB.GetBounds());
        }
    }
}
