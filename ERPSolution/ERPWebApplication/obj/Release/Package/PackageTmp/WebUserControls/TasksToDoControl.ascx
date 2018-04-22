<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TasksToDoControl.ascx.cs" Inherits="ERPWebApplication.WebUserControls.TasksToDoControl" %>
<asp:Panel ID="Panel1" runat="server">
<table style="width: 100%;">
    <tr>
        <td colspan="3">
            <div style="background-color:#E5E6E3">
                <asp:Label ID="lblTaskstodo" runat="server" Font-Bold="True" Text="Tasks to do"></asp:Label>
            </div>
            </td>
    </tr>
    <tr>
        <td>
            <asp:LinkButton ID="lnkLeaveApplication" runat="server" Font-Underline="False"></asp:LinkButton>
        </td>
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
