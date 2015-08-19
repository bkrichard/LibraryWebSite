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
    public class BookType : HeaderData
    {
        #region Private Members
        private Guid _ID = new Guid();
        private string _Type;
        #endregion

        #region Public Properties

        public string Type
        {
            get
            {
                return _Type;
            }
            set
            {
                if (_Type != value)
                {
                    _Type = value;
                    base.IsDirty = true;
                }
            }
        }

        public Guid ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    base.IsDirty = true;
                }
            }
        }
        #endregion

        #region Private Methods
        private Boolean Insert(Database db)
        {
            BookType booktype = new BookType();

            try
            {
                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblBookTypeINSERT";
                base.Initialize(db.Command, Guid.Empty);
                db.Command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = _ID;
                db.Command.Parameters.Add("@Type", SqlDbType.VarChar).Value = _Type;
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
                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblBookTypeUPDATE";
                base.Initialize(db.Command, base.ID);
                db.Command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = _ID;
                db.Command.Parameters.Add("@Type", SqlDbType.VarChar).Value = _Type;
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
                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblBookTypeDELETE";
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

        public BookType GetByID(Guid ID)
        {
            Database db = new Database("Books");
            try
            {
                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblBookTypeGETBYID";
                db.Command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
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
            _ID = new Guid(dr["ID"].ToString());
            _Type = dr["Type"].ToString();
        }

        public BookType Save(Database db, Guid userID)
        {

            _ID = ID;
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