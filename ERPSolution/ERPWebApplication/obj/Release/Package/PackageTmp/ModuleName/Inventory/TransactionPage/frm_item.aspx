<%@ Page Title="Item Requisition" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frm_item.aspx.cs" Inherits="ERPWebApplication.ModuleName.Inventory.TransactionPage.frm_item" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div id="wrapper" style="margin: 0 auto">

        <asp:UpdatePanel ID="uppnl1" runat="server">

            <ContentTemplate>


                <table class="auto-style2" id="tblmas" style="margin-top:-0.25em" runat="server">
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td>
                           
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td>
                            <table class="auto-style2" id="tblsearch" runat="server">
                                <tr>
                                    <td class="auto-style6">
                                        <table style="height:10px">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="pnlsearch" runat="server" Width="945px">
                                                        <table class="auto-style2" style="background-color:#7AC0DA;Width:920px">
                                                            <tr >
                                                                <td>

                                                                 <asp:ImageButton ID="header_ToggleImage1" runat="server" Height="17px" ImageUrl="~/images/collapse.jpg" /></td>
                                                                <td style ="color:white"><asp:Label ID="Label11" runat="server" Text="Search Requisition"  Font-Size="20px" Width="456px"></asp:Label></td>
                                                            </tr>
                                                           
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>

                                    <td class="auto-style9">

                                        <asp:Panel ID="pnlsearchrequisition" runat="server">

                                            <table class="auto-style2">
                                                <tr>
                                                    <td class="auto-style68">&nbsp;</td>
                                                    <td class="auto-style26">&nbsp;</td>
                                                    <td class="auto-style27">
                                                        <asp:TextBox ID="TextBox1" runat="server" Width="282px"></asp:TextBox>
                                                    </td>
                                                    <td class="auto-style30">
                                                        <asp:Button ID="btnsearch" runat="server" Text="Search" />
                                                    </td>
                                                    <td class="auto-style31">
                                                        <asp:Button ID="btnadvsearch" runat="server" Text="Advanced Search" OnClick="btnadvsearch_Click" />
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:Panel>


                                        <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender5" runat="Server"
                                            TargetControlID="pnlsearchrequisition"
                                            ExpandControlID="pnlsearch"
                                            CollapseControlID="pnlsearch"
                                            ExpandDirection="Vertical"
                                            Collapsed="true"
                                            SuppressPostBack="true"
                                            ExpandedImage="~/images/collapse.jpg"
                                            CollapsedImage="~/images/expand.jpg"
                                            ImageControlID="header_ToggleImage1" />



                                        <table class="auto-style2" style="width: 950px">
                                            <tr>
                                                <td style="width: 960px">
                                                    <hr id="searchbottom" runat="server" style="border-style: none; border-color: inherit; border-width: 0; background-position: 0% 0%; height: 1px; background-image: linear-gradient(to right, #ccc, #333, #ccc); width: 918px; margin-right: 50px; background-color: #333; background-repeat: repeat; background-attachment: scroll;" />
                                                </td>
                                            </tr>
                                        </table>

                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <%-- <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>--%>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td>
                            <table class="auto-style2" id="tbladvsearch" runat="server">
                                <tr>
                                    <td class="auto-style45">&nbsp;</td>
                                    <td class="auto-style17" style="text-align:right">
                                        <asp:Label ID="Label2" runat="server" Text="Ref.NO " CssClass="label"></asp:Label>
                                        :</td>
                                    <td class="auto-style18">
                                        <asp:TextBox ID="txtrequisitionid" runat="server" Width="220px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style23">
                                        <asp:Label ID="Label5" runat="server" Text="From Date:" CssClass="label"></asp:Label>
                                    </td>
                                    <td class="auto-style18">
                                        <asp:TextBox ID="txtrequisitionid1" runat="server" Width="220px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="imgbtnadsearch" runat="server" Height="15px" ImageUrl="~/Images/collapse.jpg" OnClick="imgbtnadsearch_Click" Style="width: 15px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style19"></td>
                                    <td class="auto-style20" style="text-align:right">
                                        <asp:Label ID="Label3" runat="server" Text="Item Name: " CssClass="label"></asp:Label>
                                    </td>
                                    <td class="auto-style21">
                                        <asp:TextBox ID="txtrequisitionid0" runat="server" Width="220px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style24">
                                        <asp:Label ID="Label6" runat="server" Text="To Date:" CssClass="label"></asp:Label>
                                    </td>
                                    <td class="auto-style21">
                                        <asp:TextBox ID="txtrequisitionid2" runat="server" Width="220px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style22">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style45">&nbsp;</td>
                                    <td class="auto-style17" style="text-align:right">
                                        <asp:Label ID="Label4" runat="server" Text="Item Name: " CssClass="label"></asp:Label>
                                    </td>
                                    <td >
                                        <asp:DropDownList ID="DropDownList1" runat="server" Width="225px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style23">&nbsp;</td>
                                    <td class="auto-style18">
                                        <asp:Button ID="btnshow" runat="server" Text="Show" OnClick="btnshow_Click" />
                                        &nbsp;<asp:Button ID="btnclearadsearch" runat="server" Text="Clear" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>

                            <table class="auto-style2" style="width: 950px">
                                <tr>
 
                                    <td style="width: 950px">
                                        
                                       <hr id="advsearchbottom" runat="server" style="border:0; height: 1px; background: #333;  background-image: linear-gradient(to right, #ccc, #333, #ccc); width: 918px; margin-right: 50px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <%--<tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>--%>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td>
                            <table class="auto-style2" id="tbladvsearchresult" runat="server">
                                <tr>
                                    <td class="auto-style35">&nbsp;</td>
                                    <td class="auto-style50">&nbsp;</td>
                                    <td class="auto-style34">
                                        <asp:Panel ID="Panel1" runat="server" Height="105px" ScrollBars="Vertical" Style="overflow: auto; width: 750px; text-align: center;">
                                            <asp:GridView ID="GridView2"  CssClass="myGridClass" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Width="100%" CellPadding="3" Style="text-align: left">
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle ForeColor="#000066" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                                            </asp:GridView>

                                        </asp:Panel>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>

                            <table class="auto-style2" style="width: 950px">
                                <tr>
                                    <td style="width: 950px">
                                        

                                        <hr id="headertop" runat="server" style="border:0; height: 1px; background: #333;  background-image: linear-gradient(to right, #ccc, #333, #ccc); width: 918px; margin-right: 50px" />

                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>&nbsp;</td>
                    </tr>

                    <%--  <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>--%>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td>
                            <table class="auto-style2">
                                <tr>
                                    <td class="auto-style60">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td class="auto-style61">&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btnnewReq" runat="server" Text="New Requisition" OnClick="btnnewReq_Click" />
                                        &nbsp;<asp:Button ID="btnprintrequisition" runat="server" Text="Print" />
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td>
                            <table class="auto-style2">
                                <tr>
                                    <td class="auto-style44">&nbsp;</td>
                                    <td class="auto-style42">
                                        <asp:Label ID="lblreqstatus" runat="server" CssClass="label" Text="Requisition Status:"></asp:Label>
                                    </td>
                                    <td class="auto-style40">
                                        <asp:Label ID="lblstatus1" runat="server"></asp:Label>
                                    </td>
                                    <td class="auto-style38"><strong>Request Date:</strong></td>
                                    <td class="auto-style48">
                                        <asp:TextBox ID="TextBox4" runat="server" Width="196px"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style44">&nbsp;</td>
                                    <td class="auto-style42">
                                        <asp:Label ID="lblreqstatus0" runat="server" Text="Request by:" CssClass="auto-style47"></asp:Label>
                                    </td>
                                    <td class="auto-style40">
                                        <asp:TextBox ID="TextBox2" runat="server" Width="220px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style38"><strong>Date needed:</strong></td>
                                    <td class="auto-style48">
                                        <asp:TextBox ID="TextBox5" runat="server" Width="196px"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style44">&nbsp;</td>
                                    <td class="auto-style42">
                                        <asp:Label ID="lblreqstatus1" runat="server" Text="Requesting dept." CssClass="auto-style47"></asp:Label>
                                    </td>
                                    <td class="auto-style40">
                                        <asp:DropDownList ID="DropDownList2" runat="server" Width="225px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style38"><strong>Priority:</strong></td>
                                    <td class="auto-style48">
                                        <asp:DropDownList ID="DropDownList5" runat="server" Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style44">&nbsp;</td>
                                    <td class="auto-style42">
                                        <asp:Label ID="lblreqstatus2" runat="server" Text="Item User Type:" Style="font-weight: 700"></asp:Label>
                                    </td>
                                    <td class="auto-style40">
                                        <asp:DropDownList ID="DropDownList3" runat="server" Width="225px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style38"><strong>Purpose:</strong></td>
                                    <td class="auto-style48">
                                        <asp:DropDownList ID="DropDownList6" runat="server" Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style44">&nbsp;</td>
                                    <td class="auto-style42">
                                        <asp:Label ID="lblreqstatus3" runat="server" Text="User Name:" Style="font-weight: 700"></asp:Label>
                                    </td>
                                    <td class="auto-style40">
                                        <asp:TextBox ID="TextBox3" runat="server" Width="220px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style38">
                                        <asp:Label ID="Label7" runat="server" Text="Reference Type::" CssClass="auto-style47"></asp:Label></td>
                                    <td class="auto-style48">
                                        <asp:DropDownList ID="DropDownList7" runat="server" Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style44">&nbsp;</td>
                                    <td class="auto-style42">
                                        <asp:Label ID="lblreqstatus4" runat="server" Text="Location of use:" Style="font-weight: 700"></asp:Label>
                                    </td>
                                    <td class="auto-style40">
                                        <asp:DropDownList ID="DropDownList4" runat="server" Width="225px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style38">
                                        <asp:Label ID="Label8" runat="server" Text="Reference No.:" CssClass="auto-style47"></asp:Label></td>
                                    <td class="auto-style48">
                                        <asp:TextBox ID="TextBox6" runat="server" Width="196px"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style44">&nbsp;</td>
                                    <td class="auto-style42">
                                        <asp:Label ID="lblreqstatus5" runat="server" Text="Location address:" Style="font-weight: 700"></asp:Label>
                                    </td>
                                    <td class="auto-style40" rowspan="3" style="vertical-align: top">
                                        <asp:TextBox ID="TextBox15" runat="server" Width="219px" TextMode="MultiLine" Height="66px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style38">
                                        <asp:Label ID="Label9" runat="server" Text="Is project related?:" CssClass="auto-style47"></asp:Label></td>
                                    <td class="auto-style48">
                                        <asp:CheckBox ID="chk1" runat="server" AutoPostBack="True" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style44">&nbsp;</td>
                                    <td class="auto-style42">&nbsp;</td>
                                    <td class="auto-style38">
                                        <asp:Label ID="lbl1" runat="server" Text="Select a project " CssClass="label"></asp:Label>
                                        :</td>
                                    <td class="auto-style48">
                                        <asp:DropDownList ID="DropDownList8" runat="server" Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style44">&nbsp;</td>
                                    <td class="auto-style42">&nbsp;</td>
                                    <td class="auto-style38">
                                        <asp:Label ID="Label10" runat="server" Text="File upload:" CssClass="auto-style47"></asp:Label></td>
                                    <td class="auto-style48">
                                        <asp:FileUpload ID="FileUpload1" runat="server" Width="196px" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style44">&nbsp;</td>
                                    <td class="auto-style42" style="vertical-align: top"><strong>Comments:</strong></td>
                                    <td class="auto-style39" colspan="3">

                                        <table class="auto-style2">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="TextBox16" runat="server" Width="602px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>

                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>


                            <table class="auto-style2" style="width: 950px">
                                <tr>
                                    <td style="width: 950px">
             
                                        <hr id="headerbottom" runat="server" style="border:0; height: 1px; background: #333;  background-image: linear-gradient(to right, #ccc, #333, #ccc); width: 918px; margin-right: 50px" />

                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <%-- <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>--%>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td>
                            <table class="auto-style2" id="tblauthorization" runat="server">
                                <tr>
                                    <td class="auto-style66">&nbsp;</td>
                                    <td class="auto-style62">
                                        <asp:Label ID="lblreqstatus12" runat="server" CssClass="auto-style47" Text="This requisition will be forward to"></asp:Label>
                                    </td>
                                    <td class="auto-style63">
                                        <asp:DropDownList ID="ddlforwardto" CssClass="" runat="server" Width="194px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style64">
                                        <asp:Button ID="btnedit" runat="server" Text="Enable" />
                                    </td>
                                    <td class="auto-style65">
                                        <asp:Label ID="lblreqstatus13" runat="server" CssClass="auto-style47" Text="for Authorization"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" Width="65px" />
                                    </td>
                                </tr>
                            </table>


                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td>
                            <table class="auto-style2" id="tblitemdet" runat="server">
                                <tr>
                                    <td class="auto-style49">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Panel ID="pnl" runat="server" Height="151px" ScrollBars="Vertical" Style="overflow: auto; width: 750px; text-align: center;">
                                            <asp:GridView ID="GridView3" runat="server" CssClass="myGridClass">
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <%--<tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>--%>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td>
                            <table class="auto-style2">
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table class="auto-style2" >
                                                        <tr>
                                                            <td>
                                                                <asp:Panel ID="header_HeaderPanel" runat="server" Width="945px">
                                                                   <table class="auto-style2" style="background-color:#7AC0DA; Width:920px"">
                                                            <tr>
                                                                <td class="auto-style69">


                                                                 <asp:ImageButton ID="header_ToggleImage3" runat="server" Height="17px" ImageUrl="~/images/collapse.jpg" /></td>
                                                                <td style ="color:white"><asp:Label ID="Label1" runat="server" Text="Add Item Information"  Font-Size="20px" Width="456px" style="margin-left: 0px"></asp:Label></td>
                                                            </tr>
                                                           
                                                        </table>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td>
                            <asp:Panel ID="header_ContentPanel" runat="server">

                                <table class="auto-style2">
                                    <tr>
                                        <td class="auto-style55">&nbsp;</td>
                                        <td class="auto-style57">
                                            <asp:Label ID="lblreqstatus6" runat="server" CssClass="auto-style47" Text="Item Name:"></asp:Label>
                                        </td>
                                        <td class="auto-style18">
                                            <asp:TextBox ID="txtItem" runat="server" Width="220px"></asp:TextBox>
                                        </td>
                                        <td class="auto-style59">&nbsp;</td>
                                        <td class="auto-style51">
                                            <asp:Label ID="lblreqstatus9" runat="server" CssClass="auto-style47" Text="Specification:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSpec" runat="server" Width="196px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style55">&nbsp;</td>
                                        <td class="auto-style57">
                                            <asp:Label ID="lblreqstatus7" runat="server" CssClass="auto-style47" Text="Quantity:"></asp:Label>
                                        </td>
                                        <td class="auto-style18">
                                            <asp:TextBox ID="txtQunt" runat="server" Width="220px"></asp:TextBox>
                                        </td>
                                        <td class="auto-style59">&nbsp;</td>
                                        <td class="auto-style51">
                                            <asp:Label ID="lblreqstatus10" runat="server" CssClass="auto-style47" Text="Brand:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBrand" runat="server" Width="196px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style55">&nbsp;</td>
                                        <td class="auto-style57">
                                            <asp:Label ID="lblreqstatus8" runat="server" CssClass="auto-style47" Text="Unit:"></asp:Label>
                                        </td>
                                        <td class="auto-style18">
                                            <asp:TextBox ID="txtLoc" runat="server" Width="220px"></asp:TextBox>
                                        </td>
                                        <td class="auto-style59">&nbsp;</td>
                                        <td class="auto-style51">
                                            <asp:Label ID="lblreqstatus11" runat="server" CssClass="auto-style47" Text="Origin:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOrigin" runat="server" Width="196px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style55">&nbsp;</td>
                                        <td class="auto-style57">&nbsp;</td>
                                        <td class="auto-style18">&nbsp;</td>
                                        <td class="auto-style59">&nbsp;</td>
                                        <td class="auto-style51">&nbsp;</td>
                                        <td>
                                            <asp:Button ID="btnadd" runat="server" Text="Add" OnClick="btnadd_Click" />
                                            &nbsp;<asp:Button ID="btnclear" runat="server" Text="Clear" />
                                        </td>
                                    </tr>
                                </table>

                            </asp:Panel>


                            <ajaxToolkit:CollapsiblePanelExtender ID="cpeheader" runat="Server"
                                TargetControlID="header_ContentPanel"
                                ExpandControlID="header_HeaderPanel"
                                CollapseControlID="header_HeaderPanel"
                                ExpandDirection="Vertical"
                                Collapsed="true"
                                SuppressPostBack="true"
                                ExpandedImage="~/images/collapse.jpg"
                                CollapsedImage="~/images/expand.jpg"
                                ImageControlID="header_ToggleImage3" />



                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>


            </ContentTemplate>
        </asp:UpdatePanel>


    </div>

