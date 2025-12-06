using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace _9_1113;
public partial class Form_Paint : Form
{
    public string handleTool = "brush";

    // 선택 영역
    Point selectionStartPoint = new Point();
    Point selectionEndPoint = new Point();

    // board layer
    Bitmap Bitmap = new Bitmap(1920, 1080);
    Pen myPen = new Pen(Color.Black, 5);
    Pen eraserPen = new Pen(Color.White, 5);

    // 조작 플러그
    bool IsDrawing = false;
    bool IsSelecting = false;

    private Point lastPoint; // 이전 마우스 위치 저장
    ColorDialog colorDialog1 = new ColorDialog();
    Color selectedColor = Color.Black;

    // ----------------- [Undo/Redo] ------------------
    private Stack<Bitmap> undoStack = new Stack<Bitmap>();
    private Stack<Bitmap> redoStack = new Stack<Bitmap>();
    // ---------------- [선택/클립보드] ----------------
    private Rectangle selectionRectangle = Rectangle.Empty; // 현재 선택된 영역
    private Bitmap clipboardBitmap = null; // 복사/잘라내기된 이미지 데이터
                                           // ------------------------------------------------

    // ----- 도형 및 텍스트, 드래그 기능을 위한 변수 -----
    private Point shapeStartPoint;
    private Point dragStartPoint;   // 이동 시작 시 마우스 위치
    private bool isDraggingSelection = false; // 현재 선택 영역을 이동 중인지 여부
    private TextBox activeTextBox = null; // 현재 활성화된 텍스트 박스

    public Form_Paint()
    {
        InitializeComponent();
        updateToolView();
        if (Board_PB != null)
        {
            Board_PB.Paint += Board_PB_Paint;
            Board_PB.PreviewKeyDown += Board_PB_PreviewKeyDown;
            Board_PB.Select(); // PictureBox가 키 이벤트를 받도록 포커스 설정
        }

        // --- 펜 속성 초기화 (부드러운 선/브러시 효과) ---
        eraserPen.StartCap = myPen.StartCap = LineCap.Round;
        eraserPen.EndCap = myPen.EndCap = LineCap.Round;
        eraserPen.LineJoin = myPen.LineJoin = LineJoin.Round;


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
        if (clearRedo) redoStack.Clear();

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

    // 화살표 키로 조작
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
            // 이동 중인 이미지가 있다면(cut/paste 상태) 미리보기 그리기
            if (handleTool == "selector_move_paste" && clipboardBitmap != null)
            {
                e.Graphics.DrawImage(clipboardBitmap, selectionRectangle);
            }

            // 점선 스타일 펜 생성
            using (Pen dashedPen = new Pen(Color.Blue, 1))
            {
                dashedPen.DashStyle = DashStyle.Dash;
                e.Graphics.DrawRectangle(dashedPen, selectionRectangle);
            }
        } // 2. 도형 그리기 미리보기 (마우스 드래그 중일 때)
        else if (IsDrawing && (handleTool == "rectangle" || handleTool == "circle" || handleTool == "line"))
        {
            using (Pen previewPen = new Pen(myPen.Color, myPen.Width))
            {
                previewPen.DashStyle = DashStyle.Solid;

                if (handleTool == "line")
                {
                    e.Graphics.DrawLine(previewPen, shapeStartPoint, lastPoint);
                }
                else // 사각형, 원 그리기
                {
                    Rectangle rect = GetNormalizedRectangle(shapeStartPoint, lastPoint);
                    if (handleTool == "rectangle")
                        e.Graphics.DrawRectangle(previewPen, rect);
                    else if (handleTool == "circle")
                        e.Graphics.DrawEllipse(previewPen, rect);
                }
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


    // 도구 버튼들
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
        updateToolView();
    }

    public void selectAll_Click(object sender, EventArgs e)
    {
        if (Bitmap != null)
        {
            selectionRectangle = new Rectangle(0, 0, Bitmap.Width, Bitmap.Height);
            Board_PB.Invalidate();
        }
    }

    private void updateToolView()
    {
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
        updateToolView();
    }

    // brush 두께 조작
    private void brushThicknessComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (brushThicknessComboBox.SelectedItem != null &&
            float.TryParse(brushThicknessComboBox.SelectedItem.ToString(), out float newWidth))
        {
            myPen.Width = newWidth;
            eraserPen.Width = newWidth;
        }
    }

    private void brushThicknessComboBox_LostFocus(object sender, EventArgs e)
    {
        // 사용자가 콤보박스에 직접 타이핑 후 포커스를 잃었을 때 처리
        if (float.TryParse(brushThicknessComboBox.Text, out float customWidth) && customWidth > 0)
        {
            myPen.Width = customWidth;
            eraserPen.Width = customWidth;
        }
        else brushThicknessComboBox.Text = myPen.Width.ToString(); // 유효하지 않은 값이면 현재 두께를 다시 표시
    }

