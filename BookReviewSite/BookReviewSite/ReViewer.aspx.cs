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
    public partial class ReViewer : System.Web.UI.Page
    {
        Book book = new Book();

        protected void Page_Load(object sender, EventArgs e)
        {
            book = book.GetByID(new Guid(Request.QueryString["BookID"]));
            GetBookCover();
            GetReview();
        }

        void GetBookCover()
        {
            string filename = Path.Combine(Server.MapPath("Images"), book.ID + book.MimeType);
            string relativepath = string.Format("Images/{0}", book.ID + book.MimeType);
            book.PhotoName = relativepath;
            Photo.ByteArrayToFile(book.Cover, filename);
            imgbookCover.ImageUrl = book.PhotoName;
        }

        void GetReview()
        {
            ReviewList rvl = new ReviewList();

            rvl.GetByBookID(new Guid(Request.QueryString["BookID"]));
            rptReviews.DataSource = rvl.List;
            rptReviews.DataBind();
        }
    }
}