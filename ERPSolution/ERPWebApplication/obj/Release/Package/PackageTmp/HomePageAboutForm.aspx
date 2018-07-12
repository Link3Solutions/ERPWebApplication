<%@ Page Language="C#" Title="Home Page" AutoEventWireup="true" MasterPageFile="~/SiteHomePage.Master" CodeBehind="HomePageAboutForm.aspx.cs" Inherits="ERPWebApplication.HomePageAboutForm" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                            <td>
                                <asp:Panel ID="PanelAbout" runat="server"></asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Content>
    

