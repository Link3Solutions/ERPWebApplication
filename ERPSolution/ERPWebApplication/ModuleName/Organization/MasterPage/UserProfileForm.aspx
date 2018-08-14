<%@ Page Title="User Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfileForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Organization.MasterPage.UserProfileForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width:1200px">
            <table style="width: 100%;">
                <tr>
                    <td colspan="2" style="width:550px;text-align:left;float:left">
                        <table style="width:90%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Title"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:DropDownList ID="ddlTitle" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Full Name"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Email"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="User Profile Type"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:DropDownList ID="ddlUserProfileType" runat="server">
                                        <asp:ListItem Selected="True" Value="-1">--Please Select--</asp:ListItem>
                                        <asp:ListItem Value="1">Employee</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Display Name"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtDisplayName" runat="server"></asp:TextBox>
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
                    </td>
                    <td colspan="2" style=" width:75px;text-align: right; float: right;padding-left:3px;padding-top:1px;padding-right:1px;">
                        <div style="position: fixed; background-color: white">
                            <table style="width: 100%;">
                                <tr>
                                    <td><asp:Button ID="btnSave" runat="server" CssClass="CssBtnSave" Text="Save" Width="70px" OnClick="btnSave_Click" /></td>
                                </tr>
                                <tr>
                                    <td><asp:Button ID="btnClear" runat="server" CssClass="CssBtnClear" Text="Clear" Width="70px" OnClick="btnClear_Click" /></td>
                                </tr>
                                <tr>
                                    <td><asp:Button ID="btnPrint" runat="server" CssClass="CssBtnPrint" Text="" Width="70px" /></td>
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
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
                </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
