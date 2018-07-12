<%@ Page Language="C#" Title="Home Page" AutoEventWireup="true" MasterPageFile="~/SiteHomePage.Master" CodeBehind="HomePageRegisterForm.aspx.cs" Inherits="ERPWebApplication.HomePageRegisterForm" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                            <td>
                                <asp:Panel ID="PanelRegister" runat="server" Height="550px">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="Panel1" runat="server" Width="200px" Height="550px"></asp:Panel>
                                            </td>
                                            <td>
                                                <asp:Panel ID="PanelRegisterControl" runat="server" Width="600px" Height="550px" CssClass="lineRegistration">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td class="auto-style1">
                                                                <ol style="list-style-type: none">
                                                                    <li>
                                                                        <asp:Label ID="Label1" runat="server" AssociatedControlID="txtUserName" Text="User name: <font color='red'>*</font>" CssClass="labelView"> </asp:Label>
                                                                        <asp:TextBox runat="server" Height="18px" ID="txtUserName" />
                                                                    </li>
                                                                    <li>
                                                                        <asp:Label ID="Label3" runat="server" AssociatedControlID="txtPassword" CssClass="labelView" Text="Password: <font color='red'>*</font>"></asp:Label>
                                                                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" />
                                                                    </li>
                                                                    <li>
                                                                        <asp:Label ID="Label4" runat="server" AssociatedControlID="txtConfirmPassword" CssClass="labelView" Text="Confirm password: <font color='red'>*</font>"></asp:Label>
                                                                        <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" />
                                                                    </li>
                                                                    <li>
                                                                        <asp:Label ID="Label2" runat="server" AssociatedControlID="txtSecurityCode" CssClass="labelView" Text="Security Code: <font color='red'>*</font>"></asp:Label>
                                                                        <asp:TextBox runat="server" Height="18px" ID="txtSecurityCode" />
                                                                    </li>
                                                                    <li>
                                                                        <asp:Label ID="Label7" runat="server" AssociatedControlID="txtEmail" CssClass="labelView" Text="Email: <font color='red'>*</font>"></asp:Label>
                                                                        <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" />
                                                                    </li>
                                                                    <li>
                                                                        <asp:Label ID="Label12" Height="10px" runat="server" Text="" Visible="true"></asp:Label></li>
                                                                    <li>
                                                                        <asp:CheckBox runat="server" ID="CheckBoxTerms" />
                                                                        <asp:Label ID="Label6" runat="server" AssociatedControlID="CheckBoxTerms" CssClass="checkbox">I have read and accept the</asp:Label><asp:LinkButton ID="LinkButton3" runat="server" CssClass="forgotPassword">Terms &amp; Conditions</asp:LinkButton><asp:Label ID="Label10" runat="server" Text="and"></asp:Label><asp:LinkButton ID="LinkButton4" runat="server" CssClass="forgotPassword">Privacy &amp; Cookies Policy</asp:LinkButton>
                                                                    </li>
                                                                    <li >
                                                                        <asp:Label ID="Label13" runat="server" Visible="true" ></asp:Label></li>
                                                                    <li style="padding-top:5px">
                                                                        <asp:CheckBox runat="server" ID="CheckBoxNewsletter" />
                                                                        <asp:Label ID="Label11" runat="server" AssociatedControlID="CheckBoxNewsletter" CssClass="checkbox">I agree to receive a monthly newsletter</asp:Label>
                                                                    </li>
                                                                </ol>
                                                            </td>
                                                            <td class="auto-style1"></td>
                                                            <td class="auto-style1"></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 40px">
                                                                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="CssBtnRegister" Width="100px" OnClick="btnRegister_Click" /></td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                            <td>
                                                <asp:Panel ID="Panel4" runat="server" Width="100%" Height="550px">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td colspan="3">
                                                                <%--<p class="message-info" style="color: #7ac0da; margin-left: 40px">--%>
                                                                <p  style="color: #7ac0da; margin-left: 40px;font-size:large">
                                                                    Passwords are required to be a minimum of <%: Membership.MinRequiredPasswordLength %> characters in length.
                                                                </p>
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
                                                </asp:Panel>
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
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Content>
    

