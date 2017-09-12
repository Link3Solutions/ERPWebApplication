using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CoaHeadController
/// </summary>

namespace ERPWebApplication.AppClass.DataAccess
{
    public class CoaHeadController : DataAccessBase
    {
        public CoaHeadController()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable GetSubLedgerInformation(string connectionString, string subledgerHeadName)
        {
            try
            {
                string sql = "SELECT SubLedgerTypeID,SubLedgerID FROM AccCOASubHeadSetup WHERE SubledgerHeadName = '" + subledgerHeadName + "'";
                return clsDataManipulation.GetData(connectionString, sql);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        public DataTable GetSubLedgerInformationForType(string connectionString, string subledgerHeadName)
        {
            try
            {
                string sql = @"SELECT A.SubLedgerTypeID,A.SubLedgerID FROM AccCOASubHeadSetup A
                                INNER JOIN [AccCOASubLedgerTypeSetup] B ON A.SubLedgerTypeID = B.SubledgerTypeID
                                WHERE B.SubLedgerTypeName = '" + subledgerHeadName + "'";
                return clsDataManipulation.GetData(connectionString, sql);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        public void Save(string connectionString, CoaHead objCoaHead)
        {
            try
            {
                var myConnection = new SqlConnection(connectionString);
                var myCommand = myConnection.CreateCommand();
                myConnection.Open();
                myCommand.CommandText = "exec [ACT_accCOAHeadSetup] " +
                                        +objCoaHead.AccountNo + "," +
                                        +objCoaHead.ParentAccNo + "," +
                                        +objCoaHead.AccountTypeId + "," +
                                        "'" + objCoaHead.AccountName + "'," +
                                        +objCoaHead.SeqNo + "," +
                                        +objCoaHead.TierNo + "," +
                                        "'" + objCoaHead.AccountDescription + "'," +
                                        +objCoaHead.SerialNo + "," +
                                        +objCoaHead.CompanyID + "," +
                                        +objCoaHead.BranchID + "," +
                                        +objCoaHead.IsBudgetRelated + ",'" +
                                        objCoaHead.AnalysisRequired + "'," +
                                        "'" + objCoaHead.EntryUserId + "'";
                myCommand.CommandTimeout = 600;
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                if (objCoaHead.AnalysisRequired == "Y")
                {
                    foreach (DataRow rowNo in objCoaHead.DtSubledgerInformation.Rows)
                    {
                        objCoaHead.SubledgerTypeID = rowNo.ItemArray[0].ToString();
                        objCoaHead.SubLedgerID = rowNo.ItemArray[1].ToString();
                        var storedProcedureComandTest = "exec [ACT_accAccNoWiseSubHeadSetup] " +
                                            objCoaHead.CompanyID + "," +
                                            objCoaHead.BranchID + "," +
                                            objCoaHead.AccountNo + ",'" +
                                            objCoaHead.SubledgerTypeID + "','" +
                                            objCoaHead.SubLedgerID + "','" +
                                            objCoaHead.EntryUserId + "'";
                        clsDataManipulation.StoredProcedureExecuteNonQuery(connectionString, storedProcedureComandTest);

                    }


                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void Update(string connectionString, CoaHead objCoaHead)
        {
            try
            {
                var myConnection = new SqlConnection(connectionString);
                var myCommand = myConnection.CreateCommand();
                myConnection.Open();
                myCommand.CommandText = "exec [Update_accCOAHeadSetup] " +
                                        +objCoaHead.AccountNo + "," +
                                        +objCoaHead.AccountTypeId + "," +
                                        "'" + objCoaHead.AccountName + "'," +
                                        "'" + objCoaHead.AccountDescription + "'," +
                                        +objCoaHead.CompanyID + "," +
                                        +objCoaHead.BranchID + "," +
                                        +objCoaHead.IsBudgetRelated + ",'" +
                                        objCoaHead.AnalysisRequired + "'," +
                                        "'" + objCoaHead.EntryUserId + "'";
                myCommand.CommandTimeout = 600;
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                if (objCoaHead.AnalysisRequired == "Y")
                {
                    foreach (DataRow rowNo in objCoaHead.DtSubledgerInformation.Rows)
                    {
                        objCoaHead.SubledgerTypeID = rowNo.ItemArray[0].ToString();
                        objCoaHead.SubLedgerID = rowNo.ItemArray[1].ToString();
                        var storedProcedureComandTest = "exec [Update_accAccNoWiseSubHeadSetup] " +
                                            objCoaHead.CompanyID + "," +
                                            objCoaHead.BranchID + "," +
                                            objCoaHead.AccountNo + ",'" +
                                            objCoaHead.SubledgerTypeID + "','" +
                                            objCoaHead.SubLedgerID + "','" +
                                            objCoaHead.EntryUserId + "'";
                        clsDataManipulation.StoredProcedureExecuteNonQuery(connectionString, storedProcedureComandTest);

                    }


                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal string CheckAnalysisrequired(CoaHead objCoaHead)
        {
            try
            {
                string analysisrequiredData = null;
                string sql = @"SELECT AnalysisRequired FROM accCOAHeadSetup WHERE AccountNo = " + objCoaHead.AccountNo + "";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                analysisrequiredData = objclsDataManipulation.GetSingleValueAsString(this.ConnectionString, sql);
                return analysisrequiredData;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}