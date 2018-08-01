<%@ Page Title="Two Columns Table Data(Auto)" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TwoColumnsTableDataAutoForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Organization.MasterPage.TwoColumnsTableDataAutoForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;text-align:left">
                <tr>
                    <td colspan="3">
                        <div style="width:50%;height: 530px; overflow-y: scroll; overflow-x: hidden">
                        <asp:GridView ID="grdTableName" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="grdTableName_RowCommand" OnRowDataBound="grdTableName_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="TableID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTableID" runat="server" Text='<%# Bind("TableID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Table Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTableName" runat="server" Text='<%# Bind("TableName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField SelectText="Apply" ShowSelectButton="True" HeaderText="Action" />
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text="Submitted" Font-Bold="True" ForeColor="Green"></asp:Label>
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
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>

        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
