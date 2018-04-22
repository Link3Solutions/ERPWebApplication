using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class ProcessFlowController : DataAccessBase
    {
        #region ProcessFlowInitiate
        public void UseProcessFlow(List<ProcessFlow> objListProcessFlow)
        {
            try
            {
                foreach (ProcessFlow objProcessFlow in objListProcessFlow)
                {
                    var storedProcedureComandTest = "exec [spProcessInitiate] " +
                                        objProcessFlow.CompanyID + "," +
                                        objProcessFlow.BranchID + ",'" +
                                        objProcessFlow.ApplicantID + "','" +
                                        objProcessFlow.ProcessId + "','" +
                                        objProcessFlow.FlowId + "'," +
                                        objProcessFlow.LevelId + ",'" +
                                        objProcessFlow.RemarksProcess + "','" +
                                        objProcessFlow.EntryUserName + "'," +
                                        objProcessFlow.ActionTypeId + "," +
                                        objProcessFlow.LineNo + ",'" +
                                        objProcessFlow.TransactionNo + "','" +
                                        objProcessFlow.ResponsiblePersonID + "'";
                    clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTest);

                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        #endregion ProcessFlowInitiate
        #region GetAllPendingProcess
        public DataTable GetPendingProcess(ProcessFlow objProcessFlow)
        {
            try
            {
                DataTable dtPendingProcess = null;
                var storedProcedureComandText = @"exec [spProcessGetAllPendingApplication] " +
                            objProcessFlow.CompanyID + "," +
                            objProcessFlow.BranchID + ",'" +
                            objProcessFlow.ApplicantID + "'";
                dtPendingProcess = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtPendingProcess;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        #endregion GetAllPendingProcess
        #region ShowFlowSequence
        internal DataTable GetApprovalFlowSequence(ProcessFlow objProcessFlow)
        {
            try
            {
                DataTable dtFlowSequence = null;
                var storedProcedureComandText = @"select a.ProcessId,a.ProcessFlowId,a.ProcessLevelid,b.EmployeeID,B.FullName from ProcessAccessPermission a " +
                  " inner join hrEmployeeSetup b on A.CompanyID = B.CompanyID AND a.AccessId=b.EmployeeID where A.CompanyID = " + objProcessFlow.CompanyID + " AND " + " a.ApplicantID='" + objProcessFlow.ApplicantID + "' " +
                  " and  a.ProcessId='" + objProcessFlow.ProcessId + "' and a.ProcessFlowId='" + objProcessFlow.FlowId + "'" +
                  " order by a.ProcessLevelid";
                dtFlowSequence = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtFlowSequence;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        #endregion ShowFlowSequence
        public string GetTransactionNoProcess()
        {
            try
            {
                string transactionNo = null;
                string sql = " exec [spProcessGetTransactionNo] ; ";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                return transactionNo = objclsDataManipulation.GetSingleValueAsString(this.ConnectionString, sql);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetPendingApplicationCount(ProcessDetails objProcessDetails)
        {
            try
            {
                DataTable dtPendingProcessCount = null;
                var storedProcedureComandText = @"exec [spProcessGetPendingApplicationCount] " +
                            objProcessDetails.CompanyID + "," +
                            objProcessDetails.BranchID + ",'" +
                            objProcessDetails.AccessId + "','" +                            
                            objProcessDetails.ProcessId + "'";
                dtPendingProcessCount = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtPendingProcessCount;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GettblInboxData()
        {
            try
            {
                DataTable dtDatatblInbox = null;
                var storedProcedureComandText = @" select * from [tblInbox] where TaskType='TaskPending' and Status=1 order by ID";
                dtDatatblInbox = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtDatatblInbox;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}