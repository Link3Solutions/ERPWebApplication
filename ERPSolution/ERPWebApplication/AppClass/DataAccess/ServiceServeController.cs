using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.Model;
using ERPWebApplication.AppClass.CommonClass;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class ServiceServeController : DataAccessBase
    {
        internal void ServeClientNode(ServiceServe objServiceServe, UserList objUserList)
        {
            try
            {

                DataTable dtClientNode = GetNodesOfService(objServiceServe);
                var storedProcedureComandText = SqlClientNode(dtClientNode, objServiceServe, objUserList);
                if (storedProcedureComandText == null)
                {
                    throw new Exception(clsMessages.GEverythingUptoDate);
                }
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlClientNode(DataTable dtClientNode, ServiceServe objServiceServe, UserList objUserList)
        {
            try
            {
                NodeList objNodeList = new NodeList();
                string storedProcedureComandTextDetails = null;
                if (dtClientNode != null)
                {
                    foreach (DataRow rowNo in dtClientNode.Rows)
                    {
                        objNodeList.ActivityID = Convert.ToInt32(rowNo["ActivityID"].ToString());
                        objNodeList.ActivityName = rowNo["ActivityName"].ToString();
                        objNodeList.SeqNo = Convert.ToInt32(rowNo["SeqNo"].ToString());
                        objNodeList.FormDescription = rowNo["FormDescription"].ToString();
                        objNodeList.NodeTypeID = Convert.ToInt32(rowNo["NodeTypeID"].ToString());
                        objNodeList.ParentNodeTypeID = Convert.ToInt32(rowNo["PNodeTypeID"].ToString());
                        objNodeList.FormName = rowNo["FormName"].ToString();
                        objNodeList.ShowPosition = Convert.ToInt32(rowNo["ShowPosition"].ToString());

                        var storedProcedureComandTextDetailsTemp = @"INSERT INTO [uDefaultNodeList]
                   ([CompanyID]
                   ,[BranchID]
                   ,[ActivityID]
                   ,[ActivityName]
                   ,[SeqNo]
                   ,[NodeTypeID]
                   ,[PNodeTypeID]
                   ,[FormDescription]
                   ,[FormName]
                   ,[ShowPosition]
                   ,[DataUsed]
                   ,[EntryUserID]
                   ,[EntryDate]           
                   ,[UserID]
                           )
                     VALUES
                   (" + objServiceServe.CompanyID + ""
                       + "," + 1 + ""
                       + "," + objNodeList.ActivityID + ""
                       + ",'" + objNodeList.ActivityName + "'"
                       + "," + objNodeList.SeqNo + ""
                       + "," + objNodeList.NodeTypeID + ""
                       + "," + objNodeList.ParentNodeTypeID + ""
                       + ",'" + objNodeList.FormDescription + "'"
                       + ",'" + objNodeList.FormName + "'"
                       + "," + objNodeList.ShowPosition + ""
                       + ",'" + "A" + "'"
                       + ",'" + objServiceServe.EntryUserName + "'"
                       + "," + "CAST(GETDATE() AS DateTime)" + ""
                       + ",'" + objUserList.UserName + "'"
                       + ");";
                        storedProcedureComandTextDetails += storedProcedureComandTextDetailsTemp;

                    }
                }

                return storedProcedureComandTextDetails;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private DataTable GetNodesOfService(ServiceServe objServiceServe)
        {
            try
            {
                DataTable dtNodes = null;
                var storedProcedureComandText = @"SELECT DISTINCT A.ServiceID,B.NodeTypeID,C.[ActivityID],C.[ActivityName],C.[SeqNo],C.[NodeTypeID],C.[PNodeTypeID],C.[FormDescription],C.[FormName],C.[ShowPosition]  FROM sysServiceHeader A
                INNER JOIN sysServiceDetails B ON A.ServiceInformatioID = B.ServiceInformatioID
                INNER JOIN sysProductOwnerNodeList C ON B.NodeTypeID = C.NodeTypeID
                WHERE A.DataUsed = 'A' AND B.DataUsed = 'A' AND C.DataUsed='A' AND A.ServiceID IN (" + objServiceServe.ServiceList + ")" +
                " AND B.NodeTypeID NOT IN ( SELECT D.NodeTypeID FROM uDefaultNodeList D WHERE D.DataUsed = 'A' AND D.CompanyID = " + objServiceServe.CompanyID + ")";
                dtNodes = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtNodes;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}