<%@ Page Language="C#" MasterPageFile="~/admin/adminMasterPage.Master" AutoEventWireup="true" CodeBehind="ListOfBooks.aspx.cs" Inherits="BookShop.Web.admin.ListOfBooks" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="server">
    <asp:GridView ID="gvBooks" runat="server" AllowPaging="True" 
    AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
    BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id" 
    DataSourceID="ObjectDataSource1" ForeColor="Black" GridLines="Vertical" 
    OnRowDataBound="gvBooks_RowDataBound" Width="98%">
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
        <asp:HyperLinkField DataNavigateUrlFields="id" 
            DataNavigateUrlFormatString="ListOfBooks_BookDetail.aspx?id={0}" Text="详细" />
        <asp:TemplateField ShowHeader="False" HeaderText="删除">
            <ItemTemplate>
                <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="False" 
                    CommandName="Delete" Text="删除"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="#CCCC99" />
    <RowStyle BackColor="#F7F7DE" />
    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>
<br />
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    DeleteMethod="Delete" SelectMethod="GetModelList" 
    TypeName="BookShop.BLL.BookManager">
    <DeleteParameters>
        <asp:Parameter Name="Id" Type="Int32" />
    </DeleteParameters>
    <SelectParameters>
        <asp:Parameter Name="strWhere" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
</asp:Content>
