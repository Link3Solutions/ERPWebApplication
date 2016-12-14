using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;
using ERPWebApplication.AppClass.CommonClass;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ERPWebApplication.ModuleName.Organization.MasterPage
{
    public partial class TwoColumnTablesForm : System.Web.UI.Page
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();
        private TwoColumnTables _objTwoColumnTables;
        private TwoColumnTablesController _objTwoColumnTablesController;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["entryUserCode"] = "ADM";
                ShowRecord();

            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesToTables();
                ShowRecord();
                ClearControl();
            }
            catch (Exception msgException)
            {
                clsTopMostMessageBox.Show(msgException.Message);

            }

        }

        private void ClearControl()
        {
            try
            {
                txtTableName.Text = string.Empty;
                txtEntryMode.Text = string.Empty;
                txtRelatedTo.Text = string.Empty;

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void ShowRecord()
        {
            try
            {
                _objTwoColumnTablesController = new TwoColumnTablesController();
                DataTable dtRecord = _objTwoColumnTablesController.GetRecord(_connectionString);
                grdTwoColumnTables.DataSource = null;
                grdTwoColumnTables.DataBind();
                if (dtRecord.Rows.Count > 0)
                {
                    grdTwoColumnTables.DataSource = dtRecord;
                    grdTwoColumnTables.DataBind();
                }

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void AddValuesToTables()
        {
            try
            {
                _objTwoColumnTables = new TwoColumnTables();
                _objTwoColumnTables.TableName = txtTableName.Text == string.Empty ? null : txtTableName.Text;
                _objTwoColumnTables.EntryMode = txtEntryMode.Text == string.Empty ? null : txtEntryMode.Text;
                _objTwoColumnTables.RelatedTo = txtRelatedTo.Text == string.Empty ? null : txtRelatedTo.Text;
                _objTwoColumnTables.RelatedUserRoleID = ddlRelatedUserRoleID.SelectedValue == "-1" ? 0 : Convert.ToInt32(ddlRelatedUserRoleID.SelectedValue);
                _objTwoColumnTablesController = new TwoColumnTablesController();
                _objTwoColumnTablesController.Save(_connectionString, _objTwoColumnTables);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}