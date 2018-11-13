<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServiceManagementForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Organization.MasterPage.ServiceManagementForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
                                                <td style="text-align: left; float: left; width: 500px">
                                                    <div style="overflow: auto; height: 433px; width: 500px">
                                                        <asp:TreeView ID="treeNodeListOwner" runat="server" NodeIndent="15" OnSelectedNodeChanged="treeNodeListOwner_SelectedNodeChanged" OnTreeNodePopulate="treeNodeListOwner_TreeNodePopulate">
                                                            <ParentNodeStyle Font-Bold="True" />
                                                            <RootNodeStyle Font-Bold="True" />
                                                        </asp:TreeView>
                                                    </div>
                                                </td>
                                                <td style="text-align: left; float: left; width: 485px;">
                                                    <div style="height: 433px; width: 470px; padding-left: 15px">
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td>&#160;</td>
                                                                <td>&nbsp;</td>
                                                                <td>
                                                                    <asp:Label ID="Label5" runat="server" Text="Title" Width="65px"></asp:Label><asp:Label ID="lblParentValue" runat="server" Visible="False"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtTitle" runat="server" Width="460px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>&#160;</td>
                                                                <td>&nbsp;</td>
                                                                <td>
                                                                    <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td>
                                                                    <asp:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server" TargetControlID="txtDescription"></asp:HtmlEditorExtender>
                                                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="325px" Width="460px"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                                <td style="float: left">
                                                    <div style="height: 433px; width: 110px; position: fixed; padding-left: 50px; margin-top: -5px">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnImport" runat="server" CssClass="CssBtnSave" Text="Import" Width="70px" OnClick="btnImport_Click" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="CssBtnUpdate" Width="70px" OnClick="btnUpdate_Click" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnCancelEdit" runat="server" CssClass="CssBtnCancel" Text="Cancel" Width="70px" OnClick="btnCancelEdit_Click" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnPrint" runat="server" CssClass="CssBtnPrint" Width="70px" /></td>
                                                            </tr>
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
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Panel ID="PanelServiceCreate" runat="server">
                                                    <table style="width: 100%; text-align: left">
                                                        <tr>
                                                            <td style="text-align: left; float: left; width: 500px">
                                                                <div style="overflow: auto; height: 433px; width: 500px">
                                                                    <asp:TreeView ID="treeNodeListForAssign" runat="server" OnTreeNodePopulate="treeNodeListForAssign_TreeNodePopulate"
                                                                        ShowCheckBoxes="All" NodeIndent="15" ShowExpandCollapse="False">
                                                                        <ParentNodeStyle Font-Bold="True" />
                                                                        <RootNodeStyle Font-Bold="True" />
                                                                    </asp:TreeView>
                                                                </div>
                                                            </td>
                                                            <td style="text-align: left; float: left; width: 485px;">
                                                                <div style="height: 433px; width: 470px; padding-left: 15px">
                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td></td>
                                                                            <td>&nbsp;</td>
                                                                            <td>&#160;<asp:Label ID="Label4" runat="server" Text="Select service" Width="100px"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>&nbsp;</td>
                                                                            <td>&nbsp;</td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlservices" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlservices_SelectedIndexChanged"></asp:DropDownList></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td></td>
                                                                            <td>&nbsp;</td>
                                                                            <td>&#160;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>&nbsp;</td>
                                                                            <td>&nbsp;</td>
                                                                            <td></td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                            <td style="float: left">
                                                                <div style="height: 433px; width: 110px; position: fixed; padding-left: 50px; margin-top: -5px">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Button ID="btnSaveServiceNode" runat="server" CssClass="CssBtnSave" Text="Save" Width="70px" OnClick="btnSaveServiceNode_Click" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Button ID="btnCancelNodeAssign" runat="server" CssClass="CssBtnCancel" Text="Cancel" Width="70px" OnClick="btnCancelNodeAssign_Click" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Button ID="Button4" runat="server" CssClass="CssBtnPrint" Width="70px" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Button ID="btnAddNewService" runat="server" CssClass="CssBtnAddNew" Text="New Service" Width="70px" Font-Size="8pt" OnClick="btnAddNewService_Click" /></td>
                                                                        </tr>
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
                                                    <table style="width: 100%; text-align: left; margin-top: -25px">
                                                        <tr>
                                                            <td style="text-align: left; float: left; ">
                                                                <div style="height: 175px; width: 250px">
                                                                    <table style="width: 99%;">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label12" runat="server" Text="Service Category"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlServiceCategory" Width="235px" runat="server"></asp:DropDownList></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label8" runat="server" Text="Service Name"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:TextBox ID="txtServiceName" Width="230px" runat="server"></asp:TextBox></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label10" runat="server" Text="Service Value"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:TextBox ID="txtServiceValue" Width="230px" runat="server"></asp:TextBox></td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                            <td style="text-align: left; float: left; ">
                                                                <div style="height: 175px; width: 250px; padding-left: 15px">
                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label14" runat="server" Text="Payment Type"></asp:Label><asp:Label ID="lblServiceIDValue" runat="server" Visible="False"></asp:Label></td>
                                                                            <td>&nbsp;</td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlPaymentType" Width="235px" runat="server"></asp:DropDownList></td>
                                                                            <td>&nbsp;</td>
                                                                            <td rowspan="5"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label15" runat="server" Width="110px" Text="VAT Calculation"></asp:Label>&nbsp;&nbsp;<asp:Label ID="Label7" Width="110px" runat="server" Text="VAT Rate (%)"></asp:Label></td>
                                                                            <td>&nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlVATCalculation" Width="110px" runat="server"></asp:DropDownList>&nbsp;&nbsp;<asp:TextBox ID="txtVATRate" Width="105px" Height="22px" TextMode="Number" runat="server"></asp:TextBox></td>
                                                                            <td>&nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label11" runat="server" Text="Billing frequency"></asp:Label></td>
                                                                            <td>&nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlBillingFrequency" Width="235px" runat="server"></asp:DropDownList></td>
                                                                            <td>&nbsp;</td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                            <td style="text-align: left; float: left; ">
                                                                <div style="height: 175px; width: 240px; padding-left: 15px">
                                                                    <table style="width: 100%; margin-top: -1px">
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <asp:Label ID="Label9" runat="server" Text="Package"></asp:Label><asp:Label ID="lblServiceValueIDValue" runat="server" Visible="False"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <asp:DropDownList ID="ddlPackage" Width="235px" runat="server"></asp:DropDownList>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label1" runat="server" Text="Description"></asp:Label></td>
                                                                            <td>&nbsp;</td>
                                                                            <td>&nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <asp:TextBox ID="txtServiceDescription" runat="server" Height="50px" TextMode="MultiLine" Width="230px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <asp:Label ID="Label13" runat="server" Width="175px" Text="Number of users allowed"></asp:Label>&nbsp;<asp:TextBox ID="txtNumberOfUsersAllowed" Width="50px" Height="22px" TextMode="Number" runat="server"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                            <td style="text-align: left; float: left; ">
                                                                <div style="height: 175px; width: 200px">
                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <asp:Button ID="btnAddPackage" Width="100px" CssClass="CssBtnAddNew" runat="server" Text="Add Package" OnClick="btnAddPackage_Click" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <asp:Panel ID="Panel11" runat="server" Height="100%" Width="190px">
                            <table style="width: 100%; text-align: left">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblImage" runat="server" BorderColor="Black" BorderWidth="0px" Font-Bold="True" Font-Italic="True" Font-Size="Small" ForeColor="Red" Height="55px" Style="text-align: center; vertical-align: middle" Width="60px">  Logo
                                             <br />  Not <br />  Available
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <%--<asp:Label ID="Label98" runat="server" Text="[150X150,  Files are supported]"></asp:Label>--%>
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
                                                                        </tr>
                                                                    </table>
                                                                    </div>
                                                                </td>
                                                            <td style="float: left">
                                                                <div style="height: 175px; width: 110px; position: fixed; padding-left: 50px; margin-top: -5px">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Button ID="btnCreateService" runat="server" CssClass="CssBtnSave" Text="Save" Width="70px" OnClick="btnCreateService_Click" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Button ID="btnCancelServiceSetup" runat="server" CssClass="CssBtnCancel" Text="Cancel" Width="70px" OnClick="btnCancelServiceSetup_Click" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Button ID="btnClearServiceData" runat="server" CssClass="CssBtnCancel" Text="Clear" Width="70px" OnClick="btnClearServiceData_Click" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Button ID="Button7" runat="server" CssClass="CssBtnPrint" Width="70px" /></td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:GridView ID="grdServices" runat="server" Width="1050px" AutoGenerateColumns="False" OnRowDataBound="grdServices_RowDataBound" OnRowCommand="grdServices_RowCommand" OnRowDeleting="grdServices_RowDeleting">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Service Category">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblServiceCategoryType" runat="server" Text='<%# Bind("ServiceCategoryType") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
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
                                                                                <asp:Label ID="lblServiceValue" runat="server" Text='<%# Eval("ServiceValue","{0:N2}") %>' Width="75px" Style="text-align: right;"></asp:Label>
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
                                                                        <asp:TemplateField HeaderText="VAT Rate (%)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblVATRate" runat="server" Text='<%# Bind("VATRate") %>'></asp:Label>
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
                                                                        <asp:TemplateField HeaderText="ServiceCategoryTypeID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblServiceCategoryTypeID" runat="server" Text='<%# Bind("ServiceCategoryTypeID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Package ID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPackageIDService" runat="server" Text='<%# Bind("PackageID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Package">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPackageName" runat="server" Text='<%# Bind("PackageName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Users">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblusers" runat="server" Text='<%# Bind("UserAllowed") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:CommandField ShowSelectButton="True" />
                                                                        <asp:CommandField ShowDeleteButton="True" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                            <td>
                                                                <div style="height: 175px; width: 110px;  padding-left: 50px; margin-top: -5px">
                                                                    </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="PanelPackageSetup" runat="server">
                                                    <table style="width: 100%; text-align: left; margin-top: -25px">
                                                        <tr>
                                                            <td style="text-align: left; float: left; width: 600px">
                                                                <div style="height: 275px; width: 600px">
                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label2" runat="server" Text="Package Name"></asp:Label></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <asp:TextBox ID="txtPackageName" runat="server" Width="600px"></asp:TextBox>
                                                                            </td>

                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label6" runat="server" Text="Description"></asp:Label><asp:Label ID="lblPackageIdUpdate" runat="server" Visible="false" Text=""></asp:Label>
                                                                            </td>
                                                                            <td>&nbsp;</td>
                                                                            <td>&nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <asp:HtmlEditorExtender ID="HtmlEditorExtender2" runat="server" TargetControlID="txtDescriptionPackage"></asp:HtmlEditorExtender>
                                                                                <asp:TextBox ID="txtDescriptionPackage" runat="server" Width="600px" Height="150px" TextMode="MultiLine"></asp:TextBox>

                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                            <td style="text-align: left; float: left; width: 385px;">
                                                                <div style="height: 275px; width: 370px; padding-left: 15px">
                                                                </div>
                                                            </td>
                                                            <td style="float: left">
                                                                <div style="height: 275px; width: 110px; position: fixed; padding-left: 50px; margin-top: -5px">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Button ID="btnSavePackage" runat="server" CssClass="CssBtnSave" Text="Save" Width="70px" OnClick="btnSavePackage_Click" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Button ID="btnPackageSetupCancel" runat="server" CssClass="CssBtnCancel" Text="Cancel" Width="70px" OnClick="btnPackageSetupCancel_Click" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Button ID="btnClearPackage" runat="server" CssClass="CssBtnCancel" Text="Clear" Width="70px" OnClick="btnClearPackage_Click" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Button ID="Button6" runat="server" CssClass="CssBtnPrint" Width="70px" /></td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:GridView ID="grdPackageSetup" runat="server" AutoGenerateColumns="False" Width="1050px" OnRowDataBound="grdPackageSetup_RowDataBound" OnRowDeleting="grdPackageSetup_RowDeleting" OnRowCommand="grdPackageSetup_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="SL">
                                                                            <ItemTemplate>
                                                                                <%# Container.DisplayIndex + 1 %>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Package Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPackageName" runat="server" Text='<%# Bind("PackageName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Package Description">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPackageDescription" runat="server" Text='<%# Bind("PackageDescription") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Package ID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPackageID" runat="server" Text='<%# Bind("PackageID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:CommandField ShowSelectButton="True" />
                                                                        <asp:CommandField ShowDeleteButton="True" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                                </t>
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
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                        </ajaxToolkit:TabContainer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="TabContainerUserPermission$TabPanelUserPermission$btnEmpPhoto" />
            <%--<asp:PostBackTrigger ControlID="TabContainerUserPermission$TabPanelRoleSetup$btnUpdate" />--%>
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function OnTreeClick(evt) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target
            var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
            if (isChkBoxClick) {
                var parentTable = GetParentByTagName("table", src);
                var nxtSibling = parentTable.nextSibling;
                if (nxtSibling && nxtSibling.nodeType == 1)//check if nxt sibling is not null & is an element node
                {
                    if (nxtSibling.tagName.toLowerCase() == "div") //if node has children
                    {
                        //check or uncheck children at all levels
                        CheckUncheckChildren(parentTable.nextSibling, src.checked);
                    }
                }
                //check or uncheck parents at all levels
                CheckUncheckParents(src, src.checked);
            }
        }

        function CheckUncheckChildren(childContainer, check) {
            var childChkBoxes = childContainer.getElementsByTagName("input");
            var childChkBoxCount = childChkBoxes.length;
            for (var i = 0; i < childChkBoxCount; i++) {
                childChkBoxes[i].checked = check;
            }
        }

        function CheckUncheckParents(srcChild, check) {
            var parentDiv = GetParentByTagName("div", srcChild);
            var parentNodeTable = parentDiv.previousSibling;

            if (parentNodeTable) {
                var checkUncheckSwitch;

                if (check) //checkbox checked
                {
                    checkUncheckSwitch = true;
                }
                else //checkbox unchecked
                {
                    var isAllSiblingsUnChecked = AreAllSiblingsUnChecked(srcChild);
                    if (!isAllSiblingsUnChecked)
                        checkUncheckSwitch = true;
                    else
                        checkUncheckSwitch = false;
                }

                var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");
                if (inpElemsInParentTable.length > 0) {
                    var parentNodeChkBox = inpElemsInParentTable[0];
                    parentNodeChkBox.checked = checkUncheckSwitch;
                    //do the same recursively
                    CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
                }
            }
        }

        function AreAllSiblingsUnChecked(chkBox) {
            var parentDiv = GetParentByTagName("div", chkBox);
            var childCount = parentDiv.childNodes.length;
            for (var i = 0; i < childCount; i++) {
                if (parentDiv.childNodes[i].nodeType == 1) //check if the child node is an element node
                {
                    if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {
                        var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];
                        //if any of sibling nodes are not checked, return false
                        if (prevChkBox.checked) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        //utility function to get the container of an element by tagname
        function GetParentByTagName(parentTagName, childElementObj) {
            var parent = childElementObj.parentNode;
            while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
                parent = parent.parentNode;
            }
            return parent;
        }

    </script>
</asp:Content>
