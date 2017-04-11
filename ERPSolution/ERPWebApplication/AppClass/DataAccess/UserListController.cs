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
                if (objUserList.UserPassword.ToString().Length < 6)
                {
                    throw new Exception("Passwords are required to be a minimum of 6 characters in length.");

                }

                if (objUserList.UserPassword != objUserList.ConfirmPassword)
                {
                    throw new Exception("The password and confirmation password do not match.");

                }

                if (objUserList.SecurityCode != CheckSecurityCode(objUserList))
                {
                    throw new Exception("The security code and email do not match.");

                }

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

        private string CheckSecurityCode(UserList objUserList)
        {
            try
            {
                string targetSecurityCode = null;
                string sql = @" SELECT B.SecurityCode FROM [hrEmployeeSetup] A 
                INNER JOIN UserSecurityCode B ON A.CompanyID = B.CompanyID AND A.EmployeeID = B.EmployeeID WHERE 
                B.SecurityCodeStatus = 0 AND B.DataUsed = 'A' AND A.Email = '" + objUserList.UserEmail + "'";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                targetSecurityCode = objclsDataManipulation.GetSingleValueAsString(this.ConnectionString, sql);
                return targetSecurityCode;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }


    }
}