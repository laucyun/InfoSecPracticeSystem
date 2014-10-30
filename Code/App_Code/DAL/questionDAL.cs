using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using Model;//Please add references
namespace DAL
{
	/// <summary>
	/// 数据访问类:question
	/// </summary>
	public partial class questionDAL
	{
        public questionDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string nc_qid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from question");
			strSql.Append(" where nc_qid=@nc_qid ");
			SqlParameter[] parameters = {
					new SqlParameter("@nc_qid", SqlDbType.NChar,10)			};
			parameters[0].Value = nc_qid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(questionModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into question(");
			strSql.Append("nc_qid,nvc_qcontent,int_qtype,nvc_source)");
			strSql.Append(" values (");
			strSql.Append("@nc_qid,@nvc_qcontent,@int_qtype,@nvc_source)");
			SqlParameter[] parameters = {
					new SqlParameter("@nc_qid", SqlDbType.NChar,10),
					new SqlParameter("@nvc_qcontent", SqlDbType.NVarChar,2000),
					new SqlParameter("@int_qtype", SqlDbType.Int,4),
					new SqlParameter("@nvc_source", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.nc_qid;
			parameters[1].Value = model.nvc_qcontent;
			parameters[2].Value = model.int_qtype;
			parameters[3].Value = model.nvc_source;

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
		public bool Update(questionModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update question set ");
			strSql.Append("nvc_qcontent=@nvc_qcontent,");
			strSql.Append("int_qtype=@int_qtype,");
			strSql.Append("nvc_source=@nvc_source");
			strSql.Append(" where nc_qid=@nc_qid ");
			SqlParameter[] parameters = {
					new SqlParameter("@nvc_qcontent", SqlDbType.NVarChar,2000),
					new SqlParameter("@int_qtype", SqlDbType.Int,4),
					new SqlParameter("@nvc_source", SqlDbType.NVarChar,500),
					new SqlParameter("@nc_qid", SqlDbType.NChar,10)};
			parameters[0].Value = model.nvc_qcontent;
			parameters[1].Value = model.int_qtype;
			parameters[2].Value = model.nvc_source;
			parameters[3].Value = model.nc_qid;

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
		public bool Delete(string nc_qid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from question ");
			strSql.Append(" where nc_qid=@nc_qid ");
			SqlParameter[] parameters = {
					new SqlParameter("@nc_qid", SqlDbType.NChar,10)			};
			parameters[0].Value = nc_qid;

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
		public bool DeleteList(string nc_qidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from question ");
			strSql.Append(" where nc_qid in ("+nc_qidlist + ")  ");
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
		public questionModel GetModel(string nc_qid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 nc_qid,nvc_qcontent,int_qtype,nvc_source from question ");
			strSql.Append(" where nc_qid=@nc_qid ");
			SqlParameter[] parameters = {
					new SqlParameter("@nc_qid", SqlDbType.NChar,10)			};
			parameters[0].Value = nc_qid;

			questionModel model=new questionModel();
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
		public questionModel DataRowToModel(DataRow row)
		{
			questionModel model=new questionModel();
			if (row != null)
			{
				if(row["nc_qid"]!=null)
				{
					model.nc_qid=row["nc_qid"].ToString();
				}
				if(row["nvc_qcontent"]!=null)
				{
					model.nvc_qcontent=row["nvc_qcontent"].ToString();
				}
				if(row["int_qtype"]!=null && row["int_qtype"].ToString()!="")
				{
					model.int_qtype=int.Parse(row["int_qtype"].ToString());
				}
				if(row["nvc_source"]!=null)
				{
					model.nvc_source=row["nvc_source"].ToString();
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
			strSql.Append("select nc_qid,nvc_qcontent,int_qtype,nvc_source ");
			strSql.Append(" FROM question ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(strWhere);
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
			strSql.Append(" nc_qid,nvc_qcontent,int_qtype,nvc_source ");
			strSql.Append(" FROM question ");
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
			strSql.Append("select count(1) FROM question ");
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
				strSql.Append("order by T.nc_qid desc");
			}
			strSql.Append(")AS Row, T.*  from question T ");
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
			parameters[0].Value = "question";
			parameters[1].Value = "nc_qid";
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

