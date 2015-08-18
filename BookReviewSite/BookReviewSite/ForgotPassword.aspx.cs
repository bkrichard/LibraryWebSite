using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjectHelper;

namespace BookReviewSite
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnForgot_Click(object sender, EventArgs e)
        {
            User user = new User();
            if (user.Recover(txtEmail.Text))
            {
                Session.Add("User", user);
                lblQuestion.Text = user.GetQuestion();
                btnSend.Visible = true;
                btnForgot.Visible = false;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            User user = (User)Session["User"];
            if (txtAnswer.Text == user.GetAnswer())
            {

                if (user.Recover(txtEmail.Text, txtFirstName.Text, txtLastName.Text, txtUserName.Text, txtAnswer.Text))
                {
                    lblStatus.Text = "E-mail sent";
                }
            }
            else
            {
                lblStatus.Text = "Information was not entered correctly";
            }
        }
    }
}