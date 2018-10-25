using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.Model;
using System.Data;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class OnlineRegisterController : DataAccessBase
    {
        private CompanySetupController _objCompanySetupController;
        private CompanyDetailsSetup _objCompanyDetailsSetup;
        private UserProfileOnlineController _objUserProfileOnlineController;
        private string _entryUserName = null;
        private int _companyID;
        internal void Update(UserList objUserList)
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

                UserListController objUserListController = new UserListController();
                if (objUserList.SecurityCode != objUserListController.CheckSecurityCode(objUserList))
                {
                    throw new Exception("The security code and email do not match.");

                }

                this.GetReadyForOnlineUser(objUserList);
                var storedProcedureComandText = "exec [uUserRegistrationUpdate] '" +
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
        internal void GetReadyForOnlineUser(UserList objUserList)
        {
            try
            {
                CreateCompanyOnline(objUserList);
                ServeClientNode(objUserList);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void ServeClientNode(UserList objUserList)
        {
            try
            {
                _companyID = GetUserCompanyIDonline();
                var storedProcedureComandText = @"INSERT INTO [uDefaultNodeList] ([CompanyID],[BranchID],[ActivityID],[ActivityName],[SeqNo],[NodeTypeID],[PNodeTypeID],[FormDescription],[FormName]
                ,[ShowPosition],[DataUsed],[EntryUserID],[EntryDate],[UserID])
                SELECT DISTINCT " + _companyID + ",1,A.ActivityID,A.ActivityName,A.SeqNo,A.NodeTypeID,A.PNodeTypeID,A.FormDescription,A.FormName,A.ShowPosition,'A','" + _entryUserName + "',CAST(GETDATE() AS DateTime),'" + objUserList.UserName + "'" +
                " FROM OnlineServiceRequestNodes A " +
                " INNER JOIN OnlineServiceRequestDetails B ON A.FeatureDetailsID = B.FeatureDetailsID " +
                " INNER JOIN OnlineServiceRequest C ON B.ServiceRequestID = C.ServiceRequestID " +
                " INNER JOIN uUserProfileTemp D ON C.UserProfileID = D.UserProfileID " +
                " WHERE A.DataUsed = 'A' AND B.DataUsed = 'A' AND C.DataUsed = 'A' AND D.DataUsed='A' AND D.UserEmail = '" + objUserList.UserEmail + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private int GetUserCompanyIDonline()
        {
            try
            {
                CompanySetupController objCompanySetupController = new CompanySetupController();
                UserProfile objUserProfile = new UserProfile();
                objUserProfile.UserProfileID = _entryUserName;
                return objCompanySetupController.GetCompanyID(objUserProfile);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void CreateCompanyOnline(UserList objUserList)
        {
            try
            {
                UserProfileOnline objUserProfileOnline = new UserProfileOnline();
                _objUserProfileOnlineController = new UserProfileOnlineController();
                objUserProfileOnline.DtUserProfileOnline = _objUserProfileOnlineController.GetUserProfileOnline(objUserList);
                foreach (DataRow rowNo in objUserProfileOnline.DtUserProfileOnline.Rows)
                {
                    UserProfile _objUserProfile = new UserProfile();
                    _objUserProfile.Title = rowNo["UserTitle"].ToString();
                    _objUserProfile.FullName = rowNo["UserName"].ToString();
                    _objUserProfile.Email = rowNo["UserEmail"].ToString();
                    _objUserProfile.UserProfileTypeID = "1";
                    _objUserProfile.DisplayName = rowNo["UserName"].ToString();
                    _objUserProfile.EntryUserName = rowNo["UserProfileID"].ToString();
                    _objUserProfile.UserProfileID = rowNo["UserProfileID"].ToString();
                    _objUserProfileOnlineController.Save(_objUserProfile);


                    _objCompanySetupController = new CompanySetupController();
                    _objCompanyDetailsSetup = new CompanyDetailsSetup();
                    _objCompanyDetailsSetup.CountryID = 1;
                    _objCompanyDetailsSetup.CompanyName = rowNo["CompanyName"].ToString();
                    _objCompanyDetailsSetup.CompanyEmail = rowNo["CompanyEmail"].ToString();
                    _objCompanyDetailsSetup.CompanyMobile = null;
                    _objCompanyDetailsSetup.CompanyLogo = null;
                    _objCompanyDetailsSetup.EntryUserName = rowNo["UserProfileID"].ToString();
                    _entryUserName = rowNo["UserProfileID"].ToString();
                    _objCompanySetupController.Save(_objCompanyDetailsSetup);
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}