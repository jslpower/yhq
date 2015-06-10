using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    /// <summary>
    /// 订单实体类
    /// </summary>
    public class Order
    {

        public Order() { }
        private string _orderid;
        private string _productid;
        private string _productname;
        private string _ordercode;
        private string _memberid;
        private string _membername;
        private string _membertel;
        private sexType _membersex;
        private OrderState _orderstate;
        private PaymentState _paystate;
        private string _confirmcode;
        private bool _ischeck;
        private DateTime _issuetime;
        private string _remark;

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderID
        {
            get { return _orderid; }
            set { _orderid = value; }
        }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductID
        {
            get { return _productid; }
            set { _productid = value; }
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName
        {
            get { return _productname; }
            set { _productname = value; }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode
        {
            get { return _ordercode; }
            set { _ordercode = value; }
        }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string MemberID
        {
            get { return _memberid; }
            set { _memberid = value; }
        }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string MemberName
        {
            get { return _membername; }
            set { _membername = value; }
        }
        /// <summary>
        /// 会员电话
        /// </summary>
        public string MemberTel
        {
            get { return _membertel; }
            set { _membertel = value; }
        }
        /// <summary>
        /// 会员性别
        /// </summary>
        public sexType MemberSex
        {
            get { return _membersex; }
            set { _membersex = value; }
        }
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderState OrderState
        {
            get { return _orderstate; }
            set { _orderstate = value; }
        }
        /// <summary>
        /// 支付状态
        /// </summary>
        public PaymentState PayState
        {
            get { return _paystate; }
            set { _paystate = value; }
        }
        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsCheck
        {
            get { return _ischeck; }
            set { _ischeck = value; }
        }
        /// <summary>
        /// 确认码
        /// </summary>
        public string ConfirmCode
        {
            get { return _confirmcode; }
            set { _confirmcode = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime IssueTime
        {
            get { return _issuetime; }
            set { _issuetime = value; }
        }
        
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// 返佣金额
        /// </summary>
        public decimal FYJE { get; set; }
        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime? TourDate { get; set; }
        /// <summary>
        /// 优惠码
        /// </summary>
        public string FavourCode { get; set; }
        /// <summary>
        /// 是否天天出团
        /// </summary>
        public bool isEvery { get; set; }
        /// <summary>
        /// 线路类型
        /// </summary>
        public int ProductType { get; set; }
        /// <summary>
        /// 合同类型
        /// </summary>
        public Eyousoft_yhq.Model.ContractType ContractType { get; set; }
        /// <summary>
        /// 人数
        /// </summary>
        public int PeopleNum { get; set; }
        /// <summary>
        /// 合同文本
        /// </summary>
        public string ContractText { get; set; }
        /// <summary>
        /// 是否盖章
        /// </summary>
        public bool IsealCheck { get; set; }
        /// <summary>
        /// 出团通知单
        /// </summary>
        public System.Collections.Generic.IList<Eyousoft_yhq.Model.Attach> SendFile { get; set; }
        /// <summary>
        /// 寄送地址
        /// </summary>
        public string AddressID { get; set; }
        /// <summary>
        /// 返佣金额-已结算
        /// </summary>
        public decimal RebackMoney { get; set; }
        /// <summary>
        /// 返佣金额-待结算
        /// </summary>
        public decimal backMoney { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public ProductOp ProductOpState { get; set; }
        /// <summary>
        /// 二维码有效期
        /// </summary>
        public DateTime ZCodeViaDate { get; set; }
        /// <summary>
        /// 消费状态
        /// </summary>
        public XFstate XiaoFei { get; set; }
        /// <summary>
        /// 消费操作人
        /// </summary>
        public string AppUserName { get; set; }
        /// <summary>
        /// 消费时间
        /// </summary>
        public DateTime AppTime { get; set; }
        /// <summary>
        /// 结算方式
        /// </summary>
        public JSfangshi JIESUAN { get; set; }

        /// <summary>
        /// 可消费数量
        /// </summary>
        public int AvailNum { get; set; }

        /// <summary>
        /// 持码人
        /// </summary>
        public string AppMobNo { get; set; }
        /// <summary>
        /// 微店编号
        /// </summary>
        public string WeiDianId { get; set; }
        /// <summary>
        /// 微店名称（OUTPUT）
        /// </summary>
        public string WeiDianName { get; set; }
    }
    /// <summary>
    /// 订单查询类
    /// </summary>
    public class MSearchOrder
    {
        /// <summary>
        /// 下单人
        /// </summary>
        public string MemberID { get; set; }


        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 确认码
        /// </summary>
        public string ConfirmCode { get; set; }

        /// <summary>
        /// 下单时间开始
        /// </summary>
        public DateTime? STime { get; set; }

        /// <summary>
        /// 下单时间结束
        /// </summary>
        public DateTime? ETime { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public Eyousoft_yhq.Model.OrderState? OrderState { get; set; }

        /// <summary>
        /// 支付状态
        /// </summary>
        public Eyousoft_yhq.Model.PaymentState? PaymentState { get; set; }

        /// <summary>
        /// 消费状态
        /// </summary>
        public Eyousoft_yhq.Model.ConSumState? ConSumState { get; set; }

        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }

        /// <summary>
        /// 推广码
        /// </summary>
        public string PromotionCode { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal OrderPrice { get; set; }

        /// <summary>
        /// 消费操作人
        /// </summary>
        public string AppUser { get; set; }


        /// <summary>
        /// 消费操作人编号
        /// </summary>
        public string AppUserId { get; set; }


        /// <summary>
        /// 消费时间开始
        /// </summary>
        public DateTime? XSTime { get; set; }

        /// <summary>
        /// 消费时间结束
        /// </summary>
        public DateTime? XETime { get; set; }

        /// <summary>
        /// 结算方式
        /// </summary>
        public JSfangshi? jiesuan { get; set; }
        /// <summary>
        /// 产品发布人编号
        /// </summary>
        public string ChanPinFaBuRenId { get; set; }
    }
}
