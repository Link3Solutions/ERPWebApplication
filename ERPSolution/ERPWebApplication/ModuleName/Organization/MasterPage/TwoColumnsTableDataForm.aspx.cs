﻿using System;
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
                    Session["entryUserCode"] = LoginUserInformation.UserID;
                    Session["lastPositionNo"] = 1;
                    Session["branchID"] = 1;
                    ShowsysTwoColumnTables();
                    PanelForInputControl.Visible = false;
                    btnSave.Visible = false;
                    btnClear.Visible = false;
                    
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
                _objTwoColumnTables.EntrySystem = "M";
                EmployeeSetup objEmployeeSetup = new EmployeeSetup();
                objEmployeeSetup.CompanyID = LoginUserInformation.CompanyID;
                objEmployeeSetup.EmployeeID = LoginUserInformation.UserID;
                _objTwoColumnTablesController = new TwoColumnTablesController();
                DataTable dtTablesName = _objTwoColumnTablesController.GetRecord(_connectionString, _objTwoColumnTables,objEmployeeSetup);
                grdTableName.DataSource = null;
                grdTableName.DataBind();
                if (dtTablesName.Rows.Count > 0)
                {
                    grdTableName.DataSource = dtTablesName;
                    grdTableName.DataBind();
                }

                ControlVisibleTrue(dtTablesName);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        private void ControlVisibleTrue(DataTable dtTablesNameTemp)
        {
            if (dtTablesNameTemp.Rows.Count > 0)
            {
                lblStatus.Visible = false;
            }
            else
            {
                lblStatus.Visible = true;
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
            e.Row.Cells[0].Visible = false;
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
                ShowTwoColumnsTableData();
                PanelForInputControl.Visible = true;
                btnSave.Visible = true;
                btnClear.Visible = true;

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ShowTwoColumnsTableData()
        {
            try
            {
                _objTwoColumnsTableData = new TwoColumnsTableData();
                _objTwoColumnsTableData.CompanyID = Convert.ToInt32(Session["lastPositionNo"].ToString());
                _objTwoColumnsTableData.BranchID = Convert.ToInt32(Session["branchID"].ToString());
                _objTwoColumnsTableData.TableID = Convert.ToInt32(Session["tableID"].ToString());
                _objTwoColumnsTableDataController = new TwoColumnsTableDataController();
                DataTable dtTableData = _objTwoColumnsTableDataController.GetRecord(_connectionString, _objTwoColumnsTableData);
                grdTableData.DataSource = null;
                grdTableData.DataBind();
                if (dtTableData.Rows.Count > 0)
                {
                    grdTableData.DataSource = dtTableData;
                    grdTableData.DataBind();

                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesToTablesData();
                ShowTwoColumnsTableData();
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
                txtFieldOfName.Text = string.Empty;
                txtFieldDescription.Text = string.Empty;
                btnSave.Text = "Save";

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void AddValuesToTablesData()
        {
            try
            {
                _objTwoColumnsTableData = new TwoColumnsTableData();
                _objTwoColumnsTableData.CompanyID = Convert.ToInt32(Session["lastPositionNo"].ToString());
                _objTwoColumnsTableData.BranchID = Convert.ToInt32(Session["branchID"].ToString());
                _objTwoColumnsTableData.TableID = Convert.ToInt32(Session["tableID"].ToString());
                _objTwoColumnsTableData.FieldOfName = txtFieldOfName.Text == string.Empty ? null : txtFieldOfName.Text;
                _objTwoColumnsTableData.FieldDescription = txtFieldDescription.Text == string.Empty ? null : txtFieldDescription.Text;
                _objTwoColumnsTableData.EntryUserName = Session["entryUserCode"].ToString();
                _objTwoColumnsTableData.TableName = lblSelectedTableName.Text == string.Empty ? null : lblSelectedTableName.Text;
                _objTwoColumnsTableDataController = new TwoColumnsTableDataController();
                if (btnSave.Text == "Save")
                {
                    _objTwoColumnsTableDataController.Save(_connectionString, _objTwoColumnsTableData);
                }
                else
                {
                    _objTwoColumnsTableData.FieldOfID = Session["selectedIndex"].ToString();
                    _objTwoColumnsTableDataController.Update(_connectionString,_objTwoColumnsTableData);

                }
                

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void grdTableData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
                lblSelectedTableName.Text = string.Empty;
                grdTableData.DataSource = null;
                grdTableData.DataBind();
                PanelForInputControl.Visible = false;
                btnSave.Visible = false;
                btnClear.Visible = false;

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void grdTableData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string lblFieldOfID = ((Label)grdTableData.Rows[selectedIndex].FindControl("lblFieldOfID")).Text;
            if (e.CommandName.Equals("Select"))
            {
                try
                {
                    string lblFieldOfName = ((Label)grdTableData.Rows[selectedIndex].FindControl("lblFieldOfName")).Text;
                    string lblFieldDescription = ((Label)grdTableData.Rows[selectedIndex].FindControl("lblFieldDescription")).Text;
                    txtFieldOfName.Text = lblFieldOfName;
                    txtFieldDescription.Text = lblFieldDescription;                    
                    btnSave.Text = "Update";
                    Session["selectedIndex"] = lblFieldOfID;

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
                    _objTwoColumnsTableData = new TwoColumnsTableData();
                    _objTwoColumnsTableData.FieldOfID = lblFieldOfID;
                    _objTwoColumnsTableData.CompanyID = LoginUserInformation.CompanyID;
                    _objTwoColumnsTableData.TableID = Convert.ToInt32(Session["tableID"].ToString());
                    _objTwoColumnsTableData.TableName = lblSelectedTableName.Text == string.Empty ? null : lblSelectedTableName.Text;
                    _objTwoColumnsTableDataController = new TwoColumnsTableDataController();
                    _objTwoColumnsTableDataController.Delete(_connectionString,_objTwoColumnsTableData);
                    ShowTwoColumnsTableData();

                }
                catch (Exception msgException)
                {

                    clsTopMostMessageBox.Show(msgException.Message);
                }


            }
        }

        protected void grdTableData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

    }
}