﻿using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

                if (objOrganizationalChartSetup.OrgElementIDList.Count == 0)
                {
                    throw new Exception("please select elements correctly");
                    
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

        internal void LoadOrganizationalElements(OrganizationalChartSetup objOrganizationalChartSetup, ListBox listBoxOrganizationElements)
        {
            try
            {
                ClsListBoxController.LoadListBox(this.ConnectionString, SqlGetOrganizationalElements(objOrganizationalChartSetup),
                    listBoxOrganizationElements, "OrgElementName", "OrgElementID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlGetOrganizationalElements(OrganizationalChartSetup objOrganizationalChartSetup)
        {
            try
            {
                string sqlQuery = null;
                sqlQuery = @"SELECT A.[OrgElementID],B.OrgElementName      
                          FROM [orgOrganizationElements] A 
                          INNER JOIN orgStandardOrgElements B ON A.OrgElementID = B.OrgElementID
                          WHERE A.[DataUsed] = 'A' AND A.[CompanyID]= " + objOrganizationalChartSetup.CompanyID + " ORDER BY B.HierarchyID";
                return sqlQuery;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        internal void LoadOrganizationalElements(OrganizationalChartSetup objOrganizationalChartSetup, DropDownList dropDownListOrganizationElements)
        {
            try
            {
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, this.SqlGetOrganizationalElements(objOrganizationalChartSetup), dropDownListOrganizationElements,
                    "OrgElementName", "OrgElementID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void Update(OrganizationalChartSetup objOrganizationalChartSetup)
        {
            try
            {
                var storedProcedureComandTextUpdate = @"UPDATE [orgOrganizationElements] SET [DataUsed] = 'I' WHERE [CompanyID] = " + objOrganizationalChartSetup.CompanyID + "";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTextUpdate);

                foreach (var listItem in objOrganizationalChartSetup.OrgElementIDList)
                {
                    var storedProcedureComandText = "INSERT INTO [orgOrganizationElements] ([CompanyID],[OrgElementID],[DataUsed],[EntryUserID],[LastUpdateUserID],[LastUpdateDate]) VALUES ( " +
                                                 objOrganizationalChartSetup.CompanyID + "," +
                                                 listItem.ToString() + ",'" +
                                                 "A" + "', '" +
                                                 "160ea939-7633-46a8-ae49-f661d12abfd5" + "','" +
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

        internal void PopulateRootLevel(TreeView TreeViewCompanyChart)
        {
            try
            {
                TreeViewCompanyChart.Nodes.Clear();
                TreeViewCompanyChart.ExpandAll();
                var myConnection = new SqlConnection(this.ConnectionString);
                var sqlString = @" SELECT 111 as EntityID,'Organizational Chart' as EntityName,childnodecount = 
                                    (SELECT Count(*) FROM orgOrganizationalChartSetup  
                                    WHERE ParentEntityID = 111)";
                var dt = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                PopulateNodes(dt, TreeViewCompanyChart.Nodes);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
        private void PopulateNodes(DataTable dt, TreeNodeCollection nodes)
        {
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var tn = new TreeNode(dr["EntityName"].ToString(), dr["EntityID"].ToString());
                    nodes.Add(tn);
                    tn.PopulateOnDemand = (int.Parse(dr["childnodecount"].ToString()) > 0);
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        public void PopulateSubLevel( int parentid, TreeNode parentNode)
        {
            try
            {
                var sqlString = @"select EntityID,EntityName,(select count(*) FROM orgOrganizationalChartSetup WHERE ParentEntityID=e.EntityID) childnodecount FROM orgOrganizationalChartSetup e where ParentEntityID= " + parentid + "";
                var dt = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                PopulateNodes(dt, parentNode.ChildNodes);
                parentNode.CollapseAll();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        
        internal void SaveChart(OrganizationalChartSetup objOrganizationalChartSetup, EmployeeSetup objEmployeeSetup, TwoColumnsTableData objTwoColumnsTableData)
        {
            try
            {
                var storedProcedureComandText = @"INSERT INTO [orgOrganizationalChartSetup] ([CompanyID],[ParentEntityID],[EntityID],[EntityTypeID]
                                               ,[AddressTag],[AddressID],[EntityName],[ShortName],[DisplayName],[GroupEmailAddress],[HeadID]
                                               ,[EntityCategoryID],[EntityOpeningDate],[DataUsed],[EntryUserID],[EntryDate]) VALUES ( " +
                                                 objOrganizationalChartSetup.CompanyID + "," +
                                                 objOrganizationalChartSetup.ParentEntityID + ",'" +
                                                 "A" + "', '" +
                                                 "160ea939-7633-46a8-ae49-f661d12abfd5" + "'," +
                                                 "CAST(GETDATE() AS DateTime));";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        public string GetEntityID()
        {
            try
            {
                string seqNo = null;
                var storedProcedureComandText = @" DECLARE @RefNumber VARCHAR(10),@countData INT
                                              SET @countData = ( SELECT ISNULL( MAX( [SeqNo]),0) +1  FROM [suDefaultNodeList])
                                              SET @RefNumber=STUFF('0000',5-LEN(@countData),20,@countData)
                                              SELECT @RefNumber";
                var dtSeq = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                foreach (DataRow item in dtSeq.Rows)
                {
                    seqNo = item.ItemArray[0].ToString();

                }
                return seqNo;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

    }
}