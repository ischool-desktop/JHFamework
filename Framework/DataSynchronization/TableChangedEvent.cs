using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSynchronization
{
    public delegate void TableChangedEventHandler(object sender,TableChangedEventArgs e);

    public class TableChangedEventArgs : EventArgs
    {
        public TableChangedEventArgs(Dictionary<string, DateTime> keys)
        {
            PrimaryKeys = new KeySet(keys);
        }

        /// <summary>
        /// 取得已變動的 Key。
        /// </summary>
        public KeySet PrimaryKeys { get; private set; }
    }
}
