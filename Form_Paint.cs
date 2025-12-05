using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _9_1113;
public partial class Form_Paint : Form
{
    public string handleTool = "brush";
    Point selectionStartPoint = new Point();
    Point selectionEndPoint = new Point();

    Bitmap Bitmap = new Bitmap(1920, 1080);
    Pen myPen = new Pen(Color.Black, 5);
    bool IsDrawing = false;
    bool IsSelecting = false;

    ColorDialog colorDialog1 = new ColorDialog();
    Color selectedColor = Color.Black;

    // --- [추가된 필드: Undo/Redo 및 선택/클립보드] ---
    private Stack<Bitmap> undoStack = new Stack<Bitmap>();
    private Stack<Bitmap> redoStack = new Stack<Bitmap>();
    private Rectangle selectionRectangle = Rectangle.Empty; // 현재 선택된 영역
    private Bitmap clipboardBitmap = null; // 복사/잘라내기된 이미지 데이터
    // ------------------------------------------------

    public Form_Paint()
    {
        InitializeComponent();

        if (Board_PB != null)
        {
            Board_PB.Paint += Board_PB_Paint;
            Board_PB.PreviewKeyDown += Board_PB_PreviewKeyDown;
            Board_PB.Select(); // PictureBox가 키 이벤트를 받도록 포커스 설정
        }

        // 초기 상태 저장
        SaveState(false);
    }

    // =======================================================
    // Undo/Redo 상태 관리 로직
    // =======================================================

    // 상태 저장 (새로운 변경이 있을 때 호출)
    private void SaveState(bool clearRedo = true)
    {
        if (Bitmap.Width <= 0 || Bitmap.Height <= 0) return;

        // 현재 Bitmap의 복사본을 undoStack에 저장
        undoStack.Push((Bitmap)Bitmap.Clone());

        // 새로운 작업이므로 Redo 스택은 지웁니다.
        if (clearRedo)
        {
            redoStack.Clear();
        }

        // 선택적: 최대 Undo 단계 제한 로직 추가 가능
    }

    // 실행 취소 (Undo) 기능
    public void undo_Click(object sender, EventArgs e)
    {
        // 최소한 두 개의 상태가 있어야 함 (복구할 이전 상태와 현재 상태)
        if (undoStack.Count > 1)
        {
            // 1. 현재 상태를 redoStack에 저장 (다시 실행을 위해)
            redoStack.Push((Bitmap)Bitmap.Clone());

            // 2. undoStack에서 이전 상태를 가져옵니다. (현재 상태는 이미 위에서 저장되었으므로 pop)
            Bitmap currentState = undoStack.Pop();
            Bitmap previousState = undoStack.Peek(); // 직전 상태를 미리 봅니다.

            // 3. 비트맵 복원
            Bitmap = (Bitmap)previousState.Clone(); // 깊은 복사본을 만듭니다.
            Board_PB.Image = Bitmap;
            Board_PB.Invalidate();

            // 주의: Board_PB의 크기도 변경될 수 있으므로, 만약을 위해 크기를 동기화합니다.
            // Board_PB.Width = Bitmap.Width;
            // Board_PB.Height = Bitmap.Height;

            // 다시 저장: Pop한 상태를 다시 넣지 않도록 주의. (Peek & Clone으로 처리)
        }
    }

    // 다시 실행 (Redo) 기능
    public void redo_Click(object sender, EventArgs e)
    {
        if (redoStack.Count > 0)
        {
            // 1. 현재 상태를 undoStack에 저장 (다시 취소할 수 있도록)
            undoStack.Push((Bitmap)Bitmap.Clone());

            // 2. redoStack에서 다음 상태를 가져와 복원
            Bitmap nextState = redoStack.Pop();
            Bitmap = nextState; // 참조 변경
            Board_PB.Image = Bitmap;
            Board_PB.Invalidate();
        }
    }

    // =======================================================
    // 선택 영역/키보드 조작 로직
    // =======================================================

