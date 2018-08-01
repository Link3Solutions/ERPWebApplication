<%@ Page Title="Two Columns Table Data" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="TwoColumnsTableDataForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Organization.MasterPage.TwoColumnsTableDataForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width:1200px">
            <table style="width: 100%; text-align: left">
                <tr>
                    <td style="width: 430px; float: left;margin-left:1px;margin-top:1px">
                        <asp:Label ID="lblStatus" runat="server" Text="NO DATA FOUND !" Visible="false"></asp:Label>
                        <div style="width:100%;height: 530px; overflow-y: scroll; overflow-x: hidden">
                        <asp:GridView ID="grdTableName" Width="100%" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdTableName_RowDataBound" OnSelectedIndexChanged="grdTableName_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="SL">
                                    <ItemTemplate>
                                        <%# Container.DisplayIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
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
                                    <ItemStyle Font-Size="11pt" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                            </div>
                    </td>
                    <td  style="width:425px;text-align: left; float: left;margin-left:100px;margin-top:1px">
                        <asp:Panel ID="PanelForInputControl" runat="server">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="lblSelectedTableName" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblOptionalName" runat="server" Text="Name"></asp:Label></td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtFieldOfName" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblOptionalDescription" runat="server" Text="Description"></asp:Label></td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtFieldDescription" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr> <td colspan="3"></td></tr>
                            <tr> <td colspan="3">
                                <asp:GridView ID="grdTableData" runat="server" AutoGenerateColumns="False" OnRowCommand="grdTableData_RowCommand" OnRowDataBound="grdTableData_RowDataBound" OnRowDeleting="grdTableData_RowDeleting" Width="421px">
                            <Columns>
                                <asp:TemplateField HeaderText="SL">
                                    <ItemTemplate>
                                        <%# Container.DisplayIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFieldOfID" runat="server" Text='<%# Bind("FieldOfID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFieldOfName" runat="server" Text='<%# Bind("FieldOfName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFieldDescription" runat="server" Text='<%# Bind("FieldDescription") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                                 </td></tr>
                        </table>
                            </asp:Panel>
                    </td>
                    <td  style=" width:100px;text-align: right; float: right;padding-left:25px;padding-top:1px;padding-right:1px;">
                        <div style="position: fixed; background-color: white">
                            <table style="width: 100%;">
                                <tr>
                                    <td><asp:Button ID="btnSave" runat="server" CssClass="CssBtnSave" Text="Save" Width="70px" OnClick="btnSave_Click" /></td>
                                </tr>
                                <tr>
                                    <td><asp:Button ID="btnClear" runat="server" Text="Cancel" CssClass="CssBtnClear" Width="70px" OnClick="btnClear_Click" /></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </div>
                        </td>
                </tr>
            </table>
                </div>
        </ContentTemplate>
        <Triggers>
           
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
