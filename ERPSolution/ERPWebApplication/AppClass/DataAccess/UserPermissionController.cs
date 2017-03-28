using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


namespace ERPWebApplication.AppClass.DataAccess
{
    public class UserPermissionController : DataAccessBase
    {
        internal DataTable GetData()
        {
            try
            {
                string sqlString = "SELECT [NodeTypeID], [ActivityName], [FormDescription], [FormName],[PNodeTypeID] FROM [uDefaultNodeList] ";
                var dtEntityDetails = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                return dtEntityDetails;

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
            
        }

        internal void PopulateRootLevel(TreeView TreeViewAllNode)
        {
            try
            {
                TreeViewAllNode.Nodes.Clear();
                TreeViewAllNode.ExpandAll();
                var sqlString = @"SELECT 111 as NodeTypeID,'Node List' as ActivityName,childnodecount = 
                                    (SELECT Count(*) FROM UDefaultNodeList  
                                    WHERE PNodeTypeID = 111)";
                var dt = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                PopulateNodes(dt, TreeViewAllNode.Nodes);

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
        public void PopulateSubLevel( int parentid, TreeNode parentNode)
        {
            try
            {
                var sqlString = @"select NodeTypeID,ActivityName,(select count(*) FROM UDefaultNodeList WHERE PNodeTypeID=e.NodeTypeID) childnodecount FROM UDefaultNodeList e where PNodeTypeID= " + parentid + "";
                var dt = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                PopulateNodes(dt, parentNode.ChildNodes);
                parentNode.CollapseAll();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadRoleTypeData(DropDownList ddlRoleType)
        {
            try
            {
                TwoColumnsTableDataController objTwoColumnsTableDataController = new TwoColumnsTableDataController();
                objTwoColumnsTableDataController.LoadRoleType(ddlRoleType);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        internal void SaveRoleData(CompanySetup objCompanySetup, UserPermission objUserPermission)
        {
            try
            {
                objUserPermission.RoleID = GetRoleID();
                var storedProcedureComandText = "INSERT INTO [uRoleSetup] ([CompanyID],[RoleID],[RoleTypeID],[RoleName],[DataUsed],[EntryUserID],[EntryDate]) VALUES ( " +
                                                 objCompanySetup.CompanyID + "," +
                                                 objUserPermission.RoleID + "," +
                                                 objUserPermission.RoleType+",'"+
                                                 objUserPermission.RoleName+"','"+
                                                 "A" + "', '" +
                                                 objCompanySetup.EntryUserName + "'," +
                                                 "CAST(GETDATE() AS DateTime));";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

                foreach (var itemNo in objUserPermission.nodeList)
                {
                    objUserPermission.NodeID = Convert.ToInt32( itemNo.ToString());
                    var storedProcedureComandTextNode = "INSERT INTO [uRoleSetupDetails] ([RoleID],[NodeID],[DataUsed],[EntryUserID],[EntryDate]) VALUES ( " +
                                                 objUserPermission.RoleID + "," +
                                                 objUserPermission.NodeID + ",'" +
                                                 "A" + "', '" +
                                                 objCompanySetup.EntryUserName + "'," +
                                                 "CAST(GETDATE() AS DateTime));";
                    clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTextNode);
                    
                }

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private int GetRoleID()
        {
            try
            {
                UserPermission objUserPermission = new UserPermission();
                var storedProcedureComandText = "SELECT ISNULL( MAX( RoleID ),0) +1 FROM [uRoleSetup]";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                return objUserPermission.RoleID = objclsDataManipulation.GetSingleValue(this.ConnectionString, storedProcedureComandText);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}