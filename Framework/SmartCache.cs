using System;
using System.Collections.Generic;

namespace Framework
{
    public class SmartCache<T> : Dictionary<string,T>
    {
        public int MaxCount { get; set; }

        public SmartCache()
        {
            MaxCount = int.MaxValue;
        }

        public CacheSet<T> GetByIDs(IEnumerable<string> IDs)
        {
            //從EntityCache取得資料，若是Cache的資料沒有大於MaxCount，則直接從EntityCache取得資料傳回。
            //若是EntityCache的資料筆數等於MaxCount，則將EntityCache沒有的資料，向LocalCache要資料，最後彙整資料傳回。


            CacheSet<T> CacheSet = new CacheSet<T>();

            //針對傳入的ID檢查Cache當中是否有相對應的物件，若有的話放到物件列表當中，沒有的話將ID存起來
            foreach (string strID in IDs)
                if (this.ContainsKey(strID))
                    CacheSet.Records.Add(this[strID]);
                else
                    CacheSet.NoExistIDs.Add(strID);
            return CacheSet;
        }

        public int Remove(IEnumerable<string> IDs)
        {
            int Result = 0;

            foreach (string ID in IDs)
            {
                if (this.ContainsKey(ID))
                {
                    this.Remove(ID);
                    Result++;
                }
            }

            return Result;
        }

        public void NotifyRemove(object sender, DataChangedEventArgs e)
        {
            this.Remove(e.PrimaryKeys);
        }

    }
}