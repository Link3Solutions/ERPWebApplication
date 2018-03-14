using System;
using System.Collections.Generic;
using ERPWebApplication.AppClass.Model;
using System.Linq;
using System.Web;
using System.Data;


namespace ERPWebApplication.AppClass.DataAccess
{
    public class matMaterialTransactionDetailsController:DataAccessBase
    {
        public matMaterialTransactionDetailsController()
        { }

        public bool InsertmatMaterialTransactionDetails(matMaterialTransactionDetails objMatDet)
        {
            string sql = "";
            bool retflag = true;
            sql = "INSERT INTO [matMaterialTransactionDetails] ([CompanyID], [BranchID], [MatTransID], [VoucherNo], [TransactionReferenceTypeID], [TransactionReferenceNo], [MatTransStatusID], [OtherReferenceTypeID], [OtherReferenceNo], [NextStatusDate], [TransactionAmount], [TransactionReturnAmount], [PaymentAmount], [AdvanceReceived], [Discount], [CarryingCost], [RelatedPersonID], [ShipperID], [ShippedViaID], [ArriveTo], [VATAmount], [TaxAmount], [Billingcategory]) VALUES ('" + objMatDet.CompanyID + "','" + objMatDet.BranchID + "','" + objMatDet.MatTransID + "','" + objMatDet.VoucherNo + "','" + objMatDet.TransactionReferenceTypeID + "','" + objMatDet.TransactionReferenceNo + "','" + objMatDet.MatTransStatusID + "','" + objMatDet.OtherReferenceTypeID + "','" + objMatDet.OtherReferenceNo + "', '" + objMatDet.NextStatusDate + "','" + objMatDet.TransactionAmount + "','" + objMatDet.TransactionReturnAmount + "','" + objMatDet.PaymentAmount + "','" + objMatDet.AdvanceReceived + "','" + objMatDet.Discount + "','" + objMatDet.CarryingCost + "','" + objMatDet.RelatedPersonID + "','" + objMatDet.ShipperID + "','" + objMatDet.ShippedViaID + "','" + objMatDet.ArriveTo + "','" + objMatDet.VATAmount + "','" + objMatDet.TaxAmount + "','" + objMatDet.Billingcategory + "',)";
            return retflag;
        }

        public DataTable GetDataAllmatMaterialTransactionDetails()
        {
            try
            {
                DataTable dtAll = null;
                var storedProcedureComandText = "SELECT  CompanyID, BranchID, MatTransID, VoucherNo, TransactionReferenceTypeID, TransactionReferenceNo, MatTransStatusID, OtherReferenceTypeID, OtherReferenceNo, NextStatusDate, TransactionAmount," 
                                                +" TransactionReturnAmount, PaymentAmount, AdvanceReceived, Discount, CarryingCost, RelatedPersonID, ShipperID, ShippedViaID, ArriveTo, VATAmount, TaxAmount, Billingcategory"
                                                +" FROM  matMaterialTransactionDetails";

                dtAll = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtAll;
            }
            catch (Exception msgException)
            {
                throw msgException;
            }
        }

        public DataTable GetDataAllWithCompanyBranchRefmatMaterialTransactionDetails(matMaterialTransactionDetails objMatDet)
        {
            try
            {
                DataTable dtAll = null;
                var storedProcedureComandText = "SELECT  CompanyID, BranchID, MatTransID, VoucherNo, TransactionReferenceTypeID, TransactionReferenceNo, MatTransStatusID, OtherReferenceTypeID, OtherReferenceNo, NextStatusDate, TransactionAmount,"
                                                + " TransactionReturnAmount, PaymentAmount, AdvanceReceived, Discount, CarryingCost, RelatedPersonID, ShipperID, ShippedViaID, ArriveTo, VATAmount, TaxAmount, Billingcategory"
                                                + " FROM  matMaterialTransactionDetails where CompanyID="+objMatDet.CompanyID +"and BranchID="+objMatDet.BranchID +" and MatTransID="+objMatDet.MatTransID+"";
                dtAll = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtAll;

            }
            catch (Exception msgException)
            {
                throw msgException;
            }
        }


    }
}