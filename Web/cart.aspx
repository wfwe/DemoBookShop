<%@ Page Language="C#" MasterPageFile="~/BuyMaster.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="BookShop.Web.cart" Title="购书商城" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

    $(function() {
		$("#dialog-message").dialog({
		  autoOpen: false,
			modal: true,
			buttons: {
				确定: function() {
					$(this).dialog('close');
				}
			}
		});
		
		TotalMoney();
	});
	
	function ShowErrorMessage(){
	$("#dialog-message").dialog('open');

	}

//更新购物车中商品的数量，operator:表示操作符，bookId：书的编号，根据该编号很容易的获取文本框.
//PkId:cart数据表中主键，根据它来跟新具体的购物车中的商品项
 function changeBar(operator,bookId,PkId){
     
      var $control=$("#txtCount"+bookId);//得到文本框
       if(operator=='-'){//表示减法
        var count=$control.val();//获取文本框中的数量.
        count=count-1;//数量减1、
        if(count<1){
         //  alert("数量最少为1");
         $("#errorMessage").text("数量最少为1");
         ShowErrorMessage();
           return;
        
        }else{
            $control.val(count);//将减1后的结果重新赋给文本框.
            
        }
      }else if(operator=='+'){
           var count=$control.val();
           count=parseInt(count)+1;//"+":字符连接，加法。parseInt：转成整数.
           if(count>999){
             $("#errorMessage").text("最多只能买999");
         ShowErrorMessage();
          
            return;
           }
           else
           {
                $control.val(count);
           }
      } 
      
      //向服务端发送请求，更新数据库中的数量.
      $.post("/ashx/processCart.ashx",{
                      "action":"change",
                      "pk":PkId,
                      "count":count,
                      "bookId":bookId
                          },function(data){
                                if(data=="yes"){
                                  TotalMoney();
                                }
                              
                        },"text");
      
      
      
      //更新购物车列表中显示的商品的总价格。
      
 
 }
 //手都更新文本框的数量.
 function changeTextOnBlur(pkId,bookId,control){
   var count= $(control).val();
   var reg=/^\d{1,3}$/;//数字的正则表达式
   if(reg.test(count))//判读文本框的值是否是数字
   {
//      count=parseInt(count);
//      $(control).val(Number(count));
       if(count>=1&&count<=999){
              //向服务端发送请求，更新数据库中的数量.
      $.post("/ashx/processCart.ashx",{
                      "action":"change",
                      "pk":pkId,
                      "count":count,
                      "bookId":bookId
                          },function(data){
                                if(data=="yes"){
                                  TotalMoney();
                                }
                                
                              
                        },"text");
      
       }
   }
   else
   {
      
       $("#errorMessage").text("只能输入数字!");
         ShowErrorMessage();
         //用户输入的是非数字，弹出错误提示，并且文本框中的内容恢复到默认值.
           $(control).val(inputTxt);
   }
 
 }
 
 //文本框获取焦点时执行该方法，在该方法中获取文本框中最原始的值.
 var inputTxt;
   function changeTxtOnFocus(control){
      
   inputTxt=$(control).val();
   }
 
 //删除一条记录
 //pkId:要删除购物车表中的主键
 //control:a 标签
 function removeProductOnShoppingCart(pkId,control)
 {
     //1:给出一个提示对话框，询问是否要删除
     if(confirm("你确定要删除该项吗?"))
     {
         $.post("/ashx/processCart.ashx",{"action":"delete","pk":pkId},function(data){
           if(data=="yes"){
              $(control).parent().parent().remove();
              TotalMoney();
           
           }else if(data=="no"){
            
           $("#errorMessage").text("删除失败!");
         ShowErrorMessage();
           }else{
           
                $("#errorMessage").text("出现了异常!");
         ShowErrorMessage();
           }
         
         },"text");
     }
     
     //2:如果要删除，向服务端发送请求(processCart.ashx): pkId,action:delete
     //3:在服务端完成删除操作
     //4:将商品项所在的数据行移除.
     
 }
 
 //计算购物车中所有商品的总的价格
 function TotalMoney(){
  var totalPrice=0;//初始值必须有值.
    $(".align_Center:gt(0)").each(//查找到现实购物商品的行，然后进行遍历。
      function(){
         var price=$(this).find(".price").text();//找到该行样式名称为price的span标记拿到它的值.
         var count=$(this).find("input").val();//获取该行文本框的值.
         totalPrice=totalPrice+(price*count);//完成总价格的计算
      
      }
    
    );
 
   $("#totleMoney").text(totalPrice);
 }

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <table cellpadding="0" cellspacing="0"  width="98%" align="center">
        <tr>
            <td colspan="2">
                <img height="27" 
                    src="images/shop-cart-header-blue.gif" width="206" /><img alt="" 
                    src="Images/png-0170.png" /><asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl="~/myorder.aspx">我的订单</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" width="98%">
          
                <table  cellpadding='0' cellspacing='0' width='100%' >
 <tr class='align_Center Thead'>
    <td width='7%' style='height:30px'>图片</td>
    <td>图书名称</td>
    <td width='14%'>单价</td>
    <td width='11%'>购买数量</td>
    <td width='11%'>删除图书</td>
 </tr>

              <asp:Repeater ID="RepeaterCart" runat="server">
              <ItemTemplate>
              <!--一行数据的开始 -->
             
