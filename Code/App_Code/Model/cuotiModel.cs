using System;
namespace Model
{
	/// <summary>
	/// cuoti:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class cuotiModel
	{
        public cuotiModel()
		{}
		#region Model
		private string _nc_ctid;
		private string _nc_qid;
		private string _nc_uid;
		/// <summary>
		/// 
		/// </summary>
		public string nc_ctid
		{
			set{ _nc_ctid=value;}
			get{return _nc_ctid;}
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
		public string nc_uid
		{
			set{ _nc_uid=value;}
			get{return _nc_uid;}
		}
		#endregion Model

	}
}

