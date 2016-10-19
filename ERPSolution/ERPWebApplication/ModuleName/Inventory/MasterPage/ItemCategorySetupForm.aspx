<%@ Page Title="Item Category Setup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemCategorySetupForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Inventory.MasterPage.ItemCategorySetupForm" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    
                        <td colspan="4">
                            <div id="fixedDiv" style="width: 100%; position: fixed">
                            <asp:Panel ID="PanelTop" runat="server" BackColor="#00817F" >
                                
                                <table style="width: 60%;">
                                    <tr>
                                        
                                        <td>&nbsp; 
                                <asp:CheckBox runat="server" ID="CheckBoxAddItem" CssClass="checkbox" ForeColor="White" AutoPostBack="True" OnCheckedChanged="CheckBoxAddItem_CheckedChanged" />
                                            <asp:Label ID="Label3" runat="server" AssociatedControlID="CheckBoxAddItem" CssClass="checkbox" ForeColor="White">Add Item?</asp:Label>
                                        </td>
                                        <td style="text-align: right">
                                            <asp:Button ID="btnSaveCategory" runat="server" Text="Save" Width="100px" />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Button ID="Button2" runat="server" Text="Print Summery" />
                                        </td>
                                        <td style="text-align: left">
                                            
                                            <asp:Button ID="Button3" runat="server" Text="Print" Width="100px" />
                                                
                                        </td>
                                        
                                    </tr>
                                </table>
                                    
                            </asp:Panel>
                                </div>
                        </td>
                    
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td colspan="4">
                        
                        <asp:Panel ID="PanelBody" runat="server">

                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <div style="height: 560px">
                                            <asp:Panel ID="PanelLeft" runat="server" Width="500px">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:TreeView ID="TreeViewCategory" runat="server">
                                                            </asp:TreeView>
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
                                            </asp:Panel>
                                        </div>
                                    </td>
                                    <td>
                                        <div style="height: 560px">
                                            <asp:Panel ID="PanelRight" runat="server" BackColor="#E0E0E0" Width="99%">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text="Category Name"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" Text="Parent Category"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlParentCategory" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:Panel ID="PanelProductType" BorderStyle="Solid" BorderWidth="1px" BorderColor="Gray" runat="server">

                                                                <table style="width: 100%;">
                                                                    
                                                                    <tr>
                                                                        <td >
                                                                            <asp:Label ID="Label4" runat="server" Text="Select Product Type" Width="120px"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="DropDownList10" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td >&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td style="text-align: right">
                                                                            <asp:Button ID="btnChangeCategory" runat="server" Text="Change Category" />
                                                                        </td>
                                                                    </tr>
                                                                </table>

                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:Panel ID="PanelSearch" runat="server">
                                                                <table style="width: 100%;">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label5" style="text-align:center" runat="server" Text="Search" BackColor="#FF8081" ForeColor="White" Font-Bold="true" Width="75px"></asp:Label>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label6" runat="server" Text="Item Category"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="DropDownList1" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label7" runat="server" Text="Item Name"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="DropDownList2" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label8" runat="server" Text="Item Code"></asp:Label>
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="DropDownList3" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td style="text-align:right">
                                                                            <asp:Button ID="Button1" runat="server" Text="Search Now" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>

                                                </table>
                                            </asp:Panel>
                                        </div>
                                    </td>
                                </tr>
                            </table>

                        </asp:Panel>
                            
                    </td>
                </tr>
                
                <tr>
                    <td colspan="4">
                        
                        <asp:Panel ID="PanelItemSetup" BackColor="#DDEFF9" Width="100%" runat="server">
                            <table style="width: 100%;">
                                <tr>
                                    <td colspan="4">
                                        <asp:Panel ID="PanelGetCategory" BackColor="#E0E0E0" BorderStyle="Solid" BorderWidth="3px" BorderColor="#E0E0E0" runat="server">
                                            <table style="width: 40%;">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label9" style="text-align:center" runat="server" Text="Category" BackColor="#FE817F" Width="65px" ForeColor="White" Font-Bold="True"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlCategory" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td colspan="2">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div style="padding-top: 0px">
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
                                                        <asp:Label ID="Label11" style="text-align:center" runat="server" Text="Item Name" BackColor="#FE817F" Width="75px" ForeColor="White" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label12" runat="server" Text="Unit"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownList4" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:CheckBox ID="CheckBoxIsVATPayable" runat="server" CssClass="checkbox" />
                                                        <asp:Label ID="Label19" runat="server" AssociatedControlID="CheckBoxIsVATPayable" CssClass="checkbox">Is VAT Payable ?</asp:Label>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label13" runat="server" Text="Barcode"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label14" runat="server" Text="Related Supplier"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownList5" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:CheckBox ID="CheckBoxSameSupplier" runat="server" CssClass="checkbox" />
                                                        <asp:Label ID="Label20" runat="server" AssociatedControlID="CheckBoxSameSupplier" CssClass="checkbox">Same Supplier</asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td colspan="2">
                                        <div style="padding-top: 0px">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label15" runat="server" Text="Description"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label16" runat="server" Text="H.S. Code "></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label17" runat="server" Text="Opening Balance"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label18" runat="server" Text="Re-Order Level"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
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
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table style="width: 100%; text-align: left">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label21" runat="server" Text="Retail Price(MRP)"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox8" runat="server" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label22" runat="server" Text="Retail Price"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox13" runat="server" Width="75px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" Text="Commission Rate (%) on MRP" Font-Bold="True"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox9" runat="server" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label24" runat="server" Text="(%) on TP" Font-Bold="True"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox12" runat="server" Width="75px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label25" runat="server" Text="Trade Price"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox10" runat="server" Width="75px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label26" runat="server" Text="Supplier TP"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:TextBox ID="TextBox11" runat="server" Width="75px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="text-align: right">
                                                    <asp:Button ID="Button4" runat="server" Text="Calculate Commission" Width="200px" />
                                                </td>
                                                <td colspan="3">
                                                    <asp:Button ID="Button5" runat="server" Text="Calculate Commission" Width="200px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <table style="width: 75%; text-align: left">
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Label ID="Label27" runat="server" Text="Enter Account Information" ForeColor="#793F19" Width="500px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label28" runat="server" Text="Sales Account No"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList7" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label29" runat="server" Text="Stock Account No"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList8" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label30" runat="server" Text="COGS Account No"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList9" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Button ID="Button6" runat="server" Text="Show Previous Accounts" Width="200px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label31" runat="server" Text="Sales Return Account"></asp:Label>
                                                </td>
                                                <td>:</td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList6" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Button ID="Button7" runat="server" Text="Show Account Heads" Width="200px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td colspan="2">
                                                    <asp:CheckBox ID="CheckBoxSameAccount" runat="server" CssClass="checkbox" />
                                                    <asp:Label ID="Label32" runat="server" AssociatedControlID="CheckBoxSameAccount" CssClass="checkbox"> Same Account for all items</asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                            </table>
                        </asp:Panel>
                            
                    </td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
