using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;
using System.Data;

namespace ERPWebApplication.ModuleName.HRMS.SelfService
{
    public partial class ProcessDetailsForm : System.Web.UI.Page
    {
        private ProcessDetails _objProcessDetails;
        private ProcessDetailsController _objProcessDetailsController;
        private OrganizationalChartSetupController _objOrganizationalChartSetupController;
        private BranchSetup _objBranchSetup;
        private DepartmentSetup _objDepartmentSetup;
        private EmployeeSetup _objEmployeeSetup;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    LoadProcessDescription();
                    _objProcessDetailsController = new ProcessDetailsController();
                    _objProcessDetails = new ProcessDetails();
                    _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
                    _objProcessDetailsController.LoadProcessDDL(ddlProcessFlow, _objProcessDetails);
                    _objProcessDetailsController.LoadProcessDDL(ddlProcessLevel, _objProcessDetails);
                    _objProcessDetailsController.LoadProcessDDL(ddlProcessAction, _objProcessDetails);
                    _objProcessDetailsController.LoadProcessDDL(ddlProcessConfiguration, _objProcessDetails);
                    LoadDepartmentDDL();
                    txtAccessId_AutoCompleteExtender.ContextKey = LoginUserInformation.CompanyID.ToString();
                    txtSubAccessId0_AutoCompleteExtender.ContextKey = LoginUserInformation.CompanyID.ToString();
                    this.LoadEmployeeList();
                    LoadConfigurationRecord();
                    LoadProcessFlow();
                    LoadProcessLevel();
                    LoadProcessAction();

                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void LoadProcessAction()
        {
            _objProcessDetails = new ProcessDetails();
            _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
            _objProcessDetailsController = new ProcessDetailsController();
            _objProcessDetails.DtProcessAction = _objProcessDetailsController.GetProcessAction(_objProcessDetails);
            grdActionType.DataSource = null;
            grdActionType.DataBind();
            if (_objProcessDetails.DtProcessAction != null)
            {
                grdActionType.DataSource = _objProcessDetails.DtProcessAction;
                grdActionType.DataBind();
            }

        }

        private void LoadProcessLevel()
        {
            _objProcessDetails = new ProcessDetails();
            _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
            _objProcessDetailsController = new ProcessDetailsController();
            _objProcessDetails.DtProcessLevel = _objProcessDetailsController.GetProcessLevel(_objProcessDetails);
            grdLevelDescription.DataSource = null;
            grdLevelDescription.DataBind();
            if (_objProcessDetails.DtProcessLevel != null)
            {
                grdLevelDescription.DataSource = _objProcessDetails.DtProcessLevel;
                grdLevelDescription.DataBind();
            }

        }

