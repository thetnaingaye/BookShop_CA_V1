<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UpdateInventory.aspx.cs" Inherits="BookShop_CA.secret.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            DataKeyNames="BookID"
            OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowDataBound="GridView1_RowDataBound"
            OnRowDeleting="GridView1_RowDeleting"
            OnRowEditing="GridView1_RowEditing"
            OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:TemplateField AccessibleHeaderText="BookID" HeaderText="Book ID">
                    <ItemTemplate>
                        <asp:Label ID="lblBookID" runat="server" Text='<%# Bind("BookID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField AccessibleHeaderText="Title" HeaderText="Title">
                    <ItemTemplate>
                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField AccessibleHeaderText="Image" HeaderText="Image">
                    <ItemTemplate>
                        <image src="../images/<%# Eval("ISBN") %>.jpg" width="90" height="120"></image>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField AccessibleHeaderText="Category" HeaderText="Category">
                    <ItemTemplate>
                        <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("CategoryID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField AccessibleHeaderText="ISBN" HeaderText="ISBN">
                    <ItemTemplate>
                        <asp:Label ID="lblIsbn" runat="server" Text='<%# Eval("ISBN") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField AccessibleHeaderText="Author" HeaderText="Author">
                    <ItemTemplate>
                        <asp:Label ID="lblAuthor" runat="server" Text='<%# Eval("Author") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField AccessibleHeaderText="Stock" HeaderText="Stock">
                    <EditItemTemplate>
                        <asp:TextBox ID="TxtBoxStock" runat="server" Text='<%# Bind("Stock") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblStock" runat="server" Text='<%# Eval("Stock") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField AccessibleHeaderText="Price" HeaderText="Price">
                    <EditItemTemplate>
                        <asp:TextBox ID="TxtBoxPrice" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" ButtonType="Button" ShowDeleteButton="True" />
            </Columns>

        </asp:GridView>
    </div>


</asp:Content>
