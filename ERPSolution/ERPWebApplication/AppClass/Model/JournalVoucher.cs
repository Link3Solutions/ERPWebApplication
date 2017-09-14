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

        private string _analysisValue1st;

        public string AnalysisValue1st
        {
            get { return _analysisValue1st; }
            set { _analysisValue1st = value; }
        }
        private string _analysisValue2nd;

        public string AnalysisValue2nd
        {
            get { return _analysisValue2nd; }
            set { _analysisValue2nd = value; }
        }
        private string _analysisValue3rd;

        public string AnalysisValue3rd
        {
            get { return _analysisValue3rd; }
            set { _analysisValue3rd = value; }
        }
        private string _analysisValue4th;

        public string AnalysisValue4th
        {
            get { return _analysisValue4th; }
            set { _analysisValue4th = value; }
        }
        private string _analysisValue5th;

        public string AnalysisValue5th
        {
            get { return _analysisValue5th; }
            set { _analysisValue5th = value; }
        }
        private string _analysisText1st;

        public string AnalysisText1st
        {
            get { return _analysisText1st; }
            set { _analysisText1st = value; }
        }
        private string _analysisText2nd;

        public string AnalysisText2nd
        {
            get { return _analysisText2nd; }
            set { _analysisText2nd = value; }
        }
        private string _analysisText3rd;

        public string AnalysisText3rd
        {
            get { return _analysisText3rd; }
            set { _analysisText3rd = value; }
        }
        private string _analysisText4th;

        public string AnalysisText4th
        {
            get { return _analysisText4th; }
            set { _analysisText4th = value; }
        }
        private string _analysisText5th;

        public string AnalysisText5th
        {
            get { return _analysisText5th; }
            set { _analysisText5th = value; }
        }
        
        
    }
}