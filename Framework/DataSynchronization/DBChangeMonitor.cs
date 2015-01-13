using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace DataSynchronization
{
    /// <summary>
    /// 代表資料表變動監視器。
    /// </summary>
    public class DBChangeMonitor : IEnumerable<TableChangeMonitor>
    {
        /// <summary>
        /// 建立 TableDtaMonitor 實體。
        /// </summary>
        /// <param name="interval">檢查資料變動的時間間隔，以秒為單位。</param>
        public DBChangeMonitor(int interval, params  IChangeSetProvider[] providers)
        {
            TableMonitors = new Dictionary<string, TableChangeMonitor>();
            Providers = providers;
            InitializeTimer(interval);
        }

        internal Dictionary<string, TableChangeMonitor> TableMonitors { get; private set; }

        internal IChangeSetProvider[] Providers { get; private set; }

        internal Timer CheckTimer { get; private set; }

        internal int Interval { get; private set; }

        private void InitializeTimer(int interval)
        {
            CheckTimer = new Timer();
            CheckTimer.Interval = interval * 1000; //以秒為單位。
            CheckTimer.Enabled = false;
            CheckTimer.Tick += new EventHandler(CheckTimer_Tick);
        }

        private void CheckTimer_Tick(object sender, EventArgs e)
        {
            Dictionary<string, List<ChangeEntry>> tables_changeset = new Dictionary<string, List<ChangeEntry>>();

            foreach (ChangeEntry each in GetChangeSet())
            {
                if (!tables_changeset.ContainsKey(each.TableName))
                    tables_changeset.Add(each.TableName, new List<ChangeEntry>());

                tables_changeset[each.TableName].Add(each);
            }

            foreach (KeyValuePair<string, List<ChangeEntry>> each in tables_changeset)
            {
                if (TableMonitors.ContainsKey(each.Key))
                    TableMonitors[each.Key].RaiseEvent(each.Value);
            }
        }

        private List<ChangeEntry> GetChangeSet()
        {
            List<ChangeEntry> changes = new List<ChangeEntry>();

            foreach (IChangeSetProvider each in Providers)
                changes.AddRange(each.GetChangeSet());

            return changes;
        }

        /// <summary>
        /// 取得指定資料表的 Monitor。
        /// </summary>
        public TableChangeMonitor this[string tableName]
        {
            get
            {
                if (!TableMonitors.ContainsKey(tableName))
                    TableMonitors.Add(tableName, new TableChangeMonitor(tableName));

                return TableMonitors[tableName];
            }
        }

        /// <summary>
        /// 設定變更的基礎線，設定之後的變更才要  Monitor。
        /// </summary>
        public void SetBaseLine()
        {
            foreach (IChangeSetProvider each in Providers)
                each.SetBaseLine();
        }

        /// <summary>
        /// 開始啟動 Monitor。
        /// </summary>
        public void StartMonitor()
        {
            CheckTimer.Enabled = true;
        }

        /// <summary>
        /// 停止 Monitor。
        /// </summary>
        internal void StopMonitor()
        {
            CheckTimer.Enabled = false;
        }

        #region IEnumerable<TableChangeMonitor> 成員

        public IEnumerator<TableChangeMonitor> GetEnumerator()
        {
            return TableMonitors.Values.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成員

        IEnumerator IEnumerable.GetEnumerator()
        {
            return TableMonitors.Values.GetEnumerator();
        }

        #endregion
    }
}
