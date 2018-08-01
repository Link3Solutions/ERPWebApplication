<%@ Page Title="User Permission" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPermissionForm.aspx.cs" Inherits="ERPWebApplication.ModuleName.Organization.MasterPage.UserPermissionForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <ajaxToolkit:TabContainer ID="TabContainerUserPermission" runat="server" Width="1160px" Height="100%" ActiveTabIndex="0" CssClass="tab" CssTheme="None">
                            <ajaxToolkit:TabPanel ID="TabPanelRoleSetup" runat="server" HeaderText="Role Setup" Width="1160px">
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="text-align: left; float: left; width: 500px">
                                                <div style="overflow: auto; height: 450px;">
                                                    <asp:TreeView ID="TreeViewAllNode" runat="server" OnTreeNodePopulate="TreeViewAllNode_TreeNodePopulate" 
                                                        ShowCheckBoxes="All" NodeIndent="15" ShowExpandCollapse="False">
                                                        <ParentNodeStyle Font-Bold="True" />
                                                        <RootNodeStyle Font-Bold="True" />
                                                    </asp:TreeView>
                                                </div>
                                            </td>
                                            <td style="text-align: left; float: left; width: 435px">
                                                <div style="height:450px;padding-left:15px">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label7" runat="server" Text="Company"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCompanyForRole" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompanyForRole_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" Text="Role Type"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlRoleType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRoleType_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text="Role Title"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtRoleTitle" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:GridView ID="GridViewRoles" runat="server" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GridViewRoles_RowDataBound" OnRowCommand="GridViewRoles_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="SL">
                                                                        <ItemTemplate>
                                                                            <%# Container.DisplayIndex + 1 %>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Role ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRoleID" runat="server" Text='<%# Bind("RoleID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Role Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRoleName" runat="server" Text='<%# Bind("RoleName") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Role Type ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRoleTypeID" runat="server" Text='<%# Bind("RoleTypeID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:CommandField ShowSelectButton="True" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                                    </div>
                                            </td >
                                            <td style="text-align: right; float: right; width: 150px;">
                                                <div style="height: 450px;width:150px;position: fixed;margin-top:-1px;margin-right:-1px;">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td><asp:Button ID="btnRoleSave" runat="server" CssClass="CssBtnSave" Width="70px" Text="Save" OnClick="btnRoleSave_Click" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Button ID="btnRoleClear" runat="server" CssClass="CssBtnClear" Width="70px" Text="Clear" OnClick="btnRoleClear_Click" /></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanelUserPermission" runat="server" HeaderText="User Permission" Width="1160px">
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                 <div style="width:400px">
                                                 <table style="width: 100%;">
                                                     <tr>
                                                         <td>
                                                             <asp:Label ID="Label6" runat="server" Text="Company"></asp:Label>
                                                         </td>
                                                         <td>:</td>
                                                         <td>
                                                             <asp:DropDownList ID="ddlCompany" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged">
                                                             </asp:DropDownList>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td>
                                                             <asp:Label ID="Label3" runat="server" Text="User Code"></asp:Label>
                                                         </td>
                                                         <td>:</td>
                                                         <td>
                                                             <asp:TextBox ID="txtUserCode" runat="server" AutoPostBack="True" OnTextChanged="txtUserCode_TextChanged"></asp:TextBox>
                                                             <ajaxToolkit:AutoCompleteExtender ID="txtUserCode_AutoCompleteExtender" runat="server" BehaviorID="_content_txtUserCode_AutoCompleteExtender" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem2" DelimiterCharacters="" MinimumPrefixLength="1" ServiceMethod="GetUserId" ServicePath="~/WebService/ServiceSystem.asmx" TargetControlID="txtUserCode">
                                                             </ajaxToolkit:AutoCompleteExtender>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td>
                                                             <asp:Label ID="Label5" runat="server" Text="Role Type" Width="60px"></asp:Label>
                                                         </td>
                                                         <td>:</td>
                                                         <td>
                                                             <asp:DropDownList ID="ddlRoleTypeUser" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRoleTypeUser_SelectedIndexChanged">
                                                             </asp:DropDownList>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td>
                                                             <asp:Label ID="Label4" runat="server" Font-Underline="False" Text="Role list"></asp:Label>
                                                         </td>
                                                         <td>:</td>
                                                         <td>&nbsp;</td>
                                                     </tr>
                                                 </table>
                                                     </div>
                                                 </td>
                                             <td>
                                                 <div style="width:600px">
                                                     <table style="width: 100%;">
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
                                             <td style="width:95px">
                                                 <div style="width:85px;float:right;position: fixed; background-color: white;margin-top:-72px; margin-right:1px">
                                                    <table style="width: 100%; margin-left: 13px">
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btnSave" runat="server" CssClass="CssBtnSave" Text="Save" Width="70px" OnClick="btnSave_Click" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btnClear" runat="server" CssClass="CssBtnClear" Text="Clear" Width="70px" OnClick="btnClear_Click" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btnPrint" runat="server" CssClass="CssBtnPrint" Text="Print" Width="70px" /></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                             </td>
                                            </tr>
                                        <tr>
                                             <td colspan="3">
                                                 <div style="width:950px">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:ListBox ID="ListBoxRoles" runat="server" Height="220px" Width="200px"></asp:ListBox>
                                                        </td>
                                                        <td>
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td>
                                                                        <asp:ImageButton ID="ingbtnForword" runat="server"  Width="17px" Height="17px" ImageUrl="~/Images/forward.png" OnClick="ingbtnForword_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:ImageButton ID="imgbtnForwordAll" runat="server" OnClick="imgbtnForwordAll_Click" Width="17px" Height="17px" ImageUrl="~/Images/forwardAll.png" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:ImageButton ID="imgbtnBack" runat="server" Width="17px" Height="17px" ImageUrl="~/Images/backward.png" OnClick="imgbtnBack_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:ImageButton ID="imgbtnBackAll" runat="server" Width="17px" Height="17px" ImageUrl="~/Images/backwardAll.png" OnClick="imgbtnBackAll_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <asp:ListBox ID="ListBoxSelectedRoles" runat="server" AutoPostBack="True" Height="220px" Width="200px"></asp:ListBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            <asp:ListBox ID="ListBoxRelatedUserRole" Height="220px" Width="200px" runat="server"></asp:ListBox>
                                                        </td>
                                                        <td>
                                                            <table style="width:100%;">
                                                                <tr>
                                                                    <td>
                                                                        <asp:ImageButton ID="imgbtnForwordUserRole" Width="17px" Height="17px" runat="server" ImageUrl="~/Images/forward.png" OnClick="imgbtnForwordUserRole_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:ImageButton ID="imgbtnForwordAllUserRole" runat="server" Width="17px" Height="17px" OnClick="imgbtnForwordAllUserRole_Click" ImageUrl="~/Images/forwardAll.png" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:ImageButton ID="imgbtnBackUserRole" runat="server" Width="17px" Height="17px" OnClick="imgbtnBackUserRole_Click" ImageUrl="~/Images/backward.png" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:ImageButton ID="imgbtnBackAllUserRole" runat="server" Width="17px" Height="17px" ImageUrl="~/Images/backwardAll.png" OnClick="imgbtnBackAllUserRole_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <asp:ListBox ID="ListBoxSelectedRelatedUserRole" Height="220px" Width="200px" runat="server"></asp:ListBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td colspan="3">&nbsp;</td>
                                                    </tr>
                                                </table>
                                                     </div>
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
        <Triggers></Triggers>
    </asp:UpdatePanel>
    <script  type="text/javascript">
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
