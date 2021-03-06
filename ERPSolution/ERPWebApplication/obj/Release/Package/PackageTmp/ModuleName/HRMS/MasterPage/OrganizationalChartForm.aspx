﻿<%@ Page Title="Organizational Chart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrganizationalChartForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.HRMS.MasterPage.OrganizationalChartForm" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%; text-align: left">
                <tr>
                    <td colspan="3">
                        <ajaxToolkit:TabContainer ID="TabContainerOrgChart" Height="100%" Width="1160px" runat="server" ActiveTabIndex="1" CssClass="tab" CssTheme="None" EnableTheming="True" ToolTip="Organizational Chart">

                            <ajaxToolkit:TabPanel runat="server" HeaderText="Organization Elements" ID="TabPanel1">
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label>
                                            </td>
                                            <td>:</td>
                                            <td>
                                                <asp:DropDownList ID="ddlCompany" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td rowspan="2" style="text-align: right; float: right; width: 435px">
                                                
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
                                                        <td style="width:363px">
                                                            <asp:ListBox ID="ListBoxStandardOrgElements" runat="server" Height="300px" Width="358px"></asp:ListBox>
                                                        </td>
                                                        <td style="width:30px">
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td>
                                                                        <asp:ImageButton ID="imgbtnForword" runat="server"  Width="17px" Height="17px" ImageUrl="~/Images/forward.png" OnClick="imgbtnForword_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:ImageButton ID="imgbtnForwordAll" runat="server" OnClick="imgbtnForwordAll_Click" Width="17px" Height="17px" ImageUrl="~/Images/forwardAll.png" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:ImageButton ID="imgbtnBack" runat="server" Width="17px" Height="17px" ImageUrl="~/Images/backward.png" OnClick="imgbtnBack_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:ImageButton ID="imgbtnBackAll" runat="server" Width="17px" Height="17px" ImageUrl="~/Images/backwardAll.png" OnClick="imgbtnBackAll_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="width:363px">
                                                            <asp:ListBox ID="ListBoxOrganizationElements" runat="server" Height="300px" Width="358px" AutoPostBack="True"></asp:ListBox>
                                                        </td>
                                                        <td style="float:left">
                                                            <div style="width:370px;position:fixed;">
                                                                <table style="margin-left:270px">
                                                                    <tr><td><asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" CssClass="CssBtnSave" OnClick="btnSave_Click" /></td></tr>
                                                                    <tr><td><asp:Button ID="btnClear" runat="server" Text="Clear" Width="70px" CssClass="CssBtnClear" OnClick="btnClear_Click" /></td></tr>
                                                                    <tr><td><asp:Button ID="btnPrint" runat="server" Text="" Width="70px" CssClass="CssBtnPrint" /></td></tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Organizational Chart Setup" Width="1160px">
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr style="border-bottom: 1px solid gray">
                                            <td  style="text-align: left; float: left; width: 500px">
                                                <div class="showinfo" style="height:32px;width:500px;margin-top:-15px"><asp:Button ID="btnAddNew" runat="server" CssClass="CssBtnAddNew" Text="Add New" Width="100px" OnClick="btnAddNew_Click" /><asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="CssBtnUpdate" Width="100px" OnClick="btnEdit_Click" /></div>
                                            </td>
                                            <td  style="text-align: left; float: left;width:500px; "></td>
                                            <td style="float:left">
                                                <div style="width:105px;position:fixed;padding-left:50px;margin-top:-15px">
                                                    <asp:Button ID="Button3" runat="server" Text="" CssClass="CssBtnPrint" Width="70px" OnClick="Button3_Click" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  style="text-align: left; float: left; width: 500px">
                                                 <div style="overflow:auto; height:435px;width:500px;margin-top:1px">
                            <asp:TreeView ID="TreeViewCompanyChart" runat="server" OnTreeNodePopulate="TreeViewCompanyChart_TreeNodePopulate"
                                 OnSelectedNodeChanged="TreeViewCompanyChart_SelectedNodeChanged" NodeIndent="15" CssClass="popup">
                                <ParentNodeStyle Font-Bold="True" />
                                                        <RootNodeStyle Font-Bold="True" />
                                                </asp:TreeView>
                             </div>
                                            </td>
                                            <td  style="text-align: left; float: left;width:500px; ">
                                                <div style="height: 615px;width:485px;padding-left:15px">
                                                    <asp:Panel ID="Panel1" runat="server" Height="100%" Width="99%" >
                                                <table style="width: 99%;text-align:left">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" Text="Company"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCompanyChart" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompanyChart_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label4" runat="server" Text="Element"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlElement" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlElement_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            <asp:Label ID="lblParentElementText" runat="server"></asp:Label>
                                                            <asp:Label ID="lblParentElementValue" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label5" runat="server" Text="Name"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label7" runat="server" Text="Short Name"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtShortName" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label8" runat="server" Text="Display Name"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtDisplayName" runat="server"></asp:TextBox>
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
                                                            <asp:Label ID="Label10" runat="server" Text="Name of Head"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtHeadID" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label12" runat="server" Text="Category"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCategory" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label13" runat="server" Width="100px" Text="Opening Date"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtOpeningDate" runat="server" TextMode="Date"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            <asp:CheckBox ID="CheckBoxAddress" runat="server" CssClass="checkbox"
                                                                AutoPostBack="True" OnCheckedChanged="CheckBoxAddress_CheckedChanged" />
                                                            <asp:Label ID="Label6" runat="server" AssociatedControlID="CheckBoxAddress" CssClass="checkbox">Address</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:Panel ID="PanelAddress" runat="server" Width="100%">
                                                                <table style="width: 99%;text-align: left">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label14" runat="server" Width="102px"  Text="Contact Number"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtContactNumber" runat="server" TextMode="Number"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label15" runat="server" Text="Display Address"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtDisplayAddress" runat="server" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label17" runat="server" Text="Division"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlDivision" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label16" runat="server" Text="District"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlDistrict" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label18" runat="server" Text="Postal Code"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label19" runat="server" Text="Phone No"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPhoneNo" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label20" runat="server" Text="Fax"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                                        </asp:Panel>
                                                    </div>
                                            </td>
                                            <td style="float:left">
                                                <div style="height: 475px;width:105px;position:fixed;padding-left:50px;margin-top:-5px">
                                                    <table >
                                                        <tr><td><asp:Button ID="btnSaveChart" runat="server" OnClick="btnSaveChart_Click" Text="Save" Width="70px" CssClass="CssBtnSave" /></td></tr>
                                                        <tr><td><asp:Button ID="btnClearChart" runat="server" OnClick="btnClearChart_Click" Text="Clear" Width="70px" CssClass="CssBtnClear" /></td></tr>
                                                        <tr><td><asp:Button ID="btnUpdate" runat="server" Text="Update" Width="70px" OnClick="btnUpdate_Click" CssClass="CssBtnUpdate" /></td></tr>
                                                        <tr><td><asp:Button ID="btnClearUpdate" runat="server" Text="Clear" Width="70px" OnClick="btnClearUpdate_Click" CssClass="CssBtnClear" /></td></tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>

                        </ajaxToolkit:TabContainer></td>
                </tr>
            </table>
    
        </ContentTemplate>
        <Triggers></Triggers>
    </asp:UpdatePanel>
    
</asp:Content>
