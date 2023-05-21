
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmitBytesBlog.Admin
{
    public class UIConstants
    {
        #region Cookie Constants
        public const string AUTH_COOKIE_NAME = ".amitbytes.auth";
        public const string XCSRF_COOKIE_NAME = ".amitbytes.xcsrf";
        public const string XCSRF_FORMTOKEN_NAME = ".amitbytes.xcsrftoken";
        public const string SESSION_COOKIE_NAME = ".amitbytes.session";
        #endregion

        #region Sessions
        public const string CURRENTUSER_SESSIONKEY = "CURRENT_USER";
        public const string SESSIONTIMEOUT_CODE = "1001";
        public const string SESSIONTIMEOUT_MESSAGE = "Your session timeout, please login again";
        #endregion

        #region TempDataExtentions Constants
        public const string SUCCESS_MESSAGE = "SUCCESSMESSAGE";
        #endregion
    }
}
