using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Data;

namespace Framework
{
    /// <summary>
    /// 提供一組高效率的方法建立Xml文件，在資料量大時，效率遠超過一般XmlDocument操作。
    /// </summary>
    public class XmlCreator
    {
        private XmlTextWriter _xmlWriter;
        private MemoryStream _baseStream;
        private byte[] _result;
        private bool _CompleteCreateXml = false;

        /// <summary>
        /// 建立XmlGenerate物件。
        /// </summary>
        public XmlCreator()
            : this(false)
        {
        }

        /// <summary>
        /// 建立XmlGenerate物件。
        /// </summary>
        /// <param name="doFormating">決定是否要格式化Xml文件。</param>
        public XmlCreator(bool doFormating)
        {
            _baseStream = new MemoryStream();
            _xmlWriter = new XmlTextWriter(_baseStream, Encoding.UTF8);

            if (doFormating)
            {
                _xmlWriter.Indentation = 1;
                _xmlWriter.IndentChar = '\t';
                _xmlWriter.Formatting = Formatting.Indented;
            }
        }

        /// <summary>
        /// 取出結果，當取出結果後就不能在新增資料。
        /// </summary>
        /// <returns>回傳Xml結果字串。</returns>
        public string GetAsString()
        {

            if (!IsCompleted)
                CompleteCreateXml();

            //前面有 3 byte 的怪東西...
            return Encoding.UTF8.GetString(_result, 3, _result.Length - 3);
        }

        /// <summary>
        /// 取出結果，當取出結果後就不能在新增資料。
        /// </summary>
        /// <returns>回傳Xml結果串流。</returns>
        public Stream GetAsStream()
        {
            if (!IsCompleted)
                CompleteCreateXml();

            MemoryStream ms = new MemoryStream();
            ms.Write(_result, 0, _result.Length);
            ms.Flush();
            ms.Seek(0, SeekOrigin.Begin);

            return ms;
        }

        /// <summary>
        /// 取得結果，如果沒有「根」元素將會產生錯誤。
        /// 當取出結果後就不能在新增資料。
        /// </summary>
        /// <returns>回傳結果的 XmlElement 物件。</returns>
        public XmlElement GetAsXmlElement()
        {
            if (!IsCompleted)
                CompleteCreateXml();

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.PreserveWhitespace = true;
            xmldoc.Load(GetAsStream());

            return xmldoc.DocumentElement;
        }

        /// <summary>
        /// 取得結果，如果沒有「根」元素將會產生錯誤。
        /// 當取出結果後就不能在新增資料。
        /// </summary>
        /// <returns>回傳結果的XPathDocument物件。</returns>
        public XPathDocument GetAsXPathDocument()
        {
            if (!IsCompleted)
                CompleteCreateXml();

            XPathDocument xpathdoc = new XPathDocument(GetAsStream());
            return xpathdoc;
        }

        public XmlHelper GetAsXmlHelper()
        {
            if (!IsCompleted)
                CompleteCreateXml();

            return new XmlHelper(GetAsXmlElement());
        }

        /// <summary>
        /// 將結果儲存到檔案。
        /// 當取出結果後就不能在新增資料。
        /// </summary>
        /// <param name="fileName">檔案名稱</param>
        public void SaveResult(string fileName)
        {
            if (!IsCompleted)
                CompleteCreateXml();

            FileStream sw = new FileStream(fileName, FileMode.Create);

            sw.Write(_result, 0, _result.Length);
            sw.Close();
        }

        /*Private Method*/

        /// <summary>
        /// 完成Xml的輸出動作。
        /// </summary>
        private void CompleteCreateXml()
        {
            _xmlWriter.Flush();

            _result = new byte[_baseStream.Length];
            _baseStream.Seek(0, SeekOrigin.Begin);
            _baseStream.Read(_result, 0, _result.Length);

            _baseStream.Close();
            _xmlWriter.Close();

            _CompleteCreateXml = true;
        }

        /// <summary>
        /// 取得是否已經完成建立Xml文件。
        /// </summary>
        private bool IsCompleted
        {
            get { return _CompleteCreateXml; }
        }

        #region XmlWriter成員

