using System;
namespace Model
{
	/// <summary>
	/// question:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class questionModel
	{
        public questionModel()
		{}
		#region Model
		private string _nc_qid;
		private string _nvc_qcontent;
		private int _int_qtype;
		private string _nvc_source;
		/// <summary>
		/// 
		/// </summary>
		public string nc_qid
		{
			set{ _nc_qid=value;}
			get{return _nc_qid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nvc_qcontent
		{
			set{ _nvc_qcontent=value;}
			get{return _nvc_qcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int int_qtype
		{
			set{ _int_qtype=value;}
			get{return _int_qtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nvc_source
		{
			set{ _nvc_source=value;}
			get{return _nvc_source;}
		}
		#endregion Model

	}
}

