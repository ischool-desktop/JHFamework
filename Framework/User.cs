using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Security;

namespace Framework
{
    public static class User
    {
        /// <summary>
        /// 取得使用者個人的組態資料。
        /// </summary>
        public static UserConfigManager Configuration { get; internal set; }
        /// <summary>
        /// 使用者的權限清單。
        /// </summary>
        public static FeatureAcl Acl { get { return Framework.Legacy.GlobalOld.Acl; } }

        #region UserConfigManager
        public class UserConfigManager : ConfigurationManager
        {
            public string AccountName { get; private set; }

            internal UserConfigManager(IConfigurationProvider provider, string accountName)
                : base(provider)
            {
                AccountName = accountName.ToLower();
            }

            protected override string NamespacePreprocess(string configNamespace)
            {
                return string.Format("{0}::{1}", AccountName, configNamespace);
            }
        }
        #endregion
    }
}
