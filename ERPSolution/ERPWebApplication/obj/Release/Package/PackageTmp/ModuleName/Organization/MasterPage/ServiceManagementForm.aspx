<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServiceManagementForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Organization.MasterPage.ServiceManagementForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <ajaxToolkit:TabContainer ID="TabContainerUserPermission" runat="server" Width="1160px" Height="100%" ActiveTabIndex="1" CssClass="tab" CssTheme="None">
                            <ajaxToolkit:TabPanel ID="TabPanelRoleSetup" runat="server" HeaderText="Service Description" Width="1160px">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel1" runat="server" Width="1160px">
                                    <table style="width: 100%; text-align: left">
                                        <tr>
                    <td  style="text-align: left; float: left; width: 500px">
                        <div style="overflow:auto; height:433px;width:500px">
                        <asp:TreeView ID="treeNodeList" runat="server" NodeIndent="15" >
                            <ParentNodeStyle Font-Bold="True" />
                                                        <RootNodeStyle Font-Bold="True" />
                        </asp:TreeView>
                            </div>
                    </td>
                    <td  style="text-align: left; float: left;width:485px; ">
                        <div style="height: 433px;width:470px;padding-left:15px">
                        <table style="width: 100%;">
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
                        </table>
                            </div>
                    </td>
                    <td style="float:left">
                        <div style="height: 433px;width:110px;position:fixed;padding-left:50px;margin-top:-5px">
                            <table>
                                <tr><td><asp:Button ID="btnImport" runat="server" CssClass="CssBtnSave" Text="Import" Width="70px"  /></td></tr>                                
                                <tr><td><asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="CssBtnUpdate" Width="70px"  /></td></tr>
                                <tr><td><asp:Button ID="btnCancelEdit" runat="server" CssClass="CssBtnCancel"  Text="Cancel" Width="70px"  /></td></tr>
                                <tr><td><asp:Button ID="btnPrint" runat="server" CssClass="CssBtnPrint"  Text="" Width="70px"  /></td></tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
                </asp:Panel>
                                    </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanelUserPermission" runat="server" HeaderText="Create Service" Width="1160px">
                                <ContentTemplate>
                                    <table style="width:100%">
                                        <tr>
                                            <td>
                                                <asp:Panel ID="PanelServiceCreate" runat="server">
                                                    <table style="width: 100%; text-align: left">
                                        <tr>
                    <td  style="text-align: left; float: left; width: 500px">
                        <div style="overflow:auto; height:433px;width:500px">
                        <asp:TreeView ID="TreeView1" runat="server" NodeIndent="15" >
                            <ParentNodeStyle Font-Bold="True" />
                                                        <RootNodeStyle Font-Bold="True" />
                        </asp:TreeView>
                            </div>
                    </td>
                    <td  style="text-align: left; float: left;width:485px; ">
                        <div style="height: 433px;width:470px;padding-left:15px">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Select service" Width="100px"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:DropDownList ID="ddlservices" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Category"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    
                                    <asp:DropDownList ID="ddlCategory" runat="server">
                                    </asp:DropDownList>
                                    
                                </td>
                            </tr>
                        </table>
                            </div>
                    </td>
                    <td style="float:left">
                        <div style="height: 433px;width:110px;position:fixed;padding-left:50px;margin-top:-5px">
                            <table>
                                <tr><td><asp:Button ID="Button1" runat="server" CssClass="CssBtnSave" Text="Save" Width="70px"  /></td></tr>  
                                <tr><td><asp:Button ID="Button3" runat="server" CssClass="CssBtnCancel"  Text="Cancel" Width="70px"  /></td></tr>
                                <tr><td><asp:Button ID="Button4" runat="server" CssClass="CssBtnPrint" Width="70px"  /></td></tr>
                                <tr><td><asp:Button ID="btnAddNewService" runat="server" CssClass="CssBtnAddNew"  Text="New Service" Width="70px" Font-Size="8pt" OnClick="btnAddNewService_Click"  /></td></tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="PanelServiceSetup" runat="server">
                                                    <table style="width: 100%; text-align: left">
                                        <tr>
                    <td  style="text-align: left; float: left; width: 600px">
                        <div style="height:233px;width:600px">
                            <table style="width: 68%;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Create service" Font-Bold="True" Font-Size="12pt" Font-Underline="True"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Service Name"></asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td>
                                        <asp:TextBox ID="txtServiceName" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="Description"></asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td>
                                        <asp:TextBox ID="txtServiceDescription" runat="server" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Service Value"></asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td>
                                        <asp:TextBox ID="txtServiceValue" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" Text="Type"></asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlServiceType" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            </div>
                    </td>
                    <td  style="text-align: left; float: left;width:385px; ">
                        <div style="height: 233px;width:370px;padding-left:15px">
                        
                            </div>
                    </td>
                    <td style="float:left">
                        <div style="height: 233px;width:110px;position:fixed;padding-left:50px;margin-top:-5px">
                            <table>
                                <tr><td><asp:Button ID="Button5" runat="server" CssClass="CssBtnSave" Text="Save" Width="70px"  /></td></tr>  
                                <tr><td><asp:Button ID="btnCancelServiceSetup" runat="server" CssClass="CssBtnCancel"  Text="Cancel" Width="70px" OnClick="btnCancelServiceSetup_Click"  /></td></tr>
                                <tr><td><asp:Button ID="Button7" runat="server" CssClass="CssBtnPrint" Width="70px"  /></td></tr>                                
                            </table>
                        </div>
                    </td>
                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:GridView ID="grdServices" runat="server" Width="100%"></asp:GridView>
                                                            </td>
                                                        </tr>
            </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                    </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                        </ajaxToolkit:TabContainer>
                    </td>
                </tr>
            </table>
            </ContentTemplate>
        <Triggers></Triggers>
        </asp:UpdatePanel>
</asp:Content>
