<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Checkout.aspx.cs" Inherits="BookShop_CA.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 400px; margin-left: auto; margin-right: auto">
        <h5>Customer Details:</h5>
        <table style="width:100%">
            <tr>
                <td class="auto-style1">First Name</td>
                <td>
                    <asp:TextBox ID="TxtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtFirstName" ForeColor="Red" ErrorMessage="*Enter your First Name"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtLastName" ForeColor="Red" ErrorMessage="*Enter your Last Name"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAddress" ForeColor="Red" ErrorMessage="*Enter your Address"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label4" runat="server" Text="ContactNumber"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="TxtContactNum" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtContactNum" ForeColor="Red" ErrorMessage="*Enter your Contact Number"></asp:RequiredFieldValidator>

                </td>
            </tr>



        </table>
    </div>
    <div style="width: 400px; margin-left: auto; margin-right: auto">
        <h5>Cart Items:</h5>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Price" Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">

            <Columns>
                <asp:TemplateField HeaderText="Title">
                    <ItemTemplate>
                        <asp:Label ID="LblTitleCheckout" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price">
                    <ItemTemplate>
                        <asp:Label ID="LblPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <asp:Label ID="lblDiscount" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />

        <br />
        <div>
            <table style="width:100%">
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="LblTotalAmount" runat="server" Text="Total Amount:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTotalAmount" runat="server" ReadOnly="True" Enabled="False" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="lblDiscountedPrice" runat="server" Text="Discount: " Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDiscount" runat="server" Visible="False" ReadOnly="True" Enabled="False" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="lblFinalPrice" runat="server" Text="Final Price: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFinalPrice" runat="server" ReadOnly="True" Enabled="False" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Confirm Transaction" Width="148px" OnClick="Button1_Click" BorderColor="#333333" CssClass="btn" />
        <br />
        <asp:Label ID="lblRedirect" runat="server" Text="Checkout Successful! You will be redirected to the main page in a few seconds..." Visible="False"></asp:Label>
    </div>

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style6 {
            width: 114px;
        }
    </style>
</asp:Content>

