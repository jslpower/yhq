using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    //常旅客
   public class Passenger
    {
        /// <summary>
        /// 常旅客ID
        /// </summary>
       public string PsrID { get; set; }
        /// <summary>
       /// 客户姓名
        /// </summary>
       public string CusName { get; set; }
        /// <summary>
       /// 乘机人姓名
        /// </summary>
       public string PsrName { get; set; }
        /// <summary>
       /// 性别
        /// </summary>
       public string Sex { get; set; }
        /// <summary>
       /// 乘机人类型
        /// </summary>
       public string PsrType { get; set; }
        /// <summary>
       /// 证件类型
        /// </summary>
       public string IdentityType { get; set; }
        /// <summary>
       /// 证件号码
        /// </summary>
       public string IdentityCard { get; set; }
        /// <summary>
       /// 出生日期
        /// </summary>
       public DateTime Birthday { get; set; }
        /// <summary>
       /// 手机号码
        /// </summary>
       public string Mobile { get; set; }
        /// <summary>
       /// 积分账户
        /// </summary>
       public string AccountName { get; set; }
        /// <summary>
       /// 备注
        /// </summary>
       public string Remark { get; set; }
        /// <summary>
       /// 总条数
        /// </summary>
       public int RecordCount { get; set; }

    }


   public class OrderPassenger
   {
       /// <summary>
       /// 订单号
       /// </summary>
       public int  ID { get; set; }
       /// <summary>
       /// 订单号
       /// </summary>
       public string OrderCode { get; set; }
       /// <summary>
       /// 乘机人姓名
       /// </summary>
       public string PsrName { get; set; }
   
       /// <summary>
       /// 乘机人类型
       /// </summary>
       public PerType PsrType { get; set; }
       /// <summary>
       /// 证件类型
       /// </summary>
       public CartType IdentityType { get; set; }
       /// <summary>
       /// 证件号码
       /// </summary>
       public string IdentityCard { get; set; }

       /// <summary>
       /// 手机号码
       /// </summary>
       public string Mobile { get; set; }

     
   }
}
