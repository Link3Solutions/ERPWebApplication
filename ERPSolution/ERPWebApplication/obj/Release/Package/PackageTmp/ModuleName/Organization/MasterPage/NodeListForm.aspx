﻿<%@ Page Title="Default Node List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NodeListForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Organization.MasterPage.NodeListForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%; text-align: left">
                <tr>
                    <td  style="float: left">
                        <div style="height:32px;width:500px"><asp:Button ID="btnAddNew" runat="server" CssClass="CssBtnAddNew" Text="AddNew" Width="100px" OnClick="btnAddNew_Click" /><asp:Button ID="btnEdit" runat="server" CssClass="CssBtnUpdate" Text="Edit" Width="100px" OnClick="btnEdit_Click" /></div>
                        <div style="overflow:auto; height:475px;width:500px">
                        <asp:TreeView ID="treeNodeList" runat="server" ImageSet="Msdn" OnSelectedNodeChanged="treeNodeList_SelectedNodeChanged" OnTreeNodePopulate="treeNodeList_TreeNodePopulate">
                        </asp:TreeView>
                            </div>
                    </td>
                    <td  style="text-align: left; float: left;">
                        <div style="height: 475px;width:475px;padding-left:5px">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="lblParentText" runat="server"></asp:Label>
                                    <asp:Label ID="lblParentValue" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Title" Width="65px"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblType" runat="server" Text="Type"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" Width="310px">
                                        <asp:ListItem Selected="True" Value="-1">--- Please Select ---</asp:ListItem>
                                        <asp:ListItem Value="1">Module Name</asp:ListItem>
                                        <asp:ListItem Value="2">Setup Page</asp:ListItem>
                                        <asp:ListItem Value="3">Transaction Page</asp:ListItem>
                                        <asp:ListItem Value="4">Form</asp:ListItem>
                                        <asp:ListItem Value="5">Report</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Position"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:DropDownList ID="ddlShowPosition" runat="server" Width="310px">
                                        <asp:ListItem Selected="True" Value="-1">--- Please Select ---</asp:ListItem>
                                        <asp:ListItem Value="1">Menu</asp:ListItem>
                                        <asp:ListItem Value="2">Dashboard</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Panel ID="PanelFormDetails" runat="server">
                                        <table style="width:100%;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Form URL" Width="65px"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlFormURL" runat="server" Width="310px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                            </div>
                    </td>
                    <td style="float:left">
                        <div style="height: 475px;width:125px;position:fixed">
                            <table>
                                <tr><td><asp:Button ID="btnSave" runat="server" CssClass="CssBtnSave" Text="Save" Width="70px" OnClick="btnSave_Click" /></td></tr>
                                <tr><td><asp:Button ID="btnCancelAddNew" runat="server" CssClass="CssBtnCancel" Text="Cancel" Width="70px" OnClick="btnCancelAddNew_Click" /></td></tr>
                                <tr><td><asp:Button ID="btnPrint" runat="server" CssClass="CssBtnPrint" Text="Print" Width="70px" /></td></tr>
                                <tr><td><asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="CssBtnUpdate" Width="70px" OnClick="btnUpdate_Click" /></td></tr>
                                <tr><td><asp:Button ID="btnCancelEdit" runat="server" CssClass="CssBtnCancel"  Text="Cancel" Width="70px" OnClick="btnCancelEdit_Click" /></td></tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
