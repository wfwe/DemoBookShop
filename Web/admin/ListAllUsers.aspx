<%@ Page Language="C#" MasterPageFile="~/admin/adminMasterPage.Master" AutoEventWireup="true" CodeBehind="ListAllUsers.aspx.cs" Inherits="BookShop.Web.admin.ListAllUsers" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="ObjectDataSource1" CellPadding="3" ForeColor="Black" 
        GridLines="Vertical" Height="500px" onrowdatabound="GridView1_RowDataBound" DataKeyNames="Id" 
        onrowdeleting="GridView1_RowDeleting" 
    onrowupdating="GridView1_RowUpdating" onrowcommand="GridView1_RowCommand" 
    Width="98%" AllowPaging="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" EnableModelValidation="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" 
                ReadOnly="True" />
            <asp:BoundField DataField="LoginId" HeaderText="登录名" SortExpression="LoginId" 
                ReadOnly="True" />
            <asp:BoundField DataField="Name" HeaderText="姓名" SortExpression="Name" >
           
            </asp:BoundField>
            <asp:BoundField DataField="Address" HeaderText="地址" SortExpression="Address" />
            <asp:BoundField DataField="Phone" HeaderText="电话" SortExpression="Phone" />
            <asp:BoundField DataField="Mail" HeaderText="邮件" SortExpression="Mail" />
       
            <asp:TemplateField ShowHeader="False" HeaderText="重置">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" 
                        CommandName="resetpwd" Text="密码" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                </ItemTemplate>
                <EditItemTemplate></EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
            <asp:TemplateField ShowHeader="False" HeaderText="删除">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="False" 
                        CommandName="Delete" Text="删除" ></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="#CCCCCC" />
    </asp:GridView>
    
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="BookShop.Model.User"
        SelectMethod="GetModelList" TypeName="BookShop.BLL.UserManager" DeleteMethod="DeleteModel" UpdateMethod="Update" 
      >
    
         <SelectParameters>
            <asp:QueryStringParameter ConvertEmptyStringToNull="False" DefaultValue="" 
                Name="strWhere" QueryStringField="" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    <br />
</asp:Content>
