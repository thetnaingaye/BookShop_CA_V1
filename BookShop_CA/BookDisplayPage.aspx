<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDisplayPage.aspx.cs" Inherits="BookShop_CA.BookDisplayPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align:right">
        <%--<asp:TextBox ID="txtSearchField" runat="server" Font-Size="X-Large" Width="436px"></asp:TextBox>--%>
<%--        <asp:Label ID="Label1" runat="server" Text="" ></asp:Label>--%>
        <%--<asp:Button ID="btnSearch" runat="server" Text="Button" BorderStyle="None" Height="47px" OnClick="btnSearch_Click" Width="89px" />--%>
    </div>
    <div>
        <asp:ListView ID="bookList" runat="server" 
                DataKeyNames="BookID" GroupItemCount="6"
                ItemType="BookShop_CA.Models.Book" SelectMethod="GetBooks">
                <EmptyDataTemplate>
                    <table runat="server">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td runat="server" />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                           <tr>
                                <td>
                                    <a href="BookDetails.aspx?bookID=<%#:Item.BookID%>">
                                        <image src="images/<%# Eval("ISBN") %>.jpg" width="200" height="180" ></image>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="BookDetails.aspx?bookID=<%#:Item.BookID%>">
                                        <span>
                                            <%#:Item.Title%>
                                        </span>
                                    </a>
                                    <br />
                                    <span>
                                        <b>Price: </b><%#:String.Format("{0:c}", Item.Price)%>
                                    </span>
                                    <br />
                                    <a>
                                        <asp:Button ID="btnAddToCart" runat="server" Text="Add To Cart" CommandArgument='<%#:Item.BookID%>' CommandName="ThisBtnClick" OnClick="btnAddToCart_Click" />
                                    </a>         
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server" style="width:100%;">
                        <tbody>
                            <tr runat="server">
                                <td runat="server">
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%" class="table table-bordered">
                                        <tr id="groupPlaceholder" runat="server"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server"></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
    </div>
</asp:Content>
