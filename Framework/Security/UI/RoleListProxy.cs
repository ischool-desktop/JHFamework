using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;
using System.ComponentModel;

namespace Framework.Security.UI
{
    internal class RoleListProxy
    {
        public RoleListProxy(ItemPanel itemPanel)
        {
            Panel = itemPanel;
            Panel.Items.Clear();

            Selected = RoleData.Null;
        }

        public event EventHandler SelectionChanged;

        public event CancelEventHandler SelectionChanging;

        private bool CancelSelectChange()
        {
            CancelEventArgs args = new CancelEventArgs(false);

            if (SelectionChanging != null)
                SelectionChanging(this, args);

            return args.Cancel;
        }

        public RoleData Selected { get; private set; }

        public IList<RoleData> Roles
        {
            get
            {
                List<RoleData> roles = new List<RoleData>();
                foreach (ButtonItem each in Panel.Items)
                    roles.Add(each.Tag as RoleData);

                return roles.AsReadOnly();
            }
        }

        /// <summary>
        /// 選擇指定的角色，並引發 SelectionChanged 事件。
        /// </summary>
        public void Select(string roleName)
        {
            if (CancelSelectChange())
                return;

            //選擇指定的 RoleItem。
            if (string.IsNullOrEmpty(roleName))
            {
                SelectRoleInternal(RoleData.Null);

                foreach (ButtonItem each in Panel.Items)
                    each.Checked = false;

                return;
            }
            else
            {
                ButtonItem roleItem = GetButtonItemByName(roleName);

                if (roleItem != null)
                {
                    roleItem.Checked = true;
                    SelectRoleInternal(roleItem.Tag as RoleData);
                }
                else
                    throw new ArgumentException("指定的角色名稱不存在，無法 Select。");
            }
        }

        public void Add(RoleData role)
        {
            AddInternal(role);
            Panel.Refresh();
        }

        public void AddRange(List<RoleData> roles)
        {
            foreach (RoleData each in roles)
                AddInternal(each);

            Panel.Refresh();
        }

        /// <summary>
        /// 從畫面上移除角色項目。
        /// </summary>
        public void Remove(string roleName)
        {
            ButtonItem item = GetButtonItemByName(roleName);

            if (item != null)
                Panel.Items.Remove(item);
            else
                throw new ArgumentException("指定的角色名稱不存在，無法 Remove。");

            Panel.Refresh();
        }

        /// <summary>
        /// 根據角色編號，更新畫面。
        /// </summary>
        public void Refresh(RoleData role)
        {
            ButtonItem item = GetButtonItemByIdentity(role.Identity);

            if (item != null)
            {
                RefreshInternal(role, item);
                Panel.Refresh();
            }
            else
                throw new ArgumentException("指定的角色不存在，無法重新整理。");
        }

        private ItemPanel Panel { get; set; }

        /// <summary>
        /// 新增畫面上的 ButtonItem 項目，並與 RoleData 作關聯。
        /// </summary>
        private void AddInternal(RoleData role)
        {
            ButtonItem item = new ButtonItem();
            item.OptionGroup = "Role";
            RefreshInternal(role, item);
            item.Click += new EventHandler(RoleItem_Click);
            Panel.Items.Add(item);
        }

        private static void RefreshInternal(RoleData role, ButtonItem item)
        {
            item.Text = role.Name;
            item.Tooltip = item.Description;
            item.Tag = role;
        }

        /// <summary>
        /// 改變 SelectedRole 屬性，並引發 SelectionChanged 事件。
        /// </summary>
        private void SelectRoleInternal(RoleData role)
        {
            if (role == null) throw new ArgumentException("不可以選擇 Null 角色。");

            if (Selected == role) return;

            Selected = role;

            if (SelectionChanged != null)
                SelectionChanged(this, EventArgs.Empty);
        }

        private ButtonItem GetButtonItemByName(string roleName)
        {
            foreach (ButtonItem each in Panel.Items)
            {
                RoleData role = each.Tag as RoleData;

                if (role.Name == roleName)
                    return each;
            }

            return null;
        }

        private ButtonItem GetButtonItemByIdentity(string identity)
        {
            foreach (ButtonItem each in Panel.Items)
            {
                RoleData role = each.Tag as RoleData;

                if (role.Identity == identity)
                    return each;
            }

            return null;
        }

        private void RoleItem_Click(object sender, EventArgs e)
        {
            ButtonItem originItem = GetButtonItemByName(Selected.Name);

            ButtonItem item = sender as ButtonItem;
            RoleData role = item.Tag as RoleData;

            if (CancelSelectChange())
                originItem.Checked = true; //選回去。
            else
                SelectRoleInternal(role);
        }
    }
}
