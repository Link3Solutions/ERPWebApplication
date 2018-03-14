<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProcessDetailsForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.HRMS.SelfService.ProcessDetailsForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td colspan="3">
                        <ajaxToolkit:TabContainer ID="TabContainerProcessDetails" runat="server" Width="100%" Height="100%" ActiveTabIndex="4" CssClass="tab" CssTheme="None">
                            <ajaxToolkit:TabPanel ID="TabPanelDescription" runat="server" HeaderText="Description">
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td colspan="2" style="width:400px">
                                                <table style="width:100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text="Process Description"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtProcessDescription" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            <asp:RadioButtonList ID="RadioButtonListStatus" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Selected="True" Value="A">Active</asp:ListItem>
                                                                <asp:ListItem Value="I">Inactive</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td colspan="2" style="width:550px;">
                                                <table style="width:100%;margin-top:-25px">
                                                    <tr>
                                                        <td colspan="3" style="text-align:right">
                                                            <div style="position: fixed; background-color: white; width: 360px;  float: right;">
                                                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="100px" />
                                                            <asp:Button ID="btnClear" runat="server" Text="Clear" Width="100px" OnClick="btnClear_Click" />
                                                                </div>
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
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:GridView ID="grdProcessDescription" runat="server" Width="100%">
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanelFlowDefinition" runat="server" HeaderText="Flow Definition">
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td colspan="2" style="width:400px">
                                                <table style="width:100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label18" runat="server" Text="Process"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlProcessFlow" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label19" runat="server" Text="Category ID"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownList2" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label20" runat="server" Text="Flow Description"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtFlowDescription" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td colspan="2" style="width:550px">
                                                <table style="width:100%;margin-top:-19px">
                                                    <tr>
                                                        <td colspan="3" style="text-align:right">
                                                            <div style="position: fixed; background-color: white; width: 360px;  float: right;">
                                                            <asp:Button ID="btnSaveFlowDefinition" runat="server" Text="Save" Width="100px" OnClick="btnSaveFlowDefinition_Click" />
                                                            <asp:Button ID="btnClearFlowDefinition" runat="server" Text="Clear" Width="100px" />
                                                                </div>
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
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:GridView ID="grdFlowDefinition" runat="server" Width="100%">
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanelLevelDescription" runat="server" HeaderText="Level Description">
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td colspan="2" style="width:400px">
                                                <table style="width:100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label16" runat="server" Text="Process"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlProcessLevel" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label17" runat="server" Text="Level Description"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtLevelDescription" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td colspan="2" style="width:550px">
                                                <table style="width:100%;margin-top:-26px">
                                                    <tr>
                                                        <td colspan="3" style="text-align:right">
                                                            <div style="position: fixed; background-color: white; width: 360px;  float: right;">
                                                            <asp:Button ID="btnSaveLevelDescription" runat="server" Text="Save" Width="100px" OnClick="btnSaveLevelDescription_Click" />
                                                            <asp:Button ID="btnClearLevelDescription" runat="server" Text="Clear" Width="100px" />
                                                                </div>
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
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:GridView ID="grdLevelDescription" runat="server" Width="100%">
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanelActionType" runat="server" HeaderText="Action Type">
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td colspan="2" style="width:400px">
                                                <table style="width:100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label14" runat="server" Text="Process"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlProcessAction" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label15" runat="server" Text="Action Type"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtActionType" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td colspan="2" style="width:550px">
                                                <table style="width:100%;margin-top:-26px">
                                                    <tr>
                                                        <td colspan="3" style="text-align:right">
                                                            <div style="position: fixed; background-color: white; width: 360px;  float: right;">
                                                            <asp:Button ID="btnSaveActionType" runat="server" Text="Save" Width="100px" OnClick="btnSaveActionType_Click" />
                                                            <asp:Button ID="btnClearActionType" runat="server" Text="Clear" Width="100px" />
                                                                </div>
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
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:GridView ID="grdActionType" runat="server" Width="100%">
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanelConfiguration" runat="server" HeaderText="Configuration">
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                             <td colspan="2" style="width:400px">
                                                 <div style="height:190px">
                                                <table style="width:100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label21" runat="server" Text="Process"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlProcessConfiguration" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProcessConfiguration_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" Text="Process Flow"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlFlowConfiguration" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFlowConfiguration_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" Text="Department"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlDepartmentConfiguration" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartmentConfiguration_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label22" runat="server" Text="Employee Code"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtEmployeeCodeConfigure" runat="server"></asp:TextBox>
                                                            <ajaxToolkit:AutoCompleteExtender ID="txtEmployeeCodeConfigure_AutoCompleteExtender" runat="server" 
                                                                BehaviorID="txtEmployeeCodeConfigure_AutoCompleteExtender" DelimiterCharacters="" 
                                                                MinimumPrefixLength="1"
                                                                ServiceMethod="GetEmpId"
                                                                ServicePath="~/WebService/ServiceSystem.asmx"
                                                                CompletionListCssClass="autocomplete_completionListElement"
                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                CompletionListItemCssClass="autocomplete_listItem2"
                                                                TargetControlID="txtEmployeeCodeConfigure">
                                                            </ajaxToolkit:AutoCompleteExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label4" runat="server" Text="Team Name"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtTeamName" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label34" runat="server" Text="Effective Date"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtEffectiveDate" runat="server" TextMode="Date"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                                     </div>
                                            </td>
                                            <td colspan="2" style="width:550px">
                                                <div style="height:190px">
                                                <table style="width:100%;margin-top:-10px">
                                                    <tr>
                                                        <td colspan="3" style="text-align:right">
                                                            <div style="position: fixed; background-color: white; width: 360px;  float: right;">
                                                            <asp:Button ID="btnSaveConfiguration" runat="server" Text="Save" Width="100px" OnClick="btnSaveConfiguration_Click" />
                                                            <asp:Button ID="btnClearConfiguration" runat="server" Text="Clear" Width="100px" />
                                                                </div>
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
                                                        <td colspan="3">
                                                            <asp:GridView ID="grdProcessTeam" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="grdProcessTeam_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="SL">
                                                                    <ItemTemplate>
                                                                        <%# Container.DisplayIndex + 1 %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Team Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label30" runat="server" Text='<%# Bind("ProcessName") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Process">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label27" runat="server" Text='<%# Bind("ProcessDescription") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Department">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label29" runat="server" Text='<%# Bind("EntityName") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="ReferenceNo" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label26" runat="server" Text='<%# Bind("ReferenceNo") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="DepartmentID" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label31" runat="server" Text='<%# Bind("DepartmentId") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="ProcessFlowID" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label33" runat="server" Text='<%# Bind("ProcessFlowId") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="ProcessId" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label32" runat="server" Text='<%# Bind("ProcessId") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:CommandField ShowSelectButton="True" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
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
                                        <tr>
                                            <td colspan="4">
                                                <table style="width:100%;">
                                                    <tr>
                                                        <td colspan="11" style="text-align:left">
                                                            <asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Overline="False" Font-Strikeout="False" Font-Underline="True" Text="APPROVAL FLOW CONFIGURE"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label5" runat="server" Text="Level"></asp:Label>
                                                        </td>
                                                        <td colspan="4">
                                                            <asp:Label ID="Label6" runat="server" Text="Access ID"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label7" runat="server" Text="Access Permission"></asp:Label>
                                                        </td>
                                                        <td colspan="4">
                                                            <asp:Label ID="Label8" runat="server" Text="SubAccess ID"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label24" runat="server" Text="Access Permission"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:DropDownList ID="ddlLevelConfiguration" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="txtAccessId" runat="server" AutoPostBack="True" Style="height: 22px" Width="170px"></asp:TextBox>
                                                            <ajaxToolkit:AutoCompleteExtender ID="txtAccessId_AutoCompleteExtender" runat="server" 
                                                                BehaviorID="txtAccessId_AutoCompleteExtender" DelimiterCharacters="" 
                                                                MinimumPrefixLength="1"
                                                                ServiceMethod="GetEmpId"
                                                                ServicePath="~/WebService/ServiceSystem.asmx"
                                                                CompletionListCssClass="autocomplete_completionListElement"
                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                CompletionListItemCssClass="autocomplete_listItem2"
                                                                TargetControlID="txtAccessId">
                                                            </ajaxToolkit:AutoCompleteExtender>
                                                        </td>
                                                        <td colspan="3">
                                                            <asp:CheckBoxList ID="ChkLisBoxAccessPermission" runat="server" RepeatDirection="Horizontal">
                                                            </asp:CheckBoxList>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="txtSubAccessId0" runat="server" AutoPostBack="True" Style="margin-left: 0px" Width="170px"></asp:TextBox>
                                                            <ajaxToolkit:AutoCompleteExtender ID="txtSubAccessId0_AutoCompleteExtender" runat="server" 
                                                                BehaviorID="txtSubAccessId0_AutoCompleteExtender" DelimiterCharacters="" 
                                                                MinimumPrefixLength="1"
                                                                ServiceMethod="GetEmpId"
                                                                ServicePath="~/WebService/ServiceSystem.asmx"
                                                                CompletionListCssClass="autocomplete_completionListElement"
                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                CompletionListItemCssClass="autocomplete_listItem2"
                                                                TargetControlID="txtSubAccessId0">
                                                            </ajaxToolkit:AutoCompleteExtender>
                                                        </td>
                                                        <td colspan="2">

                                                            <asp:CheckBoxList ID="chklistboxSubAccessPermission" runat="server" CssClass="checkbox" RepeatDirection="Horizontal" >
                                                            </asp:CheckBoxList>
                                                            <asp:Label ID="Label9" runat="server" AssociatedControlID="chklistboxSubAccessPermission" CssClass="checkBoxList"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="11" style="text-align:left">
                                                            <asp:Button ID="btnAdd" runat="server" Text="Add" Width="100px" OnClick="btnAdd_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">&nbsp;</td>
                                                        <td colspan="5">&nbsp;</td>
                                                        <td colspan="3">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="11">
                                                            <asp:GridView ID="grdConfiguration" runat="server" Width="100%" AutoGenerateColumns="False">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Line">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblLine" runat="server" Text='<%# Bind("Line") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Level">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblLevelId" runat="server" Text='<%# Bind("LevelId") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Level Id" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblLevelIdValue" runat="server" Text='<%# Bind("LevelIdValue") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Access Id">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAccessId" runat="server" Text='<%# Bind("AccessId") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Access Permission">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAccessPermission" runat="server" Text='<%# Bind("AccessPermission") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Access PermissionValue" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAccessPermissionValue" runat="server" Text='<%# Bind("AccessPermissionValue") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Sub Access Id	">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSubAccessId" runat="server" Text='<%# Bind("SubAccessId") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="SubAccess Permission">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSubAccessPermission" runat="server" Text='<%# Bind("SubAccessPermission") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="SubAccess PermissionValue" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSubAccessPermissionValue" runat="server" Text='<%# Bind("SubAccessPermissionValue") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <table style="width:100%;">
                                                    <tr>
                                                        <td colspan="3" style="text-align:left">
                                                            <asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Underline="True" Text="EMPLOYEE DETAILS"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:GridView ID="grdEmployes" runat="server" Width="100%" AutoGenerateColumns="False">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Employee ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblEmployeeID" runat="server" Text='<%# Bind("EmployeeID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFullName" runat="server" Text='<%# Bind("FullName") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Designation">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDesignationID" runat="server" Text='<%# Bind("FieldOfName") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CheckBoxEmployee" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                        </ajaxToolkit:TabContainer>
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
        </ContentTemplate>
        <Triggers></Triggers>
    </asp:UpdatePanel>
</asp:Content>
