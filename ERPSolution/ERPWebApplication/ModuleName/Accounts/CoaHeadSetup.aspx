<%@ Page Title="Account Head Setup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoaHeadSetup.aspx.cs" Inherits="ERPWebApplication.ModuleName.Accounts.CoaHeadSetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
        }

        .auto-style2 {
            width: 103px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 99%">
                <tr>
                    <td colspan="3">
                        <table style="width: 35%; text-align: left">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="True" placeholder="Search..." Width="337px"></asp:TextBox>
                                    </td>
                                    <ajaxToolkit:AutoCompleteExtender ID="txtSearch_AutoCompleteExtender" runat="server"
                                        CompletionListCssClass="autocomplete_completionListElement"
                                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                        CompletionListItemCssClass="autocomplete_listItem2"
                                        DelimiterCharacters=""
                                        Enabled="True"
                                        MinimumPrefixLength="1" ServiceMethod="GetCOAHeadName" ServicePath="~/WebService/ServiceSystem.asmx" TargetControlID="txtSearch">
                                    </ajaxToolkit:AutoCompleteExtender>
                                    <td>
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="CssBtnSearch" Height="30px" Width="100px" OnClick="btnSearch_Click" /></td>
                                </tr>

                            </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3"> 
                        <hr id="searchbottom" runat="server" style="border:0; height: 1px; background: #333;  background-image: linear-gradient(to right, #ccc, #333, #ccc); width: 1175px;margin-top:-2px" />
                        </td>
                    
                </tr>
                <tr >
                    <td>
                        <div style="height:32px;text-align: left; width: 500px;margin-top:-8px">
                                <asp:Button ID="btnAddNew" runat="server" CssClass="CssBtnAddNew" Text="Add New" Width="70px" OnClick="btnAddNew_Click" /><asp:Button ID="btnEdit" runat="server" CssClass="CssBtnUpdate" Text="Edit" Width="70px" OnClick="btnEdit_Click" />
                                </div>
                    </td>
                    <td>
                        <div style="text-align:left; width: 425px">
                            </div>
                    </td>
                    <td style="width:125px;float:left">
                        <div style="position:fixed;margin-top:-8px;height:32px">
                            <asp:Button ID="btnPrintSummery" runat="server" Text="Print" CssClass="CssBtnPrint" Width="70px" />
                            </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3"> 
                        <hr id="Hr1" runat="server" style="border:0; height: 1px; background: #333;  background-image: linear-gradient(to right, #ccc, #333, #ccc); width: 1175px;margin-top:-2px" />
                        </td>
                    
                </tr>
                <tr>
                    <td>
                        <div style="height:512px;text-align: left;width: 500px;">   
                            <div style="overflow:auto; height:425px;text-align: left;width: 500px;">   
                            <asp:Panel ID="Panel5" runat="server" Height="100%" 
                                    Width="100%">
                                    <asp:TreeView ID="treeCOAHead" runat="server" NodeIndent="15" 
                                        OnTreeNodePopulate="treeCOAHead_TreeNodePopulate"
                                        OnSelectedNodeChanged="treeCOAHead_SelectedNodeChanged">
                                        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                    <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="0px"
                                        NodeSpacing="0px" VerticalPadding="0px" ></NodeStyle>
                                    <ParentNodeStyle Font-Bold="False"  />
                                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                                        VerticalPadding="0px" />
                                        <ParentNodeStyle Font-Bold="True" />
                                                        <RootNodeStyle Font-Bold="True" />
                                    </asp:TreeView>
                                </asp:Panel>
                                </div>
                             </div>
                    </td>
                    <td>
                        <div style="text-align:left;height: 512px; width: 425px">
                            <asp:Panel ID="Panel1" runat="server" Height="100%" BackColor="#cccccc" Width="95%">
                                <table style="width: 93%; text-align: left; margin-left: 15px">
                                    <tr>
                                        <td colspan="4">
                                            <table style="width: 99%;">
                                                <tr>
                                                    <td>
                                                        <div style="margin-top:-17px;height:50px">
                                                        <asp:RadioButtonList ID="rblAccountType" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                                                            OnSelectedIndexChanged="rblAccountType_SelectedIndexChanged" Width="345px" Font-Names="Tahoma" Font-Size="10pt">
                                                            <asp:ListItem Value="0" Selected="True" >Asset</asp:ListItem>
                                                            <asp:ListItem Value="1">Liability</asp:ListItem>
                                                            <asp:ListItem Value="2">Revenue</asp:ListItem>
                                                            <asp:ListItem Value="3">Expense</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                            </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Parent Account"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlParentAccountNo" runat="server" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="ddlParentAccountNo_SelectedIndexChanged" Width="212px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="Account Head"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtAccountHead" runat="server" Width="205px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text="Account Type"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlAccountType" runat="server" Width="212px"
                                                Enabled="False">
                                                <asp:ListItem Value="0">Asset</asp:ListItem>
                                                <asp:ListItem Value="1">Liability</asp:ListItem>
                                                <asp:ListItem Value="2">Revenue</asp:ListItem>
                                                <asp:ListItem Value="3">Expense</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align:top">
                                            <asp:Label ID="Label7" runat="server" Text="A/C Description"></asp:Label>
                                        </td>
                                        <td style="vertical-align:top">:</td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtAccountDescription" runat="server" Height="100px" TextMode="MultiLine" Width="205px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <table style="width: 99%; text-align: left">
                                                <tr>
                                                    <td class="auto-style1" colspan="3">
                                                        <asp:CheckBox ID="CheckBoxIsBudgetRelated"  CssClass="checkbox"  runat="server"  />
                                                        <asp:Label ID="Label2" runat="server" AssociatedControlID="CheckBoxIsBudgetRelated"  CssClass="checkbox"  Font-Names="Tahoma" Font-Size="10pt">Is Budget Related</asp:Label>
                                                        <asp:CheckBox ID="CheckBoxAnalysisRequired" runat="server" CssClass="checkbox"
                                                            AutoPostBack="True" OnCheckedChanged="CheckBoxAnalysisRequired_CheckedChanged" />
                                                        <asp:Label ID="Label3" runat="server" AssociatedControlID="CheckBoxAnalysisRequired" CssClass="checkbox" Font-Names="Tahoma" Font-Size="10pt">Analysis Required</asp:Label>
                                                    </td>

                                                </tr>
                                                
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:Panel ID="PanelAnalysisRequired" runat="server" Width="100%">
                                                <table style="width: 99%; text-align: left">
                                                    <tr>
                                                        <td class="auto-style2">
                                                            <asp:Label ID="Label1" runat="server" Text="Subledger Type"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtSubledgerTypeID" runat="server" Width="205px"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ID="txtSubledgerTypeID_AutoCompleteExtender" runat="server"
                                                                CompletionListCssClass="autocomplete_completionListElement"
                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                CompletionListItemCssClass="autocomplete_listItem2"
                                                                DelimiterCharacters="" Enabled="True"
                                                                ServicePath="~/WebService/ServiceSystem.asmx"
                                                                MinimumPrefixLength="1"
                                                                ServiceMethod="GetSubledgerType"
                                                                TargetControlID="txtSubledgerTypeID">
                                                            </cc1:AutoCompleteExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style2">
                                                            <asp:Label ID="Label9" runat="server" Text="Subledger Type"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtSubledgerTypeID0" runat="server" Width="205px"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ID="txtSubledgerTypeID0_AutoCompleteExtender" runat="server"
                                                                CompletionListCssClass="autocomplete_completionListElement"
                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                CompletionListItemCssClass="autocomplete_listItem2"
                                                                DelimiterCharacters="" Enabled="True"
                                                                ServicePath="~/WebService/ServiceSystem.asmx"
                                                                MinimumPrefixLength="1"
                                                                ServiceMethod="GetSubledgerType"
                                                                TargetControlID="txtSubledgerTypeID0">
                                                            </cc1:AutoCompleteExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style2">
                                                            <asp:Label ID="Label10" runat="server" Text="Subledger Type"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtSubledgerTypeID1" runat="server" Width="205px"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ID="txtSubledgerTypeID1_AutoCompleteExtender" runat="server"
                                                                CompletionListCssClass="autocomplete_completionListElement"
                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                CompletionListItemCssClass="autocomplete_listItem2"
                                                                DelimiterCharacters="" Enabled="True"
                                                                ServicePath="~/WebService/ServiceSystem.asmx"
                                                                MinimumPrefixLength="1"
                                                                ServiceMethod="GetSubledgerType"
                                                                TargetControlID="txtSubledgerTypeID1">
                                                            </cc1:AutoCompleteExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style2">
                                                            <asp:Label ID="Label11" runat="server" Text="Subledger Type"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtSubledgerTypeID2" runat="server" Width="205px"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ID="txtSubledgerTypeID2_AutoCompleteExtender" runat="server"
                                                                CompletionListCssClass="autocomplete_completionListElement"
                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                CompletionListItemCssClass="autocomplete_listItem2"
                                                                DelimiterCharacters="" Enabled="True"
                                                                ServicePath="~/WebService/ServiceSystem.asmx"
                                                                MinimumPrefixLength="1"
                                                                ServiceMethod="GetSubledgerType"
                                                                TargetControlID="txtSubledgerTypeID2">
                                                            </cc1:AutoCompleteExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style2">
                                                            <asp:Label ID="Label12" runat="server" Text="Subledger Type"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtSubledgerTypeID3" runat="server" Width="205px"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ID="txtSubledgerTypeID3_AutoCompleteExtender" runat="server"
                                                                CompletionListCssClass="autocomplete_completionListElement"
                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                CompletionListItemCssClass="autocomplete_listItem2"
                                                                DelimiterCharacters="" Enabled="True"
                                                                ServicePath="~/WebService/ServiceSystem.asmx"
                                                                MinimumPrefixLength="1"
                                                                ServiceMethod="GetSubledgerType"
                                                                TargetControlID="txtSubledgerTypeID3">
                                                            </cc1:AutoCompleteExtender>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </td>
                    <td style="width:125px;float:left">
                        <div style="height: 500px;position:fixed;margin-top:-5px">
                            <table>
                                <tr>
                                    <td><asp:Button ID="btnSave" runat="server" CssClass="CssBtnSave" OnClick="btnSave_Click" Text="Save" Width="70px" /></td>
                                </tr>
                                <tr>
                                    <td><asp:Button ID="btnCancelAdd" runat="server" Text="Cancel" CssClass="CssBtnCancel" Width="70px" OnClick="btnCancelAdd_Click" /></td>
                                </tr>
                                <tr>
                                    <td><asp:Button ID="btnUpdate" runat="server" Text="Update" Width="70px" CssClass="CssBtnUpdate" OnClick="btnUpdate_Click" /></td>
                                </tr>
                                <tr>
                                    <td><asp:Button ID="btnCancelEdit" runat="server" Text="Cancel" Width="70px" CssClass="CssBtnCancel" OnClick="btnCancelEdit_Click" />
                                    </td>
                                </tr>
                                <tr><td><asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove" CssClass="CssBtnDelete" Visible="False" Width="70px" /></td></tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
            <asp:PostBackTrigger ControlID="btnUpdate" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
