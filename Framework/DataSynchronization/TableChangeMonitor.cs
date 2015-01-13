using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSynchronization
{
    public class TableChangeMonitor
    {
        internal TableChangeMonitor(string tableName)
        {
            TableName = tableName;
        }

        internal void RaiseEvent(List<ChangeEntry> changes)
        {
            Dictionary<ChangeAction, Dictionary<string, DateTime>> actions = new Dictionary<ChangeAction, Dictionary<string, DateTime>>();

            actions.Add(ChangeAction.Insert, new Dictionary<string, DateTime>());
            actions.Add(ChangeAction.Update, new Dictionary<string, DateTime>());
            actions.Add(ChangeAction.Delete, new Dictionary<string, DateTime>());

            foreach (ChangeEntry each in changes)
                actions[each.Action].Add(each.DataID, each.Timestamp);

            if (RecordInserted != null && actions[ChangeAction.Insert].Count > 0)
                RecordInserted(this, new TableChangedEventArgs(actions[ChangeAction.Insert]));

            if (RecordUpdated != null && actions[ChangeAction.Update].Count > 0)
                RecordUpdated(this, new TableChangedEventArgs(actions[ChangeAction.Update]));

            if (RecordDeleted != null && actions[ChangeAction.Delete].Count > 0)
                RecordDeleted(this, new TableChangedEventArgs(actions[ChangeAction.Delete]));
        }

        /// <summary>
        /// 資料表名稱。
        /// </summary>
        public string TableName { get; private set; }

        /// <summary>
        /// 當資料 Insert 時引發。
        /// </summary>
        public event TableChangedEventHandler RecordInserted;

        /// <summary>
        /// 當資料 Update 時引發。
        /// </summary>
        public event TableChangedEventHandler RecordUpdated;

        /// <summary>
        /// 當資料 Delete 時引發。
        /// </summary>
        public event TableChangedEventHandler RecordDeleted;
    }
}
