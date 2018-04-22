<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProcessDetailsForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.HRMS.SelfService.ProcessDetailsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .bottomBorderControl {
            border-bottom-style:none;
            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td colspan="3">
                        <ajaxToolkit:TabContainer ID="TabContainerProcessDetails" runat="server" Width="100%" Height="100%" ActiveTabIndex="4" CssClass="tab" CssTheme="None">
                            <ajaxToolkit:TabPanel ID="TabPanelDescription" runat="server" CssClass="bottomBorderControl" HeaderText="Description">
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td colspan="2" style="width: 400px">
                                                <table style="width: 100%;">
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
                                            <td colspan="2" style="width: 550px;">
                                                <table style="width: 100%; margin-top: -25px">
                                                    <tr>
                                                        <td colspan="3" style="text-align: right">
                                                            <div style="position: fixed; background-color: white; width: 360px; float: right;">
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
                                                <asp:GridView ID="grdProcessDescription" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="grdProcessDescription_RowCommand" OnRowDeleting="grdProcessDescription_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="SL">
                                                            <ItemTemplate>
                                                                <%# Container.DisplayIndex + 1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Process Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProcessId" runat="server" Text='<%# Bind("ProcessId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Process Description">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProcessDescription" runat="server" Text='<%# Bind("ProcessDescription") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="StatusID" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStatusText" runat="server" Text='<%# Bind("StatusText") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField ShowDeleteButton="True" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
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
                                            <td colspan="2" style="width: 400px">
                                                <table style="width: 100%;">
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
                                                            <asp:Label ID="Label19" runat="server" Text="Category"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCategory" runat="server">
                                                                <asp:ListItem Value="-1">--please select--</asp:ListItem>
                                                                <asp:ListItem Value="1">Staff</asp:ListItem>
                                                                <asp:ListItem Value="2">Officer</asp:ListItem>
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
                                            <td colspan="2" style="width: 550px">
                                                <table style="width: 100%; margin-top: -19px">
                                                    <tr>
                                                        <td colspan="3" style="text-align: right">
                                                            <div style="position: fixed; background-color: white; width: 360px; float: right;">
                                                                <asp:Button ID="btnSaveFlowDefinition" runat="server" Text="Save" Width="100px" OnClick="btnSaveFlowDefinition_Click" />
                                                                <asp:Button ID="btnClearFlowDefinition" runat="server" Text="Clear" Width="100px" OnClick="btnClearFlowDefinition_Click" />
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
                                                <asp:GridView ID="grdFlowDefinition" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="grdFlowDefinition_RowCommand" OnRowDeleting="grdFlowDefinition_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="SL">
                                                            <ItemTemplate>
                                                                <%# Container.DisplayIndex + 1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ProcessId" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProcessId" runat="server" Text='<%# Bind("ProcessId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Process">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProcessDescription" runat="server" Text='<%# Bind("ProcessDescription") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CategoryId" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCategoryId" runat="server" Text='<%# Bind("CategoryId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Category ">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCategoryIdText" runat="server" Text='<%# Bind("CategoryIdText") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ProcessFlowId" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProcessFlowId" runat="server" Text='<%# Bind("ProcessFlowId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Flow Description">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFlowDescription" runat="server" Text='<%# Bind("FlowDescription") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField ShowDeleteButton="True" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
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
                                            <td colspan="2" style="width: 400px">
                                                <table style="width: 100%;">
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
                                            <td colspan="2" style="width: 550px">
                                                <table style="width: 100%; margin-top: -26px">
                                                    <tr>
                                                        <td colspan="3" style="text-align: right">
                                                            <div style="position: fixed; background-color: white; width: 360px; float: right;">
                                                                <asp:Button ID="btnSaveLevelDescription" runat="server" Text="Save" Width="100px" OnClick="btnSaveLevelDescription_Click" />
                                                                <asp:Button ID="btnClearLevelDescription" runat="server" Text="Clear" Width="100px" OnClick="btnClearLevelDescription_Click" />
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
                                                <asp:GridView ID="grdLevelDescription" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="grdLevelDescription_RowCommand" OnRowDeleting="grdLevelDescription_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="SL">
                                                            <ItemTemplate>
                                                                <%# Container.DisplayIndex + 1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ProcessId" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProcessId" runat="server" Text='<%# Bind("ProcessId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Process">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProcessDescription" runat="server" Text='<%# Bind("ProcessDescription") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ProcessLevelId" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProcessLevelId" runat="server" Text='<%# Bind("ProcessLevelId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Level Description">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLevelDescription" runat="server" Text='<%# Bind("LevelDescription") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField ShowDeleteButton="True" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
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
                                            <td colspan="2" style="width: 400px">
                                                <table style="width: 100%;">
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
                                            <td colspan="2" style="width: 550px">
                                                <table style="width: 100%; margin-top: -26px">
                                                    <tr>
                                                        <td colspan="3" style="text-align: right">
                                                            <div style="position: fixed; background-color: white; width: 360px; float: right;">
                                                                <asp:Button ID="btnSaveActionType" runat="server" Text="Save" Width="100px" OnClick="btnSaveActionType_Click" />
                                                                <asp:Button ID="btnClearActionType" runat="server" Text="Clear" Width="100px" OnClick="btnClearActionType_Click" />
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
                                                <asp:GridView ID="grdActionType" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="grdActionType_RowCommand" OnRowDeleting="grdActionType_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="SL">
                                                            <ItemTemplate>
                                                                <%# Container.DisplayIndex + 1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ProcessId" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProcessId" runat="server" Text='<%# Bind("ProcessId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Process">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProcessDescription" runat="server" Text='<%# Bind("ProcessDescription") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ActionTypeId" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblActionTypeId" runat="server" Text='<%# Bind("ActionTypeId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Action Type">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAction" runat="server" Text='<%# Bind("Action") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField ShowDeleteButton="True" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
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
                                            <td colspan="2" style="width: 400px">
                                                <div style="height: 190px">
                                                    <table style="width: 100%;">
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
                                            <td colspan="2" style="width: 550px">
                                                <div style="height: 190px">
                                                    <table style="width: 100%; margin-top: -10px">
                                                        <tr>
                                                            <td colspan="3" style="text-align: right">
                                                                <div style="position: fixed; background-color: white; width: 360px; float: right;">
                                                                    <asp:Button ID="btnSaveConfiguration" runat="server" Text="Save" Width="100px" OnClick="btnSaveConfiguration_Click" />
                                                                    <asp:Button ID="btnClearConfiguration" runat="server" Text="Clear" Width="100px" OnClick="btnClearConfiguration_Click" />
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
                                                                <div style="width: 100%; height: 155px; overflow-y: scroll; overflow-x: hidden;">
                                                                    <asp:GridView ID="grdProcessTeam" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="grdProcessTeam_RowCommand" OnRowDeleting="grdProcessTeam_RowDeleting">
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
                                                                                    <asp:Label ID="lblProcessName" runat="server" Text='<%# Bind("ProcessName") %>'></asp:Label>
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
                                                                                    <asp:Label ID="lblReferenceNo" runat="server" Text='<%# Bind("ReferenceNo") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="DepartmentID" Visible="False">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblDepartmentId" runat="server" Text='<%# Bind("DepartmentId") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="ProcessFlowID" Visible="False">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblProcessFlowId" runat="server" Text='<%# Bind("ProcessFlowId") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="ProcessId" Visible="False">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblProcessId" runat="server" Text='<%# Bind("ProcessId") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:CommandField ShowSelectButton="True" />
                                                                            <asp:TemplateField HeaderText="EffectiveDate" Visible="False">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblEffectiveDate" runat="server" Text='<%# Bind("EffectiveDate", "{0:d}") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </div>
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
                                                <table style="width: 100%;">
                                                    <tr style="border-bottom:solid;border-bottom-color:gray;border-bottom-width:.5px">
                                                        <td colspan="11" style="text-align: left">
                                                            <asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Text="APPROVAL FLOW CONFIGURE"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color:#9FD1E4">
                                                        <td>
                                                            <asp:Label ID="Label5" runat="server" Text="Level" Width="150px"></asp:Label>
                                                        </td>
                                                        <td colspan="4">
                                                            <asp:Label ID="Label6" runat="server" Text="Access ID" Width="150px"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label7" runat="server" Text="Access Permission" Width="300px"></asp:Label>
                                                        </td>
                                                        <td colspan="4">
                                                            <asp:Label ID="Label8" runat="server" Text="SubAccess ID" Width="150px"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label24" runat="server" Text="Access Permission" Width="300px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height:30px">
                                                        <td colspan="2">
                                                            <asp:DropDownList ID="ddlLevelConfiguration" runat="server" Width="150px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="txtAccessId" runat="server" AutoPostBack="True" Style="height: 22px" Width="150px"></asp:TextBox>
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
                                                            <asp:CheckBoxList ID="ChkLisBoxAccessPermission" runat="server" RepeatDirection="Horizontal" Width="300px">
                                                            </asp:CheckBoxList>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="txtSubAccessId0" runat="server" AutoPostBack="True" Style="margin-left: 0px" Width="150px"></asp:TextBox>
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

                                                            <asp:CheckBoxList ID="chklistboxSubAccessPermission" runat="server" RepeatDirection="Horizontal" Width="300px">
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="11" style="text-align: left">
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
                                                            <asp:GridView ID="grdConfiguration" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="grdConfiguration_RowCommand" OnRowDeleting="grdConfiguration_RowDeleting">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Line" Visible="False">
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
                                                                    <asp:CommandField ShowSelectButton="True" />
                                                                    <asp:CommandField ShowDeleteButton="True" />
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
                                                <table style="width: 100%;">
                                                    <tr style="border-bottom:solid;border-bottom-color:gray;border-bottom-width:.5px">
                                                        <td colspan="3" style="text-align: left">
                                                            <asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Underline="False" Text="EMPLOYEE DETAILS"></asp:Label>
                                                            <asp:Label ID="lblReferenceNo" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:GridView ID="grdEmployes" runat="server" Width="100%" AutoGenerateColumns="False" OnRowDataBound="grdEmployes_RowDataBound">
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
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
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