    // 마우스 동작

    private void Board_PB_MouseDown(object sender, MouseEventArgs e)
    {
        if (handleTool == "brush" || handleTool == "eraser")
        {
            IsDrawing = true;
            lastPoint = e.Location; // 브러시 시작 시 이전 마우스 위치 저장

            // 브러시 시작 시 이전에 남아있던 선택 영역은 초기화
            selectionRectangle = Rectangle.Empty;
            Board_PB.Invalidate();
        }
        else if (handleTool == "rectangle" || handleTool == "circle" || handleTool == "line")
        {
            // 도형 그리기 시작
            IsDrawing = true; // 도형 드래그 중임을 표시
            shapeStartPoint = e.Location;
            lastPoint = e.Location; // 현재 위치 저장 (Paint에서 사용)
        }
        else if (handleTool == "textBox")
        {
            // 텍스트 박스 생성
            CreateTextBox(e.Location);
        }
        else if (handleTool.Contains("selector"))
        {
            // 이미 선택된 영역 내부를 클릭했다면 -> 이동 모드 시작
            if (!selectionRectangle.IsEmpty && selectionRectangle.Contains(e.Location))
            {
                // 붙여넣기 모드가 아니라면, 현재 영역을 잘라내어 clipboardBitmap으로 만듦 (이동 준비)
                if (handleTool != "selector_move_paste")
                {
                    SaveState(); // 이동 전 상태 저장
                    CopySelectionToClipboard(); // 현재 영역 복사

                    // 원본 영역 지우기 (흰색 채우기)
                    using (Graphics g = Graphics.FromImage(Bitmap))
                    using (SolidBrush brush = new SolidBrush(Color.White))
                    {
                        g.FillRectangle(brush, selectionRectangle);
                    }

                    handleTool = "selector_move_paste"; // 이동 모드로 변경
                }
                isDraggingSelection = true;
                dragStartPoint = e.Location;
            }
            else
            {
                // 그리기 확정
                if (clipboardBitmap != null && handleTool == "selector_move_paste")
                {
                    PasteToBitmap(); // 현재 selectionRectangle 위치에 이미지를 그림
                    handleTool = "selector"; // 기본 선택 도구로 복귀
                }

                // 새로운 선택 시작
                IsDrawing = false;
                IsSelecting = true;
                selectionStartPoint = e.Location;
                selectionEndPoint = e.Location;
                selectionRectangle = Rectangle.Empty;
            }
        }
        else if (handleTool == "dropper") // 스포이드 기능
        {
            selectedColor = Bitmap.GetPixel(e.X, e.Y);
            selectColorSample.BackColor = selectedColor;
            myPen.Color = selectedColor;

            handleTool = "brush";
        }
        updateToolView();
    }

