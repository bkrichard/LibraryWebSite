using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseHelper;
using System.Data;
using System.ComponentModel;

namespace BusinessObjectHelper
{
    public class ReviewList : HeaderData
    {
        #region Private Members
        private BindingList<Review> _list;
        #endregion

        #region Public Properties
        public BindingList<Review> List
        {
            get
            {
                return _list;
            }
        }
        #endregion

        #region Public Methods

        public Boolean Save(Database db, Guid BookID)
        {
            Boolean result = true;

            foreach (Review s in _list)
            {
                if (s.IsSavable() == true)
                {
                    s.Save(db, BookID);
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
            foreach (Review s in _list)
            {
                if (s.IsSavable() == true)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public ReviewList GetAll()
        {
            try
            {
                _list.Clear();
                Database db = new Database("Books");
                db.Command.CommandType = System.Data.CommandType.StoredProcedure;
                db.Command.CommandText = "tblReviewGETALL";
                DataTable dt = db.ExecuteQuery();
                //dgvStudent.DataSource = dt;
                foreach (DataRow dr in dt.Rows)
                {
                    Review s = new Review();
                    s.Initialize(dr);
                    s.InitializeBusinessData(dr);
                    s.IsDirty = false;
                    s.IsNew = false;
                    s.evtIsSavable += new IsSavableHandler(s_evtIsSavable);
                    _list.Add(s);
                }
            }

            catch(Exception ex)
            {
                throw;
            }

            return this;
        }

        public ReviewList GetByBookID(Guid BookID)
        {
            Database db = new Database("Books");
            try
            {
                db.Command.Parameters.Clear();
                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblReviewGETBYBOOKID";
                db.Command.Parameters.Add("@BookID", SqlDbType.UniqueIdentifier).Value = BookID;
                DataTable dt = db.ExecuteQuery();
                foreach (DataRow dr in dt.Rows)
                {
                    Review s = new Review();
                    s.Initialize(dr);
                    s.InitializeBusinessData(dr);
                    s.IsDirty = false;
                    s.IsNew = false;
                    s.evtIsSavable += new IsSavableHandler(s_evtIsSavable);
                    _list.Add(s);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return this;
        }

        #endregion

        #region Event Handler
        void s_evtIsSavable(bool savable)
        {
            RaiseEvent(savable);
        }
        #endregion

        #region Construction
        public ReviewList()
        {
            _list = new BindingList<Review>();
            _list.AddingNew += new AddingNewEventHandler(_list_AddingNew);
        }

        void _list_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Review();
            ((Review)e.NewObject).evtIsSavable += new IsSavableHandler(s_evtIsSavable);
        }
        #endregion
    }
}