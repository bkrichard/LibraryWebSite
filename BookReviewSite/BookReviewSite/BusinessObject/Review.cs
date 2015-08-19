using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DatabaseHelper;
using BusinessObjectHelper;
using EmailHelper;

namespace BusinessObjectHelper
{
    public class Review : HeaderData
    {
        #region Private Members
        private Guid _UserID = new Guid();
        private Guid _BookID = new Guid();
        private String _Title = string.Empty;
        private String _Review = string.Empty;

        #endregion

        #region Public Properties

        public Guid BookID
        {
            get
            {
                return _BookID;
            }
            set
            {
                if (_BookID != value)
                {
                    _BookID = value;
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

        public String User
        {
            get
            {
                User user = new User();
                user = user.GetByID(_UserID);
                return user.UserName;
            }
        }

        public String BookReview
        {
            get
            {
                return _Review;
            }
            set
            {
                if (_Review != value)
                {
                    _Review = value;
                    base.IsDirty = true;
                }
            }
        }

        public String Title
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
        #endregion

        #region Private Methods
        private Boolean Insert(Database db)
        {
            Review review = new Review();

            try
            {
                db.Command.Parameters.Clear();
                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblReviewINSERT";
                base.Initialize(db.Command, Guid.Empty);
                db.Command.Parameters.Add("@BookID", SqlDbType.UniqueIdentifier).Value = _BookID;
                db.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = _UserID;
                db.Command.Parameters.Add("@Title", SqlDbType.VarChar).Value = Title;
                db.Command.Parameters.Add("@BookReview", SqlDbType.VarChar).Value = _Review;
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
                db.Command.CommandText = "tblReviewUPDATE";
                base.Initialize(db.Command, base.ID);
                db.Command.Parameters.Add("@BookID", SqlDbType.UniqueIdentifier).Value = _BookID;
                db.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = _UserID;
                db.Command.Parameters.Add("@Title", SqlDbType.VarChar).Value = Title;
                db.Command.Parameters.Add("@BookReview", SqlDbType.VarChar).Value = _Review;
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
                db.Command.CommandText = "tblReviewDELETE";
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
            return true;
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

        public void InitializeBusinessData(DataRow dr)
        {
            _BookID = new Guid(dr["BookID"].ToString());
            _UserID = new Guid(dr["UserID"].ToString());
            _Title = dr["Title"].ToString();
            _Review = dr["BookReview"].ToString();
        }

        public Review Save(Database db, Guid bookID)
        {

            _BookID = bookID;
            Boolean result = false;
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
            return this;
        }

        #endregion
    }
}