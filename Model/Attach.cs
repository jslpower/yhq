using System;
namespace Eyousoft_yhq.Model
{
    /// <summary>
    /// 附件信息表
    /// </summary>
    [Serializable]
    public partial class Attach
    {
        public Attach()
        { }
        #region Model
        private string _itemid;
        private string _name;
        private string _filepath;
        private int _size = 0;
        private bool _iswebimage;
        /// <summary>
        /// 关联编号
        /// </summary>
        public string ItemId
        {
            set { _itemid = value; }
            get { return _itemid; }
        }
        /// <summary>
        /// 附件名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 附件路径
        /// </summary>
        public string FilePath
        {
            set { _filepath = value; }
            get { return _filepath; }
        }
        /// <summary>
        /// 附件大小(kb)
        /// </summary>
        public int Size
        {
            set { _size = value; }
            get { return _size; }
        }
        /// <summary>
        /// 是否网站图片
        /// </summary>
        public bool IsWebImage
        {
            set { _iswebimage = value; }
            get { return _iswebimage; }
        }
        #endregion Model

    }
}

