using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjectHelper;

namespace BookReviewSite
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as SiteMaster).NoBack();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                user = user.Register(txtEmail.Text, txtFirstName.Text, txtLastName.Text, txtUserName.Text,
                    txtQuestion1.Text, txtAnswer1.Text, txtQuestion2.Text, txtAnswer2.Text, txtQuestion3.Text, txtAnswer3.Text);

                if (user == null)
                {
                    lblNameValidate.Text = "User name already taken";
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "CheckMail()", true);
                    Response.Redirect("Login.aspx?Login=first");
                }
            }
            catch (Exception ex)
            {
                lblNameValidate.Text = ex.Message;
            }
        }
    }
}