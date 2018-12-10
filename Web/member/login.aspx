<%@ Page Language="C#" MasterPageFile="~/member/MasterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="BookShop.Web.member.login" Title="无标题页" %>
<%@ Register src="../Control/UserLogin.ascx" tagname="UserLogin" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UserLogin ID="UserLogin1" runat="server" />

</asp:Content>
