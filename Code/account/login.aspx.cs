using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Commom;
using Model;
using DAL;

public partial class account_login : System.Web.UI.Page
{
    public string Year = DateTime.Now.Year.ToString();
    public string loginErrorMsg = null;
    public string loginUname = null;
    public string loginUnameStyle = "logininput";
    public string loginUpwd = null;
    public string loginUpwdStyle = "logininput";
    public string loginFocus = "username";

    public string uisRemember = null;

    public string domain = new settings().getdomain();
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 脚本时间
        if (Year == "2014")
        {
            Year = "2014";
        }
        else
        {
            Year = "2014-" + Year;
        }
        #endregion


        string isSign = "";//是否登录？
        if (!string.IsNullOrEmpty(Request.Form["isSign"]))//获取数据类型
        {
            isSign = Request.Form["isSign"];
            if (isSign == "yes")
            {
                #region MyRegion
                string uname = "";//用户名
                if (!string.IsNullOrEmpty(Request.Form["username"]))//获取数据类型
                {
                    uname = Request.Form["username"];
                    #region 下一数据
                    string pwd = "";//密码
                    if (!string.IsNullOrEmpty(Request.Form["userpwd"]))//获取数据类型
                    {
                        pwd = Request.Form["userpwd"];
                        #region 下一数据
                        string isReamber = "";//是否记住密码？
                        if (!string.IsNullOrEmpty(Request.Form["isRemember"]))//获取数据类型
                        {
                            isReamber = Request.Form["isRemember"];
                        }
                        login(isReamber, uname, pwd);
                        #endregion
                    }
                    else
                    {
                        loginErrorMsg = "密码不能为空。";
                        loginUname = uname;
                        loginUpwdStyle = "loginError";
                        loginFocus = "userpwd";
                    }
                    #endregion
                }
                else
                {
                    loginErrorMsg = "用户名不能为空。";
                    loginUnameStyle = "loginError";
                    loginUpwdStyle = "loginError";
                    loginFocus = "username";
                }
                #endregion
            }
        }
        //第一次加载
        if (string.IsNullOrEmpty(isSign))
        {
            #region 自动登录
            HttpCookie cookies = Request.Cookies["ISReamberAccountCookie"];
            if (cookies != null)
            {
                loginUname = cookies["username"].ToString();
                loginUpwd = cookies["userpwd"].ToString();
                string isAutoLogin = cookies["isAutoLogin"].ToString();
                if (isAutoLogin == "yes")
                {
                    uisRemember = "checked='checked'";
                    login(isAutoLogin, loginUname, loginUpwd);
                }
            }
            #endregion
        }
        Page.DataBind();
    }

    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="isReamber">是否记住</param>
    /// <param name="uname">用户名</param>
    /// <param name="pwd">密码</param>
    protected void login(string isReamber, string uname, string pwd)
    {
        bool isexist = new yonghuDAL().ExistsUserName(uname);
        if (isexist == true)
        {
            yonghuModel yhm = new yonghuDAL().GetModelByUsername(uname);
            string pwd2 = new MD5Encrypt().GetMD5(pwd + uname);
            if (pwd2 == yhm.nvc_pwd)
            {
                string[,] array = new string[5, 2];
                array[0, 0] = "username";
                array[0, 1] = yhm.nvc_username;
                array[1, 0] = "userpwd";
                array[1, 1] = pwd;
                array[2, 0] = "isAutoLogin";
                array[2, 1] = isReamber;
                array[3, 0] = "uright";
                array[3, 1] = yhm.int_right.ToString();
                array[4, 0] = "uid";
                array[4, 1] = new MD5Encrypt().GetMD5(uname + yhm.nc_uid);
                new SetCookie().CreateCookie("ISAccountCookie", 0, 8, 0, 0, array);
                new SetCookie().CreateCookie("ISReamberAccountCookie", 5, 0, 0, 0, array);
                Response.Redirect(domain + "/default.aspx");
            }
            else
            {
                loginErrorMsg = "密码错误。";
                loginUname = uname;
                loginUpwdStyle = "loginError";
                loginFocus = "userpwd";
            }
        }
        else
        {
            loginErrorMsg = "用户名不存在。";
            loginUnameStyle = "loginError";
            loginFocus = "username";
        }
    }
}