using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class ItemSetupController
    {
        internal void Save(string connectionString, ItemSetup objItemSetup)
        {
            try
            {
                var storedProcedureComandTest = "exec [spInitiatematMaterialSetup] " +
                                        objItemSetup.ItemCategoryID + "," +

                                        objItemSetup.CoaSalesRetAccNo + "'";
                StoredProcedureExecutor.StoredProcedureExecuteNonQuery(connectionString, storedProcedureComandTest);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}