using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml;
using FISCA.DSAUtil;

namespace Framework
{
    /// <summary>
    /// 負責提供除錯相關功能。
    /// </summary>
    public static class Diagnostic
    {
        /// <summary>
        /// 將 Exception 物件的內容轉換成 Xml 字串。
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetXmlString(Exception ex)
        {
            ExceptionReport report = new ExceptionReport();
            report.AddType(typeof(HttpWebRequest), true);
            report.AddType(typeof(HttpWebResponse), true);

            return report.Transform(ex);
        }
        /// <summary>
        /// 取得系統是否處於除錯模式。
        /// </summary>
        public static bool DebugMode { get; private set; }
        /// <summary>
        /// 除錯模式下的各種選項。在使用本屬性時，建議都先判斷「DebugMode」是否為 True，以防出現預期外的結果。
        /// </summary>
        public static DebugOptions Options { get; set; }
        /// <summary>
        /// 回報例外訊息。
        /// </summary>
        /// <param name="ex">例外物件。</param>
        public static void FeedbackError(Exception ex)
        {
            BugReporter.ReportException(Framework.Legacy.GlobalOld.SystemName, Framework.Legacy.GlobalOld.SystemVersion, ex, false, string.Empty);
        }
        /// <summary>
        /// 回報例外訊息。
        /// </summary>
        /// <param name="ex">例外物件。</param>
        /// <param name="tipInfo">額外說明訊息。</param>
        public static void FeedbackError(Exception ex, string tipInfo)
        {
            BugReporter.ReportException(Framework.Legacy.GlobalOld.SystemName, Framework.Legacy.GlobalOld.SystemVersion, ex, false, string.Empty);
        }

        #region 提供除錯模式下的各種選項。
        public class DebugOptions
        {
            private AutoDictionary _options;

            public DebugOptions()
            {
                Diagnostic.DebugMode = false;
                _options = new AutoDictionary();
            }

            public DebugOptions(string debugFile)
            {
                Diagnostic.DebugMode = true;

                XmlElement debugOptions = XmlHelper.LoadFrom(debugFile);
                _options = new AutoDictionary(debugOptions.SelectNodes("Option"), "Name", false);
            }

            /// <summary>
            /// 將設定的內容轉換成 Xml 資料，以供儲存。
            /// </summary>
            /// <returns></returns>
            public XmlElement GetXml()
            {
                XmlCreator creator = new XmlCreator(true);
                creator.CreateStartElement("Diagnostic");
                {
                    foreach (string each in _options.Keys)
                    {
                        creator.CreateStartElement("Option");
                        {
                            creator.CreateAttribute("Name", each);
                            creator.CreateString(_options[each]);
                        }
                        creator.CreateEndElement();
                    }
                }
                creator.CreateEndElement();

                return creator.GetAsXmlElement();
            }

            private const string InsideOnlineUpdateServerKey = "內部更新主機位置";
            /// <summary>
            /// 取得或設定內部更新主機位置。
            /// </summary>
            public string InsideOnlineUpdateServer
            {
                get { return GetString(InsideOnlineUpdateServerKey, string.Empty); }
                set { _options[InsideOnlineUpdateServerKey] = value; }
            }
            /// <summary>
            /// 取得是否使用內部更新主機。
            /// </summary>
            public bool UseInsideOnlineUpdateServer
            {
                get { return !string.IsNullOrEmpty(InsideOnlineUpdateServer); }
            }

            private const string FrozenKernelUpdateKey = "凍結核心更新";
            /// <summary>
            /// 凍結核心更新。
            /// </summary>
            public bool FrozenKernelUpdate
            {
                get { return GetBoolean(FrozenKernelUpdateKey, true); }
                set { _options[FrozenKernelUpdateKey] = value.ToString(); }
            }

            private const string FrozenModuleUpdateKey = "凍結模組更新";
            /// <summary>
            /// 凍結模組更新。
            /// </summary>
            public bool FrozenModuleUpdate
            {
                get { return GetBoolean(FrozenModuleUpdateKey, true); }
                set { _options[FrozenModuleUpdateKey] = value.ToString(); }
            }

            private const string InsideGlobalConfigurationServerKey = "內部全域組態儲存主機位置";
            /// <summary>
            /// 取得或設定內部更新主機位置。
            /// </summary>
            public string InsideGlobalConfigurationServer
            {
                get { return GetString(InsideGlobalConfigurationServerKey, string.Empty); }
                set { _options[InsideGlobalConfigurationServerKey] = value; }
            }
            /// <summary>
            /// 取得是否使用內部「全域組態」儲存主機。
            /// </summary>
            public bool UseInsideGlobalConfigurationServer
            {
                get { return !string.IsNullOrEmpty(InsideGlobalConfigurationServer); }
            }

            private const string OutputDiagnosticMessageKey = "輸出除錯資訊";
            /// <summary>
            /// 取得或設定系統是否要輸入除錯資訊到本機檔案中。
            /// </summary>
            public bool OutputDiagnosticMessage
            {
                get { return GetBoolean(OutputDiagnosticMessageKey, true); }
                set { _options[OutputDiagnosticMessageKey] = value.ToString(); }
            }

            private const string SearchAllFolderAssemblyKey = "搜尋所有組件";
            /// <summary>
            /// 取得或設定是否載入 Module 時搜尋所有目錄，而不是只搜尋 Modules 之中的目錄。
            /// </summary>
            public bool SearchAllFolderAssembly
            {
                get { return GetBoolean(SearchAllFolderAssemblyKey, true); }
                set { _options[SearchAllFolderAssemblyKey] = value.ToString(); }
            }

            private bool GetBoolean(string key, bool defaultValue)
            {
                bool result;

                if (bool.TryParse(_options[key], out result))
                    return result;
                else
                    return defaultValue;
            }

            private string GetString(string key, string defaultValue)
            {
                if (string.IsNullOrEmpty(_options[key]))
                    return defaultValue;
                else
                    return _options[key];
            }
        }
        #endregion
    }
}
