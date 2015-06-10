using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.BLL
{
    public class SendMsg
    {
        private readonly Eyousoft_yhq.SQLServerDAL.SendMsg dal = new Eyousoft_yhq.SQLServerDAL.SendMsg();
        public SendMsg()
        { }
        /// <summary>
        /// 判断当前用户是否已经领取优惠码
        /// </summary>
        /// <param name="uid">用户名</param>
        /// <param name="pid">产品编号</param>
        /// <returns></returns>
        public bool exists(string uid, string pid, string FavourCode)
        {
            return dal.Exists(uid, pid,FavourCode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Eyousoft_yhq.Model.SendMSG model)
        {
            if (string.IsNullOrEmpty(model.SendNum) || string.IsNullOrEmpty(model.SendText)) return false;
            return dal.Add(model);
        }

        /// <summary>
        /// 统计次数
        /// </summary>
        public int countNum(string id)
        {
            if (string.IsNullOrEmpty(id)) return 0;
            return dal.countNum(id);
        }      
        /// <summary>
        /// 统计产品类别领取次数
        /// </summary>
        public int countTypeNum(string id)
        {
            if (string.IsNullOrEmpty(id)) return 0;
            return dal.countTypeNum(id);
        }

        /// <summary>
        /// 获取发送列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.SendMSG> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.serSendMSG serModel)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, serModel);
        }

    }
}
