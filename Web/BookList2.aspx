<%@ Page Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="BookList2.aspx.cs"   Inherits="BookShop.Web.BookList2" Title="图书列表" %>
<%@ Register src="Control/PageData.ascx" tagname="PageData" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
<div class="contentstyle">
            <div id="divOrder">
            <div style="MARGIN: 20px 0px; TEXT-ALIGN: left">排序方式： 
                <asp:Button class="anniu" 
                    style="BORDER-RIGHT: seagreen 1px solid; BORDER-TOP: seagreen 1px solid; FONT-WEIGHT: normal; FONT-SIZE: 12px; BORDER-LEFT: seagreen 1px solid;  COLOR: black; BORDER-BOTTOM: seagreen 1px solid; HEIGHT: 16px; BACKGROUND-COLOR: #c0ffc0" 
                    Text="出版日期↑" runat="server" ID="PublishData" onclick="PublishData_Click" 
                    Height="39px" 
                    ></asp:Button> 
                | <input class="anniu"  style="BORDER-RIGHT: seagreen 1px solid; BORDER-TOP: seagreen 1px solid; FONT-WEIGHT: normal; FONT-SIZE: 12px; BORDER-LEFT: seagreen 1px solid; WIDTH: 57px; COLOR: black; BORDER-BOTTOM: seagreen 1px solid; HEIGHT: 16px; BACKGROUND-COLOR: #c0ffc0" type="submit" value="<%=orderPrice %>"  name="UntpriceDesc" /></div></div></div>
    <asp:Repeater ID="RepeaterList" runat="server" EnableViewState="false" >
    <ItemTemplate>
    <table>
                    <tbody>
                    <tr>
                      <td rowSpan=2><A href='<%#Eval("Id","/BookDetail.aspx?id={0}") %>'><img 
                        style="CURSOR: hand" height="121"  border="0"
                        alt='<%#Eval("Title") %>' hspace="4" 
                        src='<%#Eval("ISBN","/ashx/ImageMark.ashx?isbn={0}") %>' width="95"></A> 
</td>
                      <td style="FONT-SIZE: small; COLOR: red" width=650><A 
                        class="booktitle" id="link_prd_name" 
                        href='<%#Eval("Id","/BookDetail.aspx?id={0}") %>' target="_blank" 
                        name="link_prd_name"><%#Eval("Title") %></A> </td></tr>
                    <tr>
                      <td align=left><SPAN 
                        style="FONT-SIZE: 12px; LINE-HEIGHT: 20px">
                        <%#Eval("Author") %>
                        </SPAN><BR><BR><SPAN 
                        style="FONT-SIZE: 12px; LINE-HEIGHT: 20px"><%#this.CutString(Eval("Contentdescription").ToString(),150)%></SPAN> 
                      </td></tr>
                    <tr>
                      <td align=right colSpan=2><SPAN 
                        style="FONT-WEIGHT: bold; FONT-SIZE: 13px; LINE-HEIGHT: 20px">&yen;<%#Eval("UnitPrice","{0:0.00}")%> <%#Eval("PublishDate","{0:yyyy-MM-dd}") %></SPAN> </td></tr></tbody></table>
    </ItemTemplate>
    <SeparatorTemplate>
    <hr />
    </SeparatorTemplate>
    </asp:Repeater>
    <div class=contentstyle 
            style="MARGIN: 20px 0px; TEXT-ALIGN: left">
        
         <uc1:PageData ID="PageData2" runat="server" />
        
         </div>
</asp:Content>
