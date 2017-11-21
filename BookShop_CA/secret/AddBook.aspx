<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="AddBook.aspx.cs" Inherits="BookShop_CA.secret.AddBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<!DOCTYPE html>


        <div style="width:400px;margin-left:auto;margin-right:auto">
            <table >
                <tr>
                    <td colspan="2">
                        <h1>Add Book:</h1>
                    </td>
                </tr>
                <tr>
                    <!--Category DDL-->
                    <td>Category: 
                    </td>
                    <td>
                        <asp:Label ID="LblCatID" runat="server" Text='<%# Bind("CategoryID") %>' Visible="false"></asp:Label>
                        <asp:Label ID="LblName" runat="server" Text='<%# Bind("Name") %>' Visible="false"></asp:Label>
                        <asp:DropDownList ID="DdlCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <!--Title-->
                    <td>Book Title:
                    </td>
                    <td>
                        <asp:TextBox ID="TxtBoxTitle" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtBoxTitle" ForeColor="Red" ErrorMessage="* Title Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <!--ISBN-->
                    <td>ISBN: 
                    </td>
                    <td>
                        <asp:TextBox ID="TxtBoxISBN" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtBoxISBN" ForeColor="Red" ErrorMessage="* ISBN Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <!--Author-->
                    <td>
                        Author: 
                    </td>
                    <td>
                        <asp:TextBox ID="TxtBoxAuthor" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtBoxAuthor" ForeColor="Red" ErrorMessage="* Author Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <!--Stock-->
                    <td>
                        Stock Level:
                    </td>
                    <td>
                        <asp:TextBox ID="TxtBoxStock" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtBoxStock" ForeColor="Red" ErrorMessage="* Stock Level Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <!--Price-->
                    <td>
                        Price: 
                    </td>
                    <td>
                        <asp:TextBox ID="TxtBoxPrice" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtBoxPrice" ValidationExpression="^\$?(\d{1,3},?(\d{3},?)*\d{3}(\.\d{0,2})?|\d{1,3}(\.\d{0,2})?|\.\d{1,2}?)$" ErrorMessage="* Invalid price value"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtBoxPrice" ForeColor="Red" ErrorMessage="* Price Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <!--Image-->
                    <td>Image File:

                    </td>
                    <td>
                        <asp:FileUpload ID="UploadBookImage" runat="server" CssClass="form-control" />
                        <asp:Label ID="LabelStatus" runat="server" ForeColor="Red"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="UploadBookImage" ForeColor="Red" ErrorMessage="* Book Cover Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <!--Btn Add Book-->
                    <td></td>
                    <td>
                        <asp:Button ID="BtnAddBook" runat="server" Text="Add Book" CausesValidation="true" OnClick="BtnAddBook_Click" BorderColor="#333333" CssClass="btn" />
                    </td>
                </tr>
            </table>
        </div>
</asp:Content>