using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;
using System.Xml.Linq;


namespace Eyousoft_yhq.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:Product
    /// </summary>
    public partial class Product : DALBase
    {
        private Database _db = null;
        public Product()
        {
            _db = base.SystemStore;
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

        #region IProduct 成员

        /// <summary>
        /// 判断微信码是否可用
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(Eyousoft_yhq.Model.Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbl_Product");
            strSql.Append(" where FavourCode=@FavourCode and  DATEDIFF(day,@ValidiDate,GETDATE())<0");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "FavourCode", System.Data.DbType.String, model.FavourCode);
            this._db.AddInParameter(cmd, "ValidiDate", System.Data.DbType.DateTime, model.ValidiDate);

            return Convert.ToInt32(DbHelper.GetSingle(cmd, this._db)) > 1 ? true : false;
        }
        /// <summary>
        /// 产品添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Eyousoft_yhq.Model.Product model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("Proc_Product_Add");

            _db.AddInParameter(cmd, "ProductID", DbType.String, model.ProductID);
            _db.AddInParameter(cmd, "ProductName", DbType.String, model.ProductName);
            _db.AddInParameter(cmd, "ProductType", DbType.Int32, model.ProductType);
            _db.AddInParameter(cmd, "TourDate", DbType.DateTime, model.TourDate);
            _db.AddInParameter(cmd, "MarketPrice", DbType.Decimal, model.MarketPrice);
            _db.AddInParameter(cmd, "AppPrice", DbType.Decimal, model.AppPrice);
            _db.AddInParameter(cmd, "FavourCode", DbType.String, model.FavourCode);
            _db.AddInParameter(cmd, "LinkTel", DbType.String, model.LinkTel);
            _db.AddInParameter(cmd, "ProductDis", DbType.String, model.ProductDis);
            _db.AddInParameter(cmd, "TourDis", DbType.String, model.TourDis);
            _db.AddInParameter(cmd, "SendTourKnow", DbType.String, model.SendTourKnow);
            _db.AddInParameter(cmd, "ValidiDate", DbType.String, model.ValidiDate);
            _db.AddInParameter(cmd, "ProductState", DbType.Byte, model.ProductState);
            _db.AddInParameter(cmd, "ComAttachXML", DbType.Xml, CreateComNoticeXML(model.AttachList));
            _db.AddInParameter(cmd, "IsEveryDay", DbType.Byte, model.IsEveryDay);
            _db.AddInParameter(cmd, "IsHot", DbType.Int32, model.IsHot);
            _db.AddInParameter(cmd, "ServiceQQ", DbType.String, model.ServiceQQ);
            _db.AddInParameter(cmd, "ContractType", DbType.Byte, (int)model.ContractType);
            _db.AddInParameter(cmd, "ControlPeople", DbType.Int32, model.ControlPeople);
            _db.AddInParameter(cmd, "Scompare", DbType.String, model.Scompare);

            #region 车票 门票修改
            _db.AddInParameter(cmd, "ProductOpState", DbType.Byte, model.ProductOpState);
            _db.AddInParameter(cmd, "ProductSdate", DbType.DateTime, model.ProductSdate);
            _db.AddInParameter(cmd, "ZCodeViaDate", DbType.DateTime, model.ZCodeViaDate);
            _db.AddInParameter(cmd, "PType", DbType.Int32, model.PType);
            #endregion



            this._db.AddOutParameter(cmd, "result", DbType.Int32, 4);

            _db.AddInParameter(cmd, "FaBuRenId", DbType.AnsiStringFixedLength, model.FaBuRenId);
            _db.AddInParameter(cmd, "ShenHeStatus", DbType.Int32, model.ShenHeStatus);

            DbHelper.RunProcedureWithResult(cmd, this._db);

            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result")) > 0 ? true : false;
        }
        /// <summary>
        /// 修改产品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Eyousoft_yhq.Model.Product model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("Proc_Product_Update");
            _db.AddInParameter(cmd, "ProductID", DbType.AnsiStringFixedLength, model.ProductID);
            _db.AddInParameter(cmd, "ProductName", DbType.String, model.ProductName);
            _db.AddInParameter(cmd, "ProductType", DbType.Int32, model.ProductType);
            _db.AddInParameter(cmd, "TourDate", DbType.DateTime, model.TourDate);
            _db.AddInParameter(cmd, "MarketPrice", DbType.Decimal, model.MarketPrice);
            _db.AddInParameter(cmd, "AppPrice", DbType.Decimal, model.AppPrice);
            _db.AddInParameter(cmd, "FavourCode", DbType.String, model.FavourCode);
            _db.AddInParameter(cmd, "LinkTel", DbType.String, model.LinkTel);
            _db.AddInParameter(cmd, "ProductDis", DbType.String, model.ProductDis);
            _db.AddInParameter(cmd, "TourDis", DbType.String, model.TourDis);
            _db.AddInParameter(cmd, "SendTourKnow", DbType.String, model.SendTourKnow);
            _db.AddInParameter(cmd, "ValidiDate", DbType.String, model.ValidiDate);
            _db.AddInParameter(cmd, "ProductState", DbType.Byte, model.ProductState);
            _db.AddInParameter(cmd, "ComAttachXML", DbType.Xml, CreateComNoticeXML(model.AttachList));
            _db.AddInParameter(cmd, "IsEveryDay", DbType.Byte, GetBooleanToStr(model.IsEveryDay));
            _db.AddInParameter(cmd, "IsHot", DbType.Int32, model.IsHot);
            _db.AddInParameter(cmd, "ServiceQQ", DbType.String, model.ServiceQQ);
            _db.AddInParameter(cmd, "ContractType", DbType.Byte, (int)model.ContractType);
            _db.AddInParameter(cmd, "ControlPeople", DbType.Int32, model.ControlPeople);
            _db.AddInParameter(cmd, "Scompare", DbType.String, model.Scompare);

            #region 车票 门票修改
            _db.AddInParameter(cmd, "ProductOpState", DbType.Byte, model.ProductOpState);
            _db.AddInParameter(cmd, "ProductSdate", DbType.DateTime, model.ProductSdate);
            _db.AddInParameter(cmd, "ZCodeViaDate", DbType.DateTime, model.ZCodeViaDate);
            #endregion

            this._db.AddOutParameter(cmd, "result", DbType.Int32, 4);
            _db.AddInParameter(cmd, "FaBuRenId", DbType.AnsiStringFixedLength, model.FaBuRenId);
            _db.AddInParameter(cmd, "ShenHeStatus", DbType.Int32, model.ShenHeStatus);

            DbHelper.RunProcedureWithResult(cmd, this._db);

            return Convert.ToInt32(this._db.GetParameterValue(cmd, "result")) > 0 ? true : false;
        }
        /// <summary>
        /// 下架产品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateProduteState(string[] ProductID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("UPDATE tbl_Product  SET  ProductState = 1 WHERE ProductID in ({0}) ", Utils.GetSqlInExpression(ProductID));
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;

        }

        /// <summary>
        /// 删除/批量删除
        /// </summary>
        /// <param name="ProductIDs">单个ID/多个ID拼接的字符串</param>
        /// <returns></returns>
        public int Delete(string[] ProductIDs)
        {
            StringBuilder sId = new StringBuilder();
            for (int i = 0; i < ProductIDs.Length; i++)
            {
                sId.AppendFormat("{0},", ProductIDs[i]);
            }
            sId.Remove(sId.Length - 1, 1);
            DbCommand dc = this._db.GetStoredProcCommand("Proc_Product_Delete");
            this._db.AddInParameter(dc, "ProductID", DbType.AnsiString, sId.ToString());
            this._db.AddOutParameter(dc, "Result", DbType.Int32, 4);
            DbHelper.RunProcedure(dc, this._db);
            object Result = this._db.GetParameterValue(dc, "Result");
            if (!Result.Equals(null))
            {
                return int.Parse(Result.ToString());
            }
            return 0;

        }

        public bool DeleteList(string ProductIDlist)
        {
            throw new NotImplementedException();
        }


        public Eyousoft_yhq.Model.Product GetModel(string ProductID)
        {
            Eyousoft_yhq.Model.Product model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT *,");

            strSql.AppendFormat(" (SELECT Name,FilePath,Size,IsWebImage  FROM tbl_Attach WHERE   ItemId='{0}' FOR XML RAW,ROOT('ROOT'))AS ComAttachXML   ", ProductID);

            strSql.Append("  FROM view_Product   ");
            strSql.Append(" where ProductID=@ProductID ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ProductID", System.Data.DbType.AnsiStringFixedLength, ProductID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.Product();
                    model.ProductID = ProductID;
                    model.ProductName = dr.GetString(dr.GetOrdinal("ProductName"));
                    model.ProductType = dr.GetInt32(dr.GetOrdinal("ProductType"));
                    model.TourDate = dr.IsDBNull(dr.GetOrdinal("TourDate")) ? null : Utils.GetDateTimeNullable(dr.GetDateTime(dr.GetOrdinal("TourDate")).ToString());
                    model.MarketPrice = dr.GetDecimal(dr.GetOrdinal("MarketPrice"));
                    model.AppPrice = dr.GetDecimal(dr.GetOrdinal("AppPrice"));
                    model.FavourCode = dr.GetString(dr.GetOrdinal("FavourCode"));
                    model.LinkTel = dr.GetString(dr.GetOrdinal("LinkTel"));
                    model.ProductDis = dr.GetString(dr.GetOrdinal("ProductDis"));
                    model.TourDis = dr.GetString(dr.GetOrdinal("TourDis"));
                    model.SendTourKnow = dr.GetString(dr.GetOrdinal("SendTourKnow"));
                    model.ValidiDate = dr.GetDateTime(dr.GetOrdinal("ValidiDate"));
                    //model.ProductState = dr.GetInt32(dr.GetOrdinal("ProductState"));
                    model.AttachList = this.GetAttachList(dr["ComAttachXML"].ToString(), ProductID);
                    model.IsEveryDay = dr.IsDBNull(dr.GetOrdinal("IsEveryDay")) ? false : GetBoolean(dr.GetString(dr.GetOrdinal("IsEveryDay")));
                    model.IsHot = dr.IsDBNull(dr.GetOrdinal("IsHot")) ? 0 : dr.GetByte(dr.GetOrdinal("IsHot"));
                    model.ServiceQQ = dr.IsDBNull(dr.GetOrdinal("ServiceQQ")) ? "" : dr.GetString(dr.GetOrdinal("ServiceQQ"));
                    model.ContractType = (Eyousoft_yhq.Model.ContractType)dr.GetByte(dr.GetOrdinal("ContractType"));
                    model.ControlPeople = dr.GetInt32(dr.GetOrdinal("ControlPeople"));
                    model.ResidueNum = dr.GetInt32(dr.GetOrdinal("ResidueNum"));
                    model.SaleNum = dr.GetInt32(dr.GetOrdinal("SaleNum"));
                    model.ProductOpState = (Eyousoft_yhq.Model.ProductOp)dr.GetByte(dr.GetOrdinal("ProductOpState"));
                    model.ProductSdate = dr.IsDBNull(dr.GetOrdinal("ProductSdate")) ? DateTime.Now : dr.GetDateTime(dr.GetOrdinal("ProductSdate"));
                    model.ZCodeViaDate = dr.IsDBNull(dr.GetOrdinal("ZCodeViaDate")) ? DateTime.Now : dr.GetDateTime(dr.GetOrdinal("ZCodeViaDate"));
                    model.PType = dr.IsDBNull(dr.GetOrdinal("PType")) ? 1 : dr.GetInt32(dr.GetOrdinal("PType"));
                    model.Scompare = dr.IsDBNull(dr.GetOrdinal("Scompare")) ? "" : dr.GetString(dr.GetOrdinal("Scompare"));
                    model.FaBuRenId = dr["FaBuRenId"].ToString();
                    model.ShenHeStatus = (Eyousoft_yhq.Model.ChanPinShenHeStatus)dr.GetInt32(dr.GetOrdinal("ShenHeStatus"));
                }
            }

            return model;
        }

        public IList<Eyousoft_yhq.Model.Product> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.SerProduct serModel)
        {
            IList<Eyousoft_yhq.Model.Product> list = new List<Eyousoft_yhq.Model.Product>();


            string tableName = "view_Product";
            string fileds = " *  ";
            string orderByString = "";

            StringBuilder query = new StringBuilder();
            query.Append(" 1=1  ");

            if (serModel != null)
            {
                #region 排序
                if (serModel.SFTJ == 1) orderByString += " IsHot DESC,";
                if (serModel.DDXL == 1) orderByString += "SaleNum DESC,";
                if (serModel.DDXL == 2) orderByString += "SaleNum ASC,";
                if (serModel.SJPX == 1)
                {
                    orderByString += "CreateDate DESC,";
                }
                else if (serModel.SJPX == 2)
                {
                    orderByString += "CreateDate  ASC,";
                }

                if (serModel.JGPX == 1) orderByString += "AppPrice DESC,";
                if (serModel.JGPX == 2) orderByString += "AppPrice ASC,";

                if (!string.IsNullOrEmpty(orderByString))
                {
                    orderByString = orderByString.TrimEnd(',');
                }
                else
                {
                    orderByString = "IsHot DESC,CreateDate desc";
                }
                #endregion

                if (!string.IsNullOrEmpty(serModel.FavourCode))
                {
                    query.AppendFormat(" and  (FavourCode = '{0}' )", serModel.FavourCode);
                }
                if (serModel.PType > 0)
                {
                    query.AppendFormat(" and  (PType = {0} )", serModel.PType);
                }

                if (serModel.IsAdmin != "1" && !string.IsNullOrEmpty(serModel.AdminName))
                {
                    query.AppendFormat(" and (  charindex('{0}',[AdminName])>0 or  AdminName is null)", serModel.AdminName);
                }

                if (!string.IsNullOrEmpty(serModel.PurductName))
                {
                    query.AppendFormat(" and  ProductName like '%{0}%' ", serModel.PurductName);
                }

                if (!string.IsNullOrEmpty(serModel.PurductType) && serModel.PurductType != "0")
                {
                    query.AppendFormat(" and  ProductType = '{0}' ", serModel.PurductType);
                }
                if (!string.IsNullOrEmpty(serModel.PurductState) && serModel.PurductState != "2")
                {
                    query.AppendFormat(" and  ProductState = '{0}' ", serModel.PurductState);
                }
                if (serModel.Stime.HasValue)
                {
                    query.AppendFormat(" AND datediff(day,'{0}',ValidiDate)>=0 ", serModel.Stime.Value);
                }
                if (serModel.Etime.HasValue)
                {
                    query.AppendFormat(" AND datediff(day,'{0}',ValidiDate)< 0 ", serModel.Etime.Value.AddDays(1));
                }
                if (!serModel.isVisable)
                {
                    query.AppendFormat(" AND ProductState = 0 ");
                }
                if (serModel.isHot.HasValue && serModel.isHot == 1)
                {
                    query.AppendFormat(" and  IsHot = '{0}' ", serModel.isHot);
                }
                else if (serModel.isHot.HasValue && serModel.isHot == 0)
                {
                    query.AppendFormat(" and  (IsHot = '{0}'  or IsHot is null) ", serModel.isHot);
                }

                if (serModel.xianlu != null && serModel.PType == 1)
                {
                    query.AppendFormat(" and  XianLu = '{0}' ", (int)serModel.xianlu);
                }

                if (!string.IsNullOrEmpty(serModel.WeiDianId))
                {
                    query.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_WeiDianChanPinGuanXi AS A1 WHERE A1.ChanPinId=view_Product.ProductID AND A1.WeiDianId='{0}') ", serModel.WeiDianId);
                }

                if (!string.IsNullOrEmpty(serModel.FaBuRenId))
                {
                    query.AppendFormat(" AND FaBuRenId='{0}' ", serModel.FaBuRenId);
                }
                if (serModel.ShenHeStatus.HasValue)
                {
                    query.AppendFormat(" AND ShenHeStatus={0} ", (int)serModel.ShenHeStatus.Value);
                }
            }
            else
            {
                orderByString = "IsHot DESC,CreateDate desc";
            }

            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {

                    Eyousoft_yhq.Model.Product model = new Eyousoft_yhq.Model.Product();
                    model.ProductID = dr.GetString(dr.GetOrdinal("ProductID")); ;
                    model.ProductName = dr.GetString(dr.GetOrdinal("ProductName"));
                    model.ProductType = dr.GetInt32(dr.GetOrdinal("ProductType"));
                    model.TourDate = dr.IsDBNull(dr.GetOrdinal("TourDate")) ? null : Utils.GetDateTimeNullable(dr.GetDateTime(dr.GetOrdinal("TourDate")).ToString());
                    model.MarketPrice = dr.GetDecimal(dr.GetOrdinal("MarketPrice"));
                    model.AppPrice = dr.GetDecimal(dr.GetOrdinal("AppPrice"));
                    model.FavourCode = dr.GetString(dr.GetOrdinal("FavourCode"));
                    model.LinkTel = dr.GetString(dr.GetOrdinal("LinkTel"));
                    model.ProductDis = dr.GetString(dr.GetOrdinal("ProductDis"));
                    model.TourDis = dr.GetString(dr.GetOrdinal("TourDis"));
                    model.SendTourKnow = dr.GetString(dr.GetOrdinal("SendTourKnow"));
                    model.ValidiDate = dr.GetDateTime(dr.GetOrdinal("ValidiDate"));
                    model.ProductState = dr.GetByte(dr.GetOrdinal("ProductState"));
                    model.IsEveryDay = dr.IsDBNull(dr.GetOrdinal("IsEveryDay")) ? false : GetBoolean(dr.GetString(dr.GetOrdinal("IsEveryDay")));
                    model.IsHot = dr.IsDBNull(dr.GetOrdinal("IsHot")) ? 0 : dr.GetByte(dr.GetOrdinal("IsHot"));
                    model.CreateDate = dr.GetDateTime(dr.GetOrdinal("CreateDate"));
                    model.ServiceQQ = dr.IsDBNull(dr.GetOrdinal("ServiceQQ")) ? "" : dr.GetString(dr.GetOrdinal("ServiceQQ"));
                    model.ContractType = (Eyousoft_yhq.Model.ContractType)dr.GetByte(dr.GetOrdinal("ContractType"));
                    model.ControlPeople = dr.GetInt32(dr.GetOrdinal("ControlPeople"));
                    model.ResidueNum = dr.GetInt32(dr.GetOrdinal("ResidueNum"));
                    model.SaleNum = dr.GetInt32(dr.GetOrdinal("SaleNum"));
                    model.ProductOpState = (Eyousoft_yhq.Model.ProductOp)dr.GetByte(dr.GetOrdinal("ProductOpState"));
                    model.ProductSdate = dr.IsDBNull(dr.GetOrdinal("ProductSdate")) ? DateTime.Now : dr.GetDateTime(dr.GetOrdinal("ProductSdate"));
                    model.ZCodeViaDate = dr.IsDBNull(dr.GetOrdinal("ZCodeViaDate")) ? DateTime.Now : dr.GetDateTime(dr.GetOrdinal("ZCodeViaDate"));
                    model.PType = dr.IsDBNull(dr.GetOrdinal("PType")) ? 1 : dr.GetInt32(dr.GetOrdinal("PType"));
                    model.xianlu = dr.IsDBNull(dr.GetOrdinal("XianLu")) ? Eyousoft_yhq.Model.XianLu.国内游 : (Eyousoft_yhq.Model.XianLu)dr.GetByte(dr.GetOrdinal("XianLu"));
                    model.FaBuRenId = dr["FaBuRenId"].ToString();
                    model.ShenHeStatus = (Eyousoft_yhq.Model.ChanPinShenHeStatus)dr.GetInt32(dr.GetOrdinal("ShenHeStatus"));
                    model.FaBuRenName = dr["FaBuRenName"].ToString();

                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.Product> GetList(Eyousoft_yhq.Model.SerProduct serModel)
        {
            IList<Eyousoft_yhq.Model.Product> list = new List<Eyousoft_yhq.Model.Product>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ProductID,ProductName,ProductType,TourDate,MarketPrice,AppPrice,FavourCode,LinkTel,ProductDis,TourDis,SendTourKnow,ValidiDate,IsEveryDay,IsHot,CreateDate,ServiceQQ, ContractType,ControlPeople,ResidueNum,ProductOpState,ProductSdate,ZCodeViaDate,PType,XianLu   ");
            strSql.AppendFormat("  from view_Product where  1=1 and ProductState=0  AND datediff(day,'{0}',ValidiDate)>=0 ", DateTime.Now);
            if (serModel != null)
            {
                if (serModel.PType > 0)
                {
                    strSql.AppendFormat(" and  PType = {0} ", serModel.PType);
                }
                if (!string.IsNullOrEmpty(serModel.PurductName))
                {
                    strSql.AppendFormat(" and  ProductName like '%{0}%' ", serModel.PurductName);
                }
                if (!string.IsNullOrEmpty(serModel.FavourCode))
                {
                    strSql.AppendFormat(" and  FavourCode = '{0}' ", serModel.FavourCode);
                }
            }
            strSql.Append("  order by IsHot DESC, CreateDate  DESC  ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());






            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {

                    Eyousoft_yhq.Model.Product model = new Eyousoft_yhq.Model.Product();
                    model.ProductID = dr.GetString(dr.GetOrdinal("ProductID")); ;
                    model.ProductName = dr.GetString(dr.GetOrdinal("ProductName"));
                    model.ProductType = dr.GetInt32(dr.GetOrdinal("ProductType"));
                    model.TourDate = dr.IsDBNull(dr.GetOrdinal("TourDate")) ? null : Utils.GetDateTimeNullable(dr.GetDateTime(dr.GetOrdinal("TourDate")).ToString());
                    model.MarketPrice = dr.GetDecimal(dr.GetOrdinal("MarketPrice"));
                    model.AppPrice = dr.GetDecimal(dr.GetOrdinal("AppPrice"));
                    model.FavourCode = dr.GetString(dr.GetOrdinal("FavourCode"));
                    model.LinkTel = dr.GetString(dr.GetOrdinal("LinkTel"));
                    model.ProductDis = dr.GetString(dr.GetOrdinal("ProductDis"));
                    model.TourDis = dr.GetString(dr.GetOrdinal("TourDis"));
                    model.SendTourKnow = dr.GetString(dr.GetOrdinal("SendTourKnow"));
                    model.ValidiDate = dr.GetDateTime(dr.GetOrdinal("ValidiDate"));
                    //model.ProductState = dr.GetInt32(dr.GetOrdinal("ProductState"));
                    model.IsEveryDay = dr.IsDBNull(dr.GetOrdinal("IsEveryDay")) ? false : GetBoolean(dr.GetString(dr.GetOrdinal("IsEveryDay")));
                    model.IsHot = dr.IsDBNull(dr.GetOrdinal("IsHot")) ? 0 : dr.GetByte(dr.GetOrdinal("IsHot"));
                    model.CreateDate = dr.GetDateTime(dr.GetOrdinal("CreateDate"));
                    model.ServiceQQ = dr.IsDBNull(dr.GetOrdinal("ServiceQQ")) ? "" : dr.GetString(dr.GetOrdinal("ServiceQQ"));
                    model.ContractType = (Eyousoft_yhq.Model.ContractType)dr.GetByte(dr.GetOrdinal("ContractType"));
                    model.ControlPeople = dr.GetInt32(dr.GetOrdinal("ControlPeople"));
                    model.ResidueNum = dr.GetInt32(dr.GetOrdinal("ResidueNum"));
                    model.ProductSdate = dr.IsDBNull(dr.GetOrdinal("ProductSdate")) ? DateTime.Now : dr.GetDateTime(dr.GetOrdinal("ProductSdate"));
                    model.ZCodeViaDate = dr.IsDBNull(dr.GetOrdinal("ZCodeViaDate")) ? DateTime.Now : dr.GetDateTime(dr.GetOrdinal("ZCodeViaDate"));
                    model.xianlu = (Eyousoft_yhq.Model.XianLu)dr.GetByte(dr.GetOrdinal("XianLu"));

                    list.Add(model);
                }
            }
            return list;
        }


        #endregion

        /// <summary>
        /// 产品审核，返回1成功，其它失败
        /// </summary>
        /// <param name="chanPinIds">产品编号集合</param>
        /// <param name="shenHeStatus">审核状态</param>
        /// <returns></returns>
        public int ChanPinShenHe(IList<string> chanPinIds, Eyousoft_yhq.Model.ChanPinShenHeStatus shenHeStatus)
        {
            string sql = string.Format("UPDATE tbl_Product SET ShenHeStatus=@ShenHeStatus WHERE ProductID IN({0})", Utils.GetSqlIn<string>(chanPinIds));
            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "ShenHeStatus", DbType.Int32, shenHeStatus);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }


    }
}

