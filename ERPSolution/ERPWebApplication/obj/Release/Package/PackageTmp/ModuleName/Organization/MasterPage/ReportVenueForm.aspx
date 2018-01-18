<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportVenueForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Organization.MasterPage.ReportVenueForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="PanelReportNode" runat="server" Height="450px" Width="450px">
                            <asp:TreeView ID="TreeViewReportNode" runat="server" OnTreeNodePopulate="TreeViewReportNode_TreeNodePopulate" ShowLines="True">
                            </asp:TreeView>
                        </asp:Panel>
                    </td>
                    <td colspan="2">
                        <asp:Panel ID="PanelReportInput" runat="server" Height="450px" Width="450px">
                        </asp:Panel>
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
