using ERPWebApplication.AppClass.Model;
using System;
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
                string sqlString = @"SELECT A.EmployeeID,A.FullName FROM [hrEmployeeSetup] A WHERE NOT EXISTS ( SELECT B.EmployeeID FROM UserSecurityCode B 
                WHERE A.CompanyID = B.CompanyID AND A.EmployeeID = B.EmployeeID ) AND A.UserPermission = 1 AND A.CompanyID = " + objCompanySetup.CompanyID + "";
                dtUser = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                return dtUser;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void SendSecurityCode(CompanySetup objCompanySetup, UserSecurityCode objUserSecurityCode)
        {
            try
            {
                Save(objCompanySetup,objUserSecurityCode);
                SendSecurityCodeByMail(objCompanySetup,objUserSecurityCode);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void SendSecurityCodeByMail(CompanySetup objCompanySetup, UserSecurityCode objUserSecurityCode)
        {
            try
            {
                objUserSecurityCode.SecurityCode = GetSecurityCode(objCompanySetup,objUserSecurityCode);
                if (objUserSecurityCode.SecurityCode != 0)
                {
                    
                }

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private int GetSecurityCode(CompanySetup objCompanySetup, UserSecurityCode objUserSecurityCode)
        {
            try
            {
                string sql = "";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                //sobjUserSecurityCode.objclsDataManipulation.GetSingleValue(this.ConnectionString, sql);
                return 0;

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
                var storedProcedureComandText = "exec [spInitiateSecurityCode] " +
                                        objCompanySetup.CompanyID + ",'" +
                                        objUserSecurityCode.UserKnownID+ "','"+
                                        objCompanySetup.EntryUserName+"'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}