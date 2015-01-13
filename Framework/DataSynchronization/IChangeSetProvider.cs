using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSynchronization
{
    public interface IChangeSetProvider
    {
        /// <summary>
        /// 取得有變更的資料清單。
        /// </summary>
        List<ChangeEntry> GetChangeSet();

        /// <summary>
        /// 設定 ChangeSet 的 BaseLine，以目前最新的 Sequence 為基礎。
        /// </summary>
        void SetBaseLine();

        /// <summary>
        /// 設定 ChangeSet 的 BaseLine，並可指定 Sequence。
        /// </summary>
        /// <param name="sequence"></param>
        void SetBaseLine(long sequence);
    }
}
