using System;
namespace Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class yonghuModel
	{
        public yonghuModel()
		{}
		#region Model
		private string _nc_uid;
		private string _nvc_username;
		private string _nvc_pwd;
		private int _int_right;
		private DateTime _dt_register;
		/// <summary>
		/// 
		/// </summary>
		public string nc_uid
		{
			set{ _nc_uid=value;}
			get{return _nc_uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nvc_username
		{
			set{ _nvc_username=value;}
			get{return _nvc_username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nvc_pwd
		{
			set{ _nvc_pwd=value;}
			get{return _nvc_pwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int int_right
		{
			set{ _int_right=value;}
			get{return _int_right;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime dt_register
		{
			set{ _dt_register=value;}
			get{return _dt_register;}
		}
		#endregion Model

	}
}

