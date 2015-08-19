using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjectHelper;

namespace BookReviewSite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as SiteMaster).NoBack();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                user = user.Login(txtUserName.Text, txtPassword.Text);
                Session.Add("User", user);

                LinkButton lnkLogon = (LinkButton)Master.FindControl("lnkLogin");
                lnkLogon.Visible = false;

                LinkButton lnkExit = (LinkButton)Master.FindControl("lnkLogout");
                lnkExit.Visible = true;
                if (user.Version == 0)
                {
                    Response.Redirect("ChangePassword.aspx");
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            catch (ApplicationException ex)
            {
                lblStatus.Text = "Login failed, please try again.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }

        protected void btnForgot_Click(object sender, EventArgs e)
        {
            Response.Redirect("forgotpassword.aspx");
        }
    }
}