        private void LoadProcessFlow()
        {
            try
            {
                _objProcessDetails = new ProcessDetails();
                _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
                _objProcessDetailsController = new ProcessDetailsController();
                _objProcessDetails.DtProcessFlow = _objProcessDetailsController.GetProcessFlow(_objProcessDetails);
                grdFlowDefinition.DataSource = null;
                grdFlowDefinition.DataBind();
                if (_objProcessDetails.DtProcessFlow != null)
                {
                    grdFlowDefinition.DataSource = _objProcessDetails.DtProcessFlow;
                    grdFlowDefinition.DataBind();
                }

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void LoadConfigurationRecord()
        {
            try
            {
                _objProcessDetails = new ProcessDetails();
                _objDepartmentSetup = new DepartmentSetup();
                _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
                _objProcessDetails.ProcessId = ddlProcessConfiguration.SelectedValue == "-1" ? null : ddlProcessConfiguration.SelectedValue;
                if (ddlFlowConfiguration.Items.Count == 0)
                {
                    _objProcessDetails.FlowId = null;
                }
                else if (Convert.ToInt32(ddlFlowConfiguration.SelectedValue) == -1)
                {
                    _objProcessDetails.FlowId = null;
                }
                else
                {
                    _objProcessDetails.FlowId = Convert.ToInt32(ddlFlowConfiguration.SelectedValue);
                }

                _objDepartmentSetup.DepartmentID = Convert.ToInt32(ddlDepartmentConfiguration.SelectedValue);
                _objProcessDetailsController = new ProcessDetailsController();
                _objProcessDetails.DtConfigurationData = _objProcessDetailsController.GetConfigurationRecord(_objProcessDetails, _objDepartmentSetup);
                grdProcessTeam.DataSource = null;
                grdProcessTeam.DataBind();
                if (_objProcessDetails.DtConfigurationData != null)
                {
                    grdProcessTeam.DataSource = _objProcessDetails.DtConfigurationData;
                    grdProcessTeam.DataBind();
                }


            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void LoadDepartmentDDL()
        {
            try
            {
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objBranchSetup = new BranchSetup();
                _objBranchSetup.CompanyID = LoginUserInformation.CompanyID;
                _objBranchSetup.BranchID = LoginUserInformation.BranchID;
                _objOrganizationalChartSetupController.LoadDepartmentDDL(ddlDepartmentConfiguration, _objBranchSetup);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void LoadProcessDescription()
        {
            try
            {
                _objProcessDetails = new ProcessDetails();
                _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
                _objProcessDetailsController = new ProcessDetailsController();
                _objProcessDetails.DtProcessDescription = _objProcessDetailsController.GetProcessDescription(_objProcessDetails);
                grdProcessDescription.DataSource = null;
                grdProcessDescription.DataBind();
                if (_objProcessDetails.DtProcessDescription != null)
                {
                    grdProcessDescription.DataSource = _objProcessDetails.DtProcessDescription;
                    grdProcessDescription.DataBind();
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
                AddProcessValues();
                ClearControlProcessDescription();
                _objProcessDetailsController = new ProcessDetailsController();
                _objProcessDetails = new ProcessDetails();
                _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
                _objProcessDetailsController.LoadProcessDDL(ddlProcessFlow, _objProcessDetails);
                _objProcessDetailsController.LoadProcessDDL(ddlProcessLevel, _objProcessDetails);
                _objProcessDetailsController.LoadProcessDDL(ddlProcessAction, _objProcessDetails);
                _objProcessDetailsController.LoadProcessDDL(ddlProcessConfiguration, _objProcessDetails);
                this.LoadProcessDescription();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
            }
            catch (Exception msgException)
            {
                clsTopMostMessageBox.Show(msgException.Message);

            }
        }

        private void ClearControlProcessDescription()
        {
            try
            {
                txtProcessDescription.Text = string.Empty;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void AddProcessValues()
        {
            try
            {
                _objProcessDetails = new ProcessDetails();
                _objProcessDetails.ProcessDescription = txtProcessDescription.Text == string.Empty ? null : txtProcessDescription.Text;
                _objProcessDetails.ProcessStatus = RadioButtonListStatus.SelectedValue;
                _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
                _objProcessDetails.EntryUserName = LoginUserInformation.UserID;
                _objProcessDetailsController = new ProcessDetailsController();
                _objProcessDetailsController.SaveProcessDescription(_objProcessDetails);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearControlProcessDescription();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnSaveFlowDefinition_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesFlowDefinition();
                this.LoadProcessFlow();
                ClearControlFlowDefinition();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ClearControlFlowDefinition()
        {
            try
            {
                ddlProcessFlow.ClearSelection();
                ddlCategory.ClearSelection();
                txtFlowDescription.Text = string.Empty;
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void AddValuesFlowDefinition()
        {
            try
            {
                _objProcessDetails = new ProcessDetails();
                _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
                _objProcessDetails.EntryUserName = LoginUserInformation.UserID;
                _objProcessDetails.ProcessId = ddlProcessFlow.SelectedValue == "-1" ? null : ddlProcessFlow.SelectedValue;
                _objProcessDetails.CategoryId = Convert.ToInt32( ddlCategory.SelectedValue);
                _objProcessDetails.FlowDescription = txtFlowDescription.Text == string.Empty ? null : txtFlowDescription.Text;
                _objProcessDetailsController = new ProcessDetailsController();
                _objProcessDetailsController.SaveFlowDescription(_objProcessDetails);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnSaveLevelDescription_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesLevelDescription();
                this.LoadProcessLevel();
                ClearControlLevel();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ClearControlLevel()
        {
            try
            {
                ddlProcessLevel.ClearSelection();
                txtLevelDescription.Text = string.Empty;
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void AddValuesLevelDescription()
        {
            try
            {
                _objProcessDetails = new ProcessDetails();
                _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
                _objProcessDetails.EntryUserName = LoginUserInformation.UserID;
                _objProcessDetails.ProcessId = ddlProcessLevel.SelectedValue == "-1" ? null : ddlProcessLevel.SelectedValue;
                _objProcessDetails.LevelDescription = txtLevelDescription.Text == string.Empty ? null : txtLevelDescription.Text;
                _objProcessDetailsController = new ProcessDetailsController();
                _objProcessDetailsController.SaveLevelDescription(_objProcessDetails);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnSaveActionType_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesActionType();
                this.LoadProcessAction();
                ClearControlActionType();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ClearControlActionType()
        {
            try
            {
                ddlProcessAction.ClearSelection();
                txtActionType.Text = string.Empty;
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void AddValuesActionType()
        {
            _objProcessDetails = new ProcessDetails();
            _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
            _objProcessDetails.EntryUserName = LoginUserInformation.UserID;
            _objProcessDetails.ProcessId = ddlProcessAction.SelectedValue == "-1" ? null : ddlProcessAction.SelectedValue;
            _objProcessDetails.ActionType = txtActionType.Text == string.Empty ? null : txtActionType.Text;
            _objProcessDetailsController = new ProcessDetailsController();
            _objProcessDetailsController.SaveActionType(_objProcessDetails);
        }

        protected void ddlProcessConfiguration_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _objProcessDetails = new ProcessDetails();
                _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
                _objProcessDetails.ProcessId = ddlProcessConfiguration.SelectedValue;
                _objProcessDetailsController = new ProcessDetailsController();
                _objProcessDetailsController.LoadFlowDefinitionDDL(ddlFlowConfiguration, _objProcessDetails);
                _objProcessDetailsController.LoadLevelDescriptionDDL(ddlLevelConfiguration, _objProcessDetails);
                _objProcessDetailsController.LoadActionTypeCLB(ChkLisBoxAccessPermission, _objProcessDetails);
                _objProcessDetailsController.LoadActionTypeCLB(chklistboxSubAccessPermission, _objProcessDetails);
                LoadEmployeeList();
                this.LoadConfigurationRecord();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void LoadEmployeeList()
        {
            try
            {
                _objDepartmentSetup = new DepartmentSetup();
                _objDepartmentSetup.CompanyID = LoginUserInformation.CompanyID;
                _objDepartmentSetup.DepartmentID = Convert.ToInt32(ddlDepartmentConfiguration.SelectedValue);
                _objProcessDetailsController = new ProcessDetailsController();
                _objEmployeeSetup = new EmployeeSetup();
                _objEmployeeSetup.DtEmployee = _objProcessDetailsController.GetEmployee(_objDepartmentSetup);
                grdEmployes.DataSource = null;
                grdEmployes.DataBind();
                if (_objEmployeeSetup.DtEmployee != null)
                {
                    grdEmployes.DataSource = _objEmployeeSetup.DtEmployee;
                    grdEmployes.DataBind();

                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesApprovalConfiguration();
                this.ClearControlsLevel();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }
        private void ClearControlsLevel()
        {
            try
            {
                ddlLevelConfiguration.ClearSelection();
                txtAccessId.Text = string.Empty;
                ChkLisBoxAccessPermission.ClearSelection();
                txtSubAccessId0.Text = string.Empty;
                chklistboxSubAccessPermission.ClearSelection();
                btnAdd.Text = "Add";
            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        private void BindConfigurationGrid(ProcessDetails objProcessDetails)
        {
            try
            {
                var dt = new DataTable();
                DataRow dr;

                dt.Columns.Add("Line", typeof(int));
                dt.Columns.Add("LevelId", typeof(string));
                dt.Columns.Add("LevelIdValue", typeof(int));
                dt.Columns.Add("AccessId", typeof(string));
                dt.Columns.Add("AccessPermission", typeof(string));
                dt.Columns.Add("AccessPermissionValue", typeof(string));
                dt.Columns.Add("SubAccessId", typeof(string));
                dt.Columns.Add("SubAccessPermission", typeof(string));
                dt.Columns.Add("SubAccessPermissionValue", typeof(string));

                if (ViewState["dtConfiguration"] != null)
                {
                    var dtTable = (DataTable)ViewState["dtConfiguration"];
                    var count = dtTable.Rows.Count;
                    for (var i = 0; i < count + 1; i++)
                    {
                        dt = (DataTable)ViewState["dtConfiguration"];
                        if (dt.Rows.Count <= 0) continue;
                        dr = dt.NewRow();
                        dr[0] = dt.Rows[0][0].ToString();
                    }
                    dr = dt.NewRow();
                    dr[0] = objProcessDetails.LineNo;
                    dr[1] = objProcessDetails.LevelDescription;
                    dr[2] = objProcessDetails.LevelId;
                    dr[3] = objProcessDetails.AccessId;
                    dr[4] = objProcessDetails.AccessPermissionTypeText;
                    dr[5] = objProcessDetails.AccessPermissionTypeId;
                    dr[6] = objProcessDetails.SubAccessId;
                    dr[7] = objProcessDetails.SubAccessPermissionTypeText;
                    dr[8] = objProcessDetails.SubAccessPermissionTypeId;

                    dt.Rows.Add(dr);

                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = objProcessDetails.LineNo;
                    dr[1] = objProcessDetails.LevelDescription;
                    dr[2] = objProcessDetails.LevelId;
                    dr[3] = objProcessDetails.AccessId;
                    dr[4] = objProcessDetails.AccessPermissionTypeText;
                    dr[5] = objProcessDetails.AccessPermissionTypeId;
                    dr[6] = objProcessDetails.SubAccessId;
                    dr[7] = objProcessDetails.SubAccessPermissionTypeText;
                    dr[8] = objProcessDetails.SubAccessPermissionTypeId;


                    dt.Rows.Add(dr);
                }
                if (ViewState["dtConfiguration"] != null)
                {
                    DataTable dtTemp = (DataTable)ViewState["dtConfiguration"];
                    dtTemp.DefaultView.Sort = "Line DESC";
                    dtTemp = dtTemp.DefaultView.ToTable();
                    grdConfiguration.DataSource = dtTemp;
                    grdConfiguration.DataBind();
                }
                else
                {
                    dt.DefaultView.Sort = "Line DESC";
                    dt = dt.DefaultView.ToTable();
                    grdConfiguration.DataSource = dt;
                    grdConfiguration.DataBind();

                }
                ViewState["dtConfiguration"] = dt;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void AddValuesApprovalConfiguration()
        {
            try
            {
                _objProcessDetails = new ProcessDetails();

                #region Previous
                string AccessPermission = string.Empty;
                string AccessPermissionValue = string.Empty;
                string SubAccessPermission = string.Empty;
                string SubAccessPermissionValue = string.Empty;

                foreach (ListItem item in this.ChkLisBoxAccessPermission.Items)
                {
                    if (item.Selected)
                    {
                        AccessPermissionValue += item.Value + ",";
                        AccessPermission += item.Text + ",";
                    }
                }
                AccessPermissionValue = AccessPermissionValue.TrimEnd(',');
                AccessPermission = AccessPermission.TrimEnd(',');
                foreach (ListItem item in this.chklistboxSubAccessPermission.Items)
                {
                    if (item.Selected)
                    {
                        SubAccessPermissionValue += item.Value + ",";
                        SubAccessPermission += item.Text + ",";
                    }
                }
                SubAccessPermissionValue = SubAccessPermissionValue.TrimEnd(',');
                SubAccessPermission = SubAccessPermission.TrimEnd(',');



                DataTable dtTable = (DataTable)ViewState["dtConfiguration"];
                _objProcessDetails.LineNo = dtTable == null ? 1 : this.GetMaxColumnValue(dtTable) + 1;
                _objProcessDetails.LevelDescription = ddlLevelConfiguration.SelectedItem.Text;
                _objProcessDetails.LevelId = Convert.ToInt32(ddlLevelConfiguration.SelectedValue);
                _objProcessDetails.AccessId = txtAccessId.Text == string.Empty ? null : txtAccessId.Text;
                _objProcessDetails.AccessPermissionTypeText = AccessPermission;
                _objProcessDetails.AccessPermissionTypeId = AccessPermissionValue;
                _objProcessDetails.SubAccessId = txtSubAccessId0.Text == string.Empty ? null : txtSubAccessId0.Text;
                _objProcessDetails.SubAccessPermissionTypeText = SubAccessPermission;
                _objProcessDetails.SubAccessPermissionTypeId = SubAccessPermissionValue;

                if (btnAdd.Text == "Edit")
                {
                    _objProcessDetails.LineNo = Convert.ToInt32(Session["lineNoAlign"].ToString());
                    DeleteConfigurationEntry();
                }

                this.BindConfigurationGrid(_objProcessDetails);


                //bool IsExists = false;
                //foreach (DataRow dr in dtTable.Rows)
                //{
                //    if (Convert.ToString(dr["LevelIdValue"]).Trim() == ddlLevelConfiguration.SelectedValue.Trim())
                //    {
                //        IsExists = true;
                //        break;
                //    }
                //}
                //if (!IsExists)
                //{

                //}
                //else
                //{
                //    throw new Exception(ddlLevelConfiguration.SelectedItem + " , Already exists");

                //}

                #endregion previous


            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private void DeleteConfigurationEntry()
        {
            try
            {
                var dt = (DataTable)ViewState["dtConfiguration"];
                dt.DefaultView.Sort = "Line DESC";
                dt = dt.DefaultView.ToTable();
                dt.Rows[Convert.ToInt32(Session["selectedIndexConfiguration"].ToString())].Delete();
                dt.AcceptChanges();
                dt.DefaultView.Sort = "Line DESC";
                dt = dt.DefaultView.ToTable();
                ViewState["dtConfiguration"] = dt;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private int GetMaxColumnValue(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count == 0)
                {
                    return 0;
                }
                else
                {
                    dt.DefaultView.Sort = "Line DESC";
                    return int.Parse(dt.DefaultView[0]["Line"].ToString());

                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }


        protected void btnSaveConfiguration_Click(object sender, EventArgs e)
        {
            try
            {
                AddvaluesConfiguration();
                this.LoadConfigurationRecord();
                ClearControlConfiguration();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ClearControlConfiguration()
        {
            try
            {
                ddlDepartmentConfiguration.ClearSelection();
                ddlFlowConfiguration.ClearSelection();
                ddlProcessConfiguration.ClearSelection();
                txtTeamName.Text = string.Empty;
                txtEffectiveDate.Text = string.Empty;
                btnSaveConfiguration.Text = "Save";
                ddlLevelConfiguration.SelectedValue = "-1";
                txtAccessId.Text = string.Empty;
                txtSubAccessId0.Text = string.Empty;
                ViewState["dtConfiguration"] = null;
                grdConfiguration.DataSource = null;
                grdConfiguration.DataBind();
                lblReferenceNo.Text = string.Empty;
                this.LoadEmployeeList();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void AddvaluesConfiguration()
        {
            try
            {
                _objProcessDetails = new ProcessDetails();
                _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
                _objProcessDetails.EntryUserName = LoginUserInformation.UserID;
                _objProcessDetails.ProcessId = ddlProcessConfiguration.SelectedValue == "-1" ? null : ddlProcessConfiguration.SelectedValue;
                if (ddlFlowConfiguration.SelectedValue == "-1")
                {
                    _objProcessDetails.FlowId = null;
                }
                else
                {
                    _objProcessDetails.FlowId = Convert.ToInt32(ddlFlowConfiguration.SelectedValue);
                }

                _objDepartmentSetup = new DepartmentSetup();
                _objDepartmentSetup.DepartmentID = Convert.ToInt32(ddlDepartmentConfiguration.SelectedValue);

                _objEmployeeSetup = new EmployeeSetup();


                _objProcessDetails.TeamName = txtTeamName.Text == string.Empty ? null : txtTeamName.Text;
                _objProcessDetails.DtConfigurationData = (DataTable)ViewState["dtConfiguration"];

                _objEmployeeSetup.DtEmployee = new DataTable();
                _objEmployeeSetup.DtEmployee.Columns.Add("employeeID", typeof(string));
                foreach (GridViewRow rowNo in grdEmployes.Rows)
                {
                    CheckBox CheckBoxEmployee = (CheckBox)rowNo.FindControl("CheckBoxEmployee");
                    if (CheckBoxEmployee.Checked == true)
                    {
                        string lblEmployeeID = ((Label)rowNo.FindControl("lblEmployeeID")).Text.ToString();
                        _objEmployeeSetup.DtEmployee.Rows.Add(lblEmployeeID);
                    }
                }

                if (txtEffectiveDate.Text == string.Empty)
                {
                    _objProcessDetails.EffectiveDate = null;
                }
                else
                {
                    _objProcessDetails.EffectiveDate = Convert.ToDateTime(txtEffectiveDate.Text);
                }

                _objProcessDetailsController = new ProcessDetailsController();
                if (btnSaveConfiguration.Text == "Save")
                {
                    _objProcessDetailsController.SaveConfigurationData(_objProcessDetails, _objEmployeeSetup, _objDepartmentSetup);
                }
                else
                {
                    _objProcessDetails.ReferenceNo = lblReferenceNo.Text;
                    _objProcessDetailsController.UpdateConfigurationData(_objProcessDetails, _objEmployeeSetup, _objDepartmentSetup);
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void ddlDepartmentConfiguration_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadEmployeeList();
                this.LoadConfigurationRecord();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void ddlFlowConfiguration_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadConfigurationRecord();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void grdProcessTeam_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
                if (e.CommandName.Equals("Select"))
                {
                    string lblReferenceNoTemp = ((Label)grdProcessTeam.Rows[selectedIndex].FindControl("lblReferenceNo")).Text;
                    string lblProcessIdTemp = ((Label)grdProcessTeam.Rows[selectedIndex].FindControl("lblProcessId")).Text;
                    string lblProcessFlowIdTemp = ((Label)grdProcessTeam.Rows[selectedIndex].FindControl("lblProcessFlowId")).Text;
                    string lblDepartmentIdTemp = ((Label)grdProcessTeam.Rows[selectedIndex].FindControl("lblDepartmentId")).Text;
                    string lblProcessNameTemp = ((Label)grdProcessTeam.Rows[selectedIndex].FindControl("lblProcessName")).Text;
                    string lblEffectiveDateTemp = ((Label)grdProcessTeam.Rows[selectedIndex].FindControl("lblEffectiveDate")).Text;
                    lblReferenceNo.Text = lblReferenceNoTemp;
                    ddlProcessConfiguration.SelectedValue = lblProcessIdTemp;
                    _objProcessDetails = new ProcessDetails();
                    _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
                    _objProcessDetails.ProcessId = ddlProcessConfiguration.SelectedValue;
                    _objProcessDetailsController = new ProcessDetailsController();
                    _objProcessDetailsController.LoadFlowDefinitionDDL(ddlFlowConfiguration, _objProcessDetails);
                    _objProcessDetailsController.LoadLevelDescriptionDDL(ddlLevelConfiguration, _objProcessDetails);
                    _objProcessDetailsController.LoadActionTypeCLB(ChkLisBoxAccessPermission, _objProcessDetails);
                    _objProcessDetailsController.LoadActionTypeCLB(chklistboxSubAccessPermission, _objProcessDetails);
                    LoadEmployeeList();
                    ddlFlowConfiguration.SelectedValue = lblProcessFlowIdTemp;
                    if (lblDepartmentIdTemp != string.Empty)
                    {
                        ddlDepartmentConfiguration.SelectedValue = lblDepartmentIdTemp;
                    }

                    txtTeamName.Text = lblProcessNameTemp;
                    txtEffectiveDate.Text = Convert.ToDateTime(lblEffectiveDateTemp).ToString("yyyy-MM-dd");
                    LoadConfigurationDetails();
                    btnSaveConfiguration.Text = "Edit";
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void LoadConfigurationDetails()
        {
            try
            {
                ViewState.Clear();

                DataTable dt = new DataTable();

                if ((DataTable)ViewState["dtConfiguration"] != null)
                {
                    dt = (DataTable)ViewState["dtConfiguration"];
                }
                if (dt.Columns.Count == 0)
                {
                    dt.Columns.Add("Line", typeof(int));
                    dt.Columns.Add("LevelId", typeof(string));
                    dt.Columns.Add("LevelIdValue", typeof(int));
                    dt.Columns.Add("AccessId", typeof(string));
                    dt.Columns.Add("AccessPermission", typeof(string));
                    dt.Columns.Add("AccessPermissionValue", typeof(string));
                    dt.Columns.Add("SubAccessId", typeof(string));
                    dt.Columns.Add("SubAccessPermission", typeof(string));
                    dt.Columns.Add("SubAccessPermissionValue", typeof(string));
                }
                string AccessPermission = string.Empty;
                string AccessPermissionValue = string.Empty;
                string SubAccessPermission = string.Empty;
                string SubAccessPermissionValue = string.Empty;
                string FinalAccessPermission = string.Empty;
                string FinalSubAccessPermission = string.Empty;
                DataTable DT = new DataTable();

                _objProcessDetails = new ProcessDetails();
                _objProcessDetails.ReferenceNo = lblReferenceNo.Text.ToString();
                _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
                _objProcessDetailsController = new ProcessDetailsController();

                DT = _objProcessDetailsController.GetConfigurationDetails(_objProcessDetails);
                foreach (DataRow r in DT.Rows)
                {
                    string value = (string)r["AccessPermissionValue "];
                    if (value != "")
                    {
                        string[] separator = { "," };
                        string[] words = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var word in words)
                        {
                            if (word != "&nbsp;" && word != "&amp;nbsp;")
                            {
                                string SqlString = "SELECT Action FROM ProcessActionType WHERE (ActionTypeId = " + Convert.ToInt32(word) + ")";
                                string ActionType = Process.Run(SqlString).Rows[0][0].ToString();
                                if (ActionType != "")
                                {
                                    FinalAccessPermission += ActionType + ",";
                                }
                            }
                        }
                        FinalAccessPermission = FinalAccessPermission.TrimEnd(',');
                    }
                    string valueSubAccess = (string)r["SubAccessPermissionValue"];
                    if (valueSubAccess != "")
                    {
                        string[] separator = { "," };
                        string[] wordsSubAccess = valueSubAccess.Split(separator, StringSplitOptions.RemoveEmptyEntries); //&nbsp;
                        foreach (var wordSubAccess in wordsSubAccess)
                        {
                            if (wordSubAccess != "&nbsp;" && wordSubAccess != "&amp;nbsp;")
                            {
                                string SqlString = "SELECT Action FROM ProcessActionType WHERE (ActionTypeId = " + Convert.ToInt32(wordSubAccess) + ")";

                                string SubActionType = Process.Run(SqlString).Rows[0][0].ToString();
                                if (SubActionType != "")
                                {
                                    FinalSubAccessPermission += SubActionType + ",";
                                }
                            }
                        }
                        FinalSubAccessPermission = FinalSubAccessPermission.TrimEnd(',');
                    }
                    dt.Rows.Add
                        (
                        Convert.ToInt32(r["Line"]),
                        (string)r["LevelId"] == "" ? "" : (string)r["LevelId"],
                        Convert.ToInt32(r["LevelIdValue"]),
                        (string)r["AccessId"] == "" ? "" : (string)r["AccessId"],
                        FinalAccessPermission == "" ? "" : FinalAccessPermission,
                        (string)r["AccessPermissionValue "] == "" ? "" : (string)r["AccessPermissionValue "],
                        (string)r["SubAccessId"] == "" ? "" : (string)r["SubAccessId"],
                        FinalSubAccessPermission == "" ? "" : FinalSubAccessPermission,
                        (string)r["SubAccessPermissionValue"] == "" ? "" : (string)r["SubAccessPermissionValue"]
                        );
                    FinalAccessPermission = string.Empty;
                    FinalSubAccessPermission = string.Empty;
                }
                ViewState["dtConfiguration"] = dt;
                grdConfiguration.DataSource = dt;
                grdConfiguration.DataBind();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void grdProcessTeam_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnClearConfiguration_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControlConfigurationAll();
                this.ClearControlsLevel();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ClearControlConfigurationAll()
        {
            try
            {
                if (ddlProcessConfiguration.Items.Count > 0)
                {
                    ddlProcessConfiguration.SelectedValue = "-1";
                }

                if (ddlFlowConfiguration.Items.Count > 0)
                {
                    ddlFlowConfiguration.SelectedValue = "-1";

                }

                if (ddlDepartmentConfiguration.Items.Count > 0)
                {
                    ddlDepartmentConfiguration.SelectedValue = "-1";
                }

                this.ClearControlConfiguration();
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void grdConfiguration_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName.Equals("Delete"))
            {
                DataTable dt = (DataTable)ViewState["dtConfiguration"];
                dt.DefaultView.Sort = "Line DESC";
                dt = dt.DefaultView.ToTable();
                dt.Rows[selectedIndex].Delete();
                dt.AcceptChanges();
                dt.DefaultView.Sort = "Line DESC";
                dt = dt.DefaultView.ToTable();
                ViewState["dtConfiguration"] = dt;
                if (ViewState["dtConfiguration"] == null) return;
                grdConfiguration.DataSource = ViewState["dtConfiguration"];
                grdConfiguration.DataBind();
            }
            else if (e.CommandName.Equals("Select"))
            {
                Session["selectedIndexConfiguration"] = selectedIndex;
                string lblLineTemp = ((Label)grdConfiguration.Rows[selectedIndex].FindControl("lblLine")).Text;
                string lblLevelIdTemp = ((Label)grdConfiguration.Rows[selectedIndex].FindControl("lblLevelIdValue")).Text;
                string lblAccessIdTemp = ((Label)grdConfiguration.Rows[selectedIndex].FindControl("lblAccessId")).Text;
                string lblAccessPermissionValueTemp = ((Label)grdConfiguration.Rows[selectedIndex].FindControl("lblAccessPermissionValue")).Text;
                string lblSubAccessIdTemp = ((Label)grdConfiguration.Rows[selectedIndex].FindControl("lblSubAccessId")).Text;
                string lblSubAccessPermissionValueTemp = ((Label)grdConfiguration.Rows[selectedIndex].FindControl("lblSubAccessPermissionValue")).Text;

                ddlLevelConfiguration.SelectedValue = lblLevelIdTemp;
                txtAccessId.Text = lblAccessIdTemp;
                txtSubAccessId0.Text = lblSubAccessIdTemp;
                string valueOfAccessPermission = lblAccessPermissionValueTemp;
                string valueOfSubAccessPermission = lblSubAccessPermissionValueTemp;
                CheckboxListAssign(ChkLisBoxAccessPermission, valueOfAccessPermission);
                CheckboxListAssign(chklistboxSubAccessPermission, valueOfSubAccessPermission);
                Session["lineNoAlign"] = lblLineTemp;
                btnAdd.Text = "Edit";
            }
        }

        public void CheckboxListAssign(CheckBoxList chkBoxListName, string value)
        {
            if (value != "")
            {
                string[] separators = { ",", ".", "!", "?", ";", ":", " " };
                string[] separator = { "," };
                string[] words = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (word != "&nbsp;" && word != "&amp;nbsp;")
                    {
                        chkBoxListName.Items.FindByValue(word).Selected = true;
                    }
                }
            }
        }

        protected void grdConfiguration_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdEmployes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    _objEmployeeSetup = new EmployeeSetup();
                    _objProcessDetails = new ProcessDetails();
                    _objEmployeeSetup.EmployeeID = ((Label)e.Row.FindControl("lblEmployeeID")).Text;
                    CheckBox CheckBoxEmployee = (CheckBox)e.Row.FindControl("CheckBoxEmployee");
                    _objProcessDetails.ProcessId = ddlProcessConfiguration.SelectedValue == "-1" ? "" : ddlProcessConfiguration.SelectedValue;
                    if (ddlFlowConfiguration.Items.Count > 0)
                    {
                        if (ddlFlowConfiguration.SelectedValue == "-1")
                        {
                            _objProcessDetails.FlowId = null;
                        }
                        else
                        {
                            _objProcessDetails.FlowId = Convert.ToInt32(ddlFlowConfiguration.SelectedValue);
                        }
                    }
                    else
                    {
                        _objProcessDetails.FlowId = null;
                    }

                    _objEmployeeSetup.DepartmentID = Convert.ToInt32(ddlDepartmentConfiguration.SelectedValue);
                    _objEmployeeSetup.CompanyID = LoginUserInformation.CompanyID;
                    _objProcessDetails.ReferenceNo = lblReferenceNo.Text.ToString();
                    _objProcessDetailsController = new ProcessDetailsController();

                    DataTable ApplicantIdCheck = _objProcessDetailsController.GetAssignedEmployeePhase1(_objProcessDetails, _objEmployeeSetup);
                    if (Convert.ToInt32(ApplicantIdCheck.Rows[0][0].ToString()) != 0)
                    {
                        CheckBoxEmployee.Enabled = false;
                    }

                    DataTable ApplicantId = _objProcessDetailsController.GetAssignedEmployeePhase2(_objProcessDetails, _objEmployeeSetup);
                    if (Convert.ToInt32(ApplicantId.Rows[0][0].ToString()) != 0)
                    {
                        CheckBoxEmployee.Checked = true;
                        CheckBoxEmployee.Enabled = true;
                    }
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void grdProcessDescription_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
                string lblProcessIdTemp = ((Label)grdProcessDescription.Rows[selectedIndex].FindControl("lblProcessId")).Text;
                if (e.CommandName.Equals("Delete"))
                {
                    _objProcessDetails = new ProcessDetails();
                    _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
                    _objProcessDetails.ProcessId = lblProcessIdTemp;
                    _objProcessDetailsController = new ProcessDetailsController();
                    _objProcessDetailsController.DeleteProcess(_objProcessDetails);
                    this.LoadProcessDescription();

                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void grdProcessDescription_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdFlowDefinition_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
                string lblProcessIdTemp = ((Label)grdFlowDefinition.Rows[selectedIndex].FindControl("lblProcessId")).Text;
                string lblProcessFlowIdTemp = ((Label)grdFlowDefinition.Rows[selectedIndex].FindControl("lblProcessFlowId")).Text;
                if (e.CommandName.Equals("Delete"))
                {
                    _objProcessDetails = new ProcessDetails();
                    _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
                    _objProcessDetails.ProcessId = lblProcessIdTemp;
                    _objProcessDetails.FlowId = Convert.ToInt32( lblProcessFlowIdTemp);
                    _objProcessDetailsController = new ProcessDetailsController();
                    _objProcessDetailsController.DeleteProcessFlow(_objProcessDetails);
                    this.LoadProcessFlow();

                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        protected void grdFlowDefinition_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdLevelDescription_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
                string lblProcessIdTemp = ((Label)grdLevelDescription.Rows[selectedIndex].FindControl("lblProcessId")).Text;
                string lblProcessLevelIdTemp = ((Label)grdLevelDescription.Rows[selectedIndex].FindControl("lblProcessLevelId")).Text;
                if (e.CommandName.Equals("Delete"))
                {
                    _objProcessDetails = new ProcessDetails();
                    _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
                    _objProcessDetails.ProcessId = lblProcessIdTemp;
                    _objProcessDetails.LevelId = Convert.ToInt32(lblProcessLevelIdTemp);
                    _objProcessDetailsController = new ProcessDetailsController();
                    _objProcessDetailsController.DeleteProcessLevel(_objProcessDetails);
                    this.LoadProcessLevel();

                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void grdLevelDescription_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdActionType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
                string lblProcessIdTemp = ((Label)grdActionType.Rows[selectedIndex].FindControl("lblProcessId")).Text;
                string lblActionTypeIdTemp = ((Label)grdActionType.Rows[selectedIndex].FindControl("lblActionTypeId")).Text;
                if (e.CommandName.Equals("Delete"))
                {
                    _objProcessDetails = new ProcessDetails();
                    _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
                    _objProcessDetails.ProcessId = lblProcessIdTemp;
                    _objProcessDetails.ActionTypeId = Convert.ToInt32(lblActionTypeIdTemp);
                    _objProcessDetailsController = new ProcessDetailsController();
                    _objProcessDetailsController.DeleteProcessAction(_objProcessDetails);
                    this.LoadProcessAction();

                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void grdActionType_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnClearActionType_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearControlActionType();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnClearLevelDescription_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearControlLevel();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnClearFlowDefinition_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearControlFlowDefinition();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }
    }
}