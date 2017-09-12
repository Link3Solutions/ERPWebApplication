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
    }
}