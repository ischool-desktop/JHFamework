using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Security
{
    /// <summary>
    /// 代表對於某個功能的權限等級。
    /// </summary>
    [Flags()]
    public enum AccessOptions
    {
        /// <summary>
        /// 代表沒有權限。
        /// </summary>
        None = 0,
        /// <summary>
        /// 代表執行權限。
        /// </summary>
        Execute = 1,
        /// <summary>
        /// 代表檢視權限。
        /// </summary>
        View = 2,
        /// <summary>
        /// 代表編輯權限(包含了檢視權限)。
        /// </summary>
        Edit = View + 4,
        /// <summary>
        /// 代表權殊特權限。
        /// </summary>
        Custom = 8
    }
}