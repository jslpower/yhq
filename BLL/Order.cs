using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.BLL
{
    public class Order
    {
        Eyousoft_yhq.SQLServerDAL.Order dal = new Eyousoft_yhq.SQLServerDAL.Order();
        public Order() { }


        /// <summary>
        /// 判断确认码是否存在
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public bool Exists(string Code)
        {
            if (string.IsNullOrEmpty(Code)) return false;
            return dal.Exists(Code);
        }
        /// <summary>
        ///  增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Eyousoft_yhq.Model.Order model)
        {
            model.OrderID = Guid.NewGuid().ToString();
            if (string.IsNullOrEmpty(model.MemberID) ||
                string.IsNullOrEmpty(model.ProductID)) return 0;
            return dal.Add(model);
        }
        public bool updateContract(Eyousoft_yhq.Model.Order model)
        {

            if (string.IsNullOrEmpty(model.OrderID)) return false;
            return dal.updateContract(model);
        }
        /// <summary>
        /// 设置寄送地址
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool setAddressID(Eyousoft_yhq.Model.Order model)
        {
            if (string.IsNullOrEmpty(model.OrderID)) return false;
            return dal.setAddressID(model);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(Eyousoft_yhq.Model.Order model)
        {
            if (string.IsNullOrEmpty(model.OrderID)) return 0;
            if (model.SendFile != null && model.SendFile.Count > 0)
            {
                for (int i = 0; i < model.SendFile.Count; i++)
                {
                    model.SendFile[i].ItemId = model.OrderID;
                }
            }
            return dal.Update(model);
        }
        /// <summary>
        /// 保存行程单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SavePDF(Eyousoft_yhq.Model.Order model)
        {
            if (string.IsNullOrEmpty(model.OrderID)) return 0;
            if (model.SendFile != null && model.SendFile.Count > 0)
            {
                for (int i = 0; i < model.SendFile.Count; i++)
                {
                    model.SendFile[i].ItemId = model.OrderID;
                }
            }
            return dal.SavePDF(model);
        }      /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public int Delete(string OrderID)
        {
            if (string.IsNullOrEmpty(OrderID)) return 0;
            return dal.Delete(OrderID);
        }
        /// <summary>
        /// 修改订单支付状态
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public int UpdatePayState(Eyousoft_yhq.Model.Order model)
        {
            if (string.IsNullOrEmpty(model.OrderID)) return 0;
            return dal.UpdatePayState(model);
        }
        /// <summary>
        /// 获取一个订单
        /// </summary>
        /// <param name="OrderID">订单编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.Order GetModel(string OrderID)
        {
            if (string.IsNullOrEmpty(OrderID)) return null;
            return dal.GetModel(OrderID);
        }
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="PageSize">每页显示条数</param>
        /// <param name="PageIndex">当前页数</param>
        /// <param name="RecordCount">总页数</param>
        /// <param name="serModel">搜索实体</param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.Order> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.MSearchOrder serModel)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, serModel);
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.Order> GetScanList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.MSearchOrder serModel)
        {
            return dal.GetScanList(PageSize, PageIndex, ref RecordCount, serModel);
        }

        public IList<Eyousoft_yhq.Model.Order> GetList(Eyousoft_yhq.Model.MSearchOrder serModel)
        {
            return dal.GetList(serModel);
        }


        /// <summary>
        /// 获取返佣
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.Order> GetFYList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.MSearchOrder serModel)
        {
            return dal.GetFYList(PageSize, PageIndex, ref RecordCount, serModel);
        }
        /// <summary>
        /// 保存支付状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SavePayState(Eyousoft_yhq.Model.Order model)
        {
            if (string.IsNullOrEmpty(model.OrderID)) return 0;
            return dal.SavePayState(model);
        }
        /// <summary>
        /// 保存返佣金额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveReMoney(Eyousoft_yhq.Model.Order model)
        {
            if (string.IsNullOrEmpty(model.OrderID)) return 0;
            return dal.SaveReMoney(model);
        }






        /// <summary>
        ///  修改消费状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool setConSumState(string orderid, string UserId)
        {
            if (string.IsNullOrEmpty(orderid) || string.IsNullOrEmpty(UserId)) return false;
            return dal.setConSumState(orderid, UserId);
        }
        /// <summary>
        ///  修改消费状态，结算方式
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool setConSumState(string orderid, string UserId, Eyousoft_yhq.Model.JSfangshi fangshi, string mobNo)
        {
            if (string.IsNullOrEmpty(orderid) || string.IsNullOrEmpty(UserId)) return false;
            return dal.setConSumState(orderid, UserId, fangshi, mobNo);
        }

        public bool getOrderExist(string orderid)
        {
            if (string.IsNullOrEmpty(orderid)) return false;
            return dal.getOrderExist(orderid);
        }
        /// <summary>
        /// 账户支付订单
        /// </summary>
        /// <param name="dingdan">订单</param>
        /// <param name="huiyuanbianhao">支付人</param>
        /// <returns></returns>
        public int XiaoFei(Eyousoft_yhq.Model.Order dingdan, string huiyuanbianhao)
        {
            if (string.IsNullOrEmpty(dingdan.OrderID)
                || string.IsNullOrEmpty(huiyuanbianhao)) return 0;
            return dal.XiaoFei(dingdan, huiyuanbianhao);
        }

    }
}
