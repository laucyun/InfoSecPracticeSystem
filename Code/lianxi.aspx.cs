using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;
using Commom;

public partial class lianxi : System.Web.UI.Page
{
    public int totalTimu = 0;
    public string title = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        string uid = new SetCookie().WhetherOnline();
        if (!string.IsNullOrEmpty(uid))
        {

            string type = null;
            if (!string.IsNullOrEmpty(Request.QueryString["type"]))//获取数据类型
            {
                type = Request.QueryString["type"];
            }
            if (type == "b8ca28006a659d5fed930fcf333976be")
            {
                DataSet ds = new questionDAL().GetList(" order by nc_qid asc");
                totalTimu = ds.Tables[0].Rows.Count;
                DataSet tihaods = new dateConversion().getTihaoData(ds);
                tihaoRepeater.DataSource = tihaods;
                tihaoRepeater.DataBind();
                title = "顺序练习";
            }
            if (type == "a1d8bfacd7aa75f6f6500f361e352648")
            {
                DataSet ds = new questionDAL().GetList(" order by newid()");
                totalTimu = ds.Tables[0].Rows.Count;
                DataSet tihaods = new dateConversion().getTihaoData(ds);
                tihaoRepeater.DataSource = tihaods;
                tihaoRepeater.DataBind();
                title = "随机练习";
            }
            
        }
        Page.DataBind();
    }
}