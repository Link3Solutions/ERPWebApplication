using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebApplication.ModuleName.Inventory.MasterPage
{
    public partial class ItemCategorySetupForm : System.Web.UI.Page
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();
        private ItemCategorySetup _objItemCategorySetup;
        private ItemCategorySetupController _objItemCategorySetupController;
        private ItemSetup _objItemSetup;
        private ItemSetupController _objItemSetupController;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["company"] = 1;
                Session["branch"] = 1;
                Session["entryUserCode"] = "ADM";
                PanelItemSetup.Visible = false;
                PopulateRootLevel();
                LoadCategory(ddlCategory);
                LoadCategory(ddlParentCategory);

            }
        }

        private void LoadCategory(DropDownList ddlCategory)
        {
            try
            {
                _objItemCategorySetupController = new ItemCategorySetupController();
                _objItemCategorySetupController.GetCategory(_connectionString, ddlCategory);
                if (TreeViewCategory.Nodes.Count > 0)
                {
                    ddlCategory.Items.RemoveAt(0);
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void PopulateRootLevel()
        {
            try
            {
                var myConnection = new SqlConnection(_connectionString);
                var command = new SqlCommand("SELECT ItemCategoryID,CategoryName," +
                "childnodecount = (SELECT Count(*) FROM matCategoryList WHERE ParentCategoryID = D.ItemCategoryID) " +
                "FROM matCategoryList D WHERE ParentCategoryID = 1", myConnection);
                var da = new SqlDataAdapter(command);
                var dt = new DataTable();
                da.Fill(dt);
                PopulateNodes(dt, TreeViewCategory.Nodes);

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
                    var tn = new TreeNode(dr["CategoryName"].ToString(), dr["ItemCategoryID"].ToString());
                    nodes.Add(tn);
                    tn.PopulateOnDemand = (int.Parse(dr["childnodecount"].ToString()) > 0);
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void PopulateSubLevel(int parentid, TreeNode parentNode)
        {
            try
            {
                var myConnection = new SqlConnection(_connectionString);
                var objCommand = new SqlCommand(@"select ItemCategoryID,CategoryName,(select count(*) FROM matCategoryList WHERE ParentCategoryID=e.ItemCategoryID) childnodecount FROM matCategoryList e where ParentCategoryID=@ParentCategoryID", myConnection);
                objCommand.Parameters.Add("@ParentCategoryID", SqlDbType.Int).Value = parentid;
                var da = new SqlDataAdapter(objCommand);
                var dt = new DataTable();
                da.Fill(dt);
                PopulateNodes(dt, parentNode.ChildNodes);
                TreeViewCategory.CollapseAll();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        public int CreateCategoryID()
        {
            string categoryID;
            int parentCategoryID = ddlParentCategory.SelectedValue == "-1" ? 1 : Convert.ToInt32(ddlParentCategory.SelectedValue);
            categoryID = Session["company"].ToString() + Session["branch"].ToString() + GetSeqNo(parentCategoryID) + GetTierNo(parentCategoryID);
            return Convert.ToInt32(categoryID);

        }
        private int GetTierNo(int parentAccNo)
        {
            try
            {
                var storedProcedureComandTest = "exec [spGetTierNumber] " + parentAccNo + "";
                var dtTierNo = StoredProcedureExecutor.StoredProcedureExecuteReader(_connectionString, storedProcedureComandTest);
                int tierNumber = Convert.ToInt32(dtTierNo.Rows[0][0].ToString());
                Session["tierNumber"] = tierNumber;
                return tierNumber;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        private int GetSeqNo(int parentAccount)
        {
            try
            {
                var storedProcedureComandTest = "exec [spGetNodeSeqNo] " + parentAccount + " ";
                var dtSeqNo = StoredProcedureExecutor.StoredProcedureExecuteReader(_connectionString, storedProcedureComandTest);
                int sequenceNumber = Convert.ToInt32(dtSeqNo.Rows[0][0].ToString());
                Session["sequenceNumber"] = sequenceNumber;
                return sequenceNumber;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        protected void CheckBoxAddItem_CheckedChanged(object sender, EventArgs e)
        {

            if (CheckBoxAddItem.Checked == true)
            {
                PanelBody.Visible = false;
                PanelItemSetup.Visible = true;
                PanelLeft.Visible = false;
                PanelRight.Visible = false;
                txtItemCode.Focus();
            }
            else
            {
                PanelBody.Visible = true;
                PanelLeft.Visible = true;
                PanelRight.Visible = true;
                PanelItemSetup.Visible = false;

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxAddItem.Checked == true)
                {
                    SaveItem();

                }
                else
                {
                    AddValuesToCategory();

                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        private void SaveItem()
        {
            try
            {
                _objItemSetup = new ItemSetup();
                _objItemSetup.ItemCategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                _objItemSetup.Specification = txtDescription.Text == string.Empty ? null : txtDescription.Text;
                _objItemSetup.HsCode = txtHSCode.Text == string.Empty ? null : txtHSCode.Text;
                _objItemSetup.IsVATAbleItem = CheckBoxIsVATPayable.Checked == true ? true : false;
                _objItemSetup.SupplierID = ddlRelatedSupplier.SelectedValue == "-1" ? null : ddlRelatedSupplier.SelectedValue;
                _objItemSetup.OpenningBalance = txtOpeningBalance.Text == string.Empty ? -1 : Convert.ToInt32(txtOpeningBalance.Text);
                _objItemSetup.CoaSalesAccNo = Convert.ToInt32(ddlSalesAccountNo.SelectedValue);
                _objItemSetup.CoaStockAccNo = Convert.ToInt32(ddlStockAccountNo.SelectedValue);
                _objItemSetup.CoacgsAccNo = Convert.ToInt32(ddlCOGSAccountNo.SelectedValue);
                _objItemSetup.CoaSalesRetAccNo = Convert.ToInt32(ddlSalesReturnAccount.SelectedValue);
                _objItemSetup.EntryUserName = Session["entryUserCode"].ToString();

                _objItemSetupController = new ItemSetupController();
                _objItemSetupController.Save(_connectionString, _objItemSetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void AddValuesToCategory()
        {
            try
            {
                _objItemCategorySetup = new ItemCategorySetup();
                _objItemCategorySetup.CompanyID = Convert.ToInt32(Session["company"].ToString());
                _objItemCategorySetup.BranchID = Convert.ToInt32(Session["branch"].ToString());
                _objItemCategorySetup.CategoryTypeID = Convert.ToInt32(ddlProductType.SelectedValue);
                _objItemCategorySetup.ItemCategoryID = CreateCategoryID();
                _objItemCategorySetup.CategoryName = txtCategoryName.Text == string.Empty ? null : txtCategoryName.Text;
                _objItemCategorySetup.ParentCategoryID = ddlParentCategory.SelectedValue == "-1" ? 1 : Convert.ToInt32(ddlParentCategory.SelectedValue);
                _objItemCategorySetup.StartingItemCode = 0;
                _objItemCategorySetup.EndingItemCode = 0;
                _objItemCategorySetup.SeqNo = Convert.ToInt32(Session["sequenceNumber"].ToString());
                _objItemCategorySetup.TierNo = Convert.ToInt32(Session["tierNumber"].ToString());
                _objItemCategorySetup.CurrentBalance = 0;
                _objItemCategorySetup.DataUsed = "A";
                _objItemCategorySetup.EntryUserName = Session["entryUserCode"].ToString();
                _objItemCategorySetupController = new ItemCategorySetupController();
                _objItemCategorySetupController.Save(_connectionString, _objItemCategorySetup);
                ClearCategory();
                TreeViewCategory.Nodes.Clear();
                PopulateRootLevel();
                LoadCategory(ddlCategory);
                LoadCategory(ddlParentCategory);

            }
            catch (SqlException msgException)
            {
                throw msgException;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void ClearCategory()
        {
            txtCategoryName.Text = string.Empty;
        }

        protected void TreeViewCategory_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            PopulateSubLevel(Int32.Parse(e.Node.Value), e.Node);
        }

        protected void TreeViewCategory_SelectedNodeChanged(object sender, EventArgs e)
        {
            int itemCategoryID = Convert.ToInt32(TreeViewCategory.SelectedNode.Value);
            txtCategoryName.Focus();
            ddlParentCategory.SelectedValue = itemCategoryID.ToString(); ;
        }
    }
}