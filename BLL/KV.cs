using System;
using System.Data;
using System.Collections.Generic;
using Eyousoft_yhq.Model;
namespace Eyousoft_yhq.BLL
{
    /// <summary>
    /// 公司信息栏目
    /// </summary>
    public partial class KV
    {
        private readonly Eyousoft_yhq.SQLServerDAL.DKV dal = new Eyousoft_yhq.SQLServerDAL.DKV();
        public KV()
        { }
        #region IKV 成员

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns> 
        public bool SetCompanySetting(MCompanySetting model)
        {
            return dal.SetCompanySetting(model);
        }

        /// <summary>
        /// 获取指定公司的配置信息
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="fileKey"></param>
        /// <returns></returns>
        public string GetValue(string K)
        {
            if (string.IsNullOrEmpty(K)) return null;
            return dal.GetValue(K);
        }

        /// <summary>
        /// 设置指定公司的配置信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="fieldKey">配置key</param>
        /// <param name="fieldValue">配置value</param>
        /// <returns></returns>
        public bool SetValue(string K, string V)
        {
            if (string.IsNullOrEmpty(K)) return false;
            return dal.SetValue(K, V);
        }

        /// <summary>
        /// 获取公司配置信息
        /// </summary>
        public MCompanySetting GetCompanySetting()
        {
            return dal.GetCompanySetting();
        }

        /// <summary>
        /// 获取联盟信息
        /// </summary>
        public MComLianMeng GetComLianMeng()
        {
            return dal.GetComLianMeng();
        }


        #endregion


    }
}

