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
    public class UserBook : HeaderData
    {
        #region Private Members
        private Guid _UserID = new Guid();
        private Guid _BookID = new Guid();

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

        #endregion

        #region Private Methods
        private Boolean Insert(Database db)
        {
            UserBook userbook = new UserBook();

            try
            {
                db.Command.Parameters.Clear();
                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblUserBookINSERT";
                base.Initialize(db.Command, Guid.Empty);
                db.Command.Parameters.Add("@BookID", SqlDbType.UniqueIdentifier).Value = _BookID;
                db.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = _UserID;
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
                db.Command.CommandText = "tblUserBookUPDATE";
                base.Initialize(db.Command, base.ID);
                db.Command.Parameters.Add("@BookID", SqlDbType.UniqueIdentifier).Value = _BookID;
                db.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = _UserID;
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
                db.Command.CommandText = "tblUserBookDELETE";
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

        public UserBook GetByBookID(Guid BookID)
        {
            Database db = new Database("Books");
            try
            {
                db.Command.Parameters.Clear();
                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblBookGETBYBOOKID";
                db.Command.Parameters.Add("@BookID", SqlDbType.UniqueIdentifier).Value = BookID;
                DataTable dt = db.ExecuteQuery();
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    base.Initialize(dr);
                    InitializeBusinessData(dr);
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
            _BookID = new Guid(dr["BookID"].ToString());
            _UserID = new Guid(dr["UserID"].ToString());
        }

        public UserBook Save(Database db, Guid userID, Guid bookID)
        {

            _UserID = userID;
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