<tr class='align_Center'>
   <td style='padding:5px 0 5px 0;'><img src='<%#Eval("Book.ISBN","images/bookcovers/{0}.jpg") %>' width="40" height="50" border="0" /></td>
   <td class='align_Left'><%#Eval("Book.Title") %></td>
   <td>
   &yen;<span class='price'><%#Eval("Book.UnitPrice","{0:0.00}") %></span></td>
   <td><a href='#none' title='减一' onclick='changeBar("-",<%#Eval("Book.Id") %>,<%#Eval("Id") %>)' style='margin-right:2px;' ><img src="Images/bag_close.gif" width="9" height="9" border='none' style='display:inline' /></a>
     <input type='text' id='<%#Eval("Book.Id","txtCount{0}") %>' name='<%#Eval("Book.Id","txtCount{0}") %>' maxlength='3' style='width:30px' onKeyDown='if(event.keyCode == 13) event.returnValue = false' value='<%#Eval("Count") %>' onfocus='changeTxtOnFocus(this);' onblur='changeTextOnBlur(<%#Eval("Id") %>,<%#Eval("Book.Id") %>,this);' />
     <a href='#none' title='加一' onclick='changeBar("+",<%#Eval("Book.Id") %>,<%#Eval("Id") %>)' style='margin-left:2px;' ><img src='/images/bag_open.gif' width="9" height="9" border='none' style='display:inline' /></a>   </td>
   <td>
   <a href='#none' id='btn_del_1000357315' onclick='removeProductOnShoppingCart(<%#Eval("Id") %>,this)' >
       删除</a></td>
</tr>
<!--一行数据的结束 -->
              
              </ItemTemplate>
                    </asp:Repeater>
         



 <tr>
    <td class='align_Right Tfoot' colspan='5' style='height:30px'>&nbsp;</td>
 </tr>
</table>
</td>
        </tr>
        <tr>
            <td style="text-align: center">
                &nbsp;&nbsp;&nbsp; 商品金额总计：<span ID="totleMoney" 
                   >0</span>元</td>
            <td>
                &nbsp;
               <a href="booklist.aspx"> <img alt="" src="Images/gobuy.jpg" width="103" height="36" border="0" /> </a><a href="OrderConfrim.aspx"><img src="images/balance.gif" 
                     border="0" /></a>
              
            </td>
        </tr>
    </table>
    <div id="dialog-message" title="出错啦!!!">
	<p>
		<span id="errorMessage" style="font-size:12px;color:Red"></span>
	</p>
	
</div>


</asp:Content>
