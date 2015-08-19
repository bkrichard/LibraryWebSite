using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Xml;
using System.Configuration;

namespace ConfigurationHelper
{
    public class Configuration
    {
        public static string GetConnectionString(string Name)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[Name].ConnectionString;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
