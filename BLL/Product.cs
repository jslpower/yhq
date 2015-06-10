using System;
using System.Data;
using System.Collections.Generic;
using Eyousoft_yhq.Model;
namespace Eyousoft_yhq.BLL
{
    /// <summary>
    /// 产品表
    /// </summary>
    public partial class Product
    {
        //private readonly IProduct dal = DataAccess.CreateProduct();

        Eyousoft_yhq.SQLServerDAL.Product dal = new Eyousoft_yhq.SQLServerDAL.Product();

        public Product()
        { }
        #region  成员方法


        public bool Exists(Eyousoft_yhq.Model.Product model)
        {
            return dal.Exists(model);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Eyousoft_yhq.Model.Product model)
        {
            model.ProductID = Guid.NewGuid().ToString();
            if (model.AttachList != null && model.AttachList.Count > 0)
            {
                for (int i = 0; i < model.AttachList.Count; i++)
                {
                    model.AttachList[i].ItemId = model.ProductID;
                }
            }
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Eyousoft_yhq.Model.Product model)
        {
            if (model == null || string.IsNullOrEmpty(model.ProductID)) return false;
            if (model.AttachList != null && model.AttachList.Count > 0)
            {
                for (int i = 0; i < model.AttachList.Count; i++)
                {
                    model.AttachList[i].ItemId = model.ProductID;
                }
            }
            return dal.Update(model);

        }
        /// <summary>
        /// 下架产品
        /// </summary>
        /// <param name="ProductID">产品编号</param>
        /// <returns></returns>
        public bool UpdateProduteState(string[] ProductID)
        {
            if (ProductID.Length < 1) return false;
            return dal.UpdateProduteState(ProductID);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(string[] ProductID)
        {
            if (ProductID.Length < 1) return 0;
            return dal.Delete(ProductID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eyousoft_yhq.Model.Product GetModel(string ProductID)
        {
            if (string.IsNullOrEmpty(ProductID)) return null;
            return dal.GetModel(ProductID);
        }
      
        /// <summary>
        /// 返回分页列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.Product> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.SerProduct serModel)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, serModel);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="serModel">搜索实体</param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.Product> GetList(Eyousoft_yhq.Model.SerProduct serModel)
        {
            return dal.GetList(serModel);
        }

        /// <summary>
        /// 产品审核-审核，返回1成功，其它失败
        /// </summary>
        /// <param name="chanPinIds">产品编号集合</param>
        /// <returns></returns>
        public int ChanPinShenHe(IList<string> chanPinIds)
        {
            if (chanPinIds == null || chanPinIds.Count == 0) return 0;

            return dal.ChanPinShenHe(chanPinIds, ChanPinShenHeStatus.已审核);
        }

        /// <summary>
        /// 产品审核-取消审核，返回1成功，其它失败
        /// </summary>
        /// <param name="chanPinIds">产品编号集合</param>
        /// <returns></returns>
        public int ChanPinShenHe_QuXiao(IList<string> chanPinIds)
        {
            if (chanPinIds == null || chanPinIds.Count == 0) return 0;

            return dal.ChanPinShenHe(chanPinIds, ChanPinShenHeStatus.未审核);
        }
        #endregion  成员方法
    }
}

