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
                CoaHead objCoaHead = new CoaHead();
                objCoaHead.AccountNo = Convert.ToInt32(txtAccCode.Text.Split(':')[0].Trim() == string.Empty ? null : txtAccCode.Text.Split(':')[0].Trim());
                objCoaHead.AccountName = txtAccCode.Text.Split(':')[1].Trim() == string.Empty ? null : txtAccCode.Text.Split(':')[1].Trim();
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
                if (objCoaHeadController.CheckAnalysisrequired(objCoaHead) == "Y")
                {
                    ModalPopupExtender1.Show();
                    lblAccountCode.Text = objCoaHead.AccountNo.ToString();
                    lblAccountName.Text = objCoaHead.AccountName;
                    txttotalamt.Text = _objJournalVoucher.TransactionCurrencyAmount.ToString();

                    ClearAllAnalysisDDL();

                    _objJournalVoucherController = new JournalVoucherController();
                    _objJournalVoucher.DtAssignSubLedgerType = _objJournalVoucherController.GetAssignedSubLedgerType(objCoaHead);

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

                this.BindVoucherInformationGrid(_objJournalVoucher, objCoaHead);

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


    }
}