using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.Model;
using System.Web.UI.WebControls;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class EmployeeSetupController : DataAccessBase
    {
        public void Save(EmployeeDetailsSetup objEmployeeDetailsSetup, EmployeeTypeSetup objEmployeeTypeSetup,
            EmployeeCategorySetup objEmployeeCategorySetup, DesignationSetup objDesignationSetup, IsUser objIsUser)
        {
            try
            {
                var storedProcedureComandText = "INSERT INTO [hrEmployeeSetup] ([CompanyID],[BranchID],[EmployeeID],[EmployeeTypeID], " +
                    " [EmployeeCategoryID] ,[Title],[FirstName],[MiddleName],[LastName],[Email],[UserPermission] ,[DataUsed],[EntryUserID],[EntryDate]) VALUES ( " +
                    objEmployeeDetailsSetup.CompanyID + "," +
                    objEmployeeDetailsSetup.BranchID + ", '" +
                    objEmployeeDetailsSetup.EmployeeID + "', " +
                    objEmployeeTypeSetup.EmployeeTypeID + ", " +
                    objEmployeeCategorySetup.EmployeeCategoryID + ", '" +
                    objDesignationSetup.DesignationID + "', '" +
                    objEmployeeDetailsSetup.FirstName + "', '" +
                    objEmployeeDetailsSetup.MiddleName + "', '" +
                    objEmployeeDetailsSetup.LastName + "', '" +
                    objEmployeeDetailsSetup.Email + "'," +
                    objIsUser.UserPermission + ",'" +
                    "A" + "', '" +
                    objEmployeeDetailsSetup.EntryUserName + "'," +
                    "CAST(GETDATE() AS DateTime));";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        internal void LoadCompanyDDL(DropDownList ddlCompany)
        {
            try
            {
                CompanySetupController objCompanySetupController = new CompanySetupController();
                objCompanySetupController.LoadCompany(ddlCompany);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }


        private OrganizationalChartSetupController _objOrganizationalChartSetupController;
        internal void LoadBranchDDL(DropDownList ddlBranch, CompanySetup objCompanySetup)
        {
            try
            {
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.LoadBranchDDL(ddlBranch, objCompanySetup);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        internal void LoadEmployeeType(DropDownList ddlEmployeeType)
        {
            throw new NotImplementedException();
        }

        internal void LoadEmployeeCategoryDDL(DropDownList ddlEmployeeCategory)
        {
            throw new NotImplementedException();
        }

        internal void LoadDesignationDDL(DropDownList ddlDesignation)
        {
            throw new NotImplementedException();
        }
    }
}