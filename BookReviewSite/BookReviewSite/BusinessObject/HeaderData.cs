using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BusinessObjectHelper
{
    public class HeaderData : Event
    {
        #region Private Memebers
        private Guid _ID;
        private int _Version;
        private DateTime _LastUpdated;
        private Boolean _Deleted;
        private Boolean _IsNew = true;
        private Boolean _IsDirty = false;
        #endregion

        #region Public Properties
        public Guid ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        public int Version
        {
            get
            {
                return _Version;
            }
            set
            {
                _Version = value;
            }
        }

        public DateTime LastUpdated
        {
            get
            {
                return _LastUpdated;
            }
            set
            {
                _LastUpdated = value;
            }
        }

        public Boolean Deleted
        {
            get
            {
                return _Deleted;
            }
            set
            {
                _Deleted = value;
                _IsDirty = true;
            }
        }

        public Boolean IsNew
        {
            get
            {
                return _IsNew;
            }
            set
            {
                _IsNew = value;
            }
        }

        public Boolean IsDirty
        {
            get
            {
                return _IsDirty;
            }

            set
            {
                _IsDirty = value;
            }
        }
        #endregion

        #region Public Methods
        public void Initialize(DataRow dr)
        {
            _ID = (Guid)dr["ID"];
            _Version = (int)dr["Version"];
            _LastUpdated = (DateTime)dr["LastUpdated"];
            _Deleted = (Boolean)dr["Deleted"];
        }

        public void Initialize(SqlCommand cmd)
        {
            _ID = new Guid(cmd.Parameters["@ID"].Value.ToString());
            _Version = Convert.ToInt32(cmd.Parameters["@Version"].Value.ToString());
            _LastUpdated = Convert.ToDateTime(cmd.Parameters["@LastUpdated"].Value.ToString());
            _Deleted = Convert.ToBoolean(cmd.Parameters["@Deleted"].Value.ToString());
        }

        public void Initialize(SqlCommand cmd, Guid ID)
        {
            SqlParameter parm = new SqlParameter();
            parm.ParameterName = "@ID";
            parm.Direction = ParameterDirection.InputOutput;
            parm.SqlDbType = SqlDbType.UniqueIdentifier;
            parm.Value = ID;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter();
            parm.ParameterName = "@Version";
            parm.Direction = ParameterDirection.Output;
            parm.SqlDbType = SqlDbType.Int;
            parm.Value = 0;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter();
            parm.ParameterName = "@LastUpdated";
            parm.Direction = ParameterDirection.Output;
            parm.SqlDbType = SqlDbType.DateTime;
            parm.Value = DateTime.MaxValue;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter();
            parm.ParameterName = "@Deleted";
            parm.Direction = ParameterDirection.Output;
            parm.SqlDbType = SqlDbType.Bit;
            parm.Value = false;
            cmd.Parameters.Add(parm);
        }

        #endregion
    }
}
