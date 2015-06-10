using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Xml.Linq;

namespace Eyousoft_yhq.SQLServerDAL
{
    public class Order : DALBase
    {
        #region 初始化db
        private Database _db = null;
        public Order()
        {
            _db = base.SystemStore;
        }
        #endregion

        #region Order 成员

        /// <summary>
        /// 判断确认码是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(string ConfirmCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbl_Order");
            strSql.Append(" where ConfirmCode=@ConfirmCode   ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ConfirmCode", System.Data.DbType.String, ConfirmCode);

            return DbHelper.Exists(cmd, this._db);
        }

        /// <summary>
        ///  增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Eyousoft_yhq.Model.Order model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_Order_Add");
            this._db.AddInParameter(cmd, "OrderID", DbType.AnsiStringFixedLength, model.OrderID);
            this._db.AddInParameter(cmd, "ProductID", DbType.AnsiStringFixedLength, model.ProductID);
            this._db.AddOutParameter(cmd, "OrderCode", DbType.AnsiStringFixedLength, 255);
            this._db.AddInParameter(cmd, "MemberID", DbType.AnsiStringFixedLength, model.MemberID);
            this._db.AddInParameter(cmd, "MemberName", DbType.String, model.MemberName);
            this._db.AddInParameter(cmd, "MemberTel", DbType.String, model.MemberTel);
            this._db.AddInParameter(cmd, "MemberSex", DbType.Byte, (int)model.MemberSex);
            this._db.AddInParameter(cmd, "OrderState", DbType.Byte, (int)model.OrderState);
            this._db.AddInParameter(cmd, "PayState", DbType.Byte, (int)model.PayState);
            this._db.AddInParameter(cmd, "IsCheck", DbType.AnsiStringFixedLength, this.GetBooleanToStr(model.IsCheck));
            this._db.AddInParameter(cmd, "ConfirmCode", DbType.String, model.ConfirmCode);
            this._db.AddInParameter(cmd, "OrderPrice", DbType.Decimal, model.OrderPrice);
            this._db.AddInParameter(cmd, "PeopleNum", DbType.Int32, model.PeopleNum);
            this._db.AddInParameter(cmd, "Remark", DbType.String, model.Remark);

            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            _db.AddInParameter(cmd, "WeiDianId", DbType.AnsiStringFixedLength, model.WeiDianId);

