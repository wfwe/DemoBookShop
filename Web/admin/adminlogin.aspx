<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="BookShop.Web.admin.adminlogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>网站后台登录</title>
    <link href="../Css/login.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: silver">
    <form id="form1" runat="server">
    <div id="Layer1">
        <img src="../Images/di-admini.gif" width="444" height="261" border="0" usemap="#Map" />            
    </div>
    <div id="Layer2">      
        <asp:TextBox runat="server" ID="txtLoginId"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtLoginId" Display="Dynamic" ErrorMessage="用户名必须填写">*</asp:RequiredFieldValidator>
    </div>
    <div id="Layer3">  
        <asp:TextBox runat="server" ID="txtLoginPwd" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtLoginPwd" Display="Dynamic" ErrorMessage="请输入密码！" 
            SetFocusOnError="True">*</asp:RequiredFieldValidator>
    </div>
    <div id="Layer5">
        <asp:ImageButton runat="server" ID="imgbtnSure" ImageUrl="../Images/qd.gif" 
            OnClick="imgb_Sure_Click" style="width: 62px" />
    </div>
    <div id="Layer6">
        <asp:ImageButton runat="server" ID="imgbtnCancel" ImageUrl="../Images/cz.gif" OnClick="imgb_Cancel_Click" /><span style="font-size:14px;color:red"><%=Msg %></span>
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ShowMessageBox="True" ShowSummary="False" />
    </form>
</body>
</html>
