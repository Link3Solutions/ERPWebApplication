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
        private UserPermissionController _objUserPermissionController;
        private UserPermission _objUserPermission;
        private CompanySetup _objCompanySetup;
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

                
                if (objUserList.SecurityCode != CheckSecurityCodeOnline(objUserList))
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
        public string CheckSecurityCodeOnline(UserList objUserList)
        {
            try
            {
                string targetSecurityCode = null;
                string sql = @"
                SELECT A.SecurityCode FROM UserSecurityCode A
                INNER JOIN uUserProfileTemp B ON A.UserProfileID = B.UserProfileID
                WHERE B.DataUsed = 'A'  AND A.DataUsed = 'A' AND A.SecurityCodeStatus = 0 AND B.UserEmail = '" + objUserList.UserEmail + "'";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                targetSecurityCode = objclsDataManipulation.GetSingleValueAsString(this.ConnectionString, sql);
                return targetSecurityCode;

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
                AddValuesForRoleSetup(objUserList);


            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }


        internal void GetReadyForAnotherServices(UserList objUserList, CompanySetup objCompanySetup)
        {
            try
            {
                ServeClientNodeAnother(objUserList,objCompanySetup);
                AddValuesForRoleSetupAnother(objUserList,objCompanySetup);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }


        private void AddValuesForRoleSetup(UserList objUserList)
        {
            try
            {
                _objUserPermission = new UserPermission();
                _objUserPermissionController = new UserPermissionController();
                _objUserPermission.RoleID = _objUserPermissionController.GetRoleID();
                var storedProcedureComandText = "INSERT INTO [uRoleSetup] ([CompanyID],[RoleID],[RoleTypeID],[RoleName],[DataUsed],[EntryUserID],[EntryDate]) VALUES ( " +
                                                 _companyID + "," +
                                                 _objUserPermission.RoleID + ",'" +
                                                 "1125001" + "','" +
                                                  "All Services" + "','" +
                                                 "A" + "', '" +
                                                 _entryUserName + "'," +
                                                 "CAST(GETDATE() AS DateTime));";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

                var storedProcedureComandTextNodes = @"INSERT INTO [uRoleSetupDetails] ([RoleID],[NodeID],[DataUsed],[EntryUserID],[EntryDate])
                    SELECT DISTINCT " + _objUserPermission.RoleID + " ,A.NodeTypeID,'A','" + _entryUserName + "',CAST(GETDATE() AS DateTime)" +
                    " FROM OnlineServiceRequestNodes A " +
                    " INNER JOIN OnlineServiceRequestDetails B ON A.FeatureDetailsID = B.FeatureDetailsID " +
                    " INNER JOIN OnlineServiceRequest C ON B.ServiceRequestID = C.ServiceRequestID " +
                    " INNER JOIN uUserProfileTemp D ON C.UserProfileID = D.UserProfileID " +
                    " WHERE A.DataUsed = 'A' AND B.DataUsed = 'A' AND C.DataUsed = 'A' AND D.DataUsed='A' AND D.UserEmail = '" + objUserList.UserEmail + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTextNodes);
                AddValuesForUserRole(objUserList,_objUserPermission);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private void AddValuesForRoleSetupAnother(UserList objUserList, CompanySetup objCompanySetup)
        {
            try
            {
                _objUserPermission = new UserPermission();
                _objUserPermissionController = new UserPermissionController();
                _objUserPermission.RoleID = _objUserPermissionController.GetRoleID();
                var storedProcedureComandText = "INSERT INTO [uRoleSetup] ([CompanyID],[RoleID],[RoleTypeID],[RoleName],[DataUsed],[EntryUserID],[EntryDate]) VALUES ( " +
                                                 objCompanySetup.CompanyID + "," +
                                                 _objUserPermission.RoleID + ",'" +
                                                 "1125001" + "','" +
                                                  "All Services" + "','" +
                                                 "A" + "', '" +
                                                 objUserList.UserID + "'," +
                                                 "CAST(GETDATE() AS DateTime));";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

                var storedProcedureComandTextNodes = @"INSERT INTO [uRoleSetupDetails] ([RoleID],[NodeID],[DataUsed],[EntryUserID],[EntryDate])
                    SELECT DISTINCT " + _objUserPermission.RoleID + " ,A.NodeTypeID,'A','" + objUserList.UserID + "',CAST(GETDATE() AS DateTime)" +
                    " FROM OnlineServiceRequestNodes A " +
                    " INNER JOIN OnlineServiceRequestDetails B ON A.FeatureDetailsID = B.FeatureDetailsID " +
                    " INNER JOIN OnlineServiceRequest C ON B.ServiceRequestID = C.ServiceRequestID " +
                    " INNER JOIN uUserProfileTemp D ON C.UserProfileID = D.UserProfileID " +
                    " WHERE A.DataUsed = 'A' AND B.DataUsed = 'A' AND C.DataUsed = 'A' AND D.DataUsed='A' AND D.UserEmail = '" + objUserList.UserEmail + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTextNodes);
                AddValuesForUserRole(objUserList, _objUserPermission);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void AddValuesForUserRole(UserList objUserList,UserPermission objUserPermission)
        {
            try
            {
                _objUserPermission = new UserPermission();
                List<int> listRole = new List<int>();                
                listRole.Add(Convert.ToInt32(objUserPermission.RoleID));
                _objUserPermission.roleList = listRole;
                _objUserPermission.RoleType = "1125001";
                EmployeeSetup objEmployeeSetup = new EmployeeSetup();

                UserProfile objUserProfile = new UserProfile();
                UserProfileController objUserProfileController = new UserProfileController();
                objUserProfile.UserIdentifierID = objUserList.UserName;
                objEmployeeSetup.EmployeeID = _entryUserName;
                objEmployeeSetup.CompanyID = _companyID;
                objEmployeeSetup.EntryUserName = _entryUserName;
                _objUserPermissionController = new UserPermissionController();

                List<int> listRelatedUserRole = new List<int>();
                //foreach (ListItem item in ListBoxSelectedRelatedUserRole.Items)
                //{
                //    listRelatedUserRole.Add(Convert.ToInt32(item.Value.ToString()));
                //}
                _objUserPermission.RelatedUserRoleList = listRelatedUserRole;
                _objUserPermissionController.SaveUserRole(objEmployeeSetup, _objUserPermission);
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
        private void ServeClientNodeAnother(UserList objUserList, CompanySetup objCompanySetup)
        {
            try
            {
                var storedProcedureComandText = @"INSERT INTO [uDefaultNodeList] ([CompanyID],[BranchID],[ActivityID],[ActivityName],[SeqNo],[NodeTypeID],[PNodeTypeID],[FormDescription],[FormName]
                ,[ShowPosition],[DataUsed],[EntryUserID],[EntryDate],[UserID])
                SELECT DISTINCT " + objCompanySetup.CompanyID + ",1,A.ActivityID,A.ActivityName,A.SeqNo,A.NodeTypeID,A.PNodeTypeID,A.FormDescription,A.FormName,A.ShowPosition,'A','" + _entryUserName + "',CAST(GETDATE() AS DateTime),'" + objUserList.UserName + "'" +
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