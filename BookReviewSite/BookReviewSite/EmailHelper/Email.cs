using System.Net;
using System.Net.Mail;
using System;
using System.Net.Configuration;
using System.Configuration;

namespace EmailHelper
{

    public class Email
    {
        #region Private Members

        private string _host = string.Empty;
        private int _port = 0;
        private string _username = string.Empty;
        private string _password = string.Empty;
        private string _to = string.Empty;
        private string _from = string.Empty;
        private string _subject = string.Empty;
        private string _body = string.Empty;

        #endregion

        #region Public Properties

        public string Host
        {
            get
            {
                return _host;
            }

            set
            {
                if (_host != value)
                {
                    _host = value;
                }
            }
        }

        public int Port
        {
            get
            {
                return _port;
            }

            set
            {
                if (_port != value)
                {
                    _port = value;
                }
            }
        }

        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                if (_username != value)
                {
                    _username = value;
                }
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                }
            }
        }

        public string To
        {
            get
            {
                return _to;
            }
            set
            {
                if (_to != value)
                {
                    _to = value;
                }
            }
        }

        public string From
        {
            get
            {
                return _from;
            }
            set
            {
                if (_from != value)
                {
                    _from = value;
                }
            }
        }

        public string Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                if (_subject != value)
                {
                    _subject = value;
                }
            }
        }

        public string Body
        {
            get
            {
                return _body;
            }
            set
            {
                if (_body != value)
                {
                    _body = value;
                }
            }
        }

        #endregion

        #region Public Methods
        public bool Send()
        {
            bool result = true;
            try
            {
                SmtpClient smtp = new SmtpClient(_host, _port);

                NetworkCredential credentials = new NetworkCredential(_username, _password);
                smtp.Credentials = credentials;
                smtp.EnableSsl = true;

                MailMessage message = new MailMessage(_from, _to, _subject, _body);

                smtp.Send(message);
            }
            catch (Exception ex)
            {
                result = false;
                throw;
            }

            return result;
        }
        #endregion

        #region Constructor
        public Email()
        {
            var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            _from = smtpSection.From;
            _username = smtpSection.Network.UserName;
            _password = smtpSection.Network.Password;
            _port = smtpSection.Network.Port;
            _host = smtpSection.Network.Host;
        }
        #endregion

    }

}