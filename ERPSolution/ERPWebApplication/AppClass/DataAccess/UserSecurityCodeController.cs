using ERPWebApplication.AppClass.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class UserSecurityCodeController : DataAccessBase
    {
        internal void LoadUserForSecurityCode(CompanySetup objCompanySetup, GridView GridViewUsers)
        {
            try
            {
                DataTable dtUser = GetUserForSecurityCode(objCompanySetup);
                GridViewUsers.DataSource = null;
                GridViewUsers.DataBind();
                if (dtUser.Rows.Count > 0)
                {
                    GridViewUsers.DataSource = dtUser;
                    GridViewUsers.DataBind();

                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private DataTable GetUserForSecurityCode(CompanySetup objCompanySetup)
        {
            try
            {
                DataTable dtUser = null;
                string sqlString = @"SELECT A.EmployeeID,A.FullName,A.EntryDate,NULL AS DateOfCode FROM [hrEmployeeSetup] A WHERE NOT EXISTS ( SELECT B.EmployeeID FROM UserSecurityCode B 
                WHERE A.CompanyID = B.CompanyID AND A.EmployeeID = B.EmployeeID ) AND A.UserPermission = 1 AND A.Email != '' AND A.CompanyID = " + objCompanySetup.CompanyID + "";
                sqlString += @" UNION
                SELECT A.EmployeeID,A.FullName,A.EntryDate AS EntryDate ,B.EntryDate AS DateOfCode FROM [hrEmployeeSetup] A 
                INNER JOIN UserSecurityCode B ON A.CompanyID = B.CompanyID AND A.EmployeeID = B.EmployeeID WHERE 
                B.SecurityCodeStatus = 0 AND B.DataUsed = 'A' AND A.CompanyID = " + objCompanySetup.CompanyID + "";
                sqlString += @" ORDER BY A.EntryDate";
                dtUser = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                return dtUser;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void SendSecurityCode(CompanySetup objCompanySetup, UserSecurityCode objUserSecurityCode, UserProfile objUserProfile)
        {
            try
            {
                Save(objCompanySetup, objUserSecurityCode);
                SendSecurityCodeByMail(objCompanySetup, objUserSecurityCode, objUserProfile);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        

        private void SendSecurityCodeByMail(CompanySetup objCompanySetup, UserSecurityCode objUserSecurityCode, UserProfile objUserProfile)
        {
            try
            {
                objUserSecurityCode.SecurityCode = GetSecurityCode(objUserSecurityCode);
                if (objUserSecurityCode.SecurityCode != 0)
                {
                    MailServiceSetup objMailServiceSetup = new MailServiceSetup();
                    objMailServiceSetup.MailBody = "Your security code is: " + objUserSecurityCode.SecurityCode + "";
                    objMailServiceSetup.EmailTo = objUserProfile.Email;
                    objMailServiceSetup.MailtypeID = "1";
                    ArrayList attachDocument = new ArrayList();
                    objMailServiceSetup.AttachItem = attachDocument;
                    MailServiceController objMailServiceController = new MailServiceController();
                    objMailServiceController.eMailSendService(objCompanySetup, objMailServiceSetup);

                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private int GetSecurityCode(UserSecurityCode objUserSecurityCode)
        {
            try
            {
                string sql = "SELECT [SecurityCode] FROM [UserSecurityCode] WHERE DataUsed = 'A' AND SecurityCodeStatus = 0 AND UserProfileID = '" + objUserSecurityCode.UserKnownID + "'";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                objUserSecurityCode.SecurityCode = objclsDataManipulation.GetSingleValue(this.ConnectionString, sql);
                return objUserSecurityCode.SecurityCode;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void Save(CompanySetup objCompanySetup, UserSecurityCode objUserSecurityCode)
        {
            try
            {
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                objUserSecurityCode.SecurityCode = Convert.ToInt32( objclsDataManipulation.GetAnUniqueidentifierSecurityCode(this.ConnectionString));
                var storedProcedureComandText = "exec [spInitiateSecurityCode] " +
                                         "'" + objUserSecurityCode.UserKnownID + "','" +
                                        objCompanySetup.EntryUserName + "',"+
                                        objUserSecurityCode.SecurityCode + "" ;
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadUserForSecurityCode(GridView GridViewUsers)
        {
            try
            {
                DataTable dtUser = GetUserForSecurityCode();
                GridViewUsers.DataSource = null;
                GridViewUsers.DataBind();
                if (dtUser.Rows.Count > 0)
                {
                    GridViewUsers.DataSource = dtUser;
                    GridViewUsers.DataBind();

                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private DataTable GetUserForSecurityCode()
        {
            try
            {
                DataTable dtUser = null;
                string sqlString = @"SELECT A.UserProfileID, (A.FirstName +' '+ A.MiddleName+' ' +A.LastName) AS FullName,A.Email, A.EntryDate, NULL AS DateOfCode 
                FROM [uUserProfile] A WHERE NOT EXISTS ( SELECT B.UserProfileID FROM UserSecurityCode B WHERE B.UserProfileID = A.UserProfileID  )
                AND A.DataUsed = 'A' AND A.SecurityCode IS NULL OR A.SecurityCode = ''
                 UNION
                 SELECT A.UserProfileID, (A.FirstName +' '+ A.MiddleName+' ' +A.LastName) AS FullName,A.Email, A.EntryDate, B.EntryDate AS DateOfCode 
                 FROM [uUserProfile] A  INNER JOIN UserSecurityCode B ON A.UserProfileID = B.UserProfileID WHERE A.DataUsed = 'A' AND B.DataUsed = 'A' AND A.SecurityCode 
                 IS NULL OR A.SecurityCode = '' AND B.SecurityCodeStatus = 0 ";
                sqlString += @" ORDER BY A.EntryDate";
                dtUser = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                return dtUser;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}