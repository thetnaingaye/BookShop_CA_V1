<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="BookShop_CA.BookDetails" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="bookDetails" runat="server" ItemType="BookShop_CA.Models.Book" SelectMethod="GetDetails" >
        <ItemTemplate>
            <div>
                <h1><%#:Item.Title %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <image src="images/<%# Eval("ISBN") %>.jpg" width="400" height="360"></image>
                    </td>
                    <td>&nbsp;</td>
                    <td style="vertical-align: top; text-align: left;">
                        <span><b>Price:</b>&nbsp;<%#: String.Format("{0:c}", Item.Price) %></span>
                        <br />
                        <span><b>Author:</b>&nbsp;<%#:Item.Author %></span>
                        <br />
                        <span><b>Category:</b>&nbsp;<%#:GetCategory(Item.CategoryID)%></span>
                        <br />
                        <span><b>ISBN:</b>&nbsp;<%#:Item.ISBN %></span>
                        <br />
                        <span><b>Stock:</b>&nbsp;<%#:Item.Stock %></span>
                        <br />
                        <asp:Button ID="btnAddToCart" runat="server" Text="Add To Cart" CommandArgument='<%#:Item.BookID%>' CommandName="ThisBtnClick" OnClick="btnAddToCart_Click" />
                        </a>
                       
                        <br />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:Button ID="btnReturn" runat="server" PostBackUrl="~/BookDisplayPage.aspx" Text="Return" />
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
