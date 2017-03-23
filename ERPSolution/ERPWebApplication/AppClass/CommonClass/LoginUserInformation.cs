using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.CommonClass
{
    public static class LoginUserInformation
    {
        public static string UserID
        {
            get { return HttpContext.Current.Session["@#$$%@)userID(@^&^&%"].ToString(); }
            set { HttpContext.Current.Session["@#$$%@)userID(@^&^&%"] = value; }
        }
        public static int CompanyID
        {
            get { return Convert.ToInt32( HttpContext.Current.Session["@#$$%@)companyID(@^&^&%"].ToString()); }
            set { HttpContext.Current.Session["@#$$%@)companyID(@^&^&%"] = value; }
        }

        
    }
}