using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjectHelper;
using System.IO;

namespace BookReviewSite
{
    public partial class Upload : System.Web.UI.Page
    {
        string savePath;
        Book book;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("default.aspx");
            }
            if (!Page.IsPostBack)
            {
                GetGenreData();
                if (Request.QueryString["BookID"] != null)
                {
                    book = new Book();
                    btnUpload.Visible = false;
                    btnSave.Visible = true;
                    book = book.GetByID(new Guid(Request.QueryString["BookID"]));
                    txtTitle.Text = book.Title;
                    txtPrice.Text = book.Price;
                    ddlGenre.SelectedValue = book.BookTypeID.ToString();
                    Session["Book"] = book;
                }
                else
                {
                    btnSave.Visible = false;
                }
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
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                // Before attempting to save the file, verify
                // that the FileUpload control contains a file.
                if (fuPhoto.HasFile)
                {
                    // Call a helper method routine to save the file.
                    SaveFile(fuPhoto.PostedFile);
                    lblMessage.Text = "File uploaded";
                }
                else
                {
                    savePath = Server.MapPath("Images");
                    string fileName = "CoverNull.png";
                    string pathToCheck = Path.Combine(savePath, fileName);

                    Book book = new Book();
                    book.PhotoName = pathToCheck;
                    User user = new User();
                    user = (User)Session["User"];
                    book.Title = txtTitle.Text;
                    book.Price = txtPrice.Text; 
                    book.BookTypeID = new Guid(ddlGenre.SelectedValue);
                    user.Books.List.Add(book);
                    user.Save();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        void SaveFile(HttpPostedFile file)
        {
            // Specify the path to save the uploaded file to.
             savePath = Server.MapPath("Images");

            // Get the name of the file to upload.
            string fileName = fuPhoto.FileName;

            // Create the path and file name to check for duplicates.
            string pathToCheck = Path.Combine(savePath, fileName);

            // Create a temporary file name to use for checking duplicates.
            string tempfileName = "";

            // Check to see if a file already exists with the
            // same name as the file to upload.        
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck) == true)
                {
                    // if a file with this name already exists,
                    // prefix the filename with a number.
                    tempfileName = counter.ToString() + fileName;
                    pathToCheck = Path.Combine(savePath, tempfileName);
                    counter++;
                }

                fileName = tempfileName;

                // Notify the user that the file name was changed.
                lblMessage.Text = "A file with the same name already exists." +
                    "<br />Your file was saved as " + fileName;

                // Append the name of the file to upload to the path.
                savePath = Path.Combine(savePath, fileName);

                // Call the SaveAs method to save the uploaded
                // file to the specified directory.
                fuPhoto.SaveAs(savePath);

                Book book = new Book();
                book.PhotoName = savePath;
                User user = new User();
                user = (User)Session["User"];
                book.Title = txtTitle.Text;
                book.Price = txtPrice.Text;
                book.BookTypeID = new Guid(ddlGenre.SelectedValue);
                user.Books.List.Add(book);
                user.Save();
            }
            else
            {
                // Append the name of the file to upload to the path.
                savePath = Path.Combine(savePath, fileName);

                // Call the SaveAs method to save the uploaded
                // file to the specified directory.
                fuPhoto.SaveAs(savePath);

                ////XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                Book book = new Book();
                book.PhotoName = savePath;
                User user = new User();
                user = (User)Session["User"];
                book.Title = txtTitle.Text;
                book.Price = txtPrice.Text;
                book.BookTypeID = new Guid(ddlGenre.SelectedValue);
                user.Books.List.Add(book);
                user.Save();

                // Notify the user that the file was saved successfully.

                lblMessage.Text = "Your file was uploaded successfully.";
                //Response.Redirect("UploadPhoto.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            book = (Book)Session["Book"];
            book.BookTypeID = new Guid(ddlGenre.SelectedValue);
            book.Title = txtTitle.Text;
            book.Price = txtPrice.Text;
            if (fuPhoto.HasFile)
            {

                savePath = Server.MapPath("Images");
                string fileName = fuPhoto.FileName;
                string pathToCheck = Path.Combine(savePath, fileName);

                book.PhotoName = pathToCheck;

            }
            else
            {
                savePath = Server.MapPath("Images");
                book.PhotoName = Path.Combine(savePath, book.ID + book.MimeType);
            }
            User user = new User();
            user = (User)Session["User"];
            user.Books.List.Add(book);
            user.Save();
        }

    }
}
