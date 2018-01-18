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
                if (objJournalVoucher.SearchVoucherNo != null)
                {
                    if (CheckUserVoucherNo(objJournalVoucher) == true)
                    {
                        throw new Exception("Voucher No. " + clsMessages.GExist);
                    }

                    objJournalVoucher.VoucherNo = objJournalVoucher.SearchVoucherNo;
                    DeleteGarBageRecords(objJournalVoucher);
                }
                else
                {
                    objJournalVoucher.VoucherNo = objBranchSetup.CompanyID.ToString() + DateTime.Now.ToString("yy") + this.GetVoucherNo().ToString("00000");
                }


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

        private bool CheckUserVoucherNo(JournalVoucher objJournalVoucher)
        {
            try
            {
                bool userVoucherNo = false;
                DataTable dtUserVoucherNo = null;
                string storedProcedureCommandText = @"SELECT DISTINCT A.[VoucherNo] FROM [accVoucherHeader] A  WHERE A.[UserVoucherNo] = '" + objJournalVoucher.UserVoucherNo + "' " +
                    " AND A.VoucherNo != '" + objJournalVoucher.SearchVoucherNo + "'";
                dtUserVoucherNo = clsDataManipulation.GetData(this.ConnectionString, storedProcedureCommandText);
                if (dtUserVoucherNo.Rows.Count > 0)
                {
                    userVoucherNo = true;

                }

                return userVoucherNo;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void DeleteGarBageRecords(JournalVoucher objJournalVoucher)
        {
            try
            {
                string sqlString = @"DELETE FROM accVoucherHeader WHERE VoucherNo = '" + objJournalVoucher.SearchVoucherNo + "'" +
                                    " ; DELETE FROM accVoucherJournalDetails WHERE VoucherNo = '" + objJournalVoucher.SearchVoucherNo + "'" +
                                    " ; DELETE FROM AccVoucherSubLedger WHERE VoucherNo = '" + objJournalVoucher.SearchVoucherNo + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, sqlString);

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
                        objJournalVoucher.TransactionTypeID = 0; 
                        objCoaHead.AccountNo = Convert.ToInt32(rowNo["AccountingCode"].ToString());
                        objJournalVoucher.TranactionLineNo = Convert.ToInt32(rowNo["TranactionLineNoSubLedger"].ToString());
                        objJournalVoucher.AnalysisValue1st = rowNo["1stAnalysisValue"].ToString();
                        objJournalVoucher.AnalysisValue2nd = rowNo["2ndAnalysisValue"].ToString();
                        objJournalVoucher.AnalysisValue3rd = rowNo["3rdAnalysisValue"].ToString();
                        objJournalVoucher.AnalysisValue4th = rowNo["4thAnalysisValue"].ToString();
                        objJournalVoucher.AnalysisValue5th = rowNo["5thAnalysisValue"].ToString();
                        objJournalVoucher.SubLegerAmountApart  = Convert.ToDecimal( rowNo["SubLegerAmount"].ToString());
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
                       + "," + objJournalVoucher.SubLegerAmountApart + ""
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

        internal DataTable GetSubmittedJournal(BranchSetup objBranchSetup)
        {
            try
            {
                DataTable dtSubmittedJournal = null;
                var storedProcedureComandText = @"SELECT DISTINCT A.[VoucherNo],A.[VoucherDate],A.[JournalTypeID],B.JournalTypeName FROM [accVoucherHeader] A "
                  + " INNER JOIN accJournalTypeSetup B ON A.CompanyID = B.CompanyID AND A.JournalTypeID = B.JournalTypeID "
                  + " WHERE A.[DataStatusID] = 'U' AND A.[CompanyID] = " + objBranchSetup.CompanyID + " ORDER BY A.[VoucherDate],A.[JournalTypeID]";
                dtSubmittedJournal = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtSubmittedJournal;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetSubmittedJournalAdvancedSearch(JournalVoucher objJournalVoucher, BranchSetup objBranchSetup, CoaHead objCoaHead)
        {
            try
            {
                DataTable dtSubmittedJournal = null;
                var storedProcedureComandText = @"SELECT DISTINCT A.[VoucherNo],A.[VoucherDate],A.[JournalTypeID],B.JournalTypeName FROM [accVoucherHeader] A "
                  + " INNER JOIN accJournalTypeSetup B ON A.CompanyID = B.CompanyID AND A.JournalTypeID = B.JournalTypeID "
                  + " INNER JOIN accVoucherJournalDetails C ON A.CompanyID = C.CompanyID AND A.VoucherNo = C.VoucherNo "
                  + " WHERE A.[DataStatusID] = 'U' AND A.[CompanyID] = " + objBranchSetup.CompanyID + "";
                if (objJournalVoucher.VoucherNo != null)
                {
                    storedProcedureComandText += " AND A.VoucherNo = " + objJournalVoucher.VoucherNo + "";
                }

                if (objJournalVoucher.TransactionTypeID != -1)
                {
                    storedProcedureComandText += " AND C.TransactionTypeID = " + objJournalVoucher.TransactionTypeID + "";
                }

                if (objCoaHead.AccountNo != 0)
                {
                    storedProcedureComandText += " AND C.AccountCode = " + objCoaHead.AccountNo + "";
                }

                if (objJournalVoucher.JournalDateFrom != null && objJournalVoucher.JournalDateTo != null)
                {
                    storedProcedureComandText += " AND A.VoucherDate BETWEEN CONVERT(DATETIME,'" + objJournalVoucher.JournalDateFrom + "',103) AND CONVERT(DATETIME,'" + objJournalVoucher.JournalDateTo + "',103) ";
                }

                if (objJournalVoucher.BaseAmountSearch != null)
                {
                    storedProcedureComandText += " AND C.BaseCurrencyAmount = " + objJournalVoucher.BaseAmountSearch + "";
                }
                storedProcedureComandText += " ORDER BY A.[VoucherDate],A.[JournalTypeID]";
                dtSubmittedJournal = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtSubmittedJournal;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void PostUnpostedVoucher(JournalVoucher objJournalVoucher, BranchSetup objBranchSetup)
        {
            try
            {
                string storedProcedureComandTextNode = @"UPDATE [accVoucherHeader]
                                                       SET
                                                       [DataStatusID] = 'P'
                                                       ,[LastUpdateDate] = CAST(GETDATE() AS DateTime)"
                                                       + " ,[LastUpdateUserID] = '" + objBranchSetup.EntryUserName + "'"
                                                       + " WHERE [VoucherNo] = '" + objJournalVoucher.VoucherNo + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTextNode);
            }
            catch (Exception msgExceptin)
            {

                throw msgExceptin;
            }
        }

        internal DataTable GetVoucherDetails(JournalVoucher objJournalVoucher)
        {
            try
            {
                DataTable dtVoucherDetails = null;
                var storedProcedureComandText = @"SELECT A.[AccountCode] AS AccountingCode,B.AccountName AS AccountingName,A.[AutoJournalParticulars] AS Particulars,
                                                CASE WHEN A.[VoucherTypeID] = '1' THEN A.[BaseCurrencyAmount] ELSE '' END AS Debit,
                                                CASE WHEN A.[VoucherTypeID] = '0' THEN A.[BaseCurrencyAmount] ELSE '' END AS Credit,
                                                A.[VoucherTypeID] AS Type,
                                                A.[TransactionTypeID] AS Typeid,
                                                C.TransactionType AS Trtype, 
                                                A.[CurrencyExchangeRate] AS CurrencyRate,
                                                A.[TranactionLineNo] AS SlNo,
                                                A.[BaseCurrencyAmount] AS BaseAmount,
                                                A.[TransactionCurrencyAmount] AS TransactionAmount,
                                                A.[CurrencyID]
                                                FROM [accVoucherJournalDetails] A
                                                INNER JOIN accCOAHeadSetup B ON A.AccountCode = B.AccountNo 
                                                INNER JOIN dsTransactionType C ON A.TransactionTypeID = C.TransactionTypeID
                                                WHERE C.DataUsed = 'A' AND A.VoucherNo = '" + objJournalVoucher.VoucherNo + "' "
                                                + " ORDER BY A.[TranactionLineNo] DESC";
                dtVoucherDetails = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtVoucherDetails;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetVoucherSubLedger(JournalVoucher objJournalVoucher)
        {
            try
            {
                DataTable dtVoucherSubLedger = null;
                var storedProcedureComandText = @"SELECT A.[AccountCode] AS AccountingCode,
                A.[SubLedgerID1] AS [1stAnalysisValue],
                A.[SubLedgerID2] AS [2ndAnalysisValue],
                A.[SubLedgerID3] AS [3rdAnalysisValue],
                A.[SubLedgerID4] AS [4thAnalysisValue],
                A.[SubLedgerID5] AS [5thAnalysisValue],
                (SELECT Z.[SubledgerHeadName] FROM [AccCOASubHeadSetup] Z WHERE Z.DataUsed = 'A' AND Z.[SubLedgerID] = A.[SubLedgerID1]  ) AS [1stAnalysisText],
                (SELECT Z.[SubledgerHeadName] FROM [AccCOASubHeadSetup] Z WHERE Z.DataUsed = 'A' AND Z.[SubLedgerID] = A.[SubLedgerID2]  ) AS [2ndAnalysisText],
                (SELECT Z.[SubledgerHeadName] FROM [AccCOASubHeadSetup] Z WHERE Z.DataUsed = 'A' AND Z.[SubLedgerID] = A.[SubLedgerID3]  ) AS [3rdAnalysisText],
                (SELECT Z.[SubledgerHeadName] FROM [AccCOASubHeadSetup] Z WHERE Z.DataUsed = 'A' AND Z.[SubLedgerID] = A.[SubLedgerID4]  ) AS [4thAnalysisText],
                (SELECT Z.[SubledgerHeadName] FROM [AccCOASubHeadSetup] Z WHERE Z.DataUsed = 'A' AND Z.[SubLedgerID] = A.[SubLedgerID5]  ) AS [5thAnalysisText],
                A.[Amount] AS SubLegerAmount,
                A.[TranactionLineNo] AS SlNo,
                A.[SubLineNo] AS TranactionLineNoSubLedger
                FROM  [AccVoucherSubLedger] A 
                LEFT JOIN [AccCOASubHeadSetup] B ON A.SubLedgerID1 = B.SubLedgerID
                WHERE A.DataUsed = 'A' AND B.DataUsed = 'A' AND A.[VoucherNo] = '" + objJournalVoucher.VoucherNo + "'"
                + " ORDER BY A.[SubLineNo] DESC";
                dtVoucherSubLedger = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtVoucherSubLedger;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetVoucherHeader(JournalVoucher objJournalVoucher)
        {
            try
            {
                DataTable dtVoucherHeader = null;
                var storedProcedureComandText = @"SELECT DISTINCT A.[CompanyID]
               ,A.[BranchID]
               ,A.[VoucherNo]
               ,A.[UserVoucherNo]
               ,A.[PointNumber]
               ,A.[ComputerName]
               ,A.[VoucherDate]
               ,A.[AnyRefVoucherNo]
               ,A.[AnyReferenceNo]
               ,A.[ValueDate]
               ,A.[JournalTypeID]
               ,A.[AutoParticulars]
               ,A.[ReceivedBy]
               ,A.[PaymentBy]
               ,A.[Remark]
               ,A.[DataStatusID]
               ,A.[IsBackedup]
               ,A.[IsSetToFS]               
               ,A.[EntryUserID]
               ,A.[EntryDate]
               ,B.TransactionTypeID               
               FROM [accVoucherHeader] A 
               INNER JOIN accVoucherJournalDetails B ON A.VoucherNo = B.VoucherNo
               WHERE A.[UserVoucherNo] = '" + objJournalVoucher.UserVoucherNo + "'";
                dtVoucherHeader = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtVoucherHeader;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetVoucherDetailsUserVoucherNo(JournalVoucher objJournalVoucher)
        {
            try
            {
                DataTable dtVoucherDetails = null;
                var storedProcedureComandText = @"SELECT A.[AccountCode] AS AccountingCode,B.AccountName AS AccountingName,A.[AutoJournalParticulars] AS Particulars,
                                                CASE WHEN A.[VoucherTypeID] = '1' THEN A.[BaseCurrencyAmount] ELSE '' END AS Debit,
                                                CASE WHEN A.[VoucherTypeID] = '0' THEN A.[BaseCurrencyAmount] ELSE '' END AS Credit,
                                                A.[VoucherTypeID] AS Type,
                                                A.[TransactionTypeID] AS Typeid,
                                                C.TransactionType AS Trtype, 
                                                A.[CurrencyExchangeRate] AS CurrencyRate,
                                                A.[TranactionLineNo] AS SlNo,
                                                A.[BaseCurrencyAmount] AS BaseAmount,
                                                A.[TransactionCurrencyAmount] AS TransactionAmount,
                                                A.[CurrencyID]
                                                FROM [accVoucherJournalDetails] A
                                                INNER JOIN accCOAHeadSetup B ON A.AccountCode = B.AccountNo 
                                                INNER JOIN dsTransactionType C ON A.TransactionTypeID = C.TransactionTypeID
                                                INNER JOIN accVoucherHeader D ON A.VoucherNo = D.VoucherNo
                                                WHERE C.DataUsed = 'A' AND D.UserVoucherNo = '" + objJournalVoucher.UserVoucherNo + "' "
                                                + " ORDER BY A.[TranactionLineNo] DESC";
                dtVoucherDetails = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtVoucherDetails;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetVoucherSubLedgerUserVoucherNo(JournalVoucher objJournalVoucher)
        {
            try
            {
                DataTable dtVoucherSubLedger = null;
                var storedProcedureComandText = @"SELECT A.[AccountCode] AS AccountingCode,
                A.[SubLedgerID1] AS [1stAnalysisValue],
                A.[SubLedgerID2] AS [2ndAnalysisValue],
                A.[SubLedgerID3] AS [3rdAnalysisValue],
                A.[SubLedgerID4] AS [4thAnalysisValue],
                A.[SubLedgerID5] AS [5thAnalysisValue],
                (SELECT Z.[SubledgerHeadName] FROM [AccCOASubHeadSetup] Z WHERE Z.DataUsed = 'A' AND Z.[SubLedgerID] = A.[SubLedgerID1]  ) AS [1stAnalysisText],
                (SELECT Z.[SubledgerHeadName] FROM [AccCOASubHeadSetup] Z WHERE Z.DataUsed = 'A' AND Z.[SubLedgerID] = A.[SubLedgerID2]  ) AS [2ndAnalysisText],
                (SELECT Z.[SubledgerHeadName] FROM [AccCOASubHeadSetup] Z WHERE Z.DataUsed = 'A' AND Z.[SubLedgerID] = A.[SubLedgerID3]  ) AS [3rdAnalysisText],
                (SELECT Z.[SubledgerHeadName] FROM [AccCOASubHeadSetup] Z WHERE Z.DataUsed = 'A' AND Z.[SubLedgerID] = A.[SubLedgerID4]  ) AS [4thAnalysisText],
                (SELECT Z.[SubledgerHeadName] FROM [AccCOASubHeadSetup] Z WHERE Z.DataUsed = 'A' AND Z.[SubLedgerID] = A.[SubLedgerID5]  ) AS [5thAnalysisText],
                A.[Amount] AS SubLegerAmount,
                A.[TranactionLineNo] AS TranactionLineNoSubLedger,
                A.[SubLineNo] AS SlNo
                ,A.[SubLedgerTypeID1]
               ,A.[SubLedgerTypeID2]
               ,A.[SubLedgerTypeID3]
               ,A.[SubLedgerTypeID4]
               ,A.[SubLedgerTypeID5]
                FROM  [AccVoucherSubLedger] A 
                LEFT JOIN [AccCOASubHeadSetup] B ON A.SubLedgerID1 = B.SubLedgerID
                INNER JOIN accVoucherHeader C ON A.VoucherNo = C.VoucherNo
                WHERE A.DataUsed = 'A' AND B.DataUsed = 'A' AND C.[UserVoucherNo] = '" + objJournalVoucher.UserVoucherNo + "'"
                + " ORDER BY A.[SubLineNo] DESC";
                dtVoucherSubLedger = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtVoucherSubLedger;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}