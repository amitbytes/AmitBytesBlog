using System;
using System.Collections.Generic;
using System.Text;

namespace AmitBytesBlog.Entity
{
    public static class Global
    {
        #region Session Constants
        public const string SESSION_CAPTCHA_NAME = "CAPCHA";
        #endregion

        #region MongoDb Configuration
        public static  MongoDbConfig MongoDb { get; set; }
        #endregion

        #region Default Credential
        public static string ADMIN_USER="admin";
        public static string PASSWORD = "admin@404";
        #endregion
    }

    public class MongoDbConfig
    {
        public string Host { get; set; }
        public string Database { get; set; }
        public string ConnectionString
        {
            get
            {
                return $"mongodb://" + Host;
            }
        }
    }
}
