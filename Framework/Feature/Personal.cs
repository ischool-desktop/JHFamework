using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using FISCA.DSAUtil;
using FISCA.Authentication;

namespace Framework.Feature
{
    public class Personal
    {
        [AutoRetryOnWebException()]
        public static void SetPreference(XmlElement element)
        {
            DSXmlHelper request = new DSXmlHelper();
            request.Load("<SetPreferenceRequest>" + element.InnerXml + "</SetPreferenceRequest>");
            request.SetAttribute(".", "UserName", DSAServices.UserAccount);

            DSAServices.CallService("SmartSchool.Personal.SetPreference", new DSRequest(request));
        }

        [AutoRetryOnWebException()]
        public static DSResponse GetPreference()
        {
            DSXmlHelper request = new DSXmlHelper("Content");
            request.AddElement(".", "UserName", DSAServices.UserAccount);

            return DSAServices.CallService("SmartSchool.Personal.GetPreference", new DSRequest(request));
        }
    }
}
