using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using FISCA.DSAUtil;
using Framework.Security;

namespace Framework.Security.UI
{
    internal partial class RoleAddForm : Office2007Form
    {
        private IList<RoleData> Roles { get; set; }

        public RoleData NewRole { get; private set; }

        public RoleAddForm(IList<RoleData> roles)
        {
            InitializeComponent();

            Roles = roles;
        }

        private void RoleAddForm_Load(object sender, EventArgs e)
        {
            CopyRole.Items.Add("<不進行複製>");
            CopyRole.SelectedIndex = 0;

            foreach (RoleData role in Roles)
            {
                CopyRole.Items.Add(role);
                CopyRole.DisplayMember = "Name";
                CopyRole.ValueMember = "Identity";
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (ValidateRoleName())
            {
                RoleData newrole = new RoleData();
                newrole.Name = RoleName.Text;
                newrole.Description = RoleDescription.Text;

                if (CopyRole.SelectedItem is RoleData)
                {
                    RoleData role = CopyRole.SelectedItem as RoleData;

                    foreach (RoleFeature each in role.Permissions)
                        newrole.Permissions.Add(each.Clone());
                }

                RoleDAL.AddRole(newrole);
                NewRole = newrole;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidateRoleName()
        {
            Errors.Clear();

            //角色名稱不可空白
            if (string.IsNullOrEmpty(RoleName.Text))
            {
                Errors.SetError(RoleName, "角色名稱不可空白");
                return false;
            }

            //檢查角色名稱是否重複
            foreach (RoleData role in Roles)
            {
                if (role.Name.ToLower() == RoleName.Text.ToLower())
                {
                    Errors.SetError(RoleName, "角色名稱不可重複");
                    return false;
                }
            }

            return true;
        }
    }
}