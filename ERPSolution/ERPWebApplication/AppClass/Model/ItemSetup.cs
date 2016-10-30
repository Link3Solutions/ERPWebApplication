﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class ItemSetup
    {
        private int _itemID;

        public int ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }
        private int _itemCategoryID;

        public int ItemCategoryID
        {
            get { return _itemCategoryID; }
            set { _itemCategoryID = value; }
        }
        private int _unitID;

        public int UnitID
        {
            get { return _unitID; }
            set { _unitID = value; }
        }
        private string _hsCode;

        public string HsCode
        {
            get { return _hsCode; }
            set { _hsCode = value; }
        }
        private string _specification;

        public string Specification
        {
            get { return _specification; }
            set { _specification = value; }
        }
        private int _openningBalance;

        public int OpenningBalance
        {
            get { return _openningBalance; }
            set { _openningBalance = value; }
        }
        private string _supplierID;

        public string SupplierID
        {
            get { return _supplierID; }
            set { _supplierID = value; }
        }
        private bool _isVATAbleItem;

        public bool IsVATAbleItem
        {
            get { return _isVATAbleItem; }
            set { _isVATAbleItem = value; }
        }
        private int _coaSalesAccNo;

        public int CoaSalesAccNo
        {
            get { return _coaSalesAccNo; }
            set { _coaSalesAccNo = value; }
        }
        private int _coaStockAccNo;

        public int CoaStockAccNo
        {
            get { return _coaStockAccNo; }
            set { _coaStockAccNo = value; }
        }
        private int _coacgsAccNo;

        public int CoacgsAccNo
        {
            get { return _coacgsAccNo; }
            set { _coacgsAccNo = value; }
        }
        private int _coaSalesRetAccNo;

        public int CoaSalesRetAccNo
        {
            get { return _coaSalesRetAccNo; }
            set { _coaSalesRetAccNo = value; }
        }
        private string _entryUserName;

        public string EntryUserName
        {
            get { return _entryUserName; }
            set { _entryUserName = value; }
        }

    }
}