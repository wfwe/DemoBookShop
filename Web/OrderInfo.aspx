<%@ Page Language="C#" MasterPageFile="~/BuyMaster.Master" AutoEventWireup="true" CodeBehind="OrderInfo.aspx.cs" Inherits="BookShop.Web.OrderInfo" Title="显示用户的所有订单" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
<script type="text/javascript">
    $(document).ready(
        function() {

            $(".m_r").css("width", "710px");
            $(".m_r").css("float", "none");




            $("#dialog-confirm").dialog({
                autoOpen: false,
                resizable: false,
                height: 300,
                width: 500,
                modal: true,
                buttons: {
                    '去支付': function() {
                   
                        window.location = 'PayProcess.aspx?orderid=' + $("#orderNumber").text();
                        // $(this).dialog('close');
                    },
                    '取消': function() {
                        $(this).dialog('close');
                    }
                }
            });

        }

        );


        function OnGoPay(myControl) {

            var number = $(myControl).parent().attr("number");
            var price = $(myControl).parent().attr("price");

            $("#orderNumber").text(number);
            $("#totalMoney").text(price);

            $("#dialog-confirm").dialog('open');
            
            return false;
            
            



        }


</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
<div style="border:solid 4px #aacded;width:710px" >
    <div style="background:#AACDED; text-align:left"><h2>我的订单</h2></div>
     <div align="left">
      <asp:Repeater ID="rptOrderInfo" runat="server">
              <HeaderTemplate>
                            
            <table datasrc="" cellspacing="0" cellpadding="1" width="100%" border="1" style="border:solid 1px #aacded">
              <tbody>
                <tr class="align_Center Thead">
                  <td width="20%">单号</td>
                  <td width="20%">下单时间</td>
                  <td width="15%">价格</td>
                  <td >状态</td>
                  <td width="15%">详细</td>
                      
                </tr>
              </HeaderTemplate>
              <ItemTemplate>
                 
                <tr class="align_Center">
                  <td style="PADDING-BOTTOM: 5px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; PADDING-TOP: 5px"><%#Eval("OrderId") %></td>
                  <td class=align_Left><%#Eval("OrderDate") %>
                 
                    
                      </td>
                  <td><span class="price">￥<%#Eval("TotalPrice") %></span></td>
                  <td><span price='<%#Eval("TotalPrice") %>' number='<%#Eval("OrderId")%>'><%#this.GetOrderState(Convert.ToInt32(Eval("state"))) %></span></td>
                  <td><a href='orderDetail.aspx?orderid=<%#Eval("OrderId") %>'>详细</a></td>
          
            
                </tr>
                
                </ItemTemplate>
                <FooterTemplate>
              </tbody>
            </table>
            </FooterTemplate>
            </asp:Repeater>
     </div>
</div>


<div id="dialog-confirm" title="请选择支付方式"  >	
	<table style="WIDTH: 100%" datasrc="">
              <tbody>
                <tr valign="middle">                 
                  <td style="vertical-align:middle; text-align:left ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img alt="" src="Images/y_zfb.gif" /><input name="zfPay" type="radio" value="zfb" checked="checked" />
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img 
                          alt="" src="Images/unionpay.gif" /><input name="zfPay" 
                          type="radio" value="wyzx"  /></td>
                </tr> 
                <tr>
                <td>
                
                </td>
                </tr>              
              </tbody>
            </table>
            <p></p>
            <p></p>
            <p>定单号:<span id="orderNumber"></span></p>
            <p>支付金额:<span id="totalMoney"></span>元</p>
</div>
</asp:Content>
