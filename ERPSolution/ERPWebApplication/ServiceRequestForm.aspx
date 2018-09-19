<%@ Page Title="" Language="C#" MasterPageFile="~/SiteHomePage.Master" AutoEventWireup="true" CodeBehind="ServiceRequestForm.aspx.cs" Inherits="ERPWebApplication.ServiceRequestForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript"></script>   
    <script type="text/javascript">
        $(function () {
            var showChar = 120, showtxt = "more", hidetxt = "less";
            $('.more').each(function () {
                var content = $(this).text();
                if (content.length > showChar) {
                    var con = content.substr(0, showChar);
                    var hcon = content.substr(showChar, content.length - showChar);
                    var txt = con + '<span class="dots">...</span><span class="morecontent"><span>' + hcon + '</span>&nbsp;&nbsp;<a href="" class="moretxt">' + showtxt + '</a></span>';
                    $(this).html(txt);
                }
            });
            $(".moretxt").click(function () {
                if ($(this).hasClass("sample")) {
                    $(this).removeClass("sample");
                    $(this).text(showtxt);
                } else {
                    $(this).addClass("sample");
                    $(this).text(hidetxt);
                }
                $(this).parent().prev().toggle();
                $(this).prev().toggle();
                return false;
            });
        });
</script>
<style type="text/css">

