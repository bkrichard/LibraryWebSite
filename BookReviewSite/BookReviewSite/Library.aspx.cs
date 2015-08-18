using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjectHelper;
using System.IO;
using PhotoHelper;

namespace BookReviewSite
{
    public partial class Library : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            rptBooks.ItemCommand += new RepeaterCommandEventHandler(rptBooks_ItemCommand);
            rptBooks.ItemDataBound += new RepeaterItemEventHandler(rptBooks_ItemDataBound);
            ddlGenre.SelectedIndexChanged += new EventHandler(ddlGenre_SelectedIndexChanged);

            if (!Page.IsPostBack)
            {
                    GetGenreData();

                if (Request.QueryString["Action"] == "edit")
                {
                    Response.Redirect("Upload.aspx");
                }

                else if (Request.QueryString["Action"] == "add")
                {
                    User user = (User)Session["User"];
                    UserBook userb = new UserBook();
                    Boolean found = false;

                    foreach (UserBook ub in user.UserBooks.List)
                    {
                        if (ub.BookID == new Guid(Request.QueryString["BookID"]))
                        {
                            found = true;
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "BookFound()", true);
                            break;
                        }
                    }

                    if (found == false)
                    {
                        userb.BookID = new Guid(Request.QueryString["BookID"]);
                        userb.UserID = user.ID;
                        user.UserBooks.List.Add(userb);
                        user.Save();
                        GetBookType();
                    }
                }
            }
            else
            {
                if (hidSourceID.Value == string.Empty)
                {
                    GetBookType();
                }
            }
        }

        void ddlGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Genre"] = ddlGenre.SelectedValue;
        }

        private void GetBookType()
        {
            BookList btl = new BookList();

            btl = btl.GetByBookTypeID(new Guid(ddlGenre.SelectedValue));
           
            foreach (Book book in btl.List)
            {
                string filename = Path.Combine(Server.MapPath("Images"), book.ID + book.MimeType);
                string relativepath = string.Format("Images/{0}", book.ID + book.MimeType);
                book.PhotoName = relativepath;
                Photo.ByteArrayToFile(book.Cover, filename);
            }

            rptBooks.DataSource = btl.List;
            rptBooks.DataBind();
        }

        void rptBooks_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                ImageButton b = (ImageButton)e.Item.FindControl("btnAdd");
                ImageButton bi = (ImageButton)e.Item.FindControl("btnEdit");
                LinkButton lnk = (LinkButton)e.Item.FindControl("lnkReview");
                if (Session["User"] == null)
                {
                    b.Visible = false;
                    bi.Visible = false;
                    lnk.Visible = false;
                }
                else
                {
                    b.Visible = true;
                    bi.Visible = true;
                    lnk.Visible = true;
                }
            }
        }

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
                Response.Redirect("Library.aspx?Action=" + e.CommandName + "&BookID=" + e.CommandArgument);
            }
        }

        private void GetGenreData()
        {
            BookTypeList btl = new BookTypeList();
            btl = btl.GetAll();
            ddlGenre.DataTextField = "Type";
            ddlGenre.DataValueField = "ID";
            ddlGenre.DataSource = btl.List;
            ddlGenre.DataBind();
            if (Session["Genre"] != null)
            {
                ddlGenre.SelectedValue = Session["Genre"].ToString();
            }
        }
    }
}