using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjectHelper;

namespace BookReviewSite
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                User user = (User)Session["User"];
                lbllogin.Text = "Greetings " + user.UserName.ToString();

                lnkLogin.Visible = false;
                lnkProfile.Visible = true;
                lnkLogout.Visible = true;
                NavigationMenu.FindItem("Upload").Enabled = true;
                NavigationMenu.FindItem("MyBook").Enabled = true;
            }
            else
            {
                lnkLogin.Visible = true;
                lnkProfile.Visible = false;
                lnkLogout.Visible = false;
                NavigationMenu.FindItem("Upload").Enabled = false;
                NavigationMenu.FindItem("MyBook").Enabled = false;
            }
        }

        internal void NoBack()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
            Response.AppendHeader("Pragma", "no-cache");
        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