</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr >
                    <td colspan="3"  >
                        <asp:Panel ID="PanelModule" runat="server" Width="100%" Height="115px">
                            <div style="position:fixed;background-color:#29303B; width:100%;height:115px" >
                                <table style="width: 100%;">
                                    <tr>
                                        <td><div style="width:100px;height:100%"></div></td>
                                        <td><div style="width:700px;height:100%">
                                            <asp:Label ID="lblNameoftheModule" runat="server" Text="Name of the Module" Font-Bold="True" Font-Names="Segoe UI Light" Font-Size="22pt"></asp:Label></div></td>
                                        <td><div style="width:300px;height:100%"></div></td>
                                    </tr>
                                    <tr>
                                        <td><div style="width:100px;height:100%"></div></td>
                                        <td><div style="width:700px;height:45px;border:1px solid gray" >
                                            <asp:Repeater ID="RepeaterModuleDescription" runat="server">
                                                <ItemTemplate>
                                                    <%--<div class="more" style="width:685px;background:#FFFFFF" >--%>
                                                    <div >
                                                        <%# DataBinder.Eval(Container.DataItem, "PackageDescription")%>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            </div></td>
                                        <td><div style="width:450px;height:100%;">
                                            <ol style="list-style-type: none;margin-top:-25px;height:65px;padding-top:5px;margin-left:1px">
                                                <li>
                                                    <asp:Label ID="Label25" runat="server" Text=""></asp:Label></li> 
                                                <li>
                                                                        <asp:Label ID="Label21" runat="server" Text="- Full lifetime access | Articles | Learning Materials"></asp:Label></li>
                                                <li>
                                                    <asp:Label ID="Label22" runat="server" Text="- "></asp:Label></li>
                                                <li>
                                                <asp:Label ID="lblTotalTitle" Width="220px" runat="server" Text="Total"></asp:Label><asp:Label ID="lblTotalVale" Width="75px" Style="text-align: right;" runat="server" Text=""></asp:Label>&nbsp;&nbsp;<asp:Button ID="btnPlaceOrder" runat="server" CssClass="CssBtnSave" Text="Place Order" Width="100px" OnClick="btnPlaceOrder_Click" />    
                                                </li>
                                            </ol>
                                            </div></td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="width:100px;height:100%"></div>

                    </td>
                    <td>
                        <div style="width:700px;height:100%">
                            <table style="width: 100%;">
                                <tr>
                                    <td colspan="3">
                                        <asp:Panel ID="PanelSubModuleLogo" runat="server" Height="65px">
                                             <asp:Repeater ID="RepeaterServices" runat="server" >
                                                <ItemTemplate >
         <div class="serviceAreaDIV" style="padding:10px;float:left; width:110px; text-align:left; background-color:White;border:1px solid black;padding-right :10px;padding-top :10px;margin-left:10px;margin-bottom:10px" onmouseover="this.style.background='#4cabd7';" onmouseout="this.style.background='white';" >
             <div  style="width:15px;height:15px;background-image: url('<%#"data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("ServiceLogo")) %>');"> <asp:Label ID="lblStatusAdded" ForeColor="Green" Visible="false" CssClass="labelasHeader2" runat="server" Text="ADDED"></asp:Label></div>
             <div><asp:Label ID="lblServiceName" runat="server"  Text='<%# Eval("ServiceName") %>' ></asp:Label></div>
             <div style="height:10px;text-align:right">
                 <asp:Label ID="lblServiceIDReapeter" runat="server" Visible="false" Text='<%# Eval("ServiceID") %>' ></asp:Label><asp:LinkButton ID="lnkbtnServiceDetails" OnClick="GetValue" Font-Underline="False" CssClass="logoutHover" BackColor="White" Font-Size="Small" runat="server">Details...</asp:LinkButton>
             </div>
         </div>
         </ItemTemplate> 
          <SeparatorTemplate>
          </SeparatorTemplate>
          <FooterTemplate>
          </FooterTemplate>
                                            </asp:Repeater>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Panel ID="PanelModuleDescription" runat="server">
                                            <div style="text-align: left;width: 700px;display: inline-block;border-bottom: 1px solid #808080;padding-bottom:3px">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td><asp:Label ID="lblServiceDescription" runat="server" CssClass="labelasHeader2" Width="270px" Text="Description"></asp:Label></td>
                                                        <td ><asp:Label ID="lblPreviousPrice" CssClass="labelasHeader2" runat="server" style="text-align:right" BackColor="Black" Width="120px" ForeColor="White" Font-Overline="False" Font-Strikeout="True" ></asp:Label></td>
                                                        <td><asp:Label ID="lblPrice" CssClass="labelasHeader2" style="text-align:right" runat="server" BackColor="Black" Width="120px" ForeColor="White" ></asp:Label></td>
                                                        <td><asp:Button ID="btnTakeService" runat="server" CssClass="CssBtnAddNew" Text="Take This Service" Width="170px" OnClick="btnTakeService_Click" /></td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div style="overflow:auto; height:260px;text-align: left;width: 700px;display: inline-block">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:Repeater ID="RepeaterServiceDescription" runat="server">
                                                                <ItemTemplate>
                                                                    <div style="width:99%;height:99%">
                                                                    <%# DataBinder.Eval(Container.DataItem, "ServiceDescription")%>
                                                                        </div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:Repeater ID="RepeateNodeCollection" runat="server">
                                                                <ItemTemplate>
                                                                    <div>
                                                                    <div style="width:99%;height:30px">
                                                                    <%# DataBinder.Eval(Container.DataItem, "ActivityName")%>
                                                                        </div>
                                                                    <div style="width:99%;height:100%">
                                                                    <%# DataBinder.Eval(Container.DataItem, "FormDescription")%>
                                                                        </div>
                                                                        </div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div style="overflow:auto; height:2px;text-align: left;width: 700px;display: inline-block"></div>
                                            <div style="overflow:auto; text-align: left;width: 690px;display: inline-block;padding-left:10px;border:1px solid gray;padding-top:3px;padding-bottom:3px;">
                                                Other Packages
                                            </div>
                                            <div style="overflow:auto; height:125px;text-align: left;width: 700px;display: inline-block"></div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Panel ID="PanelUserAccount" runat="server" Height="250px" CssClass="CssPanelUserAccount">
                                            <table style="width: 58%;margin-left:150px;margin-right:150px">
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" Text="Sign in" Font-Size="14pt" ForeColor="#333333" Width="200px"></asp:Label>
                                                    </td>
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
                                                        <asp:Label ID="Label3" runat="server" Text="New to Here ?" CssClass="CssPlaceOrderText"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label5" runat="server" Text="Have an account?" CssClass="CssPlaceOrderText"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" Text="Create an account now." CssClass="CssPlaceOrderText"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server" Text="Sign in now." CssClass="CssPlaceOrderText"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnCreateAccount" runat="server" CssClass="CssBtnRegister" Text="Create Account" Width="150px" OnClick="btnCreateAccount_Click" Height="30px" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSigninPanel" runat="server" CssClass="CssBtnLogin" Text="Sign in" Width="150px" OnClick="btnSigninPanel_Click" Height="30px" />
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:CheckBox runat="server" ID="CheckBox1" />
                                                                        <asp:Label ID="Label27" runat="server" AssociatedControlID="CheckBoxTerms" CssClass="checkbox">I have read and accept the</asp:Label><asp:LinkButton ID="LinkButton2" runat="server" CssClass="forgotPassword">Terms &amp; Conditions</asp:LinkButton>
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
                                <tr >
                                    <td colspan="3" >
                                        <asp:Panel ID="PanelCreateAccount" runat="server" CssClass="CssLoginPanel"  >
                                             <table style="width: 100%;margin-top:-12px">
                                                  <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                 <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                     <td>
                                                         <asp:Label ID="Label7" runat="server" CssClass="CssSigninText" Text="Create Account"></asp:Label>
                                                         &nbsp;&nbsp;<asp:Label ID="Label20" runat="server" ForeColor="#CCCCCC" Text="|"></asp:Label>
                                                         &nbsp;<asp:LinkButton ID="lnkbtnSignIn" runat="server" BackColor="Transparent" CssClass="logoutHover" Font-Size="12pt" Font-Underline="False" ForeColor="#0E9ED6" OnClick="lnkbtnSignIn_Click">Sign in</asp:LinkButton>
                                                     </td>
                                                    <td>&nbsp;</td>
                                                     <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr  >
                                                    <td>
                                                        &nbsp;</td>
                                                    <td colspan="4">
                                                        <div style="height:35px">
                                                            <asp:Label ID="Label8" runat="server" CssClass="lineCreateAccount" Text="Enter your company information" Width="710px"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                               
                                                 <tr>
                                                     <td>
                                                         &nbsp;</td>
                                                     <td>
                                                         <asp:Label ID="Label9" runat="server" ForeColor="#333333" Text="Name" Width="330px"></asp:Label>
                                                     </td>
                                                     <td>&nbsp;</td>
                                                     <td style="padding-left:5px">
                                                         <asp:Label ID="Label10" runat="server" ForeColor="#333333" Text="Email Address" Width="335px"></asp:Label>
                                                     </td>
                                                     <td>&nbsp;</td>
                                                 </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:TextBox ID="txtCompanyName" runat="server" placeholder="Your Company Name" Width="330px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td colspan="2" style="text-align:right">
                                                        <asp:TextBox ID="txtCompanyEmail" runat="server" placeholder="Email Address" Width="340px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                 <tr >
                                                    <td>
                                                        &nbsp;</td>
                                                     <td colspan="4">
                                                         <div style="height:35px;padding-top:10px">
                                                             <asp:Label ID="Label11" runat="server" CssClass="lineCreateAccount" Text="Enter User Information" Width="710px"></asp:Label>
                                                         </div>
                                                     </td>
                                                </tr>
                                                
                                                 <tr>
                                                     <td>
                                                         &nbsp;</td>
                                                     <td>
                                                         <asp:Label ID="Label12" runat="server" ForeColor="#333333" Text="Title" Width="70px"></asp:Label>
                                                         <asp:Label ID="Label13" runat="server" ForeColor="#333333" Text="Name" Width="255px"></asp:Label>
                                                     </td>
                                                     <td>&nbsp;</td>
                                                     <td style="padding-left:5px">
                                                         <asp:Label ID="Label14" runat="server" ForeColor="#333333" Text="Email Address" Width="335px"></asp:Label>
                                                     </td>
                                                     <td>&nbsp;</td>
                                                 </tr>
                                                <tr>
                                                    <td aria-orientation="vertical">
                                                        &nbsp;</td>
                                                    <td aria-orientation="vertical">
                                                        <asp:DropDownList ID="ddlUserTitle" runat="server" Width="70px">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtUserName" runat="server" placeholder="Your Name" Width="255px"></asp:TextBox>
                                                    </td>
                                                    <td style="text-align:right">
                                                        &nbsp;</td>
                                                    <td style="text-align:right" colspan="2">
                                                        <asp:TextBox ID="txtUserEmail" runat="server" placeholder="Email Address" Width="340px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td colspan="4">
                                                        <asp:CheckBox ID="CheckBoxTerms" runat="server" />
                                                        <asp:Label ID="Label16" runat="server" AssociatedControlID="CheckBoxTerms" CssClass="checkbox">I have read and accept the</asp:Label>
                                                        <asp:LinkButton ID="LinkButton3" runat="server" CssClass="forgotPassword">Terms &amp; Conditions</asp:LinkButton>
                                                        <asp:Label ID="Label17" runat="server" Text="and"></asp:Label>
                                                        <asp:LinkButton ID="LinkButton4" runat="server" CssClass="forgotPassword">Privacy &amp; Cookies Policy</asp:LinkButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td colspan="4">
                                                        <asp:Button ID="btnSubmitRequest" runat="server" CssClass="CssBtnRegister" Text="Submit Request" Width="150px" />
                                                        <asp:Label ID="Label15" runat="server" Text="You will receive security code in your email address"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                             </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Panel ID="PanelUserLogin" runat="server">
                                            <asp:Panel ID="PanelLoginControl" runat="server" Width="435px" CssClass="CssLoginPanel" >
                                                    <table style="width: 100%;margin-top:-15px">
                                                        <tr>
                                                            <td colspan="3">
                                                                <ol style="list-style-type:none">
                                                                    <li>
                                                                        <asp:Label ID="Label24" runat="server" Text="Sign in" CssClass="CssSigninText"></asp:Label>&nbsp;&nbsp;<asp:Label ID="Label26" runat="server" Text="|" ForeColor="#CCCCCC"></asp:Label>&nbsp;<asp:LinkButton ID="lnkbtnCreateAccount" runat="server" Font-Underline="False" CssClass="logoutHover" BackColor="Transparent" OnClick="lnkbtnCreateAccount_Click">Create Account</asp:LinkButton>
                                                                    </li>
                                                                </ol>
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <ol style="list-style-type: none">
                                                                    <li>
                                                                        <asp:Label ID="Label18" runat="server" AssociatedControlID="txtLoginUserName" CssClass="labelView">User name</asp:Label>
                                                                        <asp:TextBox runat="server" Height="18px" ID="txtLoginUserName" />&nbsp;<asp:LinkButton ID="lnkbtnCompany" runat="server"  Font-Underline="false" CssClass="nextHover" Height="15px" Width="85px">Next</asp:LinkButton>
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
                                                                <asp:Label ID="lblRememberMe" runat="server" AssociatedControlID="RememberMe" Width="110px" CssClass="checkbox">Remember me?</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnLogin" runat="server" CssClass="CssBtnLogin"  Text="Log in" Width="100px" />
                                                            </td>
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
                                                                <asp:Label ID="Label19" runat="server" Text="* Your user name and password were selected by you during account registration." Width="350px"></asp:Label>
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
                                                    <li><asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="False" CssClass="forgotPassword">Forgot password?</asp:LinkButton></li>
                                                </ol>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td style="vertical-align:top">
                        <div style="width:400px;height:100%;vertical-align:top">
                            <asp:Panel ID="PanelSelectedServices" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td colspan="3">
                                            <asp:GridView ID="grdSelectedServices" runat="server" Width="399px" AutoGenerateColumns="False" OnRowDataBound="grdSelectedServices_RowDataBound" OnRowCommand="grdSelectedServices_RowCommand" OnRowDeleting="grdSelectedServices_RowDeleting">
                                                <Columns>
                                                    <%--<asp:TemplateField HeaderText="SL">
                                        <ItemTemplate>
                                            <%# Container.DisplayIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                                    <%--<asp:TemplateField>
                                                        <ItemTemplate>
                                                        <div  style="width:15px;height:15px;background-image: url('<%#"data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("colServiceLogo")) %>');"></div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Service">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label29" Width="290px" runat="server" Text='<%# Bind("colServiceName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Value">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcolServiceValue" runat="server" Text='<%# Eval("colServiceValue","{0:N2}") %>' Width="75px" Style="text-align: right;" ></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ServiceID">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcolServiceID" Width="15px" runat="server" Text='<%# Bind("colServiceID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ShowDeleteButton="True" ControlStyle-Width="15px" ControlStyle-Height="15px" ControlStyle-BorderStyle="None" DeleteImageUrl="~/Images/RemoveServices.png" ButtonType="Image" >
                                                    <ControlStyle BorderStyle="None" Height="15px" Width="15px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:CommandField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSelectedSerciceID" Visible="false" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers></Triggers>
    </asp:UpdatePanel>
</asp:Content>
