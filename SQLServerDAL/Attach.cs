using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace Eyousoft_yhq.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Attach
	/// </summary>
	public partial class Attach
	{
		public Attach()
		{}


        #region IAttach 成员

        public bool Add(Eyousoft_yhq.Model.Attach model)
        {
            throw new NotImplementedException();
        }

        public bool Update(Eyousoft_yhq.Model.Attach model)
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public Eyousoft_yhq.Model.Attach GetModel()
        {
            throw new NotImplementedException();
        }

        public Eyousoft_yhq.Model.Attach DataRowToModel(DataRow row)
        {
            throw new NotImplementedException();
        }

        public DataSet GetList(string strWhere)
        {
            throw new NotImplementedException();
        }

        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }

        public int GetRecordCount(string strWhere)
        {
            throw new NotImplementedException();
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

