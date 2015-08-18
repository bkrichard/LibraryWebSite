using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseHelper;
using System.Data;
using EmailHelper;
using BusinessObjectHelper;
using BookReviewSite.BusinessObject;

namespace BusinessObjectHelper
{
    public class User : HeaderData
    {
        #region Private Members
        private DateTime _DateCreated = DateTime.Now;
        private string _FirstName = string.Empty;
        private string _LastName = string.Empty;
        private string _Username = string.Empty;
        private string _Password = string.Empty;
        private string _Email = string.Empty;
        private string _Question1 = string.Empty;
        private string _Answer1 = string.Empty;
        private string _Question2 = string.Empty;
        private string _Answer2 = string.Empty;
        private string _Question3 = string.Empty;
        private string _Answer3 = string.Empty;
        private List<string> _Questions = new List<string>();
        private List<string> _Answers = new List<string>();
        private int _index = -1;
        private Random rnd = new Random();
        private BookList _books = null;
        private UserBookList _userbooks = null;
        #endregion

        #region Public Properties
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    base.IsDirty = true;

                }
            }
        }

        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    base.IsDirty = true;

                }
            }
        }

        public string UserName
        {
            get
            {
                return _Username;
            }
            set
            {
                if (_Username != value)
                {
                    _Username = value;
                    base.IsDirty = true;

                }
            }
        }

        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                if (_Password != value)
                {
                    _Password = value;
                    base.IsDirty = true;

                }
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    base.IsDirty = true;
                }
            }
        }

        public string Question1
        {
            get
            {
                return _Question1;
            }
            set
            {
                if (_Question1 != value)
                {
                    _Question1 = value;
                    base.IsDirty = true;
                }
            }
        }

        public string Answer1
        {
            get
            {
                return _Answer1;
            }
            set
            {
                if (_Answer1 != value)
                {
                    _Answer1 = value;
                    base.IsDirty = true;
                }
            }
        }

        public string Question2
        {
            get
            {
                return _Question2;
            }
            set
            {
                if (_Question2 != value)
                {
                    _Question2 = value;
                    base.IsDirty = true;
                }
            }
        }

        public string Answer2
        {
            get
            {
                return _Answer2;
            }
            set
            {
                if (_Answer2 != value)
                {
                    _Answer2 = value;
                    base.IsDirty = true;
                }
            }
        }

        public string Question3
        {
            get
            {
                return _Question3;
            }
            set
            {
                if (_Question3 != value)
                {
                    _Question3 = value;
                    base.IsDirty = true;
                }
            }
        }

        public string Answer3
        {
            get
            {
                return _Answer3;
            }
            set
            {
                if (_Answer3 != value)
                {
                    _Answer3 = value;
                    base.IsDirty = true;
                }
            }
        }

        public BookList Books
        {
            get
            {
                
                _userbooks = UserBooks;
                
                return _books;
            }
        }

        public UserBookList UserBooks
        {
            get
            {
                //if (_userbooks == null)
                //{
                    _userbooks = new UserBookList();
                    _userbooks = _userbooks.GetByUserID(base.ID);
                    _books = new BookList();
                    foreach(UserBook ub in _userbooks.List)
                    {
                        Book b = new Book();
                        b = b.GetByID(ub.BookID);
                        _books.List.Add(b);
                    }
                //}
                return _userbooks;
            }
        }

        public DateTime DateCreated
        {
            get
            {
                return _DateCreated;
            }

            set
            {
                if (_DateCreated != value)
                {
                    _DateCreated = value;
                    base.IsDirty = true;
                }
            }
        }

        #endregion

        #region Private Methods
        private Boolean Insert(Database db)
        {
            try
            {
                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblUserINSERT";
                base.Initialize(db.Command, Guid.Empty);
                db.Command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = _FirstName;
                db.Command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = _LastName;
                db.Command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = _Username;
                db.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = _Password;
                db.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = _Email;
                db.Command.Parameters.Add("@Question1", SqlDbType.VarChar).Value = _Question1;
                db.Command.Parameters.Add("@Answer1", SqlDbType.VarChar).Value = _Answer1;
                db.Command.Parameters.Add("@Question2", SqlDbType.VarChar).Value = _Question2;
                db.Command.Parameters.Add("@Answer2", SqlDbType.VarChar).Value = _Answer2;
                db.Command.Parameters.Add("@Question3", SqlDbType.VarChar).Value = _Question3;
                db.Command.Parameters.Add("@Answer3", SqlDbType.VarChar).Value = _Answer3;
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
                db.Command.CommandText = "tblUserUPDATE";
                base.Initialize(db.Command, base.ID);
                db.Command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = _FirstName;
                db.Command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = _LastName;
                db.Command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = _Username;
                db.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = _Password;
                db.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = _Email;
                db.Command.Parameters.Add("@Question1", SqlDbType.VarChar).Value = _Question1;
                db.Command.Parameters.Add("@Answer1", SqlDbType.VarChar).Value = _Answer1;
                db.Command.Parameters.Add("@Question2", SqlDbType.VarChar).Value = _Question2;
                db.Command.Parameters.Add("@Answer2", SqlDbType.VarChar).Value = _Answer2;
                db.Command.Parameters.Add("@Question3", SqlDbType.VarChar).Value = _Question3;
                db.Command.Parameters.Add("@Answer3", SqlDbType.VarChar).Value = _Answer3;
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
                db.Command.CommandText = "tblUserDELETE";
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
            Boolean Result = true;

            if (_FirstName.Trim() == string.Empty)
            {
                Result = false;
            }

            if (_LastName.Trim() == string.Empty)
            {
                Result = false;
            }

            if (_FirstName.Trim().Length > 50)
            {
                Result = false;
            }

            if (_LastName.Trim().Length > 50)
            {
                Result = false;
            }

            if (_Username.Trim() == string.Empty)
            {
                Result = false;
            }

            if (_Password.Trim() == string.Empty)
            {
                Result = false;
            }

            if (_Username.Trim().Length > 50)
            {
                Result = false;
            }

            if (_Password.Trim().Length > 50)
            {
                Result = false;
            }
            return Result;
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

        public User GetByID(Guid ID)
        {
            Database db = new Database("Books");
            try
            {
                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblUserGETBYID";
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
                    throw new Exception("User not found");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void InitializeBusinessData(DataRow dr)
        {
            _DateCreated = Convert.ToDateTime(dr["DateCreated"].ToString());
            _FirstName = dr["FirstName"].ToString();
            _LastName = dr["LastName"].ToString();
            _Username = dr["UserName"].ToString();
            _Password = dr["Password"].ToString();
            _Email = dr["Email"].ToString();
            _Question1 = dr["Question1"].ToString();
            _Answer1 = dr["Answer1"].ToString();
            _Question2 = dr["Question2"].ToString();
            _Answer2 = dr["Answer2"].ToString();
            _Question3 = dr["Question3"].ToString();
            _Answer3 = dr["Answer3"].ToString();
            _Questions.Add(_Question1);
            _Questions.Add(_Question2);
            _Questions.Add(_Question3);
            _Answers.Add(_Answer1);
            _Answers.Add(_Answer2);
            _Answers.Add(_Answer3);
        }

        public User Login(string username, string password)
        {
            Database db = new Database("Books");
            try
            {
                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblUserLOGIN";
                db.Command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = username;
                db.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
                DataTable dt = db.ExecuteQuery();
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    base.Initialize(dr);
                    base.IsNew = false;
                    base.IsDirty = false;
                    InitializeBusinessData(dr);
                    return this;
                }
                else
                {
                    throw new ApplicationException("Invalid Login");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public User Register(string email, string firstname, string lastname, string username,
            string question1, string answer1, string question2, string answer2, string question3, string answer3)
        {
            Database db = new Database("Books");
            try
            {
                String Pass = ValidateEmail.GeneratePassword (3,3,3);
                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblUserREGISTER";
                db.Command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = firstname;
                db.Command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = lastname;
                db.Command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = username;
                db.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = Pass;
                db.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                db.Command.Parameters.Add("@Question1", SqlDbType.VarChar).Value = question1;
                db.Command.Parameters.Add("@Answer1", SqlDbType.VarChar).Value = answer1;
                db.Command.Parameters.Add("@Question2", SqlDbType.VarChar).Value = question2;
                db.Command.Parameters.Add("@Answer2", SqlDbType.VarChar).Value = answer2;
                db.Command.Parameters.Add("@Question3", SqlDbType.VarChar).Value = question3;
                db.Command.Parameters.Add("@Answer3", SqlDbType.VarChar).Value = answer3;
                DataTable dt = db.ExecuteQuery();
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    base.Initialize(dr);
                    InitializeBusinessData(dr);
                    Email e = new Email();
                    e.To = email;
                    e.Subject = "Your Password";
                    e.Body = String.Format("Your password is {0}", dr["Password"].ToString());
                    e.Send();
                    return this;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Boolean Recover(string email)
        {
            Database db = new Database("Books");
            try
            {

                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblUserRECOVER";
                db.Command.Parameters.Add(@"Email", SqlDbType.VarChar).Value = email;
                DataTable dt = db.ExecuteQuery();
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    _Questions.Add(dr["Question1"].ToString());
                    _Questions.Add(dr["Question2"].ToString());
                    _Questions.Add(dr["Question3"].ToString());
                    _Answers.Add(dr["Answer1"].ToString());
                    _Answers.Add(dr["Answer2"].ToString());
                    _Answers.Add(dr["Answer3"].ToString());
                    base.Initialize(dr);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Boolean Recover(string email, string firstname, string lastname, string username, string answer)
        {
            Database db = new Database("Books");
            try
            {
                if (_Answers[_index] == answer)
                {
                    db.Command.CommandType = CommandType.StoredProcedure;
                    db.Command.CommandText = "tblUserRECOVER";
                    db.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                    DataTable dt = db.ExecuteQuery();
                    if (dt.Rows.Count == 1)
                    {
                        DataRow dr = dt.Rows[0];
                        Email e = new Email();
                        e.To = email;
                        e.Subject = "Password Recovery";
                        e.Body = String.Format("Your password is {0}", dr["password"].ToString());
                        e.Send();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public User Save()
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

            if (result == true && _books != null && _books.IsSavable() == true)
            {
                result = _books.Save(db, base.ID);
            }

            if (result == true && _userbooks != null && _userbooks.IsSavable() == true)
            {
                result = _userbooks.Save(db, _userbooks.List[_userbooks.List.Count - 1].UserID, _userbooks.List[_userbooks.List.Count - 1].BookID);
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

        public User ChangePassword(string newpassword)
        {
            Database db = new Database("Books");

            try
            {
                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblUserCHANGEPASSWORD";
                base.Initialize(db.Command, base.ID);
                db.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = newpassword;
                db.ExecuteNonQuery();
                base.Initialize(db.Command);
                return this;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public String GetQuestion()
        {
            _index = rnd.Next(0, 3);
            return _Questions[_index].ToString();
        }

        public String GetAnswer()
        {
            return _Answers[_index].ToString();
        }
        #endregion

        #region Construction
        public User()
        {

        }
        #endregion
    }
}