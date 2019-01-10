<%@ Page Language="C#" MasterPageFile="~/admin/adminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="BookShop.Web.admin.AddBook" Title="无标题页" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">

    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="server">

    <asp:DetailsView ID="dvAddBook" runat="server" AutoGenerateRows="False"
        DataSourceID="odsAddBook" DefaultMode="Insert" Height="50px" Width="98%"
        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px"
        CellPadding="4"
        OnItemInserting="dvAddBook_ItemInserting"
        OnItemUpdating="dvAddBook_ItemUpdating" CellSpacing="2" EnableModelValidation="True" ForeColor="Black" OnPageIndexChanging="dvAddBook_PageIndexChanging">
        <FooterStyle BackColor="#CCCCCC" />
        <RowStyle BackColor="White" />
        <FieldHeaderStyle Width="20%" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <Fields>
            <asp:TemplateField HeaderText="书名" SortExpression="Title">


                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Title") %>'
                        Width="95%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="TextBox1" ErrorMessage="书名必须填写">*</asp:RequiredFieldValidator>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="类别">
                <InsertItemTemplate>
                    <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="odsCateGory"
                        DataTextField="Name" DataValueField="Id">
                    </asp:DropDownList>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="封面">
                <InsertItemTemplate>

                    <asp:FileUpload ID="FileUpload1" runat="server" Height="22px" Width="293px" />
                    <br />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="作者" SortExpression="Author">

                <InsertItemTemplate>
                    <asp:TextBox ID="txtAuthor" runat="server" Width="95%"
                        Text='<%# Bind("Author") %>' Height="22px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="txtAuthor" ErrorMessage="作者必须填写">*</asp:RequiredFieldValidator>
                </InsertItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="出版日期" SortExpression="PublishDate">

                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox3" Width="95%" runat="server" Text='<%# Bind("PublishDate") %>' onClick="WdatePicker()"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="出版时间填写有误！">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server"
                        ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="出版时间填写有误！"
                        Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
                </InsertItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="出版社">
                <InsertItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="odsPublish"
                        DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
                    </asp:DropDownList>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ISBN" SortExpression="ISBN">

                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox4" Width="95%" runat="server" Text='<%# Bind("ISBN") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ControlToValidate="TextBox4" Display="Dynamic" ErrorMessage="ISBN号必须填写"
                        SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </InsertItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="字数" SortExpression="WordsCount">

                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox5" Width="95%" runat="server" Text='<%# Bind("WordsCount") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ControlToValidate="TextBox5" ErrorMessage="字数必须填写">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server"
                        ControlToValidate="TextBox5" ErrorMessage="字数只能是数字" Operator="DataTypeCheck"
                        SetFocusOnError="True" Type="Integer">*</asp:CompareValidator>
                </InsertItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="单价" SortExpression="UnitPrice">

                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox6" Width="95%" runat="server" Text='<%# Bind("UnitPrice") %>'></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator3" ControlToValidate="TextBox6" runat="server" Display="Dynamic"
                        ErrorMessage="单价格式填写错误" Operator="DataTypeCheck" SetFocusOnError="True"
                        Type="Currency">*</asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                        ControlToValidate="TextBox6" ErrorMessage="单价必须填写" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </InsertItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="内容简介" SortExpression="ContentDescription">

                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Width="95%" TextMode="MultiLine"
                        Text='<%# Bind("ContentDescription") %>' Height="67px"></asp:TextBox>
                </InsertItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="作者介绍" SortExpression="AurhorDescription">

                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox8" Width="95%" runat="server"
                        Text='<%# Bind("AurhorDescription") %>'></asp:TextBox>
                </InsertItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="备注" SortExpression="EditorComment">

                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox9" Width="95%" runat="server" Text='<%# Bind("EditorComment") %>'></asp:TextBox>
                </InsertItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="目录" SortExpression="TOC">

                <InsertItemTemplate>

                    <asp:TextBox ID="TextBox17" runat="server" Width="95%" TextMode="MultiLine"
                        Text='<%# Bind("TOC") %>' Height="67px"></asp:TextBox>

                </InsertItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <InsertItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True"
                        CommandName="Insert" Text="插入" OnClick="LinkButton1_Click"></asp:LinkButton>
                </InsertItemTemplate>

            </asp:TemplateField>
        </Fields>
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <InsertRowStyle Width="80%" />
        <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:DetailsView>
    <asp:ObjectDataSource ID="odsAddBook" runat="server"
        DataObjectTypeName="BookShop.Model.Book" InsertMethod="Add"
        SelectMethod="GetModelList" TypeName="BookShop.BLL.BookManager">
        <SelectParameters>
            <asp:Parameter Name="strWhere" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
        ShowMessageBox="True" ShowSummary="False" />
    <asp:ObjectDataSource ID="odsPublish" runat="server"
        SelectMethod="GetModelList" TypeName="BookShop.BLL.PublisherManager">
        <SelectParameters>
            <asp:Parameter Name="strWhere" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsCateGory" runat="server"
        SelectMethod="GetModelList" TypeName="BookShop.BLL.CategoryManager">
        <SelectParameters>
            <asp:Parameter Name="strWhere" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
