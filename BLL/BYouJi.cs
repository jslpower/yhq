using System;
using System.Collections.Generic;
using System.Text;
using Eyousoft_yhq.Model;

namespace Eyousoft_yhq.BLL
{
    public class BYouJi
    {
        private readonly Eyousoft_yhq.SQLServerDAL.DYouJi dal = new Eyousoft_yhq.SQLServerDAL.DYouJi();
        public BYouJi()
        { }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MYouJi model)
        {
            if (string.IsNullOrEmpty(model.HuiYuanId)) return false;
            model.YouJiId = Guid.NewGuid().ToString();
            bool result = dal.Add(model);
            return result;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string YouJiId)
        {
            if (string.IsNullOrEmpty(YouJiId)) return false;
            return dal.Delete(YouJiId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MYouJi GetModel(string YouJiId)
        {
            if (string.IsNullOrEmpty(YouJiId)) return null;
            return dal.GetModel(YouJiId);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<MYouJi> GetList(int PageSize, int PageIndex, ref int RecordCount, MYouJiSer serModel)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, serModel);
        }

        /// <summary>
        /// 获取会员游记条数
        /// </summary>
        /// <param name="huiYuanId">会员Id</param>
        /// <param name="times">最后查看时间</param>
        /// <returns></returns>
        public int GetYouJiNum(string huiYuanId)
        {
            if (string.IsNullOrEmpty(huiYuanId)) return 0;
            return dal.GetYouJiNum(huiYuanId);
        }
        /// <summary>
        /// 修改游记内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateModel(MYouJi model)
        {
            if (string.IsNullOrEmpty(model.YouJiId)) return false;
            return dal.UpdateModel(model);
        }
    }
}
