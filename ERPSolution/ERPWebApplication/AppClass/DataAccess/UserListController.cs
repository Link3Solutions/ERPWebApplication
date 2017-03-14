using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class UserListController : DataAccessBase
    {
        internal void Save(UserList objUserList)
        {
            try
            {
                var storedProcedureComandText = "exec [uUserRegistration] '" +
                                        objUserList.UserPassword + "','" +                                        
                                        objUserList.SecurityCode + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}