<%@ Page Language="C#" MasterPageFile="~/admin/adminMasterPage.Master" AutoEventWireup="true" CodeBehind="CheckOrders.aspx.cs" Inherits="BookShop.Web.admin.CheckOrders" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
        BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        DataSourceID="odsOrderSource" GridLines="Vertical" Width="98%" 
    onrowdatabound="GridView1_RowDataBound">
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <Columns>
            <asp:TemplateField HeaderText="定单号" SortExpression="OrderId">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("OrderId") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("OrderId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="OrderDate" HeaderText="定单日期" SortExpression="OrderId" />
            <asp:BoundField DataField="TotalPrice" HeaderText="总价格" 
                SortExpression="TotalPrice" />
            <asp:TemplateField HeaderText="状态" SortExpression="State">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("State") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                <img src='<%# ConvertPic(Eval("State").ToString()) %>' />
                    <asp:Label ID="Label2" runat="server" Text='<%# ConvertState(Eval("State").ToString()) %>'></asp:Label>
                    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="OrderId" 
                DataNavigateUrlFormatString="CheckOrders_orderdetails.aspx?id={0}" HeaderText="查看详细" 
                Text="查看详细" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="Gainsboro" />
    </asp:GridView>
    <asp:ObjectDataSource ID="odsOrderSource" runat="server" 
        SelectMethod="GetModelList" TypeName="BookShop.BLL.OrdersManager">
        <SelectParameters>
            <asp:Parameter Name="strWhere" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

