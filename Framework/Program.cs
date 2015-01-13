using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using DataSynchronization;
using FISCA.Authentication;
using FISCA.Deployment.Administration;
using Framework.Legacy;
using Framework.Security;

namespace Framework
{
    public static class Program
    {
        public static void Initial()
        {
            DSAServices.AutoDisplayLoadingMessageOnMotherForm();

            InitializeGlobalData();

            //負責儲存使用者個人設定。
            User.Configuration = new User.UserConfigManager(new ConfigProvider_User(), DSAServices.UserAccount);
            //負責儲存應用程式設定。
            App.Configuration = new ConfigurationManager(new ConfigProvider_App());
            //負責儲存全域設定。
            Global.Configuration = new Global.GlobalConfigManager(new ConfigProvider_Global(), true);
            //可讀寫的全域組態。
            Global.ConfigurationWritable = new Global.GlobalConfigManager(new ConfigProvider_Global(), false);
            //負責資料庫變動的通知物件。
            App.DBMonitor = new DBChangeMonitor(10, new PTChangeSetProvider());

            try
            {
                Campus.Configuration.Config.Initialize(
                    new Campus.Configuration.UserConfigManager(new Campus.Configuration.ConfigProvider_User(), DSAServices.UserAccount),
                    new Campus.Configuration.ConfigurationManager(new Campus.Configuration.ConfigProvider_App()),
                    new Campus.Configuration.ConfigurationManager(new Campus.Configuration.ConfigProvider_Global()));
            }
            catch (Exception ex) { MsgBox.Show("載入組態管理程式庫錯誤：" + ex.Message); }

            FISCA.Presentation.MotherForm.Form.Icon = Properties.Resources.ischoolIcon;
            FISCA.Presentation.MotherForm.StartMenu.Image = Properties.Resources.Icon;
            FISCA.Presentation.MotherForm.Form.Text = GetTitleText();

            //DSAServices.SetupLoadingDisplay();

            //2011/8/4日 - dylan註解
            //FISCA.Presentation.MotherForm.StartMenu["模組管理"].Enable = User.Acl["StartButton0002"].Executable | DSAServices.IsSysAdmin;
            //FISCA.Presentation.MotherForm.StartMenu["模組管理"].Image = Properties.Resources.spiral_lock_64;
            //FISCA.Presentation.MotherForm.StartMenu["模組管理"].Click += delegate
            //{
            //    new ModuleManager().ShowDialog();
            //};

            FISCA.Presentation.MotherForm.StartMenu["安全性"]["使用者管理"].Click += new EventHandler(UserManage_Click);
            FISCA.Presentation.MotherForm.StartMenu["安全性"]["使用者管理"].Enable = User.Acl["StartButton0000"].Executable | DSAServices.IsSysAdmin;

            FISCA.Presentation.MotherForm.StartMenu["安全性"]["角色權限管理"].Click += new EventHandler(RoleManage_Click);
            FISCA.Presentation.MotherForm.StartMenu["安全性"]["角色權限管理"].Enable = User.Acl["StartButton0001"].Executable | DSAServices.IsSysAdmin;

            //最新消息註解 by Dylan 
            //if (General.Feedback.Program.Extension == null)
            //    General.Feedback.Program.Extension = new General.Feedback.ExtensionData();

            //General.Feedback.Program.Extension.SchoolChineseName = Framework.Legacy.GlobalOld.SchoolInformation.ChineseName;

            //General.Feedback.Program.RegisterStartButton();
            //LogViewfinder.PluginMain.RegisterStartButton();

            //2011/8/4日 - dylan註解
            //RoleAclSource.Instance["系統"].Add(new RibbonFeature("StartButton0002", "模組管理"));
            RoleAclSource.Instance["系統"].Add(new RibbonFeature("StartButton0000", "使用者管理"));
            RoleAclSource.Instance["系統"].Add(new RibbonFeature("StartButton0001", "角色權限管理"));

            if (Control.ModifierKeys == Keys.Shift)
            {
                if (User.Acl["StartButton0002"].Executable | DSAServices.IsSysAdmin)
                    new FISCA.Deployment.Administration.ModuleManager().ShowDialog();
            }

            //Student.Instance.ReflashAll();
            //Class.Instance.ReflashAll();
            //Teacher.Instance.ReflashAll();

            //Student.Instance.SetupPresentation();
            //Class.Instance.SetupPresentation();
            //Teacher.Instance.SetupPresentation();
            //Course.Instance.SetupPresentation();
        }

        private static string GetTitleText()
        {
            string schoolName = Framework.Legacy.GlobalOld.SchoolInformation.ChineseName;
            string schoolYear = Framework.Legacy.GlobalOld.SystemConfig.DefaultSchoolYear.ToString();
            string semester = Framework.Legacy.GlobalOld.SystemConfig.DefaultSemester.ToString();
            string server = DSAServices.AccessPoint;
            string user = DSAServices.UserAccount;

            string version = "0.0.0.0";
            try
            {
                string path = Path.Combine(Application.StartupPath, "release.xml");
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                version = doc.DocumentElement.GetAttribute("Version");
            }
            catch (Exception) { }

            return string.Format("ischool 〈{0} {1} {2} 〉〈FISCA：{3}〉〈{4}〉〈{5}〉", schoolName, schoolYear, semester, version, server, user);
        }

        #region Start Menu Events

        private static void UserManage_Click(object sender, EventArgs e)
        {
            //new Framework.Security.UI.UserManager().ShowDialog();
            new FISCA.Permission.UI.UserManager().ShowDialog();
        }

        private static void RoleManage_Click(object sender, EventArgs e)
        {
            //new Framework.Security.UI.RoleManager().ShowDialog();
            new FISCA.Permission.UI.RoleManager().ShowDialog();
        }
        #endregion

        private static void InitializeGlobalData()
        {
            Framework.Legacy.GlobalOld.BeginInitialize();

            //設定  Preference。
            FISCA.Presentation.IPreferenceProvider preference = new PreferenceProvider();
            FISCA.Presentation.MotherForm.PreferenceProvider = preference;
            Framework.Legacy.GlobalOld.Preference = preference;

            Framework.Legacy.GlobalOld.EndInitialize();
        }
    }
}
