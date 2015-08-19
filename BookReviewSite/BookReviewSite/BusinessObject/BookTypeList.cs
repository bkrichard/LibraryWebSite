using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseHelper;
using System.Data;
using System.ComponentModel;

namespace BusinessObjectHelper
{
    public class BookTypeList : HeaderData
    {
        #region Private Members
        private BindingList<BookType> _list;
        #endregion

        #region Public Properties
        public BindingList<BookType> List
        {
            get
            {
                return _list;
            }
        }
        #endregion

        #region Public Methods

        public Boolean Save(Database db, Guid UserID)
        {
            Boolean result = true;

            foreach (BookType s in _list)
            {
                if (s.IsSavable() == true)
                {
                    s.Save(db, UserID);
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
            foreach (BookType s in _list)
            {
                if (s.IsSavable() == true)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public BookTypeList GetAll()
        {
            _list.Clear();
            Database db = new Database("Books");
            db.Command.CommandType = System.Data.CommandType.StoredProcedure;
            db.Command.CommandText = "tblBookTypeGETALL";
            DataTable dt = db.ExecuteQuery();
            //dgvStudent.DataSource = dt;
            foreach (DataRow dr in dt.Rows)
            {
                BookType s = new BookType();
                s.Initialize(dr);
                s.InitializeBusinessData(dr);
                s.IsDirty = false;
                s.IsNew = false;
                s.evtIsSavable += new IsSavableHandler(s_evtIsSavable);
                _list.Add(s);
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
        public BookTypeList()
        {
            _list = new BindingList<BookType>();
            _list.AddingNew += new AddingNewEventHandler(_list_AddingNew);
        }

        void _list_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Book();
            ((Book)e.NewObject).evtIsSavable += new IsSavableHandler(s_evtIsSavable);
        }
        #endregion
    }
}