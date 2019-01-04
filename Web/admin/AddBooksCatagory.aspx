<%@ Page Language="C#" MasterPageFile="~/admin/adminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddBooksCatagory.aspx.cs" Inherits="BookShop.Web.admin.AddBooksCatagory" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="server">
    <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
        CellPadding="4" DataKeyNames="id" DataSourceID="odsCategories" 
        ForeColor="Black" Width="777px" CellSpacing="2" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="Name" HeaderText="分类名称" SortExpression="Name" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
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
