namespace Common.Config
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;

    /// <summary>
    /// Web.config 操作类
    /// Copyright (C) 2006-2008 ChenZhiRen(Adpost) All Right Reserved.
    /// 定义为不可继承性
    /// typeof(System.Configuration.NameValueFileSectionHandler).Assembly.FullName.ToString()
    /// </summary>
    public sealed class ConfigModel
    {
        /// <summary>
        /// 得到配置文件中的配置int信息
        /// </summary>
        /// <param name="key">KEY名</param>
        /// <returns>返回布尔值</returns>
        public static bool GetAppSettingBoolean(string key)
        {
            bool flag = false;
            string appSettingString = GetAppSettingString(key);
            if ((appSettingString != null) && (string.Empty != appSettingString))
            {
                try
                {
                    flag = bool.Parse(appSettingString);
                }
                catch (FormatException)
                {
                }
            }
            return flag;
        }

        /// <summary>
        /// 取得配置文件中 默认节点的 浮点数型
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static decimal GetAppSettingDecimal(string key)
        {
            decimal num = 0M;
            string appSettingString = GetAppSettingString(key);
            if ((appSettingString != null) && (string.Empty != appSettingString))
            {
                try
                {
                    num = decimal.Parse(appSettingString);
                }
                catch (FormatException)
                {
                }
            }
            return num;
        }

        /// <summary>
        /// 得到配置文件中的默认节点配置int信息
        /// </summary>
        /// <param name="key">KEY名</param>
        /// <returns>返回整数</returns>
        public static int GetAppSettingInt(string key)
        {
            int num = 0;
            string appSettingString = GetAppSettingString(key);
            if ((appSettingString != null) && (string.Empty != appSettingString))
            {
                try
                {
                    num = int.Parse(appSettingString);
                }
                catch (FormatException)
                {
                }
            }
            return num;
        }

        /// <summary>
        /// 取得默认节点的配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSettingString(string key)
        {
            string str = "";
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            if (appSettings[key] != null)
            {
                str = appSettings[key];
            }
            appSettings = null;
            return str;
        }

        /// <summary>
        /// 得到配置文件中的配置int信息
        /// </summary>
        /// <param name="SectionName">节点名称</param>
        /// <param name="key">KEY名</param>
        /// <returns>返回布尔值</returns>
        public static bool GetConfigBoolean(string SectionName, string key)
        {
            bool flag = false;
            string configString = GetConfigString(SectionName, key);
            if ((configString != null) && (string.Empty != configString))
            {
                try
                {
                    flag = bool.Parse(configString);
                }
                catch (FormatException)
                {
                }
            }
            return flag;
        }

        /// <summary>
        /// 得到配置文件中的配置decimal信息
        /// </summary>
        /// <param name="SectionName">节点名称</param>
        /// <param name="key">KEY名称</param>
        /// <returns>返回浮点数</returns>
        public static decimal GetConfigDecimal(string SectionName, string key)
        {
            decimal num = 0M;
            string configString = GetConfigString(SectionName, key);
            if ((configString != null) && (string.Empty != configString))
            {
                try
                {
                    num = decimal.Parse(configString);
                }
                catch (FormatException)
                {
                }
            }
            return num;
        }

        /// <summary>
        /// 得到配置文件中的配置int信息
        /// </summary>
        /// <param name="SectionName">节点名称</param>
        /// <param name="key">KEY名</param>
        /// <returns>返回整数</returns>
        public static int GetConfigInt(string SectionName, string key)
        {
            int num = 0;
            string configString = GetConfigString(SectionName, key);
            if ((configString != null) && (string.Empty != configString))
            {
                try
                {
                    num = int.Parse(configString);
                }
                catch (FormatException)
                {
                }
            }
            return num;
        }

        /// <summary>
        /// 取得配置文件中的字符串KEY
        /// </summary>
        /// <param name="SectionName">节点名称</param>
        /// <param name="key">KEY名</param>
        /// <returns>返回KEY值</returns>
        public static string GetConfigString(string SectionName, string key)
        {
            string str = "";
            if (SectionName != "")
            {
                try
                {
                    NameValueCollection section = (NameValueCollection) ConfigurationManager.GetSection(SectionName);
                    if (section[key] != null)
                    {
                        str = section[key];
                    }
                    section = null;
                }
                catch
                {
                }
            }
            return str;
        }

        /// <summary>
        /// 取得ConnectionStrings节点的配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnectionString(string key)
        {
            string connectionString = "";
            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
            if (connectionStrings[key] != null)
            {
                connectionString = connectionStrings[key].ConnectionString;
            }
            connectionStrings = null;
            return connectionString;
        }
    }
}

