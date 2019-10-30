// Developer Express Code Central Example:
// XtraTreeList: How to save state of checkboxes into the bound data table
// 
// The current example illustrates how to implement storing state of checkboxes
// which are shown in the TreeList. Checkboxes values are stored in the TreeList's
// bound data table.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3069

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraTreeList;
using System.ComponentModel;
using DevExpress.Utils.Serializing;
using DevExpress.XtraTreeList.Nodes;
using System.Data;
using DevExpress.XtraTreeList.Nodes.Operations;

namespace CustomComponent
{
    public class CustomTreeList : TreeList
    {
        string checkedStateFieldName;
        
        public CustomTreeList() : base() { }

        [Description("Gets or sets the data column for storing node's checked state"), Category("Data"), XtraSerializableProperty()]
        public string CheckedStateFieldName 
        {
            get { return checkedStateFieldName; }
            set {
                checkedStateFieldName = value;
                OnCheckedStateFieldNameChanged();
            }
        }

        internal void OnCheckedStateFieldNameChanged()
        { CustomTreeListStoreCheckedStateHelper.SetCheckedState(this); }

        protected override void InternalNodeChanged(DevExpress.XtraTreeList.Nodes.TreeListNode node, NodeChangeTypeEnum changeType)
        {
            if (changeType == NodeChangeTypeEnum.CheckedState)
                CustomTreeListStoreCheckedStateHelper.StoreCheckedState(node);
            base.InternalNodeChanged(node, changeType);
        }
    }

    class CustomTreeListStoreCheckedStateHelper
    {
        public static void StoreCheckedState(TreeListNode node)
        {
            CustomTreeList tl = node.TreeList as CustomTreeList;
            if (tl.CheckedStateFieldName == null || tl.CheckedStateFieldName == "") return;
            (node.TreeList.DataSource as DataTable).Rows[node.Id][tl.CheckedStateFieldName] = node.Checked;
        }

        class CustomNodeOperation : TreeListOperation
        {
            public override void Execute(TreeListNode node)
            {
                node.Checked = (bool)(node.TreeList.DataSource as DataTable).Rows[node.Id][(node.TreeList as CustomTreeList).CheckedStateFieldName];
            }
        }

        public static void SetCheckedState(CustomTreeList tl)
        {
            if (!tl.OptionsView.ShowCheckBoxes || tl.CheckedStateFieldName == null || tl.CheckedStateFieldName == "")
                return;

            tl.NodesIterator.DoOperation(new CustomNodeOperation());
        }
    }
}
