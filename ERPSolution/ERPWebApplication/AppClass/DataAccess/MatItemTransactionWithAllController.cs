using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class MatItemTransactionWithAllController : DataAccessBase
    {
        public MatItemTransactionWithAllController()
        {}

        public bool InsertMatItemTransactionWithAll(MatItemTransactionWithAll objTrnAll)
        {
            string sql = "";
            bool retflag = true;

            sql = "INSERT INTO [MatItemTransactionWithAll] ([MatTransID], [ItemID], [ItemReceivedAs], [GodownID], [UnitID], [Quantity], [Rate], [OtherRate], [OtherQuantity], [CurrencyID], [Discount], [VatAmount], [Specification], [DelevaryStatus], [BarCodeCreated], [Extra]) VALUES('" + objTrnAll.MatTransID + "','" + objTrnAll.ItemID + "','" + objTrnAll.ItemReceivedAs + "','" + objTrnAll.GodownID + "','" + objTrnAll.UnitID + "','" + objTrnAll.Quantity + "','" + objTrnAll.Rate + "','" + objTrnAll.OtherRate + "','" + objTrnAll.OtherQuantity + "','" + objTrnAll.CurrencyID + "','" + objTrnAll.Discount + "','" + objTrnAll.VatAmount + "','" + objTrnAll.Specification + "','" + objTrnAll.DelevaryStatus + "','" + objTrnAll.BarCodeCreated + "','" + objTrnAll.Extra + "')";

            return retflag;

        }

        public DataTable GetDataAllMatItemTransactionWithAll()
        {
            try
            {
                DataTable dtAll = null;

                var storedProcedureComandText = "SELECT   MatTransID, ItemID, ItemReceivedAs, GodownID, UnitID, Quantity, Rate, OtherRate, OtherQuantity,"
                + " CurrencyID, Discount, VatAmount, Specification, DelevaryStatus, BarCodeCreated, Extra FROM MatItemTransactionWithAll";

                dtAll = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtAll;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        public DataTable GetDataByTrnsIdMatItemTransactionWithAll(MatItemTransactionWithAll objTrnAll)
        {
            try
            {
                DataTable dtAllId = null;

                var storedProcedureComandText = "SELECT   MatTransID, ItemID, ItemReceivedAs, GodownID, UnitID, Quantity, Rate, OtherRate, OtherQuantity,"
                + " CurrencyID, Discount, VatAmount, Specification, DelevaryStatus, BarCodeCreated, Extra FROM MatItemTransactionWithAll where MatTransID='" + objTrnAll.MatTransID+ "'";

                dtAllId = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtAllId;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        public DataTable GetDataByItmIddMatItemTransactionWithAll(MatItemTransactionWithAll objTrnAll)
        {
            try
            {
                DataTable dtAllId = null;

                var storedProcedureComandText = "SELECT   MatTransID, ItemID, ItemReceivedAs, GodownID, UnitID, Quantity, Rate, OtherRate, OtherQuantity,"
                + " CurrencyID, Discount, VatAmount, Specification, DelevaryStatus, BarCodeCreated, Extra FROM MatItemTransactionWithAll where MatTransID='" + objTrnAll.ItemID + "'";

                dtAllId = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtAllId;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

    }
}