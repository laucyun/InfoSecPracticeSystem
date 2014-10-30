using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using Model;//Please add references
namespace DAL
{
	/// <summary>
	/// 数据访问类:options
	/// </summary>
	public partial class optionsDAL
	{
        public optionsDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string nc_opid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from options");
			strSql.Append(" where nc_opid=@nc_opid ");
			SqlParameter[] parameters = {
					new SqlParameter("@nc_opid", SqlDbType.NChar,12)			};
			parameters[0].Value = nc_opid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(optionsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into options(");
			strSql.Append("nc_opid,nc_qid,nvc_opcontent,bit_isright)");
			strSql.Append(" values (");
			strSql.Append("@nc_opid,@nc_qid,@nvc_opcontent,@bit_isright)");
			SqlParameter[] parameters = {
					new SqlParameter("@nc_opid", SqlDbType.NChar,12),
					new SqlParameter("@nc_qid", SqlDbType.NChar,10),
					new SqlParameter("@nvc_opcontent", SqlDbType.NVarChar,2000),
					new SqlParameter("@bit_isright", SqlDbType.Bit,1)};
			parameters[0].Value = model.nc_opid;
			parameters[1].Value = model.nc_qid;
			parameters[2].Value = model.nvc_opcontent;
			parameters[3].Value = model.bit_isright;

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
		public bool Update(optionsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update options set ");
			strSql.Append("nc_qid=@nc_qid,");
			strSql.Append("nvc_opcontent=@nvc_opcontent,");
			strSql.Append("bit_isright=@bit_isright");
			strSql.Append(" where nc_opid=@nc_opid ");
			SqlParameter[] parameters = {
					new SqlParameter("@nc_qid", SqlDbType.NChar,10),
					new SqlParameter("@nvc_opcontent", SqlDbType.NVarChar,2000),
					new SqlParameter("@bit_isright", SqlDbType.Bit,1),
					new SqlParameter("@nc_opid", SqlDbType.NChar,12)};
			parameters[0].Value = model.nc_qid;
			parameters[1].Value = model.nvc_opcontent;
			parameters[2].Value = model.bit_isright;
			parameters[3].Value = model.nc_opid;

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
		public bool Delete(string nc_opid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from options ");
			strSql.Append(" where nc_opid=@nc_opid ");
			SqlParameter[] parameters = {
					new SqlParameter("@nc_opid", SqlDbType.NChar,12)			};
			parameters[0].Value = nc_opid;

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
		public bool DeleteList(string nc_opidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from options ");
			strSql.Append(" where nc_opid in ("+nc_opidlist + ")  ");
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
		public optionsModel GetModel(string nc_opid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 nc_opid,nc_qid,nvc_opcontent,bit_isright from options ");
			strSql.Append(" where nc_opid=@nc_opid ");
			SqlParameter[] parameters = {
					new SqlParameter("@nc_opid", SqlDbType.NChar,12)			};
			parameters[0].Value = nc_opid;

			optionsModel model=new optionsModel();
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
		public optionsModel DataRowToModel(DataRow row)
		{
			optionsModel model=new optionsModel();
			if (row != null)
			{
				if(row["nc_opid"]!=null)
				{
					model.nc_opid=row["nc_opid"].ToString();
				}
				if(row["nc_qid"]!=null)
				{
					model.nc_qid=row["nc_qid"].ToString();
				}
				if(row["nvc_opcontent"]!=null)
				{
					model.nvc_opcontent=row["nvc_opcontent"].ToString();
				}
				if(row["bit_isright"]!=null && row["bit_isright"].ToString()!="")
				{
					if((row["bit_isright"].ToString()=="1")||(row["bit_isright"].ToString().ToLower()=="true"))
					{
						model.bit_isright=true;
					}
					else
					{
						model.bit_isright=false;
					}
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
			strSql.Append("select nc_opid,nc_qid,nvc_opcontent,bit_isright ");
			strSql.Append(" FROM options ");
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
			strSql.Append(" nc_opid,nc_qid,nvc_opcontent,bit_isright ");
			strSql.Append(" FROM options ");
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
			strSql.Append("select count(1) FROM options ");
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
				strSql.Append("order by T.nc_opid desc");
			}
			strSql.Append(")AS Row, T.*  from options T ");
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
			parameters[0].Value = "options";
			parameters[1].Value = "nc_opid";
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

