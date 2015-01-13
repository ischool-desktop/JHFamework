using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSynchronization;

namespace Framework
{
    public static class App
    {
        /// <summary>
        /// 取得應用程式的組態資料。
        /// </summary>
        public static ConfigurationManager Configuration { get; internal set; }

        /// <summary>
        /// 取得資料庫監視器。
        /// </summary>
        public static DBChangeMonitor DBMonitor { get; internal set; }
    }
}
