<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActionInDevelopmentForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Accounts.Report.ReportForm.ActionInDevelopmentForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td colspan="2"><table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Account Code"></asp:Label>
                            </td>
                            <td>:</td>
                            <td>
                                <asp:TextBox ID="txtAccountCode" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Journal Date From"></asp:Label>
                            </td>
                            <td>:</td>
                            <td>
                                <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Journal Date To"></asp:Label>
                            </td>
                            <td>:</td>
                            <td>
                                <asp:TextBox ID="txtToDate" runat="server" TextMode="Date"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    </td>
                    <td colspan="2">
                        <table style="width: 100%;">
                            <div style="position: fixed; background-color: white; margin-top: -50px; width: 400px; float: right; padding-left: 150px">
                            <tr>
                                <td colspan="3">
                                    <asp:Button ID="btnShow" runat="server" Text="Print" Width="100px" /><asp:Button ID="btnClear" runat="server" Text="Clear" Width="100px" />
                                    </td>
                            </tr>
                            </div>
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
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers></Triggers>
    </asp:UpdatePanel>
</asp:Content>
