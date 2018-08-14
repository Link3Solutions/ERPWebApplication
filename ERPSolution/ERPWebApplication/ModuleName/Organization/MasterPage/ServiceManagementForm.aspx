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
                        <asp:TreeView ID="treeNodeListOwner" runat="server" NodeIndent="15" OnSelectedNodeChanged="treeNodeListOwner_SelectedNodeChanged" OnTreeNodePopulate="treeNodeListOwner_TreeNodePopulate" >
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
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Title" Width="65px"></asp:Label>
                                    <asp:Label ID="lblParentValue" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    
                                    <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
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
                                <tr><td><asp:Button ID="btnImport" runat="server" CssClass="CssBtnSave" Text="Import" Width="70px" OnClick="btnImport_Click"  /></td></tr>                                
                                <tr><td><asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="CssBtnUpdate" Width="70px" OnClick="btnUpdate_Click"  /></td></tr>
                                <tr><td><asp:Button ID="btnCancelEdit" runat="server" CssClass="CssBtnCancel"  Text="Cancel" Width="70px" OnClick="btnCancelEdit_Click"  /></td></tr>
                                <tr><td><asp:Button ID="btnPrint" runat="server" CssClass="CssBtnPrint" Width="70px"  /></td></tr>
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
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Select service" Width="100px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlservices" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    
                                    <asp:Label ID="Label6" runat="server" Text="Category"></asp:Label>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
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
                    <td  style="text-align: left; float: left; width: 300px">
                        <div style="height:250px;width:300px">
                            <table style="width: 99%;">
                                <tr>
                                    <td>
                                        <div style="height:35px">
                                        <asp:Label ID="Label7" runat="server" CssClass="lineCreateAccount"  Text="Create service"></asp:Label>
                                            </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label12" runat="server" Text="Service Category"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlServiceCategory" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Service Name"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtServiceName" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Service Value"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtServiceValue" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" Text="Billing frequency"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlBillingFrequency" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            </div>
                    </td>
                    <td  style="text-align: left; float: left;width:685px; ">
                        <div style="height: 250px;width:670px;padding-left:15px">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <div style="height:35px">
                                        <asp:Label ID="Label13" runat="server" CssClass="lineCreateAccount"></asp:Label>
                                            <asp:Label ID="lblServiceIDValue" runat="server" Visible="False"></asp:Label>
                                            <asp:Label ID="lblServiceValueIDValue" runat="server" Visible="False"></asp:Label>
                                            </div>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Text="Payment Type"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlPaymentType" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" Text="VAT Calculation"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlVATCalculation" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="Description"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtServiceDescription" runat="server" Height="75px" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                            </div>
                    </td>
                    <td style="float:left">
                        <div style="height: 250px;width:110px;position:fixed;padding-left:50px;margin-top:-5px">
                            <table>
                                <tr><td><asp:Button ID="btnCreateService" runat="server" CssClass="CssBtnSave" Text="Save" Width="70px" OnClick="btnCreateService_Click"  /></td></tr>  
                                <tr><td><asp:Button ID="btnCancelServiceSetup" runat="server" CssClass="CssBtnCancel"  Text="Cancel" Width="70px" OnClick="btnCancelServiceSetup_Click"  /></td></tr>
                                <tr><td><asp:Button ID="btnClearServiceData" runat="server" CssClass="CssBtnCancel"  Text="Clear" Width="70px" OnClick="btnClearServiceData_Click"   /></td></tr>
                                <tr><td><asp:Button ID="Button7" runat="server" CssClass="CssBtnPrint" Width="70px"  /></td></tr>                                
                            </table>
                        </div>
                    </td>
                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:GridView ID="grdServices" runat="server" Width="1050px" AutoGenerateColumns="False" OnRowDataBound="grdServices_RowDataBound" OnRowCommand="grdServices_RowCommand" OnRowDeleting="grdServices_RowDeleting">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="ServiceID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblServiceID" runat="server" Text='<%# Bind("ServiceID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="ServiceValueID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblServiceValueID" runat="server" Text='<%# Bind("ServiceValueID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Service Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblServiceName" runat="server" Text='<%# Bind("ServiceName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Description">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblServiceDescription" runat="server" Text='<%# Bind("ServiceDescription") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="BillingFrequencyTypeID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblBillingFrequencyType" runat="server" Text='<%# Bind("BillingFrequencyType") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="PaymentTypeID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPaymentType" runat="server" Text='<%# Bind("PaymentType") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Service Value">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblServiceValue" runat="server" Text='<%# Eval("ServiceValue","{0:N2}") %>' Width="75px" Style="text-align: right;" ></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="VATCalculationProcessID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblVATCalculationProcess" runat="server" Text='<%# Bind("VATCalculationProcess") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="VAT Calculation">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblVATCalculationProcessText" runat="server" Text='<%# Bind("VATCalculationProcessText") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Payment Type">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPaymentTypeText" runat="server" Text='<%# Bind("PaymentTypeText") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Billing Frequency">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblBillingFrequencyTypeText" runat="server" Text='<%# Bind("BillingFrequencyTypeText") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:CommandField ShowSelectButton="True" />
                                                                        <asp:CommandField ShowDeleteButton="True" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                            <td></td>
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
