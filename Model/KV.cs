using System;
namespace Eyousoft_yhq.Model
{
    /// <summary>
    /// 公司信息
    /// </summary>
    public class MKV
    {
        public MKV() { }

        /// <summary>
        /// KEY
        /// </summary>
        public string K { get; set; }
        /// <summary>
        /// VALUE
        /// </summary>
        public string V { get; set; }

    }


    /// <summary>
    /// 公司信息设置
    /// </summary>
    public class MCompanySetting
    {
        /// <summary>
        /// 公司介绍
        /// </summary>
        public string CompanyIntroduce { get; set; }

        /// <summary>
        /// 关于我们
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// 诚聘英才
        /// </summary>
        public string Join { get; set; }

        /// <summary>
        /// 法律声明
        /// </summary>
        public string LegalNotices { get; set; }

        /// <summary>
        /// 版权信息
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// 统计代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 网站基本信息 Description
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// 网站基本信息 Keywords
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        ///网站基本信息 Title
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        ///网站基本信息 Logo
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// 剩余短信条数
        /// </summary>
        public int MsgNumber { get; set; }
    }

    public class MComLianMeng
    {
        /// <summary>
        /// 服务商
        /// </summary>
        public int Agent { get; set; }
        /// <summary>
        /// 交易量
        /// </summary>
        public int OorderCount { get; set; }
        /// <summary>
        /// 成交额
        /// </summary>
        public decimal SealMoney { get; set; }
    }
}

