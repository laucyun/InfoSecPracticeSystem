using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Commom;
using DAL;

public partial class _default : System.Web.UI.Page
{
    public string uname = null;
    public string domain = new settings().getdomain();
    public string Year = DateTime.Now.Year.ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        string uid = new SetCookie().WhetherOnline();
        if (!string.IsNullOrEmpty(uid))
        {
            uname = new yonghuDAL().GetModelById(uid).nvc_username;
        }
        if (Year == "2014")
        {
            Year = "2014";
        }
        else
        {
            Year = "2014-" + Year;
        }
        Page.DataBind();
    }
}