<%@ Page Title="User Permission" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPermissionForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Organization.MasterPage.UserPermissionForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <ajaxToolkit:TabContainer ID="TabContainerUserPermission" runat="server" Width="100%" Height="100%" ActiveTabIndex="0">
                            <ajaxToolkit:TabPanel ID="TabPanelRoleSetup" runat="server" HeaderText="Role Setup">
                                <ContentTemplate>
                                    <table style="width:100%;">
                                        <tr>
                                            <td style="text-align: left; float: left; width: 500px">
                                                <div style="overflow:auto; height:450px;">
                                                <asp:TreeView ID="TreeViewAllNode" runat="server" OnTreeNodePopulate="TreeViewAllNode_TreeNodePopulate" ShowCheckBoxes="All">
                                                </asp:TreeView>
                                                    </div>
                                            </td>
                                            <td style="text-align: left; float: left; width: 435px">
                                                <table style="width:100%;">
                                                    <tr>
                                                        <td colspan="3">
                                                            <div style="position: fixed; width: 425px; background-color: #00817F; height: 50px">
                                                                <table style="width: 50%;">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Button ID="btnRoleSave" runat="server" Width="100px" Text="Save" /></td>
                                                                        <td>
                                                                            <asp:Button ID="btnRoleClear" runat="server" Width="100px" Text="Clear" /></td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                </table>
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
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text="Role Title"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtRoleTitle" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:GridView ID="GridViewRoles" runat="server" Width="100%">
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanelUserPermission" runat="server" HeaderText="User Permission">
                                <ContentTemplate>
                                    <table style="width:100%;">
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
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                        </ajaxToolkit:TabContainer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers></Triggers>
    </asp:UpdatePanel>
</asp:Content>
