<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="ERPWebApplication.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="JS/ContextMenu.js"></script>
    <script src="Scripts/xtreeview.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <div id="div" oncontextmenu="javascript:return oCustomContextMenu.Display(event);">
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
                
        
                </ContentTemplate>
            <Triggers></Triggers>
            </asp:UpdatePanel>
     
    <script type="text/javascript">

        var oCustomContextMenu = null;
        var oBase = null;
        window.onload = function () {
            oBase = document.getElementById('div');

            var Arguments = {
                Base: oBase,
                Width: 200,
                FontColor: null,
                HoverFontColor: null,
                HoverBackgroundColor: null,
                HoverBorderColor: null,
                ClickEventListener: OnClick
            };

            oCustomContextMenu = new CustomContextMenu(Arguments);

            oCustomContextMenu.AddItem('Images/ei0019-48.gif', 'Add', false, 'Add');
            oCustomContextMenu.AddItem('Images/save.png', 'Save', true, 'Save');
            oCustomContextMenu.AddSeparatorItem();
            oCustomContextMenu.AddItem('Images/ei0020-48.gif', 'Update', false, 'Update');
            oCustomContextMenu.AddSeparatorItem();
            oCustomContextMenu.AddItem(null, 'Cancel', false, 'Cancel');
            
        }

        var OnClick = function (Sender, EventArgs) {
            switch (EventArgs.CommandName) {
                case 'Add':
                    alert('Text: ' + EventArgs.Text);
                    alert('IsDisabled: ' + EventArgs.IsDisabled);
                    alert('ImageUrl: ' + EventArgs.ImageUrl);
                    break;
                case 'Save':
                    alert('Text: ' + EventArgs.Text);
                    alert('IsDisabled: ' + EventArgs.IsDisabled);
                    alert('ImageUrl: ' + EventArgs.ImageUrl);
                    break;
                case 'Update':
                    alert('Text: ' + EventArgs.Text);
                    alert('IsDisabled: ' + EventArgs.IsDisabled);
                    alert('ImageUrl: ' + EventArgs.ImageUrl);
                    break;
                case 'Cancel':
                    alert('Text: ' + EventArgs.Text);
                    alert('IsDisabled: ' + EventArgs.IsDisabled);
                    alert('ImageUrl: ' + EventArgs.ImageUrl);
                    break;
            }

            oCustomContextMenu.Hide();
        }

        window.onunload = function () { oCustomContextMenu.Dispose(); }
    </script>
</asp:Content>
