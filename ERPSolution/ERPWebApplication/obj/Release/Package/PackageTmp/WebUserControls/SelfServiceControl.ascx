<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SelfServiceControl.ascx.cs" Inherits="ERPWebApplication.WebUserControls.SelfServiceControl" %>
<table style="width: 100%;">
    <tr>
        <td colspan="3">
            <asp:GridView ID="grdFormDashboard" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="grdFormDashboard_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Self Service">
                        <ItemTemplate>
                            <asp:Label ID="lblFormName" runat="server" Text='<%# Bind("ActivityName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FormLink" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblFormLink" runat="server" Text='<%# Bind("FormName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
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
