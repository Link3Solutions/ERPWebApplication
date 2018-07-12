<%@ Page Language="C#" Title="Home Page" AutoEventWireup="true" CodeBehind="HomePageForm.aspx.cs" Inherits="ERPWebApplication.HomePageForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/WebUserControls/FooterContentControl.ascx" TagPrefix="uc1" TagName="FooterContentControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title><%: Page.Title %>- ERP Web Application</title>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <meta name="viewport" content="width=device-width" />


    <link href="CSS/CSSstyleTheme/Control/CommandButton.css" rel="stylesheet" />
    <link href="CSS/CSSstyleTheme/CommonCSS/Tree.css" rel="stylesheet" />
    <link href="CSS/GridViewCSS.css" rel="stylesheet" />
    <link href="CSS/StyleSheetGridView.css" rel="stylesheet" />
    <link href="CSS/menuStyle.css" rel="stylesheet" />
    <link href="CSS/StyleSheetSpecial.css" rel="stylesheet" />
    
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                alert("Please Enter Only Numeric Value:");
                return false;
            }
            return true;
        }

    </script>

    <style type="text/css">
        .auto-style1 {
            height: 222px;
        }

        .labelView {
            font-family: Tahoma;
            font-size: 0.9em;
            font-weight: normal;
            color: #606163;
            text-align: left;
            padding-top: 5px;
            padding-bottom: 5px;
        }
    </style>

</head>

<body>
    <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Scripts>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="jquery.ui.combined" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>

        </asp:ScriptManager>
        <header>
            <div id="container" style="width: 100%; height: 100px; position: fixed; background-color: #fff; border-top: solid 10px #000">
                <div id="div1">
                    <div style="float: left">
                        <asp:ImageButton ID="ImageButtonLogo" runat="server" ImageUrl="~/Images/logo_120_100.png" OnClick="ImageButtonLogo_Click" Height="50px" Width="70px" />
                    </div>
                    <div style="float: left; padding-left: 60px; margin-top: 31px">
                    </div>
                    <div style="float: right; padding-right: 10px">
                        <div class="content-wrapper">
                            <section style="padding-top: 15px" id="login">
                                <asp:LinkButton ID="lnkbtnAbout" runat="server" Font-Underline="False" CssClass="logoutHover" BackColor="White" OnClick="lnkbtnAbout_Click">About</asp:LinkButton><asp:LinkButton ID="lnkbtnContactUs" runat="server" Font-Underline="False" CssClass="logoutHover" BackColor="White" OnClick="lnkbtnContactUs_Click">Contact us</asp:LinkButton><asp:LinkButton ID="lnkbtnRegister" runat="server" Font-Underline="False" CssClass="logoutHover" BackColor="White" OnClick="lnkbtnRegister_Click">Register</asp:LinkButton><asp:LinkButton ID="lnkbtnLogin" runat="server" Font-Underline="False" CssClass="logoutHover" BackColor="White" OnClick="lnkbtnLogin_Click">Log in</asp:LinkButton>
                            </section>
                        </div>
                    </div>
                </div>

                <br />
                <br />
                <br />
                <br />

                <div id="div12">
                    <section class="featured">
                        <div class="content-wrapperHeader" style="height: 24px">
                            <hgroup class="title">
                                <h2 style="font-size: 1.1em;"></h2>
                            </hgroup>
                        </div>
                    </section>
                </div>
            </div>

        </header>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="body" style="padding-top: 98px; width: 100%; min-height: 470px">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Panel ID="PanelHomePart" runat="server">
                                    <div id="div5" >
                                        <section class="featured" >
                                            <div class="content-wrapperBody" style="min-height: 400px;">
                                                <asp:Panel ID="Panel8" runat="server" Width="100%">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="Panel5" runat="server" Width="200px"></asp:Panel>
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="Panel6" runat="server" Width="600px">
                                                                <table style="width: 100%;">
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            
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
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="Panel7" runat="server" Width="100%"></asp:Panel>
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
                                                    </asp:Panel>
                                            </div>
                                        </section>
                                    </div>
                                    <section class="featured">
                                        <div id="div7" class="content-wrapperBodyPart2" style="min-height: 400px;padding-top:30px;padding-bottom:30px">
                                            <div class="col-lg-4 col-tb-4 col-sm-3 item" style="display: inline-block" >
                                                <h2 style="color:white" >Link3 <b>Live:</b> Latest Service Updates</h2>
                                            </div>
                                            <div class="col-lg-4 col-tb-4 col-sm-3 item" style="display: inline-block">
                                                <a class="box blog" href="HomePageForm.aspx">
                                                    <div class="image"
                                                        style="background-image: url('https://www.parcl.com/files/live/sleepingcatstatue.jpg?s=product-catalog');">
                                                    </div>
                                                    <div class="info">
                                                        <b>Shopping Ideas</b>
                                                        <p class="lead">Top-10 Items Delivered Internationally This Week</p>
                                                    </div>
                                                </a>
                                            </div>
                                            <div class="col-lg-4 col-tb-4 col-sm-3 item" style="display: inline-block">
                                                <a class="box blog" href="HomePageForm.aspx">
                                                    <div class="image"
                                                        style="background-image: url('https://www.parcl.com/files/live/whatyoucanshipwithparcl.jpg?s=huge');">
                                                    </div>
                                                    <div class="info">
                                                        <b>Shopping Ideas</b>
                                                        <p class="lead">Top-10 Items Delivered Internationally This Week</p>
                                                    </div>
                                                </a>
                                            </div>
                                            <div class="col-lg-4 col-tb-4 col-sm-3 item" style="display: inline-block">
                                                <a class="box blog" href="HomePageForm.aspx">
                                                    <div class="image"
                                                        style="background-image: url('https://www.parcl.com/files/live/whatyoucanshipwithparcl.jpg?s=huge');">
                                                    </div>
                                                    <div class="info">
                                                        <b>Shopping Ideas</b>
                                                        <p class="lead">Top-10 Items Delivered Internationally This Week</p>
                                                    </div>
                                                </a>
                                            </div>
                                        </div>
                                    </section>
                                    <div id="div6" style="min-height: 400px;">
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
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>

                            </td>

                        </tr>
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
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <h2 style="color: #7ac0da">Use an account to log in.</h2>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="Panel2" runat="server" Width="385px"></asp:Panel>
                                            </td>
                                            <td>
                                                <asp:Panel ID="PanelLoginControl" BorderStyle="Solid" BorderWidth="1px" BorderColor="#9E9E9E" runat="server" Width="435px">
                                                    <table style="width: 100%;">
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
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td style="text-align: center">
                                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="forgotPassword">Forgot password?</asp:LinkButton>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td style="text-align: center">
                                                <asp:Label ID="Label8" runat="server" Text="Don't have an account yet?"></asp:Label>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="forgotPassword"> Sign up now!</asp:LinkButton>
                                            </td>
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
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="PanelContactus" runat="server"></asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="PanelAbout" runat="server"></asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </div>
                <footer style="height: 275px; background-color: #525252">
                    <div class="content-wrapper">
                        <uc1:FooterContentControl runat="server" ID="FooterContentControl" />
                    </div>
                    <div class="content-wrapper">
                        <div class="float-left">
                            <p style="color: #A2AEAE">&copy; <%--<li><a id="registerLink" runat="server" href="~/Account/Register.aspx">Register</a></li>--%>- My ASP.NET Application</p>
                        </div>
                    </div>
                </footer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
