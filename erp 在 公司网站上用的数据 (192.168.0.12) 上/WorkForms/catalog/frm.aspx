<%@ page language="C#" autoeventwireup="true" inherits="WorkForms_catalog_frm, App_Web_g4n3y33j" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>框架</title>
    <script type="text/javascript">
        <asp:Literal runat="server" ID="ltlJs"> </asp:Literal>
    </script>
</head>


<frameset rows="1,*" cols="*" framespacing="0" frameborder="no" border="0" id="mainFrame">
    <frame src="" name="topFrame" scrolling="No" noresize="noresize" id="topFrame" />
    <frameset  cols="260,*" framespacing="0" frameborder="no" border="0" id="menuFrame">
        <frame src="tree.aspx?id=<%=Request.QueryString["id"] %>" name="leftFrame" scrolling="No" noresize="noresize" id="leftFrame" />
        <frame src='body.aspx?id=<%=Request.QueryString["id"] %>' name="bodyFrame" id="bodyFrame" />
    </frameset>
</frameset>

<noframes>
<body>你的浏览器不支持框架
</body>
</noframes>
</html>
