﻿<%@ Page Title="Journal Voucher" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JournalVoucherForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Accounts.MasterPage.JournalVoucherForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 92px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <ajaxToolkit:TabContainer ID="TabContainer2" runat="server" CssClass="tab" ActiveTabIndex="0"
                Width="1150px" CssTheme="None">
                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Voucher Entry">
                    <ContentTemplate>
                        <table style="width: 1140px">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel2" runat="server" BorderColor="#336699" BorderStyle="Solid"
                                        BorderWidth="0px" Width="1140px">
                                        <table style="width: 1140px; font-family: Tahoma; font-size: small;">
                                            <tr>
                                                <td style="width: 570px">
                                                    <div style="width: 100%; height: 450px; overflow-y: scroll; overflow-x: hidden">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label3" runat="server" Text="Journal Type"></asp:Label>
                                                                </td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlJournalType" runat="server"
                                                                        Width="128px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label32" runat="server" Text="Reference Journal"></asp:Label>
                                                                </td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtReferenceJournal" runat="server" Width="120px"></asp:TextBox>
                                                                    <ajaxToolkit:AutoCompleteExtender ID="txtReferenceJournal_AutoCompleteExtender" 
                                                                        runat="server" BehaviorID="txtReferenceJournal_AutoCompleteExtender" 
                                                                        DelimiterCharacters="" 
                                                                        MinimumPrefixLength="1"
                                                                        ServiceMethod="GetVoucherNo"
                                                                        ServicePath="~/WebService/ServiceSystem.asmx" 
                                                                        CompletionListCssClass="autocomplete_completionListElement"
                                                                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                        CompletionListItemCssClass="autocomplete_listItem2"
                                                                        TargetControlID="txtReferenceJournal">
                                                                    </ajaxToolkit:AutoCompleteExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label17" runat="server" Text="Transaction Type"></asp:Label>
                                                                </td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlTransactionType" runat="server" Width="128px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label34" runat="server" Text="Voucher No."></asp:Label>
                                                                </td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtUserVoucherNo" runat="server" Width="120px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label9" runat="server" Text="Voucher Type"></asp:Label>
                                                                </td>
                                                                <td>&nbsp;</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlVoucherType" runat="server" Width="128px">
                                                                    </asp:DropDownList>

                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label5" runat="server" Text="Journal Date"></asp:Label>
                                                                </td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtJournalDate" runat="server" TextMode="Date" Width="120px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label6" runat="server" Text="Account Code"></asp:Label>
                                                                </td>
                                                                <td>:</td>
                                                                <td colspan="4">
                                                                    <asp:TextBox ID="txtAccCode" runat="server"
                                                                        Width="370px"></asp:TextBox>
                                                                    <ajaxToolkit:AutoCompleteExtender ID="txtAccCode_AutoCompleteExtender"
                                                                        runat="server" BehaviorID="txtAccCode_AutoCompleteExtender"
                                                                        DelimiterCharacters=""
                                                                        MinimumPrefixLength="1"
                                                                        ServiceMethod="GetCOAHead"
                                                                        ServicePath="~/WebService/ServiceSystem.asmx"
                                                                        CompletionListCssClass="autocomplete_completionListElement"
                                                                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                        CompletionListItemCssClass="autocomplete_listItem2"
                                                                        TargetControlID="txtAccCode">
                                                                    </ajaxToolkit:AutoCompleteExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label26" runat="server" Text="Currency"></asp:Label>
                                                                </td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCurrency" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCurrency_SelectedIndexChanged" Width="128px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td class="auto-style24">
                                                                    <asp:Label ID="Label24" runat="server" Text="Currency Rate"></asp:Label>
                                                                </td>
                                                                <td class="auto-style24">:</td>
                                                                <td class="auto-style24">
                                                                    <asp:TextBox ID="txtCurrencyRate" runat="server" onkeypress="return isNumberKey(event)" onkeyup="UpdateCurrencyAmount();" Width="95px"></asp:TextBox>
                                                                    <asp:Button ID="btnUpdateCurrencyRate" runat="server" OnClick="btnUpdateCurrencyRate_Click" Text="U" Width="25px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label22" runat="server" Text="Transaction Amount"></asp:Label>
                                                                </td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtAmount" runat="server" onkeypress="return isNumberKey(event)" onkeyup="UpdateCurrencyAmount();" Width="120px"></asp:TextBox>
                                                                </td>
                                                                <td class="auto-style24">
                                                                    <asp:Label ID="Label25" runat="server" Text="Base Amount"></asp:Label>
                                                                </td>
                                                                <td class="auto-style24">:</td>
                                                                <td class="auto-style24">
                                                                    <asp:TextBox ID="txtBaseAmount" runat="server" BackColor="White" Font-Bold="True" Width="125px" Enabled="False"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Particulars</td>
                                                                <td class="auto-style42">:</td>
                                                                <td class="auto-style42" colspan="4">
                                                                    <asp:TextBox ID="txtNarration" runat="server"
                                                                        TextMode="MultiLine" Width="370px" Height="50px"></asp:TextBox>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td colspan="4">
                                                                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="100px" OnClick="btnAdd_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                                <td style="width: 570px">
                                                    <div style="width: 100%; height: 450px; overflow-y: scroll; overflow-x: hidden">
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="100px" OnClick="btnSave_Click" />
                                                                    <asp:Button ID="btnUnpost" runat="server" Text="Unpost" Width="100px" />
                                                                </td>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <asp:GridView ID="grdVoucher" runat="server" Width="570px" AutoGenerateColumns="False" OnRowCommand="grdVoucher_RowCommand" OnRowDeleting="grdVoucher_RowDeleting" OnSorting="grdVoucher_Sorting" OnRowDataBound="grdVoucher_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="SL">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DisplayIndex + 1 %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Account Name">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblAccountingName" runat="server" Text='<%# Bind("AccountingName") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Accounting Code" Visible="False">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblAccountingCode" runat="server" Text='<%# Bind("AccountingCode") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Particulars">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblParticulars" runat="server" Text='<%# Bind("Particulars") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Debit">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblDebit" runat="server" Text='<%# Bind("Debit") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Credit">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblCredit" runat="server" Text='<%# Bind("Credit") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Type" Visible="False">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblType" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Typeid" Visible="False">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblTypeid" runat="server" Text='<%# Bind("Typeid") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Trtype" Visible="False">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblTrtype" runat="server" Text='<%# Bind("Trtype") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Currency Rate" Visible="False">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblCurrencyRate" runat="server" Text='<%# Bind("CurrencyRate") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:CommandField ShowSelectButton="True" />

                                                                            <asp:CommandField ShowDeleteButton="True" />

                                                                            <asp:TemplateField HeaderText="slAlign" Visible="False">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblSlNoAlign" runat="server" Text='<%# Bind("SlNo") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="BaseAmount" Visible="False">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblBaseAmount" runat="server" Text='<%# Bind("BaseAmount") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="TransactionAmount" Visible="False">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblTransactionAmount" runat="server" Text='<%# Bind("TransactionAmount") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="CurrencyID" Visible="False">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblCurrencyID" runat="server" Text='<%# Bind("CurrencyID") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>

                                        </table>
                                    </asp:Panel>
                                </td>


                            </tr>
                            <tr>
                                <td>

                                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowAnalysisPopup" PopupControlID="PanelAnalysis"
                                        BackgroundCssClass="ModalBackgroud" CancelControlID="btnskip" DynamicServicePath="" BehaviorID="_content_ModalPopupExtender1">
                                    </ajaxToolkit:ModalPopupExtender>

                                    <asp:Panel ID="PanelAnalysis" runat="server" BorderColor="#336699" BorderStyle="Solid" BackColor="White" Height="500px" Style="display: block" Width="1200px">
                                        
                                        <table style="width: 100%;">
                                            <tr>
                                                <td colspan="4" style="text-align:center">
                                                    <asp:Label ID="Label35" runat="server" Text="SUBLEDGER ENTRY"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="border-bottom-style: solid; border-bottom-width: 1px; border-color: #808000" >&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="width:350px">
                                                    <div style="width:350px">
                                                    <table style="width:94%;margin-left:5px">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label29" runat="server" ForeColor="#0072B0" Text="Account Code"></asp:Label>
                                                            </td>
                                                            <td>:</td>
                                                            <td>
                                                                <asp:Label ID="lblAccountCode" runat="server" ForeColor="#0072B0"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label31" runat="server" ForeColor="#0072B0" Text="Total Amount"></asp:Label>
                                                            </td>
                                                            <td>:</td>
                                                            <td>
                                                                <asp:TextBox ID="txttotalamt" runat="server" Enabled="False" Width="100px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                        </div>
                                                </td>
                                                <td colspan="2" style="width:690px;float:right">
                                                    <div style="width:690px">
                                                    <table style="width:50%; float:right">
                                                        <tr>
                                                            <td >
                                                                <asp:Label ID="Label2" runat="server" ForeColor="#0072B0" Text="Account Name"></asp:Label>
                                                            </td>
                                                            <td>:</td>
                                                            <td>
                                                                <asp:Label ID="lblAccountName" runat="server" ForeColor="#0072B0"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:Label ID="lblSkip" runat="server" ForeColor="#0072B0">Click </asp:Label>
                                                                <asp:LinkButton ID="btnskip" runat="server" OnClick="btnskip_Click">Skip</asp:LinkButton>
                                                                <asp:Label ID="lblSkip0" runat="server" ForeColor="#0072B0">if you dont want to add subledger now</asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                        </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="width:415px;float:left">
                                                    <div style="width: 100%; height: 370px; overflow-y: scroll; overflow-x: hidden">
                                                    <table style="width:100%;margin-left:5px">
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:Label ID="Label1st0" runat="server" ForeColor="#0072B0" Text="Add Subledger Amount"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label1st" runat="server" ForeColor="#0072B0" Text="1st Analysis"></asp:Label>
                                                            </td>
                                                            <td>:</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddl1st" runat="server" Width="200px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label2nd" runat="server" ForeColor="#0072B0" Text="2nd Analysis"></asp:Label>
                                                            </td>
                                                            <td>:</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddl2nd" runat="server" Width="200px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label3rd" runat="server" ForeColor="#0072B0" Text="3rd Analysis"></asp:Label>
                                                            </td>
                                                            <td>:</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddl3rd" runat="server" Width="200px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label4th" runat="server" ForeColor="#0072B0" Text="4th Analysis"></asp:Label>
                                                            </td>
                                                            <td>:</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddl4th" runat="server" Width="200px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label5th" runat="server" ForeColor="#0072B0" Text="5th Analysis"></asp:Label>
                                                            </td>
                                                            <td>:</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddl5th" runat="server" Width="200px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label15" runat="server" ForeColor="#0072B0" Text="Sub Leger Amt"></asp:Label>
                                                            </td>
                                                            <td>:</td>
                                                            <td>
                                                                <asp:TextBox ID="txtsplitamt" runat="server" Width="196px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label14" runat="server" ForeColor="#0072B0" Text="Balance Amount"></asp:Label>
                                                            </td>
                                                            <td>:</td>
                                                            <td>
                                                                <asp:TextBox ID="txtbalamt" runat="server" Enabled="False" Width="196px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:Button ID="btnInsertAnalysis" runat="server" OnClick="btnInsertAnalysis_Click" Text="Insert" Width="100px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                        </div>
                                                </td>
                                                <td colspan="2" >
                                                    <div style="width: 690%; height: 370px; overflow-y: scroll; overflow-x: hidden">
                                                    <table style="width:100%;">
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:GridView ID="grdAnalysis" runat="server" AutoGenerateColumns="False" OnRowCommand="grdAnalysis_RowCommand" OnRowDataBound="grdAnalysis_RowDataBound" OnRowDeleting="grdAnalysis_RowDeleting" Width="685px">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="SL">
                                                                            <ItemTemplate>
                                                                                <%# Container.DisplayIndex + 1 %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Account Code">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblAccountingCode" runat="server" Text='<%# Bind("AccountingCode") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="1st Analysis Value">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl1stAnalysisValue" runat="server" Text='<%# Bind("1stAnalysisValue") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="2nd Analysis Value">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl2ndAnalysisValue" runat="server" Text='<%# Bind("2ndAnalysisValue") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="3rd Analysis Value">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl3rdAnalysisValue" runat="server" Text='<%# Bind("3rdAnalysisValue") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="4th Analysis Value">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl4thAnalysisValue" runat="server" Text='<%# Bind("4thAnalysisValue") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="5th Analysis Value">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl5thAnalysisValue" runat="server" Text='<%# Bind("5thAnalysisValue") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="1st Analysis">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl1stAnalysisText" runat="server" Text='<%# Bind("1stAnalysisText") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="2nd Analysis">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl2ndAnalysisText" runat="server" Text='<%# Bind("2ndAnalysisText") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="3rd Analysis">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl3rdAnalysisText" runat="server" Text='<%# Bind("3rdAnalysisText") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="4th Analysis">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl4thAnalysisText" runat="server" Text='<%# Bind("4thAnalysisText") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="5th Analysis">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl5thAnalysisText" runat="server" Text='<%# Bind("5thAnalysisText") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="SubLeger Amount">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSubLegerAmount" runat="server" Text='<%# Bind("SubLegerAmount") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="SlNo">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSlNo" runat="server" Text='<%# Bind("SlNo") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="TranactionLineNoSubLedger">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label33" runat="server" Text='<%# Bind("TranactionLineNoSubLedger") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:CommandField ShowSelectButton="True" />
                                                                        <asp:CommandField ShowDeleteButton="True" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                        </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                        
                                    </asp:Panel>
                                    <asp:Button ID="btnShowAnalysisPopup" runat="server" Style="display: none" />
                                </td>
                            </tr>


                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Unposted Voucher">
                    <ContentTemplate>
                        <table style="width: 750px">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel3" runat="server" BorderColor="#336699" BorderStyle="Solid"
                                        BorderWidth="0px" Height="25px" Style="text-align: right">
                                        <asp:Button ID="ButtonPost" runat="server"
                                            Text="Post" Width="100px" CssClass="CssBtnRegular" />
                                        <asp:Button ID="ButtonView" runat="server"
                                            Text="View" Width="100px" CssClass="CssBtnShowAll" />
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:Panel ID="Panel9" runat="server" BorderColor="#336699" BorderStyle="Solid"
                                        BorderWidth="0px" Height="450px" Width="100%">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gdvView" runat="server" BackColor="White"
                                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4"
                                                        ForeColor="Black" GridLines="Horizontal"
                                                        Width="100%">
                                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                        <HeaderStyle CssClass="gridHeader" />
                                                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chk" runat="server"
                                                                        Checked="false"
                                                                        Text='' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>

                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>

            </ajaxToolkit:TabContainer>
           
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
     <script type="text/javascript">
         function UpdateCurrencyAmount() {
             var frequencyValue = document.getElementById("<%= txtCurrencyRate.ClientID %>").value;
             if (frequencyValue == "" || frequencyValue == 0) {
                 document.getElementById("<%= txtBaseAmount.ClientID %>").innerHTML = 0;
                document.getElementById("<%=txtBaseAmount.ClientID%>").value = 0;
            }
            else {
                document.getElementById("<%= txtBaseAmount.ClientID %>").innerHTML = (document.getElementById("<%= txtAmount.ClientID %>").value * document.getElementById("<%= txtCurrencyRate.ClientID %>").value).toFixed(2);
                document.getElementById("<%=txtBaseAmount.ClientID%>").value = (document.getElementById("<%= txtAmount.ClientID %>").value * document.getElementById("<%= txtCurrencyRate.ClientID %>").value).toFixed(2);
             }

             
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 46 || charCode > 57)) {
                alert("Please Enter Only Numeric Value:");
                return false;
            }
            return true;
        }
            </script>
</asp:Content>
