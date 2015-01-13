using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using FISCA.DSAUtil;
using System.Xml;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using DataSynchronization;

namespace Framework
{
    //public static class DSAServices
    //{
    //    private static int _RunningRequest = 0;
    //    private static ulong _TransferBytes = 0;
    //    private static ulong _TransferTimes = 0;
    //    private static bool _TransferSuccess = true;
    //    private static string _WebExceptionMessage = "";
    //    private static ManualResetEvent _LockConnection = new ManualResetEvent(true);
    //    private static bool _is_sys_admin;

    //    private static Image _NormalImage = Properties.Resources.Icon;
    //    private static Image _LoadingImage = Properties.Resources.寬箭頭;
    //    private static Image _ErrorImage = Properties.Resources.紅箭頭;
    //    private static Image _ShadowImage = Properties.Resources.寬箭頭陰影;
    //    internal static void SetupLoadingDisplay()
    //    {
    //        var _MinimalLoadingTime = 0;
    //        var b = new Bitmap(30, 30);
    //        var g = Graphics.FromImage(b);
    //        g.TranslateTransform(14.2F, 14.5F);
    //        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
    //        var gshadow = Graphics.FromImage(b);
    //        gshadow.TranslateTransform(15.7F, 15.5F);

    //        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    //        timer.Interval = 75;
    //        timer.Tick += delegate
    //        {
    //            if (_RunningRequest == 0 && _MinimalLoadingTime == 0)
    //                timer.Stop();
    //            if (_RunningRequest <= 0 && _MinimalLoadingTime == 0 && _TransferSuccess)
    //            {
    //                FISCA.Presentation.MotherForm.StartMenu.Image = _NormalImage;
    //            }
    //            else
    //            {
    //                float _Speed = 35;
    //                if (_TransferTimes > 0)
    //                    _Speed = (((float)_TransferBytes / 1024F / ((float)_TransferTimes / 1000))) / 25F * 15;
    //                if (_Speed > 35)
    //                    _Speed = 35;
    //                if (_MinimalLoadingTime > 0) _MinimalLoadingTime = _MinimalLoadingTime - 1;
    //                if (_TransferSuccess)
    //                {

    //                    gshadow.Clear(Color.Transparent);
    //                    g.Clear(Color.Transparent);
    //                    gshadow.RotateTransform(_Speed);
    //                    gshadow.DrawImage(_ShadowImage, -15.0F, -15.0F, 30.0F, 30.0F);
    //                    gshadow.RotateTransform(180);
    //                    gshadow.DrawImage(_ShadowImage, -15.0F, -15.0F, 30.0F, 30.0F);

    //                    g.RotateTransform(_Speed);
    //                    g.DrawImage(_LoadingImage, -15.0F, -15.0F, 30.0F, 30.0F);
    //                    g.RotateTransform(180);
    //                    g.DrawImage(_LoadingImage, -15.0F, -15.0F, 30.0F, 30.0F);
    //                    FISCA.Presentation.MotherForm.StartMenu.Image = b;
    //                }
    //                else
    //                {
    //                    gshadow.Clear(Color.Transparent);
    //                    g.Clear(Color.Transparent);

    //                    gshadow.RotateTransform(_Speed / 2.0F);
    //                    gshadow.DrawImage(_ShadowImage, -15.0F, -15.0F, 30.0F, 30.0F);
    //                    gshadow.RotateTransform(180);
    //                    gshadow.DrawImage(_ShadowImage, -15.0F, -15.0F, 30.0F, 30.0F);

    //                    g.RotateTransform(_Speed / 2.0F);
    //                    g.DrawImage(_ErrorImage, -15.0F, -15.0F, 30.0F, 30.0F);
    //                    g.RotateTransform(180);
    //                    g.DrawImage(_ErrorImage, -15.0F, -15.0F, 30.0F, 30.0F);
    //                    FISCA.Presentation.MotherForm.StartMenu.Image = b;
    //                    FISCA.Presentation.MotherForm.SetStatusBarMessage("網路連線異常" + (_WebExceptionMessage == "" ? "" : ("(" + _WebExceptionMessage + ")")) + "，請檢查您的網路連線狀態。");
    //                }
    //            }
    //        };
    //        System.Windows.Forms.Application.Idle += delegate
    //        {
    //            if (_RunningRequest > 0 && !timer.Enabled)
    //            {
    //                _MinimalLoadingTime = 20;//每次轉動都至少轉1.5秒
    //                timer.Start();
    //            }
    //        };
    //    }

