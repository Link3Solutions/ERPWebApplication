using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class MatItemTransactionWithAll
    {

        public MatItemTransactionWithAll()
        { 
        }
        #region private variable

        private int matTransID;
        private int itemID;
        private int itemReceivedAs;
        private int godownID;
        private int unitID;
        private double quantity;
        private decimal rate;
        private decimal otherRate;
        private double otherQuantity;
        private int currencyID;
        private decimal discount;
        private decimal vatAmount;
        private string specification;
        private int delevaryStatus;
        private double barCodeCreated;
        private double extra;

       #endregion

        #region publick variable

        public int MatTransID
        {
            get { return matTransID; }
            set { matTransID = value; }
        }    
        public int ItemID
        {
            get { return itemID; }
            set
            {
                if (value == -1)
                {
                    throw new Exception("please select item Id");
                }

                itemID = value;
            }
        }     
        public int ItemReceivedAs
        {
            get { return itemReceivedAs; }
            set { itemReceivedAs = value; }
        }      
        public int GodownID
        {
            get { return godownID; }
            set { godownID = value; }
        }     
        public int UnitID
        {
            get { return unitID; }
            set
            {
                if (value == -1)
                {
                    throw new Exception("please select item ID");
                }

                unitID = value;
            }
        }    
        public double Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }        
        public decimal Rate
        {
            get { return rate; }
            set { rate = value; }
        }
        public decimal OtherRate
        {
            get { return otherRate; }
            set { otherRate = value; }
        }
        public double OtherQuantity
        {
            get { return otherQuantity; }
            set { otherQuantity = value; }
        }
        public int CurrencyID
        {
            get { return currencyID; }
            set { currencyID = value; }
        }
        public decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        public decimal VatAmount
        {
            get { return vatAmount; }
            set { vatAmount = value; }
        }
        public string Specification
        {
            get { return specification; }
            set { specification = value; }
        }
        public int DelevaryStatus
        {
            get { return delevaryStatus; }
            set { delevaryStatus = value; }
        }
        public double BarCodeCreated
        {
            get { return barCodeCreated; }
            set { barCodeCreated = value; }
        }
        public double Extra
        {
            get { return extra; }
            set { extra = value; }
        }

        #endregion
    }
}