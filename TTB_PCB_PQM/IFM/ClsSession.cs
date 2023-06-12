using DevExpress.XtraSplashScreen;
using IFM.Business.Dispatchers.SYS;
using IFM.Business.Implements;
using IFM.Common.Views;
using IFM.DataAccess.CQRS.Commands;
using IFM.DataAccess.CQRS.Queries;
using IFM.DataAccess.Extensions;
using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models;
using IFM.DataAccess.Models.SYS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace IFM
{
    public sealed class ClsSession
    {
        public static ClsSession App { get; } = new ClsSession();

        private ClsSession()
        {
            SplashScreen = new SplashScreenManager(typeof(DkWaitForm), new SplashFormProperties());

            // Khai báo kết nối
            string connectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connectionString = De_Encrypt.Decrypt(connectionString);
            // Sử dụng MySql
          // var connection = new DkMySqlConnection(connectionString);
            // Sử dụng PostgreSql
            var connection = new DkNpgsqlConnection(connectionString);
            Session = new DkSession(connection);

            Settings = new ClsSettings();
            FrmLogin = new frm_login();
            UserName = string.Empty;
            UserLang = string.Empty;

            _sw = new Stopwatch();

            DbServices = new SystemDispatcher(Session);
            DbServices.Executed += Services_Executed;
            DbServices.Executing += Services_Executing;

            FolderSettings = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "IFM");
            if (!Directory.Exists(FolderSettings))
            {
                Directory.CreateDirectory(FolderSettings);
            }
        }

        public frm_login FrmLogin { get; }
        public string UserLang { get; set; }
        public string UserName { get; set; }
        public string FolderSettings { get; }
        public IDkSession Session { get; set; }
        public ClsSettings Settings { get; set; }
        public SystemDispatcher DbServices { get; }
        public SplashScreenManager SplashScreen { get; }
        public List<sp_user_login> UserRoles { get; set; }

        public string Version
        {
            get
            {
                try
                {
                    Assembly entryAssembly = Assembly.GetExecutingAssembly();
                    if (!string.IsNullOrWhiteSpace(entryAssembly.Location))
                    {
                        FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(entryAssembly.Location);
                        return versionInfo.ProductVersion;
                    }
                    else
                    {
                        return entryAssembly.ImageRuntimeVersion;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return "1.0.0.0";
            }
        }
        
        private readonly Stopwatch _sw;

        public void LoadSettings()
        {
            try
            {
                string fileSettings = Path.Combine(FolderSettings, "setting.ini");
                if (File.Exists(fileSettings))
                {
                    string content = File.ReadAllText(fileSettings);
                    Settings = JsonConvert.DeserializeObject<ClsSettings>(content);
                }
            }
            catch (Exception ex)
            {
                Settings = new ClsSettings();
                Console.WriteLine(ex.Message);
            }
        }

        public void SaveSettings()
        {
            try
            {
                string fileSettings = Path.Combine(FolderSettings, "setting.ini");
                string content = JsonConvert.SerializeObject(Settings);
                File.WriteAllText(fileSettings, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IList<m_assignment> GetViews()
        {
            return DbServices.Query(new SystemGetViewsQuery()).ToList();
        }

        public int UpdateViews(params m_assignment[] views)
        {
            return DbServices.Execute(new SystemUpdateViewsCommand(views));
        }

        public bool Login(string user, string pass)
        {
            UserRoles = DbServices.Query(new SystemLoginQuery(user, pass)).ToList();
            var userRole = UserRoles.FirstOrDefault();
            UserName = userRole.user_name;
            UserLang = userRole.user_lang;
            return UserName.Length > 1;
        }

        private void Services_Executing(object sender, Type e)
        {
            _sw.Restart();
            Console.WriteLine($"[{DateTime.Now}] {e}");
        }

        private void Services_Executed(object sender, Type e)
        {
            _sw.Stop();
            Console.WriteLine($"[{DateTime.Now}] {e} - {_sw.ElapsedMilliseconds} ms");
        }
    }
}
