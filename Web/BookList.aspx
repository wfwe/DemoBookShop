<%@ Page Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="BookList.aspx.cs"   Inherits="BookShop.Web.BookList" Title="图书列表" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
<DIV class=contentstyle>
            <DIV id=divOrder>
            <DIV style="MARGIN: 20px 0px; TEXT-ALIGN: left">排序方式： <asp:Button class="anniu" 
                    style="BORDER-RIGHT: seagreen 1px solid; BORDER-TOP: seagreen 1px solid; FONT-WEIGHT: normal; FONT-SIZE: 12px; BORDER-LEFT: seagreen 1px solid; WIDTH: 57px; COLOR: black; BORDER-BOTTOM: seagreen 1px solid; HEIGHT: 16px; BACKGROUND-COLOR: #c0ffc0" 
                    Text="出版日期↑" runat="server" ID="PublishData" onclick="PublishData_Click" ></asp:Button> 
            | <INPUT class="anniu"  style="BORDER-RIGHT: seagreen 1px solid; BORDER-TOP: seagreen 1px solid; FONT-WEIGHT: normal; FONT-SIZE: 12px; BORDER-LEFT: seagreen 1px solid; WIDTH: 57px; COLOR: black; BORDER-BOTTOM: seagreen 1px solid; HEIGHT: 16px; BACKGROUND-COLOR: #c0ffc0" type="submit" value="<%=orderPrice %>"  name="UntpriceDesc"></DIV></DIV></DIV>
    <asp:Repeater ID="RepeaterList" runat="server" EnableViewState="false" >
    <ItemTemplate>
    <TABLE>
                    <TBODY>
                    <TR>
                      <TD rowSpan=2><A href='<%#Eval("Id","/BookDetail.aspx?id={0}") %>'><IMG 
                        style="CURSOR: hand" height="121"  border="0"
                        alt='<%#Eval("Title") %>' hspace="4" 
                        src='<%#Eval("ISBN","/Images/BookCovers/{0}.jpg") %>' width="95"></A> 
</TD>
                      <TD style="FONT-SIZE: small; COLOR: red" width=650><A 
                        class="booktitle" id="link_prd_name" 
                        href='<%#Eval("Id","/BookDetail.aspx?id={0}") %>' target="_blank" 
                        name="link_prd_name"><%#Eval("Title") %></A> </TD></TR>
                    <TR>
                      <TD align=left><SPAN 
                        style="FONT-SIZE: 12px; LINE-HEIGHT: 20px">
                        <%#Eval("Author") %>
                        </SPAN><BR><BR><SPAN 
                        style="FONT-SIZE: 12px; LINE-HEIGHT: 20px"><%#this.CutString(Eval("ContentDescription").ToString(),150)%></SPAN> 
                      </TD></TR>
                    <TR>
                      <TD align=right colSpan=2><SPAN 
                        style="FONT-WEIGHT: bold; FONT-SIZE: 13px; LINE-HEIGHT: 20px"><%#Eval("UnitPrice","{0:C}")%> <%#Eval("PublishDate","{0:yyyy-MM-dd}") %></SPAN> </TD></TR></TBODY></TABLE>
    </ItemTemplate>
    <SeparatorTemplate>
    <hr />
    </SeparatorTemplate>
    </asp:Repeater>
    <DIV class=contentstyle 
            style="MARGIN: 20px 0px; TEXT-ALIGN: left">第<asp:Label ID="lblCurrentPage" runat="server"></asp:Label> 页 共 <asp:Label ID="lblPageCount" runat="server"></asp:Label> 页> 
        <asp:Button class="anniu" 
            style="BORDER-RIGHT: seagreen 1px solid; BORDER-TOP: seagreen 1px solid; FONT-WEIGHT: normal; FONT-SIZE: 12px; BORDER-LEFT: seagreen 1px solid; WIDTH: 57px; COLOR: black; BORDER-BOTTOM: seagreen 1px solid; HEIGHT: 16px; BACKGROUND-COLOR: #c0ffc0" 
            Text="上一页" runat="server" ID="preBtn" onclick="preBtn_Click"></asp:Button>
              <span class="contentstyle" style="MARGIN: 20px 0px; TEXT-ALIGN: left">
              <asp:Button class="anniu"  
            style="BORDER-RIGHT: seagreen 1px solid; BORDER-TOP: seagreen 1px solid; FONT-WEIGHT: normal; FONT-SIZE: 12px; BORDER-LEFT: seagreen 1px solid; WIDTH: 57px; COLOR: black; BORDER-BOTTOM: seagreen 1px solid; HEIGHT: 16px; BACKGROUND-COLOR: #c0ffc0" 
            Text="下一页" runat="server" ID="nextBtn" onclick="nextBtn_Click" ></asp:Button>
          <input type="hidden" name="hiddenCurrentPage" value="<%=currentPage %>" />
          <asp:TextBox ID="GoPageNum" runat="server"></asp:TextBox>
          <asp:Button ID="PageBtn" runat="server" Text="跳转" onclick="PageBtn_Click" />
          <input type="submit" value="上一页" name="btnPre" />
          <input type="submit" value="下一页" name="btnNext" />
          </span></DIV>
</asp:Content>
