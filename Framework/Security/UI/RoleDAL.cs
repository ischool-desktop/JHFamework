using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.DSAUtil;
using System.Xml;
using Sec = Framework.Feature.Security;

namespace Framework.Security.UI
{
    /// <summary>
    /// 提供角色資料的存取方法。
    /// </summary>
    internal static class RoleDAL
    {
        /// <summary>
        /// 當角色資料變動時引發。
        /// </summary>
        public static event EventHandler<RoleEventArgs> RoleAdded;

        public static event EventHandler<RoleEventArgs> RoleUpdated;

        public static event EventHandler<RoleEventArgs> RoleDeleted;

        public static void AddRole(RoleData role)
        {
            Sec.InsertRole(role.Name, role.Description, role.GetPermissionAsXml());

            if (RoleAdded != null)
                RoleAdded(null, new RoleEventArgs(role.Name));
        }

        public static void UpdateRole(RoleData role)
        {
            Sec.UpdateRole(role.Identity, role.GetPermissionAsXml());

            if (RoleUpdated != null)
                RoleUpdated(null, new RoleEventArgs(role.Name));
        }

        public static void DeleteRole(RoleData role)
        {
            Sec.DeleteRole(role.Identity);

            if (RoleDeleted != null)
                RoleDeleted(null, new RoleEventArgs(role.Name));
        }

        public static RoleData GetRole(string roleName)
        {
            DSXmlHelper xmlrole = Sec.GetRoleDetail(roleName).GetContent();
            return new RoleData(xmlrole.GetElement("Role"));
        }

        public static bool RoleExists(string roleName)
        {
            DSXmlHelper xmlrole = Sec.GetRoleDetail(roleName).GetContent();
            return xmlrole.GetElements("Role").Length > 0;
        }

        public static List<RoleData> ListRoles()
        {
            DSXmlHelper xmlroles = Sec.GetRoleDetailList().GetContent();
            List<RoleData> objroles = new List<RoleData>();

            foreach (XmlElement each in xmlroles.GetElements("Role"))
                objroles.Add(new RoleData(each));

            return objroles;
        }
    }
}
