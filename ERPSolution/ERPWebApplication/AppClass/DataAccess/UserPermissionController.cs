using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


namespace ERPWebApplication.AppClass.DataAccess
{
    public class UserPermissionController : DataAccessBase
    {
        internal DataTable GetData()
        {
            try
            {
                string sqlString = "SELECT [NodeTypeID], [ActivityName], [FormDescription], [FormName],[PNodeTypeID] FROM [uDefaultNodeList] ";
                var dtEntityDetails = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                return dtEntityDetails;

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
            
        }
    }
}