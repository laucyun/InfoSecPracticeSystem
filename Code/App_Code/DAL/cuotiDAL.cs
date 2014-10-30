using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using Model;//Please add references
namespace DAL
{
	/// <summary>
	/// 数据访问类:cuoti
	/// </summary>
	public partial class cuotiDAL
	{
		public cuotiDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string nc_ctid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from cuoti");
			strSql.Append(" where nc_ctid=@nc_ctid ");
			SqlParameter[] parameters = {
					new SqlParameter("@nc_ctid", SqlDbType.NChar,20)			};
			parameters[0].Value = nc_ctid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(cuotiModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into cuoti(");
			strSql.Append("nc_qid,nc_uid)");
			strSql.Append(" values (");
			strSql.Append("@nc_qid,@nc_uid)");
			SqlParameter[] parameters = {
					new SqlParameter("@nc_qid", SqlDbType.NChar,10),
					new SqlParameter("@nc_uid", SqlDbType.NChar,20)};
			parameters[0].Value = model.nc_qid;
			parameters[1].Value = model.nc_uid;

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
		public bool Update(cuotiModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update cuoti set ");
			strSql.Append("nc_qid=@nc_qid,");
			strSql.Append("nc_uid=@nc_uid");
			strSql.Append(" where nc_ctid=@nc_ctid ");
			SqlParameter[] parameters = {
					new SqlParameter("@nc_qid", SqlDbType.NChar,10),
					new SqlParameter("@nc_uid", SqlDbType.NChar,20),
					new SqlParameter("@nc_ctid", SqlDbType.NChar,20)};
			parameters[0].Value = model.nc_qid;
			parameters[1].Value = model.nc_uid;
			parameters[2].Value = model.nc_ctid;

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
		public bool Delete(string nc_ctid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from cuoti ");
			strSql.Append(" where nc_ctid=@nc_ctid ");
			SqlParameter[] parameters = {
					new SqlParameter("@nc_ctid", SqlDbType.NChar,20)			};
			parameters[0].Value = nc_ctid;

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
		public bool DeleteList(string nc_ctidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from cuoti ");
			strSql.Append(" where nc_ctid in ("+nc_ctidlist + ")  ");
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
		public cuotiModel GetModel(string nc_ctid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 nc_ctid,nc_qid,nc_uid from cuoti ");
			strSql.Append(" where nc_ctid=@nc_ctid ");
			SqlParameter[] parameters = {
					new SqlParameter("@nc_ctid", SqlDbType.NChar,20)			};
			parameters[0].Value = nc_ctid;

			cuotiModel model=new cuotiModel();
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
		public cuotiModel DataRowToModel(DataRow row)
		{
			cuotiModel model=new cuotiModel();
			if (row != null)
			{
				if(row["nc_ctid"]!=null)
				{
					model.nc_ctid=row["nc_ctid"].ToString();
				}
				if(row["nc_qid"]!=null)
				{
					model.nc_qid=row["nc_qid"].ToString();
				}
				if(row["nc_uid"]!=null)
				{
					model.nc_uid=row["nc_uid"].ToString();
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
			strSql.Append("select distinct nc_qid ");
			strSql.Append(" FROM cuoti ");
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
			strSql.Append(" nc_ctid,nc_qid,nc_uid ");
			strSql.Append(" FROM cuoti ");
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
			strSql.Append("select count(1) FROM cuoti ");
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
				strSql.Append("order by T.nc_ctid desc");
			}
			strSql.Append(")AS Row, T.*  from cuoti T ");
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
			parameters[0].Value = "cuoti";
			parameters[1].Value = "nc_ctid";
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

