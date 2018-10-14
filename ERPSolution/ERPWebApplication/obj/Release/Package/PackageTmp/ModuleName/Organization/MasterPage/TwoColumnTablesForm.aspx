<%@ Page Title="Two Column Tables" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TwoColumnTablesForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Organization.MasterPage.TwoColumnTablesForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 125px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelTwoColumnTable" runat="server">
            <div style="width:1190px">
            <table style="width: 100%; text-align: left">
                <tr>
                    <td colspan="2" style="width: 600px; float: left">
                        <div style="width: 600px">
                            <table style="width: 85%;">
                                <tr>
                                    <td class="auto-style1">
                                        <asp:Label ID="Label1" runat="server" Text="Table Name"></asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td>
                                        <asp:TextBox ID="txtTableName" runat="server"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        <asp:Label ID="Label2" runat="server" Text="Entry Mode"></asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td>
                                        <asp:TextBox ID="txtEntryMode" runat="server"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        <asp:Label ID="Label3" runat="server" Text="Related To"></asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td>
                                        <asp:TextBox ID="txtRelatedTo" runat="server"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        <asp:Label ID="Label5" runat="server" Text="Entry System"></asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlEntrySystem" runat="server">
                                            <asp:ListItem Selected="True" Value="-1">--- Please Select ---</asp:ListItem>
                                            <asp:ListItem Value="A">Auto</asp:ListItem>
                                            <asp:ListItem Value="M">Manual</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        <asp:Label ID="Label4" runat="server" Text="Related User Role"></asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlRelatedUserRoleID" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAddRole" runat="server" CssClass="CssBtnAddNew" Text="Add New" Width="100px" OnClick="btnAddRole_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td colspan="2" style=" width:100px;text-align: right; float: right;padding-left:25px;padding-top:1px;padding-right:1px;">
                        <div style="position: fixed; background-color: white">
                            <table style="width: 100%;">
                                <tr>
                                    <td><asp:Button ID="btnSave" runat="server" CssClass="CssBtnSave" Text="Save" Width="70px" OnClick="btnSave_Click" /></td>
                                </tr>
                                <tr>
                                    <td><asp:Button ID="btnClear" runat="server" CssClass="CssBtnClear" Text="Cancel" Width="70px" OnClick="btnClear_Click" /></td>
                                </tr>
                                <tr>
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
                        <div style="width:1040px;height: 300px; overflow-y: scroll; overflow-x: hidden">
                        <asp:GridView ID="grdTwoColumnTables" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="grdTwoColumnTables_RowCommand" OnRowDataBound="grdTwoColumnTables_RowDataBound" OnRowDeleting="grdTwoColumnTables_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="SL">
                                    <ItemTemplate>
                                        <%# Container.DisplayIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Table ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTableID" runat="server" Text='<%# Bind("TableID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Table Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTableName" runat="server" Text='<%# Bind("TableName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Entry Mode">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEntryMode" runat="server" Text='<%# Bind("EntryMode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Related To">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRelatedTo" runat="server" Text='<%# Bind("RelatedTo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Related User Role ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRelatedUserRoleID" runat="server" Text='<%# Bind("RelatedUserRoleID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Related User Role">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRelatedToText" runat="server" Text='<%# Bind("RelatedToText") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Entry System">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEntrySystem" runat="server" Text='<%# Bind("EntrySystem") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" SelectText="Edit" />
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                            </div>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
                </div>
                </asp:Panel>
            <asp:Panel ID="PanelRelatedRole" Width="100%" runat="server">
                <div style="width:1190px">
                    <table style="width: 100%; text-align: left">
                        <tr>
                    <td colspan="2" style="width: 600px; float: left">
                        <div style="width: 600px">
                            <table style="width: 85%;">
                                <tr>
                                    <td style="width:98px">
                                        <asp:Label ID="Label6" runat="server" Text="Related User Role"></asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td>
                                        <asp:TextBox ID="txtRelatedUserRole" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            </div>
                        </td>
                    <td colspan="2" style=" width:100px;text-align: right; float: right;padding-left:25px;padding-top:1px;padding-right:1px;">
                        <div style="position: fixed; background-color: white">
                            <table style="width: 100%;">
                                <tr>
                                    <td><asp:Button ID="btnSaveRelatedRole" runat="server" CssClass="CssBtnSave" Text="Save" Width="70px" OnClick="btnSaveRelatedRole_Click"  /></td>
                                </tr>
                                <tr>
                                    <td><asp:Button ID="btnCancelRelatedRole" runat="server" CssClass="CssBtnClear" Text="Cancel" Width="70px" OnClick="btnCancelRelatedRole_Click"  /></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </div>
                        </td>
                </tr>
                        <tr>
                    <td>
                        <asp:Label ID="lblRelatedUserRoleID" runat="server" Visible="False"></asp:Label>
                            </td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div style="width:1040px;height: 400px; overflow-y: scroll; overflow-x: hidden">
                        <asp:GridView ID="grdRelatedUserRole" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="grdRelatedUserRole_RowCommand" OnRowDataBound="grdRelatedUserRole_RowDataBound" OnRowDeleting="grdRelatedUserRole_RowDeleting" >
                            <Columns>
                                <asp:TemplateField HeaderText="SL">
                                    <ItemTemplate>
                                        <%# Container.DisplayIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RelatedToID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRelatedToID" runat="server" Text='<%# Bind("RelatedToID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Related User Role ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRelatedToText" runat="server" Text='<%# Bind("RelatedToText") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                            
                        </asp:GridView>
                            </div>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>

                        </table>
                    </div>
                </asp:Panel>
        </ContentTemplate>
        <Triggers>
            
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
