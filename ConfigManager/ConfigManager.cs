using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

///
/// Version 3.2
///
namespace RuFramework.Config
{
    // AppDataPath for select the save path of config file
    public enum AppDataPath { Local, Roaming, Common, ExePath };
    public static class ConfigManager
    {
        #region AppDataPath
        /// <summary>
        /// Get Path Local, Roaming, Common or ExePath
        /// Default is Roaming
        /// </summary>
        /// <param name="appDataPointer"></param>
        /// <returns>Filename with path</returns>
        public static string GetAppDataPath(AppDataPath appDataPointer = AppDataPath.Roaming)
        {
            string ConfigPath = null;
            try
            {
                switch (appDataPointer)
                {
                    case AppDataPath.Local:
                        // C:\users\UserName\AppData\Local\ProductName\ProductName\ProductVersion\ProductName.Config
                        ConfigPath = Application.LocalUserAppDataPath + "\\" + Application.ProductName + ".config";
                        break;
                    case AppDataPath.Roaming:
                        // C:\users\UserName\AppData\Roaming\ProductName\ProductName\ProductVersion\ProductName.Config
                        ConfigPath = Application.UserAppDataPath + "\\" + Application.ProductName + ".config";
                        break;
                    case AppDataPath.Common:
                        // C:\ProgramData\ProductName\ProductName\ProductVersion\ProductName.Config
                        ConfigPath = Application.CommonAppDataPath + "\\" + Application.ProductName + ".config";
                        break;
                    case AppDataPath.ExePath:
                        // ProductSaveDirectory\ProductName.Config, only PortableApps
                        ConfigPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + Application.ProductName + ".config";
                        break;
                    default: // Roaming
                        ConfigPath = Application.UserAppDataPath + "\\" + Application.ProductName + ".config";
                        break;
                }
                return ConfigPath;
            }
            catch
            {
                return null;
            }
        }
        #endregion
        #region Read/Save
        /// <summary>
        /// Read config date by Path to config file or default by roaming
        /// </summary>
        /// <param name="ConfigPath">Config file name or nothig, default roaming</param>
        /// <returns>Config data</returns>
        public static AppSettings Read(AppDataPath appDataPath = AppDataPath.Roaming)
        {
            AppSettings appSettings = new AppSettings();
            try
            {
                string ConfigPath = GetAppDataPath(appDataPath);
                Regex r = new Regex(@"^(([a-zA-Z]\:)|(\\))(\\{1}|((\\{1})[^\\]([^/:*?<>""|]*))+)$");
                if (r.IsMatch(ConfigPath))
                {

                    using (FileStream fileStream = new FileStream(ConfigPath.ToString(), FileMode.Open))
                    {
                        var serializer = new XmlSerializer(typeof(AppSettings));
                        appSettings = (AppSettings)serializer.Deserialize(fileStream);
                        fileStream.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Error: Bad finename");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " but is new created!");
            }
            return appSettings;
        }
        /// <summary>
        /// Save config data with Path to config file
        /// </summary>
        /// <param name="appSettings">Config data</param>
        /// <param name="ConfigPath">Config file name or nothig, default roaming</param>
        public static void Save(AppSettings appSettings, AppDataPath appDataPath = AppDataPath.Roaming)
        {
            string ConfigPath = GetAppDataPath(appDataPath);
            try
            {
                if (ConfigPath == null) ConfigPath = Application.UserAppDataPath + "\\" + Application.ProductName + ".config";
                Regex r = new Regex(@"^(([a-zA-Z]\:)|(\\))(\\{1}|((\\{1})[^\\]([^/:*?<>""|]*))+)$");
                if (r.IsMatch(ConfigPath))
                {
                    using (StreamWriter streamWriter = new StreamWriter(ConfigPath))
                    {
                        using (XmlWriter xmlWriter = XmlWriter.Create(streamWriter))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                            serializer.Serialize(xmlWriter, appSettings);
                        }
                        streamWriter.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not write file to disk. Original error: " + ex.InnerException.InnerException.Message);
            }
        }
        #endregion

    }
}