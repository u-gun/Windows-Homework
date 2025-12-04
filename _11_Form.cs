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
public partial class _11_Form : Form
{
    int tickCount = 0;

    public _11_Form()
    {
        InitializeComponent();
        treeView1.ExpandAll();
    }

    private void radioButton_view_CheckedChanged(object sender, EventArgs e)
    {
        string choice = ((RadioButton)sender).Text;
        choice = choice.Replace("radioButton_", "");
        if (((RadioButton)sender).Checked)
        {
            switch (choice)
            {
                case "LargeIcon": listView1.View = View.LargeIcon; break;
                case "SmallIcon": listView1.View = View.SmallIcon; break;
                case "List": listView1.View = View.List; break;
                case "Tile": listView1.View = View.Tile; break;
                case "Details": listView1.View = View.Details; break;
            }
        }
    }

    private void comboBox_view_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (comboBox_view.SelectedIndex)
        {
            case 0: listView1.View = View.LargeIcon; break;
            case 1: listView1.View = View.SmallIcon; break;
            case 2: listView1.View = View.List; break;
            case 3: listView1.View = View.Tile; break;
            case 4: listView1.View = View.Details; break;
        }
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string str = "";
        foreach (ListViewItem i in listView1.SelectedItems)
        { //리스트뷰 아이템의 서브아이템 콜렉션 타입의 객체에게 선택한 아이템 저장
            ListViewItem.ListViewSubItemCollection sub = i.SubItems;
            // 서브아이템 정보는 배열로 저장되었으므로 각각 추출
            str = str + sub[0].Text + ", " + sub[1].Text + ", " + sub[2].Text + ", " + sub[3].Text
            + ", " + sub[4].Text + ", " + "\r\n";
        }
        label_nation.Text = str;
    }

    private void button_insert_Click(object sender, EventArgs e)
    {
        if (textBox_tree.Text != "" && treeView1.SelectedNode != null)
        {
            treeView1.SelectedNode.Nodes.Add(textBox_tree.Text);
            textBox_tree.Text = ""; textBox_tree.Focus();
            return;
        }
    }

    private void button_delete_Click(object sender, EventArgs e)
    {
        if (treeView1.SelectedNode != null)
        {
            treeView1.Nodes.Remove(treeView1.SelectedNode);
            return;
        }
    }

    private void button_insert_class_in_treeView_Click(object sender, EventArgs e)
    {
        if ((treeView1.SelectedNode != null) && (domainUpDown_class.SelectedItem != null))
        {
            treeView1.SelectedNode.Nodes.Add(domainUpDown_class.SelectedItem.ToString());
            return;
        }
    }

    private void numericUpDown_Calculator_ValueChanged(object sender, EventArgs e)
    {
        double value = (double)numericUpDown_Calculator.Value;
        C_result_log.Text = Math.Log10(value).ToString();
        C_result_SQR.Text = Math.Pow(value, 2).ToString();
        C_result_SQRT.Text = Math.Sqrt(value).ToString();
        trackBar_calculator.Value = (int)value;
    }

    private void trackBar_calculator_Scroll(object sender, EventArgs e)
    {
        numericUpDown_Calculator.Value = trackBar_calculator.Value;
    }

    private void timer_frame_Tick(object sender, EventArgs e)
    {
        tickCount++;
        label_weightlifting.Image = imageList_weightlifting.Images[tickCount % 4];
        label_golf.Image = imageList_golf.Images[tickCount % 15];
        label_tenis.Image = imageList_tenis.Images[tickCount % 20];

    }
}
