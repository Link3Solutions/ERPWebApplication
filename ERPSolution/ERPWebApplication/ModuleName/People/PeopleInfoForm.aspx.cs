using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;

namespace ERPWebApplication.ModuleName.People
{
    public partial class PeopleInfoForm : System.Web.UI.Page
    {
        private Boolean NoDataFound = false;
        private PeopleEntry _objPeopleEntry;
        private PeopleEntryController _objPeopleEntryController;
        private EmployeeSetupController _objEmployeeSetupController;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    PanelDataEntry.Visible = false;
                    btnCancel.Visible = false;
                    PanelAcademicRecord.Visible = false;
                    btnCancelAcademicRecord.Visible = false;
                    ShowProperData(NoDataFound);
                    LoadPepoleRecord();
                    LoadEmployeeTitle();
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        private void LoadEmployeeTitle()
        {
            try
            {
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.GetEmployeeTitle(ddlSearch1);
                _objEmployeeSetupController.GetEmployeeTitle(ddlSearch2);
                _objEmployeeSetupController.GetEmployeeTitle(ddlSearch3);
                _objEmployeeSetupController.GetEmployeeTitle(ddlSearch4);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void LoadPepoleRecord()
        {
            try
            {
                _objPeopleEntry = new PeopleEntry();
                _objPeopleEntryController = new PeopleEntryController();
                //_objPeopleEntry.DtPeople = _objPeopleEntryController.GetPeopleRecord();
                _objPeopleEntry.DtPeople = GETTEMPDATA();
                
                grdPeople.DataSource = null;
                grdPeople.DataBind();
                if (_objPeopleEntry.DtPeople == null)
                {
                    PanelSearchHeader.Visible = false;
                    PanelSearchToGrid.Visible = false;
                    lblGridTitle.Text = clsMessages.GNoDataFound;
                    PanelPeopleRecord.Visible = false;
                }
                else
                {
                    grdPeople.DataSource = _objPeopleEntry.DtPeople;
                    grdPeople.DataBind();
                    PanelSearchHeader.Visible = true;
                    PanelSearchToGrid.Visible = true;
                    lblGridTitle.Text = grdPeople.Rows.Count.ToString() + clsMessages.GDataFound;
                    PanelPeopleRecord.Visible = true;
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private DataTable GETTEMPDATA()
        {
            var dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new DataColumn("txtNameOfDegree", typeof(String)));
            dt.Columns.Add(new DataColumn("txtInstitutionName", typeof(String)));
            dt.Columns.Add(new DataColumn("txtBoardUniversity", typeof(String)));
            dt.Columns.Add(new DataColumn("txtResultsGradeDivision", typeof(String)));
            dt.Columns.Add(new DataColumn("txtPassingYear", typeof(string)));
            dt.Columns.Add(new DataColumn("txtMajor", typeof(string)));

            dr = dt.NewRow();
            dr[0] = "MD. BASIR";
            dr[1] = "Programmer";
            dr[2] = "Software";
            dr[3] = "basir.link3.net";
            dr[4] = "26/09/2018";
            dr[5] = "01787656665";
            dt.Rows.Add(dr);
            return dt;
            
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                PanelDataEntry.Visible = true;
                btnCancel.Visible = true;
                if (btnAddNew.Text != "Add New")
                {
                    AddValuesOfPeople();
                }

                btnAddNew.Text = "Save";
                this.LoadPepoleRecord();
                lblGridTitle.Text = clsMessages.GYouareAddingData;
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void AddValuesOfPeople()
        {
            try
            {
                _objPeopleEntry = new PeopleEntry();
                _objPeopleEntry.PeopleName = txtPeopleName.Text == string.Empty ? null : txtPeopleName.Text;
                if (txtPeopleEmail.Text == string.Empty)
                {
                    _objPeopleEntry.BirthDate = null;
                }
                else
                {
                    _objPeopleEntry.BirthDate = Convert.ToDateTime(txtPeopleEmail.Text);
                }

                _objPeopleEntryController = new PeopleEntryController();
                _objPeopleEntryController.SavePeopleData(_objPeopleEntry);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                CancelAndClearControl();
                LoadPepoleRecord();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void CancelAndClearControl()
        {
            try
            {
                PanelDataEntry.Visible = false;
                btnCancel.Visible = false;
                btnAddNew.Text = "Add New";
                lblGridTitle.Text = clsMessages.GYouareAddingData;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnAddNewAcademicRecord_Click(object sender, EventArgs e)
        {
            try
            {
                PanelAcademicRecord.Visible = true;
                btnCancelAcademicRecord.Visible = true;

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnCancelAcademicRecord_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControlsOfAcademicRecords();
                CancelAndClearControlAcademicRecord();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void CancelAndClearControlAcademicRecord()
        {
            try
            {
                PanelAcademicRecord.Visible = false;
                btnCancelAcademicRecord.Visible = false;
                btnAddAcademicRecordToGrid.Text = "Add New";
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }


        private void ShowProperData(Boolean iNoDataFound)
        {
            if (iNoDataFound == true)
            {
                lblSearchinGrid.Visible = false;
                txtSearchInGrid.Visible = false;
            }
            else
            {
                lblSearchinGrid.Visible = true;
                txtSearchInGrid.Visible = true;

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                _objPeopleEntry = new PeopleEntry();
                _objPeopleEntry.SearchOption1 = ddlSearch1.SelectedValue.ToString();
                _objPeopleEntry.SearchOption2 = ddlSearch2.SelectedValue.ToString();
                _objPeopleEntry.SearchOption3 = ddlSearch3.SelectedValue.ToString();
                _objPeopleEntry.SearchOption4 = ddlSearch4.SelectedValue.ToString();
                _objPeopleEntryController = new PeopleEntryController();
                _objPeopleEntry.DtPeople = _objPeopleEntryController.GetPeopleRecord(_objPeopleEntry);
                grdPeople.DataSource = null;
                grdPeople.DataBind();
                PanelPeopleRecord.Visible = false;
                if (_objPeopleEntry.DtPeople != null)
                {
                    grdPeople.DataSource = _objPeopleEntry.DtPeople;
                    grdPeople.DataBind();
                    PanelPeopleRecord.Visible = true;
                }

            }
            catch (Exception msgException)
            {
                
                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnAddAcademicRecordToGrid_Click(object sender, EventArgs e)
        {
            try
            {
                var nameOfDegree = txtNameOfDegree.Text == "" ? "" : txtNameOfDegree.Text;
                var institutionName = txtInstitutionName.Text == "" ? "" : txtInstitutionName.Text;
                var board = txtBoardUniversity.Text == "" ? "" : txtBoardUniversity.Text;
                var resultGrade = txtResultsGradeDivision.Text == "" ? "" : txtResultsGradeDivision.Text;
                var passingYear = Convert.ToDouble(txtPassingYear.Text == "" ? 0 : Convert.ToDouble(txtPassingYear.Text));
                var majorGroup = txtMajor.Text == string.Empty ? "" : txtMajor.Text;
                if (btnAddAcademicRecordToGrid.Text == "Update")
                {
                    UpdateAcademicRecord();
                }

                CheckValidation(nameOfDegree);

                BindAcademicQualificationGrid(nameOfDegree, institutionName, board, resultGrade, passingYear, majorGroup);
                ClearControlsOfAcademicRecords();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void CheckValidation(string nameOfDegree)
        {
            try
            {
                if (nameOfDegree == "")
                {
                    throw new Exception(" Name of degree is required");
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private void UpdateAcademicRecord()
        {
            if ((DataTable)ViewState["AcademicQualification"] != null)
            {
                var indexForDelete = Convert.ToInt32(Session["indexAcademicRecords"].ToString());
                var dt = (DataTable)ViewState["AcademicQualification"];
                dt.Rows[indexForDelete].Delete();
                dt.AcceptChanges();
                ViewState["AcademicQualification"] = dt;
                btnAddAcademicRecordToGrid.Text = "Add";
            }

        }
        private void ClearControlsOfAcademicRecords()
        {
            txtNameOfDegree.Text = "";
            txtInstitutionName.Text = "";
            txtBoardUniversity.Text = "";
            txtResultsGradeDivision.Text = "";
            txtPassingYear.Text = "";
            txtMajor.Text = string.Empty;
            txtNameOfDegree.Enabled = true;
            btnAddAcademicRecordToGrid.Text = "Add New";
        }
        private void BindAcademicQualificationGrid(string nameOfDegree, string institutionName, string board, string resultGrade, double passingYear, string majorInGroup)
        {
            var dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new DataColumn("txtNameOfDegree", typeof(String)));
            dt.Columns.Add(new DataColumn("txtInstitutionName", typeof(String)));
            dt.Columns.Add(new DataColumn("txtBoardUniversity", typeof(String)));
            dt.Columns.Add(new DataColumn("txtResultsGradeDivision", typeof(String)));
            dt.Columns.Add(new DataColumn("txtPassingYear", typeof(double)));
            dt.Columns.Add(new DataColumn("txtMajor", typeof(string)));

            if (ViewState["AcademicQualification"] != null)
            {
                var dtTable = (DataTable)ViewState["AcademicQualification"];
                var count = dtTable.Rows.Count;
                for (var i = 0; i < count + 1; i++)
                {
                    dt = (DataTable)ViewState["AcademicQualification"];
                    if (dt.Rows.Count <= 0) continue;
                    dr = dt.NewRow();
                    dr[0] = dt.Rows[0][0].ToString();
                }
                dr = dt.NewRow();
                dr[0] = nameOfDegree;
                dr[1] = institutionName;
                dr[2] = board;
                dr[3] = resultGrade;
                dr[4] = passingYear;
                dr[5] = majorInGroup;

                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = nameOfDegree;
                dr[1] = institutionName;
                dr[2] = board;
                dr[3] = resultGrade;
                dr[4] = passingYear;
                dr[5] = majorInGroup;
                dt.Rows.Add(dr);
            }
            if (ViewState["AcademicQualification"] != null)
            {
                grdAcademicRecords.DataSource = ViewState["AcademicQualification"];
                grdAcademicRecords.DataBind();
            }
            else
            {
                grdAcademicRecords.DataSource = dt;
                grdAcademicRecords.DataBind();

            }
            ViewState["AcademicQualification"] = dt;
        }

        protected void grdAcademicRecords_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
            }

        }

        protected void grdAcademicRecords_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdAcademicRecords_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                var con = Convert.ToInt32(e.CommandArgument.ToString());

                if (e.CommandName.Equals("Select"))
                {
                    Session["indexAcademicRecords"] = con;
                    txtNameOfDegree.Text = grdAcademicRecords.Rows[con].Cells[1].Text == "&nbsp;" ? "" : grdAcademicRecords.Rows[con].Cells[1].Text;
                    txtInstitutionName.Text = grdAcademicRecords.Rows[con].Cells[2].Text == "&nbsp;" ? "" : grdAcademicRecords.Rows[con].Cells[2].Text;
                    txtBoardUniversity.Text = grdAcademicRecords.Rows[con].Cells[3].Text == "&nbsp;" ? "" : grdAcademicRecords.Rows[con].Cells[3].Text;
                    txtMajor.Text = grdAcademicRecords.Rows[con].Cells[4].Text == "&nbsp;" ? "" : grdAcademicRecords.Rows[con].Cells[4].Text;
                    txtResultsGradeDivision.Text = grdAcademicRecords.Rows[con].Cells[5].Text == "&nbsp;" ? "" : grdAcademicRecords.Rows[con].Cells[5].Text;
                    txtPassingYear.Text = grdAcademicRecords.Rows[con].Cells[6].Text == "&nbsp;" ? "" : grdAcademicRecords.Rows[con].Cells[6].Text;
                    btnAddAcademicRecordToGrid.Text = "Update";
                    txtNameOfDegree.Enabled = false;
                    PanelAcademicRecord.Visible = true;
                    btnCancelAcademicRecord.Visible = true;
                }
                else
                {
                    if (!e.CommandName.Equals("Delete")) return;
                    var dt = (DataTable)ViewState["AcademicQualification"];
                    dt.Rows[con].Delete();
                    dt.AcceptChanges();
                    ViewState["AcademicQualification"] = dt;
                    if (ViewState["AcademicQualification"] == null) return;
                    grdAcademicRecords.DataSource = ViewState["AcademicQualification"];
                    grdAcademicRecords.DataBind();
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void grdPeople_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdPeople_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                var selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
                _objPeopleEntry = new PeopleEntry();
                if (e.CommandName.Equals("Select"))
                {
                    txtPeopleName.Text = grdPeople.Rows[selectedIndex].Cells[1].Text == "&nbsp;" ? "" : grdPeople.Rows[selectedIndex].Cells[1].Text;
                    PanelDataEntry.Visible = true;
                    btnCancel.Visible = true;
                    btnAddNew.Text = "Save";
                    lblGridTitle.Text = clsMessages.GYouareAddingData;
                }
                else
                {
                    if (!e.CommandName.Equals("Delete")) return;
                    _objPeopleEntryController = new PeopleEntryController();
                    _objPeopleEntryController.DeletePeopleRecord(_objPeopleEntry);
                }
            }
            catch (Exception msgException)
            {
                clsTopMostMessageBox.Show(msgException.Message);
            }
        }
    }
}