﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.Model;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class ServiceManagementController : DataAccessBase
    {
        internal void ImportDeveloperData()
        {
            try
            {
                var storedProcedureComandText = @"
                INSERT INTO sysProductOwnerNodeList
                  ([CompanyID],[BranchID],[ActivityID],[ActivityName],[SeqNo],[NodeTypeID],[PNodeTypeID],[FormDescription]
                  ,[FormName],[ShowPosition],[DataUsed],[EntryUserID],[EntryDate],[LastUpdateDate],[LastUpdateUserID])
                SELECT t1.[CompanyID],t1.[BranchID],t1.[ActivityID],t1.[ActivityName],t1.[SeqNo],t1.[NodeTypeID],t1.[PNodeTypeID],
                  t1.[FormDescription],t1.[FormName],t1.[ShowPosition],t1.[DataUsed],t1.[EntryUserID],t1.[EntryDate],t1.[LastUpdateDate],t1.[LastUpdateUserID]
                  FROM suDefaultNodeList t1
                  WHERE NOT EXISTS(SELECT [NodeTypeID]
                  FROM sysProductOwnerNodeList t2
                  WHERE t2.[NodeTypeID] = t1.[NodeTypeID])";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void PopulateRootLevel(TreeView objTreeView)
        {
            try
            {
                objTreeView.Nodes.Clear();
                objTreeView.ExpandAll();
                var sqlString = @"SELECT 111 as NodeTypeID,'Node List' as ActivityName,childnodecount = 
                                    (SELECT Count(*) FROM sysProductOwnerNodeList  
                                    WHERE PNodeTypeID = 111)";
                var dt = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                PopulateNodes(dt, objTreeView.Nodes);

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
                    var tn = new TreeNode(dr["ActivityName"].ToString(), dr["NodeTypeID"].ToString());
                    nodes.Add(tn);
                    tn.PopulateOnDemand = (int.Parse(dr["childnodecount"].ToString()) > 0);
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void PopulateSubLevelOwner(int parentid, TreeNode parentNode)
        {
            try
            {
                var sqlString = @"select NodeTypeID,ActivityName,(select count(*) FROM sysProductOwnerNodeList WHERE PNodeTypeID=e.NodeTypeID) childnodecount FROM sysProductOwnerNodeList e where PNodeTypeID= " + parentid + "";
                var dt = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                PopulateNodes(dt, parentNode.ChildNodes);
                parentNode.CollapseAll();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetNodeDetails(NodeList objNodeList)
        {
            try
            {
                DataTable dtNodeValue = null;
                var storedProcedureComandText = @"SELECT [ActivityID]
                                                  ,[ActivityName]            
                                                  ,[FormDescription]
                                                  ,[FormName]
                                                  ,[ShowPosition]  
                                              FROM [sysProductOwnerNodeList] WHERE [NodeTypeID] = " + objNodeList.NodeTypeID + " ";
                dtNodeValue = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtNodeValue;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void Update(NodeList objNodeList)
        {
            try
            {
                var storedProcedureComandText = "UPDATE [sysProductOwnerNodeList] " +
                                               " SET " +
                                                 " [ActivityName] = ISNULL('" + objNodeList.ActivityName + "',ActivityName) " +
                                                 " ,[FormDescription] = ISNULL('" + objNodeList.FormDescription + "',FormDescription) " +
                                                 " ,[LastUpdateDate] = CAST(GETDATE() AS DateTime) " +
                                                 " ,[LastUpdateUserID] = '" + objNodeList.EntryUserName + "' " +
                                                 " WHERE [NodeTypeID] = " + objNodeList.NodeTypeID + "";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }


        TwoColumnsTableDataAutoController _objTwoColumnsTableDataAutoController;
        internal void LoadBillingFrequency(DropDownList ddlBillingFrequency)
        {
            try
            {
                _objTwoColumnsTableDataAutoController = new TwoColumnsTableDataAutoController();
                _objTwoColumnsTableDataAutoController.LoadBillingFrequency(ddlBillingFrequency);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadPaymentType(DropDownList ddlPaymentType)
        {
            try
            {
                _objTwoColumnsTableDataAutoController = new TwoColumnsTableDataAutoController();
                _objTwoColumnsTableDataAutoController.LoadPaymentType(ddlPaymentType);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadVATCalculationProcess(DropDownList ddlVATCalculation)
        {
            try
            {
                _objTwoColumnsTableDataAutoController = new TwoColumnsTableDataAutoController();
                _objTwoColumnsTableDataAutoController.LoadVATCalculationProcess(ddlVATCalculation);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        TwoColumnsTableDataController _objTwoColumnsTableDataController;
        internal void LoadServiceCategoryType(DropDownList ddlServiceCategory, TwoColumnsTableData objTwoColumnsTableData)
        {
            try
            {
                _objTwoColumnsTableDataController = new TwoColumnsTableDataController();
                _objTwoColumnsTableDataController.LoadServiceCategoryType(ddlServiceCategory, objTwoColumnsTableData);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void SaveServiceData(ServiceManagement objServiceManagement)
        {
            try
            {
                bool serviceName = true;
                serviceName = CheckServiceName(objServiceManagement);
                if (serviceName == false)
                {
                    throw new Exception("Service Name : " + objServiceManagement.ServiceName + " " + clsMessages.GExist);
                }

                objServiceManagement.ServiceID = GetServiceID();
                objServiceManagement.ServiceValueID = GetServiceValueID(objServiceManagement);
                var storedProcedureComandText = SqlSaveServiceData(objServiceManagement);
                storedProcedureComandText += SqlSaveServicePricing(objServiceManagement);
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private bool CheckServiceName(ServiceManagement objServiceManagement)
        {
            try
            {
                bool checkData = true;
                string sql = "SELECT COUNT(ServiceID) FROM sysServiceSetup WHERE ServiceName = '" + objServiceManagement.ServiceName + "'";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                int tableDataCount = objclsDataManipulation.GetSingleValue(this.ConnectionString, sql);
                if (tableDataCount != 0)
                {
                    checkData = false;
                }

                return checkData;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private bool CheckServiceNameUpdate(ServiceManagement objServiceManagement)
        {
            try
            {
                bool checkData = true;
                string sql = "";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                string tableDataValue;
                tableDataValue = objclsDataManipulation.GetSingleValueAsString(this.ConnectionString, sql);
                if (tableDataValue != null && tableDataValue != objServiceManagement.ServiceID.ToString())
                {
                    checkData = false;
                }

                return checkData;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private int GetServiceValueID(ServiceManagement objServiceManagement)
        {
            try
            {
                int serviceValueNo = 0;
                var storedProcedureComandText = "SELECT ISNULL( COUNT( ServiceValueID),0)+1 as ServiceValueID FROM [sysServicePricing] WHERE ServiceID = " + objServiceManagement.ServiceID + "";
                serviceValueNo = clsDataManipulation.GetMaximumValueUsingSQL(this.ConnectionString, storedProcedureComandText);
                return serviceValueNo;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private int GetServiceID()
        {
            try
            {
                int serviceNo = 0;
                var storedProcedureComandText = "SELECT ISNULL( COUNT( ServiceID),0)+1 as ServiceID FROM [sysServiceSetup]";
                serviceNo = clsDataManipulation.GetMaximumValueUsingSQL(this.ConnectionString, storedProcedureComandText);
                return serviceNo;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private static string SqlSaveServiceData(ServiceManagement objServiceManagement)
        {
            try
            {
                var storedProcedureComandText = @"
            INSERT INTO [sysServiceSetup]
           ([ServiceID]
           ,[ServiceName]
           ,[ServiceDescription]
           ,[ServiceValueID]
           ,[BillingFrequencyType]
           ,[PaymentType]
           ,[DataUsed]
           ,[EntryUserID]
           ,[EntryDate])
            VALUES
           (" + objServiceManagement.ServiceID + ""
             + ",'" + objServiceManagement.ServiceName + "'"
             + ",'" + objServiceManagement.ServiceDescription + "'"
             + "," + objServiceManagement.ServiceValueID + ""
             + "," + objServiceManagement.BillingFrequencyType + ""
             + "," + objServiceManagement.PaymentType + ""
             + ",'" + "A" + "'"
             + ",'" + objServiceManagement.EntryUserName + "'"
              + "," + "CAST(GETDATE() AS DateTime)" + ""
            + ");";
                return storedProcedureComandText;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private static string SqlUpdateServiceData(ServiceManagement objServiceManagement)
        {
            try
            {
                var storedProcedureComandText = @"
            UPDATE [sysServiceSetup]
               SET 
                  [ServiceName] = '" + objServiceManagement.ServiceName + "'" +
                  " ,[ServiceDescription] = '" + objServiceManagement.ServiceDescription + "'" +
                  " ,[ServiceValueID] = " + objServiceManagement.ServiceValueID + "" +
                  " ,[BillingFrequencyType] = " + objServiceManagement.BillingFrequencyType + "" +
                  " ,[PaymentType] = " + objServiceManagement.PaymentType + "" +
                  " ,[LastUpdateUserID] = '" + objServiceManagement.EntryUserName + "'" +
                  " ,[LastUpdateDate] = " + "CAST(GETDATE() AS DateTime)" + "" +
                  " WHERE [DataUsed] = 'A' AND [ServiceID] = " + objServiceManagement.ServiceID + " ;";
                return storedProcedureComandText;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private static string SqlSaveServicePricing(ServiceManagement objServiceManagement)
        {
            try
            {
                var storedProcedureComandText = @"
            INSERT INTO [sysServicePricing]
           ([ServiceID]
           ,[ServiceValueID]
           ,[ServiceValueStartDate]
           ,[ServiceValue]
           ,[VATRate]
           ,[VATCalculationProcess]
           ,[DataUsed]
           ,[EntryUserID]
           ,[EntryDate])
            VALUES
           (" + objServiceManagement.ServiceID + ""
              + "," + objServiceManagement.ServiceValueID + ""
             + ",'" + objServiceManagement.ServiceValueStartDate + "'"
             + "," + objServiceManagement.ServiceValue + ""
             + "," + objServiceManagement.VatRate + ""
             + "," + objServiceManagement.VatCalculationProcessID + ""
             + ",'" + "A" + "'"
             + ",'" + objServiceManagement.EntryUserName + "'"
              + "," + "CAST(GETDATE() AS DateTime)" + ""
            + ");";
                return storedProcedureComandText;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetServices()
        {
            try
            {
                DataTable dtServiceRecord = null;
                var storedProcedureComandText = @"SELECT A.ServiceID,B.ServiceValueID,A.ServiceName,A.ServiceDescription,A.BillingFrequencyType,A.PaymentType
                ,B.ServiceValue,B.VATCalculationProcess
                ,C.FieldOfName AS VATCalculationProcessText
                ,D.FieldOfName AS PaymentTypeText
                ,E.FieldOfName AS BillingFrequencyTypeText
                 FROM sysServiceSetup A
                INNER JOIN sysServicePricing B ON A.ServiceID = B.ServiceID AND A.ServiceValueID = B.ServiceValueID
                LEFT JOIN VATCalculationProcess C ON B.VATCalculationProcess = C.FieldOfID
                LEFT JOIN PaymentType D ON A.PaymentType = D.FieldOfID
                LEFT JOIN BillingFrequency E ON A.BillingFrequencyType = E.FieldOfID
                WHERE A.DataUsed = 'A' AND B.DataUsed = 'A' ORDER BY A.ServiceName";
                dtServiceRecord = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtServiceRecord;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void DeleteService(ServiceManagement objServiceManagement)
        {
            try
            {
                string sqlString = @"UPDATE sysServiceSetup SET DataUsed	= 'I' WHERE ServiceID = " + objServiceManagement.ServiceID + " AND ServiceValueID = " + objServiceManagement.ServiceValueID + ";" +
                " UPDATE sysServicePricing SET DataUsed	= 'I' WHERE ServiceID = " + objServiceManagement.ServiceID + " AND ServiceValueID = " + objServiceManagement.ServiceValueID + "";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, sqlString);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void UpdateServiceData(ServiceManagement objServiceManagement)
        {
            try
            {
                //bool serviceName = true;
                //serviceName = CheckServiceName(objServiceManagement);
                //if (serviceName == false)
                //{
                //    throw new Exception("Service Name : " + objServiceManagement.ServiceName + " " + clsMessages.GExist);
                //}

                var storedProcedureComandTextUpdate = SqlUpdateServicePricing(objServiceManagement);
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTextUpdate);
                objServiceManagement.ServiceValueID = GetServiceValueID(objServiceManagement);
                var storedProcedureComandText = SqlUpdateServiceData(objServiceManagement);
                storedProcedureComandText += SqlSaveServicePricing(objServiceManagement);
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlUpdateServicePricing(ServiceManagement objServiceManagement)
        {
            try
            {
                string sqlString = @" UPDATE sysServicePricing SET DataUsed	= 'I' WHERE ServiceID = " + objServiceManagement.ServiceID + " AND ServiceValueID = " + objServiceManagement.ServiceValueID + "";
                return sqlString;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}