using System;
using System.Collections.Generic;
using System.Text;

namespace EyouSoft.Model
{

    /// <summary>
    /// 旅游资讯类别
    /// </summary>
    public class MArticleClass
    {
        public MArticleClass() { }
        /// <summary>
        /// 类别编号
        /// </summary>
        public int ClassId { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 资讯类型
        /// </summary>
        public Eyousoft_yhq.Model.ArticleType IsSystem { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int SortRule { get; set; }
    }

    /// <summary>
    /// 旅游资讯排序字段
    /// </summary>
    public class TravelArticleOrderBy
    {
        /// <summary>
        /// 排序字段
        /// </summary>
        public Eyousoft_yhq.Model.TravelArticleFiledOrder FiledOrder { get; set; }
        /// <summary>
        /// 升降序
        /// </summary>
        public Eyousoft_yhq.Model.OrderBy OrderBy { get; set; }
    }

    /// <summary>
    /// 旅游资讯
    /// </summary>
    public class MTravelArticle
    {
        public MTravelArticle() { }

        /// <summary>
        /// 资讯编号
        /// </summary>
        public string ArticleID { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string ArticleTitle { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string ImgPath { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string ArticleText { get; set; }
        /// <summary>
        /// 关键词标签(,分隔)
        /// </summary>
        public string ArticleTag { get; set; }
        /// <summary>
        /// 标题文字颜色
        /// </summary>
        public string TitleColor { get; set; }
        /// <summary>
        /// 关键词(,分隔)
        /// </summary>
        public string KeyWords { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public int ClassId { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 咨询类别类型
        /// </summary>
        public Eyousoft_yhq.Model.ArticleType ArticleType { get; set; }

        /// <summary>
        /// 是否首页显示
        /// </summary>
        public bool? IsFrontPage { get; set; }
        /// <summary>
        /// 是否头条
        /// </summary>
        public bool? IsHot { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        public string OperatorId { get; set; }
        /// <summary>
        /// 操作员姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        public string LinkUrl { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        public int Click { get; set; }
        /// <summary>
        /// 排序规则:1低，2常规，3高
        /// </summary>
        public int SortRule { get; set; }
    }

    /// <summary>
    /// 旅游资讯
    /// </summary>
    public class MTravelArticleCX : MTravelArticle
    {
        public MTravelArticleCX() { }

        /// <summary>
        /// 时间开始
        /// </summary>
        public DateTime? IssueTimeBegin { get; set; }

        /// <summary>
        /// 时间结束
        /// </summary>
        public DateTime? IssueTimeEnd { get; set; }

        /// <summary>
        /// 资讯类型
        /// </summary>
        public Eyousoft_yhq.Model.ArticleType[] IsSystem { get; set; }

        /// <summary>
        /// 查询类别
        /// </summary>
        public string[] ZXtype { get; set; }
    }

    /// <summary>
    /// 旅游资讯留言
    /// </summary>
    public class MTravelArticleLY
    {
        public MTravelArticleLY() { }
        /// <summary>
        /// 留言编号
        /// </summary>
        public string LiuYanId { get; set; }
        /// <summary>
        /// 资讯编号
        /// </summary>
        public string ArticleID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string ArticleTitle { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string MemberID { get; set; }
        /// <summary>
        /// 会员账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 留言时间
        /// </summary>
        public DateTime LiuYanShiJian { get; set; }
        /// <summary>
        /// 留言内容
        /// </summary>
        public string LiuYanContet { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        public string HuiFuContet { get; set; }
        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsCheck { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public string OperatorId { get; set; }
        /// <summary>
        /// 审核人用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? IssueTime { get; set; }
    }
    /// <summary>
    /// 旅游资讯留言
    /// </summary>
    public class MTravelArticleLYCX
    {
        /// <summary>
        /// 资讯编号
        /// </summary>
        public string ArticleID { get; set; }
        /// <summary>
        /// 留言时间开始
        /// </summary>
        public DateTime? Stime { get; set; }
        /// <summary>
        /// 留言时间结束
        /// </summary>
        public DateTime? Etime { get; set; }
        /// <summary>
        /// 是否审核
        /// </summary>
        public bool? IsCheck { get; set; }
    }
}