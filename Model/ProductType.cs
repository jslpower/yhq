using System;
using System.Collections.Generic;
namespace Eyousoft_yhq.Model
{
    /// <summary>
    /// 轮换图片/轮换图片
    /// </summary>
    [Serializable]
    public partial class ProductType
    {
        public ProductType()
        { }
        #region Model
        private int _typeid;
        private string _typename;
        private AdminNameList _adminname;
        private string _productid;
        private string _productname;
        private string _typeimg;
        private string _webimg;
        private string _tpmark;
        private int _orderby;
        /// <summary>
        /// 分类编号
        /// </summary>
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 绑定管理员账号
        /// </summary>
        public IList<AdminNameList> AdminName{get;set;}
        /// <summary>
        /// 产品编号(产品图片)
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
        /// 分类图片
        /// </summary>
        public string TypeImg
        {
            set { _typeimg = value; }
            get { return _typeimg; }
        }
        /// <summary>
        /// 网站图片
        /// </summary>
        public string WebImg
        {
            set { _webimg = value; }
            get { return _webimg; }
        }
        /// <summary>
        /// 添加类型
        /// </summary>
        public string TpMark
        {
            set { _tpmark = value; }
            get { return _tpmark; }
        }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int OrderBy
        {
            set { _orderby = value; }
            get { return _orderby; }
        }
        /// <summary>
        /// 线路类型
        /// </summary>
        public XianLu xianlu { get; set; }

        #endregion Model

    }

    /// <summary>
    /// 管理员列表实体
    /// </summary>
    public class AdminNameList
    {
        public string AdminN { get; set; }
    }
    /// <summary>
    /// 产品类别搜索实体
    /// </summary>
    public class serProductType
    {
        public serProductType()
        { }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 管理员编号
        /// </summary>
        public string AdminID { get; set; }
        /// <summary>
        /// 是否超级管理员
        /// </summary>
        public bool IsAdmin { get; set; }
        /// <summary>
        /// 线路类型
        /// </summary>
        public XianLu? xianlu { get; set; }

    }
}

