<%@ Page Language="C#" MasterPageFile="~/admin/adminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddBooksCatagory.aspx.cs" Inherits="BookShop.Web.admin.AddBooksCatagory" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="server">
    <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" DataKeyNames="id" DataSourceID="odsCategories" 
        ForeColor="Black" GridLines="Vertical" Width="777px">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="Name" HeaderText="分类名称" SortExpression="Name" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    新增分类：<asp:TextBox ID="txtCateGory" runat="server"></asp:TextBox>
    &nbsp;
    <asp:Button ID="btnAdd" runat="server" Text="添加" onclick="btnAdd_Click" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
    ControlToValidate="txtCateGory" Display="Dynamic" SetFocusOnError="True">请填写分类</asp:RequiredFieldValidator>
    <br />
  
    
    <asp:ObjectDataSource ID="odsCategories" runat="server" 
        SelectMethod="GetModelList" TypeName="BookShop.BLL.CategoryManager" 
        DeleteMethod="Delete">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:Parameter Name="strWhere" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
</asp:Content>
