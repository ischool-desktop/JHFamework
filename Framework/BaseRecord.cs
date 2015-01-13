using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Framework
{
    public enum RecordStatus { Insert, Update, Delete, NoChange }

    /// <summary>
    /// 可編輯的資料
    /// </summary>
    public abstract class BaseRecord
    {
        /// <summary>
        /// 建構子
        /// </summary>
        //public BaseRecord()
        //{

        //}

        ///// <summary>
        ///// 取得或設定，指出是否刪除這筆資料(Deleted為true後呼叫Save()才會真的從資料庫刪除)
        ///// </summary>
        //public bool Deleted { get; set; }
        /// <summary>
        /// 取得資料變更狀態
        /// </summary>
        public RecordStatus RecordStatus {get; set;}

        /// <summary>
        /// 儲存變更
        /// </summary>
        abstract public void Save();
    }
}
