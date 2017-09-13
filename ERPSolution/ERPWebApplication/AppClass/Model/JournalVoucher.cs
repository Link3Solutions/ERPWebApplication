using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class JournalVoucher
    {
        private Nullable<int> _journalTypeID;

        public Nullable<int> JournalTypeID
        {
            get { return _journalTypeID; }
            set {
                if (value == null)
                {
                    throw new Exception(" Journal type is required ");
                } _journalTypeID = value;
            }
        }


        private Nullable<int> _transactionTypeID;

        public Nullable<int> TransactionTypeID
        {
            get { return _transactionTypeID; }
            set {
                if (value == null)
                {
                    throw new Exception(" Transaction type is required ");
                } _transactionTypeID = value;
            }
        }

        
        private string _voucherTypeID;

        public string VoucherTypeID
        {
            get { return _voucherTypeID; }
            set {
                if (value == null)
                {
                    throw new Exception(" Voucher type is required ");
                    
                } _voucherTypeID = value;
            }
        }
        private DateTime _voucherDate;

        public DateTime VoucherDate
        {
            get { return _voucherDate; }
            set { _voucherDate = value; }
        }
        private decimal _transactionCurrencyAmount;

        public decimal TransactionCurrencyAmount
        {
            get { return _transactionCurrencyAmount; }
            set { _transactionCurrencyAmount = value; }
        }
        private decimal _currencyRate;

        public decimal CurrencyRate
        {
            get { return _currencyRate; }
            set { _currencyRate = value; }
        }
        private decimal _baseAmount;

        public decimal BaseAmount
        {
            get { return _baseAmount; }
            set { _baseAmount = value; }
        }
        private string _particulars;

        public string Particulars
        {
            get { return _particulars; }
            set { _particulars = value; }
        }

        public decimal Credit { get; set; }

        public decimal Debit { get; set; }

        public string TransactionTypeText { get; set; }

        public decimal SlNo { get; set; }
        private DataTable _dtAssignSubLedgerType;

        public DataTable DtAssignSubLedgerType
        {
            get { return _dtAssignSubLedgerType; }
            set { _dtAssignSubLedgerType = value; }
        }
        private List<string> _listAnalysisData = new List<string>();

        public List<string> ListAnalysisData
        {
            get { return _listAnalysisData; }
            set { _listAnalysisData = value; }
        }
        private List<string> _listAnalysisDataText = new List<string>();

        public List<string> ListAnalysisDataText
        {
            get { return _listAnalysisDataText; }
            set { _listAnalysisDataText = value; }
        }

        
    }
}