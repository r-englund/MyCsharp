using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThreeStateCheckboxList
{
    class MyTreeGroupNode : TreeNode
    {

      
        public MyTreeGroupNodeStates state = MyTreeGroupNodeStates.Unchecked;

        public MyTreeGroupNode()
        {
        }

        public void setState()
        {
            int c = 0;
            int u = 0;
            foreach(TreeNode t in this.Nodes){
                if(t is MyTreeGroupNode){
                    switch((t as MyTreeGroupNode).state){
                        case MyTreeGroupNodeStates.Partial:
                            this.state = MyTreeGroupNodeStates.Partial;
                            return;
                        case MyTreeGroupNodeStates.Checked:
                            c++;
                            break;
                        case MyTreeGroupNodeStates.Unchecked:
                            u++;
                            break;
                    }
                }
                else
                {
                    if (t.Checked) c++;
                    else u++;
                }
                
            }
            if (c == 0)
            {
                this.state = MyTreeGroupNodeStates.Unchecked;
            }
            else if (c == 0)
            {
                this.state = MyTreeGroupNodeStates.Unchecked;
            }
            else if (c != 0 && u != 0)
            {
                this.state = MyTreeGroupNodeStates.Partial;
            }
            else if (c != 0 && u == 0)
            {
                this.state = MyTreeGroupNodeStates.Checked;
            }
        }
    }

    enum MyTreeGroupNodeStates
    {
        Unchecked,
        Checked,
        Partial
    }
}
