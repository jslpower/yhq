using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    public class ChouJiang
    {
        /// <summary>
        /// 抽奖编号
        /// </summary>
        public string ChouJiangID { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        public string LiuShuiHao { get; set; }
        /// <summary>
        /// 红包编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public string CaoZuoRenID { get; set; }
        /// <summary>
        /// 抽奖时间
        /// </summary>
        public DateTime ChouJiangShiJian { get; set; }
        /// <summary>
        /// 抽奖结果
        /// </summary>
        public ChouJiangJieGuo JieGuo { get; set; }
        /// <summary>
        /// 抽中点数
        /// </summary>
        public decimal DianShu { get; set; }
        /// <summary>
        /// 获得奖励方式
        /// </summary>
        public JiangLiFangShi FangShi { get; set; }

        #region 扩展
        /// <summary>
        /// 会员账号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string ContactName { get; set; }
        #endregion

    }

    public class ChouJiangSer
    {
        /// <summary>
        /// 操作人编号
        /// </summary>
        public string CaoZuoRenID { get; set; }
        /// <summary>
        /// 红包编号
        /// </summary>
        public string ID { get; set; }
    }


}
