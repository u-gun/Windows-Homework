using _7_1016_1;
using System.Diagnostics;
using System.Security.Policy;
using static System.Net.Mime.MediaTypeNames;
namespace _8_1030
{
    public partial class _8_Form1 : Form
    {
        public _8_Form1()
        {
            InitializeComponent();
        }
        private void open_7Form_Click(object sender, EventArgs e)
        {
            _7_1016_1._7_Form1 _7_Form1 = new _7_1016_1._7_Form1();
            _7_Form1.Show();
        }
        private void outLine_button_Click(object sender, EventArgs e)
        {
            outLine.Text = "외각선 : " + ((Button)sender).Text;
        }

        private void checkedE(object sender, EventArgs e)
        {

            string selectedFruits = label_fruits.Text;
            string choice = ((CheckBox)sender).Text;
            if (!selectedFruits.Contains(choice) && ((CheckBox)sender).Checked)
            {
                selectedFruits += choice;
                studentLavel.Text = studentLavel.Text.Replace("선호과일: ", "선호과일: " + choice);
            }
            else if (selectedFruits.Contains(choice) && !(((CheckBox)sender).Checked))
            {
                selectedFruits = selectedFruits.Replace(choice, "");
                studentLavel.Text = studentLavel.Text.Replace(choice, "");
            }
            label_fruits.Text = selectedFruits;
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            string selectedClass = label_class.Text;
            string choice = ((RadioButton)sender).Text;
            if (((RadioButton)sender).Checked)
            {
                selectedClass += choice;
                studentLavel.Text = studentLavel.Text.Replace("학년: ", "학년: " + choice);
            }
            else
            {
                selectedClass = selectedClass.Replace(choice, "");
                studentLavel.Text = studentLavel.Text.Replace(choice, "");
            }
            label_class.Text = selectedClass;
        }

        private void radio_department_CheckedChanged(object sender, EventArgs e)
        {
            string selectedDepartment = label_department.Text;
            string choice = ((RadioButton)sender).Text;
            if (((RadioButton)sender).Checked)
            {
                selectedDepartment += choice;
                studentLavel.Text = studentLavel.Text.Replace("학과: ", "학과: " + choice);
            }
            else
            {
                selectedDepartment = selectedDepartment.Replace(choice, "");
                studentLavel.Text = studentLavel.Text.Replace(choice, "");
            }
            label_department.Text = selectedDepartment;
        }


        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel clickedLabel = sender as LinkLabel;
            if (clickedLabel == null) return;
            
            string url = clickedLabel.Text;
            if (string.IsNullOrWhiteSpace(url)) return;

            HandleLinkTarget(url);
        }

