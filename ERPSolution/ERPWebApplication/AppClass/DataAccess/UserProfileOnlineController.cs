using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.Model;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class UserProfileOnlineController : DataAccessBase
    {
        internal void SaveUserProfileOnline(UserProfileOnline objUserProfileOnline, CompanyDetailsSetup objCompanyDetailsSetup)
        {
            try
            {
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                objUserProfileOnline.UserProfileID = objclsDataManipulation.GetAnUniqueidentifierNumber(this.ConnectionString);
                var storedProcedureComandText = @"INSERT INTO [uUserProfileTemp]
               ([UserProfileID]
               ,[CompanyName]
               ,[CompanyEmail]
               ,[UserEmail]
               ,[UserTitle]
               ,[UserName]
               ,[DataUsed]
               ,[EntryDate])
                    VALUES
                   ('" + objUserProfileOnline.UserProfileID + "'"
                      + ",'" + objCompanyDetailsSetup.CompanyName + "'"
                      + ",'" + objCompanyDetailsSetup.CompanyEmail + "'"
                      + ",'" + objUserProfileOnline.Email + "'"
                      + ",'" + objUserProfileOnline.Title + "'"
                      + ",'" + objUserProfileOnline.FullName + "'"
                      + ",'" + "A" + "'"
                      + "," + "CAST(GETDATE() AS DateTime)" + ""
                      + ");";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}