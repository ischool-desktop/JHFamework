using System;
using System.Collections.Generic;
using System.Text;
using DevComponents.AdvTree;
using Framework.Security;
using DevComponents.DotNetBar;
using System.Windows.Forms;

namespace Framework.Security.UI
{
    internal class RolePermissionProxy
    {
        public static int IndexExecute = 2;
        public static int IndexView = 0;
        public static int IndexEdit = 1;
        public static int IndexNone = 3;

        private AdvTree AT { get; set; }

        private Dictionary<string, FeatureNode> FeatureNodes { get; set; }

        private List<CatalogNode> CatalogNodes { get; set; }

        private ConfigData Preference { get; set; }

        private ButtonItem Menu { get; set; }

        /// <summary>
        /// 暫止 PermissionChanged 事件的發生。
        /// </summary>
        private bool BlockChangedEvent { get; set; }

        public RolePermissionProxy(AdvTree permissionTree)
        {
            AT = permissionTree;
            AT.AfterExpand += new AdvTreeNodeEventHandler(AT_AfterExpand);
            AT.AfterCollapse += new AdvTreeNodeEventHandler(AT_AfterCollapse);
            AT.AfterCheck += new AdvTreeCellEventHandler(AT_AfterCheck);
            AT.KeyDown += new System.Windows.Forms.KeyEventHandler(AT_KeyDown);
            Preference = null;
            BlockChangedEvent = false;
        }

        public RolePermissionProxy(AdvTree permissionTree, ConfigData preference)
            : this(permissionTree)
        {
            Preference = preference;
        }

        public RolePermissionProxy(AdvTree permissionTree, ConfigData preference, ButtonItem menu)
            : this(permissionTree, preference)
        {
            Menu = menu;
            Menu.PopupOpen += new DotNetBarManager.PopupOpenEventHandler(Menu_PopupOpen);
            Menu.SubItems[IndexView].Click += new EventHandler(Menu_Click);
            Menu.SubItems[IndexEdit].Click += new EventHandler(Menu_Click);
            Menu.SubItems[IndexExecute].Click += new EventHandler(Menu_Click);
            Menu.SubItems[IndexNone].Click += new EventHandler(Menu_Click);
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            BaseItem item = sender as BaseItem;
            string permission = item.Tag.ToString().ToLower();

            foreach (Node each in AT.SelectedNodes)
                SetPermission(permission, each);
        }

        private static void SetPermission(string permission, Node each)
        {
            if (each.Tag is FeatureNode)
            {
                FeatureNode fn = each.Tag as FeatureNode;

                if (permission == "none")
                    fn.CheckNone();
                else if (permission == "execute")
                    fn.CheckExecute();
                else if (permission == "view")
                    fn.CheckView();
                else if (permission == "edit")
                    fn.CheckEdit();
            }
            else if (each.Tag is CatalogNode)
            {
                foreach (Node n in each.Nodes)
                    SetPermission(permission, n);
            }
        }

        #region Menu Events
        private void Menu_PopupOpen(object sender, PopupOpenEventArgs e)
        {
            foreach (BaseItem each in Menu.SubItems)
                each.Visible = false;

            foreach (Node each in AT.SelectedNodes)
                GroupPermissionOption(each);

            Menu.SubItems[IndexNone].Visible = true;
        }

        private void GroupPermissionOption(Node node)
        {
            if (node.Tag is CatalogNode)
            {
                CatalogNode c = node.Tag as CatalogNode;
                foreach (Node each in c.TreeNode.Nodes)
                    GroupPermissionOption(each);
            }
            else if (node.Tag is FeatureNode)
            {
                FeatureNode f = node.Tag as FeatureNode;

                if (f.FeatureItem is DetailItemFeature)
                {
                    Menu.SubItems[IndexView].Visible = true;
                    Menu.SubItems[IndexEdit].Visible = true;
                }
                else if (f.FeatureItem is RibbonFeature || f.FeatureItem is ReportFeature)
                {
                    Menu.SubItems[IndexExecute].Visible = true;
                }
            }
        }
        #endregion

        #region AdvTree Events

        private void AT_AfterCheck(object sender, AdvTreeCellEventArgs e)
        {
            if (BlockChangedEvent) return;

            if (PermissionChanged != null)
                PermissionChanged(this, EventArgs.Empty);
        }

        private void AT_AfterExpand(object sender, AdvTreeNodeEventArgs e)
        {
            if (Preference != null)
                Preference.SetBoolean(e.Node.FullPath, true);
        }

        private void AT_AfterCollapse(object sender, AdvTreeNodeEventArgs e)
        {
            if (Preference != null)
                Preference.SetBoolean(e.Node.FullPath, false);
        }

