using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Security
{
    public class FeatureAce
    {
        public FeatureAce(string code, string accessString)
        {
            _code = code.Trim();
            _perm_string = accessString;

            string stracc = accessString.ToLower();

            if (stracc == "execute")
                _permAccess = AccessOptions.Execute;
            else if (stracc == "view")
                _permAccess = AccessOptions.View;
            else if (stracc == "edit")
                _permAccess = AccessOptions.Edit;
            else if (stracc == "none")
                _permAccess = AccessOptions.None;
            else
            {
                _permAccess = AccessOptions.Custom;
                _perm_string = accessString;
            }
        }

        internal FeatureAce(string code, AccessOptions access)
        {
            _code = code.Trim();
            _permAccess = access;
            _perm_string = string.Empty;
        }

        private string _code;
        /// <summary>
        /// 功能代碼。
        /// </summary>
        public string Code
        {
            get { return _code; }
        }

        private AccessOptions _permAccess;
        public AccessOptions Access
        {
            get { return _permAccess; }
        }

        private string _perm_string;
        /// <summary>
        /// 取得權限的原始字串內容。
        /// </summary>
        public string PermissionString { get { return _perm_string; } }

        /// <summary>
        /// 是否有檢視權限。
        /// </summary>
        public bool Viewable
        {
            get { return IsSupersetOf(AccessOptions.View); }
        }

        /// <summary>
        /// 是否有編輯權限(包含了檢視)。
        /// </summary>
        public bool Editable
        {
            get { return IsSupersetOf(AccessOptions.Edit); }
        }

        /// <summary>
        /// 是否有執行權限。
        /// </summary>
        public bool Executable
        {
            get { return IsSupersetOf(AccessOptions.Execute); }
        }

        internal bool IsSupersetOf(AccessOptions permission)
        {
            return ((_permAccess & permission) == permission);
        }

        /// <summary>
        /// 代表沒有任何資訊的物件。
        /// </summary>
        public static FeatureAce Null
        {
            get { return new FeatureAce(string.Empty, AccessOptions.None); }
        }

        public static AccessOptions Parse(string permString)
        {
            return (AccessOptions)Enum.Parse(typeof(AccessOptions), permString, true);
        }
    }
}