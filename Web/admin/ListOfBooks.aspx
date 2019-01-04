<%@ Page Language="C#" MasterPageFile="~/admin/adminMasterPage.Master" AutoEventWireup="true" CodeBehind="ListOfBooks.aspx.cs" Inherits="BookShop.Web.admin.ListOfBooks" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="server">
    <asp:GridView ID="gvBooks" runat="server" AllowPaging="True" 
    AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" 
    BorderStyle="Solid" BorderWidth="3px" CellPadding="4" DataKeyNames="id" 
    DataSourceID="ObjectDataSource1" ForeColor="Black" 
    OnRowDataBound="gvBooks_RowDataBound" Width="98%" CellSpacing="2" EnableModelValidation="True">
    <Columns>
        <asp:TemplateField Visible="False">
            <ItemTemplate>
                <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Title" HeaderText="书名" />
        <asp:BoundField DataField="Author" HeaderText="作者" />
        <asp:TemplateField HeaderText="类别">
            <ItemTemplate>
                <asp:Label ID="lblCategory" runat="server" 
                    Text='<%# Eval("Category.Name") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="False" HeaderText="删除">
            <ItemTemplate>
                <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="False" 
                    CommandName="Delete" Text="删除"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="#CCCCCC" />
    <RowStyle BackColor="White" />
    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
</asp:GridView>
<br />
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    DeleteMethod="Delete" SelectMethod="GetModelList" 
    TypeName="BookShop.BLL.BookManager" OnSelecting="ObjectDataSource1_Selecting">
    <DeleteParameters>
        <asp:Parameter Name="Id" Type="Int32" />
    </DeleteParameters>
    <SelectParameters>
        <asp:Parameter Name="strWhere" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
</asp:Content>