</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style2 {
            width: 81%;
        }

        .auto-style5 {
            width: 25px;
        }

        .auto-style6 {
        }

        .auto-style9 {
        }

        .auto-style17 {
            width: 113px;
        }

        .auto-style18 {
            width: 228px;
        }

        .auto-style19 {
            width: 40px;
            height: 26px;
        }

        .auto-style20 {
            width: 113px;
            height: 26px;
        }

        .auto-style21 {
            width: 228px;
            height: 26px;
        }

        .auto-style22 {
            height: 26px;
        }

        .auto-style23 {
            width: 112px;
            text-align: right;
        }

        .auto-style24 {
            height: 26px;
            width: 112px;
            text-align: right;
        }

        .auto-style26 {
            width: 101px;
            text-align: right;
        }

        .auto-style27 {
            width: 222px;
        }

        .auto-style30 {
            width: 61px;
        }

        .auto-style31 {
            width: 281px;
        }

        .auto-style34 {
            width: 227px;
        }

        .auto-style35 {
            width: 9px;
        }

        .auto-style38 {
            width: 137px;
            text-align: right;
        }

        .auto-style39 {
        }

        .auto-style40 {
            width: 237px;
        }

        .auto-style42 {
            width: 148px;
            text-align: right;
        }

        .auto-style44 {
            width: 6px;
        }

        .auto-style45 {
            width: 40px;
        }

        .auto-style47 {
            font-weight: bold;
        }

        .auto-style48 {
            width: 204px;
        }

        .auto-style49 {
            width: 8px;
        }

        .auto-style50 {
            width: 1px;
        }

        .auto-style51 {
            width: 72px;
        }

        .auto-style55 {
            width: 46px;
        }

        .auto-style57 {
            width: 92px;
        }

        .auto-style59 {
            width: 76px;
        }

        .auto-style60 {
            width: 4px;
        }

        .auto-style61 {
            width: 542px;
        }

        .auto-style62 {
            width: 227px;
            text-align: right;
        }

        .auto-style63 {
            width: 194px;
        }

        .auto-style64 {
            width: 60px;
        }

        .auto-style65 {
            width: 120px;
        }

        .auto-style66 {
            width: 54px;
        }

        .auto-style68 {
            width: 57px;
        }

        .auto-style69 {
            width: 13px;
        }
    </style>
</asp:Content>


