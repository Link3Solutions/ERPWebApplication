using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.Model;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class NodeListController
    {
        public void Save(string connectionString, NodeList objNodeList)
        {
            try
            {
                var storedProcedureComandText = "INSERT INTO [suDefaultNodeList] ([CompanyID],[BranchID],[ActivityID],[ActivityName],[SeqNo],[NodeTypeID],[PNodeTypeID]" +
                                            " ,[FormDescription],[FormName],[DataUsed],[EntryUserID],[EntryDate]) VALUES ( " +
                                                 objNodeList.CompanyID + "," +
                                                 objNodeList.BranchID + ", " +
                                                 objNodeList.ActivityID + ", '" +
                                                 objNodeList.ActivityName + "', " +
                                                 objNodeList.SeqNo + ", " +
                                                 objNodeList.NodeTypeID + ", " +
                                                 objNodeList.ParentNodeTypeID + ", '" +
                                                 objNodeList.FormDescription + "', '" +
                                                 objNodeList.FormName + "', '" +
                                                 "A" + "', '" +
                                                 "160ea939-7633-46a8-ae49-f661d12abfd5" + "'," +
                                                 "CAST(GETDATE() AS DateTime));";
                clsDataManipulation.StoredProcedureExecuteNonQuery(connectionString, storedProcedureComandText);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}