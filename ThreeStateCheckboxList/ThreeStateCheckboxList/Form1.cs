using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThreeStateCheckboxList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            TreeNode c1 = new TreeNode();
            TreeNode c2 = new TreeNode();
            TreeNode c3 = new TreeNode();
            TreeNode c4 = new TreeNode();
            TreeNode c5 = new TreeNode();
            TreeNode c6 = new TreeNode();
            MyTreeGroupNode tn = new MyTreeGroupNode();

            c1.Name = "Checkbox 1";
            c2.Name = "Checkbox 2";
            c3.Name = "Checkbox 3";
            c4.Name = "Checkbox 4";
            tn.Name = "Groupnode";
            c5.Name = "Checkbox 5";
            c6.Name = "Checkbox 6";


            tn.Text = "Groupnode";
            c1.Text = c1.Name;
            c2.Text = c2.Name;
            c3.Text = c3.Name;
            c4.Text = c4.Name;
            c5.Text = c5.Name;
            c6.Text = c6.Name;
            this.treeView1.CheckBoxes = true;
            this.treeView1.Nodes.Add(c1);
            this.treeView1.Nodes.Add(c2);
            this.treeView1.Nodes.Add(c3);
            this.treeView1.Nodes.Add(c4);
            tn.Nodes.Add(c5);
            tn.Nodes.Add(c6);
            this.treeView1.Nodes.Add(tn);            

            treeView1.AfterCheck += new TreeViewEventHandler(treeView1_AfterCheck);
        }

        void setChilds(TreeNode t,bool check)
        {
            foreach (TreeNode node in t.Nodes)
            {
                if (node is MyTreeGroupNode)
                {
                    setChilds(node,check);
                }
                node.Checked = check;
            }
        }

        void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown) return;
            if (e.Node is MyTreeGroupNode)
            { //Check/Uncheck childs
                setChilds(e.Node,e.Node.Checked);
                (e.Node as MyTreeGroupNode).setState();
            }
            e.Node.TreeView.Invalidate();
            TreeNode t = e.Node.Parent;
            while (t != null) {
                if (t is MyTreeGroupNode)
                {
                    (t as MyTreeGroupNode).setState();
                    //if (e.Action != TreeViewAction.Unknown)
                        switch ((t as MyTreeGroupNode).state)
                        {
                            case MyTreeGroupNodeStates.Partial:
                            case MyTreeGroupNodeStates.Unchecked:
                                t.Checked = false;
                                break;
                            case MyTreeGroupNodeStates.Checked:
                                t.Checked = true;
                                break;
                        }
                }
                t = t.Parent;
            }
            

            
            
        }
    }
}