    //    private static DSConnection _DSConnection = new DSConnection();
    //    /// <summary>
    //    /// 授權登入系統
    //    /// </summary>
    //    /// <param name="fileName">授權檔路徑</param>
    //    /// <returns>授權是否成功</returns>
    //    public static void SetLicense(string fileName)
    //    {
    //        SetLicense(new FileStream(fileName, FileMode.Open));
    //    }
    //    /// <summary>
    //    /// 設定授權登入系統
    //    /// </summary>
    //    /// <param name="stream">授權檔串流</param>
    //    /// <returns>授權是否成功</returns>
    //    public static void SetLicense(Stream stream)
    //    {
    //        ServicePointManager.ServerCertificateValidationCallback = delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    //        {
    //            //只要是「CN=intellischool Root Authority」發的憑證都信任。
    //            return (certificate.Issuer == "CN=intellischool Root Authority");
    //        };
    //        _DSConnection = new DSConnection();

    //        byte[] CryptoKey = Encoding.UTF8.GetBytes("IntelliSchool SmartSchool Cryptography Key");
    //        byte[] cipher = new byte[stream.Length];
    //        stream.Read(cipher, 0, Convert.ToInt32(stream.Length));
    //        stream.Close();

    //        byte[] plain = ProtectedData.Unprotect(cipher, CryptoKey, DataProtectionScope.LocalMachine);
    //        string xmlString = Encoding.UTF8.GetString(plain);

    //        DSXmlHelper hlplicense = new DSXmlHelper(DSXmlHelper.LoadXml(xmlString));
    //        DSXmlHelper apptoken = new DSXmlHelper("SecurityToken");
    //        apptoken.SetAttribute(".", "Type", "Application");
    //        apptoken.AddElement(".", hlplicense.GetElement("ApplicationKey"));

    //        var accessPoint = hlplicense.GetText("AccessPoint");
    //        var applicationToken = new ApplicationToken(apptoken.BaseElement);
    //        _DSConnection.Connect(accessPoint, applicationToken);
    //        Framework.BugReporter.SetRunTimeMessage("DsnsName", accessPoint);
    //    }
    //    /// <summary>
    //    /// 登入使用者
    //    /// </summary>
    //    /// <param name="account">帳號</param>
    //    /// <param name="password">密碼</param>
    //    /// <returns>登入成功</returns>
    //    public static void Login(string account, string password)
    //    {
    //        DSXmlHelper request = new DSXmlHelper("Request");
    //        request.AddElement("Condition");
    //        request.AddElement("Condition", "UserName", account.ToUpper());
    //        request.AddElement("Condition", "Password", PasswordHash.Compute(password));

    //        DSXmlHelper response = _DSConnection.SendRequest("SmartSchool.Personal.CheckUserPassword", request);

    //        if (response.GetElements("User").Length <= 0)
    //            throw new Exception("使用者帳號或密碼錯誤。");

    //        XmlElement user = response.GetElement("User");
    //        if (user.GetAttribute("IsSysAdmin") == "1")
    //            _is_sys_admin = true;
    //        else
    //            _is_sys_admin = false;

    //        Framework.BugReporter.SetRunTimeMessage("LoginUser", account);
    //        IsLogined = true;
    //        UserAccount = account;

    //        //負責儲存使用者個人設定。
    //        User.Configuration = new User.UserConfigManager(new ConfigProvider_User(), account);
    //        //負責儲存應用程式設定。
    //        App.Configuration = new ConfigurationManager(new ConfigProvider_App());
    //        //負責儲存全域設定。
    //        Global.Configuration = new Global.GlobalConfigManager(new ConfigProvider_Global(), true);
    //        //可讀寫的全域組態。
    //        Global.ConfigurationWritable = new Global.GlobalConfigManager(new ConfigProvider_Global(), false);
    //        //負責資料庫變動的通知物件。
    //        App.DBMonitor = new DBChangeMonitor(10, new PTChangeSetProvider());
    //    }
    //    /// <summary>
    //    /// 取得登入帳號是否為系統管理員帳號
    //    /// </summary>
    //    public static bool IsSysAdmin
    //    {
    //        get { return _is_sys_admin; }
    //    }
    //    /// <summary>
    //    /// 使用者已經成功登入系統
    //    /// </summary>
    //    public static bool IsLogined { get; internal set; }
    //    /// <summary>
    //    /// 呼叫DSAService
    //    /// </summary>
    //    /// <param name="service">ServiceName</param>
    //    /// <param name="req">DSRequest</param>
    //    /// <returns>DSResponse</returns>
    //    public static DSResponse CallService(string service, DSRequest req)
    //    {
    //        if (!IsLogined) throw new Exception("尚未登入系統。");
    //        _RunningRequest++;
    //        var failedAutoRetry = false;
    //        var stackTrace = new List<string>();
    //        foreach (StackFrame frame in (new StackTrace()).GetFrames())//呼叫堆疊
    //        {
    //            Type type = frame.GetMethod().ReflectedType;
    //            foreach (object var in frame.GetMethod().GetCustomAttributes(true))//呼叫的函數是否為AutoRetryOnWebException
    //            {
    //                if (var is AutoRetryOnWebExceptionAttribute)
    //                {
    //                    failedAutoRetry = true;
    //                    break;
    //                }
    //            }
    //            foreach (object var in type.GetCustomAttributes(true))//呼叫的類別是否為AutoRetryOnWebException
    //            {
    //                if (var is AutoRetryOnWebExceptionAttribute)
    //                {
    //                    failedAutoRetry = true;
    //                    break;
    //                }
    //            }
    //        }

