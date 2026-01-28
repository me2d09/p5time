using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace P5Time
{
    class Common
    {
        private const string rPath = "Software\\SVoCR\\P5Time";
        public static ConnectionSettings GetServerSettings()
        {
            ConnectionSettings con = new ConnectionSettings();

            RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey(rPath);

            con.Server = (string)regKeyAppRoot.GetValue("Server");
            con.UserId = (string)regKeyAppRoot.GetValue("UserId");
            con.Password = (string)regKeyAppRoot.GetValue("Password");
            con.Database = (string)regKeyAppRoot.GetValue("Database");
            regKeyAppRoot.Close();

            return con;
        }

        public static void SetServerSettings(ConnectionSettings con)
        {
            RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey(rPath);

            regKeyAppRoot.SetValue("Server", con.Server);
            regKeyAppRoot.SetValue("UserId", con.UserId);
            regKeyAppRoot.SetValue("Password", con.Password);
            regKeyAppRoot.SetValue("Database", con.Database);
            regKeyAppRoot.Close();
           
        }

        public static int? GetPohar()
        {
            RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey(rPath);
            int? i = (int?)regKeyAppRoot.GetValue("LastUsedPohar");
            regKeyAppRoot.Close();
            return i;
        }
        public static void SetPohar(int id_poharu)
        {
            RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey(rPath);
            regKeyAppRoot.SetValue("LastUsedPohar", id_poharu);
            regKeyAppRoot.Close();
        }

        public static bool AutoStart
        {
            get
            {
                RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey(rPath);
                bool b = false;
                try
                {
                    b = bool.Parse(regKeyAppRoot.GetValue("AutoStart").ToString());
                }
                catch (NullReferenceException)
                {
                    b = false;
                }
                regKeyAppRoot.Close();
                return b;
            }
            set
            {
                RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey(rPath);
                regKeyAppRoot.SetValue("AutoStart", value);
                regKeyAppRoot.Close();
            }
        }

        public static int LastZavod
        {
            get
            {
                RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey(rPath);
                int b = 0;
                try
                {
                    b = int.Parse(regKeyAppRoot.GetValue("LastZavod").ToString());
                }
                catch (NullReferenceException)
                {
                    b = 0;
                }
                regKeyAppRoot.Close();
                return b;
            }
            set
            {
                if (value != 0)
                {
                    RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey(rPath);
                    regKeyAppRoot.SetValue("LastZavod", value, RegistryValueKind.DWord);
                    regKeyAppRoot.Close();
                }
            }
        }

        public static int LastTab
        {
            get
            {
                RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey(rPath);
                int b = 0;
                try
                {
                    b = int.Parse(regKeyAppRoot.GetValue("LastTab").ToString());
                }
                catch (NullReferenceException)
                {
                    b = 0;
                }
                regKeyAppRoot.Close();
                return b;
            }
            set
            {
                if (value != 0)
                {
                    RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey(rPath);
                    regKeyAppRoot.SetValue("LastTab", value, RegistryValueKind.DWord);
                    regKeyAppRoot.Close();
                }
            }
        }


        public static string ExcelTemplate
        {
            get
            {
                RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey(rPath);
                string b = "";
                try
                {
                    b = regKeyAppRoot.GetValue("ExcelTemplate").ToString();
                }
                catch (NullReferenceException)
                {
                    b = "";
                }
                regKeyAppRoot.Close();
                return b;
            }
            set
            {
                if (value != "")
                {
                    RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey(rPath);
                    regKeyAppRoot.SetValue("ExcelTemplate", value, RegistryValueKind.String);
                    regKeyAppRoot.Close();
                }
            }
        }

        public static string MysqldumpPath
        {
            get
            {
                RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey(rPath);
                string b = "";
                try
                {
                    b = regKeyAppRoot.GetValue("MysqldumpPath").ToString();
                }
                catch (NullReferenceException)
                {
                    b = "";
                }
                regKeyAppRoot.Close();
                return b;
            }
            set
            {
                if (value != "")
                {
                    RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey(rPath);
                    regKeyAppRoot.SetValue("MysqldumpPath", value, RegistryValueKind.String);
                    regKeyAppRoot.Close();
                }
            }
        }


        public class ConnectionSettings
        {
            public ConnectionSettings()
            { }

            public ConnectionSettings(string Server, string UserId, string Password, string Database)
            {
                this.Server = Server;
                this.UserId = UserId;
                this.Password = Password;
                this.Database = Database;
            }
            public string Server;
            public string UserId;
            public string Password;
            public string Database;
        }
    }
}
