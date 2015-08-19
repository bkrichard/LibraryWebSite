using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjectHelper;

namespace BookReviewSite
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["User"];
        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            if (txtCurrentPass.Text == user.Password.ToString())
            {
                if (txtNewPass.Text == txtConfirmPass.Text)
                {
                    user = user.ChangePassword(txtNewPass.Text);
                    Response.Redirect("Profile.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CallMyFunction", "DoesNotMatch()", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CallMyFunction", "WrongCurrent()", true);
            }
        }
    }
}