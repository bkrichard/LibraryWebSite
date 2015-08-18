using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjectHelper;

namespace BookReviewSite
{
    public partial class TextEditor : System.Web.UI.Page
    {
        Book book = new Book();

        protected void Page_Load(object sender, EventArgs e)
        {
            book = book.GetByID(new Guid(Request.QueryString["BookID"]));
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            Review br = new Review();
            User user = new User();
            user = (User)Session["User"];
            br.Title = txtTitle.Text;
            br.BookReview = txtBody.Text;
            br.UserID = user.ID;
            br.BookID = book.ID;
            book.Reviews.List.Add(br);
            book.Save();
            Response.Redirect("default.aspx");
        }
    }
}