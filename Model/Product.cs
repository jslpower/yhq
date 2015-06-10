using System;
namespace Eyousoft_yhq.Model
{
    /// <summary>
    /// 产品表
    /// </summary>
    [Serializable]
    public partial class Product
    {
        public Product()
        { }
        #region Model
        private string _productid;
        private string _productname;
        private int _producttype = 0;
        private DateTime? _tourdate;
        private decimal _marketprice;
        private decimal _appprice;
        private string _favourcode;
        private string _linktel;
        private string _productdis;
        private string _tourdis;
        private string _sendtourknow;
        private DateTime _valididate;
        private int _productstate;
        private bool _iseveryday;

        private System.Collections.Generic.IList<Eyousoft_yhq.Model.Attach> _attachlist;
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        /// <summary>
        /// 产品分类
        /// </summary>
        public int ProductType
        {
            set { _producttype = value; }
            get { return _producttype; }
        }
        /// <summary>
        /// 出团日期/上车结束时间
        /// </summary>
        public DateTime? TourDate
        {
            set { _tourdate = value; }
            get { return _tourdate; }
        }
        /// <summary>
        /// 市场价
        /// </summary>
        public decimal MarketPrice
        {
            set { _marketprice = value; }
            get { return _marketprice; }
        }
        /// <summary>
        /// APP价
        /// </summary>
        public decimal AppPrice
        {
            set { _appprice = value; }
            get { return _appprice; }
        }
        /// <summary>
        /// 微信码
        /// </summary>
        public string FavourCode
        {
            set { _favourcode = value; }
            get { return _favourcode; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string LinkTel
        {
            set { _linktel = value; }
            get { return _linktel; }
        }
        /// <summary>
        /// 产品介绍/车辆介绍/景点介绍
        /// </summary>
        public string ProductDis
        {
            set { _productdis = value; }
            get { return _productdis; }
        }
        /// <summary>
        /// 参考行程/上车地点/景点地址
        /// </summary>
        public string TourDis
        {
            set { _tourdis = value; }
            get { return _tourdis; }
        }
        /// <summary>
        /// 出团需知/使用需知
        /// </summary>
        public string SendTourKnow
        {
            set { _sendtourknow = value; }
            get { return _sendtourknow; }
        }
        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime ValidiDate
        {
            set { _valididate = value; }
            get { return _valididate; }
        }
        /// <summary>
        /// 产品状态(正常、下架...)
        /// </summary>
        public int ProductState
        {
            set { _productstate = value; }
            get { return _productstate; }
        }

        /// <summary>
        /// 附件列表
        /// </summary>
        public System.Collections.Generic.IList<Eyousoft_yhq.Model.Attach> AttachList
        {
            set { _attachlist = value; }
            get { return _attachlist; }
        }
        /// <summary>
        /// 是否天天发团
        /// </summary>
        public bool IsEveryDay
        {
            set { _iseveryday = value; }
            get { return _iseveryday; }
        }
        /// <summary>
        /// 是否热门
        /// </summary>
        public int IsHot { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { set; get; }
        /// <summary>
        /// 客服QQ
        /// </summary>
        public string ServiceQQ { get; set; }
        /// <summary>
        /// 合同类别
        /// </summary>
        public ContractType ContractType { get; set; }
        /// <summary>
        /// 预控人数，有效余量
        /// </summary>
        public int ControlPeople { get; set; }
        /// <summary>
        /// 剩余控位数
        /// </summary>
        public int ResidueNum { get; set; }
        /// <summary>
        /// 已购买人数
        /// </summary>
        public int SaleNum { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public ProductOp ProductOpState { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime ProductSdate { get; set; }
        /// <summary>
        /// 二维码有效期
        /// </summary>
        public DateTime ZCodeViaDate { get; set; }

        /// <summary>
        /// 添加类型1,线路产品，2车票，3门票
        /// </summary>
        public int PType { get; set; }
        /// <summary>
        /// 同类产品比较
        /// </summary>
        public string Scompare { get; set; }
        /// <summary>
        /// 线路类型
        /// </summary>
        public Eyousoft_yhq.Model.XianLu xianlu { get; set; }

        /// <summary>
        /// 发布人编号（标识是否是供应商产品）
        /// </summary>
        public string FaBuRenId { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public ChanPinShenHeStatus ShenHeStatus { get; set; }
        #endregion Model

        /// <summary>
        /// 发布人姓名
        /// </summary>
        public string FaBuRenName { get; set; }

    }

    /// <summary>
    /// 产品搜索实体
    /// </summary>
    public class SerProduct
    {
        public SerProduct() { }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string PurductName { get; set; }
        /// <summary>
        /// 微信码
        /// </summary>
        public string FavourCode { set; get; }
        /// <summary>
        /// 产品类别
        /// </summary>
        public string PurductType { set; get; }
        /// <summary>
        /// 产品状态
        /// </summary>
        public string PurductState { set; get; }
        /// <summary>
        /// 有效期开始
        /// </summary>
        public DateTime? Stime { set; get; }
        /// <summary>
        /// 有效期结束
        /// </summary>
        public DateTime? Etime { set; get; }
        /// <summary>
        /// 是否显示下架产品
        /// </summary>
        public bool isVisable { set; get; }
        /// <summary>
        /// 管理员编号
        /// </summary>
        public string AdminName { get; set; }

        /// <summary>
        /// 管理员编号
        /// </summary>
        public string IsAdmin { get; set; }

        /// <summary>
        /// 是否热门
        /// </summary>
        public int? isHot { get; set; }

        /// <summary>
        /// 是否推荐 0忽略，1是 
        /// </summary>
        public int SFTJ { get; set; }
        /// <summary>
        /// 订单销量  0忽略，1升序，2倒序
        /// </summary>
        public int DDXL { get; set; }
        /// <summary>
        /// 时间排序  0忽略，1升序，2升序
        /// </summary>
        public int SJPX { get; set; }
        /// <summary>
        /// 价格排序 0忽略，1升序，2升序
        /// </summary>
        public int JGPX { get; set; }
        /// <summary>
        /// 添加类型1,线路产品，2车票，3门票
        /// </summary>
        public int PType { get; set; }
        /// <summary>
        /// 线路类型
        /// </summary>
        public Eyousoft_yhq.Model.XianLu? xianlu { get; set; }
        /// <summary>
        /// 微店编号
        /// </summary>
        public string WeiDianId { get; set; }
        /// <summary>
        /// 发布人编号
        /// </summary>
        public string FaBuRenId { get; set; }

        ChanPinShenHeStatus? _ShenHeStatus = ChanPinShenHeStatus.已审核;
        /// <summary>
        /// 审核状态
        /// </summary>
        public ChanPinShenHeStatus? ShenHeStatus { get { return _ShenHeStatus; } set { _ShenHeStatus = value; } }
    }
}

