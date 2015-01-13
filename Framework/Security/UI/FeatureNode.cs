using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.AdvTree;
using Framework.Security;
using DevComponents.DotNetBar;

namespace Framework.Security.UI
{
    internal class FeatureNode
    {
        public static int IndexExecute = 3;
        public static int IndexView = 1;
        public static int IndexEdit = 2;
        public static int IndexNone = 4;

        public FeatureNode(FeatureItem feature)
        {
            Node n = new Node();
            n.Cells.Clear();

            Cell c1 = new Cell();
            //c1.Text = string.Format("{1}({0})", feature.Code, feature.Title);
            c1.Text = string.Format("{0}", feature.Title);
            n.Cells.Add(c1);

            if (feature is RibbonFeature || feature is ReportFeature)
                CreateCells(feature, n, false, false, true, true, false);
            else if (feature is DetailItemFeature)
                CreateCells(feature, n, true, true, false, true, false);
            else if (feature is CustomeFeature)
                CreateCells(feature, n, false, false, false, false, true);
            else
                throw new ArgumentException("不支援此種的 FeatureItem。");

            n.Tag = this;
            TreeNode = n;
            FeatureItem = feature;
        }

        public Node TreeNode { get; private set; }

        public FeatureItem FeatureItem { get; private set; }

        public void CheckExecute()
        {
            if (TreeNode.Cells[IndexExecute].CheckBoxVisible)
                TreeNode.Cells[IndexExecute].Checked = true;
        }

        public void CheckView()
        {
            if (TreeNode.Cells[IndexView].CheckBoxVisible)
                TreeNode.Cells[IndexView].Checked = true;
        }

        public void CheckEdit()
        {
            if (TreeNode.Cells[IndexEdit].CheckBoxVisible)
                TreeNode.Cells[IndexEdit].Checked = true;
        }

        public void CheckNone()
        {
            if (TreeNode.Cells[IndexNone].CheckBoxVisible)
                TreeNode.Cells[IndexNone].Checked = true;
        }

        public void SetPermission(string permissionString)
        {
            string perm = permissionString.ToLower();

            if (FeatureItem is DetailItemFeature || FeatureItem is RibbonFeature || FeatureItem is ReportFeature)
            {
                if (perm == "execute")
                    CheckExecute();
                else if (perm == "view")
                    CheckView();
                else if (perm == "edit")
                    CheckEdit();
                else
                    CheckNone();
            }
            else
            {
                foreach (Cell each in TreeNode.Cells)
                    each.Checked = false;

                FeatureItem.Editor.PermissionString = permissionString;
            }
        }

        public string GetPermission()
        {
            if (FeatureItem is DetailItemFeature || FeatureItem is RibbonFeature || FeatureItem is ReportFeature)
            {
                if (TreeNode.Cells[IndexExecute].Checked)
                    return "Execute";
                else if (TreeNode.Cells[IndexView].Checked)
                    return "View";
                else if (TreeNode.Cells[IndexEdit].Checked)
                    return "Edit";
                else
                    return "None";
            }
            else
                return FeatureItem.Editor.PermissionString;
        }

        private static void CreateCells(FeatureItem item, Node n, bool c1, bool c2, bool c3, bool c4, bool c5)
        {
            Cell cell = new Cell();
            cell.CheckBoxVisible = c1;
            cell.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            n.Cells.Add(cell);

            cell = new Cell();
            cell.CheckBoxVisible = c2;
            cell.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            n.Cells.Add(cell);

            cell = new Cell();
            cell.CheckBoxVisible = c3;
            cell.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            n.Cells.Add(cell);

            cell = new Cell();
            cell.CheckBoxVisible = c4;
            cell.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            n.Cells.Add(cell);

            cell = new Cell();
            if (c5)
            {
                ButtonX x = new ButtonX();
                x.Text = "設定";
                x.Tag = item;
                x.Click += new EventHandler(x_Click);
                cell.HostedControl = x;
            }
            n.Cells.Add(cell);
        }

        static void x_Click(object sender, EventArgs e)
        {
            ButtonX x = sender as ButtonX;
            FeatureItem item = x.Tag as FeatureItem;

            item.Editor.ShowEditor();
        }
    }
}
