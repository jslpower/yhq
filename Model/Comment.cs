using System;
namespace Eyousoft_yhq.Model
{
	/// <summary>
	/// 评论表
	/// </summary>
	[Serializable]
	public partial class Comment
	{
		public Comment()
		{}
		#region Model
		private string _productid;
		private string _commentid;
		private string _peopleid;
		private string _commenttext;
		private string _checkstate="0";
        private DateTime _issuetime;
        private string _peoplename;
		/// <summary>
		/// 产品编号
		/// </summary>
		public string ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 主键编号
		/// </summary>
		public string CommentID
		{
			set{ _commentid=value;}
			get{return _commentid;}
		}
		/// <summary>
		/// 评论人编号
		/// </summary>
		public string PeopleID
		{
			set{ _peopleid=value;}
			get{return _peopleid;}
		}
		/// <summary>
		/// 评论内容
		/// </summary>
		public string CommentText
		{
			set{ _commenttext=value;}
			get{return _commenttext;}
		}
		/// <summary>
		/// 审核状态
		/// </summary>
		public string CheckState
		{
			set{ _checkstate=value;}
			get{return _checkstate;}
		}
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 评论人姓名
        /// </summary>
        public string PeopleName
        {
            set { _peoplename = value; }
            get { return _peoplename; }
        }
		#endregion Model

	}
    /// <summary>
    /// 评论搜索实体
    /// </summary>
    public class serComment
    {
        public serComment() { }
        /// <summary>
        /// 评论开始时间
        /// </summary>
        public DateTime? sTime { get; set; }
        /// <summary>
        /// 评论结束时间
        /// </summary>
        public DateTime? eTime { get; set; }

    
    }
}

