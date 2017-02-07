<%@ Page Title="Organizational Chart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrganizationalChartForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.HRMS.MasterPage.OrganizationalChartForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%; text-align: left">
                <tr>
                    <td colspan="3">
                        <ajaxToolkit:TabContainer ID="TabContainerOrgChart" Height="100%" Width="100%" runat="server" ActiveTabIndex="0">
                            <ajaxToolkit:TabPanel runat="server" HeaderText="Organization Elements" ID="TabPanel1">
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label>
                                            </td>
                                            <td>:</td>
                                            <td>
                                                <asp:DropDownList ID="ddlCompany" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td rowspan="2" style="text-align: right; float: right;width:435px">
                                                <div style="position: fixed; width: 425px; background-color: #00817F; height: 50px">
                                                    <table style="width: 70%; margin-left: 5px">
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btnSave" runat="server" Text="Save" Width="100px" OnClick="btnSave_Click" /></td>
                                                            <td>
                                                                <asp:Button ID="btnClear" runat="server" Text="Clear" Width="100px" /></td>
                                                            <td>
                                                                <asp:Button ID="btnPrint" runat="server" Text="Print" Width="100px" /></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="Elements" Font-Underline="False"></asp:Label>
                                            </td>
                                            <td>:</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:ListBox ID="ListBoxStandardOrgElements" runat="server" Height="300px" Width="500px"></asp:ListBox>
                                                        </td>
                                                        <td>
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnForword" runat="server" Text="&gt;" Width="25px" OnClick="btnForword_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnForwordAll" runat="server" Text="&gt;&gt;" Width="25px" OnClick="btnForwordAll_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnBack" runat="server" Text="&lt;" Width="25px" OnClick="btnBack_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnBackAll" runat="server" Text="&lt;&lt;" Width="25px" OnClick="btnBackAll_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <asp:ListBox ID="ListBoxOrganizationElements" runat="server" Height="300px" Width="500px" AutoPostBack="True"></asp:ListBox>
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
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Organizational Chart Setup">
                            </ajaxToolkit:TabPanel>
                        </ajaxToolkit:TabContainer></td>
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
        <Triggers></Triggers>
    </asp:UpdatePanel>
</asp:Content>
