using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSynchronization
{
    public enum ChangeAction { Insert, Update, Delete }

    public struct ChangeEntry
    {
        public long Sequence { get; set; }

        public string TableName { get; set; }

        public string DataID { get; set; }

        public DateTime Timestamp { get; set; }

        public ChangeAction Action { get; set; }
    }
}
