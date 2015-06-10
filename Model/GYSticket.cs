using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    public class GYSticket
    {


        /// <summary>
        /// 编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CusName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public sexType CusSex { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string CusMob { get; set; }
        /// <summary>
        /// 机票编号
        /// </summary>
        public string PlaneTicket { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string OpertorID { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public TickOrderState orderState { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public PaymentState payState { get; set; }


    }
    public class GysTicketSer
    {
        /// <summary>
        /// 操作员
        /// </summary>
        public string OpertorID { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string cusName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string cusMob { get; set; }
        /// <summary>
        /// 机票编号
        /// </summary>
        public string tickNO { get; set; }

    }

}
