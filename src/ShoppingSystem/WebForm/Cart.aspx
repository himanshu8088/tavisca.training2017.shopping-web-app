<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ShoppingSystem.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="cartForm" runat="server">
        <div style="display: flex; align-items: center; justify-content: space-between; flex-direction: column;">
            <asp:Label Text="Cart Detail" Style="margin-bottom: 50px; margin-top: 50px" ID="Lbl_header" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="XX-Large" ForeColor="#000099"></asp:Label>
            <asp:GridView ID="GridView_Cart" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="BookTitle" HeaderText="Book" />
                    <asp:BoundField DataField="Price" HeaderText="Price/Book" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                </Columns>
            </asp:GridView>
            <asp:Label Style="margin-bottom: 50px; margin-top: 50px" ID="Lbl_Total_Price" runat="server" />
            <asp:Button Style="margin-bottom: 50px; margin-top: 50px" ID="Btn_Order" runat="server" Text="Order" OnClick="Btn_Order_Click" />
        </div>
    </form>
</body>
</html>