            DbHelper.RunProcedureWithResult(cmd, this._db);
            model.OrderCode = this._db.GetParameterValue(cmd, "OrderCode").ToString();
            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        ///  修改合同数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool updateContract(Eyousoft_yhq.Model.Order model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("UPDATE tbl_Order  SET  ContractText = @ContractText   ,  IsealCheck=@IsealCheck  WHERE OrderID =@OrderID ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            this._db.AddInParameter(cmd, "OrderID", DbType.AnsiStringFixedLength, model.OrderID);
            this._db.AddInParameter(cmd, "IsealCheck", DbType.AnsiStringFixedLength, GetBooleanToStr(model.IsealCheck));
            this._db.AddInParameter(cmd, "ContractText", DbType.String, model.ContractText);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;

        }
        /// <summary>
        ///  设置寄送地址
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool setAddressID(Eyousoft_yhq.Model.Order model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("UPDATE tbl_Order  SET  AddressID = @AddressID     WHERE OrderID =@OrderID ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            this._db.AddInParameter(cmd, "OrderID", DbType.AnsiStringFixedLength, model.OrderID);
            this._db.AddInParameter(cmd, "AddressID", DbType.AnsiStringFixedLength, model.AddressID);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(Eyousoft_yhq.Model.Order model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_Order_Update");
            this._db.AddInParameter(cmd, "OrderID", DbType.AnsiStringFixedLength, model.OrderID);
            this._db.AddInParameter(cmd, "OrderState", DbType.Byte, (int)model.OrderState);
            this._db.AddInParameter(cmd, "OrderPrice", DbType.Decimal, model.OrderPrice);
            this._db.AddInParameter(cmd, "Remark", DbType.String, model.Remark);



            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

            DbHelper.RunProcedureWithResult(cmd, this._db);
            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        ///  修改消费状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool setConSumState(string orderid, string UserId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("UPDATE tbl_Order  SET ConSumState=1,AppUserId=@UserId,AppTime=getdate()  WHERE OrderID =@OrderID");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            this._db.AddInParameter(cmd, "OrderID", DbType.AnsiStringFixedLength, orderid);
            this._db.AddInParameter(cmd, "UserId", DbType.AnsiStringFixedLength, UserId);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;

        }

        /// <summary>
        ///  修改消费状态，结算方式
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool setConSumState(string orderid, string UserId, Eyousoft_yhq.Model.JSfangshi fangshi, string AppMobNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("UPDATE tbl_Order  SET ConSumState=1,AppUserId=@UserId,AppTime=getdate(),JState=@JState,AvailNum=AvailNum-1  WHERE OrderID =@OrderID;");
            strSql.AppendFormat("INSERT INTO tbl_OrderAppScan (OrderID,OrderType,AppUserId,AppMobNo) VALUES(@OrderID,0,@UserId,@AppMobNo);");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            this._db.AddInParameter(cmd, "OrderID", DbType.AnsiStringFixedLength, orderid);
            this._db.AddInParameter(cmd, "UserId", DbType.AnsiStringFixedLength, UserId);
            this._db.AddInParameter(cmd, "JState", DbType.Byte, (int)fangshi);
            this._db.AddInParameter(cmd, "AppMobNo", DbType.AnsiStringFixedLength, AppMobNo);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;

        }

        public bool getOrderExist(string orderid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbl_Order");
            strSql.Append(" where  OrderID =@OrderID   and  ConSumState=1");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "OrderID", System.Data.DbType.AnsiStringFixedLength, orderid);

            return DbHelper.Exists(cmd, this._db);
        }

        public int SavePDF(Eyousoft_yhq.Model.Order model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_Order_UpdatePDF");
            this._db.AddInParameter(cmd, "OrderID", DbType.AnsiStringFixedLength, model.OrderID);
            this._db.AddInParameter(cmd, "ComAttachXML", DbType.Xml, CreateComNoticeXML(model.SendFile));


            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

            DbHelper.RunProcedureWithResult(cmd, this._db);
            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));
        }
        /// <summary>
        /// 保存支付状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SavePayState(Eyousoft_yhq.Model.Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("UPDATE tbl_Order  SET  PayState = @PayState,OrderState=@OrderState    WHERE OrderID =@OrderID ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "OrderID", DbType.AnsiStringFixedLength, model.OrderID);
            this._db.AddInParameter(cmd, "PayState", DbType.Byte, (int)model.PayState);
            this._db.AddInParameter(cmd, "OrderState", DbType.Byte, (int)model.OrderState);
            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 保存返佣金额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveReMoney(Eyousoft_yhq.Model.Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("UPDATE tbl_Order  SET  RebackMoney = @RebackMoney    WHERE OrderID =@OrderID ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "OrderID", DbType.AnsiStringFixedLength, model.OrderID);
            this._db.AddInParameter(cmd, "RebackMoney", DbType.Decimal, model.RebackMoney);
            return DbHelper.ExecuteSql(cmd, this._db);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public int Delete(string OrderID)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_Order_Delete");
            this._db.AddInParameter(cmd, "OrderID", DbType.AnsiStringFixedLength, OrderID);
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

            DbHelper.RunProcedureWithResult(cmd, this._db);
            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));
        }
        /// <summary>
        /// 修改订单支付状态
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public int UpdatePayState(Eyousoft_yhq.Model.Order Model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_OrderState_Update");
            this._db.AddInParameter(cmd, "OrderID", DbType.AnsiStringFixedLength, Model.OrderID);
            this._db.AddInParameter(cmd, "PayState", DbType.Byte, (int)Model.PayState);
            this._db.AddInParameter(cmd, "ConfirmCode", DbType.AnsiStringFixedLength, Model.ConfirmCode);
            this._db.AddInParameter(cmd, "OrderState", DbType.Byte, (int)Model.OrderState);
            this._db.AddInParameter(cmd, "JState", DbType.Byte, (int)Model.JIESUAN);

            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

            DbHelper.RunProcedureWithResult(cmd, this._db);
            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));
        }
        /// <summary>
        /// 获取一个订单
        /// </summary>
        /// <param name="OrderID">订单编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.Order GetModel(string OrderID)
        {
            Eyousoft_yhq.Model.Order model = null;

            string StrSql = "select  *  from view_Order where OrderId=@OrderId";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "OrderId", DbType.AnsiStringFixedLength, OrderID);
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.Order();

                    model.OrderID = dr.GetString(dr.GetOrdinal("OrderId"));
                    model.ProductID = dr.IsDBNull(dr.GetOrdinal("ProductID")) ? "" : dr.GetString(dr.GetOrdinal("ProductID"));
                    model.ProductName = dr.IsDBNull(dr.GetOrdinal("ProductName")) ? "" : dr.GetString(dr.GetOrdinal("ProductName"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.MemberID = dr.GetString(dr.GetOrdinal("MemberID"));
                    model.MemberName = dr.GetString(dr.GetOrdinal("MemberName"));
                    model.MemberTel = dr.IsDBNull(dr.GetOrdinal("MemberTel")) ? "" : dr.GetString(dr.GetOrdinal("MemberTel"));
                    model.MemberSex = (Eyousoft_yhq.Model.sexType)dr.GetByte(dr.GetOrdinal("MemberSex"));
                    model.OrderState = (Eyousoft_yhq.Model.OrderState)dr.GetByte(dr.GetOrdinal("OrderState"));
                    model.PayState = (Eyousoft_yhq.Model.PaymentState)dr.GetByte(dr.GetOrdinal("PayState"));
                    model.IsCheck = this.GetBoolean(dr.GetString(dr.GetOrdinal("ProductName")));
                    model.ConfirmCode = dr.IsDBNull(dr.GetOrdinal("ConfirmCode")) ? "" : dr.GetString(dr.GetOrdinal("ConfirmCode"));
                    model.Remark = dr.IsDBNull(dr.GetOrdinal("Remark")) ? "" : dr.GetString(dr.GetOrdinal("Remark"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OrderPrice = dr.GetDecimal(dr.GetOrdinal("OrderPrice"));

                    model.TourDate = dr.IsDBNull(dr.GetOrdinal("TourDate")) ? null : Utils.GetDateTimeNullable(dr.GetDateTime(dr.GetOrdinal("TourDate")).ToString());
                    model.FavourCode = dr.GetString(dr.GetOrdinal("FavourCode"));
                    model.isEvery = this.GetBoolean(dr.GetString(dr.GetOrdinal("isEvery")));
                    model.ProductType = dr.GetInt32(dr.GetOrdinal("ProductType"));
                    model.ContractType = dr.IsDBNull(dr.GetOrdinal("ContractType")) ? Eyousoft_yhq.Model.ContractType.国内合同 : (Eyousoft_yhq.Model.ContractType)dr.GetByte(dr.GetOrdinal("ContractType"));
                    model.OrderPrice = dr.GetDecimal(dr.GetOrdinal("OrderPrice"));
                    model.PeopleNum = dr.GetInt32(dr.GetOrdinal("PeopleNum"));
                    model.ContractText = dr.IsDBNull(dr.GetOrdinal("ContractText")) ? "" : dr.GetString(dr.GetOrdinal("ContractText"));
                    model.IsealCheck = GetBoolean(dr.GetString(dr.GetOrdinal("IsealCheck")));
                    model.FYJE = dr.IsDBNull(dr.GetOrdinal("fyje")) ? 0 : dr.GetDecimal(dr.GetOrdinal("fyje"));
                    model.SendFile = this.GetAttachList(dr["ComAttachXML"].ToString(), OrderID);
                    model.AddressID = dr.IsDBNull(dr.GetOrdinal("AddressID")) ? "" : dr.GetString(dr.GetOrdinal("AddressID"));
                    model.RebackMoney = dr.IsDBNull(dr.GetOrdinal("RebackMoney")) ? 0 : dr.GetDecimal(dr.GetOrdinal("RebackMoney"));
                    model.backMoney = dr.IsDBNull(dr.GetOrdinal("backMoney")) ? 0 : dr.GetDecimal(dr.GetOrdinal("backMoney"));
                    model.ProductOpState = (Eyousoft_yhq.Model.ProductOp)dr.GetByte(dr.GetOrdinal("ProductOpState"));
                    model.ZCodeViaDate = dr.IsDBNull(dr.GetOrdinal("ZCodeViaDate")) ? DateTime.Now : dr.GetDateTime(dr.GetOrdinal("ZCodeViaDate"));
                    model.XiaoFei = (Eyousoft_yhq.Model.XFstate)dr.GetByte(dr.GetOrdinal("ConSumState"));
                    model.JIESUAN = (Eyousoft_yhq.Model.JSfangshi)dr.GetByte(dr.GetOrdinal("JState"));
                    model.AvailNum = dr.IsDBNull(dr.GetOrdinal("AvailNum")) ? 0 : dr.GetInt32(dr.GetOrdinal("AvailNum"));

                }
            }
            return model;
        }
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.Order> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.MSearchOrder serModel)
        {
            IList<Eyousoft_yhq.Model.Order> list = new List<Eyousoft_yhq.Model.Order>();

            string tableName = "view_Order";

            string fileds = " * ";

            string orderByString = " IssueTime desc ";


            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");

            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.MemberID))
                {
                    query.AppendFormat(" and MemberID = '{0}' ", serModel.MemberID);
                }
                if (!string.IsNullOrEmpty(serModel.OrderCode))
                {
                    query.AppendFormat(" and OrderCode like '%{0}%' ", serModel.OrderCode);
                }
                if (!string.IsNullOrEmpty(serModel.ConfirmCode))
                {
                    query.AppendFormat(" and ConfirmCode like '%{0}%' ", serModel.ConfirmCode);
                }
                if (!string.IsNullOrEmpty(serModel.AppUserId))
                {
                    query.AppendFormat(" and AppUserId = '{0}' ", serModel.AppUserId);
                }
                if (!string.IsNullOrEmpty(serModel.AppUser))
                {
                    query.AppendFormat(" and AppUserName like '%{0}%' ", serModel.ConfirmCode);
                }
                if (serModel.OrderState.HasValue)
                {
                    query.AppendFormat(" AND OrderState = '{0}' ", (int)serModel.OrderState.Value);
                }
                if (serModel.ConSumState.HasValue)
                {
                    query.AppendFormat(" AND ConSumState = '{0}' ", (int)serModel.ConSumState.Value);
                }
                if (serModel.PaymentState.HasValue)
                {
                    query.AppendFormat(" AND PayState = '{0}' ", (int)serModel.PaymentState.Value);
                }
                if (serModel.STime.HasValue)
                {
                    query.AppendFormat(" AND IssueTime>='{0}' ", serModel.STime.Value);
                }
                if (serModel.ETime.HasValue)
                {
                    query.AppendFormat(" AND IssueTime< '{0}' ", serModel.ETime.Value.AddDays(1));
                }
                if (serModel.XSTime.HasValue)
                {
                    query.AppendFormat(" AND AppTime>='{0}' ", serModel.XSTime.Value);
                }
                if (serModel.XETime.HasValue)
                {
                    query.AppendFormat(" AND AppTime< '{0}' ", serModel.XETime.Value.AddDays(1));
                }
                if (!string.IsNullOrEmpty(serModel.RouteName))
                {
                    query.AppendFormat(" AND ProductName  like '%{0}%' ", serModel.RouteName);
                }
                if (serModel.OrderPrice != 0)
                {
                    query.AppendFormat(" AND OrderPrice  = '{0}' ", serModel.OrderPrice);
                }
                if (!string.IsNullOrEmpty(serModel.PromotionCode))
                {
                    query.AppendFormat(" and  (PollCode = '{0}'  OR PromotionCode= '{0}' )", serModel.PromotionCode);
                }
                if (serModel.jiesuan.HasValue)
                {
                    query.AppendFormat(" AND JState = '{0}' ", (int)serModel.jiesuan.Value);
                }
                if (!string.IsNullOrEmpty(serModel.ChanPinFaBuRenId))
                {
                    query.AppendFormat(" AND ChanPinFaBuRenId='{0}' ", serModel.ChanPinFaBuRenId);
                }
            }



            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {

                while (dr.Read())
                {
                    Eyousoft_yhq.Model.Order model = new Eyousoft_yhq.Model.Order();

                    model.OrderID = dr.GetString(dr.GetOrdinal("OrderId"));
                    model.ProductID = dr.IsDBNull(dr.GetOrdinal("ProductID")) ? "" : dr.GetString(dr.GetOrdinal("ProductID"));
                    model.ProductName = dr.IsDBNull(dr.GetOrdinal("ProductName")) ? "" : dr.GetString(dr.GetOrdinal("ProductName"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.MemberID = dr.GetString(dr.GetOrdinal("MemberID"));
                    model.MemberName = dr.GetString(dr.GetOrdinal("MemberName"));
                    model.MemberTel = dr.IsDBNull(dr.GetOrdinal("MemberTel")) ? "" : dr.GetString(dr.GetOrdinal("MemberTel"));
                    model.MemberSex = (Eyousoft_yhq.Model.sexType)dr.GetByte(dr.GetOrdinal("MemberSex"));
                    model.OrderState = (Eyousoft_yhq.Model.OrderState)dr.GetByte(dr.GetOrdinal("OrderState"));
                    model.PayState = (Eyousoft_yhq.Model.PaymentState)dr.GetByte(dr.GetOrdinal("PayState"));
                    model.IsCheck = this.GetBoolean(dr.GetString(dr.GetOrdinal("ProductName")));
                    model.ConfirmCode = dr.IsDBNull(dr.GetOrdinal("ConfirmCode")) ? "" : dr.GetString(dr.GetOrdinal("ConfirmCode"));
                    model.Remark = dr.IsDBNull(dr.GetOrdinal("Remark")) ? "" : dr.GetString(dr.GetOrdinal("Remark"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OrderPrice = dr.GetDecimal(dr.GetOrdinal("OrderPrice"));


                    model.TourDate = dr.IsDBNull(dr.GetOrdinal("TourDate")) ? null : Utils.GetDateTimeNullable(dr.GetDateTime(dr.GetOrdinal("TourDate")).ToString());
                    model.FavourCode = dr.GetString(dr.GetOrdinal("FavourCode"));
                    model.isEvery = this.GetBoolean(dr.GetString(dr.GetOrdinal("isEvery")));
                    model.ProductType = dr.GetInt32(dr.GetOrdinal("ProductType"));
                    model.ContractType = dr.IsDBNull(dr.GetOrdinal("ContractType")) ? Eyousoft_yhq.Model.ContractType.国内合同 : (Eyousoft_yhq.Model.ContractType)dr.GetByte(dr.GetOrdinal("ContractType")); model.OrderPrice = dr.GetDecimal(dr.GetOrdinal("OrderPrice"));
                    model.PeopleNum = dr.GetInt32(dr.GetOrdinal("PeopleNum"));
                    model.ContractText = dr.IsDBNull(dr.GetOrdinal("ContractText")) ? "" : dr.GetString(dr.GetOrdinal("ContractText"));
                    model.IsealCheck = GetBoolean(dr.GetString(dr.GetOrdinal("IsealCheck")));
                    model.FYJE = dr.IsDBNull(dr.GetOrdinal("fyje")) ? 0 : dr.GetDecimal(dr.GetOrdinal("fyje"));
                    model.SendFile = this.GetAttachList(dr["ComAttachXML"].ToString(), model.OrderID);
                    model.AddressID = dr.IsDBNull(dr.GetOrdinal("AddressID")) ? "" : dr.GetString(dr.GetOrdinal("AddressID"));
                    model.RebackMoney = dr.IsDBNull(dr.GetOrdinal("RebackMoney")) ? 0 : dr.GetDecimal(dr.GetOrdinal("RebackMoney"));
                    model.backMoney = dr.IsDBNull(dr.GetOrdinal("backMoney")) ? 0 : dr.GetDecimal(dr.GetOrdinal("backMoney"));
                    model.ProductOpState = (Eyousoft_yhq.Model.ProductOp)dr.GetByte(dr.GetOrdinal("ProductOpState"));
                    model.ZCodeViaDate = dr.IsDBNull(dr.GetOrdinal("ZCodeViaDate")) ? DateTime.Now : dr.GetDateTime(dr.GetOrdinal("ZCodeViaDate"));
                    model.XiaoFei = (Eyousoft_yhq.Model.XFstate)dr.GetByte(dr.GetOrdinal("ConSumState"));
                    model.AppTime = dr.IsDBNull(dr.GetOrdinal("AppTime")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("AppTime"));
                    model.AppUserName = dr.IsDBNull(dr.GetOrdinal("AppUserName")) ? string.Empty : dr.GetString(dr.GetOrdinal("AppUserName"));
                    model.JIESUAN = (Eyousoft_yhq.Model.JSfangshi)dr.GetByte(dr.GetOrdinal("JState"));

                    model.WeiDianName = dr["WeiDianName"].ToString();

                    list.Add(model);
                }
            };
            return list;
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.Order> GetScanList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.MSearchOrder serModel)
        {
            IList<Eyousoft_yhq.Model.Order> list = new List<Eyousoft_yhq.Model.Order>();

            string tableName = "view_OrderScan";

            string fileds = " * ";

            string orderByString = " AppTime desc ";


            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");

            if (serModel != null)
            {

                if (serModel.ConSumState.HasValue)
                {
                    query.AppendFormat(" AND ConSumState = '{0}' ", (int)serModel.ConSumState.Value);
                }
                if (!string.IsNullOrEmpty(serModel.OrderCode))
                {
                    query.AppendFormat(" and OrderCode like '%{0}%' ", serModel.OrderCode);
                }
                if (!string.IsNullOrEmpty(serModel.ConfirmCode))
                {
                    query.AppendFormat(" and ConfirmCode like '%{0}%' ", serModel.ConfirmCode);
                }
                if (!string.IsNullOrEmpty(serModel.AppUserId))
                {
                    query.AppendFormat(" and AppUserId = '{0}' ", serModel.AppUserId);
                }
                if (!string.IsNullOrEmpty(serModel.AppUser))
                {
                    query.AppendFormat(" and AppUserName like '%{0}%' ", serModel.ConfirmCode);
                }
                if (serModel.STime.HasValue)
                {
                    query.AppendFormat(" AND IssueTime>='{0}' ", serModel.STime.Value);
                }
                if (serModel.ETime.HasValue)
                {
                    query.AppendFormat(" AND IssueTime< '{0}' ", serModel.ETime.Value.AddDays(1));
                }
                if (serModel.XSTime.HasValue)
                {
                    query.AppendFormat(" AND AppTime>='{0}' ", serModel.XSTime.Value);
                }
                if (serModel.XETime.HasValue)
                {
                    query.AppendFormat(" AND AppTime< '{0}' ", serModel.XETime.Value.AddDays(1));
                }
                if (!string.IsNullOrEmpty(serModel.RouteName))
                {
                    query.AppendFormat(" AND ProductName  like '%{0}%' ", serModel.RouteName);
                }
            }



            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {

                while (dr.Read())
                {
                    Eyousoft_yhq.Model.Order model = new Eyousoft_yhq.Model.Order();

                    model.OrderID = dr.GetString(dr.GetOrdinal("OrderId"));
                    model.ProductID = dr.IsDBNull(dr.GetOrdinal("ProductID")) ? "" : dr.GetString(dr.GetOrdinal("ProductID"));
                    model.ProductName = dr.IsDBNull(dr.GetOrdinal("ProductName")) ? "" : dr.GetString(dr.GetOrdinal("ProductName"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.MemberID = dr.GetString(dr.GetOrdinal("MemberID"));
                    model.MemberName = dr.GetString(dr.GetOrdinal("MemberName"));

                    model.OrderState = (Eyousoft_yhq.Model.OrderState)dr.GetByte(dr.GetOrdinal("OrderState"));
                    model.PayState = (Eyousoft_yhq.Model.PaymentState)dr.GetByte(dr.GetOrdinal("PayState"));
                    model.IsCheck = this.GetBoolean(dr.GetString(dr.GetOrdinal("ProductName")));
                    model.ConfirmCode = dr.IsDBNull(dr.GetOrdinal("ConfirmCode")) ? "" : dr.GetString(dr.GetOrdinal("ConfirmCode"));

                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));




                    model.ProductType = dr.GetInt32(dr.GetOrdinal("ProductType"));

                    model.AppTime = dr.IsDBNull(dr.GetOrdinal("AppTime")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("AppTime"));
                    model.AppUserName = dr.IsDBNull(dr.GetOrdinal("AppUserName")) ? string.Empty : dr.GetString(dr.GetOrdinal("AppUserName"));
                    model.AppMobNo = dr.IsDBNull(dr.GetOrdinal("AppMobNo")) ? "" : dr.GetString(dr.GetOrdinal("AppMobNo"));

                    list.Add(model);
                }
            };
            return list;
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.Order> GetList(Eyousoft_yhq.Model.MSearchOrder serModel)
        {
            IList<Eyousoft_yhq.Model.Order> list = new List<Eyousoft_yhq.Model.Order>();
            StringBuilder query = new StringBuilder();


            query.Append("select    *    from view_Order where  1=1");

            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.MemberID))
                {
                    query.AppendFormat(" and MemberID = '{0}' ", serModel.MemberID);
                }
                if (!string.IsNullOrEmpty(serModel.OrderCode))
                {
                    query.AppendFormat(" and OrderCode like '%{0}%' ", serModel.OrderCode);
                }
                if (!string.IsNullOrEmpty(serModel.ConfirmCode))
                {
                    query.AppendFormat(" and ConfirmCode like '%{0}%' ", serModel.ConfirmCode);
                }
                if (serModel.OrderState.HasValue)
                {
                    query.AppendFormat(" AND OrderState = '{0}' ", (int)serModel.OrderState.Value);
                }
                if (serModel.PaymentState.HasValue)
                {
                    query.AppendFormat(" AND PayState = '{0}' ", (int)serModel.PaymentState.Value);
                }
                if (serModel.STime.HasValue)
                {
                    query.AppendFormat(" AND IssueTime>='{0}' ", serModel.STime.Value);
                }
                if (serModel.ETime.HasValue)
                {
                    query.AppendFormat(" AND IssueTime< '{0}' ", serModel.ETime.Value.AddDays(1));
                }
                if (!string.IsNullOrEmpty(serModel.RouteName))
                {
                    query.AppendFormat(" AND ProductName  like '%{0}%' ", serModel.RouteName);
                }
                if (serModel.OrderPrice != 0)
                {
                    query.AppendFormat(" AND OrderPrice  = '{0}' ", serModel.OrderPrice);
                }
                if (!string.IsNullOrEmpty(serModel.PromotionCode))
                {
                    query.AppendFormat(" and  (PollCode = '{0}'  OR PromotionCode= '{0}' )", serModel.PromotionCode);
                }
            }
            query.Append("  order by IssueTime  DESC  ");
            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {

                while (dr.Read())
                {
                    Eyousoft_yhq.Model.Order model = new Eyousoft_yhq.Model.Order();

                    model.OrderID = dr.GetString(dr.GetOrdinal("OrderId"));
                    model.ProductID = dr.IsDBNull(dr.GetOrdinal("ProductID")) ? "" : dr.GetString(dr.GetOrdinal("ProductID"));
                    model.ProductName = dr.IsDBNull(dr.GetOrdinal("ProductName")) ? "" : dr.GetString(dr.GetOrdinal("ProductName"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.MemberID = dr.GetString(dr.GetOrdinal("MemberID"));
                    model.MemberName = dr.GetString(dr.GetOrdinal("MemberName"));
                    model.MemberTel = dr.IsDBNull(dr.GetOrdinal("MemberTel")) ? "" : dr.GetString(dr.GetOrdinal("MemberTel"));
                    model.MemberSex = (Eyousoft_yhq.Model.sexType)dr.GetByte(dr.GetOrdinal("MemberSex"));
                    model.OrderState = (Eyousoft_yhq.Model.OrderState)dr.GetByte(dr.GetOrdinal("OrderState"));
                    model.PayState = (Eyousoft_yhq.Model.PaymentState)dr.GetByte(dr.GetOrdinal("PayState"));
                    model.IsCheck = this.GetBoolean(dr.GetString(dr.GetOrdinal("ProductName")));
                    model.ConfirmCode = dr.IsDBNull(dr.GetOrdinal("ConfirmCode")) ? "" : dr.GetString(dr.GetOrdinal("ConfirmCode"));
                    model.Remark = dr.IsDBNull(dr.GetOrdinal("Remark")) ? "" : dr.GetString(dr.GetOrdinal("Remark"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OrderPrice = dr.GetDecimal(dr.GetOrdinal("OrderPrice"));


                    model.TourDate = dr.IsDBNull(dr.GetOrdinal("TourDate")) ? null : Utils.GetDateTimeNullable(dr.GetDateTime(dr.GetOrdinal("TourDate")).ToString());
                    model.FavourCode = dr.GetString(dr.GetOrdinal("FavourCode"));
                    model.isEvery = this.GetBoolean(dr.GetString(dr.GetOrdinal("isEvery")));
                    model.ProductType = dr.GetInt32(dr.GetOrdinal("ProductType"));
                    model.ContractType = dr.IsDBNull(dr.GetOrdinal("ContractType")) ? Eyousoft_yhq.Model.ContractType.国内合同 : (Eyousoft_yhq.Model.ContractType)dr.GetByte(dr.GetOrdinal("ContractType")); model.OrderPrice = dr.GetDecimal(dr.GetOrdinal("OrderPrice"));
                    model.PeopleNum = dr.GetInt32(dr.GetOrdinal("PeopleNum"));
                    model.ContractText = dr.IsDBNull(dr.GetOrdinal("ContractText")) ? "" : dr.GetString(dr.GetOrdinal("ContractText"));
                    model.IsealCheck = GetBoolean(dr.GetString(dr.GetOrdinal("IsealCheck")));
                    model.FYJE = dr.IsDBNull(dr.GetOrdinal("fyje")) ? 0 : dr.GetDecimal(dr.GetOrdinal("fyje"));
                    model.SendFile = this.GetAttachList(dr["ComAttachXML"].ToString(), model.OrderID);
                    model.AddressID = dr.IsDBNull(dr.GetOrdinal("AddressID")) ? "" : dr.GetString(dr.GetOrdinal("AddressID"));
                    model.RebackMoney = dr.IsDBNull(dr.GetOrdinal("RebackMoney")) ? 0 : dr.GetDecimal(dr.GetOrdinal("RebackMoney"));
                    model.backMoney = dr.IsDBNull(dr.GetOrdinal("backMoney")) ? 0 : dr.GetDecimal(dr.GetOrdinal("backMoney"));
                    model.ProductOpState = (Eyousoft_yhq.Model.ProductOp)dr.GetByte(dr.GetOrdinal("ProductOpState"));
                    model.ZCodeViaDate = dr.IsDBNull(dr.GetOrdinal("ZCodeViaDate")) ? DateTime.Now : dr.GetDateTime(dr.GetOrdinal("ZCodeViaDate"));
                    model.XiaoFei = (Eyousoft_yhq.Model.XFstate)dr.GetByte(dr.GetOrdinal("ConSumState"));
                    model.JIESUAN = (Eyousoft_yhq.Model.JSfangshi)dr.GetByte(dr.GetOrdinal("JState"));
                    list.Add(model);
                }
            };
            return list;
        }





        /// <summary>
        /// 获取返佣
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.Order> GetFYList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.MSearchOrder serModel)
        {
            IList<Eyousoft_yhq.Model.Order> list = new List<Eyousoft_yhq.Model.Order>();

            string tableName = "view_Order";

            string fileds = " * ";

            string orderByString = " IssueTime desc ";


            StringBuilder query = new StringBuilder();
            query.Append(" PayState=2 ");

            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.MemberID))
                {
                    query.AppendFormat(" and  (PollCode = '{0}'  OR PromotionCode= '{0}' OR  MemberID = '{1}' )  ", serModel.PromotionCode, serModel.MemberID);
                }

            }



            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {

                while (dr.Read())
                {
                    Eyousoft_yhq.Model.Order model = new Eyousoft_yhq.Model.Order();

                    model.OrderID = dr.GetString(dr.GetOrdinal("OrderId"));
                    model.ProductID = dr.IsDBNull(dr.GetOrdinal("ProductID")) ? "" : dr.GetString(dr.GetOrdinal("ProductID"));
                    model.ProductName = dr.IsDBNull(dr.GetOrdinal("ProductName")) ? "" : dr.GetString(dr.GetOrdinal("ProductName"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.MemberID = dr.GetString(dr.GetOrdinal("MemberID"));
                    model.MemberName = dr.GetString(dr.GetOrdinal("MemberName"));
                    model.MemberTel = dr.IsDBNull(dr.GetOrdinal("MemberTel")) ? "" : dr.GetString(dr.GetOrdinal("MemberTel"));
                    model.MemberSex = (Eyousoft_yhq.Model.sexType)dr.GetByte(dr.GetOrdinal("MemberSex"));
                    model.OrderState = (Eyousoft_yhq.Model.OrderState)dr.GetByte(dr.GetOrdinal("OrderState"));
                    model.PayState = (Eyousoft_yhq.Model.PaymentState)dr.GetByte(dr.GetOrdinal("PayState"));
                    model.IsCheck = this.GetBoolean(dr.GetString(dr.GetOrdinal("ProductName")));
                    model.ConfirmCode = dr.IsDBNull(dr.GetOrdinal("ConfirmCode")) ? "" : dr.GetString(dr.GetOrdinal("ConfirmCode"));
                    model.Remark = dr.IsDBNull(dr.GetOrdinal("Remark")) ? "" : dr.GetString(dr.GetOrdinal("Remark"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OrderPrice = dr.GetDecimal(dr.GetOrdinal("OrderPrice"));


                    model.TourDate = dr.IsDBNull(dr.GetOrdinal("TourDate")) ? null : Utils.GetDateTimeNullable(dr.GetDateTime(dr.GetOrdinal("TourDate")).ToString());
                    model.FavourCode = dr.GetString(dr.GetOrdinal("FavourCode"));
                    model.isEvery = this.GetBoolean(dr.GetString(dr.GetOrdinal("isEvery")));
                    model.ProductType = dr.GetInt32(dr.GetOrdinal("ProductType"));
                    model.ContractType = dr.IsDBNull(dr.GetOrdinal("ContractType")) ? Eyousoft_yhq.Model.ContractType.国内合同 : (Eyousoft_yhq.Model.ContractType)dr.GetByte(dr.GetOrdinal("ContractType")); model.OrderPrice = dr.GetDecimal(dr.GetOrdinal("OrderPrice"));
                    model.PeopleNum = dr.GetInt32(dr.GetOrdinal("PeopleNum"));
                    model.ContractText = dr.IsDBNull(dr.GetOrdinal("ContractText")) ? "" : dr.GetString(dr.GetOrdinal("ContractText"));
                    model.IsealCheck = GetBoolean(dr.GetString(dr.GetOrdinal("IsealCheck")));
                    model.FYJE = dr.IsDBNull(dr.GetOrdinal("fyje")) ? 0 : dr.GetDecimal(dr.GetOrdinal("fyje"));
                    model.AddressID = dr.IsDBNull(dr.GetOrdinal("AddressID")) ? "" : dr.GetString(dr.GetOrdinal("AddressID"));
                    model.RebackMoney = dr.IsDBNull(dr.GetOrdinal("RebackMoney")) ? 0 : dr.GetDecimal(dr.GetOrdinal("RebackMoney"));
                    model.backMoney = dr.IsDBNull(dr.GetOrdinal("backMoney")) ? 0 : dr.GetDecimal(dr.GetOrdinal("backMoney"));
                    model.ProductOpState = (Eyousoft_yhq.Model.ProductOp)dr.GetByte(dr.GetOrdinal("ProductOpState"));
                    model.ZCodeViaDate = dr.IsDBNull(dr.GetOrdinal("ZCodeViaDate")) ? DateTime.Now : dr.GetDateTime(dr.GetOrdinal("ZCodeViaDate"));
                    model.XiaoFei = (Eyousoft_yhq.Model.XFstate)dr.GetByte(dr.GetOrdinal("ConSumState"));
                    model.JIESUAN = (Eyousoft_yhq.Model.JSfangshi)dr.GetByte(dr.GetOrdinal("JState"));
                    list.Add(model);
                }
            };
            return list;
        }

        /// <summary>
        /// 账户支付订单
        /// </summary>
        /// <param name="dingdan">订单</param>
        /// <param name="huiyuanbianhao">支付人</param>
        /// <returns></returns>
        public int XiaoFei(Eyousoft_yhq.Model.Order dingdan, string huiyuanbianhao)
        {

            DbCommand cmd = _db.GetStoredProcCommand("proc_XiaoFei");
            this._db.AddInParameter(cmd, "HuiYuanBianHao", DbType.AnsiStringFixedLength, huiyuanbianhao);
            this._db.AddInParameter(cmd, "DingDanBianHao", DbType.AnsiStringFixedLength, dingdan.OrderID);
            this._db.AddInParameter(cmd, "DingDanZT", DbType.Byte, dingdan.PayState);
            this._db.AddInParameter(cmd, "JinE", DbType.Decimal, dingdan.OrderPrice);
            this._db.AddOutParameter(cmd, "result", DbType.Int32, 4);

            DbHelper.RunProcedureWithResult(cmd, this._db);

            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));

        }

        #region 私有方法
        /// <summary>
        /// 创建附件XML
        /// </summary>
        /// <param name="list">附件集合</param>
        /// <returns></returns>
        private string CreateComNoticeXML(IList<Eyousoft_yhq.Model.Attach> list)
        {
            //if (list == null) return "";
            if (list == null) return null;
            StringBuilder StrBuild = new StringBuilder();
            StrBuild.Append("<ROOT>");
            foreach (Eyousoft_yhq.Model.Attach model in list)
            {
                StrBuild.AppendFormat("<ComAttach ItemId=\"{0}\" ", model.ItemId);
                StrBuild.AppendFormat(" Name=\"{0}\" ", model.Name);
                StrBuild.AppendFormat(" FilePath=\"{0}\" ", model.FilePath);
                StrBuild.AppendFormat(" Size=\"{0}\"  ", (int)model.Size);
                StrBuild.AppendFormat(" IsWebImage=\"{0}\" /> ", this.GetBooleanToStr(model.IsWebImage));

            }
            StrBuild.Append("</ROOT>");
            return StrBuild.ToString();
        }
        /// <summary>
        /// 生成附件集合List
        /// </summary>
        /// <param name="ComAttachXML">附件信息</param>
        /// <param name="NoticeId">通知编号</param>
        /// <param name="ItemType">附件类型</param>
        /// <returns></returns>
        private IList<Eyousoft_yhq.Model.Attach> GetAttachList(string ComAttachXML, string NoticeId)
        {
            if (string.IsNullOrEmpty(ComAttachXML)) return null;
            IList<Eyousoft_yhq.Model.Attach> ResultList = null;
            ResultList = new List<Eyousoft_yhq.Model.Attach>();
            XElement root = XElement.Parse(ComAttachXML);
            IEnumerable<XElement> xRow = root.Elements("row");
            foreach (XElement tmp1 in xRow)
            {
                Eyousoft_yhq.Model.Attach model = new Eyousoft_yhq.Model.Attach()
                {
                    Name = tmp1.Attribute("Name").Value,
                    FilePath = tmp1.Attribute("FilePath").Value,
                    Size = int.Parse(tmp1.Attribute("Size").Value),
                    ItemId = NoticeId,
                    IsWebImage = this.GetBoolean(tmp1.Attribute("IsWebImage").Value)
                };
                ResultList.Add(model);
                model = null;
            }
            return ResultList;
        }
        #endregion



        #endregion
    }
}
