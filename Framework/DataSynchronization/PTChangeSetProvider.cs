using System;
using System.Collections.Generic;
using System.Text;
using FISCA.DSAUtil;
using FISCA.Authentication;

namespace DataSynchronization
{
    /// <summary>
    /// Physical Table ChangeSet Provider.
    /// </summary>
    internal class PTChangeSetProvider : IChangeSetProvider
    {
        private long CurrentSequence { get; set; }

        public PTChangeSetProvider()
        {
        }

        #region IChangeSetProvider 成員

        public List<ChangeEntry> GetChangeSet()
        {
            return new List<ChangeEntry>();
        }

        public void SetBaseLine()
        {
            DSXmlHelper rsp = DSAServices.CallService("DataSynchronization.GetLastSequence", new DSRequest()).GetContent();
            int sequence = 0;

            if (int.TryParse(rsp.GetText("@Sequence"), out sequence))
                CurrentSequence = sequence;
        }

        public void SetBaseLine(long sequence)
        {
            CurrentSequence = sequence;
        }

        #endregion
    }
}
