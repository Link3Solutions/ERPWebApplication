<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ERPWebApplication.WebForm2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<%--<html xmlns="http://www.w3.org/1999/xhtml">--%>
<html lang="en">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
	<script src="Scripts/jquery.contextMenu.js" type="text/javascript"></script>
	<link href="jquery.contextMenu.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <div id="MyTreeDiv">
                <asp:TreeView ID="MyTreeView" runat="server" ExpandDepth="0">
                    <Nodes>
                        <asp:TreeNode Text="node1" Value="f2571858-0eff-4260-9935-2f53d8e1bcd0">
                            <asp:TreeNode Text="node10" Value="c1ddc0fc-c170-4a74-8de3-f1e85fdb2615">
                             <asp:TreeNode Text="node100" Value="c2532e51-704f-45e9-abc7-f8a2a7b1f422"></asp:TreeNode>
                            <asp:TreeNode Text="node101" Value="d47ce54e-1c2b-45af-b767-e610f05e0960"></asp:TreeNode>
                            <asp:TreeNode Text="node102" Value="faa99883-4996-4ac4-afa1-a197df615a0b"></asp:TreeNode>
                            <asp:TreeNode Text="node103" Value="7c49a861-c253-49c4-86a5-9b1789187f80"></asp:TreeNode>
                            <asp:TreeNode Text="node104" Value="42def2d5-ae7a-4746-8223-63f762de058a"></asp:TreeNode>
                            <asp:TreeNode Text="node105" Value="ea0051a0-1122-432e-977b-46ef1e58f9c4"></asp:TreeNode>
                            </asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="node2" Value="bcb02fd7-d2fa-430a-b004-1d5f8e481a9f">
                            <asp:TreeNode Text="node20" Value="42516600-21c3-4866-9d45-7e42e82997c4"></asp:TreeNode>
                            <asp:TreeNode Text="node21" Value="3802be53-69c7-4e45-85e6-863cabea238a"></asp:TreeNode>
                            <asp:TreeNode Text="node22" Value="e99019d4-243e-454d-a761-0b214a4bd893"></asp:TreeNode>
                            <asp:TreeNode Text="node23" Value="4cbc3de2-18c0-43da-b65d-493f9a84243e"></asp:TreeNode>
                            <asp:TreeNode Text="node24" Value="7a211df9-6ed5-4198-b5ab-665f39069541"></asp:TreeNode>
                            <asp:TreeNode Text="node25" Value="862dc876-8b92-437d-9947-833faea03ce4"></asp:TreeNode>
                        </asp:TreeNode>
                    </Nodes>
                </asp:TreeView>
            </div>
        <ul id="myMenu" class="contextMenu">
            <li class="copy"><a href="#add">Add</a></li>
			<li class="edit"><a href="#edit">Edit</a></li>	
			<li class="delete"><a href="#delete">Delete</a></li>
			<li class="quit separator"><a href="#cancel">Cancel</a></li>
		</ul>
                </ContentTemplate>
            <Triggers></Triggers>
            </asp:UpdatePanel>
    </form>
</body>
     <script type="text/javascript">

         $(document).ready(function () {
             $("#MyTreeDiv A").contextMenu({
                 menu: 'myMenu'
             }, function (action, el, pos) {
                 alert(
                     'Action: ' + action + '\n\n' +
                     'Element text: ' + $(el).text() + '\n\n' +
                     'GUID: ' + getGUID($(el).attr("href")) + '\n\n' +
                     'X: ' + pos.x + '  Y: ' + pos.y + ' (relative to element)\n\n' +
                     'X: ' + pos.docX + '  Y: ' + pos.docY + ' (relative to document)'
                     );
             });
         });
         //end document Ready


         //GUID s\\48e8d94d-e6eb-4b4d-a70f-4c82c3e42630
         // s\\81694dbe-548d-4921-87eb-f6be61ab7dfb\\778c071f-b419-428b-aecb-68b561c25164
         function getGUID(mystr) {
             var reGUID = /\w{8}[-]\w{4}[-]\w{4}[-]\w{4}[-]\w{12}/g //regular expression defining GUID
             var retArr = [];
             var retval = '';
             retArr = mystr.match(reGUID);
             if (retArr != null) {
                 retval = retArr[retArr.length - 1];
             }
             return retval;
         }
		</script>
</html>
