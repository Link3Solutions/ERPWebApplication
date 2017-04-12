using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Data;
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

                if (CheckUserName(objUserList) != 0)
                {
                    throw new Exception("User name already exist ");

                }

                var storedProcedureComandText = "exec [uUserRegistration] '" +
                                        objUserList.UserPassword + "','" +
                                        objUserList.SecurityCode + "','" +
                                        objUserList.UserName + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private int CheckUserName(UserList objUserList)
        {
            try
            {
                int countUserProfileId = 0;
                string sqlString = "SELECT ISNULL( COUNT( UserProfileID),0) FROM uUserList WHERE UserName = '" + objUserList.UserName + "'";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                objclsDataManipulation.GetSingleValue(this.ConnectionString, sqlString);
                return countUserProfileId;

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



        internal DataTable GetLoginUserInformation(UserList objUserList)
        {
            try
            {
                DataTable dtInformation = new DataTable();
                string sqlString = null;
                return dtInformation;

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}