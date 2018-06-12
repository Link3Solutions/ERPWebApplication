<%@ Page Title="Employee Setup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeSetupForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.HRMS.MasterPage.EmployeeSetupForm" %>

<%@ Register src="../../../WebUserControls/OrganizationalChartControl.ascx" tagname="OrganizationalChartControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width:1200px;">
            <table style="width: 100%; text-align: left">
                <tr >
                    <td style="text-align: left; float: left;width:192px">
                        <asp:Panel ID="Panel11" runat="server" Height="100%" Width="190px">
                            <table style="width: 100%; text-align: left">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblImage" runat="server" BorderColor="Black" BorderWidth="0px" Font-Bold="True" Font-Italic="True" Font-Size="Medium" ForeColor="Red" Height="155px" Style="text-align: center; vertical-align: middle" Width="155px"> <br /> Photo
                                             <br />  Not <br />  Available  
                                             
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label98" runat="server" Text="[150X150,  Files are supported]"></asp:Label>
                                                                    <div id="dvMsg" style="background-color: Red; color: White; width: 190px; padding: 3px; display: none;">
                                                                        Maximum size allowed is 500 kb
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:FileUpload ID="ProfileImageUpload" runat="server" Width="190px" CssClass="CssFile_Upload" Height="24px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left; margin-top: -30px">
                                                                    <asp:ImageButton ID="btnEmpPhoto" runat="server" Width="27px" ImageUrl="~/Images/imageup.jpg" Height="12px" OnClick="btnEmpPhoto_Click"  />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="margin-top: -30px">
                                                                    <asp:RegularExpressionValidator ID="RevImg" runat="server" ControlToValidate="ProfileImageUpload" ErrorMessage="Invalid File!(only  .gif, .jpg, .jpeg, .bmp, .png  Files are supported)" ForeColor="Red" ValidationExpression="^.+(.jpg|.JPG|.gif|.GIF|.jpeg|JPEG| .bmp|BMP| .png|PNG)$" Width="100%"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                        </asp:Panel>
                    </td>
                    <td style="text-align: left; float: left;width:375px">
                        <table style="width: 410px;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Employee ID"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtEmployeeID" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Employee Type"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEmployeeType" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Employee Category"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:DropDownList ID="ddlEmployeeCategory" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
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
                                    <asp:Label ID="Label7" runat="server" Text="First Name"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Middle Name"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Last Name"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text="Designation"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:DropDownList ID="ddlDesignationEmployee" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Email"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="User Permission"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:DropDownList ID="ddlUserPermission" runat="server">
                                        <asp:ListItem Selected="True" Value="-1">--- Please Select ---</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                    </asp:DropDownList>
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
                    <td style="text-align: left; float: left;width:275px;padding-left:50px">
                        <table style="width: 100%;">
                            <tr >
                                <td colspan="3">
                                    <div style="margin-top:-25px">
                                    <uc1:OrganizationalChartControl ID="OrganizationalChartControl1" runat="server" />
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
                    </td>
                    <td style=" width:100px;text-align: right; float: right;padding-left:25px;padding-top:1px;padding-right:1px;">
                        <div style="position: fixed; background-color: white">
                            <table style="width: 100%;">
                                <tr>
                                    <td><asp:Button ID="btnSave" runat="server" Text="Save" CssClass="CssBtnSave" Width="70px" OnClick="btnSave_Click" /></td>
                                </tr>
                                <tr>
                                    <td><asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="CssBtnClear"  Width="70px" /></td>
                                </tr>
                                <tr>
                                    <td><asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="CssBtnPrint" Width="70px" /></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnEmpPhoto" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