    // 선택 영역 이동 (키보드 이벤트에서 호출)
    private void MoveSelection(int dx, int dy)
    {
        if (selectionRectangle != Rectangle.Empty)
        {
            // selectionRectangle은 구조체이므로, 변경을 적용하려면 재할당해야 합니다.
            Rectangle newRect = selectionRectangle;
            newRect.X += dx;
            newRect.Y += dy;

            // 캔버스 경계를 넘어가지 않도록 조정
            newRect.X = Math.Max(0, Math.Min(newRect.X, Board_PB.Width - newRect.Width));
            newRect.Y = Math.Max(0, Math.Min(newRect.Y, Board_PB.Height - newRect.Height));

            selectionRectangle = newRect;
            Board_PB.Invalidate(); // 변경된 영역 다시 그리기
        }
    }

    private void Board_PB_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        const int moveStep = 5; // 이동 단위

        // 선택 도구(selector_rectangle, selector_move_paste 등)이 활성화되어 있고,
        // 유효한 선택 영역이 있을 때만 키보드 이동을 처리합니다.
        if (handleTool.Contains("selector") && selectionRectangle != Rectangle.Empty)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    MoveSelection(-moveStep, 0);
                    e.IsInputKey = true;
                    break;
                case Keys.Right:
                    MoveSelection(moveStep, 0);
                    e.IsInputKey = true;
                    break;
                case Keys.Up:
                    MoveSelection(0, -moveStep);
                    e.IsInputKey = true;
                    break;
                case Keys.Down:
                    MoveSelection(0, moveStep);
                    e.IsInputKey = true;
                    break;
            }
        }
    }

    // Board_PB에 그림을 다시 그릴 때 호출됨 (선택 영역 점선 표시)
    private void Board_PB_Paint(object sender, PaintEventArgs e)
    {
        // 선택 도구이거나 붙여넣기 모드이고 선택 영역이 유효한 경우에만 점선 그리기
        if ((handleTool.Contains("selector") || handleTool == "move_paste") && !selectionRectangle.IsEmpty)
        {
            // 점선 스타일 펜 생성 (빨간색 점선으로 표시)
            using (Pen dashedPen = new Pen(Color.Red, 1))
            {
                dashedPen.DashStyle = DashStyle.Dash;
                e.Graphics.DrawRectangle(dashedPen, selectionRectangle);
            }
        }
    }

    // =======================================================
    // 복사/잘라내기/붙여넣기 로직
    // =======================================================

    private void CopySelectionToClipboard()
    {
        if (selectionRectangle.IsEmpty) return;

        Rectangle rect = selectionRectangle;

        // 원본 Bitmap의 유효한 영역만 복사합니다.
        Rectangle sourceRect = new Rectangle(
            Math.Max(0, rect.X),
            Math.Max(0, rect.Y),
            Math.Min(rect.Width, Bitmap.Width - Math.Max(0, rect.X)),
            Math.Min(rect.Height, Bitmap.Height - Math.Max(0, rect.Y))
        );

        if (sourceRect.Width > 0 && sourceRect.Height > 0)
        {
            // 기존 클립보드 비트맵 해제 및 새 비트맵 생성
            if (clipboardBitmap != null) clipboardBitmap.Dispose();
            clipboardBitmap = new Bitmap(sourceRect.Width, sourceRect.Height);

            using (Graphics g = Graphics.FromImage(clipboardBitmap))
            {
                // 원본 비트맵의 유효한 영역을 클립보드 비트맵의 (0, 0) 위치에 그립니다.
                g.DrawImage(Bitmap,
                            new Rectangle(0, 0, sourceRect.Width, sourceRect.Height),
                            sourceRect,
                            GraphicsUnit.Pixel);
            }
        }
        else
        {
            // 유효하지 않은 선택 영역 (예: 캔버스 밖)
            if (clipboardBitmap != null) clipboardBitmap.Dispose();
            clipboardBitmap = null;
        }
    }

    // 메뉴/툴바 이벤트 핸들러: 복사
    public void copy_Click(object sender, EventArgs e)
    {
        CopySelectionToClipboard();
        handleTool = "selector"; // 복사 후에도 선택 모드 유지
        toolView.Text = "Tool: " + handleTool;
    }

    // 메뉴/툴바 이벤트 핸들러: 잘라내기
    public void cut_Click(object sender, EventArgs e)
    {
        if (selectionRectangle.IsEmpty) return;

        CopySelectionToClipboard(); // 1. 복사

        // 2. 잘라내기 (선택 영역을 흰색으로 채우기)
        SaveState(); // 잘라내기 전 상태 저장

        Rectangle rect = selectionRectangle;

        using (Graphics g = Graphics.FromImage(Bitmap))
        {
            // 배경색(흰색)으로 채웁니다.
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                g.FillRectangle(brush, rect);
            }
        }

        Board_PB.Image = Bitmap;
        Board_PB.Invalidate();

        // 3. 잘라내기 후 선택 영역은 유지하고 붙여넣기 모드로 전환
        handleTool = "selector_move_paste";
        toolView.Text = "Tool: " + handleTool + " (Ready to Paste)";
    }

    // 메뉴/툴바 이벤트 핸들러: 붙여넣기
    public void paste_Click(object sender, EventArgs e)
    {
        if (clipboardBitmap == null)
        {
            MessageBox.Show("클립보드에 붙여넣을 이미지가 없습니다.", "알림");
            return;
        }

        SaveState(); // 붙여넣기 전 상태 저장

        // 붙여넣기할 위치와 크기 설정
        if (selectionRectangle.IsEmpty)
        {
            // 선택 영역이 없으면 (0, 0)에 붙여넣습니다.
            selectionRectangle = new Rectangle(0, 0, clipboardBitmap.Width, clipboardBitmap.Height);
        }
        else
        {
            // 기존 선택 영역의 위치를 유지하고 크기만 클립보드 이미지에 맞춥니다.
            selectionRectangle.Width = clipboardBitmap.Width;
            selectionRectangle.Height = clipboardBitmap.Height;
        }

        // Bitmap에 이미지 붙여넣기
        using (Graphics g = Graphics.FromImage(Bitmap))
        {
            g.DrawImage(clipboardBitmap, selectionRectangle.Location);
        }

        Board_PB.Image = Bitmap;
        Board_PB.Invalidate();

        // 붙여넣기 후에는 선택 영역 이동 모드로 유지
        handleTool = "selector_move_paste";
        toolView.Text = "Tool: " + handleTool + " (Move to Place)";
    }


    // =======================================================
    // [4] 기존 이벤트 핸들러 수정
    // =======================================================

    // (기존 selector_Click, color_selector_Click, select_brush_Click, textBox_Click, element_Click, fill_Click은 유지)

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
        if (colorDialog1.ShowDialog() == DialogResult.OK)
        {
            selectedColor = colorDialog1.Color;
            selectColorSample.BackColor = selectedColor;
            myPen.Color = selectedColor; // 펜 색상도 업데이트
        }
        // ... (이후 로직은 그대로)
        toolView.Text = "Tool: ";
        toolView.Text = toolView.Text.Replace("Tool: ", "Tool: " + handleTool.ToString());
    }

    private void Board_PB_MouseDown(object sender, MouseEventArgs e)
    {
        if (handleTool == "brush")
        {
            IsDrawing = true;
            // 브러시 시작 시 이전에 남아있던 선택 영역은 초기화
            selectionRectangle = Rectangle.Empty;
            Board_PB.Invalidate();
        }
        else if (handleTool.Contains("selector"))
        {
            // 선택 도구로 새로운 선택을 시작할 때
            IsDrawing = false;
            IsSelecting = true;
            selectionStartPoint = e.Location;
            selectionEndPoint = e.Location;
            selectionRectangle = Rectangle.Empty;
        }
        // 붙여넣기 모드에서 마우스 다운을 처리하여 이동/재배치 기능을 구현할 수 있습니다.
        else if (handleTool == "selector_move_paste" && selectionRectangle.Contains(e.Location))
        {
            // TODO: 마우스 다운 시 붙여넣기된 이미지 이동 시작 로직 추가 (선택 사항)
        }
    }

    private void Board_PB_MouseUp(object sender, MouseEventArgs e)
    {
        if (IsDrawing)
        {
            IsDrawing = false;
            SaveState(); // 드로잉 완료 후 상태 저장
        }
        else if (IsSelecting)
        {
            IsSelecting = false;
            // 최종 선택 영역 확정은 MouseMove에서 완료됨
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
        // TODO: 붙여넣기 모드에서 마우스 이동을 처리하여 이미지 드래그 이동 로직 추가 가능
    }

    private void select_brush_Click(object sender, EventArgs e)
    {
        handleTool = "brush";
        toolView.Text = "Tool: ";
        toolView.Text = toolView.Text.Replace("Tool: ", "Tool: " + handleTool.ToString());
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

    public void fillSelection_Click(object sender, EventArgs e)
    {
        // 1. 유효성 검사: 선택 영역이 유효하고 Bitmap이 존재하는지 확인
        if (selectionRectangle.IsEmpty || Bitmap == null)
        {
            MessageBox.Show("먼저 채우기할 영역을 선택하거나, 새 파일을 만드세요.", "알림");
            return;
        }

        // 2. Undo를 위해 현재 상태 저장
        SaveState();

        try
        {
            using (Graphics g = Graphics.FromImage(Bitmap))
            {
                using (SolidBrush brush = new SolidBrush(selectedColor))
                {
                    g.FillRectangle(brush, selectionRectangle);
                }
            }

            // 4. 화면 갱신
            Board_PB.Image = Bitmap;
            Board_PB.Invalidate();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"영역 채우기 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // 오류가 발생했으므로, 직전에 저장한 상태를 취소하여 Undo 스택을 정리
            if (undoStack.Count > 0) undoStack.Pop();
        }
    }

    private void selectColorSample_Click(object sender, EventArgs e)
    {
        ToolStripItem box = (ToolStripItem)sender;
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

    private void newFile_Click(object sender, EventArgs e)
    {
        if(ask_fileSave()) save_Click(sender, e);

        // 기존 비트맵 리소스 해제 (메모리 누수 방지)
        if (Bitmap != null) Bitmap.Dispose();

        // 새 비트맵(캔버스) 생성 및 흰색으로 초기화
        // 너비와 높이는 필요에 따라 Form 크기 또는 사용자 지정 값으로 설정할 수 있습니다.
        int width = 1920;
        int height = 1080;
        Bitmap = new Bitmap(width, height);

        using (Graphics g = Graphics.FromImage(Bitmap))
        {
            // 캔버스를 흰색으로 채웁니다.
            g.Clear(Color.White);
        }

        // 3. PictureBox에 새 비트맵 설정 및 크기 조정
        Board_PB.Image = Bitmap;
        Board_PB.Width = width;
        Board_PB.Height = height;

        // 4. Undo/Redo 기록 초기화 및 초기 상태 저장
        undoStack.Clear();
        redoStack.Clear();
        SaveState(false); // 새 파일의 빈 상태를 첫 번째 Undo 상태로 저장합니다.

        // 5. 선택 영역 초기화 및 화면 갱신
        selectionRectangle = Rectangle.Empty;
        Board_PB.Invalidate();

        toolView.Text = "Tool: brush"; // 기본 도구로 초기화
    }

    public void open_Click(object sender, EventArgs e)
    {
        // 파일 대화 상자 속성 설정
        openDlg.Filter = "이미지 파일 (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp|모든 파일 (*.*)|*.*";

        if (openDlg.ShowDialog() == DialogResult.OK)
        {
            try
            {
                // 1. 기존 비트맵 리소스 해제
                Bitmap.Dispose();

                // 2. 새 이미지 파일로부터 비트맵 생성 및 로드
                // Bitmap 생성 시 lock 문제가 발생할 수 있으므로, Image.FromFile로 로드 후 Bitmap으로 변환합니다.
                using (Image img = Image.FromFile(openDlg.FileName))
                {
                    Bitmap = new Bitmap(img);
                }

                // 3. PictureBox 및 상태 업데이트
                Board_PB.Image = Bitmap;
                Board_PB.Width = Bitmap.Width;
                Board_PB.Height = Bitmap.Height;

                // 4. 새 이미지로 상태를 초기화하고 Undo/Redo 스택을 초기화
                undoStack.Clear();
                redoStack.Clear();
                SaveState(false); // 새로운 이미지이므로 Redo 클리어는 false로 호출해도 무방함.

                Board_PB.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"파일 열기 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
    {
        // 인쇄 영역의 크기와 위치를 설정합니다.
        // 여기서는 용지 여백을 고려하여 최대한 크게 이미지를 출력하도록 조정합니다.

        int x = e.MarginBounds.X;
        int y = e.MarginBounds.Y;
        int width = e.MarginBounds.Width;
        int height = e.MarginBounds.Height;

        // 가로/세로 비율을 유지하며 용지에 맞게 이미지 크기 조정
        float ratio = Math.Min((float)width / Bitmap.Width, (float)height / Bitmap.Height);
        int newWidth = (int)(Bitmap.Width * ratio);
        int newHeight = (int)(Bitmap.Height * ratio);

        // 이미지를 페이지 중앙에 배치
        int startX = x + (width - newWidth) / 2;
        int startY = y + (height - newHeight) / 2;

        // Graphics 객체를 사용하여 Bitmap을 인쇄 페이지에 그립니다.
        e.Graphics.DrawImage(Bitmap, startX, startY, newWidth, newHeight);

        // 다음 페이지가 없음을 알립니다. (단일 이미지 인쇄)
        e.HasMorePages = false;
    }

    private void FilePrint_Click(object sender, EventArgs e)
    {
        if (Bitmap == null)
        {
            MessageBox.Show("인쇄할 이미지가 없습니다.", "알림");
            return;
        }

        // PrintDialog에 PrintDocument를 연결
        printDlg.Document = printDoc;

        // 인쇄 대화 상자 표시
        if (printDlg.ShowDialog() == DialogResult.OK)
        {
            try
            {
                // 사용자가 '확인'을 누르면 인쇄 시작 (PrintPage 이벤트가 발생합니다)
                printDoc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"인쇄 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void FilePrintPreview_Click(object sender, EventArgs e)
    {
        if (Bitmap == null)
        {
            MessageBox.Show("인쇄할 이미지가 없습니다.", "알림");
            return;
        }

        // PrintPreviewDialog에 PrintDocument를 연결
        printPreviewDlg.Document = printDoc;

        try
        {
            // 인쇄 미리보기 대화 상자 표시
            printPreviewDlg.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"인쇄 미리보기 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void 종료XToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if(ask_fileSave())
        {
            save_Click(sender, e);
        }
        this.Close();
    }

    private bool ask_fileSave()
    {
        if (MessageBox.Show("현재 파일을 저장하시겠습니까?", "확인",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        {
            return true;
        } else
        {
            return false;
        }
    }


    public void selectAll_Click(object sender, EventArgs e)
    {
        if (Bitmap != null)
        {
            selectionRectangle = new Rectangle(0, 0, Bitmap.Width, Bitmap.Height);

            // 도구 모드를 선택 모드로 유지합니다. (필요하다면 "selector"와 같은 적절한 이름으로 설정)
            // handleTool = "selector"; 
            // toolView.Text = "Tool: " + handleTool; // UI 업데이트

            Board_PB.Invalidate();
        }
    }


    public void save_Click(object sender, EventArgs e)
    {
        // 파일 대화 상자 속성 설정
        saveDlg.Filter = "PNG 파일 (*.png)|*.png|JPEG 파일 (*.jpg)|*.jpg|Bitmap 파일 (*.bmp)|*.bmp|모든 파일 (*.*)|*.*";
        saveDlg.FileName = "새 그림"; // 기본 파일 이름 설정

        if (saveDlg.ShowDialog() == DialogResult.OK)
        {
            try
            {
                // 선택된 파일 이름과 확장자를 가져옵니다.
                string fileName = saveDlg.FileName;
                ImageFormat format = ImageFormat.Png;

                // 파일 확장자에 따라 저장 포맷을 결정합니다.
                string ext = System.IO.Path.GetExtension(fileName).ToLower();

                switch (ext)
                {
                    case ".jpg":
                    case ".jpeg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                    case ".png":
                    default:
                        format = ImageFormat.Png;
                        break;
                }

                // Bitmap 저장
                Bitmap.Save(fileName, format);
                MessageBox.Show($"파일 저장 완료: {fileName}", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"파일 저장 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}