using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjectHelper;
using PhotoHelper;
using System.IO;

namespace BookReviewSite
{
    public partial class MyBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("default.aspx");
            }

            rptBooks.ItemCommand += new RepeaterCommandEventHandler(rptBooks_ItemCommand);
            if (!Page.IsPostBack)
            {
                User user = GetMyBooks();

                if (Request.QueryString["Action"] == "edit")
                {
                    Response.Redirect("Upload.aspx");
                }

                else if (Request.QueryString["Action"] == "delete")
                {
                    foreach (UserBook ub in user.UserBooks.List)
                    {
                        if (ub.BookID == new Guid(Request.QueryString["BookID"]))
                        {
                            ub.Deleted = true;
                            user.Save();
                            GetMyBooks();
                        }
                    }
                }
            }
        }

        private User GetMyBooks()
        {
            User user = (User)Session["User"];
            BookList bl = user.Books;
            foreach (Book book in bl.List)
            {
                string filename = Path.Combine(Server.MapPath("Images"), book.ID + book.MimeType);
                string relativepath = string.Format("Images/{0}", book.ID + book.MimeType);
                book.PhotoName = relativepath;
                Photo.ByteArrayToFile(book.Cover, filename);
            }
            rptBooks.DataSource = bl.List;
            rptBooks.DataBind();
            return user;
        }

        //

        void rptBooks_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "review")
            {
                Response.Redirect("TextEditor.aspx?Action=" + e.CommandName + "&BookID=" + e.CommandArgument);
            }
            else if (e.CommandName == "readreview")
            {
                Response.Redirect("ReViewer.aspx?Action=" + e.CommandName + "&BookID=" + e.CommandArgument);
            }
            else
            {
                Response.Redirect("MyBooks.aspx?Action=" + e.CommandName + "&BookID=" + e.CommandArgument);
            }
        }
    }
}