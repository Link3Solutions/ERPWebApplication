using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.Model;
using ERPWebApplication.AppClass.DataAccess;

namespace ERPWebApplication.ModuleName.Organization.MasterPage
{
    public partial class NodeListForm : System.Web.UI.Page
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();
        private NodeList _objNodeList;
        private NodeListController _objNodeListController;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    PanelFormDetails.Visible = false;
                    Session["companyID"] = 1;
                    Session["branchID"] = 1;
                    lblParentText.Visible = false;
                    lblParentValue.Visible = false;
                    _objNodeListController = new NodeListController();
                    _objNodeListController.PopulateRootLevel(_connectionString, treeNodeList);
                    GetAllFormURL();

                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlType.SelectedValue == "4")
                {
                    PanelFormDetails.Visible = true;

                }
                else
                {
                    PanelFormDetails.Visible = false;
                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesOfNode();
                treeNodeList.Nodes.Clear();
                _objNodeListController = new NodeListController();
                _objNodeListController.PopulateRootLevel(_connectionString, treeNodeList);
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void AddValuesOfNode()
        {
            try
            {
                _objNodeListController = new NodeListController();
                _objNodeList = new NodeList();
                _objNodeList.ActivityID = Convert.ToInt32(ddlType.SelectedValue);
                _objNodeList.ActivityName = txtTitle.Text == string.Empty ? null : txtTitle.Text;
                _objNodeList.BranchID = Convert.ToInt32(Session["branchID"].ToString());
                _objNodeList.CompanyID = Convert.ToInt32(Session["companyID"].ToString());
                _objNodeList.FormDescription = txtDescription.Text == string.Empty ? null : txtDescription.Text;
                _objNodeList.FormName = ddlFormURL.SelectedValue == "-1" ? null : ddlFormURL.SelectedValue;
                _objNodeList.ParentNodeTypeID = lblParentValue.Text == string.Empty ? 111 : Convert.ToInt32(lblParentValue.Text);
                _objNodeList.SeqNo = _objNodeListController.GetSeqNo(_connectionString);
                _objNodeListController.Save(_connectionString, _objNodeList);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        protected void treeNodeList_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            try
            {
                _objNodeListController = new NodeListController();
                _objNodeListController.PopulateSubLevel(_connectionString, Int32.Parse(e.Node.Value), e.Node);
                treeNodeList.ExpandAll();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void treeNodeList_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                lblParentText.Text = treeNodeList.SelectedNode.Text;
                lblParentText.Visible = true;
                lblParentValue.Text = treeNodeList.SelectedNode.Value;
                txtTitle.Focus();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        public void GetAllFormURL()
        {
            string root = Server.MapPath("~");
            System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(root);
            System.IO.FileInfo[] files = info.GetFiles("*.aspx", System.IO.SearchOption.AllDirectories);

            string pageName = "";
            ddlFormURL.Items.Clear();
            ddlFormURL.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));
            foreach (System.IO.FileInfo fi in files)
            {
                pageName = fi.FullName.Replace(root, "~/").Replace("\\", "/");

                ListItem lst = new ListItem();
                lst.Value = pageName;
                lst.Text = fi.Name.ToString();
                ddlFormURL.Items.Add(lst);
            }

        }
    }
}