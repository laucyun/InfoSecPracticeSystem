<%@ WebHandler Language="C#" Class="kaoshi" %>

using System;
using System.Web;
using System.Data;
using Model;
using DAL;
using Commom;

public class kaoshi : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string uid = new SetCookie().WhetherOnline();
        if (!string.IsNullOrEmpty(uid))
        {
            string html = null;
            string action = null;
            if (!string.IsNullOrEmpty(context.Request.Form["action"]))//获取数据类型
            {
                action = context.Request.Form["action"];
            }
            string timuid = null;
            if (!string.IsNullOrEmpty(context.Request.Form["timuid"]))//获取数据类型
            {
                timuid = context.Request.Form["timuid"];
            }
            #region 获取题目内容
            if (action == "getContent" && !string.IsNullOrEmpty(timuid))
            {
                string json = string.Empty;
                questionModel qm = new questionDAL().GetModel(timuid);
                DataSet ds = new optionsDAL().GetList(" nc_qid='" + timuid + "' order by newid()");
                json = "{text:'timucontent',value:'" + qm.nvc_qcontent + "',opid:''}";
                json += ",{text:'timutype',value:'" + qm.int_qtype + "',opid:''}";
                json += ",{text:'timuoptions',value:'" + ds.Tables[0].Rows.Count + "',opid:''}";
                if (qm.int_qtype == 1 || qm.int_qtype == 2)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        json += ",";
                        json += "{text:'timuoptions" + i + "',value:'" + getABCD(i) + "：" + ds.Tables[0].Rows[i]["nvc_opcontent"].ToString() + "',opid:'" + ds.Tables[0].Rows[i]["nc_opid"].ToString() + "'}";
                    }
                }
                html = json;
            }
            #endregion

            #region 判断答案是否正确
            if (action == "isRight" && !string.IsNullOrEmpty(timuid))
            {
                string tihao = null;
                if (!string.IsNullOrEmpty(context.Request.Form["tihao"]))
                {
                    tihao = context.Request.Form["tihao"];
                }
                string timutype = null;
                if (!string.IsNullOrEmpty(context.Request.Form["timutype"]))
                {
                    timutype = context.Request.Form["timutype"];
                }
                string daanid = null;
                if (!string.IsNullOrEmpty(context.Request.Form["daanid"]))
                {
                    daanid = context.Request.Form["daanid"];
                }
                if (!string.IsNullOrEmpty(tihao) && !string.IsNullOrEmpty(timutype) && !string.IsNullOrEmpty(daanid))
                {
                    if (timutype == "0" || timutype == "1")
                    {
                        html = whetherRight(timuid, daanid);
                    }
                    if (timutype == "2")
                    {
                        daanid = daanid.Substring(0, daanid.Length - 1);
                        string[] arrayList = daanid.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        string rightStr = "1";
                        foreach (string opid in arrayList)
                        {
                            if (!string.IsNullOrEmpty(opid))
                            {
                                if (whetherRight(timuid, daanid) == "0")
                                {
                                    rightStr = "0";
                                }
                            }
                        }
                        if (rightStr == "1")
                        {
                            html = "1";
                        }
                        if (rightStr == "0")
                        {
                            html = "0";
                        }
                    }
                }
                if (html == "0")
                {
                    cuotiModel ctm = new cuotiModel();
                    ctm.nc_qid = timuid;
                    ctm.nc_uid = uid;
                    bool isok = new cuotiDAL().Add(ctm);
                }
            }
            #endregion

            #region 获取正确答案
            if (action == "getRight" && !string.IsNullOrEmpty(timuid))
            {
                string json = string.Empty;
                questionModel qm = new questionDAL().GetModel(timuid);
                json += "{text:'timutype',value:'" + qm.int_qtype + "',opid:''}";
                DataSet ds = new optionsDAL().GetList(" nc_qid='" + timuid + "' and bit_isright=1");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    json += ",";
                    json += "{text:'timuoptions" + i + "',opid:'" + ds.Tables[0].Rows[i]["nc_opid"].ToString() + "'}";
                }
                html = json;
            }
            #endregion
            context.Response.Write(html);
        }
    }


    /// <summary>
    /// 判断答案是否正确
    /// </summary>
    /// <param name="timuid">题目id</param>
    /// <param name="daanid">答案id</param>
    /// <returns></returns>
    private string whetherRight(string timuid, string daanid)
    {
        string isright = "0";
        DataSet ds = new optionsDAL().GetList(" nc_qid='" + timuid + "' and nc_opid='" + daanid + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            bool isok = false;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                isok = (bool)ds.Tables[0].Rows[i]["bit_isright"];
            }
            if (isok)
            {
                isright = "1";
            }
        }
        return isright;
    }

    /// <summary>
    /// 获取选项的ABCDE
    /// </summary>
    /// <param name="i">序号</param>
    /// <returns></returns>
    private string getABCD(int i)
    {
        string str = null;
        switch (i)
        {
            case 0: str = "A"; break;
            case 1: str = "B"; break;
            case 2: str = "C"; break;
            case 3: str = "D"; break;
            case 4: str = "E"; break;
            case 5: str = "F"; break;
            default: break;
        }
        return str;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}