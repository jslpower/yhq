using System;
using System.Collections.Generic;
using System.Text;
using Eyousoft_yhq.Model;

namespace Eyousoft_yhq.BLL
{
    public class BChouJiang
    {
        readonly Eyousoft_yhq.SQLServerDAL.DChouJiang dal = new Eyousoft_yhq.SQLServerDAL.DChouJiang();
        /// <summary>
        /// 判断当日用户是否抽奖
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool Exists(ChouJiang info)
        {
            if (string.IsNullOrEmpty(info.CaoZuoRenID)
                 || info.ChouJiangShiJian == DateTime.MinValue) return false;
            return dal.Exists(info);
        }

        /// <summary>
        /// 添加一条抽奖记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Insert(ChouJiang info)
        {
            info.ChouJiangShiJian = DateTime.Now;
            info.ChouJiangID = Guid.NewGuid().ToString();
            info.LiuShuiHao = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            int result = dal.Insert(info);
            if (result == 1)
            {
                var hongbao = new Eyousoft_yhq.BLL.BHongBao().GetInfo(info.ID);
                if (hongbao != null)
                {
                    new Eyousoft_yhq.BLL.BHongBao().Update(new HongBao() { HongBaoJinE = hongbao.HongBaoJinE - info.DianShu, ID = hongbao.ID });
                }
                var model = new Eyousoft_yhq.BLL.Member().GetModel(info.CaoZuoRenID);
                if (model != null)
                {
                    new Eyousoft_yhq.BLL.Member().setMoney(info.CaoZuoRenID, model.YuE + info.DianShu);
                }
            }
            return result;
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<ChouJiang> GetList(int PageSize, int PageIndex, ref int RecordCount, ChouJiangSer serModel)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, serModel);
        }

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<ChouJiang> GetList(ChouJiangSer serModel)
        {
            return dal.GetList(serModel);
        }

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public decimal getSumMoney(ChouJiangSer serModel)
        {
            return dal.getSumMoney(serModel);
        }

    }
}
