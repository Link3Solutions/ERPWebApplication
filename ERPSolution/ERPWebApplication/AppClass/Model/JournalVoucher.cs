using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            set
            {
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
            set
            {
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
            set
            {
                if (value == null)
                {
                    throw new Exception(" Voucher type is required ");

                } _voucherTypeID = value;
            }
        }
        private DateTime? _voucherDate;

        public DateTime? VoucherDate
        {
            get { return _voucherDate; }
            set
            {
                if (value == null)
                {
                    throw new Exception(" Journal date is required ");
                } _voucherDate = value;
            }
        }


        private decimal? _transactionCurrencyAmount;

        public decimal? TransactionCurrencyAmount
        {
            get { return _transactionCurrencyAmount; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Transaction amount	is required ");

                } _transactionCurrencyAmount = value;
            }
        }


        private decimal _subLegerAmount;

        public decimal SubLegerAmount
        {
            get { return _subLegerAmount; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Sub leger amount is not correct");

                }

                if (value > this._balanceAmount)
                {
                    throw new Exception("Sub leger amount can not greater than balance amount");
                }
                _subLegerAmount = value;
            }
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
            set
            {
                if (value == null)
                {
                    throw new Exception("First analysis is not selected");

                } _analysisValue1st = value;
            }
        }
        private string _analysisValue2nd;

        public string AnalysisValue2nd
        {
            get { return _analysisValue2nd; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Second analysis is not selected");
                } _analysisValue2nd = value;
            }
        }
        private string _analysisValue3rd;

        public string AnalysisValue3rd
        {
            get { return _analysisValue3rd; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Third analysis is not selected");
                } _analysisValue3rd = value;
            }
        }
        private string _analysisValue4th;

        public string AnalysisValue4th
        {
            get { return _analysisValue4th; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Fourth analysis is not selected");
                } _analysisValue4th = value;
            }
        }
        private string _analysisValue5th;

        public string AnalysisValue5th
        {
            get { return _analysisValue5th; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Fifth analysis is not selected");
                } _analysisValue5th = value;
            }
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
        private decimal _balanceAmount;

        public decimal BalanceAmount
        {
            get { return _balanceAmount; }
            set { _balanceAmount = value; }
        }
        private string _userVoucherNo;

        public string UserVoucherNo
        {
            get { return _userVoucherNo; }
            set { _userVoucherNo = value; }
        }
        private int? _pointNumber;


        public int? PointNumber
        {
            get { return _pointNumber; }
            set { _pointNumber = value; }
        }
        private string _computerName;

        public string ComputerName
        {
            get { return _computerName; }
            set { _computerName = value; }
        }
        private int? _anyRefVoucherNo;

        public int? AnyRefVoucherNo
        {
            get { return _anyRefVoucherNo; }
            set { _anyRefVoucherNo = value; }
        }
        private string _anyReferenceNo;

        public string AnyReferenceNo
        {
            get { return _anyReferenceNo; }
            set { _anyReferenceNo = value; }
        }
        private DateTime? _valueDate;

        public DateTime? ValueDate
        {
            get { return _valueDate; }
            set { _valueDate = value; }
        }


        private string _receivedBy;

        public string ReceivedBy
        {
            get { return _receivedBy; }
            set { _receivedBy = value; }
        }
        private string _paymentBy;

        public string PaymentBy
        {
            get { return _paymentBy; }
            set { _paymentBy = value; }
        }
        private string _remark;

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        private string _dataStatusID;

        public string DataStatusID
        {
            get { return _dataStatusID; }
            set { _dataStatusID = value; }
        }
        [DefaultValue(0)]
        private int? _isBackedup;

        [DefaultValue(0)]
        public int? IsBackedup
        {
            get { return _isBackedup; }
            set { _isBackedup = value; }
        }
        [DefaultValue(0)]
        private int? _isSetToFS;

        [DefaultValue(0)]
        public int? IsSetToFS
        {
            get { return _isSetToFS; }
            set { _isSetToFS = value; }
        }

        private DateTime _lastBackupDate;
        [DefaultValue(null)]
        public DateTime LastBackupDate
        {
            get { return _lastBackupDate; }
            set { _lastBackupDate = value; }
        }
        private string _voucherNo;

        public string VoucherNo
        {
            get { return _voucherNo; }
            set { _voucherNo = value; }
        }
        private int _transactionNo;

        public int TransactionNo
        {
            get { return _transactionNo; }
            set { _transactionNo = value; }
        }
        private int? _tranactionLineNo;

        public int? TranactionLineNo
        {
            get { return _tranactionLineNo; }
            set { _tranactionLineNo = value; }
        }
        private int? _tranactionLineNoSubLedger;

        public int? TranactionLineNoSubLedger
        {
            get { return _tranactionLineNoSubLedger; }
            set { _tranactionLineNoSubLedger = value; }
        }
        private int? _transactionMediaID;

        public int? TransactionMediaID
        {
            get { return _transactionMediaID; }
            set { _transactionMediaID = value; }
        }
        private string _tranactionLineStatus;

        public string TranactionLineStatus
        {
            get { return _tranactionLineStatus; }
            set { _tranactionLineStatus = value; }
        }
        private string _tranactionLineCalcStatus;

        public string TranactionLineCalcStatus
        {
            get { return _tranactionLineCalcStatus; }
            set { _tranactionLineCalcStatus = value; }
        }
        private int? _showInRpt;

        public int? ShowInRpt
        {
            get { return _showInRpt; }
            set { _showInRpt = value; }
        }
        private double? _rpCashAmount;

        public double? RpCashAmount
        {
            get { return _rpCashAmount; }
            set { _rpCashAmount = value; }
        }
        private double? _rpChequeAmount;

        public double? RpChequeAmount
        {
            get { return _rpChequeAmount; }
            set { _rpChequeAmount = value; }
        }
        private DataTable _dtVoucherJournalDetails;

        public DataTable DtVoucherJournalDetails
        {
            get { return _dtVoucherJournalDetails; }
            set { _dtVoucherJournalDetails = value; }
        }


        private DataTable _dtVoucherSubLedger;

        public DataTable DtVoucherSubLedger
        {
            get { return _dtVoucherSubLedger; }
            set { _dtVoucherSubLedger = value; }
        }
        private int _subLineNo;

        public int SubLineNo
        {
            get { return _subLineNo; }
            set { _subLineNo = value; }
        }
        private string _subLedgerNarration;

        public string SubLedgerNarration
        {
            get { return _subLedgerNarration; }
            set { _subLedgerNarration = value; }
        }
        private string _subLedgerTypeID1;

        public string SubLedgerTypeID1
        {
            get { return _subLedgerTypeID1; }
            set { _subLedgerTypeID1 = value; }
        }
        private string _subLedgerTypeID2;

        public string SubLedgerTypeID2
        {
            get { return _subLedgerTypeID2; }
            set { _subLedgerTypeID2 = value; }
        }
        private string _subLedgerTypeID3;

        public string SubLedgerTypeID3
        {
            get { return _subLedgerTypeID3; }
            set { _subLedgerTypeID3 = value; }
        }
        private string _subLedgerTypeID4;


        public string SubLedgerTypeID4
        {
            get { return _subLedgerTypeID4; }
            set { _subLedgerTypeID4 = value; }
        }
        private string _subLedgerTypeID5;

        public string SubLedgerTypeID5
        {
            get { return _subLedgerTypeID5; }
            set { _subLedgerTypeID5 = value; }
        }
        private int? _currencyID;

        public int? CurrencyID
        {
            get { return _currencyID; }
            set
            {
                if (value == null)
                {
                    throw new Exception(" Currency is required ");
                } _currencyID = value;
            }
        }
        private DataTable _dtSubmittedJournal;

        public DataTable DtSubmittedJournal
        {
            get { return _dtSubmittedJournal; }
            set { _dtSubmittedJournal = value; }
        }
        private DateTime? _journalDateFrom;

        public DateTime? JournalDateFrom
        {
            get { return _journalDateFrom; }
            set { _journalDateFrom = value; }
        }
        private DateTime? _JournalDateTo;

        public DateTime? JournalDateTo
        {
            get { return _JournalDateTo; }
            set { _JournalDateTo = value; }
        }
        private decimal? _baseAmountSearch;

        public decimal? BaseAmountSearch
        {
            get { return _baseAmountSearch; }
            set { _baseAmountSearch = value; }
        }
        private DataTable _dtVoucherHeader;

        public DataTable DtVoucherHeader
        {
            get { return _dtVoucherHeader; }
            set { _dtVoucherHeader = value; }
        }
        private string _searchVoucherNo;

        public string SearchVoucherNo
        {
            get { return _searchVoucherNo; }
            set { _searchVoucherNo = value; }
        }
        private string _searchUserVoucherNo;

        public string SearchUserVoucherNo
        {
            get { return _searchUserVoucherNo; }
            set { _searchUserVoucherNo = value; }
        }
        private decimal _subLegerAmountApart;

        public decimal SubLegerAmountApart
        {
            get { return _subLegerAmountApart; }
            set { _subLegerAmountApart = value; }
        }
    }
}