using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Commom;
using System.Data;
using DAL;

public partial class cuoti : System.Web.UI.Page
{
    public int totalTimu = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string uid = new SetCookie().WhetherOnline();
        if (!string.IsNullOrEmpty(uid))
        {
            DataSet ds = new cuotiDAL().GetList(" nc_uid='" + uid + "' order by nc_qid asc");
            totalTimu = ds.Tables[0].Rows.Count;
            DataSet tihaods = new dateConversion().getTihaoData(ds);
            tihaoRepeater.DataSource = tihaods;
            tihaoRepeater.DataBind();
        }
        Page.DataBind();
    }
}