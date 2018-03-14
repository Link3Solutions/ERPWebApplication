using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class matMaterialTransactionDetails
    {
        public matMaterialTransactionDetails()
        { }

        #region private variable

        private int companyID;
        private int branchID;
        private int matTransID;
        private int voucherNo;
        private int transactionReferenceTypeID;
        private int transactionReferenceNo;
        private int matTransStatusID;
        private int otherReferenceTypeID;
        private int otherReferenceNo;
        private DateTime nextStatusDate;
        private decimal transactionAmount;
        private decimal transactionReturnAmount;
        private decimal paymentAmount;
        private decimal advanceReceived;
        private decimal discount;
        private decimal carryingCost;
        private string relatedPersonID;
        private string shipperID;
        private int shippedViaID;
        private string arriveTo;
        private decimal vATAmount;
        private decimal taxAmount;
        private int billingcategory;

        #endregion private variable

        #region Public variable
        public int CompanyID
        {
            get { return companyID; }
            set { companyID = value; }
        }
        public int BranchID
        {
            get { return branchID; }
            set { branchID = value; }
        }
        public int MatTransID
        {
            get { return matTransID; }
            set { matTransID = value; }
        }
        public int VoucherNo
        {
            get { return voucherNo; }
            set { voucherNo = value; }
        }
        public int TransactionReferenceTypeID
        {
            get { return transactionReferenceTypeID; }
            set { transactionReferenceTypeID = value; }
        }
        public int TransactionReferenceNo
        {
            get { return transactionReferenceNo; }
            set { transactionReferenceNo = value; }
        }
        public int MatTransStatusID
        {
            get { return matTransStatusID; }
            set { matTransStatusID = value; }
        }
        public int OtherReferenceTypeID
        {
            get { return otherReferenceTypeID; }
            set { otherReferenceTypeID = value; }
        }
        public int OtherReferenceNo
        {
            get { return otherReferenceNo; }
            set { otherReferenceNo = value; }
        }
        public DateTime NextStatusDate
        {
            get { return nextStatusDate; }
            set { nextStatusDate = value; }
        }
        public decimal TransactionAmount
        {
            get { return transactionAmount; }
            set { transactionAmount = value; }
        }
        public decimal TransactionReturnAmount
        {
            get { return transactionReturnAmount; }
            set { transactionReturnAmount = value; }
        }
        public decimal PaymentAmount
        {
            get { return paymentAmount; }
            set { paymentAmount = value; }
        }
        public decimal AdvanceReceived
        {
            get { return advanceReceived; }
            set { advanceReceived = value; }
        }
        public decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        public decimal CarryingCost
        {
            get { return carryingCost; }
            set { carryingCost = value; }
        }
        public string RelatedPersonID
        {
            get { return relatedPersonID; }
            set { relatedPersonID = value; }
        }
        public string ShipperID
        {
            get { return shipperID; }
            set { shipperID = value; }
        }
        public int ShippedViaID
        {
            get { return shippedViaID; }
            set { shippedViaID = value; }
        }
        public string ArriveTo
        {
            get { return arriveTo; }
            set { arriveTo = value; }
        }
        public decimal VATAmount
        {
            get { return vATAmount; }
            set { vATAmount = value; }
        }
        public decimal TaxAmount
        {
            get { return taxAmount; }
            set { taxAmount = value; }
        }
        public int Billingcategory
        {
            get { return billingcategory; }
            set { billingcategory = value; }
        }

        #endregion 
    }
}