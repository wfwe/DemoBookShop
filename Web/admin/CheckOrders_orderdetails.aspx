<%@ Page Language="C#" MasterPageFile="~/admin/adminMasterPage.Master" AutoEventWireup="true" CodeBehind="CheckOrders_orderdetails.aspx.cs" Inherits="BookShop.Web.admin.CheckOrders_orderdetails" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" DataSourceID="odsOrderBookSource" GridLines="Vertical" 
        ondatabound="GridView1_DataBound" Width="98%">
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" 
                Visible="False" />
            <asp:BoundField DataField="OrderID" HeaderText="OrderID" 
                SortExpression="OrderID" Visible="False" />
            <asp:TemplateField HeaderText="书  名" SortExpression="BookID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("BookID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Book.Title") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Quantity" HeaderText="数量（本）" 
                SortExpression="Quantity" />
            <asp:BoundField DataField="UnitPrice" HeaderText="单价（元）" 
                SortExpression="UnitPrice" DataFormatString="{0:00.00}" />
            <asp:TemplateField HeaderText="合计"></asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="#DCDCDC" />
    </asp:GridView>
    <br />
    本单总价：<asp:Label ID="lbTotle" runat="server" Text="Label"></asp:Label><asp:Button ID="btnSend" runat="server" Text="审核通过，发货" 
    onclick="btnSend_Click" />
    <asp:ObjectDataSource ID="odsOrderBookSource" runat="server" 
        SelectMethod="GetModelListByOrderId" 
        TypeName="BookShop.BLL.OrderBookManager">
        <SelectParameters>
            <asp:QueryStringParameter Name="orderId" QueryStringField="id" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>

