using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.Model;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class TwoColumnsTableDataController
    {
        public void Save(string connectionString, TwoColumnsTableData objTwoColumnsTableData)
        {
            try
            {
                var storedProcedureComandTest = "exec [ACT_TwoColumnsTable] " +
                                        objTwoColumnsTableData.CompanyID + "," +
                                        objTwoColumnsTableData.BranchID + "," +
                                        objTwoColumnsTableData.TableID + ",'" +
                                        0 + "','" +
                                        objTwoColumnsTableData.FieldOfName + "','" +
                                        objTwoColumnsTableData.FieldDescription + "','" +
                                        objTwoColumnsTableData.EntryUserName + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(connectionString, storedProcedureComandTest);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
 
        }
    }
}