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
}
