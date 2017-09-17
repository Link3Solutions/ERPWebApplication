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


namespace ERPWebApplication.ModuleName.Accounts.MasterPage
{
    public partial class JournalVoucherForm : System.Web.UI.Page
    {
        private JournalVoucherController _objJournalVoucherController;
        private JournalVoucher _objJournalVoucher;
        private CoaHead _objCoaHead;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                _objJournalVoucherController = new JournalVoucherController();
                _objJournalVoucherController.LoadJournalTypeDDL(ddlJournalType);
                _objJournalVoucherController.LoadTransactionTypeDDL(ddlTransactionType);
                _objJournalVoucherController.LoadVoucherTypeDDL(ddlVoucherType);
                grdVoucher.DataSource = ViewState["voucherInformation"];
                grdVoucher.DataBind();
                txtAccCode_AutoCompleteExtender.ContextKey = LoginUserInformation.CompanyID.ToString();
                btnSave.Visible = false;

            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesVoucherEntry();
                this.ControlButtonVisible();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void AddValuesVoucherEntry()
        {
            try
            {
                _objJournalVoucher = new JournalVoucher();
                _objJournalVoucher.JournalTypeID = Convert.ToInt32(ddlJournalType.SelectedValue);
                if (_objJournalVoucher.JournalTypeID == -1)
                {
                    _objJournalVoucher.JournalTypeID = null;

                }

                _objJournalVoucher.TransactionTypeID = Convert.ToInt32(ddlTransactionType.SelectedValue);
                if (_objJournalVoucher.TransactionTypeID == -1)
                {
                    _objJournalVoucher.TransactionTypeID = null;

                }

                _objJournalVoucher.TransactionTypeText = ddlTransactionType.SelectedItem.Text;
                _objJournalVoucher.VoucherTypeID = ddlVoucherType.SelectedValue == "-1" ? null : ddlVoucherType.SelectedValue;
                _objJournalVoucher.VoucherDate = Convert.ToDateTime(txtJournalDate.Text);
                _objCoaHead = new CoaHead();
                _objCoaHead.AccountNo = Convert.ToInt32(txtAccCode.Text.Split(':')[0].Trim() == string.Empty ? null : txtAccCode.Text.Split(':')[0].Trim());
                _objCoaHead.AccountName = txtAccCode.Text.Split(':')[1].Trim() == string.Empty ? null : txtAccCode.Text.Split(':')[1].Trim();
                _objJournalVoucher.TransactionCurrencyAmount = Convert.ToDecimal(txtAmount.Text);
                _objJournalVoucher.CurrencyRate = Convert.ToDecimal(txtCurrencyRate.Text);
                _objJournalVoucher.BaseAmount = Convert.ToDecimal(txtBaseAmount.Text);
                _objJournalVoucher.Particulars = txtNarration.Text;
                if (_objJournalVoucher.VoucherTypeID == "0")
                {
                    _objJournalVoucher.Credit = _objJournalVoucher.BaseAmount;
                    _objJournalVoucher.Debit = 0;

                }
                else
                {
                    _objJournalVoucher.Debit = _objJournalVoucher.BaseAmount;
                    _objJournalVoucher.Credit = 0;
                }

                var dtTable = (DataTable)ViewState["voucherInformation"];
                _objJournalVoucher.SlNo = dtTable == null ? 1 : this.GetMaxColumnValue(dtTable) + 1;
                CoaHeadController objCoaHeadController = new CoaHeadController();
                if (objCoaHeadController.CheckAnalysisrequired(_objCoaHead) == "Y")
                {
                    ModalPopupExtender1.Show();
                    lblAccountCode.Text = _objCoaHead.AccountNo.ToString();
                    lblAccountName.Text = _objCoaHead.AccountName;
                    txttotalamt.Text = _objJournalVoucher.TransactionCurrencyAmount.ToString();
                    txtbalamt.Text = _objJournalVoucher.TransactionCurrencyAmount.ToString();

                    ClearAllAnalysisDDL();

                    _objJournalVoucherController = new JournalVoucherController();
                    _objJournalVoucher.DtAssignSubLedgerType = _objJournalVoucherController.GetAssignedSubLedgerType(_objCoaHead);

                    if (_objJournalVoucher.DtAssignSubLedgerType.Rows.Count > 0)
                    {
                        SubledgerSetup objSubledgerSetup;
                        foreach (DataRow rowNo in _objJournalVoucher.DtAssignSubLedgerType.Rows)
                        {
                            int index = _objJournalVoucher.DtAssignSubLedgerType.Rows.IndexOf(rowNo);
                            objSubledgerSetup = new SubledgerSetup();
                            objSubledgerSetup.SubledgerTypeID = rowNo["SubledgerTypeID"].ToString();
                            switch (Convert.ToInt32(index))
                            {
                                case 0:
                                    {
                                        _objJournalVoucherController.LoadAnalysisDDL(ddl1st, objSubledgerSetup);
                                        break;
                                    }
                                case 1:
                                    {
                                        _objJournalVoucherController.LoadAnalysisDDL(ddl2nd, objSubledgerSetup);
                                        break;
                                    }
                                case 2:
                                    {
                                        _objJournalVoucherController.LoadAnalysisDDL(ddl3rd, objSubledgerSetup);
                                        break;
                                    }
                                case 3:
                                    {
                                        _objJournalVoucherController.LoadAnalysisDDL(ddl4th, objSubledgerSetup);
                                        break;
                                    }
                                case 4:
                                    {
                                        _objJournalVoucherController.LoadAnalysisDDL(ddl5th, objSubledgerSetup);
                                        break;
                                    }
                                default: break;
                            }

                        }

                    }
                }
                else
                {
                    ModalPopupExtender1.Hide();
                }

                this.BindVoucherInformationGrid(_objJournalVoucher, _objCoaHead);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void ClearAllAnalysisDDL()
        {
            try
            {
                ddl1st.Items.Clear();
                ddl2nd.Items.Clear();
                ddl3rd.Items.Clear();
                ddl4th.Items.Clear();
                ddl5th.Items.Clear();
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private decimal GetMaxColumnValue(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count == 0)
                {
                    return 0;
                }
                else
                {
                    dt.DefaultView.Sort = "SlNo DESC";
                    return Decimal.Parse(dt.DefaultView[0]["SlNo"].ToString());

                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private void BindVoucherInformationGrid(JournalVoucher objJournalVoucher, CoaHead objCoaHead)
        {
            try
            {
                var dt = new DataTable();
                DataRow dr;

                dt.Columns.Add("AccountingCode", typeof(string));
                dt.Columns.Add("AccountingName", typeof(string));
                dt.Columns.Add("Particulars", typeof(string));
                dt.Columns.Add("Debit", typeof(double));
                dt.Columns.Add("Credit", typeof(double));
                dt.Columns.Add("Type", typeof(string));
                dt.Columns.Add("Typeid", typeof(string));
                dt.Columns.Add("Trtype", typeof(string));
                dt.Columns.Add("CurrencyRate", typeof(double));
                dt.Columns.Add("SlNo", typeof(int));

                if (ViewState["voucherInformation"] != null)
                {
                    var dtTable = (DataTable)ViewState["voucherInformation"];
                    var count = dtTable.Rows.Count;
                    for (var i = 0; i < count + 1; i++)
                    {
                        dt = (DataTable)ViewState["voucherInformation"];
                        if (dt.Rows.Count <= 0) continue;
                        dr = dt.NewRow();
                        dr[0] = dt.Rows[0][0].ToString();
                    }
                    dr = dt.NewRow();
                    dr[0] = objCoaHead.AccountNo;
                    dr[1] = objCoaHead.AccountName;
                    dr[2] = objJournalVoucher.Particulars;
                    dr[3] = objJournalVoucher.Debit;
                    dr[4] = objJournalVoucher.Credit;
                    dr[5] = objJournalVoucher.VoucherTypeID;
                    dr[6] = objJournalVoucher.TransactionTypeID;
                    dr[7] = objJournalVoucher.TransactionTypeText;
                    dr[8] = objJournalVoucher.CurrencyRate;
                    dr[9] = objJournalVoucher.SlNo;

                    dt.Rows.Add(dr);

                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = objCoaHead.AccountNo;
                    dr[1] = objCoaHead.AccountName;
                    dr[2] = objJournalVoucher.Particulars;
                    dr[3] = objJournalVoucher.Debit;
                    dr[4] = objJournalVoucher.Credit;
                    dr[5] = objJournalVoucher.VoucherTypeID;
                    dr[6] = objJournalVoucher.TransactionTypeID;
                    dr[7] = objJournalVoucher.TransactionTypeText;
                    dr[8] = objJournalVoucher.CurrencyRate;
                    dr[9] = objJournalVoucher.SlNo;


                    dt.Rows.Add(dr);
                }
                if (ViewState["voucherInformation"] != null)
                {
                    DataTable dtTemp = (DataTable)ViewState["voucherInformation"];
                    dtTemp.DefaultView.Sort = "SlNo DESC";
                    dtTemp = dtTemp.DefaultView.ToTable();
                    //grdVoucher.DataSource = ViewState["voucherInformation"];
                    grdVoucher.DataSource = dtTemp;
                    grdVoucher.DataBind();
                }
                else
                {
                    dt.DefaultView.Sort = "SlNo DESC";
                    dt = dt.DefaultView.ToTable();
                    grdVoucher.DataSource = dt;
                    grdVoucher.DataBind();

                }
                ViewState["voucherInformation"] = dt;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private void ControlButtonVisible()
        {
            try
            {
                if (grdVoucher.Rows.Count > 0)
                {
                    btnSave.Visible = true;
                }
                else
                {
                    btnSave.Visible = false;
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void grdVoucher_Sorting(object sender, GridViewSortEventArgs e)
        {
            // If you want to only switch default for some column, disable comment
            //switch (e.SortExpression)
            //{
            //    case "MyDataField01":
            //    case "MyDataField03":

            //if (e.SortExpression != ((GridView)sender).SortExpression)
            //{
            //    e.SortDirection = SortDirection.Descending;
            //}

            //        break;
            //    default:
            //        break;
            //}
        }

        protected void grdVoucher_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                var con = Convert.ToInt32(e.CommandArgument.ToString());
                if (!e.CommandName.Equals("Delete")) return;
                var dt = (DataTable)ViewState["voucherInformation"];
                dt.DefaultView.Sort = "SlNo DESC";
                dt = dt.DefaultView.ToTable();
                dt.Rows[con].Delete();
                dt.AcceptChanges();
                dt.DefaultView.Sort = "SlNo DESC";
                dt = dt.DefaultView.ToTable();
                ViewState["voucherInformation"] = dt;
                if (ViewState["voucherInformation"] == null) return;
                grdVoucher.DataSource = ViewState["voucherInformation"];
                grdVoucher.DataBind();
                this.ControlButtonVisible();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void grdVoucher_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdVoucher_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //GridView grdSubLedger = ((GridView)grdVoucher.Rows[1].FindControl("grdSubLedger"));
            //grdSubLedger.DataSource = ViewState["voucherInformation"];
            //grdSubLedger.DataBind();
        }

        protected void btnInsertAnalysis_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesAnalysis();
                if (txtbalamt.Text == 0.ToString())
                {
                    ModalPopupExtender1.Hide();
                }
                else
                {
                    ModalPopupExtender1.Show();
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
                ModalPopupExtender1.Show();
            }

        }

        private void AddValuesAnalysis()
        {
            try
            {
                _objCoaHead = new CoaHead();
                _objCoaHead.AccountNo = Convert.ToInt32( lblAccountCode.Text);               
                _objJournalVoucher = new JournalVoucher();
                _objJournalVoucher.TransactionCurrencyAmount = Convert.ToDecimal( txttotalamt.Text);

                if (ddl1st.Items.Count > 1)
                {
                    _objJournalVoucher.AnalysisValue1st = ddl1st.SelectedValue == "-1" ? null : ddl1st.SelectedValue;
                    _objJournalVoucher.AnalysisText1st = ddl1st.SelectedItem.Text;
                }

                if (ddl2nd.Items.Count > 1)
                {
                    _objJournalVoucher.AnalysisValue2nd = ddl2nd.SelectedValue == "-1" ? null : ddl2nd.SelectedValue;
                    _objJournalVoucher.AnalysisText2nd = ddl2nd.SelectedItem.Text;
                    
                }

                if (ddl3rd.Items.Count > 1)
                {
                    _objJournalVoucher.AnalysisValue3rd = ddl3rd.SelectedValue == "-1" ? null : ddl3rd.SelectedValue;
                    _objJournalVoucher.AnalysisText3rd = ddl3rd.SelectedItem.Text;
                }

                if (ddl4th.Items.Count > 1)
                {
                    _objJournalVoucher.AnalysisValue4th = ddl4th.SelectedValue == "-1" ? null : ddl4th.SelectedValue;
                    _objJournalVoucher.AnalysisText4th = ddl4th.SelectedItem.Text;
                }

                if (ddl5th.Items.Count > 1)
                {
                    _objJournalVoucher.AnalysisValue5th = ddl5th.SelectedValue == "-1" ? null : ddl5th.SelectedValue;
                    _objJournalVoucher.AnalysisText5th = ddl5th.SelectedItem.Text;
                }

                var dtTable = (DataTable)ViewState["analysisInformation"];
                CGlobalMethod objCGlobalMethod = new CGlobalMethod();
                _objJournalVoucher.SlNo = dtTable == null ? 1 : objCGlobalMethod.GetMaxColumnValue(dtTable) + 1;
                _objJournalVoucher.SubLegerAmount = Convert.ToDecimal( txtsplitamt.Text == string.Empty ? 0 : Convert.ToDecimal( txtsplitamt.Text));
                this.BindAnalysisInformationGrid(_objJournalVoucher, _objCoaHead);
                

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
        private void BindAnalysisInformationGrid(JournalVoucher objJournalVoucher, CoaHead objCoaHead)
        {
            try
            {
                var dt = new DataTable();
                DataRow dr;

                dt.Columns.Add("AccountingCode", typeof(string));
                dt.Columns.Add("1stAnalysisValue", typeof(string));
                dt.Columns.Add("2ndAnalysisValue", typeof(string));
                dt.Columns.Add("3rdAnalysisValue", typeof(string));
                dt.Columns.Add("4thAnalysisValue", typeof(string));
                dt.Columns.Add("5thAnalysisValue", typeof(string));
                dt.Columns.Add("1stAnalysisText", typeof(string));
                dt.Columns.Add("2ndAnalysisText", typeof(string));
                dt.Columns.Add("3rdAnalysisText", typeof(string));
                dt.Columns.Add("4thAnalysisText", typeof(string));
                dt.Columns.Add("5thAnalysisText", typeof(string));
                dt.Columns.Add("SubLegerAmount", typeof(double));
                dt.Columns.Add("SlNo", typeof(int));

                if (ViewState["analysisInformation"] != null)
                {
                    var dtTable = (DataTable)ViewState["analysisInformation"];
                    var count = dtTable.Rows.Count;
                    for (var i = 0; i < count + 1; i++)
                    {
                        dt = (DataTable)ViewState["analysisInformation"];
                        if (dt.Rows.Count <= 0) continue;
                        dr = dt.NewRow();
                        dr[0] = dt.Rows[0][0].ToString();
                    }
                    dr = dt.NewRow();
                    dr[0] = objCoaHead.AccountNo;
                    dr[1] = objJournalVoucher.AnalysisValue1st;
                    dr[2] = objJournalVoucher.AnalysisValue2nd;
                    dr[3] = objJournalVoucher.AnalysisValue3rd;
                    dr[4] = objJournalVoucher.AnalysisValue4th;
                    dr[5] = objJournalVoucher.AnalysisValue5th;
                    dr[6] = objJournalVoucher.AnalysisText1st;
                    dr[7] = objJournalVoucher.AnalysisText2nd;
                    dr[8] = objJournalVoucher.AnalysisText3rd;
                    dr[9] = objJournalVoucher.AnalysisText4th;
                    dr[10] = objJournalVoucher.AnalysisText5th;
                    dr[11] = objJournalVoucher.SubLegerAmount;
                    dr[12] = objJournalVoucher.SlNo;

                    dt.Rows.Add(dr);

                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = objCoaHead.AccountNo;
                    dr[1] = objJournalVoucher.AnalysisValue1st;
                    dr[2] = objJournalVoucher.AnalysisValue2nd;
                    dr[3] = objJournalVoucher.AnalysisValue3rd;
                    dr[4] = objJournalVoucher.AnalysisValue4th;
                    dr[5] = objJournalVoucher.AnalysisValue5th;
                    dr[6] = objJournalVoucher.AnalysisText1st;
                    dr[7] = objJournalVoucher.AnalysisText2nd;
                    dr[8] = objJournalVoucher.AnalysisText3rd;
                    dr[9] = objJournalVoucher.AnalysisText4th;
                    dr[10] = objJournalVoucher.AnalysisText5th;
                    dr[11] = objJournalVoucher.SubLegerAmount;
                    dr[12] = objJournalVoucher.SlNo;


                    dt.Rows.Add(dr);
                }
                if (ViewState["analysisInformation"] != null)
                {
                    DataTable dtTemp = (DataTable)ViewState["analysisInformation"];
                    dtTemp.DefaultView.Sort = "SlNo DESC";
                    dtTemp = dtTemp.DefaultView.ToTable();
                    grdAnalysis.DataSource = dtTemp;
                    grdAnalysis.DataBind();
                }
                else
                {
                    dt.DefaultView.Sort = "SlNo DESC";
                    dt = dt.DefaultView.ToTable();
                    grdAnalysis.DataSource = dt;
                    grdAnalysis.DataBind();

                }
                ViewState["analysisInformation"] = dt;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void grdAnalysis_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[13].Visible = false;
        }


    }
}