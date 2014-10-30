using System;
namespace Model
{
	/// <summary>
	/// options:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class optionsModel
	{
        public optionsModel()
		{}
		#region Model
		private string _nc_opid;
		private string _nc_qid;
		private string _nvc_opcontent;
		private bool _bit_isright;
		/// <summary>
		/// 
		/// </summary>
		public string nc_opid
		{
			set{ _nc_opid=value;}
			get{return _nc_opid;}
		}
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
		public string nvc_opcontent
		{
			set{ _nvc_opcontent=value;}
			get{return _nvc_opcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bit_isright
		{
			set{ _bit_isright=value;}
			get{return _bit_isright;}
		}
		#endregion Model

	}
}

