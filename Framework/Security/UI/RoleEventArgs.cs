using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Security.UI
{
    /// <summary>
    /// 代表角色資料變動時的事件參數。
    /// </summary>
    internal class RoleEventArgs : EventArgs
    {
        public RoleEventArgs(string roleName)
        {
            RoleName = roleName;
        }

        /// <summary>
        /// 被變動的角色名稱。
        /// </summary>
        public string RoleName { get; private set; }
    }
}
