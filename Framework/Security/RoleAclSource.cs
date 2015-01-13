using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Security
{
    /// <summary>
    /// 代表角色的權限清單資料來源。
    /// </summary>
    public class RoleAclSource
    {
        private static RoleAclSource _instance;

        public static RoleAclSource Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RoleAclSource();

                return _instance;
            }
        }

        public RoleAclSource()
        {
            Root = new Catalog(FISCA.Permission.RoleAclSource.Instance.Root);
        }

        public Catalog this[string name]
        {
            get { return Root[name]; }
        }

        public Catalog Root { get; private set; }
    }
}
