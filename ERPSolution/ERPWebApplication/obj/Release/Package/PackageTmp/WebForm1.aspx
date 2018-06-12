<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TreeViewContextMenu.WebForm1" %>

<!DOCTYPE html>

<html  >
<head id="Head1" runat="server">
    <title>xTreeView</title>
    <style type="text/css">
<!--

.skin0{
position:absolute;
width:140px;
border:2px solid black;
background-color:menu;
font-family:Verdana;
line-height:20px;
cursor:default;
font-size:14px;
z-index:100;
visibility:hidden;
}

.menuitems{
padding-left:10px;
padding-right:10px;
font-family:Verdana;
font-size:12px;
color:black;
}
-->
</style>

</head>
<body>


    <form id="form1" runat="server">
     &nbsp;&nbsp;
        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="176px">
          
                <asp:TreeView ID="TreeView1" runat="server" BackColor="#FFFFC0"  Height="180px" Width="172px">
                <Nodes>
                    <asp:TreeNode Text="Root" Value="sroot">
                        <asp:TreeNode  Text="Parent 1" Value="sParent 1">
                            <asp:TreeNode Text="&lt;b id='b1' oncontextmenu=&quot;return showmenuie5(event)&quot; &gt; this is a test&lt;/b&gt;" Value="sLeaf 1"  ></asp:TreeNode>
                            <asp:TreeNode Text="Leaf 2" Value="sLeaf 2"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="Parent 2" Value="sParent 2">
                            <asp:TreeNode Text="Leaf 1" Value="sLeaf 1"></asp:TreeNode>
                            <asp:TreeNode Text="Leaf 2" Value="sLeaf 2"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
                </Nodes>
            </asp:TreeView>
        </asp:Panel>
        <div>
            &nbsp; &nbsp;
         
            &nbsp; &nbsp;&nbsp; 
         
            
            <asp:Panel ID="Panel2"  runat="server" display:none BorderColor="Black" CssClass="skin0" onMouseover="highlightie5(event)" onMouseout="lowlightie5(event)" onClick="jumptoie5(event)"  >
                <div class="menuitems"><asp:LinkButton ID="LinkButton1" runat="server"   CssClass="menuitems" >New Node</asp:LinkButton></div>
                <div class="menuitems"><asp:LinkButton ID="LinkButton2" runat="server"   CssClass="menuitems">Edit Node</asp:LinkButton></div>
                <hr />
                <div class="menuitems"><asp:LinkButton ID="LinkButton3" runat="server"   CssClass="menuitems">Delete Node</asp:LinkButton></div>
                <hr />
                <div class="menuitems"><asp:LinkButton ID="LinkButton4" runat="server"   CssClass="menuitems">FAQS</asp:LinkButton></div>
                <div class="menuitems"><asp:LinkButton ID="LinkButton5" runat="server"   CssClass="menuitems">Online Help</asp:LinkButton></div>
                <hr />
                <div class="menuitems"><asp:LinkButton ID="LinkButton6" runat="server"   CssClass="menuitems">Email Me</asp:LinkButton></div>
            </asp:Panel>
            <br />
            <a  href=""  > </a>
         </div>
    </form>
    
    
 <script src="Scripts/xtreeview.js"  type="text/javascript"></script>
 
  
</body>
</html>