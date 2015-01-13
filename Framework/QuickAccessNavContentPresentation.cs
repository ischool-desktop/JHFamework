using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.Presentation;

namespace Framework
{
    /// <summary>
    /// 整合快取資料功能的NavContentPresentation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class QuickAccessNavContentPresentation<T> : FISCA.Presentation.NLDPanel
    {
        /// <summary>
        /// 一次取得所有資料項目
        /// </summary>
        /// <returns>傳回索引鍵跟快取資料的查詢</returns>
        protected abstract Dictionary<string, T> GetAllData();
        /// <summary>
        /// 一次取得部份指定鍵值的資料。
        /// </summary>
        /// <param name="primaryKeys">要取得的鍵值</param>
        /// <returns>傳回索引鍵跟快取資料的查詢</returns>
        protected abstract Dictionary<string, T> GetData(IEnumerable<string> primaryKeys);
        /// <summary>
        /// 重新整理Filter的內容，於資料讀取完成或資料變更時呼叫
        /// </summary>
        protected virtual void FillFilter() { }
        /// <summary>
        /// 取得或設定，使用Filter機制
        /// </summary>
        private bool _UseFilter=false;
        protected bool UseFilter { get { return _UseFilter; } set { _UseFilter = value; FilterMenu.Visible = value; } }
        private void SetSource()
        {
            if ( _UseFilter )
                FillFilter();
            else
                SetFilteredSource(new List<string>(Items.Keys));
        }
        /// <summary>
        /// 驗證輸入的鍵值是否合法，當要求查尋資料時若鍵值不合法則不進行查尋
        /// 預設驗證方法為是否可轉化為int
        /// </summary>
        /// <param name="key">鍵值</param>
        /// <returns>是否合法</returns>
        protected virtual bool ValidateKey(string key)
        {
            int a;
            return int.TryParse(key, out a);
        }

        private QuickAccessCacheManager _CacheManager = null;
        /// <summary>
        /// 建構子
        /// </summary>
        public QuickAccessNavContentPresentation()
        {
            Loaded = false;
            UseFilter = false;
            _CacheManager = new QuickAccessNavContentPresentation<T>.QuickAccessCacheManager(this);
            _CacheManager.ItemUpdated += delegate(object sender, ItemUpdatedEventArgs e)
            {
                RefillListPane();

                BigEvent be = new BigEvent("ItemUpdated", ItemUpdated, this, e);
                be.UIRaise();
                if (be.HasException) throw be.Exceptions[0];

                SetSource();
                foreach (var key in DisplaySource)
                {
                    if (e.PrimaryKeys.Contains(key))
                    {
                        RefillListPane();
                        break;
                    }
                }
                //if (e.PrimaryKeys.Contains(DisplayDetailID) && Items.ContainsKey(DisplayDetailID))
                //    this.ReloadDetailPane();
            };
            _CacheManager.ItemLoaded += delegate(object sender, EventArgs e)
            {
                this.ShowLoading = false;
                Loaded = true;

                BigEvent be = new BigEvent("ItemLoaded", ItemLoaded, this, e);
                be.UIRaise();
                if (be.HasException) throw be.Exceptions[0];

                SetSource();
            };

            this.CompareSource += delegate(object sender, CompareEventArgs e)
            {
                e.Result = _CacheManager.QuickCompare(e.Value1, e.Value2);
            };
            this.SelectedSourceChanged += delegate { if (SelectedListChanged != null)SelectedListChanged(this, new EventArgs()); };
            this.TempSourceChanged += delegate { if (TemporaListChanged != null)TemporaListChanged(this, new EventArgs()); };
        }

        /// <summary>
        /// 取得指定索引的項目，若指定的鍵值不存在則會先嚐試進行查尋
        /// </summary>
        /// <param name="primaryKey">取得項目的鍵值</param>
        /// <returns>該鍵值的項目，若傳入鍵值沒有對應項目則傳回default(T)</returns>
        public T this[string primaryKey]
        {
            get { return Items[primaryKey]; }
        }
        /// <summary>
        /// 取得管理項目的集合
        /// </summary>
        public CacheManager<T>.CacheItemCollection Items { get { if (!Loaded)SyncAllBackground(); return _CacheManager.Items; } }
        /// <summary>
        /// 重新排序快取資料，快取的資料型別若為IComparable則將自動進行排序
        /// 不需呼叫此方法也會維持順序，唯有當IComparable.CompareTo實作變更時使用此方法重新排序
        /// </summary>
        public void SortItems()
        {
            _CacheManager.SortItems();
            RefillListPane();
        }
        /// <summary>
        /// 取得所有資料，此方法將於背景執行續進行，並於完成後引發ItemLoaded事件
        /// </summary>
        public void SyncAllBackground()
        {
            _CacheManager.SyncAllBackground();
            this.ShowLoading = true;
        }
        /// <summary>
        /// 更新快取資料，更新後將會引發ItemUpdated事件
        /// </summary>
        /// <param name="primaryKeys">要更新資料的鍵值</param>
        public void SyncData(params string[] primaryKeys) { SyncData((IEnumerable<string>)primaryKeys); }
        /// <summary>
        /// 更新快取資料，更新後將會引發ItemUpdated事件
        /// </summary>
        /// <param name="primaryKeys">要更新資料的鍵值</param>
        public void SyncData(IEnumerable<string> primaryKeys) { _CacheManager.SyncData(primaryKeys); }
        /// <summary>
        /// 更新快取資料，此方法將於背景執行續進行，並於完成後引發ItemUpdated事件
        /// </summary>
        /// <param name="primaryKeys">要更新資料的鍵值</param>
        public void SyncDataBackground(params string[] primaryKeys) { SyncDataBackground((IEnumerable<string>)primaryKeys); }
        /// <summary>
        /// 更新快取資料，此方法將於背景執行續進行，並於完成後引發ItemUpdated事件
        /// </summary>
        /// <param name="primaryKeys">要更新資料的鍵值</param>
        public void SyncDataBackground(IEnumerable<string> primaryKeys) { _CacheManager.SyncDataBackground(primaryKeys); }
        /// <summary>
        /// ListPane中被選取的項目清單
        /// </summary>
        public List<T> SelectedList
        {
            get
            {
                List<T> selectedList = new List<T>();
                foreach (var id in this.SelectedSource)
                {
                    selectedList.Add(Items[id]);
                }
                return selectedList;
            }
        }
        /// <summary>
        /// 被加入至待處理的項目清單
        /// </summary>
        public List<T> TemporaList
        {
            get
            {
                List<T> temporaList = new List<T>();
                foreach (var id in this.TempSource)
                {
                    temporaList.Add(Items[id]);
                }
                return temporaList;
            }
        }
        /// <summary>
        /// 取得是否已經載入(SyncAllBackground)
        /// </summary>
        public bool Loaded { get; private set; }
        /// <summary>
        /// 當SelectedList改變時
        /// </summary>
        public event EventHandler SelectedListChanged;
        /// <summary>
        /// 當TemporaList改變時
        /// </summary>
        public event EventHandler TemporaListChanged;

        /// <summary>
        /// 當SyncAllBackground完成時
        /// </summary>
        public event EventHandler ItemLoaded;
        /// <summary>
        /// 當快取資料變更時
        /// </summary>
        public event EventHandler<ItemUpdatedEventArgs> ItemUpdated;

        private class QuickAccessCacheManager : CacheManager<T>
        {
            private QuickAccessNavContentPresentation<T> _Parent;
            public QuickAccessCacheManager(QuickAccessNavContentPresentation<T> parent)
            {
                _Parent = parent;
            }

            protected override Dictionary<string, T> GetAllData()
            {
                return _Parent.GetAllData();
            }

            protected override Dictionary<string, T> GetData(IEnumerable<string> primaryKeys)
            {
                return _Parent.GetData(primaryKeys);
            }

            protected override bool ValidateKey(string key)
            {
                return _Parent.ValidateKey(key);
            }
        }

    }
}
