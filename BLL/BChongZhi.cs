using System;
using System.Collections.Generic;
using System.Text;
using Eyousoft_yhq.Model;

namespace Eyousoft_yhq.BLL
{
    public class BChongZhi
    {
        private readonly Eyousoft_yhq.SQLServerDAL.DChongZhi dal = new Eyousoft_yhq.SQLServerDAL.DChongZhi();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MChongZhi model)
        {
            return dal.Add(model);

        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MChongZhi GetModel(string ID)
        {
            if (string.IsNullOrEmpty(ID)) return null;
            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MChongZhi GetModelByOrderCode(string OrderCode)
        {
            Eyousoft_yhq.SQLServerDAL.Utils.WLog(OrderCode, "/log_1.txt");
            if (string.IsNullOrEmpty(OrderCode)) return null;
            return dal.GetModelByOrderCode(OrderCode);
        }
        /// <summary>
        /// 更新付款状态
        /// </summary>
        public int SheZhiZhiFus(string DingDanId, PaymentState state)
        {
            if (string.IsNullOrEmpty(DingDanId)) return 0;
            return dal.SheZhiZhiFus(DingDanId, state);
        }
        /// <summary>
        /// 根据交易号(订单号)更新订单状态
        /// </summary>
        public bool SheZhiZhiFuByOrderCode(string OrderCode, PaymentState state)
        {
            if (string.IsNullOrEmpty(OrderCode)) return false;
            bool result = dal.SheZhiZhiFuByOrderCode(OrderCode, state) > 0 ? true : false;
            if (result)
            {
                var zhifu = GetModelByOrderCode(OrderCode);
                if (zhifu == null) return false;
                var member = new Eyousoft_yhq.BLL.Member().GetModel(zhifu.OperatorID);
                if (member == null) return false;
                member.YuE = member.YuE + zhifu.OptMoney;
                return new Eyousoft_yhq.BLL.Member().UpdateYuE(member);


            }
            else
            {
                return result;
            }

        }
        /// <summary>
        /// 更新交易号
        /// </summary>
        /// <param name="dingdanid"></param>
        /// <param name="TradeNO"></param>
        /// <returns></returns>
        public bool UpdateTradeNO(string OrderCode, string TradeNO)
        {
            if (string.IsNullOrEmpty(OrderCode)
                || string.IsNullOrEmpty(TradeNO)) return false;
            return dal.UpdateTradeNO(OrderCode, TradeNO);
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<MChongZhi> GetList(int PageSize, int PageIndex, ref int RecordCount, MChongZhiSer serModel)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, serModel);
        }

    }
}
