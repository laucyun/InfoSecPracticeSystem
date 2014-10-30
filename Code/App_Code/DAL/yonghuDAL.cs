using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using Model;//Please add references
namespace DAL
{
	/// <summary>
	/// 数据访问类:yonghu
	/// </summary>
	public partial class yonghuDAL
	{
		public yonghuDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool ExistsUserName(string nvc_username)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from yonghu");
            strSql.Append(" where nvc_username=@nvc_username ");
			SqlParameter[] parameters = {
					new SqlParameter("@nvc_username", SqlDbType.NVarChar,50)			};
            parameters[0].Value = nvc_username;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(yonghuModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into yonghu(");
			strSql.Append("nvc_username,nvc_pwd,int_right)");
			strSql.Append(" values (");
			strSql.Append("@nvc_username,@nvc_pwd,@int_right)");
			SqlParameter[] parameters = {
					new SqlParameter("@nvc_username", SqlDbType.NVarChar,50),
					new SqlParameter("@nvc_pwd", SqlDbType.NVarChar,50),
					new SqlParameter("@int_right", SqlDbType.Int,4)};
			parameters[0].Value = model.nvc_username;
			parameters[1].Value = model.nvc_pwd;
			parameters[2].Value = model.int_right;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(yonghuModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update yonghu set ");
			strSql.Append("nvc_username=@nvc_username,");
			strSql.Append("nvc_pwd=@nvc_pwd,");
			strSql.Append("int_right=@int_right,");
			strSql.Append("dt_register=@dt_register");
			strSql.Append(" where nc_uid=@nc_uid ");
			SqlParameter[] parameters = {
					new SqlParameter("@nvc_username", SqlDbType.NVarChar,50),
					new SqlParameter("@nvc_pwd", SqlDbType.NVarChar,50),
					new SqlParameter("@int_right", SqlDbType.Int,4),
					new SqlParameter("@dt_register", SqlDbType.DateTime),
					new SqlParameter("@nc_uid", SqlDbType.NChar,20)};
			parameters[0].Value = model.nvc_username;
			parameters[1].Value = model.nvc_pwd;
			parameters[2].Value = model.int_right;
			parameters[3].Value = model.dt_register;
			parameters[4].Value = model.nc_uid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(string nc_uid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from yonghu ");
			strSql.Append(" where nc_uid=@nc_uid ");
			SqlParameter[] parameters = {
					new SqlParameter("@nc_uid", SqlDbType.NChar,20)			};
			parameters[0].Value = nc_uid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string nc_uidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from yonghu ");
			strSql.Append(" where nc_uid in ("+nc_uidlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public yonghuModel GetModelById(string nc_uid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 nc_uid,nvc_username,nvc_pwd,int_right,dt_register from yonghu ");
			strSql.Append(" where nc_uid=@nc_uid ");
			SqlParameter[] parameters = {
					new SqlParameter("@nc_uid", SqlDbType.NChar,20)			};
			parameters[0].Value = nc_uid;

			yonghuModel model=new yonghuModel();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
        public yonghuModel GetModelByUsername(string username)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 nc_uid,nvc_username,nvc_pwd,int_right,dt_register from yonghu ");
            strSql.Append(" where nvc_username=@nvc_username ");
            SqlParameter[] parameters = {
					new SqlParameter("@nvc_username", SqlDbType.NVarChar,50)			};
            parameters[0].Value = username;

            yonghuModel model = new yonghuModel();
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
		public yonghuModel DataRowToModel(DataRow row)
		{
			yonghuModel model=new yonghuModel();
			if (row != null)
			{
				if(row["nc_uid"]!=null)
				{
					model.nc_uid=row["nc_uid"].ToString();
				}
				if(row["nvc_username"]!=null)
				{
					model.nvc_username=row["nvc_username"].ToString();
				}
				if(row["nvc_pwd"]!=null)
				{
					model.nvc_pwd=row["nvc_pwd"].ToString();
				}
				if(row["int_right"]!=null && row["int_right"].ToString()!="")
				{
					model.int_right=int.Parse(row["int_right"].ToString());
				}
				if(row["dt_register"]!=null && row["dt_register"].ToString()!="")
				{
					model.dt_register=DateTime.Parse(row["dt_register"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select nc_uid,nvc_username,nvc_pwd,int_right,dt_register ");
			strSql.Append(" FROM yonghu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" nc_uid,nvc_username,nvc_pwd,int_right,dt_register ");
			strSql.Append(" FROM yonghu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM yonghu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.nc_uid desc");
			}
			strSql.Append(")AS Row, T.*  from yonghu T ");
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
			parameters[0].Value = "yonghu";
			parameters[1].Value = "nc_uid";
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

