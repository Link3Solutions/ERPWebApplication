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
                _objNodeList = new NodeList();
                _objNodeList.ActivityID = 0;
                _objNodeList.ActivityName = txtTitle.Text == string.Empty ? null : txtTitle.Text;
                _objNodeList.BranchID = Convert.ToInt32( Session["branchID"].ToString());
                _objNodeList.CompanyID = Convert.ToInt32(Session["companyID"].ToString());
                _objNodeList.FormDescription = txtDescription.Text == string.Empty ? null : txtDescription.Text;
                _objNodeList.FormName = txtFormURL.Text == string.Empty ? null : txtFormURL.Text;
                _objNodeList.NodeTypeID = 0;
                _objNodeList.ParentNodeTypeID = 0;
                _objNodeList.SeqNo = 0;
                _objNodeListController = new NodeListController();
                _objNodeListController.Save(_connectionString, _objNodeList);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
            
        }
    }
}