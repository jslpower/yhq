using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Eyousoft_yhq.Model;

namespace Eyousoft_yhq.BLL
{
    public class BJiPiaoBaoCun
    {
        private readonly Eyousoft_yhq.SQLServerDAL.DJiPiaoBaoCun dal = new Eyousoft_yhq.SQLServerDAL.DJiPiaoBaoCun();

        /// <summary>
        /// 添加发送信息
        /// </summary>
        /// <param name="model">发送信息实体</param>
        /// <returns></returns>
        public bool Add(Eyousoft_yhq.Model.MJiPiaoBaoCun model)
        {
            if (model.IssueTime == DateTime.MinValue) return false;
            model.OrderID = Guid.NewGuid().ToString();
            return dal.Add(model);
        }
        /// <summary>
        /// 删除订单记录
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public bool Delete(string OrderID)
        {
            if (string.IsNullOrEmpty(OrderID)) return false;
            return dal.Delete(OrderID);
        }
        /// <summary>
        /// 设置支付状态
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public bool setState(MJiPiaoBaoCun model)
        {
            if (string.IsNullOrEmpty(model.OrderID)) return false;
            bool result = dal.setState(model);
            if (result && model.payState == TickOrderPayState.出票失败)
            {
                var order = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetModel(model.OrderID);
                if (order != null) new Eyousoft_yhq.BLL.Member().HuiYuangZzByID(order.OpeatorID, order.OrderPrice);
            }
            return result;

        }
        /// <summary>
        /// 设置支付状态
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public bool setStateAndCodeByOrderID(MJiPiaoBaoCun model)
        {
            if (string.IsNullOrEmpty(model.OrderCode)) return dal.setState(model);
            return dal.setStateAndCodeByOrderID(model);
        }
        /// <summary>
        /// 设置支付状态
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public bool setStateByOrderCode(MJiPiaoBaoCun model)
        {
            if (string.IsNullOrEmpty(model.OrderCode)) return false;
            bool result = dal.setStateByOrderCode(model);
            if (result && model.payState == TickOrderPayState.出票失败)
            {
                var order = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetModelByCode(model.OrderCode);
                if (order != null) new Eyousoft_yhq.BLL.Member().HuiYuangZzByID(order.OpeatorID, order.OrderPrice);
            }
            return result;
        }
        /// <summary>
        /// 设置支付状态
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public int ZhiFu(MJiPiaoBaoCun model)
        {
            if (string.IsNullOrEmpty(model.OpeatorID)
                || string.IsNullOrEmpty(model.OrderID)
                || model.OrderPrice <= 0) return 0;
            return dal.ZhiFu(model);
        }
        /// <summary>
        /// 获取一个订单
        /// </summary>
        /// <param name="OrderID">订单编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.MJiPiaoBaoCun GetModel(string OrderID)
        {
            if (string.IsNullOrEmpty(OrderID)) return null;
            return dal.GetModel(OrderID);
        }
        /// <summary>
        /// 获取一个订单列表
        /// </summary>
        /// <param name="serModel">订单编号</param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MJiPiaoBaoCun> GetList(Eyousoft_yhq.Model.MJiPiaoBaoCunSer serModel)
        {
            return dal.GetList(serModel);
        }
        /// <summary>
        /// 获取一个订单
        /// </summary>
        /// <param name="OrderID">订单号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.MJiPiaoBaoCun GetModelByCode(string OrderCode)
        {
            if (string.IsNullOrEmpty(OrderCode)) return null;
            return dal.GetModelByCode(OrderCode);
        }
        /// <summary>
        /// 返回列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MJiPiaoBaoCun> GetModeList(int PageSize, int PageIndex, ref int RecordCount, string userid)
        {
            if (string.IsNullOrEmpty(userid)) return null;
            return dal.GetModelList(PageSize, PageIndex, ref  RecordCount, userid);
        }
    }
}
