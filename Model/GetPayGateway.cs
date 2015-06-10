using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    //支付平台支持的支付方式
    public class GetPayGateway
    {
        /// <summary>
        /// 支付网关ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 支付网关
        /// </summary>
        public string PayGateway { get; set; }
        /// <summary>
        /// 支付网关名称
        /// </summary>
        public string PayGatewayName { get; set; }
        /// <summary>
        /// 支付网关的图片路径
        /// </summary>
        public string ImgUrl { get; set; }
      
  

    }
}