        private void HandleLinkTarget(string target)
        {
            try
            {
                // 1. target이 로컬 파일 경로인지 확인 (프로젝트의 실행 경로를 기준으로)
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string fullPath = Path.Combine(baseDir, target);


                if (File.Exists(fullPath))
                {
                    // A. 로컬 파일 경로인 경우:
                    // 해당 파일을 기본 프로그램(메모장 등)으로 엽니다.
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = fullPath,
                        UseShellExecute = true
                    });
                }
                else if (Uri.TryCreate(target, UriKind.Absolute, out Uri uriResult) &&
                         (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                {
                    // B. 유효한 웹 URL인 경우:
                    // 웹 브라우저로 엽니다.
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = target,
                        UseShellExecute = true
                    });
                }
                else
                {
                    // C. 어느 쪽도 아닌 경우 (경로를 찾을 수 없거나 유효한 URL이 아님):
                    MessageBox.Show($"유효한 파일 경로 또는 URL을 찾을 수 없습니다: {target}", "경로 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"실행 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void input_button_Click(object sender, EventArgs e)
        {
            string ID = textBox_ID.Text;
            string PW = textBox_PW.Text;
            textBox_output.Text = "ID: " + ID + "\r\nPW: " + PW;

            if (ID != "jug")
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
            }
        }

        private void button_addClass_Click(object sender, EventArgs e)
        {
            if (textBox_addClass.Text == "")
            {
                MessageBox.Show("과목을 선택하세요!");
                textBox_addClass.Focus();
                return;
            }
            else if (listBox_basket.Items.Contains(textBox_addClass.Text))
            {
                MessageBox.Show("이미 장바구니에 추가한 과목입니다!");
                textBox_addClass.Focus();
                textBox_addClass.SelectAll();
                return;
            }
            else if (textBox_classIndex.Text != "")
            {
                //instert at index
                int index = int.Parse(textBox_classIndex.Text);
                if (index < 0 || index > listBox_basket.Items.Count)
                {
                    MessageBox.Show("올바르지 않은 위치입니다!");
                    textBox_classIndex.Focus();
                    textBox_classIndex.SelectAll();
                    return;
                }
                else
                {
                    listBox_basket.Items.Insert(index, textBox_addClass.Text);
                    textBox_addClass.Clear();
                    textBox_addClass.Focus();
                    return;
                }
            }
            listBox_basket.Items.Add(textBox_addClass.Text);
            textBox_addClass.Clear();
            textBox_addClass.Focus();
        }

        private void button_deleteClass_Click(object sender, EventArgs e)
        {
            if (listBox_basket.SelectedItem != null)
                listBox_basket.Items.Remove(listBox_basket.SelectedItem);
            else if (listBox_basket.Items.Contains(textBox_addClass.Text))
                listBox_basket.Items.Remove(textBox_addClass.Text);
            else
            {
                MessageBox.Show("올바른 과목명을 입력하세요!");
                textBox_addClass.Focus();

            }
            textBox_addClass.Clear();
        }

        private void button_addProfessor_Click(object sender, EventArgs e)
        {
            if (textBox_professor.Text == "")
            {
                MessageBox.Show("교수명을 입력하세요!");
                textBox_professor.Focus();
                return;
            }
            else if (comboBox_professor.Items.Contains(textBox_addClass.Text))
            {
                MessageBox.Show("이미 존제하는 교수님입니다!");
                textBox_professor.Focus();
                textBox_professor.SelectAll();
                return;
            }
            else if (textBox_professorIndex.Text != "")
            {
                //instert at index
                int index = int.Parse(textBox_professorIndex.Text);
                if (index < 0 || index > comboBox_professor.Items.Count)
                {
                    MessageBox.Show("유효하지 않는 위치입니다!");
                    textBox_professor.Focus();
                    textBox_professor.SelectAll();
                    return;
                }
                else
                {
                    comboBox_professor.Items.Insert(index, textBox_professor.Text);
                    textBox_professor.Clear();
                    textBox_professor.Focus();
                    return;
                }
            }
            comboBox_professor.Items.Add(textBox_professor.Text);
            textBox_professor.Clear();
            textBox_professor.Focus();
        }

        private void button_deleteProfessor_Click(object sender, EventArgs e)
        {
            if (comboBox_professor.SelectedItem != null)
                comboBox_professor.Items.Remove(comboBox_professor.SelectedItem);
            else if (comboBox_professor.Items.Contains(textBox_professor.Text))
                comboBox_professor.Items.Remove(textBox_professor.Text);
            else
            {
                MessageBox.Show("올바른 이름을 입력하세요!");
                textBox_professor.Focus();

            }
            textBox_professor.Clear();
        }

        private void button_Rshift_Click(object sender, EventArgs e)
        {
            if (comboBox_professor.SelectedItem != null)
            {
                listBox_basket.Items.Add(comboBox_professor.SelectedItem);
                comboBox_professor.Items.Remove(comboBox_professor.SelectedItem);
            }
            else if (comboBox_professor.Items.Contains(textBox_professor.Text))
            {
                listBox_basket.Items.Add(textBox_professor.Text);
                comboBox_professor.Items.Remove(textBox_professor.Text);
            }
        }
        private void button_Lshift_Click(object sender, EventArgs e)
        {
            //basketfrom professor to comboBox
            if (listBox_basket.SelectedItem != null)
            {
                comboBox_professor.Items.Add(listBox_basket.SelectedItem);
                listBox_basket.Items.Remove(listBox_basket.SelectedItem);
            }
            else if (listBox_basket.Items.Contains(textBox_addClass.Text))
            {
                comboBox_professor.Items.Add(textBox_addClass.Text);
                listBox_basket.Items.Remove(textBox_addClass.Text);
            }
        }

        private void buttonAddSports_Click(object sender, EventArgs e)
        {
            if (textBox_sports.Text == "")
            {
                MessageBox.Show("추가할 스포츠 명칭을 입력하세요!");
                textBox_sports.Focus();
                return;
            }
            else if (checkedListBox_sports.Items.Contains(textBox_addClass.Text))
            {
                MessageBox.Show("이미 존제하는 스포츠입니다!");
                textBox_sports.Focus();
                textBox_sports.SelectAll();
                return;
            }
            checkedListBox_sports.Items.Add(textBox_sports.Text);
            textBox_sports.Clear();
            textBox_sports.Focus();
        }

        private void buttonDeleteSports_Click(object sender, EventArgs e)
        {
            if (checkedListBox_sports.SelectedItem != null)
                checkedListBox_sports.Items.Remove(checkedListBox_sports.SelectedItem);
            else if (checkedListBox_sports.Items.Contains(textBox_sports.Text))
                checkedListBox_sports.Items.Remove(textBox_sports.Text);
            else
            {
                MessageBox.Show("올바른 이름을 입력하세요!");
                textBox_sports.Focus();

            }
            textBox_sports.Clear();
        }
    }
}
