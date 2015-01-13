using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Framework.Security;

namespace Framework.Security.UI
{
    public partial class RoleManager : FISCA.Presentation.Controls.BaseForm
    {
        private RoleListProxy RProxy;
        private RolePermissionProxy RPProxy;
        private ConfigData Preference;
        private bool IsDirty { get; set; }

        public RoleManager()
        {
            InitializeComponent();

            IsDirty = false;
            Preference = User.Configuration["RoleAclEditor"];
            RProxy = new RoleListProxy(RolesPanel);
            RPProxy = new RolePermissionProxy(AT, Preference, TreeMenu);

            RProxy.SelectionChanging += new CancelEventHandler(RProxy_SelectionChanging);
            RProxy.SelectionChanged += new EventHandler(Roles_SelectionChanged);
            RPProxy.PermissionChanged += new EventHandler(RPProxy_PermissionChanged);

            RoleDAL.RoleAdded += new EventHandler<RoleEventArgs>(RoleDAL_RoleAdded);
            RoleDAL.RoleUpdated += new EventHandler<RoleEventArgs>(RoleDAL_RoleUpdated);
            RoleDAL.RoleDeleted += new EventHandler<RoleEventArgs>(RoleDAL_RoleDeleted);

            AT.Enabled = false;
        }

        private void RefreshRoleTitle()
        {
            if (IsDirty)
                PanelTop.Text = string.Format("{0} (已修改)", RProxy.Selected.Name);
            else
                PanelTop.Text = RProxy.Selected.Name;
        }

        private void RPProxy_PermissionChanged(object sender, EventArgs e)
        {
            RefreshRoleTitle();
            IsDirty = true;
        }

        private void RoleDAL_RoleAdded(object sender, RoleEventArgs e)
        {
            try
            {
                RoleData role = RoleDAL.GetRole(e.RoleName);
                RProxy.Add(role);
            }
            catch (Exception ex)
            {
                Framework.MsgBox.Show(ex.Message);
            }
        }

        private void RoleDAL_RoleUpdated(object sender, RoleEventArgs e)
        {
            try
            {
                RoleData role = RoleDAL.GetRole(e.RoleName);
                RProxy.Refresh(role);
                IsDirty = false;
                RefreshRoleTitle();
            }
            catch (Exception ex)
            {
                Framework.MsgBox.Show(ex.Message);
            }
        }

        private void RoleDAL_RoleDeleted(object sender, RoleEventArgs e)
        {
            RProxy.Remove(e.RoleName);
        }

        private void RProxy_SelectionChanging(object sender, CancelEventArgs e)
        {
            if (IsDirty)
            {
                string msg = string.Format("「{0}」資料已修改，但尚未儲存，是否放棄？", RProxy.Selected.Name);

                if (Framework.MsgBox.Show(msg, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void Roles_SelectionChanged(object sender, EventArgs e)
        {
            Delete.Enabled = (RProxy.Selected != RoleData.Null);
            Save.Enabled = (RProxy.Selected != RoleData.Null);

            RPProxy.SetPermissions(RProxy.Selected.Permissions);
            IsDirty = false;
            RefreshRoleTitle();

            AT.Enabled = (RProxy.Selected != RoleData.Null);
        }

        private void RoleManager_Load(object sender, EventArgs e)
        {
            List<RoleData> roles = RoleDAL.ListRoles();
            RProxy.AddRange(roles);

            try
            {
                RPProxy.SetFeatureSource(RoleAclSource.Instance.Root);
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);

                if (Control.ModifierKeys == Keys.Shift)
                    System.IO.File.WriteAllText("C://error.xml", Diagnostic.GetXmlString(ex));

                Close();
            }
        }

        private void RoleManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            RProxy.SelectionChanging -= new CancelEventHandler(RProxy_SelectionChanging);
            RProxy.SelectionChanged -= new EventHandler(Roles_SelectionChanged);
            RPProxy.PermissionChanged -= new EventHandler(RPProxy_PermissionChanged);

            RoleDAL.RoleAdded -= new EventHandler<RoleEventArgs>(RoleDAL_RoleAdded);
            RoleDAL.RoleUpdated -= new EventHandler<RoleEventArgs>(RoleDAL_RoleUpdated);
            RoleDAL.RoleDeleted -= new EventHandler<RoleEventArgs>(RoleDAL_RoleDeleted);

            Preference.SaveAsync();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            RoleAddForm form = new RoleAddForm(RProxy.Roles);
            if (form.ShowDialog() == DialogResult.OK)
                RProxy.Select(form.NewRole.Name);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string msg = string.Format("您確定要刪除「{0}」角色？", RProxy.Selected.Name);
            if (Framework.MsgBox.Show(msg, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                IsDirty = false;
                RoleDAL.DeleteRole(RProxy.Selected);
                RProxy.Select(null);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            RoleData role = RProxy.Selected;
            role.Permissions = RPProxy.GetPermissions();
            RoleDAL.UpdateRole(role);
        }
    }
}
