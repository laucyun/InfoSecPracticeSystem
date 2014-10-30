using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using Model;//Please add references
namespace DAL
{
    /// <summary>
    /// 数据访问类:kaoshi
    /// </summary>
    public partial class kaoshiDAL
    {
        public kaoshiDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string nc_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from kaoshi");
            strSql.Append(" where nc_id=@nc_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@nc_id", SqlDbType.NChar,20)			};
            parameters[0].Value = nc_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(kaoshiModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into kaoshi(");
            strSql.Append("nc_kaoshiId,nc_qid,nc_daanid,bit_isRight,nc_uid)");
            strSql.Append(" values (");
            strSql.Append("@nc_kaoshiId,@nc_qid,@nc_daanid,@bit_isRight,@nc_uid)");
            SqlParameter[] parameters = {
					new SqlParameter("@nc_kaoshiId", SqlDbType.NChar,18),
					new SqlParameter("@nc_qid", SqlDbType.NChar,10),
					new SqlParameter("@nc_daanid", SqlDbType.NChar,12),
					new SqlParameter("@bit_isRight", SqlDbType.Bit,1),
                    new SqlParameter("@nc_uid", SqlDbType.NChar,20)};
            parameters[0].Value = model.nc_kaoshiId;
            parameters[1].Value = model.nc_qid;
            parameters[2].Value = model.nc_daanid;
            parameters[3].Value = model.bit_isRight;
        parameters[4].Value = model.nc_uid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 修改成绩
        /// </summary>
        public bool UpDateChengji(string nc_kaoshiId, string nvc_chengji)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("upDate kaoshi set ");
            strSql.Append("nvc_chengji=@nvc_chengji ");
            strSql.Append(" where nc_kaoshiId=@nc_kaoshiId ");
            SqlParameter[] parameters = {
					new SqlParameter("@nc_kaoshiId", SqlDbType.NChar,18),
					new SqlParameter("@nvc_chengji", SqlDbType.NVarChar,50)};
            parameters[0].Value = nc_kaoshiId;
            parameters[1].Value = nvc_chengji;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 修改考试时间
        /// </summary>
        public bool UpDateShijian(string nc_kaoshiId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("upDate kaoshi set ");
            strSql.Append("dt_shijian=getdate() ");
            strSql.Append(" where nc_kaoshiId=@nc_kaoshiId ");
            SqlParameter[] parameters = {
					new SqlParameter("@nc_kaoshiId", SqlDbType.NChar,18)};
            parameters[0].Value = nc_kaoshiId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(kaoshiModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update kaoshi set ");
            strSql.Append("nc_kaoshiId=@nc_kaoshiId,");
            strSql.Append("nc_qid=@nc_qid,");
            strSql.Append("nc_daanid=@nc_daanid,");
            strSql.Append("bit_isRight=@bit_isRight,");
            strSql.Append("nvc_chengji=@nvc_chengji,");
            strSql.Append("dt_shijian=@dt_shijian,");
            strSql.Append("nc_uid=@nc_uid");
            strSql.Append(" where nc_id=@nc_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@nc_kaoshiId", SqlDbType.NChar,18),
					new SqlParameter("@nc_qid", SqlDbType.NChar,10),
					new SqlParameter("@nc_daanid", SqlDbType.NChar,12),
					new SqlParameter("@bit_isRight", SqlDbType.Bit,1),
					new SqlParameter("@nvc_chengji", SqlDbType.NVarChar,50),
					new SqlParameter("@dt_shijian", SqlDbType.DateTime),
					new SqlParameter("@nc_uid", SqlDbType.NChar,20),
					new SqlParameter("@nc_id", SqlDbType.NChar,20)};
            parameters[0].Value = model.nc_kaoshiId;
            parameters[1].Value = model.nc_qid;
            parameters[2].Value = model.nc_daanid;
            parameters[3].Value = model.bit_isRight;
            parameters[4].Value = model.nvc_chengji;
            parameters[5].Value = model.dt_shijian;
            parameters[6].Value = model.nc_uid;
            parameters[7].Value = model.nc_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string nc_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from kaoshi ");
            strSql.Append(" where nc_id=@nc_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@nc_id", SqlDbType.NChar,20)			};
            parameters[0].Value = nc_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string nc_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from kaoshi ");
            strSql.Append(" where nc_id in (" + nc_idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public kaoshiModel GetModel(string nc_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 nc_id,nc_kaoshiId,nc_qid,nc_daanid,bit_isRight,nvc_chengji,dt_shijian,nc_uid from kaoshi ");
            strSql.Append(" where nc_id=@nc_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@nc_id", SqlDbType.NChar,20)			};
            parameters[0].Value = nc_id;

            kaoshiModel model = new kaoshiModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public kaoshiModel DataRowToModel(DataRow row)
        {
            kaoshiModel model = new kaoshiModel();
            if (row != null)
            {
                if (row["nc_id"] != null)
                {
                    model.nc_id = row["nc_id"].ToString();
                }
                if (row["nc_kaoshiId"] != null)
                {
                    model.nc_kaoshiId = row["nc_kaoshiId"].ToString();
                }
                if (row["nc_qid"] != null)
                {
                    model.nc_qid = row["nc_qid"].ToString();
                }
                if (row["nc_daanid"] != null)
                {
                    model.nc_daanid = row["nc_daanid"].ToString();
                }
                if (row["bit_isRight"] != null && row["bit_isRight"].ToString() != "")
                {
                    if ((row["bit_isRight"].ToString() == "1") || (row["bit_isRight"].ToString().ToLower() == "true"))
                    {
                        model.bit_isRight = true;
                    }
                    else
                    {
                        model.bit_isRight = false;
                    }
                }
                if (row["nvc_chengji"] != null)
                {
                    model.nvc_chengji = row["nvc_chengji"].ToString();
                }
                if (row["dt_shijian"] != null && row["dt_shijian"].ToString() != "")
                {
                    model.dt_shijian = DateTime.Parse(row["dt_shijian"].ToString());
                }
                if (row["nc_uid"] != null)
                {
                    model.nc_uid = row["nc_uid"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select nc_id,nc_kaoshiId,nc_qid,nc_daanid,bit_isRight,nvc_chengji,dt_shijian,nc_uid ");
            strSql.Append(" FROM kaoshi ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" nc_id,nc_kaoshiId,nc_qid,nc_daanid,bit_isRight,nvc_chengji,dt_shijian,nc_uid ");
            strSql.Append(" FROM kaoshi ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM kaoshi ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.nc_id desc");
            }
            strSql.Append(")AS Row, T.*  from kaoshi T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "kaoshi";
            parameters[1].Value = "nc_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

