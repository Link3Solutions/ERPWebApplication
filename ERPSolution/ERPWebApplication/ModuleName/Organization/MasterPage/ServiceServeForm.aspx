<%@ Page Title="Service Serve" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServiceServeForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Organization.MasterPage.ServiceServeForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width:1190px">
            <table style="width: 100%;margin-top:-13px">
                <tr >
                    <td colspan="3"  >
                        <asp:Panel ID="PanelModule" runat="server" Width="100%" Height="115px">
                            <div style="background-color:#29303B; width:100%;height:115px" >
                                <table style="width: 100%;margin-left:5px;padding-left:5px">
                                    <tr>
                                        <%--<td><div style="width:100px;height:100%"></div></td>--%>
                                        <td><div style="width:700px;height:100%">
                                            <asp:Label ID="lblNameoftheModule" runat="server" Text="Name of the Module" Font-Bold="True" Font-Names="Segoe UI Light" Font-Size="22pt"></asp:Label></div></td>
                                        <td><div style="width:450px;height:100%"></div></td>
                                    </tr>
                                    <tr>
                                        <%--<td><div style="width:100px;height:100%"></div></td>--%>
                                        <td><div style="width:700px;height:45px;border:1px solid gray" >
                                            <asp:Repeater ID="RepeaterModuleDescription" runat="server">
                                                <ItemTemplate>
                                                    <%--<div class="more" style="width:685px;background:#FFFFFF" >--%>
                                                    <div >
                                                        <%# DataBinder.Eval(Container.DataItem, "PackageDescription")%>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            </div></td>
                                        <td><div style="width:450px;height:100%;">
                                            <ol style="list-style-type: none;margin-top:-25px;height:65px;padding-top:5px;margin-left:1px">
                                                <li>
                                                    <asp:Label ID="Label25" runat="server" Text=""></asp:Label></li> 
                                                <li>
                                                                        <asp:Label ID="Label21" runat="server" Text="- Full lifetime access | Articles | Learning Materials"></asp:Label></li>
                                                <li>
                                                    <asp:Label ID="Label22" runat="server" Text="- "></asp:Label></li>
                                                <li>
                                                <asp:Label ID="lblTotalTitle" Width="190px" runat="server" Text="Total"></asp:Label><asp:Label ID="lblTotalVale" Width="75px" Style="text-align: right;" runat="server" Text=""></asp:Label>&nbsp;&nbsp;<asp:Button ID="btnServe" runat="server" CssClass="CssBtnSave" Text="Serve" Width="100px" OnClick="btnServe_Click" />    
                                                </li>
                                            </ol>
                                            </div></td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <%--<td><div style="width:100px;height:100%"></div></td>--%>
                    <td>
                        <div style="width:700px;height:100%">
                            <table style="width: 100%;">
                                <tr>
                                    <td colspan="3">
                                        <asp:Panel ID="PanelSubModuleLogo" runat="server" Height="65px">
                                             <asp:Repeater ID="RepeaterServices" runat="server" >
                                                <ItemTemplate >
         <div class="serviceAreaDIV" style="padding:10px;float:left; width:110px; text-align:left; background-color:White;border:1px solid black;padding-right :10px;padding-top :10px;margin-left:10px;margin-bottom:10px" onmouseover="this.style.background='#4cabd7';" onmouseout="this.style.background='white';" >
             <div  style="width:15px;height:15px;background-image: url('<%#"data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("ServiceLogo")) %>');"> <asp:Label ID="lblStatusAdded" ForeColor="Green" Visible="false" CssClass="labelasHeader2" runat="server" Text="ADDED"></asp:Label></div>
             <div><asp:Label ID="lblServiceName" runat="server"  Text='<%# Eval("ServiceName") %>' ></asp:Label></div>
             <div style="height:10px;text-align:right">
                 <asp:Label ID="lblServiceIDReapeter" runat="server" Visible="false" Text='<%# Eval("ServiceID") %>' ></asp:Label><asp:LinkButton ID="lnkbtnServiceDetails" OnClick="GetValue" Font-Underline="False" CssClass="logoutHover" BackColor="White" Font-Size="Small" runat="server">Details...</asp:LinkButton>
             </div>
         </div>
         </ItemTemplate> 
          <SeparatorTemplate>
          </SeparatorTemplate>
          <FooterTemplate>
          </FooterTemplate>
                                            </asp:Repeater>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Panel ID="PanelModuleDescription" runat="server">
                                            <div style="text-align: left;width: 700px;display: inline-block;border-bottom: 1px solid #808080;padding-bottom:3px">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td><asp:Label ID="lblServiceDescription" runat="server" CssClass="labelasHeader2" Width="270px" Text="Description"></asp:Label></td>
                                                        <td ><asp:Label ID="lblPreviousPrice" CssClass="labelasHeader2" runat="server" style="text-align:right" BackColor="Black" Width="120px" ForeColor="White" Font-Overline="False" Font-Strikeout="True" ></asp:Label></td>
                                                        <td><asp:Label ID="lblPrice" CssClass="labelasHeader2" style="text-align:right" runat="server" BackColor="Black" Width="120px" ForeColor="White" ></asp:Label></td>
                                                        <td><asp:Button ID="btnTakeService" runat="server" CssClass="CssBtnAddNew" Text="Take This Service" Width="170px" OnClick="btnTakeService_Click" /></td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div style="overflow:auto; height:260px;text-align: left;width: 700px;display: inline-block">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:Repeater ID="RepeaterServiceDescription" runat="server">
                                                                <ItemTemplate>
                                                                    <div style="width:99%;height:99%">
                                                                    <%# DataBinder.Eval(Container.DataItem, "ServiceDescription")%>
                                                                        </div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:Repeater ID="RepeateNodeCollection" runat="server">
                                                                <ItemTemplate>
                                                                    <div>
                                                                    <div style="width:99%;height:30px">
                                                                    <%# DataBinder.Eval(Container.DataItem, "ActivityName")%>
                                                                        </div>
                                                                    <div style="width:99%;height:100%">
                                                                    <%# DataBinder.Eval(Container.DataItem, "FormDescription")%>
                                                                        </div>
                                                                        </div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div style="overflow:auto; height:2px;text-align: left;width: 700px;display: inline-block"></div>
                                            <div style="overflow:auto; text-align: left;width: 690px;display: inline-block;padding-left:10px;border:0px solid gray;padding-top:3px;padding-bottom:3px;background-color:#91B5CF;">
                                                Other Packages
                                            </div>
                                            <div style="min-height:401px;text-align: left;width: 700px;display: inline-block">
                                                <asp:Repeater ID="RepeaterOtherPackages" runat="server">
                                                    <ItemTemplate>
                                                        <div  style="padding:10px;float:left; width:120px; height:150px; text-align:left;background-color:#041624;border:1px solid black;padding-right :10px;padding-top :10px;margin-left:10px;margin-bottom:10px" onmouseover="this.style.background='#053041';" onmouseout="this.style.background='#041624';" >
                                                        <div  style="width:15px;height:15px;background-image: url('<%#"data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("PackageLogo")) %>');"> 
                                                            <br> 
                                                            </br>
                                                            <br></br><asp:Button ID="btnOtherModuleName1" runat="server" Text='<%# Eval("PackageName") %>' CssClass="CssBtnModuleName" Width="115px" Font-Bold="True" Font-Size="Larger" ForeColor="#333333" OnClick="btnOtherModuleName1_Click"   />
                                                            
                                                        </div>
                                                            </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td style="vertical-align:top">
                        <div style="width:390px;height:100%;vertical-align:top">
                            <asp:Panel ID="PanelSelectedServices" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td colspan="3">
                                            <asp:GridView ID="grdSelectedServices" runat="server" Width="388px" AutoGenerateColumns="False" OnRowDataBound="grdSelectedServices_RowDataBound" OnRowCommand="grdSelectedServices_RowCommand" OnRowDeleting="grdSelectedServices_RowDeleting">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Service">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label29" Width="200px" runat="server" Text='<%# Bind("colServiceName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Value">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcolServiceValue" runat="server" Text='<%# Eval("colServiceValue","{0:N2}") %>' Width="75px" Style="text-align: right;" ></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ServiceID">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcolServiceID" Width="15px" runat="server" Text='<%# Bind("colServiceID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ShowDeleteButton="True" ControlStyle-Width="15px" ControlStyle-Height="15px" ControlStyle-BorderStyle="None" DeleteImageUrl="~/Images/RemoveServices.png" ButtonType="Image" >
                                                    <ControlStyle BorderStyle="None" Height="15px" Width="15px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:CommandField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSelectedSerciceID" Visible="false" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
                </div>
        </ContentTemplate>
        <Triggers></Triggers>
    </asp:UpdatePanel>
</asp:Content>
