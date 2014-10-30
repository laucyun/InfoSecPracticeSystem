using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Text.RegularExpressions;
using Model;
using Commom;

public partial class account_register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string caozuo = null;
        if (!string.IsNullOrEmpty(Request.Form["action"]))//获取数据类型
        {
            caozuo = Request.Form["action"];
        }
        if (caozuo == "Register")
        {
            #region 注册
            #region 用户名
            string uname = null;
            if (!string.IsNullOrEmpty(Request.Form["CreateUsername"]))//获取数据类型
            {
                string un = Request.Form["CreateUsername"];
                if (un.Length > 0 && un.Length <= 20)
                {
                    if (Regex.IsMatch(un, @"^([\u4e00-\u9fa5]|[a-zA-Z]|[0-9]|-){0,}$") || Regex.IsMatch(un, @"^[_\.0-9a-zA-Z-]+@([0-9a-zA-Z][0-9a-zA-Z-]+\.)+[a-zA-Z]{2,4}$"))
                    {
                        uname = un;
                    }
                }
            }
            #endregion
            #region 密码
            string pwd = null;
            if (!string.IsNullOrEmpty(Request.Form["CreatePassword"]))//获取数据类型
            {
                string up = Request.Form["CreatePassword"];
                if (up.Length > 6 && up.Length <= 16 && up != "123456" && up != "654321" && up != "111222")
                {
                    pwd = up;
                }
            }
            #endregion
            #region 重复密码
            string repwd = null;
            if (!string.IsNullOrEmpty(Request.Form["CreateRePassword"]))//获取数据类型
            {
                string urd = Request.Form["CreateRePassword"];
                if (urd == pwd)
                {
                    repwd = urd;
                }
            }
            #endregion
            #region 操作
            string action = null;
            if (!string.IsNullOrEmpty(Request.Form["RegisterSubmit"]))//获取数据类型
            {
                action = Request.Form["RegisterSubmit"];
            }
            #endregion
            if (pwd == repwd && action == "创建账户" && string.IsNullOrEmpty(uname) != null)
            {

                //添加一条记录
                yonghuModel yhm = new yonghuModel();
                yhm.nvc_username = uname;
                yhm.nvc_pwd = new MD5Encrypt().GetMD5(pwd + uname);
                yhm.int_right = 1;
                bool isInsertOk = new yonghuDAL().Add(yhm);

                if (isInsertOk == true)
                {
                    Response.Write("<script>javascript:alert('注册成功！');window.parent.location.reload();</script>");
                }
            }
            else
            {
                Response.Write("<script>javascript:alert('注册失败！请重试！');</script>");
            }
            #endregion
            Response.End();
        }
        Page.DataBind();
    }
}