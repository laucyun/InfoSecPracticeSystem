using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using Commom;

public partial class kaoshi : System.Web.UI.Page
{
    public string kaoshiid = DateTime.Now.ToString("yyyyMMddHHmmssffff");
    public int totalTimu = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string uid = new SetCookie().WhetherOnline();
        if (!string.IsNullOrEmpty(uid))
        {
            DataSet ds = new questionDAL().GetList(" where nc_qid in(select top 200 nc_qid from question order by newid()) order by int_qtype asc");
            totalTimu = ds.Tables[0].Rows.Count;
            DataSet tihaods = new dateConversion().getTihaoData(ds);
            tihaoRepeater.DataSource = tihaods;
            tihaoRepeater.DataBind();
        }
        Page.DataBind();
    }
}