using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.Model;
using System.Data;
using ERPWebApplication.AppClass.CommonClass;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class TwoColumnsTableDataAutoController
    {
        public void Save(string connectionString, TwoColumnsTableDataAuto objTwoColumnsTableDataAuto)
        {
            try
            {
                DataTable dtDefaultData = new DataTable();
                var storedProcedureComandTestTemp = "";
                TwoColumnTables objTwoColumnTables = new TwoColumnTables();
                objTwoColumnTables.TableID = objTwoColumnsTableDataAuto.TableID;
                AutoTableData objAutoTableData = new AutoTableData(objTwoColumnTables);
                dtDefaultData = objAutoTableData.ControlTableID();
                foreach (DataRow dtRow in dtDefaultData.Rows)
                {
                    objTwoColumnsTableDataAuto.EieldOfID = dtRow[0].ToString();
                    objTwoColumnsTableDataAuto.FieldOfName = dtRow[1].ToString();

                    var storedProcedureComandTest = "INSERT INTO [TwoColumnsTableAuto] ([TableID], [FieldOfID], [FieldOfName], [DataUsed], [EntryUserID], [EntryDate]) VALUES ( " +
                                                 objTwoColumnsTableDataAuto.TableID + ",'" +
                                                 objTwoColumnsTableDataAuto.EieldOfID + "', '" +
                                                 objTwoColumnsTableDataAuto.FieldOfName + "', '" +
                                                 "A" + "', '" +
                                                 "160ea939-7633-46a8-ae49-f661d12abfd5" + "'," +
                                                 "CAST(GETDATE() AS DateTime));";
                    storedProcedureComandTestTemp += storedProcedureComandTest;
                }

                clsDataManipulation.StoredProcedureExecuteNonQuery(connectionString, storedProcedureComandTestTemp);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
    }
}