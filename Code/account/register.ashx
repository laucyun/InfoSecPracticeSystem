<%@ WebHandler Language="C#" Class="register" %>

using System;
using System.Web;
using DAL;
using Model;
using System.Text.RegularExpressions;

public class register : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        string type = null;
        if (!string.IsNullOrEmpty(context.Request.QueryString["type"]))//获取数据类型
        {
            type = context.Request.QueryString["type"];
        }
        #region 用户名
        if (type == "username")//用户名
        {
            string value = context.Request.QueryString["value"];
            bool isexist = new yonghuDAL().ExistsUserName(value);
            if (isexist == true)
            {
                context.Response.Write(1);
            }
            else
            {
                context.Response.Write(0);
            }
        }
        #endregion
        #region 验证码
        if (type == "validate")//验证码
        {
            HttpCookie cookies = HttpContext.Current.Request.Cookies["verifycode"];
            if (cookies != null && string.IsNullOrEmpty(context.Request.QueryString["value"]) == false)//获取数据值
            {
                string value = context.Request.QueryString["value"];
                string code = cookies["CheckCode"].ToString().ToString();//session中的验证码
                if (code.Equals(value, StringComparison.InvariantCultureIgnoreCase))//比较文本框和session两者中的字符串内容  注意：此处忽略大小
                {
                    context.Response.Write(1);
                }
                else
                {
                    context.Response.Write(0);
                }
            }
            else
            {
                context.Response.Write(0);
            }
        }
        #endregion
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}