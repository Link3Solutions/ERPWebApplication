<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ERPWebApplication._Default" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <p>Content Page Here............................</p>
    <nav >
        <ul id="menu"  >
             <li><a id="A1" runat="server" href="~/ModuleName/Inventory/TransactionPage/frm_item_issue.aspx">ITEM ISSUE</a></li> 
            <li><a id="A2" runat="server" href="~/ModuleName/Inventory/TransactionPage/frm_item_requisition.aspx">ITEM REQUISITION</a></li>
            <li><a id="A3" runat="server" href="~/ModuleName/Inventory/TransactionPage/frm_item.aspx">ITEM</a></li>
        </ul>
    </nav>
</asp:Content>
