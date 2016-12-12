<%@ Page Title="Company Information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompanySetupForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.HRMS.MasterPage.CompanySetupForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 61px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;text-align:left">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Business Nature"></asp:Label>
                    </td>
                    <td colspan="2">:</td>
                    <td>
                        <asp:DropDownList ID="ddlBusinessNature" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="OwnerShip"></asp:Label>
                    </td>
                    <td colspan="2">:</td>
                    <td>
                        <asp:DropDownList ID="ddlOwnerShip" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="Label3" runat="server" Text="Company Address"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="Label4" runat="server" Text="House Information"></asp:Label>
                                </td>
                                <td class="auto-style1">:</td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtHouseInformation" runat="server" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Road Information"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtRoadInformation" runat="server" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="Sector"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtSector" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="2">
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Country"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:DropDownList ID="ddlCountry" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="District"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:DropDownList ID="ddlDistrict" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Area Group"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:DropDownList ID="ddlAreaGroup" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Area"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:DropDownList ID="ddlArea" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Landmark"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtLandmark" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
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
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>

        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
