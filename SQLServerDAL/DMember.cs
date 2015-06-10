using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;
using System.Xml.Linq;
using Eyousoft_yhq.Model;
namespace Eyousoft_yhq.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:User
    /// </summary>
    public partial class DMember : DALBase
    {
        #region 初始化db
        private Database _db = null;

        public DMember()
        {
            _db = base.SystemStore;
        }
        #endregion


        #region IUser 成员
        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public bool Exists(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbl_Member");
            strSql.Append(" where UserName=@UserName ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "UserName", System.Data.DbType.String, UserName);

            return DbHelper.Exists(cmd, this._db);
        }
        /// <summary>
        /// 返回推广次数
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public int CountTGCS(string Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbl_Member");
            strSql.Append(" where PollCode=@PromotionCode ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "PromotionCode", System.Data.DbType.String, Code);

            return Convert.ToInt32(DbHelper.GetSingle(cmd, this._db));
        }
        /// <summary>
        /// 返回返佣次数
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public int CountFYCS(string MemberID, string PollCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from view_Order");
            strSql.AppendFormat(" where (MemberID=@MemberID {0}) AND PayState=2", string.IsNullOrEmpty(PollCode) ? "" : "or PollCode=@PollCode");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "MemberID", System.Data.DbType.String, MemberID);
            this._db.AddInParameter(cmd, "PollCode", System.Data.DbType.String, PollCode);

            return Convert.ToInt32(DbHelper.GetSingle(cmd, this._db));
        }
        /// <summary>
        /// 注册用户/添加用户
        /// </summary>
        /// <param name="model">用户实体/管理员实体</param>
        /// <returns></returns>
        public bool Add(Eyousoft_yhq.Model.User model)
        {

            StringBuilder strSqlExists = new StringBuilder();
            strSqlExists.Append("select count(1) from tbl_Member");
            strSqlExists.Append(" where PromotionCode=@PollCode ");

            DbCommand cmdExists = this._db.GetSqlStringCommand(strSqlExists.ToString());
            this._db.AddInParameter(cmdExists, "PollCode", System.Data.DbType.String, model.PollCode);

            if (!DbHelper.Exists(cmdExists, this._db))
            {
                model.PollCode = "";
            }

            StringBuilder strSql = new StringBuilder();

            strSql.Append("  INSERT INTO tbl_Member([UserID],[UserName],[UserPwd],[ContactName],[ContactSex],[Remark],[IssueTime],[PollCode],[IsAgent],[YuE]  )		VALUES (@UserID,@UserName,@UserPwd,@ContactName,@ContactSex,@Remark,@IssueTime,@PollCode,@IsAgent,@YuE) ");


            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "UserID", System.Data.DbType.AnsiStringFixedLength, model.UserID);
            this._db.AddInParameter(cmd, "UserName", System.Data.DbType.String, model.UserName);
            this._db.AddInParameter(cmd, "UserPwd", System.Data.DbType.String, model.UserPwd);
            this._db.AddInParameter(cmd, "ContactName", System.Data.DbType.String, model.ContactName);
            this._db.AddInParameter(cmd, "ContactSex", System.Data.DbType.Byte, (int)model.ContactSex);
            this._db.AddInParameter(cmd, "Remark", System.Data.DbType.String, model.Remark);
            this._db.AddInParameter(cmd, "IssueTime", System.Data.DbType.DateTime, model.IssueTime);
            this._db.AddInParameter(cmd, "PollCode", System.Data.DbType.String, model.PollCode);
            this._db.AddInParameter(cmd, "IsAgent", System.Data.DbType.Byte, GetBooleanToStr(model.IsAgent));
            this._db.AddInParameter(cmd, "YuE", System.Data.DbType.Decimal, model.YuE);


            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="model">用户实体</param>
        /// <returns></returns>
        public bool Update(Eyousoft_yhq.Model.User model)
        {
            StringBuilder strSql = new StringBuilder();


            strSql.Append("UPDATE tbl_Member  SET  ContactName =@ContactName ,Remark =@Remark  , ContactSex =@ContactSex,CommissonScale=@CommissonScale ,PromotionCode=@PromotionCode,IsAgent=@IsAgent,IsZZ=@IsZZ,MemberOption=@MemberOption,ProviceId=@ProviceId,CityId=@CityId,AreaId=@AreaId,StreetId=@StreetId");
            if (!string.IsNullOrEmpty(model.UserPwd))
            {
                strSql.AppendFormat(" ,UserPwd = @UserPwd ");
            }
            if (model.valiUser)
            {
                strSql.AppendFormat(" ,valiUser = @valiUser ");
            }
            strSql.Append(" WHERE UserID = @UserID");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());


            this._db.AddInParameter(cmd, "UserID", System.Data.DbType.AnsiStringFixedLength, model.UserID);
            if (!string.IsNullOrEmpty(model.UserPwd))
            {
                this._db.AddInParameter(cmd, "UserPwd", System.Data.DbType.String, model.UserPwd);
            }
            if (model.valiUser)
            {
                this._db.AddInParameter(cmd, "valiUser", System.Data.DbType.Byte, this.GetBooleanToStr(model.valiUser));
            }

            this._db.AddInParameter(cmd, "ContactName", System.Data.DbType.String, model.ContactName);
            this._db.AddInParameter(cmd, "ContactSex", System.Data.DbType.Byte, (int)model.ContactSex);
            this._db.AddInParameter(cmd, "Remark", System.Data.DbType.String, model.Remark);
            this._db.AddInParameter(cmd, "CommissonScale", System.Data.DbType.Decimal, model.CommissonScale);
            this._db.AddInParameter(cmd, "PromotionCode", System.Data.DbType.String, model.PromotionCode);
            this._db.AddInParameter(cmd, "IsAgent", System.Data.DbType.Byte, this.GetBooleanToStr(model.IsAgent));
            //            this._db.AddInParameter(cmd, "YuE", System.Data.DbType.Decimal, model.YuE);
            this._db.AddInParameter(cmd, "IsZZ", System.Data.DbType.Byte, GetBooleanToStr(model.IsZZ));
            this._db.AddInParameter(cmd, "MemberOption", System.Data.DbType.Int32, model.MemberOption);
            this._db.AddInParameter(cmd, "ProviceId", System.Data.DbType.Int32, model.ProviceId);
            this._db.AddInParameter(cmd, "CityId", System.Data.DbType.Int32, model.CityId);
            this._db.AddInParameter(cmd, "AreaId", System.Data.DbType.Int32, model.AreaId);
            this._db.AddInParameter(cmd, "StreetId", System.Data.DbType.Int32, model.StreetId);


            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;

        }
        /// <summary>
        /// 设置充值金额
        /// </summary>
        /// <param name="model">用户实体</param>
        /// <returns></returns>
        public bool UpdateYuE(Eyousoft_yhq.Model.User model)
        {
            StringBuilder strSql = new StringBuilder();


            strSql.Append("UPDATE tbl_Member  SET   YuE=@YuE WHERE UserID = @UserID");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "UserID", System.Data.DbType.AnsiStringFixedLength, model.UserID);
            this._db.AddInParameter(cmd, "YuE", System.Data.DbType.Decimal, model.YuE);
            Eyousoft_yhq.SQLServerDAL.Utils.WLog(strSql.ToString(), "/log_sql.txt");





            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;

        }
        /// <summary>
        /// 修改最后查看时间
        /// </summary>
        /// <param name="UserId">用户id</param>
        /// <param name="XinXiType">查看类别（0-点赞1-留言2-关注）</param>
        /// <returns></returns>
        public bool Update(string UserId, Eyousoft_yhq.Model.OptionType XinXiType)
        {
            StringBuilder strSql = new StringBuilder();


            strSql.Append("UPDATE tbl_Member  SET  ");
            if (XinXiType == OptionType.点赞)
            {
                strSql.Append("DianZanTime=getdate()");
            }
            else if (XinXiType == OptionType.留言)
            {
                strSql.Append("LiuYanTime=getdate()");
            }
            else if (XinXiType == OptionType.关注)
            {
                strSql.Append("GuanZhuTime=getdate()");
            }

            strSql.AppendFormat(" WHERE UserID ='{0}'", UserId);
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;

        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns></returns>
        public int Delete(string UserID)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_User_Delete");
            this._db.AddInParameter(cmd, "UserID", DbType.AnsiStringFixedLength, UserID);
            this._db.AddOutParameter(cmd, "result", DbType.Int32, 4);

            DbHelper.RunProcedureWithResult(cmd, this._db);

            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));
        }


        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="UserIDlist">用户编号</param>
        /// <returns></returns>
        public bool DeleteList(string[] UserIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("DELETE FROM  tbl_Member   WHERE UserID in ({0}) ", Utils.GetSqlInExpression(UserIDlist));
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.User GetModel(string UserID)
        {
            Eyousoft_yhq.Model.User model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT *  ");

            strSql.Append("  FROM tbl_Member  ");
            strSql.Append(" where UserID=@UserID ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "UserID", System.Data.DbType.AnsiStringFixedLength, UserID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.User();
                    model.UserID = dr.IsDBNull(dr.GetOrdinal("UserID")) ? "" : dr.GetString(dr.GetOrdinal("UserID"));
                    model.UserName = dr.IsDBNull(dr.GetOrdinal("UserName")) ? "" : dr.GetString(dr.GetOrdinal("UserName"));
                    model.UserPwd = dr.IsDBNull(dr.GetOrdinal("UserPwd")) ? "" : dr.GetString(dr.GetOrdinal("UserPwd"));
                    model.ContactName = dr.IsDBNull(dr.GetOrdinal("ContactName")) ? "" : dr.GetString(dr.GetOrdinal("ContactName"));
                    model.ContactSex = (sexType)dr.GetByte(dr.GetOrdinal("ContactSex"));
                    model.Remark = dr.IsDBNull(dr.GetOrdinal("Remark")) ? "" : dr.GetString(dr.GetOrdinal("Remark"));
                    model.CommissonScale = dr.IsDBNull(dr.GetOrdinal("CommissonScale")) ? 0 : dr.GetDecimal(dr.GetOrdinal("CommissonScale"));
                    model.PollCode = dr.IsDBNull(dr.GetOrdinal("PollCode")) ? "" : dr.GetString(dr.GetOrdinal("PollCode"));
                    model.PromotionCode = dr.IsDBNull(dr.GetOrdinal("PromotionCode")) ? "" : dr.GetString(dr.GetOrdinal("PromotionCode"));
                    model.IsAgent = dr.IsDBNull(dr.GetOrdinal("IsAgent")) ? false : GetBoolean(dr.GetString(dr.GetOrdinal("IsAgent")));
                    model.valiUser = GetBoolean(dr.GetString(dr.GetOrdinal("valiUser")));
                    model.YuE = dr.GetDecimal(dr.GetOrdinal("YuE"));
                    model.IsZZ = GetBoolean(dr.GetString(dr.GetOrdinal("IsZZ")));

                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                    {
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    }

                    model.WeiXinHao = dr["WeiXinHao"].ToString();
                    model.GongSiName = dr["GongSiName"].ToString();
                    model.ZhiWei = dr["ZhiWei"].ToString();
                    model.ShouJi = dr["ShouJi"].ToString();
                    model.TuXiangFilepath = dr["TuXiangFilepath"].ToString();
                    model.QQ = dr["QQ"].ToString();
                    model.YouXiang = dr["YouXiang"].ToString();
                    model.DiZhi = dr["DiZhi"].ToString();
                    model.IsLvYouGuWen = dr["IsLvYouGuWen"].ToString() == "1";
                    model.LvYouGuWenRenZhengTime = dr.GetDateTime(dr.GetOrdinal("LvYouGuWenRenZhengTime"));

                    model.ZanJiShu = dr.GetInt32(dr.GetOrdinal("ZanJiShu"));
                    model.GuanZhuJiShu = dr.GetInt32(dr.GetOrdinal("GuanZhuJiShu"));
                    model.LiuYanJiShu = dr.GetInt32(dr.GetOrdinal("LiuYanJiShu"));

                    model.MingPianId = dr["MingPianId"].ToString();
                    model.MemberOption = (MemberOption)dr.GetInt32(dr.GetOrdinal("MemberOption"));
                    model.ProviceId = dr.GetInt32(dr.GetOrdinal("ProviceId"));
                    model.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                    model.AreaId = dr.GetInt32(dr.GetOrdinal("AreaId"));
                    model.StreetId = dr.GetInt32(dr.GetOrdinal("StreetId"));
                }
            }

            return model;
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.User GetModelByName(string UserName)
        {
            Eyousoft_yhq.Model.User model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [UserID],[UserName],[UserPwd],[ContactName],[ContactSex],[Remark],[IssueTime],[CommissonScale],[PollCode],[PromotionCode],[IsAgent],[valiUser],[YuE],[IsZZ],MemberOption,ProviceId,CityId,AreaId,StreetId   ");

            strSql.Append("  FROM tbl_Member  ");
            strSql.Append(" where UserName=@UserName ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "UserName", System.Data.DbType.AnsiStringFixedLength, UserName);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.User();
                    model.UserID = dr.IsDBNull(dr.GetOrdinal("UserID")) ? "" : dr.GetString(dr.GetOrdinal("UserID"));
                    model.UserName = dr.IsDBNull(dr.GetOrdinal("UserName")) ? "" : dr.GetString(dr.GetOrdinal("UserName"));
                    model.UserPwd = dr.IsDBNull(dr.GetOrdinal("UserPwd")) ? "" : dr.GetString(dr.GetOrdinal("UserPwd"));
                    model.ContactName = dr.IsDBNull(dr.GetOrdinal("ContactName")) ? "" : dr.GetString(dr.GetOrdinal("ContactName"));
                    model.ContactSex = (sexType)dr.GetByte(dr.GetOrdinal("ContactSex"));
                    model.Remark = dr.IsDBNull(dr.GetOrdinal("Remark")) ? "" : dr.GetString(dr.GetOrdinal("Remark"));
                    model.CommissonScale = dr.IsDBNull(dr.GetOrdinal("CommissonScale")) ? 0 : dr.GetDecimal(dr.GetOrdinal("CommissonScale"));
                    model.PollCode = dr.IsDBNull(dr.GetOrdinal("PollCode")) ? "" : dr.GetString(dr.GetOrdinal("PollCode"));
                    model.PromotionCode = dr.IsDBNull(dr.GetOrdinal("PromotionCode")) ? "" : dr.GetString(dr.GetOrdinal("PromotionCode"));
                    model.IsAgent = dr.IsDBNull(dr.GetOrdinal("IsAgent")) ? false : GetBoolean(dr.GetString(dr.GetOrdinal("IsAgent")));
                    model.valiUser = GetBoolean(dr.GetString(dr.GetOrdinal("valiUser")));
                    model.YuE = dr.GetDecimal(dr.GetOrdinal("YuE"));
                    model.IsZZ = GetBoolean(dr.GetString(dr.GetOrdinal("IsZZ")));

                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                    {
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    }
                    model.MemberOption = (MemberOption)dr.GetInt32(dr.GetOrdinal("MemberOption"));
                    model.ProviceId = dr.GetInt32(dr.GetOrdinal("ProviceId"));
                    model.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                    model.AreaId = dr.GetInt32(dr.GetOrdinal("AreaId"));
                    model.StreetId = dr.GetInt32(dr.GetOrdinal("StreetId"));
                }
            }

            return model;
        }

        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="cname"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.User GetModel(string cname, string mobile)
        {
            Eyousoft_yhq.Model.User model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [UserID],[UserName],[UserPwd],[ContactName],[ContactSex],[Remark],[IssueTime],[CommissonScale],[PollCode],[PromotionCode],[IsAgent],[valiUser],[IsZZ],MemberOption,ProviceId,CityId,AreaId,StreetId   ");

            strSql.Append("  FROM tbl_Member  ");
            strSql.Append(" where ContactName=@ContactName and  UserName=@UserName");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ContactName", System.Data.DbType.AnsiStringFixedLength, cname);
            this._db.AddInParameter(cmd, "UserName", System.Data.DbType.AnsiStringFixedLength, mobile);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.User();
                    model.UserID = dr.IsDBNull(dr.GetOrdinal("UserID")) ? "" : dr.GetString(dr.GetOrdinal("UserID"));
                    model.UserName = dr.IsDBNull(dr.GetOrdinal("UserName")) ? "" : dr.GetString(dr.GetOrdinal("UserName"));
                    model.UserPwd = dr.IsDBNull(dr.GetOrdinal("UserPwd")) ? "" : dr.GetString(dr.GetOrdinal("UserPwd"));
                    model.ContactName = dr.IsDBNull(dr.GetOrdinal("ContactName")) ? "" : dr.GetString(dr.GetOrdinal("ContactName"));
                    model.ContactSex = (sexType)dr.GetByte(dr.GetOrdinal("ContactSex"));
                    model.Remark = dr.IsDBNull(dr.GetOrdinal("Remark")) ? "" : dr.GetString(dr.GetOrdinal("Remark"));
                    model.CommissonScale = dr.IsDBNull(dr.GetOrdinal("CommissonScale")) ? 0 : dr.GetDecimal(dr.GetOrdinal("CommissonScale"));
                    model.PollCode = dr.IsDBNull(dr.GetOrdinal("PollCode")) ? "" : dr.GetString(dr.GetOrdinal("PollCode"));
                    model.PromotionCode = dr.IsDBNull(dr.GetOrdinal("PromotionCode")) ? "" : dr.GetString(dr.GetOrdinal("PromotionCode"));
                    model.IsAgent = dr.IsDBNull(dr.GetOrdinal("IsAgent")) ? false : GetBoolean(dr.GetString(dr.GetOrdinal("IsAgent")));
                    model.valiUser = GetBoolean(dr.GetString(dr.GetOrdinal("valiUser")));
                    model.IsZZ = GetBoolean(dr.GetString(dr.GetOrdinal("IsZZ")));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                    {
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    }
                    model.MemberOption = (MemberOption)dr.GetInt32(dr.GetOrdinal("MemberOption"));
                    model.ProviceId = dr.GetInt32(dr.GetOrdinal("ProviceId"));
                    model.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                    model.AreaId = dr.GetInt32(dr.GetOrdinal("AreaId"));
                    model.StreetId = dr.GetInt32(dr.GetOrdinal("StreetId"));
                }
            }

            return model;
        }



        public IList<Eyousoft_yhq.Model.User> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.MSearchUser serModel, int isadmin)
        {
            IList<Eyousoft_yhq.Model.User> list = new List<Eyousoft_yhq.Model.User>();


            string tableName = "tbl_Member";
            string fileds = " *,(SELECT COUNT(1) FROM tbl_Order WHERE MemberID=tbl_Member.UserID  and PayState='2' ) AS OrderCount  ";
            string orderByString = "IssueTime desc";

            StringBuilder query = new StringBuilder();
            query.AppendFormat(" 1=1 ", isadmin);

            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.UserName))
                {
                    query.AppendFormat(" and  UserName like '%{0}%' ", serModel.UserName);
                }

                if (!string.IsNullOrEmpty(serModel.ContactName))
                {
                    query.AppendFormat(" and  ContactName like '%{0}%' ", serModel.ContactName);
                }
                if (!string.IsNullOrEmpty(serModel.PromotionCode))
                {
                    query.AppendFormat(" and  PollCode = '{0}' ", serModel.PromotionCode);
                }
                if (serModel.IsLvYouGuWen.HasValue)
                {
                    query.AppendFormat(" AND IsLvYouGuWen='{0}' ", serModel.IsLvYouGuWen.Value ? "1" : "0");

                    if (serModel.IsLvYouGuWen.Value)
                    {
                        orderByString = "LvYouGuWenRenZhengTime DESC";
                    }
                }
                if (serModel.MemberOption.HasValue)
                {
                    query.AppendFormat(" AND MemberOption='{0}' ", (int)serModel.MemberOption);
                }
                if (serModel.ProviceId != 0)
                {
                    query.AppendFormat(" AND ProviceId='{0}' ", serModel.ProviceId);
                }
                if (serModel.CityId != 0)
                {
                    query.AppendFormat(" AND CityId='{0}' ", serModel.CityId);
                }
                if (serModel.AreaId != 0)
                {
                    query.AppendFormat(" AND AreaId='{0}' ", serModel.AreaId);
                }
                if (serModel.StreetId != 0)
                {
                    query.AppendFormat(" AND StreetId='{0}' ", serModel.StreetId);
                }
            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {

                    Eyousoft_yhq.Model.User model = new Eyousoft_yhq.Model.User();
                    model.UserID = dr.IsDBNull(dr.GetOrdinal("UserID")) ? "" : dr.GetString(dr.GetOrdinal("UserID"));
                    model.UserName = dr.IsDBNull(dr.GetOrdinal("UserName")) ? "" : dr.GetString(dr.GetOrdinal("UserName"));
                    model.UserPwd = dr.IsDBNull(dr.GetOrdinal("UserPwd")) ? "" : dr.GetString(dr.GetOrdinal("UserPwd"));
                    model.ContactName = dr.IsDBNull(dr.GetOrdinal("ContactName")) ? "" : dr.GetString(dr.GetOrdinal("ContactName"));
                    model.ContactSex = (sexType)dr.GetByte(dr.GetOrdinal("ContactSex"));
                    model.Remark = dr.IsDBNull(dr.GetOrdinal("Remark")) ? "" : dr.GetString(dr.GetOrdinal("Remark"));
                    model.CommissonScale = dr.IsDBNull(dr.GetOrdinal("CommissonScale")) ? 0 : dr.GetDecimal(dr.GetOrdinal("CommissonScale"));
                    model.OrderCount = dr.GetInt32(dr.GetOrdinal("OrderCount"));
                    model.PollCode = dr.IsDBNull(dr.GetOrdinal("PollCode")) ? "" : dr.GetString(dr.GetOrdinal("PollCode"));
                    model.PromotionCode = dr.IsDBNull(dr.GetOrdinal("PromotionCode")) ? "" : dr.GetString(dr.GetOrdinal("PromotionCode"));
                    model.IsAgent = dr.IsDBNull(dr.GetOrdinal("IsAgent")) ? false : GetBoolean(dr.GetString(dr.GetOrdinal("IsAgent")));
                    model.valiUser = GetBoolean(dr.GetString(dr.GetOrdinal("valiUser")));
                    model.YuE = dr.GetDecimal(dr.GetOrdinal("YuE"));
                    model.IsZZ = GetBoolean(dr.GetString(dr.GetOrdinal("IsZZ")));

                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                    {
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    }

                    model.WeiXinHao = dr["WeiXinHao"].ToString();
                    model.GongSiName = dr["GongSiName"].ToString();
                    model.ZhiWei = dr["ZhiWei"].ToString();
                    model.ShouJi = dr["ShouJi"].ToString();
                    model.TuXiangFilepath = dr["TuXiangFilepath"].ToString();
                    model.QQ = dr["QQ"].ToString();
                    model.YouXiang = dr["YouXiang"].ToString();
                    model.DiZhi = dr["DiZhi"].ToString();
                    model.IsLvYouGuWen = dr["IsLvYouGuWen"].ToString() == "1";
                    model.LvYouGuWenRenZhengTime = dr.GetDateTime(dr.GetOrdinal("LvYouGuWenRenZhengTime"));

                    model.ZanJiShu = dr.GetInt32(dr.GetOrdinal("ZanJiShu"));
                    model.GuanZhuJiShu = dr.GetInt32(dr.GetOrdinal("GuanZhuJiShu"));
                    model.LiuYanJiShu = dr.GetInt32(dr.GetOrdinal("LiuYanJiShu"));
                    model.MingPianId = dr["MingPianId"].ToString();
                    model.MemberOption = (MemberOption)dr.GetInt32(dr.GetOrdinal("MemberOption"));
                    model.ProviceId = dr.GetInt32(dr.GetOrdinal("ProviceId"));
                    model.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                    model.AreaId = dr.GetInt32(dr.GetOrdinal("AreaId"));
                    model.StreetId = dr.GetInt32(dr.GetOrdinal("StreetId"));

                    list.Add(model);
                }
            }
            return list;
        }

        public IList<Eyousoft_yhq.Model.User> GetList(Eyousoft_yhq.Model.MSearchUser serModel)
        {
            IList<Eyousoft_yhq.Model.User> list = new List<Eyousoft_yhq.Model.User>();
            StringBuilder query = new StringBuilder();
            query.Append("select UserID,UserName,UserPwd,ContactName,ContactSex,Remark,IssueTime,CommissonScale,PollCode,PromotionCode,IsAgent,valiUser,YuE,MemberOption,ProviceId,CityId,AreaId,StreetId   from tbl_Member where  1=1");

            if (serModel != null)
            {

                if (!string.IsNullOrEmpty(serModel.UserName))
                {
                    query.AppendFormat(" and  UserName like '%{0}%' ", serModel.UserName);
                }

                if (!string.IsNullOrEmpty(serModel.ContactName))
                {
                    query.AppendFormat(" and  ContactName like '%{0}%' ", serModel.ContactName);
                }
            }
            query.Append("  order by UserID  DESC  ");
            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {

                    Eyousoft_yhq.Model.User model = new Eyousoft_yhq.Model.User();
                    model.UserID = dr.IsDBNull(dr.GetOrdinal("UserID")) ? "" : dr.GetString(dr.GetOrdinal("UserID"));
                    model.UserName = dr.IsDBNull(dr.GetOrdinal("UserName")) ? "" : dr.GetString(dr.GetOrdinal("UserName"));
                    model.UserPwd = dr.IsDBNull(dr.GetOrdinal("UserPwd")) ? "" : dr.GetString(dr.GetOrdinal("UserPwd"));
                    model.ContactName = dr.IsDBNull(dr.GetOrdinal("ContactName")) ? "" : dr.GetString(dr.GetOrdinal("ContactName"));
                    model.ContactSex = (sexType)dr.GetByte(dr.GetOrdinal("ContactSex"));
                    model.Remark = dr.IsDBNull(dr.GetOrdinal("Remark")) ? "" : dr.GetString(dr.GetOrdinal("Remark"));
                    model.CommissonScale = dr.IsDBNull(dr.GetOrdinal("CommissonScale")) ? 0 : dr.GetDecimal(dr.GetOrdinal("CommissonScale"));
                    model.PollCode = dr.IsDBNull(dr.GetOrdinal("PollCode")) ? "" : dr.GetString(dr.GetOrdinal("PollCode"));
                    model.PromotionCode = dr.IsDBNull(dr.GetOrdinal("PromotionCode")) ? "" : dr.GetString(dr.GetOrdinal("PromotionCode"));
                    model.IsAgent = dr.IsDBNull(dr.GetOrdinal("IsAgent")) ? false : GetBoolean(dr.GetString(dr.GetOrdinal("IsAgent")));
                    model.valiUser = GetBoolean(dr.GetString(dr.GetOrdinal("valiUser")));
                    model.YuE = dr.GetDecimal(dr.GetOrdinal("YuE"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                    {
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    }
                    model.MemberOption = (MemberOption)dr.GetInt32(dr.GetOrdinal("MemberOption"));
                    model.ProviceId = dr.GetInt32(dr.GetOrdinal("ProviceId"));
                    model.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                    model.AreaId = dr.GetInt32(dr.GetOrdinal("AreaId"));
                    model.StreetId = dr.GetInt32(dr.GetOrdinal("StreetId"));
                    list.Add(model);
                }
            }
            return list;
        }



        /// <summary>
        /// 添加用户地址
        /// </summary>
        /// <param name="address">地址信息</param>
        /// <returns></returns>
        public int UserAddressAdd(Eyousoft_yhq.Model.UserAddress address)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("  INSERT INTO  tbl_UserAddress(AddressID,UserID,AddressProvince,AddressCity,AddressInfo,IsDefault,Remark,AddressCountry,ContactName,ZpCode,MobileNum,TelNum) VALUES(@AddressID,@UserID,@AddressProvince,@AddressCity,@AddressInfo,@IsDefault,@Remark,@AddressCountry,@ContactName,@ZpCode,@MobileNum,@TelNum)");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "AddressID", DbType.AnsiStringFixedLength, address.AddressID);
            this._db.AddInParameter(cmd, "UserID", DbType.AnsiStringFixedLength, address.UserID);
            this._db.AddInParameter(cmd, "AddressProvince", DbType.Int32, address.AddressProvince);
            this._db.AddInParameter(cmd, "AddressCity", DbType.Int32, address.AddressCity);
            this._db.AddInParameter(cmd, "AddressInfo", DbType.String, address.AddressInfo);
            this._db.AddInParameter(cmd, "IsDefault", DbType.Byte, this.GetBooleanToStr(address.IsDefault));
            this._db.AddInParameter(cmd, "Remark", DbType.String, address.Remark);

            this._db.AddInParameter(cmd, "AddressCountry", DbType.Int32, address.AddressCountry);
            this._db.AddInParameter(cmd, "ContactName", DbType.String, address.ContactName);
            this._db.AddInParameter(cmd, "ZpCode", DbType.String, address.ZpCode);
            this._db.AddInParameter(cmd, "MobileNum", DbType.String, address.MobileNum);
            this._db.AddInParameter(cmd, "TelNum", DbType.String, address.TelNum);




            return DbHelper.ExecuteSql(cmd, this._db);

        }

        /// <summary>
        /// 修改地址
        /// </summary>
        /// <param name="address">地址信息</param>
        /// <returns></returns>
        public int UserAddressUpdate(Eyousoft_yhq.Model.UserAddress address)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_UserAddress_Update");

            this._db.AddInParameter(cmd, "AddressID", DbType.AnsiStringFixedLength, address.AddressID);
            this._db.AddInParameter(cmd, "UserID", DbType.AnsiStringFixedLength, address.UserID);
            this._db.AddInParameter(cmd, "AddressProvince", DbType.Int32, address.AddressProvince);
            this._db.AddInParameter(cmd, "AddressCity", DbType.Int32, address.AddressCity);
            this._db.AddInParameter(cmd, "AddressInfo", DbType.String, address.AddressInfo);
            this._db.AddInParameter(cmd, "IsDefault", DbType.Byte, this.GetBooleanToStr(address.IsDefault));
            this._db.AddInParameter(cmd, "Remark", DbType.String, address.Remark);


            this._db.AddInParameter(cmd, "AddressCountry", DbType.Int32, address.AddressCountry);
            this._db.AddInParameter(cmd, "ContactName", DbType.String, address.ContactName);
            this._db.AddInParameter(cmd, "ZpCode", DbType.String, address.ZpCode);
            this._db.AddInParameter(cmd, "MobileNum", DbType.String, address.MobileNum);
            this._db.AddInParameter(cmd, "TelNum", DbType.String, address.TelNum);



            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            DbHelper.RunProcedureWithResult(cmd, this._db);
            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));


        }
        /// <summary>
        /// 设置默认状态
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public int UserAddressDefaultUpdate(Eyousoft_yhq.Model.UserAddress address)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_UserAddress_DefaultUpdate");

            this._db.AddInParameter(cmd, "AddressID", DbType.AnsiStringFixedLength, address.AddressID);
            this._db.AddInParameter(cmd, "UserID", DbType.AnsiStringFixedLength, address.UserID);
            this._db.AddInParameter(cmd, "IsDefault", DbType.Byte, this.GetBooleanToStr(address.IsDefault));
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            DbHelper.RunProcedureWithResult(cmd, this._db);
            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));


        }
        /// <summary>
        /// 转账
        /// </summary>
        /// <param name="memberid">操作人ID</param>
        /// <param name="account">转入账户</param>
        /// <param name="money">转账金额</param>
        /// <returns></returns>
        public int UpdatePayState(string memberid, string account, decimal money)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_ZhuanZhang");
            this._db.AddInParameter(cmd, "memnberId", DbType.String, memberid);
            this._db.AddInParameter(cmd, "userAccount", DbType.String, account);
            this._db.AddInParameter(cmd, "jinE", DbType.Decimal, money);
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

            DbHelper.RunProcedureWithResult(cmd, this._db);
            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 删除地址
        /// </summary>
        /// <param name="address">地址信息</param>
        /// <returns></returns>
        public int UserAddressDelete(string address)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" DELETE FROM tbl_UserAddress WHERE AddressID=@AddressID");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "AddressID", DbType.AnsiStringFixedLength, address);

            return DbHelper.ExecuteSql(cmd, this._db);

        }


        /// <summary>
        /// 获取用户地址
        /// </summary>
        /// <param name="address">地址信息</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.UserAddress GetAddress(string Address)
        {
            Eyousoft_yhq.Model.UserAddress model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT AddressID,UserID,AddressProvince,AddressCity,AddressCountry,AddressInfo,IsDefault,Remark,ContactName,ZpCode,MobileNum,TelNum,  ");
            strSql.Append("(SELECT UserName FROM tbl_Member  WHERE UserID = tbl_UserAddress.UserID) as UserName, ");
            strSql.Append("(SELECT Name FROM tbl_SysProvince  WHERE ID = tbl_UserAddress.AddressProvince) as AddressProvinceName, ");
            strSql.Append("(SELECT Name FROM tbl_SysCity  WHERE Id = tbl_UserAddress.AddressCity) as AddressCityName, ");
            strSql.Append("(SELECT Name FROM tbl_SysDistrict  WHERE Id = tbl_UserAddress.AddressCountry) as AddressCountryName ");
            strSql.Append(" FROM  tbl_UserAddress ");

            strSql.Append(" where AddressID=@AddressID ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "AddressID", System.Data.DbType.AnsiStringFixedLength, Address);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.UserAddress();
                    model.UserID = dr.GetString(dr.GetOrdinal("UserID"));
                    model.UserName = dr.IsDBNull(dr.GetOrdinal("UserName")) ? "" : dr.GetString(dr.GetOrdinal("UserName"));
                    model.AddressID = dr.IsDBNull(dr.GetOrdinal("AddressID")) ? "" : dr.GetString(dr.GetOrdinal("AddressID"));
                    model.AddressProvince = dr.IsDBNull(dr.GetOrdinal("AddressProvince")) ? 0 : dr.GetInt32(dr.GetOrdinal("AddressProvince"));
                    model.AddressCity = dr.IsDBNull(dr.GetOrdinal("AddressCity")) ? 0 : dr.GetInt32(dr.GetOrdinal("AddressCity"));
                    model.AddressInfo = dr.IsDBNull(dr.GetOrdinal("AddressInfo")) ? "" : dr.GetString(dr.GetOrdinal("AddressInfo"));
                    model.IsDefault = dr.IsDBNull(dr.GetOrdinal("IsDefault")) ? false : this.GetBoolean(dr.GetString(dr.GetOrdinal("IsDefault")));
                    model.Remark = dr.IsDBNull(dr.GetOrdinal("Remark")) ? "" : dr.GetString(dr.GetOrdinal("Remark"));

                    model.AddressCountry = dr.GetInt32(dr.GetOrdinal("AddressCountry"));
                    model.ContactName = dr.IsDBNull(dr.GetOrdinal("ContactName")) ? "" : dr.GetString(dr.GetOrdinal("ContactName"));
                    model.ZpCode = dr.IsDBNull(dr.GetOrdinal("ZpCode")) ? "" : dr.GetString(dr.GetOrdinal("ZpCode"));
                    model.MobileNum = dr.IsDBNull(dr.GetOrdinal("MobileNum")) ? "" : dr.GetString(dr.GetOrdinal("MobileNum"));
                    model.TelNum = dr.IsDBNull(dr.GetOrdinal("TelNum")) ? "" : dr.GetString(dr.GetOrdinal("TelNum"));

                    model.AddressProvinceName = dr.IsDBNull(dr.GetOrdinal("AddressProvinceName")) ? "" : dr.GetString(dr.GetOrdinal("AddressProvinceName"));
                    model.AddressCityName = dr.IsDBNull(dr.GetOrdinal("AddressCityName")) ? "" : dr.GetString(dr.GetOrdinal("AddressCityName"));
                    model.AddressCountryName = dr.IsDBNull(dr.GetOrdinal("AddressCountryName")) ? "" : dr.GetString(dr.GetOrdinal("AddressCountryName"));

                }
            }

            return model;
        }

        /// <summary>
        /// 获取用户地址
        /// </summary>
        /// <param name="address">地址信息</param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.UserAddress> GetAddressList(int top, string userID)
        {
            IList<Eyousoft_yhq.Model.UserAddress> list = new List<Eyousoft_yhq.Model.UserAddress>();

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select  {0} * , ", top > 0 ? " top " + top : "");
            strSql.Append("(SELECT UserName FROM tbl_Member  WHERE UserID = tbl_UserAddress.UserID) as UserName, ");
            strSql.Append("(SELECT Name FROM tbl_SysProvince  WHERE ID = tbl_UserAddress.AddressProvince) as AddressProvinceName, ");
            strSql.Append("(SELECT Name FROM tbl_SysCity  WHERE Id = tbl_UserAddress.AddressCity) as AddressCityName, ");
            strSql.Append("(SELECT Name FROM tbl_SysDistrict  WHERE Id = tbl_UserAddress.AddressCountry) as AddressCountryName ");
            strSql.AppendFormat(" from tbl_UserAddress where UserID=@UserID");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "UserID", System.Data.DbType.AnsiStringFixedLength, userID);
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    Eyousoft_yhq.Model.UserAddress model = new Eyousoft_yhq.Model.UserAddress();
                    model.UserID = dr.GetString(dr.GetOrdinal("UserID"));
                    model.AddressID = dr.IsDBNull(dr.GetOrdinal("AddressID")) ? "" : dr.GetString(dr.GetOrdinal("AddressID"));
                    model.AddressProvince = dr.IsDBNull(dr.GetOrdinal("AddressProvince")) ? 0 : dr.GetInt32(dr.GetOrdinal("AddressProvince"));
                    model.AddressCity = dr.IsDBNull(dr.GetOrdinal("AddressCity")) ? 0 : dr.GetInt32(dr.GetOrdinal("AddressCity"));
                    model.AddressInfo = dr.IsDBNull(dr.GetOrdinal("AddressInfo")) ? "" : dr.GetString(dr.GetOrdinal("AddressInfo"));
                    model.IsDefault = dr.IsDBNull(dr.GetOrdinal("IsDefault")) ? false : this.GetBoolean(dr.GetString(dr.GetOrdinal("IsDefault")));
                    model.Remark = dr.IsDBNull(dr.GetOrdinal("Remark")) ? "" : dr.GetString(dr.GetOrdinal("Remark"));

                    model.AddressCountry = dr.GetInt32(dr.GetOrdinal("AddressCountry"));
                    model.ContactName = dr.IsDBNull(dr.GetOrdinal("ContactName")) ? "" : dr.GetString(dr.GetOrdinal("ContactName"));
                    model.ZpCode = dr.IsDBNull(dr.GetOrdinal("ZpCode")) ? "" : dr.GetString(dr.GetOrdinal("ZpCode"));
                    model.MobileNum = dr.IsDBNull(dr.GetOrdinal("MobileNum")) ? "" : dr.GetString(dr.GetOrdinal("MobileNum"));
                    model.TelNum = dr.IsDBNull(dr.GetOrdinal("TelNum")) ? "" : dr.GetString(dr.GetOrdinal("TelNum"));

                    model.AddressProvinceName = dr.IsDBNull(dr.GetOrdinal("AddressProvinceName")) ? "" : dr.GetString(dr.GetOrdinal("AddressProvinceName"));
                    model.AddressCityName = dr.IsDBNull(dr.GetOrdinal("AddressCityName")) ? "" : dr.GetString(dr.GetOrdinal("AddressCityName"));
                    model.AddressCountryName = dr.IsDBNull(dr.GetOrdinal("AddressCountryName")) ? "" : dr.GetString(dr.GetOrdinal("AddressCountryName"));

                    list.Add(model);
                }
            }

            return list;
        }


        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.UserAddress> GetAddressList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.MSearchUserAddress serModel)
        {
            IList<Eyousoft_yhq.Model.UserAddress> list = new List<Eyousoft_yhq.Model.UserAddress>();


            string tableName = "tbl_UserAddress";
            string fileds = " AddressID,UserID,AddressProvince,AddressCity,AddressCountry,AddressInfo,IsDefault,Remark,ContactName,ZpCode,MobileNum,TelNum, (SELECT UserName FROM tbl_Member  WHERE UserID = tbl_UserAddress.UserID) as UserName,(SELECT Name FROM tbl_SysProvince  WHERE ID = tbl_UserAddress.AddressProvince) as AddressProvinceName,(SELECT Name FROM tbl_SysCity  WHERE Id = tbl_UserAddress.AddressCity) as AddressCityName,(SELECT Name FROM tbl_SysDistrict  WHERE Id = tbl_UserAddress.AddressCountry) as AddressCountryName     ";
            string orderByString = " ";

            StringBuilder query = new StringBuilder();
            query.AppendFormat(" 1=1 ");

            if (serModel != null)
            {

            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    Eyousoft_yhq.Model.UserAddress model = new Eyousoft_yhq.Model.UserAddress();
                    model.UserID = dr.GetString(dr.GetOrdinal("UserID"));
                    model.AddressID = dr.IsDBNull(dr.GetOrdinal("AddressID")) ? "" : dr.GetString(dr.GetOrdinal("AddressID"));
                    model.AddressProvince = dr.IsDBNull(dr.GetOrdinal("AddressProvince")) ? 0 : dr.GetInt32(dr.GetOrdinal("AddressProvince"));
                    model.AddressCity = dr.IsDBNull(dr.GetOrdinal("AddressCity")) ? 0 : dr.GetInt32(dr.GetOrdinal("AddressCity"));
                    model.AddressInfo = dr.IsDBNull(dr.GetOrdinal("AddressInfo")) ? "" : dr.GetString(dr.GetOrdinal("AddressInfo"));
                    model.IsDefault = dr.IsDBNull(dr.GetOrdinal("IsDefault")) ? false : this.GetBoolean(dr.GetString(dr.GetOrdinal("IsDefault")));
                    model.Remark = dr.IsDBNull(dr.GetOrdinal("Remark")) ? "" : dr.GetString(dr.GetOrdinal("Remark"));

                    model.AddressCountry = dr.GetInt32(dr.GetOrdinal("AddressCountry"));
                    model.ContactName = dr.IsDBNull(dr.GetOrdinal("ContactName")) ? "" : dr.GetString(dr.GetOrdinal("ContactName"));
                    model.ZpCode = dr.IsDBNull(dr.GetOrdinal("ZpCode")) ? "" : dr.GetString(dr.GetOrdinal("ZpCode"));
                    model.MobileNum = dr.IsDBNull(dr.GetOrdinal("MobileNum")) ? "" : dr.GetString(dr.GetOrdinal("MobileNum"));
                    model.TelNum = dr.IsDBNull(dr.GetOrdinal("TelNum")) ? "" : dr.GetString(dr.GetOrdinal("TelNum"));

                    model.AddressProvinceName = dr.IsDBNull(dr.GetOrdinal("AddressProvinceName")) ? "" : dr.GetString(dr.GetOrdinal("AddressProvinceName"));
                    model.AddressCityName = dr.IsDBNull(dr.GetOrdinal("AddressCityName")) ? "" : dr.GetString(dr.GetOrdinal("AddressCityName"));
                    model.AddressCountryName = dr.IsDBNull(dr.GetOrdinal("AddressCountryName")) ? "" : dr.GetString(dr.GetOrdinal("AddressCountryName"));

                    list.Add(model);
                }
            }
            return list;
        }


        #endregion


        /// <summary>
        /// 给会员充值
        /// </summary>
        /// <param name="username">会员名</param>
        /// <returns></returns>
        public int HuiYuangZZ(string username, decimal money)
        {

            StringBuilder strSql = new StringBuilder();

            strSql.Append(" update tbl_Member set YuE=YuE+@YuE where UserName=@UserName");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "YuE", DbType.Decimal, money);
            this._db.AddInParameter(cmd, "UserName", DbType.String, username);

            return DbHelper.ExecuteSql(cmd, this._db);

        }
        /// <summary>
        /// 给会员充值
        /// </summary>
        /// <param name="username">会员编号</param>
        /// <returns></returns>
        public int HuiYuangZzByID(string id, decimal money)
        {

            StringBuilder strSql = new StringBuilder();

            strSql.Append(" update tbl_Member set YuE=YuE+@YuE where UserID=@UserID");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "YuE", DbType.Decimal, money);
            this._db.AddInParameter(cmd, "UserID", DbType.String, id);

            return DbHelper.ExecuteSql(cmd, this._db);

        }
        /// <summary>
        /// 设置账户金额
        /// </summary>
        /// <param name="username">会员编号</param>
        /// <returns></returns>
        public int setMoney(string id, decimal money)
        {

            StringBuilder strSql = new StringBuilder();

            strSql.Append(" update tbl_Member set YuE=@YuE where UserID=@UserID");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "YuE", DbType.Decimal, money);
            this._db.AddInParameter(cmd, "UserID", DbType.String, id);

            return DbHelper.ExecuteSql(cmd, this._db);

        }
        /// <summary>
        /// 会员新增修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int HuiYuan_CU(Eyousoft_yhq.Model.User info)
        {
            var cmd = _db.GetStoredProcCommand("proc_HuiYuan_CU");
            _db.AddInParameter(cmd, "@HuiYuanId", DbType.AnsiStringFixedLength, info.UserID);
            _db.AddInParameter(cmd, "@YongHuMing", DbType.String, info.UserName);
            _db.AddInParameter(cmd, "@MiMa", DbType.String, info.UserPwd);
            _db.AddInParameter(cmd, "@MiMaMD5", DbType.String, "");
            _db.AddInParameter(cmd, "@XingMing", DbType.String, info.ContactName);
            _db.AddInParameter(cmd, "@XingBie", DbType.Byte, info.ContactSex);
            _db.AddInParameter(cmd, "@BeiZhu", DbType.String, info.Remark);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "@FanYong", DbType.Decimal, info.CommissonScale);
            _db.AddInParameter(cmd, "@IsDaiLi", DbType.AnsiStringFixedLength, info.IsAgent ? "1" : "0");
            _db.AddInParameter(cmd, "@ZhuCeMa", DbType.String, info.PollCode);
            _db.AddInParameter(cmd, "@TuiGuangMa", DbType.String, info.PromotionCode);
            _db.AddInParameter(cmd, "@IsYanZheng", DbType.AnsiStringFixedLength, info.valiUser ? "1" : "0");
            _db.AddInParameter(cmd, "@YuE", DbType.Currency, info.YuE);
            _db.AddInParameter(cmd, "@IsYunXuZhuanZhang", DbType.AnsiStringFixedLength, info.IsZZ ? "1" : "0");
            _db.AddInParameter(cmd, "@WeiXinHao", DbType.String, info.WeiXinHao);
            _db.AddInParameter(cmd, "@GongSiName", DbType.String, info.GongSiName);
            _db.AddInParameter(cmd, "@ZhiWei", DbType.String, info.ZhiWei);
            _db.AddInParameter(cmd, "@ShouJi", DbType.String, info.ShouJi);
            _db.AddInParameter(cmd, "@TuXiangFilepath", DbType.String, info.TuXiangFilepath);
            _db.AddInParameter(cmd, "@QQ", DbType.String, info.QQ);
            _db.AddInParameter(cmd, "@YouXiang", DbType.String, info.YouXiang);
            _db.AddInParameter(cmd, "@DiZhi", DbType.String, info.DiZhi);
            _db.AddInParameter(cmd, "@IsLvYouGuWen", DbType.AnsiStringFixedLength, info.IsLvYouGuWen ? "1" : "0");
            _db.AddInParameter(cmd, "@LvYouGuWenRenZhengTime", DbType.DateTime, info.LvYouGuWenRenZhengTime);
            _db.AddInParameter(cmd, "ProviceId", System.Data.DbType.Int32, info.ProviceId);
            _db.AddInParameter(cmd, "CityId", System.Data.DbType.Int32, info.CityId);
            _db.AddInParameter(cmd, "AreaId", System.Data.DbType.Int32, info.AreaId);
            _db.AddInParameter(cmd, "StreetId", System.Data.DbType.Int32, info.StreetId);
            _db.AddOutParameter(cmd, "@RetCode", DbType.Int32, 4);

            int sqlExceptionCode = 0;

            try
            {
                DbHelper.RunProcedure(cmd, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /// <summary>
        /// 获取名片信息业务实体
        /// </summary>
        /// <param name="mingPianId">名片编号</param>
        /// <returns></returns>
        public MMingPianInfo GetMingPianInfo(string mingPianId)
        {
            MMingPianInfo info = null;
            var cmd = _db.GetSqlStringCommand("SELECT * FROM tbl_Member WHERE MingPianId=@MingPianId");
            _db.AddInParameter(cmd, "MingPianId", DbType.AnsiStringFixedLength, mingPianId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new MMingPianInfo();
                    info.GongSiName = rdr["GongSiName"].ToString();
                    info.GuanZhuJiShu = rdr.GetInt32(rdr.GetOrdinal("GuanZhuJiShu"));
                    info.HuiYuanId = rdr["UserID"].ToString();
                    info.LiuYanJiShu = rdr.GetInt32(rdr.GetOrdinal("LiuYanJiShu"));
                    info.MingPianId = mingPianId;
                    info.ShouJi = rdr["ShouJi"].ToString();
                    info.WeiXinHao = rdr["WeiXinHao"].ToString();
                    info.XingMing = rdr["ContactName"].ToString();
                    info.ZanJiShu = rdr.GetInt32(rdr.GetOrdinal("ZanJiShu"));
                    info.ZhiWei = rdr["ZhiWei"].ToString();
                    info.TuXiangFilepath = rdr["TuXiangFilepath"].ToString();
                    info.DianZanTime = rdr.GetDateTime(rdr.GetOrdinal("DianZanTime"));
                    info.LiuYanTime = rdr.GetDateTime(rdr.GetOrdinal("LiuYanTime"));
                    info.GuanZhuTime = rdr.GetDateTime(rdr.GetOrdinal("GuanZhuTime"));
                }
            }

            return info;
        }

    }
}

