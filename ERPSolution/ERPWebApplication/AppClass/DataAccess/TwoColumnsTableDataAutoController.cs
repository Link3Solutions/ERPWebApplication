using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.Model;
using System.Data;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class TwoColumnsTableDataAutoController
    {
        public void Save(string connectionString, TwoColumnsTableDataAuto objTwoColumnsTableDataAuto)
        {
            try
            {
                DataTable dtDefaultData = new DataTable();
                var storedProcedureComandTest = "";
                foreach (DataRow dtRow in dtDefaultData.Rows)
                {
                    storedProcedureComandTest = "INSERT INTO [TwoColumnsTableAuto] ([TableID], [FieldOfID], [FieldOfName], [DataUsed], [EntryUserID], [EntryDate]) VALUES ( " +
                                                 objTwoColumnsTableDataAuto.TableID + ",'" +
                                                 objTwoColumnsTableDataAuto.EieldOfID + "', '" +
                                                 objTwoColumnsTableDataAuto.FieldOfName + "', '" +
                                                 "A" + "', '" +
                                                 "160ea939-7633-46a8-ae49-f661d12abfd5" + "'," +
                                                 "CAST(GETDATE() AS DateTime));";
                }
                
                clsDataManipulation.StoredProcedureExecuteNonQuery(connectionString, storedProcedureComandTest);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
    }
}