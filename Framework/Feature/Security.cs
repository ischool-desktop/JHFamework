using System;
using System.Collections.Generic;
using System.Text;
using FISCA.DSAUtil;
using System.Xml;
using Framework;
using FISCA.Authentication;

namespace Framework.Feature
{
    internal class Security
    {
        [AutoRetryOnWebException()]
        internal static DSResponse GetLoginDetailList()
        {
            return DSAServices.CallService("SmartSchool.Security.GetLoginDetailList", new DSRequest());
        }

        [AutoRetryOnWebException()]
        internal static DSResponse GetRoleDetailList()
        {
            return DSAServices.CallService("SmartSchool.Security.GetRoleDetailList", new DSRequest());
        }

        [AutoRetryOnWebException()]
        internal static DSResponse GetRoleDetail(string roleName)
        {
            DSXmlHelper helper = new DSXmlHelper("Request");
            helper.AddElement("All");
            helper.AddElement("Condition");
            helper.AddElement("Condition", "RoleName", roleName);

            return DSAServices.CallService("SmartSchool.Security.GetRoleDetailList", new DSRequest(helper));
        }

        [AutoRetryOnWebException()]
        internal static void DeleteLogin(string id)
        {
            DSXmlHelper helper = new DSXmlHelper("Request");
            helper.AddElement("Login");
            helper.AddElement("Login", "ID", id);
            DSAServices.CallService("SmartSchool.Security.DeleteLogin", new DSRequest(helper));
        }

        [AutoRetryOnWebException()]
        internal static void DeleteLRBelong(string id)
        {
            DSXmlHelper helper = new DSXmlHelper("Request");
            helper.AddElement("LRBelong");
            helper.AddElement("LRBelong", "LoginID", id);
            DSAServices.CallService("SmartSchool.Security.DeleteLRBelong", new DSRequest(helper));
        }

        internal static void InsertLRBelong(string loginID, params string[] roleIDs)
        {
            DSXmlHelper helper = new DSXmlHelper("Request");
            foreach (string roleID in roleIDs)
            {
                helper.AddElement("LRBelong");
                helper.AddElement("LRBelong", "LoginID", loginID);
                helper.AddElement("LRBelong", "RoleID", roleID);
            }

            DSAServices.CallService("SmartSchool.Security.InsertLRBelong", new DSRequest(helper));
        }

        internal static void InsertLogin(string name, string password)
        {
            DSXmlHelper helper = new DSXmlHelper("Request");
            helper.AddElement("Login");
            helper.AddElement("Login", "LoginName", name);
            helper.AddElement("Login", "Password", password);
            DSAServices.CallService("SmartSchool.Security.InsertLogin", new DSRequest(helper));
        }

        [AutoRetryOnWebException()]
        internal static void UpdateLogin(string name, string password)
        {
            DSXmlHelper helper = new DSXmlHelper("Request");
            helper.AddElement("Login");
            helper.AddElement("Login", "Password", password);
            helper.AddElement("Login", "Condition");
            helper.AddElement("Login/Condition", "LoginName", name);
            DSAServices.CallService("SmartSchool.Security.UpdateLogin", new DSRequest(helper));
        }

        internal static void InsertRole(string name, string desc)
        {
            DSXmlHelper helper = new DSXmlHelper("Request");
            helper.AddElement("Role");
            helper.AddElement("Role", "RoleName", name);
            helper.AddElement("Role", "Description", desc);
            DSAServices.CallService("SmartSchool.Security.InsertRole", new DSRequest(helper));
        }

        internal static void InsertRole(string name, string desc, XmlElement permission)
        {
            DSXmlHelper helper = new DSXmlHelper("Request");
            helper.AddElement("Role");
            helper.AddElement("Role", "RoleName", name);
            helper.AddElement("Role", "Description", desc);
            helper.AddElement("Role", "Permission", permission.OuterXml, true);
            DSAServices.CallService("SmartSchool.Security.InsertRole", new DSRequest(helper));
        }

        [AutoRetryOnWebException()]
        internal static void DeleteRole(string id)
        {
            DSXmlHelper helper = new DSXmlHelper("Request");
            helper.AddElement("Role");
            helper.AddElement("Role", "ID", id);
            DSAServices.CallService("SmartSchool.Security.DeleteRole", new DSRequest(helper));
        }

        [AutoRetryOnWebException()]
        internal static void UpdateRole(string id, XmlElement permission)
        {
            DSXmlHelper helper = new DSXmlHelper("Request");
            helper.AddElement("Role");
            helper.AddElement("Role", "Permission", permission.OuterXml, true);
            helper.AddElement("Role", "Condition");
            helper.AddElement("Role/Condition", "ID", id);
            DSAServices.CallService("SmartSchool.Security.UpdateRole", new DSRequest(helper));
        }
    }
}
