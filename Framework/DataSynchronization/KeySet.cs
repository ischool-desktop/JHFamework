using System;
using System.Collections.Generic;
using System.Text;

namespace DataSynchronization
{
    /// <summary>
    /// 代表一組 Key 的集合。
    /// </summary>
    public class KeySet : IEnumerable<string>
    {
        private Dictionary<string, DateTime> _keys_dic;

        public KeySet(Dictionary<string, DateTime> keys)
        {
            _keys_dic = keys;
        }

        /// <summary>
        /// 取得 Key 的數量。
        /// </summary>
        public int Count { get { return _keys_dic.Count; } }

        /// <summary>
        /// 判斷某 Key 是否存在。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(string key)
        {
            return _keys_dic.ContainsKey(key);
        }

        /// <summary>
        /// 取得指定 Key 的更改時間。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DateTime this[string key] { get { return _keys_dic[key]; } }

        /// <summary>
        /// 將資料轉換成 Dictionary。
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, DateTime> AsDictionary()
        {
            return new Dictionary<string, DateTime>(_keys_dic);
        }

        #region IEnumerable<string> 成員

        public IEnumerator<string> GetEnumerator()
        {
            return _keys_dic.Keys.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成員

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _keys_dic.Keys.GetEnumerator();
        }

        #endregion

        public override string ToString()
        {
            string[] klist = new string[_keys_dic.Count];
            _keys_dic.Keys.CopyTo(klist, 0);
            return string.Join(",", klist);
        }
    }
}