        /// <summary>
        /// 建立二進位資料的Base64編碼。
        /// </summary>
        /// <param name="buffer">要寫入的二進位資料。</param>
        /// <param name="index">緩衝區的索引，要開始寫入的索引。</param>
        /// <param name="count">要寫入的位元組數。</param>
        public void CreateBase64(byte[] buffer, int index, int count)
        {
            _xmlWriter.WriteBase64(buffer, index, count);
        }

        /// <summary>
        /// 建立文字資料於CDataSection中。
        /// </summary>
        /// <param name="text">要加入CDataSection的文字資料。</param>
        public void CreateCData(string text)
        {
            _xmlWriter.WriteCData(text);
        }

        /// <summary>
        /// 建立Xml註解。
        /// </summary>
        /// <param name="text">註解文字</param>
        public void CreateComment(string text)
        {
            _xmlWriter.WriteComment(text);
        }

        /// <summary>
        /// 關閉先前的CreateStartAttribute呼叫。
        /// </summary>
        public void CreateEndAttribute()
        {
            _xmlWriter.WriteEndAttribute();
        }

        /// <summary>
        /// 關閉先前的CreateStartElement呼叫。
        /// </summary>
        public void CreateEndElement()
        {
            _xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// 從未經處理的Xml字串建立Xml。例：&lt;Student&gt;資料&lt;/Student&gt;。
        /// </summary>
        /// <param name="data">要寫入的Xml字串。</param>
        public void CreateRaw(string data)
        {
            _xmlWriter.WriteRaw(data);
        }

        /// <summary>
        /// 從未經處理的Xml字元陣列建立Xml。例：&lt;Student&gt;資料&lt;/Student&gt;。
        /// </summary>
        /// <param name="buffer">要入寫的字元列。</param>
        /// <param name="index">開始位置。</param>
        /// <param name="count">讀取數量。</param>
        public void CreateRaw(char[] buffer, int index, int count)
        {
            _xmlWriter.WriteRaw(buffer, index, count);
        }

        /// <summary>
        /// 開始建立Xml屬性。
        /// </summary>
        /// <param name="localName">屬性名稱。</param>
        public void CreateStartAttribute(string localName)
        {
            _xmlWriter.WriteStartAttribute(localName);
        }

        /// <summary>
        /// 建立起始元素。例：&lt;Student&gt;。
        /// </summary>
        /// <param name="localName">元素名稱。</param>
        public void CreateStartElement(string localName)
        {
            _xmlWriter.WriteStartElement(localName);
        }

        /// <summary>
        /// 建立文字資料。
        /// </summary>
        /// <param name="text">文字資料。</param>
        public void CreateString(string text)
        {
            _xmlWriter.WriteString(text);
        }

        /// <summary>
        /// 建立完整的Xml元素。
        /// </summary>
        /// <param name="localName">元素名稱。</param>
        /// <param name="value">資料值。</param>
        public void CreateElement(string localName, string value)
        {
            _xmlWriter.WriteElementString(localName, value);
        }

        /// <summary>
        /// 建立完整的屬性資料。
        /// </summary>
        /// <param name="localName">屬性名稱。</param>
        /// <param name="value">屬性值。</param>
        public void CreateAttribute(string localName, string value)
        {
            _xmlWriter.WriteAttributeString(localName, value);
        }

        /// <summary>
        /// 匯入XmlElement中的資料建立子元素樹，資料中可以包含許多子元素。
        /// </summary>
        /// <param name="elm">要匯入的元素物件。</param>
        public void CreateSubtree(XmlElement elm)
        {
            _xmlWriter.WriteNode(new XmlTextReader(new StringReader(elm.OuterXml)), true);
        }

        /// <summary>
        /// 依元素陣列建立Xml。
        /// </summary>
        /// <param name="elements">要匯入的元素陣列。</param>
        public void CreateElements(XmlElement[] elements)
        {
            CreateSubtree(elements, null);
        }

        /// <summary>
        /// 匯入元素陣列建立子元素樹。
        /// </summary>
        /// <param name="elements">要匯入的元素陣列。</param>
        /// <param name="rootName">根元素名稱。</param>
        public void CreateSubtree(XmlElement[] elements, string rootName)
        {
            if (rootName != null) CreateStartElement(rootName);

            foreach (XmlElement elm in elements)
                CreateSubtree(elm);

            if (rootName != null) CreateEndElement();
        }

        /// <summary>
        /// 匯入XmlNodeList中的資料建立Xml。
        /// </summary>
        /// <param name="nodes">要匯入的XmlNodeList物件。</param>
        public void CreateElements(XmlNodeList nodes)
        {
            CreateSubtree(nodes, null);
        }

        /// <summary>
        /// 匯入XmlNodeList物件建立子元素樹。
        /// </summary>
        /// <param name="nodes">要匯入的XmlNodeList物件</param>
        /// <param name="rootName">根元素名稱</param>
        public void CreateSubtree(XmlNodeList nodes, string rootName)
        {
            if (rootName != null) CreateStartElement(rootName);

            foreach (XmlNode node in nodes)
                CreateSubtree((XmlElement)node);

            if (rootName != null) CreateEndElement();
        }


        /// <summary>
        /// 匯入DataTable物件建立子元素樹。
        /// </summary>
        public void CreateSubtree(DataTable dataTable)
        {
            if (dataTable.TableName != "")
                CreateSubtree(dataTable, dataTable.TableName);
            else
                CreateSubtree(dataTable, "DataTable");
        }

        /// <summary>
        /// 匯入DataTable物件建立子元素樹。
        /// </summary>
        /// <param name="dataTable">要匯入的DataTable物件。</param>
        /// <param name="rootName">根元素名稱。</param>
        public void CreateSubtree(DataTable dataTable, string rootName)
        {
            CreateSubtree(dataTable, rootName, "RecordName");
        }

        /// <summary>
        /// 匯入DataTable物件建立子元素樹。
        /// </summary>
        /// <param name="dataTable">要匯入的DataTable物件。</param>
        /// <param name="rootName">根元素名稱。</param>
        /// <param name="recordName">每一筆記錄的根名稱。</param>
        public void CreateSubtree(DataTable dataTable, string rootName, string recordName)
        {
            CreateSubtree(dataTable, rootName, recordName, null);
        }

        /// <summary>
        /// 匯入DataTable物件建立子元素樹
        /// </summary>
        /// <param name="dataTable">要匯入的DataTable物件</param>
        /// <param name="rootName">根元素名稱</param>
        /// <param name="recordName">每一筆記錄的根名稱</param>
        /// <param name="fieldList">要加入的欄位列表，用逗號(,)分隔。例：客戶,訂單,日期，傳入 Null 就處理所有欄位。</param>
        public void CreateSubtree(DataTable dataTable, string rootName, string recordName, string fieldList)
        {
            /* 決定是否處理所有欄位，還是由使用者決定的部份欄位
             * 使用fieldList參數決定，如果不是Null就使用使用者決定的欄位
             * 否之則處理所有欄位。
             * 在處理時，使用DataColumn陣列儲存要處理的欄位。*/
            DataColumn[] columnInfos = null;
            if (fieldList != null)
            {
                string[] strFieldList = fieldList.Split(',');
                columnInfos = new DataColumn[strFieldList.Length];
                for (int i = 0; i < columnInfos.Length; i++)
                    columnInfos[i] = dataTable.Columns[strFieldList[i]];
            }
            else
            {
                columnInfos = new DataColumn[dataTable.Columns.Count];
                for (int i = 0; i < dataTable.Columns.Count; i++)
                    columnInfos[i] = dataTable.Columns[i];
            }

            CreateStartElement(rootName);
            foreach (DataRow dr in dataTable.Rows)
            {
                CreateStartElement(recordName);

                //依據columnInfos內部決定要處理哪些欄位。
                foreach (DataColumn dc in columnInfos)
                {
                    object value = dr[dc.Ordinal];
                    if (value == null)
                        CreateElement(dc.ColumnName, "");
                    else
                    {
                        //如果欄位的資料類型是DateTime就將其處理成一定的格式。
                        if (dc.DataType == typeof(DateTime))
                            if (value.ToString() == "")
                                CreateElement(dc.ColumnName, "");
                            else
                                CreateElement(dc.ColumnName, ((DateTime)value).ToString("yyyy/MM/dd hh:mm:ss"));
                        else
                            CreateElement(dc.ColumnName, value.ToString());
                    }
                }
                CreateEndElement();
            }
            CreateEndElement();
        }
        #endregion
    }
}
