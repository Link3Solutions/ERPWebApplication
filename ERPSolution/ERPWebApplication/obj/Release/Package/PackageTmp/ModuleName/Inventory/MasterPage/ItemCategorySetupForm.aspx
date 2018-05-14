<%@ Page Title="Item Category Setup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemCategorySetupForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Inventory.MasterPage.ItemCategorySetupForm" %>

<%@ Register Assembly="ControlLibrary" Namespace="ERPSolution.Common.Controls" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 110px;
        }

        .auto-style4 {
            height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <cc1:MessageBox ID="MessageBox1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%; text-align: left">
                <tr>
                    <td colspan="4" style="float: left;">
                        <table style="width: 88%; text-align: left">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="True" placeholder="Search..." Width="337px"></asp:TextBox>
                                    </td>
                                    <ajaxToolkit:AutoCompleteExtender ID="txtSearch_AutoCompleteExtender" runat="server"
                                        CompletionListCssClass="autocomplete_completionListElement"
                                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                        CompletionListItemCssClass="autocomplete_listItem2"
                                        DelimiterCharacters=""
                                        Enabled="True"
                                        MinimumPrefixLength="1" ServiceMethod="GetItemName" ServicePath="~/WebService/ServiceSystem.asmx" TargetControlID="txtSearch">
                                    </ajaxToolkit:AutoCompleteExtender>
                                    <td>
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="CssBtnSearch" Height="30px" Width="100px" OnClick="btnSearch_Click" /></td>
                                </tr>

                            </table>
                    </td>
                    
                </tr>
                <tr>
                    <td colspan="4">
                        <hr id="searchbottom" runat="server" style="border:0; height: 1px; background: #333;  background-image: linear-gradient(to right, #ccc, #333, #ccc); width: 1175px;" />
                    </td>
                </tr>

                <tr>
                    <td colspan="3">
                        <asp:Panel ID="PanelBody"  runat="server">
                             <table style="width: 100%;">
                                <tr>
                                    <td style="width:500px;float:left;">
                                        <div style="min-height: 500px; width: 500px;">
                                            <asp:CheckBox runat="server" ID="CheckBoxAddItem" CssClass="checkbox" ForeColor="Gray" AutoPostBack="True" OnCheckedChanged="CheckBoxAddItem_CheckedChanged" />
                                        <asp:Label ID="Label3" runat="server" AssociatedControlID="CheckBoxAddItem" CssClass="checkbox" ForeColor="Gray">Add Item?</asp:Label>
                                            <div style="overflow:auto; height:425px;padding-top:5px">  
                                            <asp:Panel ID="PanelLeft" runat="server" Height="100%" Width="100%" >
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:TreeView ID="TreeViewCategory"
                                                                    runat="server" ImageSet="Simple" NodeIndent="15" OnTreeNodePopulate="TreeViewCategory_TreeNodePopulate"
                                                                    OnSelectedNodeChanged="TreeViewCategory_SelectedNodeChanged"
                                                                     Width="80%">
                                                                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                                            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="2px"
                                                                NodeSpacing="0px" VerticalPadding="2px"></NodeStyle>
                                                            <ParentNodeStyle Font-Bold="False" />
                                                            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                                                                VerticalPadding="0px" />
                                                                </asp:TreeView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
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
                                                </asp:Panel>
                                                </div>
                                        </div>
                                    </td>
                                    <td style="width:490px;float:left">
                                        <div style="min-height: 500px; width: 480px;padding-left:15px">
                                            <asp:Panel ID="PanelRight" runat="server" BackColor="#E0E0E0" Width="100%">
                                                <table style="width: 99%; margin-left: 15px; text-align: left">
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-left:5px">
                                                            <asp:Label ID="Label1" runat="server" Text="Category Name" Width="125px"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-left:5px">
                                                            <asp:Label ID="Label2" runat="server" Text="Parent Category"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlParentCategory" runat="server" Enabled="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="margin-left: -5px">
                                                            <asp:Panel ID="PanelProductType" Width="99%" BorderStyle="Solid" BorderWidth="1px" BorderColor="Gray" runat="server">

                                                                <table style="width: 100%;margin-left:5px">

                                                                    <tr>
                                                                        <td >&nbsp;<asp:Label ID="Label4" runat="server" Text="Product Type" Width="140px"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlProductType" runat="server">
                                                                                <asp:ListItem Selected="True" Value="1">Barcode Item</asp:ListItem>
                                                                                <asp:ListItem Value="2">Scale Item</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style1"></td>
                                                                        <td></td>
                                                                        <td style="text-align: left">
                                                                            <asp:Button ID="btnChangeCategory" runat="server" Text="Change Category" />
                                                                        </td>
                                                                    </tr>
                                                                </table>

                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:Panel ID="PanelItemDetails" runat="server">
                                                                <table style="width: 100%;margin-left:5px">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label39" runat="server" Text="Item Code" Width="125px"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtItemCodeUpdate" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label40" runat="server" BackColor="#FE817F" Font-Bold="true" ForeColor="White" Style="text-align: center" Text="Item Name" Width="75px"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtItemNameUpdate" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label41" runat="server" Text="Item Type ID"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlItemTypeIDUpdate" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label42" runat="server" Text="Item Usage ID"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlItemUsageIDUpdate" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>
                                                                            <asp:CheckBox ID="CheckBoxIsVATUpdate" runat="server" CssClass="checkbox" />
                                                                            <asp:Label ID="Label5" runat="server" AssociatedControlID="CheckBoxIsVATUpdate" CssClass="checkbox">Is VAT Payable ?</asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label43" runat="server" Text="Related Supplier"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlRelatedSupplierUpdate" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label44" runat="server" Text="Description"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtDescriptionUpdate" runat="server" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label45" runat="server" Text="H.S. Code "></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtHSCodeUpdate" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label46" runat="server" Text="Opening Balance"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtOpeningBalanceUpdate" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label47" runat="server" Text="Unit"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlUnitUpdate" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label48" runat="server" Text="Break Up Quantity"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtBreakUpQuantityUpdate" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label49" runat="server" Text="Break Up Unit"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlBreakupUnitUpdate" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label50" runat="server" Text="Re-Order Level"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtReOrderLevelUpdate" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label51" runat="server" Text="Minimum Quantity"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtMinimumQuantityUpdate" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label52" runat="server" Text="Sales Account No"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlSalesAccountNoUpdate" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label53" runat="server" Text="Stock Account No"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlStockAccountNoUpdate" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label54" runat="server" Text="COGS Account No"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlCOGSAccountNoUpdate" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label55" runat="server" Text="Sales Return Account"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlSalesReturnAccountUpdate" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>

                                                </table>
                                            </asp:Panel>
                                        </div>
                                    </td>
                                    <td  >
                                        
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                    <td style="width:125px;float:left">
                        <div style="min-height: 500px;position:fixed">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnSave" CssClass="CssBtnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnUpdate" runat="server" CssClass="CssBtnUpdate" Text="Update" Width="70px" OnClick="btnUpdate_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="Button3" runat="server" CssClass="CssBtnPrint" Text="Print" Width="70px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Panel ID="PanelItemSetup" BackColor="#DDEFF9" Width="90%" runat="server">
                            <table style="width: 100%;">
                                <tr>
                                    <td colspan="4" >
                                        <asp:Panel ID="PanelGetCategory" BackColor="#E0E0E0" BorderStyle="Solid" BorderWidth="3px" BorderColor="#E0E0E0" runat="server">
                                            <table style="width: 40%;">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label9" Style="text-align: center" runat="server" Text="Category" BackColor="#FE817F" Width="65px" ForeColor="White" Font-Bold="True"></asp:Label>
                                                        
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlCategory" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="lblSkip" runat="server" ForeColor="#0072B0"> (Click </asp:Label>
                                                                    <asp:LinkButton ID="btnskip" runat="server" CssClass="CssBtnCancel" OnClick="btnskip_Click" >Cancel</asp:LinkButton>
                                                                    <asp:Label ID="lblSkip0" runat="server" ForeColor="#0072B0">if you want to close item entry)</asp:Label>
                                                    </td>
                                                </tr>

                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="2"></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div style="width: 500px;min-height:235px">
                                            <table style="width: 100%; text-align: left">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label10" runat="server" Text="Item Code"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtItemCode" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label11" Style="text-align: center" runat="server" Text="Item Name" BackColor="#FE817F" Width="75px" ForeColor="White" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label33" runat="server" Text="Item Type ID"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlItemTypeID" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label34" runat="server" Text="Item Usage ID"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlItemUsageID" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td>
                                                        <asp:CheckBox ID="CheckBoxIsVATPayable" runat="server" CssClass="checkbox" />
                                                        <asp:Label ID="Label19" runat="server" AssociatedControlID="CheckBoxIsVATPayable" CssClass="checkbox">Is VAT Payable ?</asp:Label>

                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label14" runat="server" Text="Related Supplier"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlRelatedSupplier" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td>
                                                        <asp:CheckBox ID="CheckBoxSameSupplier" runat="server" CssClass="checkbox" />
                                                        <asp:Label ID="Label20" runat="server" AssociatedControlID="CheckBoxSameSupplier" CssClass="checkbox">Same Supplier</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="Label27" runat="server" Font-Underline="True" ForeColor="#793F19" Text="Enter Account Information"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label28" runat="server" Text="Sales Account No"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSalesAccountNo" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label29" runat="server" Text="Stock Account No"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlStockAccountNo" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label30" runat="server" Text="COGS Account No"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlCOGSAccountNo" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label31" runat="server" Text="Sales Return Account"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSalesReturnAccount" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:CheckBox ID="CheckBoxSameAccount" runat="server" CssClass="checkbox" />
                                                                    <asp:Label ID="Label32" runat="server" AssociatedControlID="CheckBoxSameAccount" CssClass="checkbox"> Same Account for all items</asp:Label>
                                                    </td>
                                                </tr>
                                                
                                            </table>
                                        </div>
                                    </td>
                                    <td colspan="2">
                                        <div style="width: 500px;min-height:235px">
                                            <table style="width: 98%;">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label15" runat="server" Text="Description"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label16" runat="server" Text="H.S. Code "></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtHSCode" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="Label35" runat="server" ForeColor="#793F19" Text="Unit Information" Font-Underline="True"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style4">
                                                        <asp:Label ID="Label17" runat="server" Text="Opening Balance"></asp:Label>
                                                    </td>
                                                    <td class="auto-style4">:</td>
                                                    <td class="auto-style4">
                                                        <asp:TextBox ID="txtOpeningBalance" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label12" runat="server" Text="Unit"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlUnit" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label36" runat="server" Text="Break Up Quantity"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtBreakUpQuantity" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label37" runat="server" Text="Break Up Unit"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBreakupUnit" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label18" runat="server" Text="Re-Order Level"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtReOrderLevel" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label38" runat="server" Text="Minimum Quantity"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtMinimumQuantity" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                 </table>
                        </asp:Panel>
                    </td>
                    <td></td>
                </tr>
            </table>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
