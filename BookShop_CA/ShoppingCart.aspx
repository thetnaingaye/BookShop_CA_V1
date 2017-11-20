<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ShoppingCart.aspx.cs" Inherits="BookShop_CA.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        DataKeyNames="BookID"
        OnRowDeleting="OnRowDeleting">

        <Columns>
            <asp:TemplateField HeaderText="BookID">
                <ItemTemplate>
                    <asp:Label ID="LblBookID" runat="server" Text='<%# Bind("BookID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Title" SortExpression="Title">
                <ItemTemplate>
                    <asp:Label ID="LblTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ISBN" SortExpression="ISBN">
                <ItemTemplate>
                    <asp:Label ID="LblISBN" runat="server" Text='<%# Bind("ISBN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CategoryID" SortExpression="CategoryID">
                <ItemTemplate>
                    <asp:Label ID="LblCatID" runat="server" Text='<%# Bind("CategoryID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Author" SortExpression="Author">
                <ItemTemplate>
                    <asp:Label ID="LblAuthor" runat="server" Text='<%# Bind("Author") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" SortExpression="Price">
                <ItemTemplate>
                    <asp:Label ID="LblPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="BtnCheckout" runat="server" Text="Checkout" OnClick="BtnCheckout_Click" />
    </div>
</asp:Content>

