using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Model;
using Commom;

public partial class jiaojuan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string uid = new SetCookie().WhetherOnline();
        if (!string.IsNullOrEmpty(uid))
        {
            int rightTimu = 0;
            #region 获取考试ID，总题数
            string kaoshiId = null;
            if (!string.IsNullOrEmpty(Request.Form["kaoshiId"]))//获取数据类型
            {
                kaoshiId = Request.Form["kaoshiId"];
            }
            int totalTimu = 0;
            if (!string.IsNullOrEmpty(Request.Form["totalTimu"]))//获取数据类型
            {
                totalTimu = int.Parse(Request.Form["totalTimu"]);
            }
            #endregion

            bool isok = false;
            for (int i = 1; i <= totalTimu; i++)
            {
                #region 获取数据
                string timuid = null;
                if (!string.IsNullOrEmpty(Request.Form["tihao" + i]))//获取数据类型
                {
                    timuid = Request.Form["tihao" + i];
                }
                string daanid = null;
                if (!string.IsNullOrEmpty(Request.Form["timudaan" + i]))//获取数据类型
                {
                    daanid = Request.Form["timudaan" + i];
                }
                bool isRight = false;
                if (!string.IsNullOrEmpty(Request.Form["isRight" + i]))//获取数据类型
                {
                    string ir = Request.Form["isRight" + i];
                    if (ir == "1")
                    {
                        isRight = true;
                        rightTimu++;
                    }
                    else
                    {
                        isRight = false;
                    }
                }
                #endregion

                #region 提交数据
                questionModel qm = new questionDAL().GetModel(timuid);
                //单选，判断
                if (qm.int_qtype == 1 || qm.int_qtype == 0)
                {
                    kaoshiModel ksm = new kaoshiModel();
                    ksm.nc_kaoshiId = kaoshiId;
                    ksm.nc_qid = timuid;
                    ksm.nc_daanid = daanid;
                    ksm.bit_isRight = isRight;
                    ksm.nc_uid = uid;
                    isok = new kaoshiDAL().Add(ksm);
                }
                //多选
                if (qm.int_qtype == 2)
                {
                    kaoshiModel ksm = new kaoshiModel();
                    ksm.nc_kaoshiId = kaoshiId;
                    ksm.nc_qid = timuid;
                    ksm.bit_isRight = isRight;
                    ksm.nc_uid = uid;
                    if (string.IsNullOrEmpty(daanid))
                    {
                        isok = new kaoshiDAL().Add(ksm);
                    }
                    else
                    {
                        daanid = daanid.Substring(0, daanid.Length - 1);
                        string[] arrayList = daanid.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string opid in arrayList)
                        {
                            ksm.nc_daanid = opid;
                            isok = new kaoshiDAL().Add(ksm);
                        }
                    }
                }
                #endregion
            }

            #region 更改部分数据
            bool isupdatechengji = new kaoshiDAL().UpDateChengji(kaoshiId, rightTimu.ToString());
            bool isupdateShijian = new kaoshiDAL().UpDateShijian(kaoshiId);
            #endregion

            Response.Write("<script>javascript:if(window.confirm('交卷成功，考试成绩为" + rightTimu.ToString() + "分！是否重新考试？') == true){window.location.replace('kaoshi.aspx');}</script>");
        }
    }

}