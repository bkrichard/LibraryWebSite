using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookReviewSite
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("User");

            Label lblGreeting = (Label)Master.FindControl("lbllogin");
            lblGreeting.Text = "Welcome";

            LinkButton lnkLogon = (LinkButton)Master.FindControl("lnkLogin");
            lnkLogon.Visible = true;

            LinkButton lnkExit = (LinkButton)Master.FindControl("lnkLogout");
            lnkExit.Visible = false;

            Response.Redirect("Default.aspx");
        }
    }
}