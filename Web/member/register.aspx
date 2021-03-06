﻿<%@ Page Language="C#" MasterPageFile="~/member/MasterPage.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="BookShop.Web.member.register" Title="购书商城" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">

  <script type="text/javascript">
   $(function(){
     $("#<%=txtName.ClientID%>").blur(CheckName);//添加失去焦点触发的事件
   
   });
   
   function CheckName(){
     var loginId=$("#<%=txtName.ClientID%>").val();//获取用户名
     if(loginId!=""){
       $.post("/ashx/CheckName.ashx",{"LoginId":loginId},function(data){
         if(data=="no"){//表示用户名不存在
         
         }else if(data=="yes"){
       
         }
       
       },"text");
     }else{
      
     }
   }
  
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-size:small">
        <table align="center" border="0" cellpadding="0" cellspacing="0" height="22" 
            width="80%">
            <tr>
                <td style="width: 10px">
                    <img height="28" src="../Images/az-tan-top-left-round-corner.gif" width="10" /></td>
                <td bgcolor="#DDDDCC">
                    <span class="STYLE1">注册新用户</span></td>
                <td width="10">
                    <img height="28" src="../Images/az-tan-top-right-round-corner.gif" width="10" /></td>
            </tr>
        </table>
        <table align="center" border="0" cellpadding="0" cellspacing="0" height="22" 
            width="80%">
            <tr>
                <td bgcolor="#DDDDCC" width="2">
                    &nbsp;</td>
                <td>
                    <div align="center">
                        <table cellpadding="0" cellspacing="0" height="61" style="height: 332px">
                            <tr>
                                <td colspan="6" height="33">
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 26px" valign="top" width="24%">
                                    用户名</td>
                                            <td align="left" style="height: 26px" valign="top" width="37%">
                                                <asp:TextBox ID="txtName" runat="server" Width="178px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                    ControlToValidate="txtName" ErrorMessage="用户名不能为空！" Display="Dynamic">*</asp:RequiredFieldValidator>
                                            <img src="" id="imgCheck" style="display:none" />
                                            
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" height="26" valign="top" width="24%">
                                                真实姓名：</td>
                                            <td align="left" valign="top" width="37%">
                                                <asp:TextBox ID="txtTrueName" runat="server" Width="178px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" height="26" valign="top" width="24%">
                                                密码：</td>
                                            <td align="left" valign="top" width="37%">
                                                <asp:TextBox ID="txtPass" runat="server" Width="178px" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPass" ErrorMessage="密码不能为空！">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" height="26" valign="top" width="24%">
                                                确认密码：</td>
                                            <td align="left" valign="top" width="37%">
                                                <asp:TextBox ID="txtTwoPass" runat="server" Width="178px" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTwoPass" ErrorMessage="确认密码不能为空！"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPass" ControlToValidate="txtTwoPass" ErrorMessage="两次密码输入不一致"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" height="26" valign="top" width="24%">
                                                Email：</td>
                                            <td align="left" valign="top" width="37%">
                                                <asp:TextBox ID="txtEmail" runat="server" Width="178px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                    ControlToValidate="txtEmail" ErrorMessage="邮件格式不正确" 
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" height="26" valign="top" width="24%">
                                                地址：</td>
                                            <td align="left" valign="top" width="37%">
                                                <asp:TextBox ID="txtAddress" runat="server" Width="178px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" height="26" valign="top" width="24%">
                                                手机：</td>
                                            <td align="left" valign="top" width="37%">
                                                <asp:TextBox ID="txtPhone" runat="server" Width="178px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" height="26" valign="top" width="24%">
                                                验证码：</td>
                                            <td align="left" valign="top" width="37%">
                                                <asp:TextBox ID="txtCode" runat="server" Width="178px"></asp:TextBox>
                                               <img src="../ashx/ValidateCode.ashx" id="checkCode" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Button ID="btnRegister" runat="server" Text="注册" CssClass="btn btn-success" OnClick="btnRegister_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                    <div class="STYLE5">
                                        ---------------------------------------------------------</div>
                    </div>
                </td>
                <td bgcolor="#DDDDCC" width="2">
                    &nbsp;</td>
            </tr>
        </table>
        <table align="center" border="0" cellpadding="0" cellspacing="0" height="3" 
            width="80%">
            <tr>
                <td bgcolor="#DDDDCC" height="3">
                    <img height="9" src="../Images/touming.gif" width="27" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
