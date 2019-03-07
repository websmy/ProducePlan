<%@ page language="C#" autoeventwireup="true" inherits="WorkForms_catalog_tree, App_Web_g4n3y33j" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>框架</title>
     <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        <asp:Literal runat="server" ID="ltlJs"> </asp:Literal>
    </script>
    
     <script type="text/javascript">
         function window.onload() {
             var url = '<%=GetBodyUrl() %>';
             if (url != "") {
                 window.parent.bodyFrame.location.href = url;
             }

         }
         function DeleteConfirm() {
             return window.confirm("是否删除此节点？");
         }
    </script>

</head>

<body>
  <form id="form1" runat="server">
        
        
            <asp:ImageButton ID="imgBtnAddNode" runat="server" ImageUrl="../images/addnode.gif" BorderStyle="None" ToolTip="添加项" OnClick="imgBtnAddNode_Click"/><asp:ImageButton 
            ID="imgBtnAddChildNode" runat="server" ImageUrl="../images/addchildnode.gif" BorderStyle="None" ToolTip="添加子项" OnClick="imgBtnAddChildNode_Click" /><asp:ImageButton 
            ID="imgBtnDeleteNode" runat="server" ImageUrl="../images/deletenode.gif" BorderStyle="None"  ToolTip="删除" OnClientClick="return DeleteConfirm();" OnClick="imgBtnDeleteNode_Click" /><asp:ImageButton 
            ID="imgBtnUp" runat="server" ImageUrl="../images/up.gif" BorderStyle="None" ToolTip="上移" OnClick="imgBtnUp_Click"  /><asp:ImageButton 
            ID="imgBtnDown" runat="server" ImageUrl="../images/down.gif" BorderStyle="None" ToolTip="下移" 
            OnClick="imgBtnDown_Click"  />
     
            <asp:TreeView ID="tvType" runat="server">
            </asp:TreeView>
      

    </form>
</body>

</html>
