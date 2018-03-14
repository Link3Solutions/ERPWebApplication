using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class ProcessDetailsController : DataAccessBase
    {
        internal void SaveProcessDescription(ProcessDetails objProcessDetails)
        {
            try
            {
                var storedProcedureComandTest = "exec [spProcessInsertProcessDescription] '" +
                                        objProcessDetails.ProcessId + "','" +
                                        objProcessDetails.ProcessDescription + "','" +
                                        objProcessDetails.ProcessStatus + "','" +
                                        "INSERT" + "'," +
                                        objProcessDetails.CompanyID + ",'" +
                                        objProcessDetails.EntryUserName + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTest);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }



        internal void LoadProcessDDL(DropDownList ddlProcess, ProcessDetails objProcessDetails)
        {
            try
            {
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, this.SqlGetProcess(objProcessDetails), ddlProcess, "ProcessDescription", "ProcessId");
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlGetProcess(ProcessDetails objProcessDetails)
        {
            try
            {
                string sqlString = null;
                sqlString = @"SELECT [ProcessId]
                              ,[ProcessDescription]      
                          FROM [ProcessDescription] WHERE [Status] = 'A' AND CompanyID = " + objProcessDetails.CompanyID + "  ORDER BY [ProcessDescription]";
                return sqlString;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }



        internal void SaveFlowDescription(ProcessDetails objProcessDetails)
        {
            try
            {
                if (objProcessDetails.FlowId == null)
                {
                    objProcessDetails.FlowId = 0;
                }

                var storedProcedureComandTest = "exec [spProcessInsertProcessFlowDefinition] '" +
                                        objProcessDetails.ProcessId + "'," +
                                        objProcessDetails.CategoryId + "," +
                                        objProcessDetails.FlowId + ",'" +
                                        objProcessDetails.FlowDescription + "','" +
                                        "INSERT" + "'," +
                                        objProcessDetails.CompanyID + ",'" +
                                        objProcessDetails.EntryUserName + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTest);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void SaveLevelDescription(ProcessDetails objProcessDetails)
        {
            try
            {
                var storedProcedureComandTest = "exec [spProcessInsertProcessLevelDescription] '" +
                                        objProcessDetails.ProcessId + "','" +
                                        objProcessDetails.LevelDescription + "'," +
                                        objProcessDetails.LevelId + ",'" +
                                        "INSERT" + "'," +
                                        objProcessDetails.CompanyID + ",'" +
                                        objProcessDetails.EntryUserName + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTest);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void SaveActionType(ProcessDetails objProcessDetails)
        {
            try
            {
                var storedProcedureComandTest = "exec [spProcessInsertProcessActionType] '" +
                                        objProcessDetails.ProcessId + "','" +
                                        objProcessDetails.ActionType + "'," +
                                        objProcessDetails.ActionTypeId + ",'" +
                                        "INSERT" + "'," +
                                        objProcessDetails.CompanyID + ",'" +
                                        objProcessDetails.EntryUserName + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTest);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadFlowDefinitionDDL(DropDownList ddlFlow, ProcessDetails objProcessDetails)
        {
            try
            {
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, this.SqlGetFlow(objProcessDetails), ddlFlow, "FlowDescription", "ProcessFlowId");
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlGetFlow(ProcessDetails objProcessDetails)
        {
            try
            {
                string sqlString = null;
                sqlString = @"SELECT [ProcessFlowId]
                              ,[FlowDescription]      
                          FROM [ProcessFlowDefinition] WHERE CompanyID = " + objProcessDetails.CompanyID + " AND ProcessId = '" + objProcessDetails.ProcessId + "'  ORDER BY [FlowDescription]";
                return sqlString;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadLevelDescriptionDDL(DropDownList ddlLevel, ProcessDetails objProcessDetails)
        {
            try
            {
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, this.SqlGetLevel(objProcessDetails), ddlLevel, "LevelDescription", "ProcessLevelId");
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlGetLevel(ProcessDetails objProcessDetails)
        {
            try
            {
                string sqlString = null;
                sqlString = @"SELECT [ProcessLevelId]
                              ,[LevelDescription]      
                          FROM [ProcessLevelDescription] WHERE CompanyID = " + objProcessDetails.CompanyID + " AND ProcessId = '" + objProcessDetails.ProcessId + "'  ORDER BY [LevelDescription]";
                return sqlString;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadActionTypeCLB(CheckBoxList CheckListBoxAccessPermission, ProcessDetails objProcessDetails)
        {
            try
            {
                ClsDropDownListController.LoadCheckBoxListExceptConcatenation(this.ConnectionString, this.SqlGetActionType(objProcessDetails), CheckListBoxAccessPermission, "Action", "ActionTypeId");
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlGetActionType(ProcessDetails objProcessDetails)
        {
            try
            {
                string sqlString = null;
                sqlString = @"SELECT [ActionTypeId]
                              ,[Action]      
                          FROM [ProcessActionType] WHERE CompanyID = " + objProcessDetails.CompanyID + " AND ProcessId = '" + objProcessDetails.ProcessId + "'  ORDER BY [Action]";
                return sqlString;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetEmployee(DepartmentSetup objDepartmentSetup)
        {
            try
            {
                EmployeeSetup objEmployeeSetup = new EmployeeSetup();
                EmployeeSetupController objEmployeeSetupController = new EmployeeSetupController();
                objEmployeeSetup.DtEmployee = objEmployeeSetupController.GetEmployee(objDepartmentSetup);
                return objEmployeeSetup.DtEmployee;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void SaveConfigurationData(ProcessDetails objProcessDetails, EmployeeSetup objEmployeeSetup, DepartmentSetup objDepartmentSetup)
        {
            try
            {
                string departmentIDTemp = null;
                if (objDepartmentSetup.DepartmentID != -1)
                {
                    departmentIDTemp = objDepartmentSetup.DepartmentID.ToString();
                }

                objProcessDetails.ReferenceNo = GetReferanceNo();
                var storedProcedureComandTest = "exec [spProcessInsertProcessHeaderConfigurationbyDepartment] '" +
                    objProcessDetails.ReferenceNo + "','" +
                    objProcessDetails.ProcessId + "'," +
                    objProcessDetails.FlowId + ",'" +
                    departmentIDTemp + "','" +
                    "S" + "','" +
                    objProcessDetails.TeamName + "'," +
                    objProcessDetails.CompanyID + ",'" +
                    objProcessDetails.EntryUserName + "','" +
                    objProcessDetails.EffectiveDate + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTest);
                foreach (DataRow rowNo in objProcessDetails.DtConfigurationData.Rows)
                {
                    int levelIdValue = Convert.ToInt32(rowNo["LevelIdValue"].ToString());
                    string accessId = rowNo["AccessId"].ToString();
                    string accessPermissionValue = rowNo["AccessPermissionValue"].ToString();
                    string subAccessId = rowNo["SubAccessId"].ToString();
                    string subAccessPermissionValue = rowNo["SubAccessPermissionValue"].ToString();

                    var storedProcedureConfiguration = "exec [spProcessInsertProcessDetailsConfigurationbyDepartment] '" +
                        objProcessDetails.ReferenceNo + "'," +
                        levelIdValue + ",'" +
                        accessId + "','" +
                        subAccessId + "','" +
                        accessPermissionValue + "','" +
                        subAccessPermissionValue + "'," +
                        objProcessDetails.CompanyID + ",'" +
                        objProcessDetails.EffectiveDate + "'";
                    clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureConfiguration);
                    foreach (DataRow rowNOEmployee in objEmployeeSetup.DtEmployee.Rows)
                    {
                        string employeeID = rowNOEmployee["employeeID"].ToString();
                        var storedProcedureConfigurationEmployee = "exec [spProcessInsertProcessFlowConfigurationbyEmployee] '" +
                            objProcessDetails.ReferenceNo + "','" +
                            employeeID + "'," +
                            levelIdValue + ",'" +
                            accessId + "','" +
                            subAccessId + "','" +
                            accessPermissionValue + "','" +
                            subAccessPermissionValue + "'," +
                            objProcessDetails.CompanyID + ",'" +
                            objProcessDetails.EffectiveDate + "'";
                        clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureConfigurationEmployee);
                    }
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string GetReferanceNo()
        {
            try
            {
                string referanceNo = null;
                var storedProcedureComandText = @" exec [spProcessGetReferenceNoFromProcessHeaderConfigurationbyDepartment] ";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                referanceNo = objclsDataManipulation.GetSingleValueAsString(this.ConnectionString, storedProcedureComandText);
                return referanceNo;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetConfigurationRecord(ProcessDetails objProcessDetails, DepartmentSetup objDepartmentSetup)
        {
            try
            {
                DataTable dtConfigurationRecord = null;
                var storedProcedureComandText = @"SELECT 
                  A.[ReferenceNo]
                  ,A.[ProcessId]
                  ,A.[ProcessFlowId]
                  ,A.[DepartmentId]
                  ,A.[ProcessName]     
                  ,B.ProcessDescription
                  ,D.EntityName
                  ,A.EffectiveDate  
              FROM [ProcessHeaderConfigurationbyDepartment] A
              INNER JOIN [ProcessDescription] B ON A.ProcessId = B.ProcessId
              LEFT JOIN [ProcessFlowDefinition] C ON A.ProcessFlowId = C.ProcessFlowId
              LEFT JOIN orgDepartment D ON A.DepartmentId = D.EntityID
              WHERE A.[DataUsed] = 'A' AND A.CompanyID = " + objProcessDetails.CompanyID + "";

                if (objProcessDetails.ProcessId != null)
                {
                    storedProcedureComandText += " AND A.[ProcessId] = '" + objProcessDetails.ProcessId + "'";
                }

                if (objProcessDetails.FlowId != null)
                {
                    storedProcedureComandText += " AND A.[ProcessFlowId] = " + objProcessDetails.FlowId + "";
                }

                if (objDepartmentSetup.DepartmentID != -1)
                {
                    storedProcedureComandText += " AND A.[DepartmentId] = " + objDepartmentSetup.DepartmentID + "";
                }

                storedProcedureComandText += " ORDER BY A.[ProcessName]";

                dtConfigurationRecord = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtConfigurationRecord;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void UpdateConfigurationData(ProcessDetails objProcessDetails, EmployeeSetup objEmployeeSetup, DepartmentSetup objDepartmentSetup)
        {
            try
            {
                string departmentIDTemp = null;
                if (objDepartmentSetup.DepartmentID != -1)
                {
                    departmentIDTemp = objDepartmentSetup.DepartmentID.ToString();
                }

                var storedProcedureComandTestUpdate = "exec [spProcessUpdateConfiguration] '" +
                    objProcessDetails.ReferenceNo + "'," +
                    objProcessDetails.CompanyID + ",'" +
                    objProcessDetails.EntryUserName + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTestUpdate);


                var storedProcedureComandTest = "exec [spProcessInsertProcessHeaderConfigurationbyDepartment] '" +
                    objProcessDetails.ReferenceNo + "','" +
                    objProcessDetails.ProcessId + "'," +
                    objProcessDetails.FlowId + ",'" +
                    departmentIDTemp + "','" +
                    "S" + "','" +
                    objProcessDetails.TeamName + "'," +
                    objProcessDetails.CompanyID + ",'" +
                    objProcessDetails.EntryUserName + "','" +
                    objProcessDetails.EffectiveDate + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTest);
                foreach (DataRow rowNo in objProcessDetails.DtConfigurationData.Rows)
                {
                    int levelIdValue = Convert.ToInt32(rowNo["LevelIdValue"].ToString());
                    string accessId = rowNo["AccessId"].ToString();
                    string accessPermissionValue = rowNo["AccessPermissionValue"].ToString();
                    string subAccessId = rowNo["SubAccessId"].ToString();
                    string subAccessPermissionValue = rowNo["SubAccessPermissionValue"].ToString();

                    var storedProcedureConfiguration = "exec [spProcessInsertProcessDetailsConfigurationbyDepartment] '" +
                        objProcessDetails.ReferenceNo + "'," +
                        levelIdValue + ",'" +
                        accessId + "','" +
                        subAccessId + "','" +
                        accessPermissionValue + "','" +
                        subAccessPermissionValue + "'," +
                        objProcessDetails.CompanyID + ",'" +
                        objProcessDetails.EffectiveDate + "'";
                    clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureConfiguration);
                    foreach (DataRow rowNOEmployee in objEmployeeSetup.DtEmployee.Rows)
                    {
                        string employeeID = rowNOEmployee["employeeID"].ToString();
                        var storedProcedureConfigurationEmployee = "exec [spProcessInsertProcessFlowConfigurationbyEmployee] '" +
                            objProcessDetails.ReferenceNo + "','" +
                            employeeID + "'," +
                            levelIdValue + ",'" +
                            accessId + "','" +
                            subAccessId + "','" +
                            accessPermissionValue + "','" +
                            subAccessPermissionValue + "'," +
                            objProcessDetails.CompanyID + ",'" +
                            objProcessDetails.EffectiveDate + "'";
                        clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureConfigurationEmployee);
                    }
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetAssignedEmployeePhase1(ProcessDetails objProcessDetails, EmployeeSetup objEmployeeSetup)
        {
            try
            {
                DataTable dtSubmittedJournal = null;
                var storedProcedureComandText = @"SELECT COUNT(*) AS ApplicantID FROM ProcessFlowConfigurationbyEmployee A inner join ProcessHeaderConfigurationbyDepartment B
            on A.ReferenceNo=B.ReferenceNo AND A.CompanyID = B.CompanyID WHERE A.DataUsed = 'A' AND B.DataUsed = 'A' AND A.CompanyID = " + objEmployeeSetup.CompanyID + " AND A.ApplicantID ='" + objEmployeeSetup.EmployeeID + "'" +
            " AND B.ProcessId='" + objProcessDetails.ProcessId + "'";
                if (objProcessDetails.FlowId != null)
                {
                    storedProcedureComandText += " AND B.ProcessFlowId='" + objProcessDetails.FlowId + "'";
                }

                dtSubmittedJournal = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtSubmittedJournal;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetAssignedEmployeePhase2(ProcessDetails objProcessDetails, EmployeeSetup objEmployeeSetup)
        {
            try
            {
                DataTable dtSubmittedJournal = null;
                var storedProcedureComandText = @"SELECT COUNT(*) AS ApplicantID FROM ProcessFlowConfigurationbyEmployee A WHERE A.DataUsed = 'A' " +
                    " AND A.CompanyID = " + objEmployeeSetup.CompanyID + " AND (A.ApplicantID = '" + objEmployeeSetup.EmployeeID + "') AND (A.ReferenceNo= '" + objProcessDetails.ReferenceNo + "')";
                dtSubmittedJournal = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtSubmittedJournal;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetConfigurationDetails(ProcessDetails objProcessDetails)
        {
            try
            {
                DataTable dtConfigurationDetails = null;
                var storedProcedureComandText = @"exec [spProcessGetDataFromProcessDetailsConfigurationbyDepartment] '" +
                            objProcessDetails.ReferenceNo + "'," +
                            objProcessDetails.CompanyID + "";
                dtConfigurationDetails = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtConfigurationDetails;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetProcessDescription(ProcessDetails objProcessDetails)
        {
            try
            {
                DataTable dtProcess = null;
                var storedProcedureComandText = @"SELECT A.ProcessId, A.ProcessDescription, A.[Status],
                CASE WHEN A.[Status] = 'A' THEN 'Active' 
                WHEN A.[Status] = 'I' THEN 'Inactive'
                END AS [StatusText]
                 FROM ProcessDescription A
                WHERE A.CompanyID = " + objProcessDetails.CompanyID + "";
                dtProcess = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtProcess;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetProcessFlow(ProcessDetails objProcessDetails)
        {
            try
            {
                DataTable dtProcessFlow = null;
                var storedProcedureComandText = @"SELECT A.[ProcessId],B.ProcessDescription,A.[CategoryId],
                CASE WHEN A.[CategoryId] = '1' THEN 'Staff' 
                WHEN A.[CategoryId] = '2' THEN 'Officer'
                WHEN A.[CategoryId] = '5' 
                THEN 'All' ELSE '-' END AS [CategoryIdText],
                A.[ProcessFlowId],A.[FlowDescription] 
                FROM [ProcessFlowDefinition] A
                 INNER JOIN [ProcessDescription] B ON 
                A.[ProcessId] = B.[ProcessId]
                WHERE A.CompanyID = " + objProcessDetails.CompanyID + "";
                dtProcessFlow = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtProcessFlow;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetProcessLevel(ProcessDetails objProcessDetails)
        {
            try
            {
                DataTable dtProcessLevel = null;
                var storedProcedureComandText = @"SELECT A.[ProcessId],B.ProcessDescription,A.[ProcessLevelId],
                A.[LevelDescription]
                FROM [ProcessLevelDescription] A
                INNER JOIN [ProcessDescription] B
                ON A.[ProcessId] = B.[ProcessId] WHERE A.CompanyID = " + objProcessDetails.CompanyID + "";
                dtProcessLevel = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtProcessLevel;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetProcessAction(ProcessDetails objProcessDetails)
        {
            try
            {
                DataTable dtProcessAction = null;
                var storedProcedureComandText = @"SELECT A.[ProcessId],B.ProcessDescription,A.[ActionTypeId],A.[Action]
                FROM [ProcessActionType] A
                INNER JOIN [ProcessDescription] B
                 ON A.[ProcessId] = B.[ProcessId]
                 WHERE A.CompanyID = " + objProcessDetails.CompanyID + "";
                dtProcessAction = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtProcessAction;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void DeleteProcess(ProcessDetails objProcessDetails)
        {
            try
            {
                var storedProcedureComandText = "DELETE FROM ProcessDescription WHERE CompanyID = " + objProcessDetails.CompanyID + " AND ProcessId = '" + objProcessDetails.ProcessId + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void DeleteProcessFlow(ProcessDetails objProcessDetails)
        {
            try
            {
                var storedProcedureComandText = @"DELETE FROM [ProcessFlowDefinition]
                WHERE CompanyID = " + objProcessDetails.CompanyID + " AND ProcessId = '" + objProcessDetails.ProcessId + "' AND ProcessFlowId = " + objProcessDetails.FlowId + "";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void DeleteProcessLevel(ProcessDetails objProcessDetails)
        {
            try
            {
                var storedProcedureComandText = @"DELETE FROM [ProcessLevelDescription]
                WHERE CompanyID = " + objProcessDetails.CompanyID + " AND ProcessId = '" + objProcessDetails.ProcessId + "' AND ProcessLevelId = " + objProcessDetails.LevelId + "";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void DeleteProcessAction(ProcessDetails objProcessDetails)
        {
            try
            {
                var storedProcedureComandText = @"DELETE FROM [ProcessActionType]
                WHERE CompanyID = " + objProcessDetails.CompanyID + " AND ProcessId = '" + objProcessDetails.ProcessId + "' AND ActionTypeId = " + objProcessDetails.ActionTypeId + "";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}