    private void Board_PB_MouseUp(object sender, MouseEventArgs e)
    {
        if (IsDrawing)
        {
            IsDrawing = false;

            if (handleTool == "rectangle" || handleTool == "circle" || handleTool == "line")
            {
                SaveState(); // Undo 저장
                using (Graphics g = Graphics.FromImage(Bitmap))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    // 선 그리기 확정
                    if (handleTool == "line")
                    {
                        g.DrawLine(myPen, shapeStartPoint, e.Location);
                    }
                    else // 사각형, 원 확정
                    {
                        Rectangle rect = GetNormalizedRectangle(shapeStartPoint, e.Location);
                        if (rect.Width > 0 && rect.Height > 0)
                        {
                            if (handleTool == "rectangle")
                                g.DrawRectangle(myPen, rect);
                            else if (handleTool == "circle")
                                g.DrawEllipse(myPen, rect);
                        }
                    }
                }
                Board_PB.Image = Bitmap;
                Board_PB.Invalidate();
            }
            else
            {
                SaveState(); // 브러시 등 기타 작업 저장
            }
        }
        else if (IsSelecting)
        {
            IsSelecting = false;
            if (selectionRectangle.Width <= 0 || selectionRectangle.Height <= 0)
                selectionRectangle = Rectangle.Empty;
            Board_PB.Invalidate(); // 최종 선택 영역 표시를 위해 갱신
        }
        else if (isDraggingSelection)
        {
            // 드래그 종료 (아직 비트맵에 붙여넣지는 않고, 떠있는 상태 유지)
            isDraggingSelection = false;
        }
    }

    private void Board_PB_MouseMove(object sender, MouseEventArgs e)
    {
        if (IsDrawing)
        {
            if (handleTool == "brush" || handleTool == "eraser")
            {
                // 기존 브러시 로직
                Graphics Grp = Graphics.FromImage(Bitmap);
                if (handleTool == "eraser") Grp.DrawLine(eraserPen, lastPoint, e.Location);
                else Grp.DrawLine(myPen, lastPoint, e.Location);

                lastPoint = e.Location;
                Board_PB.Image = Bitmap;
            }
            else if (handleTool == "rectangle" || handleTool == "circle" || handleTool == "line")
            {
                // 도형 미리보기 (실제 그리기는 Paint 이벤트에서 처리)
                lastPoint = e.Location; // 현재 마우스 위치 업데이트
                Board_PB.Invalidate();  // 화면 갱신 요청 -> Paint 이벤트 발생
            }
        }
        else if (IsSelecting)
        {
            // 선택 영역 드래그 중
            selectionEndPoint = e.Location;
            selectionRectangle = GetNormalizedRectangle(selectionStartPoint, selectionEndPoint);
            Board_PB.Invalidate();
        }
        else if (isDraggingSelection && handleTool == "selector_move_paste")
        {
            // [추가] 선택된 요소(이미지) 드래그 이동
            int dx = e.X - dragStartPoint.X;
            int dy = e.Y - dragStartPoint.Y;

            selectionRectangle.X += dx;
            selectionRectangle.Y += dy;

            dragStartPoint = e.Location; // 기준점 업데이트
            Board_PB.Invalidate(); // 이동된 위치에 다시 그리기 위해 갱신
        }
    }

    private void select_brush_Click(object sender, EventArgs e)
    {
        handleTool = "brush"; updateToolView();
    }

    private void textBox_Click(object sender, EventArgs e)
    {
        handleTool = "textBox"; updateToolView();
    }

    private void element_Click(object sender, EventArgs e)
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
        updateToolView();
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

    // 텍스트 박스 로직들
    // 텍스트 박스 생성
    private void CreateTextBox(Point location)
    {
        if (activeTextBox != null) CommitText(); // 기존 박스가 있으면 확정

        activeTextBox = new TextBox();
        activeTextBox.Location = location;
        activeTextBox.Size = new Size(150, 30); // 기본 크기
        activeTextBox.Font = new Font("Malgun Gothic", 12);
        activeTextBox.ForeColor = myPen.Color; // 현재 펜 색상 적용
        activeTextBox.BorderStyle = BorderStyle.FixedSingle;

        // 엔터키 입력 시 확정 이벤트 연결
        activeTextBox.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Enter)
            {
                CommitText();
                e.SuppressKeyPress = true; // 소리 방지
            }
        };

        Board_PB.Controls.Add(activeTextBox);
        activeTextBox.Focus();
    }

    // 텍스트를 비트맵에 그리기 (확정)
    private void CommitText()
    {
        if (activeTextBox == null) return;

        if (!string.IsNullOrWhiteSpace(activeTextBox.Text))
        {
            SaveState();
            using (Graphics g = Graphics.FromImage(Bitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                using (Brush brush = new SolidBrush(activeTextBox.ForeColor))
                {
                    g.DrawString(activeTextBox.Text, activeTextBox.Font, brush, activeTextBox.Location);
                }
            }
            Board_PB.Image = Bitmap;
            Board_PB.Invalidate();
        }

        // 컨트롤 제거
        Board_PB.Controls.Remove(activeTextBox);
        activeTextBox.Dispose();
        activeTextBox = null;
    }

    private void selectColorSample_Click(object sender, EventArgs e)
    {
        ToolStripItem box = (ToolStripItem)sender;
        myPen.Color = box.BackColor;
    }


    private void PasteToBitmap()
    {
        if (clipboardBitmap == null) return;

        SaveState();
        using (Graphics g = Graphics.FromImage(Bitmap))
        {
            g.DrawImage(clipboardBitmap, selectionRectangle.Location);
        }
        Board_PB.Image = Bitmap;
        Board_PB.Invalidate();
    }

    /// <summary>
    /// 두 점을 사용하여 시작점과 크기가 양수인 Rectangle을 반환합니다.
    /// </summary>
    private Rectangle GetNormalizedRectangle(Point startPoint, Point endPoint)
    {
        return new Rectangle(
            Math.Min(startPoint.X, endPoint.X),
            Math.Min(startPoint.Y, endPoint.Y),
            Math.Abs(startPoint.X - endPoint.X),
            Math.Abs(startPoint.Y - endPoint.Y)
        );
    }

    private void newFile_Click(object sender, EventArgs e)
    {
        if (ask_fileSave()) save_Click(sender, e);

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


    // printer logic
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

    // closer logic
    private void closer_Click(object sender, EventArgs e)
    {
        if (ask_fileSave())
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
        }
        else
        {
            return false;
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

    private void Formcloser_Click(object sender, FormClosedEventArgs e)
    {
        closer_Click(sender, e);
    }

    private void getColoe_Click(object sender, EventArgs e)
    {
        handleTool = "dropper";

        updateToolView();
    }

    private void eraser_Click(object sender, EventArgs e)
    {
        handleTool = "eraser";

        updateToolView();
    }
}