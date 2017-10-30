using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.CommonClass;
using System.Web.UI.WebControls;
using System.Data;
using ERPWebApplication.AppClass.Model;


namespace ERPWebApplication.AppClass.DataAccess
{
    public class JournalVoucherController : DataAccessBase
    {
        internal void LoadJournalTypeDDL(DropDownList ddlJournalType)
        {
            try
            {
                string sqlString = @"SELECT JournalTypeID,JournalTypeName FROM accJournalTypeSetup ORDER  BY JournalTypeName";
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, sqlString, ddlJournalType, "JournalTypeName", "JournalTypeID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadTransactionTypeDDL(DropDownList ddlTransactionType)
        {
            try
            {
                string sqlString = @"SELECT TransactionTypeID,TransactionType FROM dsTransactionType WHERE DataUsed = 'A' ORDER BY TransactionType";
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, sqlString, ddlTransactionType, "TransactionType", "TransactionTypeID");
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadVoucherTypeDDL(DropDownList ddlVoucherType)
        {
            try
            {
                string sqlString = @"SELECT VoucherTypeID,VoucherType FROM dsVoucherTypeSetup ORDER BY VoucherType";
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, sqlString, ddlVoucherType, "VoucherType", "VoucherTypeID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetAssignedSubLedgerType(CoaHead objCoaHead)
        {
            try
            {
                DataTable dtAssignedSubLedgerType = null;
                var storedProcedureComandText = "SELECT DISTINCT A.[SubledgerTypeID] FROM accAccNoWiseSubHeadSetup A WHERE DataUsed = 'Y' AND A.AccountCode = " + objCoaHead.AccountNo + "";
                dtAssignedSubLedgerType = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtAssignedSubLedgerType;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadAnalysisDDL(DropDownList targetDropDownList, SubledgerSetup objSubledgerSetup)
        {
            try
            {
                string sqlString = @"SELECT A.[SubLedgerID],A.[SubledgerHeadName] FROM [AccCOASubHeadSetup] A WHERE A.[SubLedgerTypeID]='" + objSubledgerSetup.SubledgerTypeID + "' ORDER BY A.SubledgerHeadName";
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, sqlString, targetDropDownList, "SubledgerHeadName", "SubLedgerID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void Save(BranchSetup objBranchSetup, CoaHead objCoaHead, JournalVoucher objJournalVoucher)
        {
            try
            {
                objJournalVoucher.VoucherNo = objBranchSetup.CompanyID.ToString() + DateTime.Now.ToString("yy") + this.GetVoucherNo().ToString("00000");
                objJournalVoucher.TransactionNo = Convert.ToInt32(objJournalVoucher.VoucherNo);
                if (objJournalVoucher.UserVoucherNo == null)
                {
                    objJournalVoucher.UserVoucherNo = objJournalVoucher.VoucherNo;
                }

                var storedProcedureComandText = SqlSaveVoucherHeader(objBranchSetup, objCoaHead, objJournalVoucher);
                storedProcedureComandText += SqlSaveVoucherJournalDetails(objBranchSetup, objCoaHead, objJournalVoucher);
                storedProcedureComandText += SqlSaveVoucherSubLedger(objBranchSetup, objCoaHead, objJournalVoucher);
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlSaveVoucherSubLedger(BranchSetup objBranchSetup, CoaHead objCoaHead, JournalVoucher objJournalVoucher)
        {
            try
            {
                string storedProcedureComandTextSubLedger = null;
                if (objJournalVoucher.DtVoucherSubLedger != null)
                {
                    foreach (DataRow rowNo in objJournalVoucher.DtVoucherSubLedger.Rows)
                    {
                        objJournalVoucher.SubLineNo = Convert.ToInt32(rowNo["SlNo"].ToString());
                        objJournalVoucher.TransactionTypeID = 0; //null;//Convert.ToInt32(rowNo["Typeid"].ToString());
                        objCoaHead.AccountNo = Convert.ToInt32(rowNo["AccountingCode"].ToString());
                        objJournalVoucher.TranactionLineNo = Convert.ToInt32(rowNo["TranactionLineNoSubLedger"].ToString());
                        objJournalVoucher.AnalysisValue1st = rowNo["1stAnalysisValue"].ToString();
                        objJournalVoucher.AnalysisValue2nd = rowNo["2ndAnalysisValue"].ToString();
                        objJournalVoucher.AnalysisValue3rd = rowNo["3rdAnalysisValue"].ToString();
                        objJournalVoucher.AnalysisValue4th = rowNo["4thAnalysisValue"].ToString();
                        objJournalVoucher.AnalysisValue5th = rowNo["5thAnalysisValue"].ToString();
                        var storedProcedureComandTextSubLedgerTemp = @"INSERT INTO [AccVoucherSubLedger]
                   ([CompanyID]
                   ,[BranchID]
                   ,[VoucherNo]
                   ,[AccountCode]
                   ,[TranactionLineNo]
                   ,[SubLineNo]
                   ,[TransactionTypeID]
                   ,[SubLedgerNarration]
                   ,[Amount]
                   ,[SubLedgerTypeID1]
                   ,[SubLedgerTypeID2]
                   ,[SubLedgerTypeID3]
                   ,[SubLedgerTypeID4]
                   ,[SubLedgerTypeID5]
                   ,[SubLedgerID1]
                   ,[SubLedgerID2]
                   ,[SubLedgerID3]
                   ,[SubLedgerID4]
                   ,[SubLedgerID5]                   
                   ,[DataUsed]
                   ,[EntryUserID]
                   ,[EntryDate]
                   )
             VALUES
                   (" + objBranchSetup.CompanyID + ""
                       + "," + objBranchSetup.BranchID + ""
                       + ",'" + objJournalVoucher.VoucherNo + "'"
                       + "," + objCoaHead.AccountNo + ""
                       + "," + objJournalVoucher.TranactionLineNo + ""
                       + "," + objJournalVoucher.SubLineNo + ""
                       + "," + objJournalVoucher.TransactionTypeID + ""
                       + ",'" + objJournalVoucher.SubLedgerNarration + "'"
                       + "," + objJournalVoucher.SubLegerAmount + ""
                       + ",'" + objJournalVoucher.SubLedgerTypeID1 + "'"
                       + ",'" + objJournalVoucher.SubLedgerTypeID2 + "'"
                       + ",'" + objJournalVoucher.SubLedgerTypeID3 + "'"
                       + ",'" + objJournalVoucher.SubLedgerTypeID4 + "'"
                       + ",'" + objJournalVoucher.SubLedgerTypeID5 + "'"
                       + ",'" + objJournalVoucher.AnalysisValue1st + "'"
                       + ",'" + objJournalVoucher.AnalysisValue2nd + "'"
                       + ",'" + objJournalVoucher.AnalysisValue3rd + "'"
                       + ",'" + objJournalVoucher.AnalysisValue4th + "'"
                       + ",'" + objJournalVoucher.AnalysisValue5th + "'"
                       + ",'" + "A" + "'"
                       + ",'" + objBranchSetup.EntryUserName + "'"
                       + "," + "CAST(GETDATE() AS DateTime)" + ""
                       + ");";
                        storedProcedureComandTextSubLedger += storedProcedureComandTextSubLedgerTemp;
                    }
                }
                return storedProcedureComandTextSubLedger;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlSaveVoucherJournalDetails(BranchSetup objBranchSetup, CoaHead objCoaHead, JournalVoucher objJournalVoucher)
        {
            try
            {
                string storedProcedureComandTextDetails = null;
                if (objJournalVoucher.DtVoucherJournalDetails != null)
                {
                    foreach (DataRow rowNo in objJournalVoucher.DtVoucherJournalDetails.Rows)
                    {
                        objJournalVoucher.TranactionLineNo = Convert.ToInt32(rowNo["SlNo"].ToString());
                        objJournalVoucher.TransactionTypeID = Convert.ToInt32(rowNo["Typeid"].ToString());
                        objJournalVoucher.VoucherTypeID = rowNo["Type"].ToString();
                        objCoaHead.AccountNo = Convert.ToInt32(rowNo["AccountingCode"].ToString());
                        objJournalVoucher.Particulars = rowNo["Particulars"].ToString();
                        objJournalVoucher.CurrencyRate = Convert.ToDecimal(rowNo["CurrencyRate"].ToString());
                        objJournalVoucher.BaseAmount = Convert.ToDecimal(rowNo["BaseAmount"].ToString());
                        objJournalVoucher.TransactionCurrencyAmount = Convert.ToDecimal(rowNo["TransactionAmount"].ToString());
                        objJournalVoucher.CurrencyID = Convert.ToInt32(rowNo["CurrencyID"].ToString());

                        var storedProcedureComandTextDetailsTemp = @"INSERT INTO [accVoucherJournalDetails]
                   ([CompanyID]
                   ,[BranchID]
                   ,[VoucherNo]
                   ,[TransactionNo]
                   ,[TranactionLineNo]
                   ,[TransactionTypeID]
                   ,[VoucherTypeID]
                   ,[TransactionMediaID]
                   ,[AccountCode]
                   ,[CurrencyID] 
                   ,[BaseCurrencyAmount]
                   ,[CurrencyExchangeRate]
                   ,[TransactionCurrencyAmount]
                   ,[AutoJournalParticulars]
                   ,[Status]
                   ,[CalcStatus]
                   ,[ShowInRpt]
                   ,[RPCashAmount]
                   ,[RpChequeAmount]
                   ,[EntryUserID]
                   ,[EntryDate]
                   )
             VALUES
                   (" + objBranchSetup.CompanyID + ""
                       + "," + objBranchSetup.BranchID + ""
                       + ",'" + objJournalVoucher.VoucherNo + "'"
                       + "," + objJournalVoucher.TransactionNo + ""
                       + "," + objJournalVoucher.TranactionLineNo + ""
                       + "," + objJournalVoucher.TransactionTypeID + ""
                       + ",'" + objJournalVoucher.VoucherTypeID + "'"
                       + "," + objJournalVoucher.TransactionMediaID + ""
                       + "," + objCoaHead.AccountNo + ""
                       + "," + objJournalVoucher.CurrencyID + ""
                       + "," + objJournalVoucher.BaseAmount + ""
                       + "," + objJournalVoucher.CurrencyRate + ""
                       + "," + objJournalVoucher.TransactionCurrencyAmount + ""
                       + ",'" + objJournalVoucher.Particulars + "'"
                       + ",'" + objJournalVoucher.TranactionLineStatus + "'"
                       + ",'" + objJournalVoucher.TranactionLineCalcStatus + "'"
                       + "," + objJournalVoucher.ShowInRpt + ""
                       + "," + objJournalVoucher.RpCashAmount + ""
                       + "," + objJournalVoucher.RpChequeAmount + ""
                       + ",'" + objBranchSetup.EntryUserName + "'"
                       + "," + "CAST(GETDATE() AS DateTime)" + ""
                       + ");";
                        storedProcedureComandTextDetails += storedProcedureComandTextDetailsTemp;

                    }
                }

                return storedProcedureComandTextDetails;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private static string SqlSaveVoucherHeader(BranchSetup objBranchSetup, CoaHead objCoaHead, JournalVoucher objJournalVoucher)
        {
            try
            {
                var storedProcedureComandText = @"INSERT INTO [accVoucherHeader]
               ([CompanyID]
               ,[BranchID]
               ,[VoucherNo]
               ,[UserVoucherNo]
               ,[PointNumber]
               ,[ComputerName]
               ,[VoucherDate]
               ,[AnyRefVoucherNo]
               ,[AnyReferenceNo]
               ,[ValueDate]
               ,[JournalTypeID]
               ,[AutoParticulars]
               ,[ReceivedBy]
               ,[PaymentBy]
               ,[Remark]
               ,[DataStatusID]
               ,[IsBackedup]
               ,[IsSetToFS]               
               ,[EntryUserID]
               ,[EntryDate])
         VALUES
               (" + objBranchSetup.CompanyID + ""
               + "," + objBranchSetup.BranchID + ""
               + ",'" + objJournalVoucher.VoucherNo + "'"
               + ",'" + objJournalVoucher.UserVoucherNo + "'"
               + "," + objJournalVoucher.PointNumber + ""
               + ",'" + objJournalVoucher.ComputerName + "'"
               + ",CONVERT(DATETIME,'" + objJournalVoucher.VoucherDate + "',103)"
               + "," + objJournalVoucher.AnyRefVoucherNo + ""
               + ",'" + objJournalVoucher.AnyReferenceNo + "'"
               + ",CONVERT(DATETIME,'" + objJournalVoucher.ValueDate + "',103)"
               + "," + objJournalVoucher.JournalTypeID + ""
               + ",'" + objJournalVoucher.Particulars + "'"
               + ",'" + objJournalVoucher.ReceivedBy + "'"
               + ",'" + objJournalVoucher.PaymentBy + "'"
               + ",'" + objJournalVoucher.Remark + "'"
               + ",'" + objJournalVoucher.DataStatusID + "'"
               + "," + objJournalVoucher.IsBackedup + ""
               + "," + objJournalVoucher.IsSetToFS + ""
               + ",'" + objBranchSetup.EntryUserName + "'"
               + "," + "CAST(GETDATE() AS DateTime)" + ""
               + ");";
                return storedProcedureComandText;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private int GetVoucherNo()
        {
            try
            {
                int voucherNo = 0;
                var storedProcedureComandText = "SELECT ISNULL( COUNT( VoucherNo),0)+1 FROM [accVoucherHeader]";
                voucherNo = clsDataManipulation.GetMaximumValueUsingSQL(this.ConnectionString, storedProcedureComandText);
                return voucherNo;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void GetCurrency(DropDownList ddlCurrency)
        {
            try
            {
                string sqlString = @"SELECT [CurrencyID],[CurrencyName] FROM [gCurrencyTypeSetup] WHERE [DataUsed] = 'A' AND [CompanyID] = 1 ORDER BY IsBaseCurrency DESC";
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, sqlString, ddlCurrency, "CurrencyName", "CurrencyID");
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal string GetExchangeRate(JournalVoucher objJournalVoucher, BranchSetup objBranchSetup)
        {
            try
            {
                string exchangeRate = null;
                var storedProcedureComandText = @"SELECT DISTINCT [ExchangeRate] FROM [gCurrencyTypeSetup] WHERE [DataUsed] = 'A' AND [CompanyID] = " + objBranchSetup.CompanyID + " "
                + "AND [CurrencyID] = " + objJournalVoucher.CurrencyID + "";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                exchangeRate = objclsDataManipulation.GetSingleValueAsString(this.ConnectionString, storedProcedureComandText);
                return exchangeRate;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void UpdateExchangeRate(JournalVoucher objJournalVoucher, BranchSetup objBranchSetup)
        {
            try
            {
                string storedProcedureComandTextNode = @"UPDATE [gCurrencyTypeSetup] SET 
		         [ExchangeRate] = " + objJournalVoucher.CurrencyRate + ""
                + ",[LastUpdateDate] = " + "CAST(GETDATE() AS DateTime)" + ""
               + ",[LastUpdateUser] = '" + objBranchSetup.EntryUserName + "'"
                + " WHERE DataUsed = 'A' AND [CompanyID] = " + objBranchSetup.CompanyID + " AND [CurrencyID] = " + objJournalVoucher.CurrencyID + "";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTextNode);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}