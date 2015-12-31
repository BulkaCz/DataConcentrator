using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataConcentratorWEB
{
    public partial class DataConcentrator : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DBElektromer.aspx");
        }

        protected void btnVahy_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DBVaha.aspx");
        }

        protected void btnConf_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuration.aspx");
        }

        protected void btnLogs_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/History.aspx");
        }
    }
}