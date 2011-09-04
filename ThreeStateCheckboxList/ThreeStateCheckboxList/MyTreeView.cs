using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ThreeStateCheckboxList
{
    class MyTreeView : System.Windows.Forms.TreeView
    {

        public MyTreeView()
        {
            this.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
        }

        protected override void OnDrawNode(System.Windows.Forms.DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;
            base.OnDrawNode(e);
            if (e.Node is MyTreeGroupNode) if ((e.Node as MyTreeGroupNode).state == MyTreeGroupNodeStates.Partial)
            {
                Console.Out.WriteLine("sdfsdfgskdfhgskjdhfjdhsfgkjhsdfg");
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
                e.Graphics.FillRectangle(myBrush, new Rectangle(e.Node.Bounds.X - 12, e.Node.Bounds.Y+4, 9, 9));
            }
        }
    }
}
