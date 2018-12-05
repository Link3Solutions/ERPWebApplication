<%@ Page Title="" Language="C#" MasterPageFile="~/SiteHomePage.Master" AutoEventWireup="true" CodeBehind="ThankYouForm.aspx.cs" Inherits="ERPWebApplication.ThankYouForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding-left:150px">
    <table style="width: 100%;">
        <tr>
            <td>
                
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
            <p2> Thank You !</p2><br />
            <p1> You have received a security code in your email address <asp:Label ID="lblUserEmail" runat="server" Font-Bold="True"></asp:Label> .</p1>
            <br /><br />
            <p1> Please <asp:LinkButton ID="lnkbtnToResigter" runat="server" OnClick="lnkbtnToResigter_Click">Click</asp:LinkButton> here to register and enter security code to complete your registration. </p1> 

            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:LinkButton ID="lnkbtnHome" runat="server" Font-Underline="False" CssClass="logoutHover" BackColor="White" OnClick="lnkbtnHome_Click" >Home</asp:LinkButton><asp:LinkButton ID="lnkbtnServices" runat="server" Font-Underline="False" CssClass="logoutHover" BackColor="White" OnClick="lnkbtnServices_Click" >Services</asp:LinkButton><asp:LinkButton ID="lnkbtnPolicies" runat="server" Font-Underline="False" CssClass="logoutHover" BackColor="White" >Policies</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
        </div>
</asp:Content>
