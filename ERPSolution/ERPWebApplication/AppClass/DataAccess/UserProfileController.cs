using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class UserProfileController : DataAccessBase
    {
        internal void Save(UserProfile objUserProfile)
        {
            try
            {
                objUserProfile.UserIdentifierID = objUserProfile.FullName + ":" + objUserProfile.Email;
                string[] fullName = objUserProfile.FullName.Split(new Char[] { ' ' });
                objUserProfile.FirstName = fullName[0];
                if (fullName.Length >= 2)
                {
                    objUserProfile.MiddleName = fullName[1];
                }

                if (fullName.Length >= 3)
                {
                    objUserProfile.LastName = fullName[2];

                }

                objUserProfile.IsApproved = 1;
                objUserProfile.IsLockedOut = 0;
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                objUserProfile.UserProfileID = objclsDataManipulation.GetAnUniqueidentifierNumber(this.ConnectionString);


                var storedProcedureComandText = "INSERT INTO [uUserProfile] ([UserProfileID],[Password],[Email],[Title],[FirstName],[MiddleName],[LastName],[DisplayName] " +
               " ,[DataUsed],[EntryUserID],[EntryDate],[UserIdentifier],[PasswordSalt],[MobilePIN],[LoweredEmail],[DateOfBirth],[PasswordQuestion],[PasswordAnswer]" +
               " ,[CreateDate] ,[Comment],[IsApproved],[IsLockedOut],[UserProfileTypeID]) VALUES (" +
               "'" + objUserProfile.UserProfileID + "'" +
               ",'111'" +
               ",'" + objUserProfile.Email + "'" +
               ",'" + objUserProfile.Title + "'" +
               ",'" + objUserProfile.FirstName + "'" +
               ",'" + objUserProfile.MiddleName + "'" +
               ",'" + objUserProfile.LastName + "'" +
               ",'" + objUserProfile.DisplayName + "'" +
               ",'A'" +
               ",'" + objUserProfile.EntryUserName + "'" +
               ",CAST(GETDATE() AS DateTime)" +
               ",'" + objUserProfile.UserIdentifierID + "'" +
               ",'" + objUserProfile.PasswordSalt + "'" +
               ",'" + objUserProfile.MobilePIN + "'" +
               ",'" + objUserProfile.LoweredEmail + "'" +
               ",'" + objUserProfile.DateOfBirth + "'" +
               ",'" + objUserProfile.PasswordQuestion + "'" +
               ",'" + objUserProfile.PasswordAnswer + "'" +
               ",'" + objUserProfile.CreateDate + "'" +
               ",'" + objUserProfile.Comment + "'" +
               "," + objUserProfile.IsApproved + "" +
               "," + objUserProfile.IsLockedOut + "" +
               ",'" + objUserProfile.UserProfileTypeID + "'" +
               " );";

                storedProcedureComandText += @"INSERT INTO [uUserList]([UserID],[UserTypeID],[UserProfileID],[UserName],[IsAnonymous],[LastActivityDate]) VALUES (NEWID()
               ,1 " +
               ",'" + objUserProfile.UserProfileID + "'" +
               ",'" + objUserProfile.UserIdentifierID + "'" +
               ",NULL,NULL);";

                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal string GetUserProfileID(UserProfile objUserProfile)
        {
            try
            {
                string targetUserProfileID = null;
                string sql = @"SELECT DISTINCT UserProfileID FROM [uUserProfile] WHERE DataUsed = 'A' AND IsApproved = 1 AND IsLockedOut = 0 AND UserIdentifier " +
                 "= '" + objUserProfile.UserIdentifierID + "'";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                targetUserProfileID = objclsDataManipulation.GetSingleValueAsString(this.ConnectionString, sql);
                return targetUserProfileID;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}