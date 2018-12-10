<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showinfo.aspx.cs" Inherits="BookShop.Web.showinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
    </style>
    
    <script type="text/javascript">
      window.onload=function(){
        
          setTimeout(ChangeTime, 1000); //setInterval();
      
      }
      function ChangeTime(){
       var time=document.getElementById("txtNum").innerHTML;//得到数字
       time--;
       if(time>0){
          document.getElementById("txtNum").innerHTML=time;
          setTimeout(ChangeTime,1000);
        
       
       }else{
       //获取服务端控件的ID属性值时，一定要通过<%=HyperLink1.ClientID%>
        var url= document.getElementById("<%=HyperLink1.ClientID%>").href;//HyperLink生成的是a标签。href
        window.location=url;//完成跳转
       }
       
      
      }
      
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>  
      <table width="490" height="325" border="0" align="center" cellpadding="0" cellspacing="0" background="Images/showinfo.png">
      <tr>
        <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="50">&nbsp;</td>
            <td>&nbsp;</td>
            <td width="40">&nbsp;</td>
          </tr>
          <tr>
            <td width="50">&nbsp;</td>
            <td style="text-align: center">
                <asp:Label ID="Label1" runat="server" ForeColor="#CC0000" Width="98%"></asp:Label>
              </td>
            <td width="40">&nbsp;</td>
          </tr>
          <tr>
            <td width="50">&nbsp;</td>
            <td>&nbsp;</td>
            <td width="40">&nbsp;</td>
          </tr>
          <tr>
            <td width="50" class="style1">&nbsp;</td>
            <td style="text-align: center">
               <span id="txtNum" style="font-size:16px;color:Red; font-weight:bold">5</span>秒中以后跳转到
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/booklist.aspx">返   回</asp:HyperLink>
                                </td>
            <td width="40">&nbsp;</td>
          </tr>
        </table></td>
      </tr>
    </table>
    </div>
    </form>
</body>
</html>