        private void AT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                foreach (FeatureNode each in FeatureNodes.Values)
                    AT.SelectedNodes.Add(each.TreeNode);

                foreach (CatalogNode each in CatalogNodes)
                    AT.SelectedNodes.Add(each.TreeNode);
            }
        }
        #endregion

        #region Public Inteface


        public void SetFeatureSource(Catalog permissions)
        {
            _feature_code_duplicate = new Dictionary<string, int>();
            CalculateDuplicateCount(permissions);
            List<string> duplicateList=new List<string>();
            foreach (KeyValuePair<string, int> each in _feature_code_duplicate)
            {
                if (each.Value > 1)
                    duplicateList.Add(each.Key);
            }
                if (duplicateList.Count>0)
                    throw new ArgumentException(string.Format("功能代碼重覆。({0})", string.Join(",", duplicateList.ToArray())));

            GenerateTreeView(permissions);
        }

        /// <summary>
        /// 用於檢查功能代碼有無重覆。
        /// </summary>
        private Dictionary<string, int> _feature_code_duplicate;
        private void CalculateDuplicateCount(Catalog permissions)
        {
            foreach (var each in permissions.Features)
            {
                if (_feature_code_duplicate.ContainsKey(each.Code))
                {
                    _feature_code_duplicate[each.Code]++;
                    Console.WriteLine(each.InstallAssembly);
                }
                else
                    _feature_code_duplicate.Add(each.Code, 1);
            }

            if (permissions.SubCatalogs.Count > 0)
            {
                foreach (var each in permissions.SubCatalogs)
                    CalculateDuplicateCount(each.Value);
            }
        }

        public void SetPermissions(List<RoleFeature> permissions)
        {
            BlockChangedEvent = true;

            foreach (FeatureNode each in FeatureNodes.Values)
                each.SetPermission(string.Empty);

            foreach (RoleFeature each in permissions)
            {
                if (FeatureNodes.ContainsKey(each.Code))
                    FeatureNodes[each.Code].SetPermission(each.PermissionString);
            }

            BlockChangedEvent = false;
        }

        public List<RoleFeature> GetPermissions()
        {
            List<RoleFeature> features = new List<RoleFeature>();

            foreach (FeatureNode each in FeatureNodes.Values)
            {
                string permission = each.GetPermission();

                if (string.IsNullOrEmpty(permission) || permission.ToLower() == "none")
                    continue;

                RoleFeature feature = new RoleFeature();
                feature.Code = each.FeatureItem.Code;
                feature.PermissionString = permission;

                features.Add(feature);
            }

            return features;
        }

        public event EventHandler PermissionChanged;

        #endregion

        #region GenerateTreeView
        private void GenerateTreeView(Catalog Root)
        {
            BlockChangedEvent = true;

            FeatureNodes = new Dictionary<string, FeatureNode>();
            CatalogNodes = new List<CatalogNode>();

            AT.Nodes.Clear();
            foreach (KeyValuePair<string, Catalog> eachItem in Root.SubCatalogs)
                CreateCatalogNode(null, eachItem.Key, eachItem.Value);

            foreach (FeatureItem each in RoleAclSource.Instance.Root.Features)
                CreateFeatureNode(null, each);

            BlockChangedEvent = false;
        }

        private void CreateCatalogNode(Node parent, string title, Catalog catalog)
        {
            Node n = new Node();
            n.Cells.Clear();

            Cell c1 = new Cell();
            c1.Text = title;
            n.Cells.Add(c1);
            n.Cells.Add(new Cell());
            n.Cells.Add(new Cell());
            n.Cells.Add(new Cell());
            n.Cells.Add(new Cell());
            n.Cells.Add(new Cell());

            if (parent == null)
                AT.Nodes.Add(n);
            else
                parent.Nodes.Add(n);

            n.Tag = catalog;

            CatalogNode cn = new CatalogNode(n);
            CatalogNodes.Add(cn);

            if (Preference != null)
                n.Expanded = Preference.GetBoolean(n.FullPath, false);

            foreach (KeyValuePair<string, Catalog> each in catalog.SubCatalogs)
                CreateCatalogNode(n, each.Key, each.Value);

            foreach (FeatureItem each in catalog.Features)
                cn.Children.Add(CreateFeatureNode(n, each));
        }

        private FeatureNode CreateFeatureNode(Node parent, FeatureItem feature)
        {
            FeatureNode fn = new FeatureNode(feature);

            if (parent == null)
                AT.Nodes.Add(fn.TreeNode);
            else
                parent.Nodes.Add(fn.TreeNode);

            if (!FeatureNodes.ContainsKey(feature.Code))
                FeatureNodes.Add(feature.Code, fn);

            return fn;
        }

        #endregion
    }
}
