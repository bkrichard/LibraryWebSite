using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjectHelper;

namespace BookReviewSite
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["User"];
            lblDisplayFName.Text = user.FirstName.ToString();
            lblDisplayLName.Text = user.LastName.ToString();
            lblDisplayUName.Text = user.UserName.ToString();
            lblDisplayEMail.Text = user.Email.ToString();
        }
    }
}