    //        DSResponse resp = null;
    //        while (true)//呼叫成功立刻break，發生網路錯誤且自動重試時則continue
    //        {
    //            try
    //            {
    //                _LockConnection.WaitOne();
    //                DateTime d1 = DateTime.Now;
    //                resp = _DSConnection.SendRequest(service, req, 60000);  //60秒才  Timeout
    //                long binaryLength = resp.GetRawBinary().LongLength + (req == null ? 0 : req.GetRawBinary().LongLength);//計算傳輸資料量
    //                int milliseconds = ((TimeSpan)(DateTime.Now - d1)).Milliseconds;//計算花費時間
    //                _TransferBytes = _TransferBytes + (ulong)resp.GetRawBinary().Length;
    //                _TransferTimes = _TransferTimes + (ulong)milliseconds;
    //                _TransferSuccess = true;
    //            }
    //            catch (Exception e)
    //            {
    //                var isWebException = false;
    //                var currentException = e;
    //                while (currentException != null)
    //                {
    //                    if (currentException is WebException)
    //                    {
    //                        isWebException = true;
    //                        _WebExceptionMessage = currentException.Message;
    //                        break;
    //                    }
    //                    currentException = currentException.InnerException;
    //                }
    //                if (isWebException)
    //                {
    //                    //回報網路
    //                    Framework.BugReporter.ReportException(e, false);
    //                    if (failedAutoRetry)
    //                    {
    //                        _TransferSuccess = false;
    //                        continue;
    //                    }
    //                    else
    //                    {
    //                        _LockConnection.Reset();
    //                        if (Framework.MsgBox.Show("網路連線異常" + (_WebExceptionMessage == "" ? "" : ("(" + _WebExceptionMessage + ")")) + "，系統必須關閉。\n您可能正在新增或修改資料，\n系統因網路環境錯誤無法判斷您正進行的作業是否成功儲存，\n繼續使用將無法保證資料的正確，\n\n建議您在重新登入系統後檢查資料的變更是否完成。\n\n是否重新登入系統?", "網路連線異常", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
    //                           == DialogResult.Yes)
    //                        {
    //                            Application.Restart();
    //                        }
    //                        else
    //                        {
    //                            Application.Exit();
    //                        }
    //                    }
    //                }
    //                else
    //                {
    //                    _RunningRequest--;
    //                    throw e;
    //                }
    //            }
    //            break;
    //        }
    //        _RunningRequest--;
    //        return resp;
    //    }
    //    /// <summary>
    //    /// 登入帳號
    //    /// </summary>
    //    public static string UserAccount { get; private set; }

    //    /// <summary>
    //    /// 登入的主機名稱。
    //    /// </summary>
    //    public static string AccessPoint { get { return _DSConnection.AccessPoint.Name; } }
    //}


    internal class ApplicationToken : ISecurityToken
    {
        public ApplicationToken(XmlElement token)
        {
            _token_content = token;
        }

        private XmlElement _token_content;

        #region ISecurityToken 成員

        public System.Xml.XmlElement GetTokenContent()
        {
            return _token_content;
        }

        public string TokenType
        {
            get { return "Application"; }
        }

        public bool Reuseable
        {
            get { return false; }
        }

        #endregion
    }
    /// <summary>
    /// 讓大家一起用吧。
    /// </summary>
    public static class PasswordHash
    {
        public static string Compute(string password)
        {
            SHA1Managed sha1 = new SHA1Managed();
            Encoding utf8 = Encoding.UTF8;

            byte[] hashResult = sha1.ComputeHash(utf8.GetBytes(password));

            return Convert.ToBase64String(hashResult);
        }
    }
}
