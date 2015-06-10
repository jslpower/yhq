using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    public class MConDetaile
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>
        public string HuiYuanID { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string HuiYuanName { get; set; }
        /// <summary>
        /// 交易号
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 交易时间
        /// </summary>
        public DateTime JiaoYiShiJian { get; set; }
        /// <summary>
        /// 消费方式
        /// </summary>
        public XFfangshi XFway { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string DingDanBianHao { get; set; }
        /// <summary>
        /// 消费对象
        /// </summary>
        public string JiaoYiDuiXiang { get; set; }
        /// <summary>
        /// 消费对象名称
        /// </summary>
        public string DuiXiangName { get; set; }
        /// <summary>
        /// 订单类别
        /// </summary>
        public DDleibie DDCarrtes { get; set; }
    
    }
}
