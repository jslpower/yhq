using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.BLL
{
   public class BConDetaile
    {
       private readonly Eyousoft_yhq.SQLServerDAL.DConDetaile dal = new Eyousoft_yhq.SQLServerDAL.DConDetaile();

        /// <summary>
        /// 添加发送信息
        /// </summary>
        /// <param name="model">发送信息实体</param>
        /// <returns></returns>
        public int Add(Eyousoft_yhq.Model.MConDetaile model)
        {
           
           
            return dal.Add(model);
        }



        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MConDetaile> GetModelList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.MConDetaile serModel)
        {
            return dal.GetModelList(PageSize, PageIndex, ref RecordCount, serModel);
        }


         /// <summary>
        /// 获取所有帐户的充值和消费金额
        /// </summary>

        /// <returns></returns>
        public int GetTotalMoney(Eyousoft_yhq.Model.TotalMoney Tmoney)
        {
           
            return dal.GetTotalMoney(Tmoney);

        }

    
       
     
    }
}
