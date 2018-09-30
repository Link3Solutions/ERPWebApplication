<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTree.master" AutoEventWireup="true" CodeBehind="PeopleInfoForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.People.PeopleInfoForm" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContentTree" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td colspan="3">
                        <div style="position:fixed;width:900px;height:50px;margin-top:-12px;background-color:#FFFFFF">
                        <table style="width: 100%;  border-bottom-style: solid;border-bottom-width: 1px; border-bottom-color: #7F7F7F;  border-top-color: #7F7F7F; border-top-width: 1px;border-top-style: solid;">
                            <tr>
                                <td><asp:Label ID="lblGridTitle" runat="server" Width="100%"></asp:Label></td>
                                <td>
                                    &nbsp;</td>
                                <td style="text-align:right">
                                    <asp:Button ID="btnCancel" runat="server" CssClass="CssBtnCancel" OnClick="btnCancel_Click" Text="Cancel" Width="100px" />
                                </td>
                                <td style="text-align:right;width:110px">
                                    <asp:Button ID="btnAddNew" CssClass="CssBtnAddNew" runat="server" Text="Add New" Width="100px" OnClick="btnAddNew_Click" /></td>
                            </tr>
                        </table>
                            </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        </td>
                </tr>
                <tr>
                    <td colspan="3">
                        </td>
                </tr>
                <tr>
                    <td colspan="3">
                        </td>
                </tr>
                <tr>
                    <td colspan="3">
                        </td>
                </tr>
                <tr>
                    <td colspan="3">
                        </td>
                </tr>
                <tr>
                    <td colspan="3">
                        </td>
                </tr>
                <tr>
                    <td colspan="3">
                        </td>
                </tr>
                <tr>
                    <td colspan="3">
                        </td>
                </tr>
                <tr>
                    <td colspan="3">
                        </td>
                </tr>
                <tr>
                    <td colspan="3">
                        </td>
                </tr>
                <tr >
                    <td colspan="3">
                        <asp:Panel ID="PanelDataEntry" runat="server">
                            <table style="width: 100%;">
                                <tr>
                                    <td colspan="7">
                                        <table style="width:100%;margin-top:-5px">
                                            <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Type" Width="100px"></asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td>
                                        <asp:DropDownList ID="DropDownList5" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="Category"></asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td style="text-align:right">
                                        <asp:DropDownList ID="DropDownList6" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                            <tr>
                                    <td style="width:100px">
                                        <asp:Label ID="Label7" runat="server" Text="Name"></asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td style="width:300px">
                                        <asp:TextBox ID="txtPeopleName" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="width:200px">&nbsp;</td>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="DOB"></asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td style="text-align:right">
                                        <asp:TextBox ID="txtPeopleEmail" runat="server" TextMode="Date"></asp:TextBox>
                                    </td>
                                </tr>
                                        </table>
                                        </td>
                                    </tr>
                                
                                
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="7">
                                        <table style="width: 100%;  border-bottom-style: solid;border-bottom-width: 1px; border-bottom-color: #7F7F7F;  border-top-color: #7F7F7F; border-top-width: 1px;border-top-style: solid;">
                            <tr>
                                <td>
                                    <asp:Button ID="btnAddNewAcademicRecord" CssClass="CssBtnAddNew" runat="server" Text="Add Academic Qualification" Width="215px" OnClick="btnAddNewAcademicRecord_Click"  />
                                </td>
                                <td >
                                    </td>
                                <td style="text-align:right">
                                    &nbsp;</td>
                                <td style="text-align:right;width:110px">
                                    </td>
                            </tr>
                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="7">
                                        <asp:Panel ID="PanelAcademicRecord" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label67" runat="server" Text="Name Of Degree" Width="100px"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td><asp:TextBox ID="txtNameOfDegree" runat="server"  Columns="3"></asp:TextBox></td>
                                                    <td>
                                                        <asp:Label ID="Label12" runat="server" Visible="False"></asp:Label>
                                                    </td>
                                                    <td><asp:Label ID="Label130" runat="server" Text="Major in/Group"></asp:Label></td>
                                                    <td>:</td>
                                                    <td style="text-align:right"><asp:TextBox ID="txtMajor" runat="server" ></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td style="width:100px"><asp:Label ID="Label68" runat="server" Text="Institution Name"></asp:Label></td>
                                                    <td>:</td>
                                                    <td style="width:300px"><asp:TextBox ID="txtInstitutionName" runat="server" ></asp:TextBox></td>
                                                    <td style="width:150px">&nbsp;</td>
                                                    <td style="width:170px"><asp:Label ID="Label70" runat="server" Text="Results Grade/Division"></asp:Label></td>
                                                    <td>:</td>
                                                    <td style="text-align:right"><asp:TextBox ID="txtResultsGradeDivision" runat="server" Width="250px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td><asp:Label ID="Label69" runat="server" Text="Board/University"></asp:Label></td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtBoardUniversity" runat="server" ></asp:TextBox>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                    <td><asp:Label ID="Label71" runat="server" Text="Passing Year"></asp:Label></td>
                                                    <td>:</td>
                                                    <td style="text-align:right"><asp:TextBox ID="txtPassingYear" runat="server"  onkeypress="return isNumberKey(event)"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td style="text-align:right">
                                                        <asp:Button ID="btnCancelAcademicRecord" runat="server" CssClass="CssBtnCancel" OnClick="btnCancelAcademicRecord_Click" Text="Cancel" Width="100px" />
                                                        <asp:Button ID="btnAddAcademicRecordToGrid" CssClass="CssBtnAddNew" Width="100px" runat="server" Text="Add New" OnClick="btnAddAcademicRecordToGrid_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="7">
                                        <asp:GridView ID="grdAcademicRecords" runat="server" AutoGenerateColumns="False" EmptyDataText="No record" Width="100%" OnRowCommand="grdAcademicRecords_RowCommand" OnRowDeleting="grdAcademicRecords_RowDeleting" OnRowDataBound="grdAcademicRecords_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="SL">
                                        <ItemTemplate>
                                            <%# Container.DisplayIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="txtNameOfDegree" HeaderText="Name Of Degree" />
                                    <asp:BoundField DataField="txtInstitutionName" HeaderText="Institution Name" />
                                    <asp:BoundField DataField="txtBoardUniversity" HeaderText="Board/University" />
                                    <asp:BoundField DataField="txtMajor" HeaderText="Major in/Group" />
                                    <asp:BoundField DataField="txtResultsGradeDivision" HeaderText="Result Grade/Division" />
                                    <asp:BoundField DataField="txtPassingYear" HeaderText="Passing Year" />                                    
                                    <asp:CommandField ShowSelectButton="True">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:CommandField>
                                    <asp:CommandField ShowDeleteButton="True" />
                                </Columns>
                            </asp:GridView>
                                    </td>
                                </tr>
                                 </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        </td>
                </tr>
                <tr>
                    <td colspan="3">
                        </td>
                </tr>
                <tr>
                    <td colspan="3">
                        </td>
                </tr>
                <tr>
                    <td colspan="3">
                        </td>
                </tr>
                <tr>
                    <td colspan="3">
                        </td>
                </tr>
                <tr>
                    <td colspan="3">
                        </td>
                </tr>
                <tr>
                    <td colspan="3">
                        </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Panel ID="PanelSearchHeader" runat="server">
                            <asp:ImageButton ID="imgBtnSearch" runat="server" ImageUrl="~/images/collapse.jpg" Height="15px" Width="15px" />
                                                                            <div style="margin-left: 30px; margin-top: -25px">
                                                                                <asp:Label ID="lblSearchHeaderTab1" runat="server" Text="Search" Width="100px" Height="15px"></asp:Label>
                                                                            </div>
                             </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Panel ID="PanelSearchDetails" runat="server" >
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Select"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Select"></asp:Label>
                                    </td>
                                    <td><asp:Label ID="Label4" runat="server" Text="Select"></asp:Label></td>
                                    <td><asp:Label ID="Label5" runat="server" Text="Select"></asp:Label></td>
                                    <td rowspan="2" style="text-align:center;vertical-align:bottom">
                                        <asp:Button ID="btnSearch" runat="server" CssClass="CssBtnSearch" Text="Search" Width="100px" OnClick="btnSearch_Click" /> </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlSearch1" runat="server" Width="190px"></asp:DropDownList></td>
                                    <td><asp:DropDownList ID="ddlSearch2" runat="server" Width="190px"></asp:DropDownList></td>
                                    <td><asp:DropDownList ID="ddlSearch3" runat="server" Width="190px"></asp:DropDownList></td>
                                    <td><asp:DropDownList ID="ddlSearch4" runat="server" Width="190px"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server"  Enabled="true"
                                            TargetControlID="PanelSearchDetails"
                                            ExpandControlID="PanelSearchHeader"
                                            CollapseControlID="PanelSearchHeader"
                                            ExpandDirection="Vertical"
                                            Collapsed="true"
                                            AutoCollapse="False"
                                            AutoExpand="false"
                                            ExpandedImage="~/images/collapse.jpg"
                                            CollapsedImage="~/images/expand.jpg"
                                            ImageControlID="imgBtnSearch" />
                    </td>
                </tr>
                
                <tr>
                    <td colspan="3">
                        <asp:Panel ID="PanelPeopleRecord" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="Gray" >
                        <table style="width:100%;">
                            <tr>
                    <td colspan="3" style="padding-left:5px">
                        <asp:Panel ID="PanelSearchToGrid" runat="server">
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width:300px">
                                        <asp:Label ID="lblSearchinGrid" runat="server" Text="Type to search in grid"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtSearchInGrid" runat="server" onkeyup="callForSearch();" Width="100%"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                            <tr>
                    <td colspan="3" style="padding-left:5px">
                        <asp:GridView ID="grdPeople" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="grdPeople_RowCommand" OnRowDeleting="grdPeople_RowDeleting">
                            <Columns>
                                    <asp:TemplateField HeaderText="SL">
                                        <ItemTemplate>
                                            <%# Container.DisplayIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="txtNameOfDegree" HeaderText="Name" />
                                    <asp:BoundField DataField="txtInstitutionName" HeaderText="Designation" />
                                    <asp:BoundField DataField="txtBoardUniversity" HeaderText="Department" />
                                    <asp:BoundField DataField="txtMajor" HeaderText="Email" />
                                    <asp:BoundField DataField="txtResultsGradeDivision" HeaderText="DOB" />
                                    <asp:BoundField DataField="txtPassingYear" HeaderText="Contact No." />                                    
                                    <asp:CommandField ShowSelectButton="True">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:CommandField>
                                    <asp:CommandField ShowDeleteButton="True" />
                                </Columns>
                        </asp:GridView>
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
        </ContentTemplate>
        <Triggers></Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript" >
        function callForSearch() {
            var searchText = document.getElementById("<%=txtSearchInGrid.ClientID %>").value.toUpperCase();
            var gvDrv = document.getElementById("<%=grdPeople.ClientID %>");
            for (i = 1; i < gvDrv.rows.length; i++) {
                if (searchText == "") {
                    gvDrv.rows[i].style.display = '';
                }
                else {
                    if ((gvDrv.rows[i].cells[0].innerHTML).toString().match(searchText) ||
                    (gvDrv.rows[i].cells[1].innerHTML).toString().toUpperCase().match(searchText) ||
                    (gvDrv.rows[i].cells[2].innerHTML).toString().toUpperCase().match(searchText) ||
                    (gvDrv.rows[i].cells[3].innerHTML).toString().toUpperCase().match(searchText) ||
                    (gvDrv.rows[i].cells[4].innerHTML).toString().toUpperCase().match(searchText) ||
                    (gvDrv.rows[i].cells[5].innerHTML).toString().toUpperCase().match(searchText)
                        ) {
                        gvDrv.rows[i].style.display = '';
                    }
                    else {
                        gvDrv.rows[i].style.display = "none";
                    }
                }
            }
        }
    </script>
</asp:Content>
