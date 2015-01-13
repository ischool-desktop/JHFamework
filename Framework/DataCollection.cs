using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework
{
    /// <summary>
    /// 提供內部需要儲存Dictionary資料的類別。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataCollection<T>
    {
        protected Dictionary<string, List<T>> records;
        protected DataCollection()
        {
            records = new Dictionary<string, List<T>>();
        }

        public Dictionary<string, List<T>> Items
        {
            get { return records; }
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<T> this[string key]
        {
            get { return this.records[key]; }
        }

        public void Add(string key, List<T> val)
        {
            if (!this.records.ContainsKey(key))
                this.records.Add(key, val);
        }

        public void Clear()
        {
            this.records.Clear();
        }

        public List<string> Keys { 

            get {
                List<string> keys = new List<string>();
                foreach (string key in this.records.Keys)
                    keys.Add(key);

                return keys; 
            }
 
        }
    }
}
