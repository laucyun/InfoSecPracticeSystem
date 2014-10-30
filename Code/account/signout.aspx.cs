using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Commom;

public partial class account_signout : System.Web.UI.Page
{
    public string domain = new settings().getdomain();
    protected void Page_Load(object sender, EventArgs e)
    {
        string type = "";
        if (!string.IsNullOrEmpty(Request.Form["type"]))//获取数据类型
        {
            type = Request.Form["type"];
        }
        //清除cookie
        if (type == "signout")
        {
            try
            {
                HttpCookie aCookie;
                string cookieName;
                int limit = Request.Cookies.Count;
                for (int i = 0; i < limit; i++)
                {
                    cookieName = Request.Cookies[i].Name;
                    if (cookieName != "ISReamberAccountCookie")
                    {
                        aCookie = new HttpCookie(cookieName);
                        aCookie.Expires = DateTime.Now.AddDays(-365);
                        Response.Cookies.Add(aCookie);
                    }
                    if (cookieName == "ISReamberAccountCookie")
                    {
                        HttpCookie cookies = HttpContext.Current.Request.Cookies["ISReamberAccountCookie"];
                        string[,] array = new string[5, 2];
                        array[0, 0] = "username";
                        array[0, 1] = cookies["username"].ToString(); ;
                        array[1, 0] = "userpwd";
                        array[1, 1] = cookies["userpwd"].ToString(); ;
                        array[2, 0] = "isAutoLogin";
                        array[2, 1] = "";
                        array[3, 0] = "uright";
                        array[3, 1] = cookies["uright"].ToString(); ;
                        array[4, 0] = "uid";
                        array[4, 1] = cookies["uid"].ToString(); ;
                        new SetCookie().CreateCookie("ISReamberAccountCookie", 5, 0, 0, 0, array);
                    }
                }
                Response.Write(1);
            }
            catch (Exception)
            {
                Response.Write(0);
            }
        }
        Response.End();
    }
}