using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Framework.Security.UI
{
    /*
    <Role ID="5">
		<RoleName>boss</RoleName>
		<Description>老闆</Description>
		<Permission>
			<Permissions>
				<Feature Code="Button0010" Permission="Execute" />
				<Feature Code="Button0020" Permission="Execute" />
				<Feature Code="Button0030" Permission="Execute" />
				<Feature Code="Button0040" Permission="Execute" />
				<Feature Code="Content0010" Permission="View" />
				<Feature Code="Content0020" Permission="View" />
				<Feature Code="Content0030" Permission="View" />
				<Feature Code="Content0040" Permission="Edit" />
				<Feature Code="Content0100" Permission="Edit" />
				<Feature Code="Content0110" Permission="Edit" />
				<Feature Code="Content0120" Permission="View" />
				<Feature Code="Report0040" Permission="Execute" />
			</Permissions>
		</Permission>
	</Role>
     */

    internal class RoleData
    {
        public static RoleData Null { get; private set; }

        static RoleData()
        {
            Null = new RoleData();
        }

        public RoleData()
        {
            Permissions = new List<RoleFeature>();
            Identity = string.Empty;
            Name = string.Empty;
        }

        public RoleData(XmlElement data)
            : this()
        {
            XmlHelper xdata = new XmlHelper(data);
            Identity = xdata.GetString("@ID");
            Name = xdata.GetString("RoleName");

            foreach (XmlElement each in xdata.GetElements("Permission/Permissions/Feature"))
                Permissions.Add(new RoleFeature(each));
        }

        /// <summary>
        /// 角色編號。
        /// </summary>
        public string Identity { get; private set; }

        /// <summary>
        /// 角色名稱。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 角色說明。
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 角色權限清單(ACL)。
        /// </summary>
        public List<RoleFeature> Permissions { get; set; }

        /// <summary>
        /// 將 Permissions 屬性轉換成 Xml 資料。
        /// </summary>
        public XmlElement GetPermissionAsXml()
        {
            //<Feature Code="Button0010" Permission="Execute" />

            XmlCreator creator = new XmlCreator(true);
            creator.CreateStartElement("Permissions");
            {
                foreach (RoleFeature each in Permissions)
                {
                    creator.CreateStartElement("Feature");
                    creator.CreateAttribute("Code", each.Code);
                    creator.CreateAttribute("Permission", each.PermissionString);
                    creator.CreateEndElement();
                }
            }
            creator.CreateEndElement();

            return creator.GetAsXmlElement();
        }
    }

    /// <summary>
    /// 代表角色所擁有的權限項目。
    /// </summary>
    internal class RoleFeature
    {
        public RoleFeature()
        {
        }

        public RoleFeature(XmlElement data)
        {
            Code = data.GetAttribute("Code");
            PermissionString = data.GetAttribute("Permission");
        }

        public string Code { get; set; }

        public string PermissionString { get; set; }

        public RoleFeature Clone()
        {
            RoleFeature feature = new RoleFeature();
            feature.Code = Code;
            feature.PermissionString = PermissionString;

            return feature;
        }
    }
}
