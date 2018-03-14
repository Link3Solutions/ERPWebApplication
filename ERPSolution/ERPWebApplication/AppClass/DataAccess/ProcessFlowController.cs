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
    }
}