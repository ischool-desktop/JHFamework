using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.Presentation;

namespace Framework
{
    public class AsyncFieldLoader<T, F> where T : CacheManager<F>
    {
        private T Cacher { get; set; }
        private Dictionary<string, string> _cached_values = new Dictionary<string, string>();
        private bool _loading = false;

        public ListPaneField Field { get; private set; }

        public AsyncFieldLoader(T cacher, string fieldName)
        {
            Cacher = cacher;
            Cacher.ItemUpdated += new EventHandler<ItemUpdatedEventArgs>(ItemUpdatedDelegate);

            Field = new ListPaneField(fieldName);
            Field.GetVariable += new EventHandler<GetVariableEventArgs>(Field_GetVariable);
            Field.PreloadVariable += new EventHandler<PreloadVariableEventArgs>(Field_PreloadVariable);
        }

        /// <summary>
        /// 當畫面上的欄位需要值的時後。
        /// </summary>
        public event EventHandler<GetValueEventArgs> GetValue;

        /// <summary>
        /// 請將負責該資料 CacheManager 的 ItemUpdate 事件指向此方法。
        /// </summary>
        private void ItemUpdatedDelegate(object sender, ItemUpdatedEventArgs e)
        {
            bool do_reload = false;

            foreach (string each in e.PrimaryKeys)
            {
                if (_cached_values.ContainsKey(each))
                {
                    _cached_values[each] = GetValueOutside(each);
                    do_reload = true;
                }
            }

            _loading = false;

            if (do_reload) Field.Reload();
        }

        private void Field_PreloadVariable(object sender, PreloadVariableEventArgs e)
        {
            Console.WriteLine(Field.Column.HeaderText + ":Preload");

            List<string> synclist = new List<string>();

            foreach (string each in e.Keys)
            {
                if (!_cached_values.ContainsKey(each))
                {
                    _cached_values.Add(each, string.Empty);
                    synclist.Add(each);
                }
            }

            if (synclist.Count > 0)
            {
                _loading = true;
                Cacher.SyncDataBackground(synclist);
            }
        }

        private string GetValueInside(string primaryKey)
        {
            if (_cached_values.ContainsKey(primaryKey))
                return _cached_values[primaryKey];
            else
                return string.Empty;
        }

        private string GetValueOutside(string primaryKey)
        {
            GetValueEventArgs args = new GetValueEventArgs(primaryKey);
            GetValue(this, args);
            return args.Value;
        }

        private void Field_GetVariable(object sender, GetVariableEventArgs e)
        {
            if (!_loading)
                e.Value = GetValueInside(e.Key);
            else
                e.Value = "讀取中...";
        }
    }

    public class GetValueEventArgs : EventArgs
    {
        public GetValueEventArgs(string key)
        {
            Key = key;
            Value = string.Empty;
        }
        /// <summary>
        /// 取得資料的ID
        /// </summary>
        public string Key { get; private set; }
        /// <summary>
        /// 取得或設定，此ID要顯示的值
        /// </summary>
        public string Value { get; set; }
    }
}
