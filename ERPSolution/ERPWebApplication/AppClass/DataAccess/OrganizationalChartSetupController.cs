using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class OrganizationalChartSetupController : DataAccessBase
    {
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

        internal void LoadStandardOrgElementsDDL(ListBox listBoxStandardOrgElements)
        {
            try
            {
                StandardOrgElementsController objStandardOrgElementsController = new StandardOrgElementsController();
                objStandardOrgElementsController.LoadStandardOrgElements(listBoxStandardOrgElements);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        internal void Save(OrganizationalChartSetup objOrganizationalChartSetup)
        {
            try
            {
                if (objOrganizationalChartSetup.CompanyID == -1)
                {
                    throw new Exception(" company name is required ");

                }

                foreach (var listItem in objOrganizationalChartSetup.OrgElementIDList)
                {
                    var storedProcedureComandText = "INSERT INTO [orgOrganizationElements] ([CompanyID],[OrgElementID],[DataUsed],[EntryUserID],[EntryDate]) VALUES ( " +
                                                 objOrganizationalChartSetup.CompanyID + "," +
                                                 listItem.ToString() + ",'" +
                                                 "A" + "', '" +
                                                 "160ea939-7633-46a8-ae49-f661d12abfd5" + "'," +
                                                 "CAST(GETDATE() AS DateTime));";
                    clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
                }
                

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}