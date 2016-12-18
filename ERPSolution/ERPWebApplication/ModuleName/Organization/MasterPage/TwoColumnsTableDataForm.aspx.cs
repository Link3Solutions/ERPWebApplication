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
using System.Data;

namespace ERPWebApplication.ModuleName.Organization.MasterPage
{
    public partial class TwoColumnsTableDataForm : System.Web.UI.Page
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();
        private TwoColumnTables _objTwoColumnTables;
        private TwoColumnTablesController _objTwoColumnTablesController;
        private TwoColumnsTableData _objTwoColumnsTableData;
        private TwoColumnsTableDataController _objTwoColumnsTableDataController;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Session["relatedUserRoleID"] = 1;
                    Session["entryUserCode"] = 1;
                    Session["companyID"] = 1;
                    Session["branchID"] = 1;
                    ShowsysTwoColumnTables();
                }

            }
            catch (Exception msgException)
            {
                clsTopMostMessageBox.Show(msgException.Message);

            }

        }

        private void ShowsysTwoColumnTables()
        {
            try
            {
                _objTwoColumnTables = new TwoColumnTables();
                _objTwoColumnTables.RelatedUserRoleID = Convert.ToInt32(Session["relatedUserRoleID"].ToString());
                _objTwoColumnTablesController = new TwoColumnTablesController();
                DataTable dtTablesName = _objTwoColumnTablesController.GetRecord(_connectionString, _objTwoColumnTables);
                grdTableName.DataSource = null;
                grdTableName.DataBind();
                if (dtTablesName.Rows.Count > 0)
                {
                    grdTableName.DataSource = dtTablesName;
                    grdTableName.DataBind();

                }

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }

        }

        protected void grdTableName_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';this.style.color='blue';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.color='black';";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.grdTableName, "Select$" + e.Row.RowIndex);
            }
            e.Row.Cells[1].Visible = false;
        }

        protected void grdTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = grdTableName.SelectedIndex;
                string lblTableID = ((Label)grdTableName.Rows[selectedIndex].FindControl("lblTableID")).Text;
                string lblTableName = ((Label)grdTableName.Rows[selectedIndex].FindControl("lblTableName")).Text;
                lblSelectedTableName.Text = lblTableName;
                txtFieldOfName.Focus();
                Session["tableID"] = lblTableID;

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
                AddValuesToTablesData();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void AddValuesToTablesData()
        {
            try
            {
                _objTwoColumnsTableData = new TwoColumnsTableData();
                _objTwoColumnsTableData.CompanyID = Convert.ToInt32(Session["companyID"].ToString());
                _objTwoColumnsTableData.BranchID = Convert.ToInt32(Session["branchID"].ToString());
                _objTwoColumnsTableData.TableID = Convert.ToInt32(Session["tableID"].ToString());
                _objTwoColumnsTableData.FieldOfName = txtFieldOfName.Text == string.Empty ? null : txtFieldOfName.Text;
                _objTwoColumnsTableData.FieldDescription = txtFieldDescription.Text == string.Empty ? null : txtFieldDescription.Text;
                _objTwoColumnsTableData.EntryUserName = Session["entryUserCode"].ToString();
                _objTwoColumnsTableDataController = new TwoColumnsTableDataController();
                _objTwoColumnsTableDataController.Save(_connectionString, _objTwoColumnsTableData);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

    }
}