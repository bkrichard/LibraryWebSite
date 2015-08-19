using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseHelper;
using System.Data;
using System.ComponentModel;

namespace BusinessObjectHelper
{
    public class UserBookList : HeaderData
    {
        #region Private Members
        private BindingList<UserBook> _list;
        #endregion

        #region Public Properties
        public BindingList<UserBook> List
        {
            get
            {
                return _list;
            }
        }

        public int Count
        {
            get
            {
                return _list.Count;
            }
        }
        #endregion

        #region Public Methods

        public Boolean Save(Database db, Guid UserID, Guid BookID)
        {
            Boolean result = true;

            foreach (UserBook s in _list)
            {
                if (s.IsSavable() == true)
                {
                    s.Save(db, UserID, BookID);
                    if (s.IsNew == true)
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        public Boolean IsSavable()
        {
            Boolean result = false;
            foreach (UserBook s in _list)
            {
                if (s.IsSavable() == true)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public UserBookList GetAll()
        {
            _list.Clear();
            Database db = new Database("Books");
            db.Command.CommandType = System.Data.CommandType.StoredProcedure;
            db.Command.CommandText = "tblUserBookGETALL";
            DataTable dt = db.ExecuteQuery();
            //dgvStudent.DataSource = dt;
            foreach (DataRow dr in dt.Rows)
            {
                UserBook s = new UserBook();
                s.Initialize(dr);
                s.InitializeBusinessData(dr);
                s.IsDirty = false;
                s.IsNew = false;
                s.evtIsSavable += new IsSavableHandler(s_evtIsSavable);
                _list.Add(s);
            }

            return this;
        }

        public UserBookList GetByUserID(Guid UserID)
        {
            Database db = new Database("Books");
            try
            {
                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblUserBookGETBYUSERID";
                db.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = UserID;
                DataTable dt = db.ExecuteQuery();
                //dgvStudent.DataSource = dt;
                foreach (DataRow dr in dt.Rows)
                {
                    UserBook s = new UserBook();
                    s.Initialize(dr);
                    s.InitializeBusinessData(dr);
                    s.IsDirty = false;
                    s.IsNew = false;
                    s.evtIsSavable += new IsSavableHandler(s_evtIsSavable);
                    _list.Add(s);
                }

                return this;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Event Handler
        void s_evtIsSavable(bool savable)
        {
            RaiseEvent(savable);
        }
        #endregion

        #region Construction
        public UserBookList()
        {
            _list = new BindingList<UserBook>();
            _list.AddingNew += new AddingNewEventHandler(_list_AddingNew);
        }

        void _list_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new UserBook();
            ((UserBook)e.NewObject).evtIsSavable += new IsSavableHandler(s_evtIsSavable);
        }
        #endregion
    }
}