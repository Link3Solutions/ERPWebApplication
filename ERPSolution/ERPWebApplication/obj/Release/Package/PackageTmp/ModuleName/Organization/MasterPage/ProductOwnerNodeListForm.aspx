<%@ Page Title="Product Owner Node List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductOwnerNodeListForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Organization.MasterPage.ProductOwnerNodeListForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Width="1160px">
            <table style="width: 100%; text-align: left">
                <tr style="border-bottom: 1px solid gray ">
                    <td style="text-align: left; float: left; width: 500px">
                        <div style="height:32px;width:500px;margin-top:-10px">
                            <asp:Button ID="btnAddNew" runat="server" CssClass="CssBtnAddNew" Text="AddNew" Width="100px" OnClick="btnAddNew_Click" /><asp:Button ID="btnEdit" runat="server" CssClass="CssBtnUpdate" Text="Edit" Width="100px" OnClick="btnEdit_Click" />

                        </div>
                    </td>
                    <td style="text-align: left; float: left;width:485px; "></td>
                    <td style="float:left">
                        <div style="width:110px;position:fixed;padding-left:50px;margin-top:-10px">
                            <asp:Button ID="btnPrint" runat="server" CssClass="CssBtnPrint" Text="" Width="70px" />
                            </div>
                    </td>
                </tr>
                <tr>
                    <td  style="text-align: left; float: left; width: 500px">
                        <div style="overflow:auto; height:433px;width:500px">
                        <asp:TreeView ID="treeNodeList" runat="server" NodeIndent="15"  OnSelectedNodeChanged="treeNodeList_SelectedNodeChanged" OnTreeNodePopulate="treeNodeList_TreeNodePopulate">
                            <ParentNodeStyle Font-Bold="True" />
                                                        <RootNodeStyle Font-Bold="True" />
                        </asp:TreeView>
                            </div>
                    </td>
                    <td  style="text-align: left; float: left;width:485px; ">
                        <div style="height: 433px;width:470px;padding-left:15px">
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
                        <div style="height: 433px;width:110px;position:fixed;padding-left:50px;margin-top:-5px">
                            <table>
                                <tr><td><asp:Button ID="btnSave" runat="server" CssClass="CssBtnSave" Text="Save" Width="70px" OnClick="btnSave_Click" /></td></tr>
                                <tr><td><asp:Button ID="btnCancelAddNew" runat="server" CssClass="CssBtnCancel" Text="Cancel" Width="70px" OnClick="btnCancelAddNew_Click" /></td></tr>
                                <tr><td><asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="CssBtnUpdate" Width="70px" OnClick="btnUpdate_Click" /></td></tr>
                                <tr><td><asp:Button ID="btnCancelEdit" runat="server" CssClass="CssBtnCancel"  Text="Cancel" Width="70px" OnClick="btnCancelEdit_Click" /></td></tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
                </asp:Panel>
        </ContentTemplate>
        <Triggers>
            
        </Triggers>
    </asp:UpdatePanel>
    
</asp:Content>
