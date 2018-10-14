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
        private RelatedUserRole _objRelatedUserRole;
        private RelatedUserRoleController _objRelatedUserRoleController;
        private CompanySetup _objCompanySetup;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Session["entryUserCode"] = "ADM";
                    ShowRecord();
                    _objTwoColumnTablesController.LoadRelatedUserRoleDDL(ddlRelatedUserRoleID);
                    PanelTwoColumnTable.Visible = true;
                    PanelRelatedRole.Visible = false;
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
                btnSave.Text = "Save";
                ddlEntrySystem.SelectedValue = "-1";
                ddlRelatedUserRoleID.SelectedValue = "-1";

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
                _objTwoColumnTables.EntrySystem = ddlEntrySystem.SelectedValue == "-1" ? null : ddlEntrySystem.SelectedValue;
                _objTwoColumnTablesController = new TwoColumnTablesController();
                if (btnSave.Text == "Save")
                {
                    _objTwoColumnTablesController.Save(_connectionString, _objTwoColumnTables);

                }
                else
                {
                    _objTwoColumnTables.TableID = Convert.ToInt32(Session["selectedIndex"].ToString());
                    _objTwoColumnTablesController.Update(_connectionString, _objTwoColumnTables);
                }


            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void grdTwoColumnTables_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string lblTableID = ((Label)grdTwoColumnTables.Rows[selectedIndex].FindControl("lblTableID")).Text;
            if (e.CommandName.Equals("Select"))
            {
                try
                {
                    string lblTableName = ((Label)grdTwoColumnTables.Rows[selectedIndex].FindControl("lblTableName")).Text;
                    string lblEntryMode = ((Label)grdTwoColumnTables.Rows[selectedIndex].FindControl("lblEntryMode")).Text;
                    string lblRelatedTo = ((Label)grdTwoColumnTables.Rows[selectedIndex].FindControl("lblRelatedTo")).Text;
                    string lblEntrySystem = ((Label)grdTwoColumnTables.Rows[selectedIndex].FindControl("lblEntrySystem")).Text;
                    string lblRelatedUserRoleID = ((Label)grdTwoColumnTables.Rows[selectedIndex].FindControl("lblRelatedUserRoleID")).Text;
                    txtTableName.Text = lblTableName;
                    txtEntryMode.Text = lblEntryMode;
                    txtRelatedTo.Text = lblRelatedTo;
                    ddlRelatedUserRoleID.SelectedValue = lblRelatedUserRoleID;
                    ddlEntrySystem.SelectedValue = lblEntrySystem;
                    btnSave.Text = "Update";
                    Session["selectedIndex"] = lblTableID;
                }
                catch (Exception msgException)
                {

                    clsTopMostMessageBox.Show(msgException.Message);
                }
            }
            else if (e.CommandName.Equals("Delete"))
            {
                try
                {
                    _objTwoColumnTables = new TwoColumnTables();
                    _objTwoColumnTables.TableID = Convert.ToInt32(lblTableID);
                    _objTwoColumnTablesController = new TwoColumnTablesController();
                    _objTwoColumnTablesController.Delete(_connectionString, _objTwoColumnTables);
                    ShowRecord();

                }
                catch (Exception msgException)
                {

                    clsTopMostMessageBox.Show(msgException.Message);
                }


            }
        }

        protected void grdTwoColumnTables_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[7].Visible = false;
        }

        protected void grdTwoColumnTables_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControl();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            try
            {
                PanelRelatedRole.Visible = true;
                PanelTwoColumnTable.Visible = false;
                LoadRelatedUserRole();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void LoadRelatedUserRole()
        {
            try
            {
                _objRelatedUserRoleController = new RelatedUserRoleController();
                _objRelatedUserRole = new RelatedUserRole();
                _objRelatedUserRole.DtRelatedRole = _objRelatedUserRoleController.GetRelatedUserRole();
                grdRelatedUserRole.DataSource = null;
                grdRelatedUserRole.DataBind();
                if (_objRelatedUserRole.DtRelatedRole != null)
                {
                    grdRelatedUserRole.DataSource = _objRelatedUserRole.DtRelatedRole;
                    grdRelatedUserRole.DataBind();
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnCancelRelatedRole_Click(object sender, EventArgs e)
        {
            try
            {
                PanelTwoColumnTable.Visible = true;
                PanelRelatedRole.Visible = false;
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnSaveRelatedRole_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesRelatedUserRole();
                this.LoadRelatedUserRole();
                ClearControlRelatedUserRole();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ClearControlRelatedUserRole()
        {
            try
            {
                txtRelatedUserRole.Text = string.Empty;
                btnSaveRelatedRole.Text = "Save";
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void AddValuesRelatedUserRole()
        {
            try
            {
                _objRelatedUserRole = new RelatedUserRole();
                _objRelatedUserRole.RelatedRoleText = txtRelatedUserRole.Text == string.Empty ? null : txtRelatedUserRole.Text;
                _objCompanySetup = new CompanySetup();
                _objCompanySetup.EntryUserName = LoginUserInformation.UserID;
                _objRelatedUserRoleController = new RelatedUserRoleController();
                if (btnSaveRelatedRole.Text == "Save")
                {
                    _objRelatedUserRoleController.SaveRelatedRole(_objCompanySetup, _objRelatedUserRole);
                }
                else
                {
                    _objRelatedUserRole.RelatedRoleID = Convert.ToInt32(lblRelatedUserRoleID.Text);
                    _objRelatedUserRoleController.UpdateRelatedUserRole(_objCompanySetup, _objRelatedUserRole);
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void grdRelatedUserRole_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

        protected void grdRelatedUserRole_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdRelatedUserRole_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
                string lblRelatedToID = ((Label)grdRelatedUserRole.Rows[selectedIndex].FindControl("lblRelatedToID")).Text;
                if (e.CommandName.Equals("Select"))
                {
                    string lblRelatedToText = ((Label)grdRelatedUserRole.Rows[selectedIndex].FindControl("lblRelatedToText")).Text;
                    txtRelatedUserRole.Text = lblRelatedToText;
                    lblRelatedUserRoleID.Text = lblRelatedToID;
                    btnSaveRelatedRole.Text = "Update";
                }
                else if (e.CommandName.Equals("Delete"))
                {
                    _objRelatedUserRole = new RelatedUserRole();
                    _objRelatedUserRole.RelatedRoleID = Convert.ToInt32(lblRelatedToID);
                    _objRelatedUserRoleController = new RelatedUserRoleController();
                    _objRelatedUserRoleController.DeleteRelatedUserRole(_objRelatedUserRole);
                    this.LoadRelatedUserRole();
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }


    }
}