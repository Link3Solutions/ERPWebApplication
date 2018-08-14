<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTree.master" AutoEventWireup="true" CodeBehind="WebFormSample.aspx.cs" Inherits="ERPWebApplication.WebFormSample" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContentTree">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <div style="position:fixed;background-color:#FFFFFF;margin-top:-10px;width:87%">
                                <table style="width: 25%;">
                                    <tr>
                                        <td><asp:Button ID="btnSave" runat="server" Text="Save" CssClass="CssBtnSave" Width="100px" /></td>
                                        <td><asp:Button ID="btnClear" runat="server" CssClass="CssBtnClear" Text="Clear" Width="100px" /></td>
                                        <td><asp:Button ID="btnPrint" runat="server" Text="" CssClass="CssBtnPrint" Width="100px" /></td>
                                    </tr>
                                </table>
                                
                            </div>
                        </td>
                    </tr>
                    <tr>
                            <td>
                                <asp:Panel ID="PanelAbout" Width="1000px" runat="server"></asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Content of chield page using nested master page"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:right">
                            <asp:Label ID="Label2" runat="server" Text="Test"></asp:Label></td>
                    </tr>
                    </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Content>

