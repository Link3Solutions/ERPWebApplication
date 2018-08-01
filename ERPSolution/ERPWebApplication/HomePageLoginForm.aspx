<%@ Page Language="C#" Title="Home Page" AutoEventWireup="true" MasterPageFile="~/SiteHomePage.Master" CodeBehind="HomePageLoginForm.aspx.cs" Inherits="ERPWebApplication.HomePageLoginForm" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                            <td>
                                <asp:Panel ID="PanelLogin" runat="server">
                                    <table style="width: 100%;">
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
                                                <asp:Panel ID="Panel2" runat="server" Width="385px"></asp:Panel>
                                            </td>
                                            <td>
                                                <asp:Panel ID="PanelLoginControl" runat="server" Width="435px" CssClass="CssLoginPanel" >
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td colspan="3">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <ol style="list-style-type:none">
                                                    <li><asp:Label ID="Label24" runat="server"  Text="Sign in" CssClass="CssSigninText"></asp:Label>&nbsp;&nbsp;<asp:Label ID="Label20" runat="server" Text="|" ForeColor="#CCCCCC"></asp:Label>&nbsp;<asp:LinkButton ID="lnkbtnCreateAccount" runat="server" Font-Underline="False" CssClass="logoutHover" BackColor="Transparent" OnClick="lnkbtnCreateAccount_Click" >Create Account</asp:LinkButton></li>
                                                </ol>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3"></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <ol style="list-style-type: none">
                                                                    <li>
                                                                        <asp:Label ID="Label5" runat="server" AssociatedControlID="txtLoginUserName" CssClass="labelView">User name</asp:Label>
                                                                        <asp:TextBox runat="server" Height="18px" ID="txtLoginUserName" />&nbsp;<asp:LinkButton ID="lnkbtnCompany" runat="server" OnClick="lnkbtnCompany_Click" Font-Underline="false" CssClass="nextHover" Height="15px" Width="85px">Next</asp:LinkButton>
                                                                    </li>
                                                                    <li style="padding-left: 170px"></li>
                                                                    <li></li>
                                                                    <li>
                                                                        <asp:Label ID="lblCompanyText" runat="server" AssociatedControlID="ddlCompany" CssClass="labelView">Company</asp:Label>
                                                                        <asp:DropDownList ID="ddlCompany" runat="server"></asp:DropDownList>
                                                                    </li>
                                                                    <li>
                                                                        <asp:Label ID="lblLoginPassword" runat="server" AssociatedControlID="txtLoginPassword" CssClass="labelView">Password</asp:Label>
                                                                        <asp:TextBox runat="server" ID="txtLoginPassword" TextMode="Password" />
                                                                    </li>
                                                                </ol>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 40px">
                                                                <asp:CheckBox ID="RememberMe" runat="server" />
                                                                <asp:Label ID="lblRememberMe" runat="server" AssociatedControlID="RememberMe" Width="110px" CssClass="checkbox">Remember me?</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnLogin" runat="server" CssClass="CssBtnLogin" OnClick="btnLogin_Click" Text="Log in" Width="100px" />
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 40px">&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 40px"></td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 40px">
                                                                <asp:Label ID="Label9" runat="server" Text="* Your user name and password were selected by you during account registration." Width="350px"></asp:Label>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 40px">&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td >
                                                                <ol style="list-style-type:none">
                                                    <li><asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="False" BackColor="Transparent" CssClass="forgotPassword">Forgot password?</asp:LinkButton></li>
                                                </ol>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 40px">&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                            <td>
                                                <asp:Panel ID="Panel3" runat="server" Width="385px"></asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                         </table>

                                </asp:Panel>
                            </td>
                        </tr>
                    <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Content>
    

