using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DatabaseHelper;
using BusinessObjectHelper;
using EmailHelper;
using System.IO;

namespace BusinessObjectHelper
{
    public class Book : HeaderData
    {
        #region Private Members
        private Guid _UserID = new Guid();
        private Guid _BookTypeID = new Guid();
        private string _Title = string.Empty;
        private string _Price = string.Empty;
        private byte[] _BookCover = { };
        private string _PhotoName = string.Empty;
        private UserBookList _UserBooks = null;
        private string _RelativePath = string.Empty;
        private string _MimeType = string.Empty;
        private ReviewList _ReviewList = null;
        #endregion

        #region Public Properties

        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                    base.IsDirty = true;
                }
            }
        }

        public String Price
        {
            get
            {
                String money = String.Format("{0:C}", Convert.ToDecimal(_Price));
                return money;
            }
            set
            {
                if (_Price != value)
                {
                    _Price = value;
                    base.IsDirty = true;
                }
            }
        }

        public Guid UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                if (_UserID != value)
                {
                    _UserID = value;
                    base.IsDirty = true;
                }
            }
        }

        public Guid BookTypeID
        {
            get
            {
                return _BookTypeID;
            }
            set
            {
                if (_BookTypeID != value)
                {
                    _BookTypeID = value;
                    base.IsDirty = true;
                }
            }   
        }

        public String Genre
        {
            get
            {
                BookType bt = new BookType();
                bt = bt.GetByID(_BookTypeID);
                return bt.Type;
            }
        }

        public byte[] Cover
        {
            get
            {
                return _BookCover;
            }

            set
            {
                if (_BookCover != value)
                {
                    _BookCover = value;
                    base.IsDirty = true;
                }
            }
        }

        public string PhotoName
        {
            get
            {
                return _PhotoName;
            }
            set
            {
                 _PhotoName = value;
            }
        }

        public UserBookList UserBooks
        {
            get
            {
                if (_UserBooks == null)
                {
                    _UserBooks = new UserBookList();
                    //_UserBooks = _UserBooks.GetByBookID(base.ID);
                }
                return _UserBooks;
            }
        }

        public string RelativePath
        {
            get
            {
                return _RelativePath;
            }

            set
            {
                _RelativePath = value;
            }
        }

        public String MimeType
        {
            get
            {
                return _MimeType;
            }

            set
            {
                _MimeType = value;
            }
        }

        public ReviewList Reviews
        {
            get
            {
                if (_ReviewList == null)
                {
                    _ReviewList = new ReviewList();

                }
                return _ReviewList;
            }
        }
        #endregion

        #region Private Methods
        private Boolean Insert(Database db)
        {
            Book book = new Book();

            try
            {
                db.Command.Parameters.Clear();
                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblBookINSERT";
                base.Initialize(db.Command, Guid.Empty);
                db.Command.Parameters.Add("@BookTypeID", SqlDbType.UniqueIdentifier).Value = _BookTypeID;
                db.Command.Parameters.Add("@Title", SqlDbType.VarChar).Value = _Title;
                db.Command.Parameters.Add("@Price", SqlDbType.VarChar).Value = _Price;
                db.Command.Parameters.Add("@BookCover", SqlDbType.Image).Value = PhotoHelper.Photo.FileToByteArray(_PhotoName);
                db.Command.Parameters.Add("@MimeType", SqlDbType.VarChar).Value = Path.GetExtension(_PhotoName);
                db.ExecuteNonQueryWithTransaction();
                base.Initialize(db.Command);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private Boolean Update(Database db)
        {
            try
            {
                db.Command.Parameters.Clear();
                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblBookUPDATE";
                base.Initialize(db.Command, base.ID);
                db.Command.Parameters.Add("@BookTypeID", SqlDbType.UniqueIdentifier).Value = _BookTypeID;
                db.Command.Parameters.Add("@Title", SqlDbType.VarChar).Value = _Title;
                db.Command.Parameters.Add("@Price", SqlDbType.VarChar).Value = _Price;
                db.Command.Parameters.Add("@BookCover", SqlDbType.Image).Value = PhotoHelper.Photo.FileToByteArray(_PhotoName);
                db.Command.Parameters.Add("@MimeType", SqlDbType.VarChar).Value = Path.GetExtension(_PhotoName);
                db.ExecuteNonQueryWithTransaction();
                base.Initialize(db.Command);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private Boolean Delete(Database db)
        {
            try
            {
                db.Command.Parameters.Clear();
                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblBookDELETE";
                base.Initialize(db.Command, base.ID);
                db.ExecuteNonQueryWithTransaction();
                base.Initialize(db.Command);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private Boolean IsValid()
        {
            Boolean result = true;
            decimal price;
            result = decimal.TryParse(_Price, out price);
            return result;
        }

        #endregion

        #region Public Methods
        public Boolean IsSavable()
        {
            Boolean Result = true;

            if (base.IsDirty == true && IsValid() == true)
            {
                return Result;
            }
            else
            {
                Result = false;
            }

            return Result;
        }

        public Book GetByID(Guid ID)
        {
            Database db = new Database("Books");
            try
            {
                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblBookGETBYID";
                db.Command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
                DataTable dt = db.ExecuteQuery();
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    base.Initialize(dr);
                    InitializeBusinessData(dr);
                    base.IsNew = false;
                    base.IsDirty = false;
                    return this;
                }
                else
                {
                    throw new Exception("Book");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void InitializeBusinessData(DataRow dr)
        {
            _BookTypeID = new Guid(dr["BookTypeID"].ToString());
            _BookCover = (byte [])dr["BookCover"];
            _MimeType = dr["MimeType"].ToString();
            _Title = dr["Title"].ToString();
            _Price = dr["Price"].ToString();
        }

        public Book Save(Database db, Guid userID)
        {

            _UserID = userID;
            Boolean result = true;

            if (base.IsNew == true && IsSavable() == true)
            {
                result = Insert(db);

                UserBook ub = new UserBook();
                ub.UserID = userID;
                _UserBooks = new UserBookList();
                _UserBooks.List.Add(ub);
            }
            else if (base.Deleted == true)
            {
                result = Delete(db);
            }
            else if (base.IsNew == false && IsSavable() == true)
            {
                result = Update(db);
               
            }

            base.IsDirty = false;
            base.IsNew = false;

            if (result == true && _UserBooks != null && _UserBooks.IsSavable() == true)
            {
                result = _UserBooks.Save(db, userID, base.ID);
            }

            return this;
        }

        public Book Save()
        {
            Database db = new Database("Books");
            db.BeginTransaction();
            Boolean result = true;

            if (base.IsNew == true && IsSavable() == true)
            {
                result = Insert(db);
            }
            else if (base.Deleted == true)
            {
                result = Delete(db);
            }
            else if (base.IsNew == false && IsSavable() == true)
            {
                result = Update(db);
               
            }

            base.IsDirty = false;
            base.IsNew = false;

            if (result == true && _ReviewList != null && _ReviewList.IsSavable() == true)
            {
                result = _ReviewList.Save(db, base.ID);
            }

            if (result == true)
            {
                db.EndTransaction();
            }
            else
            {
                db.RollBackTransaction();
            }

            return this;
        }

        #endregion
    }
}


            