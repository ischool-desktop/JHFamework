using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Framework.Legacy
{
    [Obsolete("Refactoring:需要再討論。")]
    public class ConfigurationCollection
    {
        public ConfigurationCollection()
        {
            RootElement = GlobalOld.SchoolConfig.Content;
        }

        private XmlElement RootElement;
        public XmlElement this[string Key]
        {
            get
            {
                XmlElement element = (XmlElement)RootElement.SelectSingleNode(Key);
                if (element == null)
                {
                    return RootElement.OwnerDocument.CreateElement(Key);
                }
                else
                    return (XmlElement)element;
            }
            set
            {
                if (value.Name != Key)
                    throw new Exception("ElementName與Key不相同");
                //馬上抓最新版
                GlobalOld.SchoolConfig.Load();
                //CurrentUser.Instance.SchoolConfig.Load();
                //更新
                //RootElement = CurrentUser.Instance.SchoolConfig.Content;
                RootElement = GlobalOld.SchoolConfig.Content;
                XmlElement element = (XmlElement)RootElement.SelectSingleNode(Key);
                if (element != null)
                {
                    XmlElement e = value;
                    if (element.OwnerDocument != value.OwnerDocument)
                        e = (XmlElement)element.OwnerDocument.ImportNode(value, true);

                    RootElement.ReplaceChild(e, element);
                }
                else
                    RootElement.AppendChild(RootElement.OwnerDocument.ImportNode(value, true));
                //存回去
                GlobalOld.SchoolConfig.Save();
                //CurrentUser.Instance.SchoolConfig.Save();
            }
        }
    }
}
