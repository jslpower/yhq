using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Xml;

namespace Eyousoft_yhq.SQLServerDAL
{
    /// <summary>
    /// 数据层访问基类
    /// 读取配置文件，生成数据库可用连接
    /// </summary>
    public class DALBase
    {
        private readonly Database _systemstore = DatabaseFactory.CreateDatabase("SystemStore");

        /// <summary>
        /// 系统库
        /// </summary>
        protected Database SystemStore
        {
            get
            {
                return _systemstore;
            }
        }

        /// <summary>
        /// 数据库CHAR(1)转换成布尔类型，1→true 其它→false
        /// </summary>
        /// <param name="s">CHAR(1)</param>
        /// <returns></returns>
        public bool GetBoolean(string s)
        {
            return s == "1" ? true : false;
        }

        /// <summary>
        /// 将bool转换成char(1) true:1 false:0
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string GetBooleanToStr(bool s)
        {
            return s ? "1" : "0";
        }

    }
}
