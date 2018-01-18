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
        private BranchSetup _objBranchSetup;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
                    txtReferenceJournal_AutoCompleteExtender.ContextKey = LoginUserInformation.CompanyID.ToString();
                    btnSubmit.Visible = false;
                    btnPost.Visible = false;
                    LoadCurrencyDDL();
                    btnSave.Visible = false;
                    panelForTotal.Visible = false;
                    _objJournalVoucherController.LoadTransactionTypeDDL(ddlTransactionTypeSearchTab2);
                    txtAccountCodeSearchTab2_AutoCompleteExtender.ContextKey = LoginUserInformation.CompanyID.ToString();
                    PanelAdvancedSearch.Visible = false;
                    btnPostTab2.Visible = false;
                    btnClearTab2.Visible = false;
                    LoadSubmitteVoucherAll();
                    txtVoucherNoSearchTab2_AutoCompleteExtender.ContextKey = LoginUserInformation.CompanyID.ToString();
                    txtSearchTab1_AutoCompleteExtender.ContextKey = LoginUserInformation.CompanyID.ToString() + ":" + LoginUserInformation.UserID.ToString();
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        private void LoadSubmitteVoucherAll()
        {
            try
            {
                _objJournalVoucher = new JournalVoucher();
                _objBranchSetup = new BranchSetup();
                _objJournalVoucherController = new JournalVoucherController();
                _objBranchSetup.CompanyID = LoginUserInformation.CompanyID;
                _objJournalVoucher.DtSubmittedJournal = _objJournalVoucherController.GetSubmittedJournal(_objBranchSetup);
                LoadSubmittedVoucher(_objJournalVoucher);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void LoadSubmittedVoucher(JournalVoucher objJournalVoucher)
        {
            try
            {
                grdUnpostedVoucher.DataSource = null;
                grdUnpostedVoucher.DataBind();
                if (objJournalVoucher.DtSubmittedJournal != null)
                {
                    grdUnpostedVoucher.DataSource = objJournalVoucher.DtSubmittedJournal;
                    grdUnpostedVoucher.DataBind();

                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void LoadCurrencyDDL()
        {
            try
            {
                _objJournalVoucherController = new JournalVoucherController();
                _objJournalVoucherController.GetCurrency(ddlCurrency);
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
                AddValuesVoucherEntry();
                this.ControlButtonVisible();
                ClearControlAfterAdd();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ClearControlAfterAdd()
        {
            try
            {
                txtAccCode.Text = string.Empty;
                this.LoadCurrencyDDL();
                txtCurrencyRate.Text = string.Empty;
                txtAmount.Text = string.Empty;
                txtBaseAmount.Text = string.Empty;
                txtNarration.Text = string.Empty;
                btnAdd.Text = "Add";
                ddlVoucherType.SelectedValue = "-1";
            }
            catch (Exception msgException)
            {

                throw msgException;
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
                try
                {
                    _objCoaHead = new CoaHead();
                    _objCoaHead.AccountNo = Convert.ToInt32(txtAccCode.Text.Split(':')[0].Trim() == string.Empty ? null : txtAccCode.Text.Split(':')[0].Trim());
                    _objCoaHead.AccountName = txtAccCode.Text.Split(':')[1].Trim() == string.Empty ? null : txtAccCode.Text.Split(':')[1].Trim();
                }
                catch (Exception)
                {
                    throw new Exception(" Account Code is required ");
                }


                if (ddlCurrency.SelectedValue == "-1")
                {
                    _objJournalVoucher.CurrencyID = null;
                }
                else
                {
                    _objJournalVoucher.CurrencyID = Convert.ToInt32(ddlCurrency.SelectedValue);
                }

                _objJournalVoucher.CurrencyRate = Convert.ToDecimal(txtCurrencyRate.Text);
                if (txtAmount.Text == string.Empty)
                {
                    _objJournalVoucher.TransactionCurrencyAmount = null;
                }
                else
                {
                    _objJournalVoucher.TransactionCurrencyAmount = Convert.ToDecimal(txtAmount.Text);
                }

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
                Session["TranactionLineNoSubLedger"] = _objJournalVoucher.SlNo;
                CoaHeadController objCoaHeadController = new CoaHeadController();
                if (objCoaHeadController.CheckAnalysisrequired(_objCoaHead) == "Y")
                {
                    ClearSubledgerRecords();
                    ModalPopupExtender1.Show();
                    lblAccountCode.Text = _objCoaHead.AccountNo.ToString();
                    lblAccountName.Text = ":" + _objCoaHead.AccountName;
                    lbltotalamt.Text = _objJournalVoucher.BaseAmount.ToString();
                    txtbalamt.Text = this.GetBalanceAmount();

                    if (ViewState["analysisInformation"] != null)
                    {
                        grdAnalysis.DataSource = ViewState["analysisInformation"];
                        grdAnalysis.DataBind();
                    }

                    btnInsertAnalysis.Text = "Insert";


                    ClearAllAnalysisDDL();

                    _objJournalVoucherController = new JournalVoucherController();
                    _objJournalVoucher.DtAssignSubLedgerType = _objJournalVoucherController.GetAssignedSubLedgerType(_objCoaHead);

                    ClearAllSubLedgerTypeID();
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
                                        Session["SubLedgerTypeID1"] = objSubledgerSetup.SubledgerTypeID;
                                        _objJournalVoucherController.LoadAnalysisDDL(ddl1st, objSubledgerSetup);
                                        break;
                                    }
                                case 1:
                                    {
                                        Session["SubLedgerTypeID2"] = objSubledgerSetup.SubledgerTypeID;
                                        _objJournalVoucherController.LoadAnalysisDDL(ddl2nd, objSubledgerSetup);
                                        break;
                                    }
                                case 2:
                                    {
                                        Session["SubLedgerTypeID3"] = objSubledgerSetup.SubledgerTypeID;
                                        _objJournalVoucherController.LoadAnalysisDDL(ddl3rd, objSubledgerSetup);
                                        break;
                                    }
                                case 3:
                                    {
                                        Session["SubLedgerTypeID4"] = objSubledgerSetup.SubledgerTypeID;
                                        _objJournalVoucherController.LoadAnalysisDDL(ddl4th, objSubledgerSetup);
                                        break;
                                    }
                                case 4:
                                    {
                                        Session["SubLedgerTypeID5"] = objSubledgerSetup.SubledgerTypeID;
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

                if (btnAdd.Text == "Edit")
                {
                    _objJournalVoucher.SlNo = Convert.ToInt32(Session["slNoAlign"].ToString());
                    DeleteVoucherEntry();
                }

                this.BindVoucherInformationGrid(_objJournalVoucher, _objCoaHead);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void DeleteVoucherEntry()
        {
            try
            {
                var dt = (DataTable)ViewState["voucherInformation"];
                dt.DefaultView.Sort = "SlNo DESC";
                dt = dt.DefaultView.ToTable();
                dt.Rows[Convert.ToInt32(Session["selectedIndexVoucherEntry"].ToString())].Delete();
                dt.AcceptChanges();
                dt.DefaultView.Sort = "SlNo DESC";
                dt = dt.DefaultView.ToTable();
                ViewState["voucherInformation"] = dt;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void ClearSubledgerRecords()
        {
            try
            {
                //ViewState["analysisInformation"] = null;
                //DataTable dtTemp = (DataTable)ViewState["analysisInformation"];
                //grdAnalysis.DataSource = dtTemp;
                //grdAnalysis.DataBind();
                txtsplitamt.Text = string.Empty;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void ClearAllSubLedgerTypeID()
        {
            try
            {
                Session["SubLedgerTypeID1"] = string.Empty;
                Session["SubLedgerTypeID2"] = string.Empty;
                Session["SubLedgerTypeID3"] = string.Empty;
                Session["SubLedgerTypeID4"] = string.Empty;
                Session["SubLedgerTypeID5"] = string.Empty;
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
                dt.Columns.Add("BaseAmount", typeof(decimal));
                dt.Columns.Add("TransactionAmount", typeof(decimal));
                dt.Columns.Add("CurrencyID", typeof(int));

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
                    dr[10] = objJournalVoucher.BaseAmount;
                    dr[11] = objJournalVoucher.TransactionCurrencyAmount;
                    dr[12] = objJournalVoucher.CurrencyID;


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
                    dr[10] = objJournalVoucher.BaseAmount;
                    dr[11] = objJournalVoucher.TransactionCurrencyAmount;
                    dr[12] = objJournalVoucher.CurrencyID;


                    dt.Rows.Add(dr);
                }
                if (ViewState["voucherInformation"] != null)
                {
                    DataTable dtTemp = (DataTable)ViewState["voucherInformation"];
                    dtTemp.DefaultView.Sort = "SlNo DESC";
                    dtTemp = dtTemp.DefaultView.ToTable();
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
                    panelForTotal.Visible = true;
                    decimal countDebit = 0;
                    decimal countCredit = 0;
                    foreach (GridViewRow rowNo in grdVoucher.Rows)
                    {
                        string lblDebit = ((Label)rowNo.FindControl("lblDebit")).Text;
                        countDebit += Convert.ToDecimal(lblDebit);
                        string lblCredit = ((Label)rowNo.FindControl("lblCredit")).Text;
                        countCredit += Convert.ToDecimal(lblCredit);
                    }

                    if (countDebit == countCredit)
                    {
                        btnSubmit.Visible = true;
                        btnPost.Visible = true;
                    }
                    else
                    {
                        btnSubmit.Visible = false;
                        btnPost.Visible = false;
                    }

                }
                else
                {
                    btnSubmit.Visible = false;
                    btnPost.Visible = false;
                    btnSave.Visible = false;
                    panelForTotal.Visible = false;
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void grdVoucher_Sorting(object sender, GridViewSortEventArgs e)
        {
            
        }

        protected void grdVoucher_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                var selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
                Session["selectedIndexVoucherEntry"] = selectedIndex;
                string lblSlNoAlign = ((Label)grdVoucher.Rows[selectedIndex].FindControl("lblSlNoAlign")).Text;
                if (e.CommandName.Equals("Select"))
                {
                    string lblAccountingName = ((Label)grdVoucher.Rows[selectedIndex].FindControl("lblAccountingName")).Text;
                    string lblAccountingCode = ((Label)grdVoucher.Rows[selectedIndex].FindControl("lblAccountingCode")).Text;
                    string lblParticulars = ((Label)grdVoucher.Rows[selectedIndex].FindControl("lblParticulars")).Text;
                    string lblDebit = ((Label)grdVoucher.Rows[selectedIndex].FindControl("lblDebit")).Text;
                    string lblCredit = ((Label)grdVoucher.Rows[selectedIndex].FindControl("lblCredit")).Text;
                    string lblType = ((Label)grdVoucher.Rows[selectedIndex].FindControl("lblType")).Text;
                    string lblTypeid = ((Label)grdVoucher.Rows[selectedIndex].FindControl("lblTypeid")).Text;
                    string lblTrtype = ((Label)grdVoucher.Rows[selectedIndex].FindControl("lblTrtype")).Text;
                    string lblCurrencyRate = ((Label)grdVoucher.Rows[selectedIndex].FindControl("lblCurrencyRate")).Text;
                    string lblBaseAmount = ((Label)grdVoucher.Rows[selectedIndex].FindControl("lblBaseAmount")).Text;
                    string lblTransactionAmount = ((Label)grdVoucher.Rows[selectedIndex].FindControl("lblTransactionAmount")).Text;
                    string lblCurrencyID = ((Label)grdVoucher.Rows[selectedIndex].FindControl("lblCurrencyID")).Text;


                    txtAccCode.Text = lblAccountingCode + ":" + lblAccountingName;
                    ddlCurrency.SelectedValue = lblCurrencyID;
                    txtCurrencyRate.Text = lblCurrencyRate;
                    txtAmount.Text = lblTransactionAmount;
                    txtBaseAmount.Text = lblBaseAmount;
                    txtNarration.Text = lblParticulars;
                    Session["slNoAlign"] = lblSlNoAlign;
                    ddlVoucherType.SelectedValue = lblType;
                    btnAdd.Text = "Edit";


                }

                if (!e.CommandName.Equals("Delete")) return;
                var dt = (DataTable)ViewState["voucherInformation"];
                dt.DefaultView.Sort = "SlNo DESC";
                dt = dt.DefaultView.ToTable();
                dt.Rows[selectedIndex].Delete();
                dt.AcceptChanges();
                dt.DefaultView.Sort = "SlNo DESC";
                dt = dt.DefaultView.ToTable();
                ViewState["voucherInformation"] = dt;
                if (ViewState["voucherInformation"] == null) return;
                grdVoucher.DataSource = ViewState["voucherInformation"];
                grdVoucher.DataBind();
                _objJournalVoucher = new JournalVoucher();
                _objJournalVoucher.TranactionLineNo = Convert.ToInt32(lblSlNoAlign);
                this.DeleteSubledgerRecord(_objJournalVoucher);
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
        double debitAmount = 0;
        double creditAmount = 0;
        protected void grdVoucher_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[10].ColumnSpan = 2;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblDebitGrid = (e.Row.FindControl("lblDebit") as Label);
                Label lblCreditGrid = (e.Row.FindControl("lblCredit") as Label);
                debitAmount += Convert.ToDouble(lblDebitGrid.Text);
                creditAmount += Convert.ToDouble(lblCreditGrid.Text);
                lblDebit.Text = string.Format("{0:n2}", debitAmount);
                lblCredit.Text = string.Format("{0:n2}", creditAmount);
            }
        }

        protected void btnInsertAnalysis_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesAnalysis();
                txtbalamt.Text = this.GetBalanceAmount();
                if (txtbalamt.Text == ("0").ToString() || txtbalamt.Text == ("0.00").ToString())
                {
                    ModalPopupExtender1.Hide();
                }
                else
                {
                    ModalPopupExtender1.Show();
                }

                txtsplitamt.Text = string.Empty;
                btnInsertAnalysis.Text = "Insert";
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
                _objCoaHead.AccountNo = Convert.ToInt32(lblAccountCode.Text);
                _objJournalVoucher = new JournalVoucher();
                _objJournalVoucher.TransactionCurrencyAmount = Convert.ToDecimal(lbltotalamt.Text);

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
                _objJournalVoucher.BalanceAmount = txtbalamt.Text == string.Empty ? 0 : Convert.ToDecimal(txtbalamt.Text);
                _objJournalVoucher.SubLegerAmount = txtsplitamt.Text == string.Empty ? 0 : Convert.ToDecimal(txtsplitamt.Text);
                _objJournalVoucher.TranactionLineNoSubLedger = Convert.ToInt32(Session["TranactionLineNoSubLedger"].ToString());

                int countExistingSubledger = CheckSubledgerRecord(_objCoaHead, _objJournalVoucher);
                if (countExistingSubledger > 0)
                {
                    throw new Exception(clsMessages.GExist);
                }


                if (btnInsertAnalysis.Text == "Edit")
                {
                    _objJournalVoucher.SlNo = Convert.ToInt32(Session["slNoSubledgerAlign"].ToString());
                    DeleteSubledgerRecord();
                }

                this.BindAnalysisInformationGrid(_objJournalVoucher, _objCoaHead);


            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private int CheckSubledgerRecord(CoaHead objCoaHead, JournalVoucher objJournalVoucher)
        {
            try
            {
                int countRecord = 0;
                if (grdAnalysis.Rows.Count > 0)
                {
                    foreach (GridViewRow rowNo in grdAnalysis.Rows)
                    {
                        if (btnInsertAnalysis.Text == "Edit")
                        {
                            string lblSlNoSubledger = ((Label)rowNo.FindControl("lblSlNo")).Text;
                            if (Convert.ToInt32(Session["slNoSubledgerAlign"].ToString()) == Convert.ToInt32(lblSlNoSubledger))
                            {
                                continue;
                            }

                        }

                        string lblAccountingCode = ((Label)rowNo.FindControl("lblAccountingCode")).Text == "" ? null : ((Label)rowNo.FindControl("lblAccountingCode")).Text;
                        string lbl1stAnalysisValue = ((Label)rowNo.FindControl("lbl1stAnalysisValue")).Text == "" ? null : ((Label)rowNo.FindControl("lbl1stAnalysisValue")).Text;
                        string lbl2ndAnalysisValue = ((Label)rowNo.FindControl("lbl2ndAnalysisValue")).Text == "" ? null : ((Label)rowNo.FindControl("lbl2ndAnalysisValue")).Text;
                        string lbl3rdAnalysisValue = ((Label)rowNo.FindControl("lbl3rdAnalysisValue")).Text == "" ? null : ((Label)rowNo.FindControl("lbl3rdAnalysisValue")).Text;
                        string lbl4thAnalysisValue = ((Label)rowNo.FindControl("lbl4thAnalysisValue")).Text == "" ? null : ((Label)rowNo.FindControl("lbl4thAnalysisValue")).Text;
                        string lbl5thAnalysisValue = ((Label)rowNo.FindControl("lbl5thAnalysisValue")).Text == "" ? null : ((Label)rowNo.FindControl("lbl5thAnalysisValue")).Text;
                        if (objCoaHead.AccountNo == Convert.ToInt32(lblAccountingCode) &&
                            objJournalVoucher.AnalysisValue1st == lbl1stAnalysisValue &&
                            objJournalVoucher.AnalysisValue2nd == lbl2ndAnalysisValue &&
                            objJournalVoucher.AnalysisValue3rd == lbl3rdAnalysisValue &&
                            objJournalVoucher.AnalysisValue4th == lbl4thAnalysisValue &&
                            objJournalVoucher.AnalysisValue5th == lbl5thAnalysisValue)
                        {
                            countRecord++;
                        }

                    }

                }
                return countRecord;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void DeleteSubledgerRecord()
        {
            try
            {
                var dt = (DataTable)ViewState["analysisInformation"];
                dt.DefaultView.Sort = "SlNo DESC";
                dt = dt.DefaultView.ToTable();
                dt.Rows[Convert.ToInt32(Session["selectedIndexSubledger"].ToString())].Delete();
                dt.AcceptChanges();
                dt.DefaultView.Sort = "SlNo DESC";
                dt = dt.DefaultView.ToTable();
                ViewState["analysisInformation"] = dt;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private void DeleteSubledgerRecord(JournalVoucher objJournalVoucher)
        {
            try
            {
                DataTable dtSubledger = (DataTable)ViewState["analysisInformation"];
                if (dtSubledger != null)
                {
                    dtSubledger.DefaultView.Sort = "SlNo DESC";
                    dtSubledger = dtSubledger.DefaultView.ToTable();

                    for (int rowSubledger = dtSubledger.Rows.Count - 1; rowSubledger >= 0; rowSubledger--)
                    {
                        if (dtSubledger.Rows[rowSubledger]["TranactionLineNoSubLedger"].ToString().Trim().Contains(objJournalVoucher.TranactionLineNo.ToString()))
                        {
                            dtSubledger.Rows[rowSubledger].Delete();
                        }
                        dtSubledger.AcceptChanges();
                    }

                    dtSubledger.DefaultView.Sort = "SlNo DESC";
                    dtSubledger = dtSubledger.DefaultView.ToTable();
                    ViewState["analysisInformation"] = dtSubledger;

                }
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
                dt.Columns.Add("TranactionLineNoSubLedger", typeof(int));

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
                    dr[13] = objJournalVoucher.TranactionLineNoSubLedger;

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
                    dr[13] = objJournalVoucher.TranactionLineNoSubLedger;


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
            e.Row.Cells[14].Visible = false;

            if (e.Row.RowType == DataControlRowType.Header)
            {
                grdAnalysis.Columns[15].HeaderText = "";
                e.Row.Cells[15].Text = e.Row.Cells[15].Text + e.Row.Cells[16].Text;
                e.Row.Cells[15].ColumnSpan = 2;
            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAccountingCode = (e.Row.FindControl("lblAccountingCode") as Label);
                if (lblAccountCode.Text.ToString().Trim() == lblAccountingCode.Text.ToString().Trim())
                {
                    e.Row.Visible = true;
                }
                else
                {
                    e.Row.Visible = false;
                }
            }


        }

        private string GetBalanceAmount()
        {
            try
            {
                string balanceAmount = null;
                decimal assignedAmount = 0;
                if (grdAnalysis.Rows.Count > 0)
                {
                    foreach (GridViewRow rowNo in grdAnalysis.Rows)
                    {
                        string lblSubLegerAmount = ((Label)rowNo.FindControl("lblSubLegerAmount")).Text;
                        assignedAmount += Convert.ToDecimal(lblSubLegerAmount);
                    }

                }

                balanceAmount = (Convert.ToDecimal(lbltotalamt.Text) - assignedAmount).ToString();
                return balanceAmount;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Session["dataStatusID"] = "U";
                AddValuesSaveMode();
                ClearControlAfterSave();
                txtSearchTab1.Text = string.Empty;
                ClearControlAfterAdd();
                LoadSubmitteVoucherAll();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ClearControlAfterSave()
        {
            try
            {
                btnSubmit.Visible = false;
                btnPost.Visible = false;
                btnSave.Visible = false;
                panelForTotal.Visible = false;
                lblDebit.Text = string.Empty;
                lblCredit.Text = string.Empty;
                ViewState["voucherInformation"] = null;
                grdVoucher.DataSource = null;
                grdVoucher.DataBind();
                ViewState["analysisInformation"] = null;
                grdAnalysis.DataSource = null;
                grdAnalysis.DataBind();
                lblVoucherNo.Text = string.Empty;

                ddlJournalType.SelectedValue = "-1";
                ddlTransactionType.SelectedValue = "-1";
                txtReferenceJournal.Text = string.Empty;
                txtUserVoucherNo.Text = string.Empty;
                txtJournalDate.Text = string.Empty;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void AddValuesSaveMode()
        {
            try
            {
                _objJournalVoucher = new JournalVoucher();
                _objBranchSetup = new BranchSetup();
                _objCoaHead = new CoaHead();
                _objBranchSetup.CompanyID = LoginUserInformation.CompanyID;
                _objBranchSetup.BranchID = LoginUserInformation.BranchID;
                _objCoaHead.AccountNo = Convert.ToInt32(txtAccCode.Text.Split(':')[0].Trim() == string.Empty ? null : txtAccCode.Text.Split(':')[0].Trim());
                _objJournalVoucher.VoucherNo = "";
                _objJournalVoucher.UserVoucherNo = txtUserVoucherNo.Text == string.Empty ? null : txtUserVoucherNo.Text;
                if (txtReferenceJournal.Text == string.Empty)
                {
                    _objJournalVoucher.AnyRefVoucherNo = 0;
                }
                else
                {
                    _objJournalVoucher.AnyRefVoucherNo = Convert.ToInt32(txtReferenceJournal.Text);
                }

                if (ddlJournalType.SelectedValue == "-1")
                {
                    _objJournalVoucher.JournalTypeID = null;
                }
                else
                {
                    _objJournalVoucher.JournalTypeID = Convert.ToInt32(ddlJournalType.SelectedValue);
                }

                _objJournalVoucher.DataStatusID = Session["dataStatusID"].ToString();
                _objBranchSetup.EntryUserName = LoginUserInformation.UserID;
                if (txtJournalDate.Text == string.Empty)
                {
                    _objJournalVoucher.VoucherDate = null;
                }
                else
                {
                    _objJournalVoucher.VoucherDate = Convert.ToDateTime(txtJournalDate.Text);
                }

                _objJournalVoucherController = new JournalVoucherController();

                if (grdVoucher.Rows.Count > 0)
                {
                    _objJournalVoucher.DtVoucherJournalDetails = (DataTable)ViewState["voucherInformation"];
                }
                else
                {
                    _objJournalVoucher.DtVoucherJournalDetails = null;
                }

                if (grdAnalysis.Rows.Count > 0)
                {
                    _objJournalVoucher.DtVoucherSubLedger = (DataTable)ViewState["analysisInformation"];

                }
                else
                {
                    _objJournalVoucher.DtVoucherSubLedger = null;
                }

                _objJournalVoucher.SubLedgerTypeID1 = Session["SubLedgerTypeID1"].ToString();
                _objJournalVoucher.SubLedgerTypeID2 = Session["SubLedgerTypeID2"].ToString();
                _objJournalVoucher.SubLedgerTypeID3 = Session["SubLedgerTypeID3"].ToString();
                _objJournalVoucher.SubLedgerTypeID4 = Session["SubLedgerTypeID4"].ToString();
                _objJournalVoucher.SubLedgerTypeID5 = Session["SubLedgerTypeID5"].ToString();

                _objJournalVoucher.PointNumber = 0;
                _objJournalVoucher.IsBackedup = 0;
                _objJournalVoucher.IsSetToFS = 0;
                _objJournalVoucher.ValueDate = _objJournalVoucher.VoucherDate;
                _objJournalVoucher.TransactionMediaID = 0;
                _objJournalVoucher.ShowInRpt = 1;
                _objJournalVoucher.RpCashAmount = 0;
                _objJournalVoucher.RpChequeAmount = 0;

                _objJournalVoucher.ComputerName = Environment.MachineName;
                _objJournalVoucher.SearchUserVoucherNo = txtSearchTab1.Text == string.Empty ? null : txtSearchTab1.Text;
                _objJournalVoucher.SearchVoucherNo = lblVoucherNo.Text == string.Empty ? null : lblVoucherNo.Text;
                _objJournalVoucherController.Save(_objBranchSetup, _objCoaHead, _objJournalVoucher);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnskip_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearSubledgerRecords();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void grdAnalysis_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                var selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
                Session["selectedIndexSubledger"] = selectedIndex;
                if (e.CommandName.Equals("Select"))
                {
                    string lbl1stAnalysisValue = ((Label)grdAnalysis.Rows[selectedIndex].FindControl("lbl1stAnalysisValue")).Text;
                    string lbl2ndAnalysisValue = ((Label)grdAnalysis.Rows[selectedIndex].FindControl("lbl2ndAnalysisValue")).Text;
                    string lbl3rdAnalysisValue = ((Label)grdAnalysis.Rows[selectedIndex].FindControl("lbl3rdAnalysisValue")).Text;
                    string lbl4thAnalysisValue = ((Label)grdAnalysis.Rows[selectedIndex].FindControl("lbl4thAnalysisValue")).Text;
                    string lbl5thAnalysisValue = ((Label)grdAnalysis.Rows[selectedIndex].FindControl("lbl5thAnalysisValue")).Text;
                    string lblSubLegerAmount = ((Label)grdAnalysis.Rows[selectedIndex].FindControl("lblSubLegerAmount")).Text;
                    string lblSlNoSubledger = ((Label)grdAnalysis.Rows[selectedIndex].FindControl("lblSlNo")).Text;

                    if (lbl1stAnalysisValue != string.Empty || lbl1stAnalysisValue != "")
                    {
                        ddl1st.SelectedValue = lbl1stAnalysisValue;
                    }

                    if (lbl2ndAnalysisValue != string.Empty || lbl2ndAnalysisValue != "")
                    {
                        ddl2nd.SelectedValue = lbl2ndAnalysisValue;
                    }

                    if (lbl3rdAnalysisValue != string.Empty || lbl3rdAnalysisValue != "")
                    {
                        ddl3rd.SelectedValue = lbl3rdAnalysisValue;
                    }

                    if (lbl4thAnalysisValue != string.Empty || lbl4thAnalysisValue != "")
                    {
                        ddl4th.SelectedValue = lbl4thAnalysisValue;
                    }

                    if (lbl5thAnalysisValue != string.Empty || lbl5thAnalysisValue != "")
                    {
                        ddl5th.SelectedValue = lbl5thAnalysisValue;
                    }

                    txtsplitamt.Text = lblSubLegerAmount;
                    txtbalamt.Text = (Convert.ToDecimal(this.GetBalanceAmount()) + Convert.ToDecimal(lblSubLegerAmount)).ToString();
                    Session["slNoSubledgerAlign"] = lblSlNoSubledger;
                    btnInsertAnalysis.Text = "Edit";
                    ModalPopupExtender1.Show();
                }

                if (!e.CommandName.Equals("Delete")) return;
                var dt = (DataTable)ViewState["analysisInformation"];
                dt.DefaultView.Sort = "SlNo DESC";
                dt = dt.DefaultView.ToTable();
                dt.Rows[selectedIndex].Delete();
                dt.AcceptChanges();
                dt.DefaultView.Sort = "SlNo DESC";
                dt = dt.DefaultView.ToTable();
                ViewState["analysisInformation"] = dt;
                if (ViewState["analysisInformation"] == null) return;
                grdAnalysis.DataSource = ViewState["analysisInformation"];
                grdAnalysis.DataBind();
                txtbalamt.Text = this.GetBalanceAmount();
                btnInsertAnalysis.Text = "Insert";
                ModalPopupExtender1.Show();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
                ModalPopupExtender1.Show();
            }
        }

        protected void grdAnalysis_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void ddlCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtCurrencyRate.Text = string.Empty;
                _objJournalVoucher = new JournalVoucher();
                if (ddlCurrency.SelectedValue == "-1")
                {
                    _objJournalVoucher.CurrencyID = null;
                }
                else
                {
                    _objJournalVoucher.CurrencyID = Convert.ToInt32(ddlCurrency.SelectedValue);
                }

                _objBranchSetup = new BranchSetup();
                _objBranchSetup.CompanyID = LoginUserInformation.CompanyID;
                _objJournalVoucherController = new JournalVoucherController();
                txtCurrencyRate.Text = Math.Round(Convert.ToDecimal(_objJournalVoucherController.GetExchangeRate(_objJournalVoucher, _objBranchSetup)), 2).ToString();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnUpdateCurrencyRate_Click(object sender, EventArgs e)
        {
            try
            {
                _objJournalVoucher = new JournalVoucher();
                if (ddlCurrency.SelectedValue == "-1")
                {
                    _objJournalVoucher.CurrencyID = null;
                }
                else
                {
                    _objJournalVoucher.CurrencyID = Convert.ToInt32(ddlCurrency.SelectedValue);
                }

                _objJournalVoucher.CurrencyRate = Convert.ToDecimal(txtCurrencyRate.Text);
                _objBranchSetup = new BranchSetup();
                _objBranchSetup.CompanyID = LoginUserInformation.CompanyID;
                _objBranchSetup.EntryUserName = LoginUserInformation.UserID;
                _objJournalVoucherController = new JournalVoucherController();
                _objJournalVoucherController.UpdateExchangeRate(_objJournalVoucher, _objBranchSetup);
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
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
                Session["dataStatusID"] = "S";
                AddValuesSaveMode();
                ClearControlAfterSave();
                txtSearchTab1.Text = string.Empty;
                ClearControlAfterAdd();
                LoadSubmitteVoucherAll();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                Session["dataStatusID"] = "P";
                AddValuesSaveMode();
                ClearControlAfterSave();
                txtSearchTab1.Text = string.Empty;
                ClearControlAfterAdd();
                LoadSubmitteVoucherAll();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (PanelAdvancedSearch.Visible == true)
                {
                    PanelAdvancedSearch.Visible = false;
                }
                else
                {
                    PanelAdvancedSearch.Visible = true;
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                GetSubmittedVoucherAdvancedSearch();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void GetSubmittedVoucherAdvancedSearch()
        {
            try
            {
                _objJournalVoucher = new JournalVoucher();
                _objJournalVoucher.VoucherNo = txtVoucherNoSearchTab2.Text == string.Empty ? null : txtVoucherNoSearchTab2.Text;
                _objJournalVoucher.TransactionTypeID = Convert.ToInt32(ddlTransactionTypeSearchTab2.SelectedValue);
                _objCoaHead = new CoaHead();
                _objCoaHead.AccountNo = txtAccountCodeSearchTab2.Text.Split(':')[0].Trim() == string.Empty ? 0 : Convert.ToInt32(txtAccountCodeSearchTab2.Text.Split(':')[0].Trim());
                if (txtJournalDateFromSearchTab2.Text == string.Empty)
                {
                    _objJournalVoucher.JournalDateFrom = null;
                }
                else
                {
                    _objJournalVoucher.JournalDateFrom = Convert.ToDateTime(txtJournalDateFromSearchTab2.Text);
                }

                if (txtJournalDateToSearchTab2.Text == string.Empty)
                {
                    _objJournalVoucher.JournalDateTo = null;
                }
                else
                {
                    _objJournalVoucher.JournalDateTo = Convert.ToDateTime(txtJournalDateToSearchTab2.Text);
                }

                if (txtAmountSearchTab2.Text == string.Empty)
                {
                    _objJournalVoucher.BaseAmountSearch = null;
                }
                else
                {
                    _objJournalVoucher.BaseAmountSearch = Convert.ToDecimal(txtAmountSearchTab2.Text);
                }

                _objBranchSetup = new BranchSetup();
                _objBranchSetup.CompanyID = LoginUserInformation.CompanyID;
                _objJournalVoucherController = new JournalVoucherController();
                _objJournalVoucher.DtSubmittedJournal = _objJournalVoucherController.GetSubmittedJournalAdvancedSearch(_objJournalVoucher, _objBranchSetup, _objCoaHead);
                this.LoadSubmittedVoucher(_objJournalVoucher);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void grdUnpostedVoucher_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[3].Visible = false;
        }

        protected void CheckBoxUnpostedVoucher_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ControlPostButtonTab2();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ControlPostButtonTab2()
        {
            try
            {
                int countSelectedRow = 0;
                foreach (GridViewRow rowNo in grdUnpostedVoucher.Rows)
                {
                    CheckBox CheckBoxUnpostedVoucher = ((CheckBox)rowNo.FindControl("CheckBoxUnpostedVoucher"));
                    if (CheckBoxUnpostedVoucher.Checked == true)
                    {
                        countSelectedRow++;

                    }
                }

                if (countSelectedRow == 0)
                {
                    btnPostTab2.Visible = false;

                }
                else
                {
                    btnPostTab2.Visible = true;
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void CheckBoxUnpostedVoucherHeader_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox CheckBoxUnpostedVoucherHeader = ((CheckBox)grdUnpostedVoucher.HeaderRow.FindControl("CheckBoxUnpostedVoucherHeader"));
                if (CheckBoxUnpostedVoucherHeader.Checked == true)
                {
                    foreach (GridViewRow rowNo in grdUnpostedVoucher.Rows)
                    {
                        CheckBox CheckBoxUnpostedVoucher = ((CheckBox)rowNo.FindControl("CheckBoxUnpostedVoucher"));
                        CheckBoxUnpostedVoucher.Checked = true;
                    }

                }
                else
                {
                    foreach (GridViewRow rowNo in grdUnpostedVoucher.Rows)
                    {
                        CheckBox CheckBoxUnpostedVoucher = ((CheckBox)rowNo.FindControl("CheckBoxUnpostedVoucher"));
                        CheckBoxUnpostedVoucher.Checked = false;
                    }
                }

                this.ControlPostButtonTab2();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnPostTab2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow rowNo in grdUnpostedVoucher.Rows)
                {
                    CheckBox CheckBoxUnpostedVoucher = ((CheckBox)rowNo.FindControl("CheckBoxUnpostedVoucher"));
                    if (CheckBoxUnpostedVoucher.Checked == true)
                    {
                        string lblVoucherNo = ((Label)rowNo.FindControl("lblVoucherNo")).Text;
                        _objJournalVoucher = new JournalVoucher();
                        _objJournalVoucher.VoucherNo = lblVoucherNo;
                        _objBranchSetup = new BranchSetup();
                        _objBranchSetup.EntryUserName = LoginUserInformation.UserID;
                        _objJournalVoucherController = new JournalVoucherController();
                        _objJournalVoucherController.PostUnpostedVoucher(_objJournalVoucher, _objBranchSetup);

                    }
                }

                this.LoadSubmitteVoucherAll();
                btnPostTab2.Visible = false;
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void grdUnpostedVoucher_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                var selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());

                if (e.CommandName.Equals("Select"))
                {
                    string lblVoucherNo = ((Label)grdUnpostedVoucher.Rows[selectedIndex].FindControl("lblVoucherNo")).Text;
                    Session["voucherNoSubledgerPopup"] = lblVoucherNo;
                    _objJournalVoucher = new JournalVoucher();
                    _objJournalVoucher.VoucherNo = lblVoucherNo;
                    _objJournalVoucherController = new JournalVoucherController();
                    _objJournalVoucher.DtVoucherJournalDetails = _objJournalVoucherController.GetVoucherDetails(_objJournalVoucher);
                    LoadUnpostedVoucherDetailsGridView(_objJournalVoucher.DtVoucherJournalDetails);
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void LoadUnpostedVoucherDetailsGridView(DataTable dataTableVoucherDetails)
        {
            try
            {
                grdUnpostedVoucherDetails.DataSource = null;
                grdUnpostedVoucherDetails.DataBind();
                if (dataTableVoucherDetails != null)
                {
                    grdUnpostedVoucherDetails.DataSource = dataTableVoucherDetails;
                    grdUnpostedVoucherDetails.DataBind();
                    grdUnpostedVoucherSubLedger.DataSource = null;
                    grdUnpostedVoucherSubLedger.DataBind();
                    lblSubledgerTitle.Visible = false;
                    PanelUnpostedVoucherRecord_ModalPopupExtender.Show();
                }
                else
                {
                    PanelUnpostedVoucherRecord_ModalPopupExtender.Hide();
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        double debitAmountDetails = 0;
        double creditAmountDetails = 0;
        protected void grdUnpostedVoucherDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblDebitGrid = (e.Row.FindControl("lblDebit") as Label);
                    Label lblCreditGrid = (e.Row.FindControl("lblCredit") as Label);
                    debitAmountDetails += Convert.ToDouble(lblDebitGrid.Text);
                    creditAmountDetails += Convert.ToDouble(lblCreditGrid.Text);
                    lblDebit.Text = string.Format("{0:n2}", debitAmountDetails);
                    lblCredit.Text = string.Format("{0:n2}", creditAmountDetails);
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void grdUnpostedVoucherDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                var selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());

                if (e.CommandName.Equals("Select"))
                {
                    string lblSlNoAlign = ((Label)grdUnpostedVoucherDetails.Rows[selectedIndex].FindControl("lblSlNoAlign")).Text;
                    _objJournalVoucher = new JournalVoucher();
                    _objJournalVoucher.VoucherNo = Session["voucherNoSubledgerPopup"].ToString();
                    Session["slNoAlignVoucher"] = Convert.ToInt32(lblSlNoAlign);
                    _objJournalVoucherController = new JournalVoucherController();
                    _objJournalVoucher.DtVoucherSubLedger = _objJournalVoucherController.GetVoucherSubLedger(_objJournalVoucher);
                    LoadUnpostedVoucherSubLedgerGridView(_objJournalVoucher.DtVoucherSubLedger);
                    PanelUnpostedVoucherRecord_ModalPopupExtender.Show();
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void LoadUnpostedVoucherSubLedgerGridView(DataTable dataTableSubLedger)
        {
            try
            {
                grdUnpostedVoucherSubLedger.DataSource = null;
                grdUnpostedVoucherSubLedger.DataBind();
                lblSubledgerTitle.Visible = false;
                if (dataTableSubLedger != null)
                {
                    grdUnpostedVoucherSubLedger.DataSource = dataTableSubLedger;
                    grdUnpostedVoucherSubLedger.DataBind();
                    lblSubledgerTitle.Visible = true;
                }
            }
            catch (Exception msgExceptin)
            {

                throw msgExceptin;
            }
        }

        protected void grdUnpostedVoucherSubLedger_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[13].Visible = false;
                e.Row.Cells[14].Visible = false;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblSlNo = (e.Row.FindControl("lblSlNo") as Label);
                    if (Session["slNoAlignVoucher"].ToString().Trim() == lblSlNo.Text.ToString().Trim())
                    {
                        e.Row.Visible = true;
                    }
                    else
                    {
                        e.Row.Visible = false;
                    }
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void txtSearchTab1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ClearControlAfterSave();
                _objJournalVoucher = new JournalVoucher();
                _objJournalVoucher.UserVoucherNo = txtSearchTab1.Text;
                ShowVoucherHeader(_objJournalVoucher);
                ShowVoucherDetails(_objJournalVoucher);
                ShowVoucherSubLedger(_objJournalVoucher);
                this.ControlButtonVisible();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ShowVoucherSubLedger(JournalVoucher objJournalVoucher)
        {
            try
            {
                _objJournalVoucherController = new JournalVoucherController();                
                _objJournalVoucher.DtVoucherSubLedger = _objJournalVoucherController.GetVoucherSubLedgerUserVoucherNo(objJournalVoucher);
                ViewState["analysisInformation"] = null;
                grdAnalysis.DataSource = null;
                grdAnalysis.DataBind();
                Session["SubLedgerTypeID1"] = string.Empty;
                Session["SubLedgerTypeID2"] = string.Empty;
                Session["SubLedgerTypeID3"] = string.Empty;
                Session["SubLedgerTypeID4"] = string.Empty;
                Session["SubLedgerTypeID5"] = string.Empty;
                if (_objJournalVoucher.DtVoucherSubLedger != null)
                {
                    _objJournalVoucher.DtVoucherSubLedger.DefaultView.Sort = "SlNo DESC";
                    _objJournalVoucher.DtVoucherSubLedger = _objJournalVoucher.DtVoucherSubLedger.DefaultView.ToTable();
                    grdAnalysis.DataSource = _objJournalVoucher.DtVoucherSubLedger;
                    grdAnalysis.DataBind();
                    ViewState["analysisInformation"] = _objJournalVoucher.DtVoucherSubLedger;

                    foreach (DataRow rowNo in _objJournalVoucher.DtVoucherSubLedger.Rows)
                    {
                        Session["SubLedgerTypeID1"] = rowNo["SubLedgerTypeID1"].ToString();
                        Session["SubLedgerTypeID2"] = rowNo["SubLedgerTypeID2"].ToString();
                        Session["SubLedgerTypeID3"] = rowNo["SubLedgerTypeID3"].ToString();
                        Session["SubLedgerTypeID4"] = rowNo["SubLedgerTypeID4"].ToString();
                        Session["SubLedgerTypeID5"] = rowNo["SubLedgerTypeID5"].ToString();
                        break;
                    }
                }
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void ShowVoucherDetails(JournalVoucher objJournalVoucher)
        {
            _objJournalVoucherController = new JournalVoucherController();            
            _objJournalVoucher.DtVoucherJournalDetails = _objJournalVoucherController.GetVoucherDetailsUserVoucherNo(objJournalVoucher);
            ViewState["voucherInformation"] = null;
            grdVoucher.DataSource = null;
            grdVoucher.DataBind();
            if (_objJournalVoucher.DtVoucherJournalDetails != null)
            {
                _objJournalVoucher.DtVoucherJournalDetails.DefaultView.Sort = "SlNo DESC";
                _objJournalVoucher.DtVoucherJournalDetails = _objJournalVoucher.DtVoucherJournalDetails.DefaultView.ToTable();
                grdVoucher.DataSource = _objJournalVoucher.DtVoucherJournalDetails;
                grdVoucher.DataBind();
                ViewState["voucherInformation"] = _objJournalVoucher.DtVoucherJournalDetails;
            }
        }

        private void ShowVoucherHeader(JournalVoucher objJournalVoucher)
        {
            try
            {
                _objJournalVoucherController = new JournalVoucherController();
                _objJournalVoucher.DtVoucherHeader = _objJournalVoucherController.GetVoucherHeader(objJournalVoucher);
                foreach (DataRow rowNo in _objJournalVoucher.DtVoucherHeader.Rows)
                {
                    ddlJournalType.SelectedValue = rowNo["JournalTypeID"].ToString();
                    ddlTransactionType.SelectedValue = rowNo["TransactionTypeID"].ToString();
                    txtReferenceJournal.Text = rowNo["AnyRefVoucherNo"].ToString() == "0" ? string.Empty : rowNo["AnyRefVoucherNo"].ToString();
                    txtUserVoucherNo.Text = rowNo["UserVoucherNo"].ToString();
                    txtJournalDate.Text = Convert.ToDateTime( rowNo["VoucherDate"].ToString()).ToString("yyyy-MM-dd");
                    lblVoucherNo.Text = rowNo["VoucherNo"].ToString();
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

    }
}