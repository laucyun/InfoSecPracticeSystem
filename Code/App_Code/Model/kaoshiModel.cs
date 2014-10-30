using System;
namespace Model
{
    /// <summary>
    /// kaoshi:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class kaoshiModel
    {
        public kaoshiModel()
        { }
        #region Model
        private string _nc_id;
        private string _nc_kaoshiid;
        private string _nc_qid;
        private string _nc_daanid;
        private bool _bit_isright;
        private string _nvc_chengji;
        private DateTime _dt_shijian;
        private string _nc_uid;
        /// <summary>
        /// 
        /// </summary>
        public string nc_id
        {
            set { _nc_id = value; }
            get { return _nc_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string nc_kaoshiId
        {
            set { _nc_kaoshiid = value; }
            get { return _nc_kaoshiid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string nc_qid
        {
            set { _nc_qid = value; }
            get { return _nc_qid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string nc_daanid
        {
            set { _nc_daanid = value; }
            get { return _nc_daanid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bit_isRight
        {
            set { _bit_isright = value; }
            get { return _bit_isright; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string nvc_chengji
        {
            set { _nvc_chengji = value; }
            get { return _nvc_chengji; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dt_shijian
        {
            set { _dt_shijian = value; }
            get { return _dt_shijian; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string nc_uid
        {
            set { _nc_uid = value; }
            get { return _nc_uid; }
        }
        #endregion Model

    }
}

