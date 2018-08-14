<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportVenueForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Organization.MasterPage.ReportVenueForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Panel ID="PanelReportNode" runat="server" Height="430px" Width="450px">
                            <asp:TreeView ID="TreeViewReportNode" runat="server" OnTreeNodePopulate="TreeViewReportNode_TreeNodePopulate" ShowLines="True">
                            </asp:TreeView>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="PanelReportInput" runat="server" Height="430px" Width="450px">
                            <table style="width: 100%;">
                                <tr>
                                    <td colspan="3">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Report"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:Label ID="lblSelectedReport" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Date From"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Date To"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="txtToDate" runat="server" TextMode="Date"></asp:TextBox>
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
                        </asp:Panel>
                    </td>
                    <td style=" width:250px;text-align: right; float: right;padding-left:175px;padding-top:1px;padding-right:1px;">
                        <div style="position: fixed; background-color: white">
                                <table style="width: 100%;">
                                    <tr>
                                        <td><asp:Button ID="btnShow" runat="server" CssClass="CssBtnPrint" Text="" Width="70px" /></td>
                                    </tr>
                                    <tr>
                                        <td><asp:Button ID="btnClear" runat="server" CssClass="CssBtnClear" Text="Clear" Width="70px"  /></td>
                                    </tr>
                                </table>
                            </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers></Triggers>
    </asp:UpdatePanel>
</asp:Content>
