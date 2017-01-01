using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.Model;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class NodeListController
    {
        public void Save(string connectionString, NodeList objNodeList)
        {
            try
            {
                objNodeList.NodeTypeID = Convert.ToInt32(objNodeList.CompanyID.ToString() + objNodeList.BranchID.ToString());
                if (objNodeList.ActivityID == 4)
                {
                    objNodeList.NodeTypeID = Convert.ToInt32(objNodeList.NodeTypeID.ToString() + GetSeqNoForForm(connectionString).ToString());
                }
                else
                {
                    objNodeList.NodeTypeID = Convert.ToInt32(objNodeList.NodeTypeID.ToString() + GetSeqNoForModule(connectionString).ToString());

                }

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
        public int GetSeqNo(string connectionString)
        {
            try
            {
                int seqNo = 0;
                var storedProcedureComandText = "SELECT ISNULL( MAX( [SeqNo]),0) +1  FROM [suDefaultNodeList]";
                seqNo = clsDataManipulation.GetMaximumValueUsingSQL(connectionString, storedProcedureComandText);
                return seqNo;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        public string GetSeqNoForForm(string connectionString)
        {
            try
            {
                string seqNo = null;
                var storedProcedureComandText = @" DECLARE @RefNumber VARCHAR(10),@countData INT
                                              SET @countData = ( SELECT ISNULL( MAX( [SeqNo]),0) +1  FROM [suDefaultNodeList])
                                              SET @RefNumber=STUFF('0000',5-LEN(@countData),20,@countData)
                                              SELECT @RefNumber";
                var dtSeq = clsDataManipulation.GetData(connectionString, storedProcedureComandText);
                foreach (DataRow item in dtSeq.Rows)
                {
                    seqNo = item.ItemArray[0].ToString();

                }
                return seqNo;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        public string GetSeqNoForModule(string connectionString)
        {
            try
            {
                string seqNo = null;
                var storedProcedureComandText = @" DECLARE @RefNumber VARCHAR(10),@countData INT
                                              SET @countData = ( SELECT ISNULL( MAX( [SeqNo]),0) +1  FROM [suDefaultNodeList])
                                              SET @RefNumber=STUFF('000',4-LEN(@countData),20,@countData)
                                              SELECT @RefNumber";
                var dtSeq = clsDataManipulation.GetData(connectionString, storedProcedureComandText);
                foreach (DataRow item in dtSeq.Rows)
                {
                    seqNo = item.ItemArray[0].ToString();

                }
                return seqNo;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        public void PopulateRootLevel(string connectionString, TreeView objTreeView)
        {
            try
            {
                var myConnection = new SqlConnection(connectionString);
                var command = new SqlCommand("SELECT NodeTypeID,ActivityName," +
                "childnodecount = (SELECT Count(*) FROM suDefaultNodeList WHERE PNodeTypeID = D.NodeTypeID) " +
                "FROM suDefaultNodeList D WHERE PNodeTypeID = 111", myConnection);
                var da = new SqlDataAdapter(command);
                var dt = new DataTable();
                da.Fill(dt);
                PopulateNodes(dt, objTreeView.Nodes);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private void PopulateNodes(DataTable dt, TreeNodeCollection nodes)
        {
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var tn = new TreeNode(dr["ActivityName"].ToString(), dr["NodeTypeID"].ToString());
                    nodes.Add(tn);
                    tn.PopulateOnDemand = (int.Parse(dr["childnodecount"].ToString()) > 0);
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        public void PopulateSubLevel(string connectionString, int parentid, TreeNode parentNode)
        {
            try
            {
                var myConnection = new SqlConnection(connectionString);
                var objCommand = new SqlCommand(@"select NodeTypeID,ActivityName,(select count(*) FROM suDefaultNodeList WHERE PNodeTypeID=e.NodeTypeID) childnodecount FROM suDefaultNodeList e where PNodeTypeID=@PNodeTypeID", myConnection);
                objCommand.Parameters.Add("@PNodeTypeID", SqlDbType.Int).Value = parentid;
                var da = new SqlDataAdapter(objCommand);
                var dt = new DataTable();
                da.Fill(dt);
                PopulateNodes(dt, parentNode.ChildNodes);
                parentNode.CollapseAll();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}