using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.DSAUtil;
using Framework.Security;
using System.Xml;
using FISCA.Authentication;

namespace Framework.Feature
{
    public static class Permission
    {
        public static FeatureAcl GetUserAccessControlList()
        {
            FeatureAcl acl = new FeatureAcl();

            DSXmlHelper helper = new DSXmlHelper("Request");
            helper.AddElement("Condition");
            helper.AddElement("Condition", "UserName", DSAServices.UserAccount.ToUpper());
            DSResponse dsrsp = DSAServices.CallService("SmartSchool.Personal.GetRoles", new DSRequest(helper));
            foreach (XmlElement roleElement in dsrsp.GetContent().GetElements("Role"))
            {
                string role = roleElement.GetAttribute("Description");

                //這兩行程式暫時沒用到的樣子。
                //if (!_roles.Contains(role))
                //    _roles.Add(role);

                foreach (XmlElement featureElement in roleElement.SelectNodes("Permissions/Feature"))
                {
                    string code = featureElement.GetAttribute("Code");
                    string perm = featureElement.GetAttribute("Permission");
                    FeatureAce ace = new FeatureAce(code, perm);
                    acl.MergeAce(ace);
                }
            }

            return acl;
        }
    }
}
