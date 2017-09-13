<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="ShoppingSystem.Order"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="orderForm" runat="server">
        <div style="display:flex; align-items:center; justify-content:space-between; flex-direction:column;">                
            <asp:Label Text="Billing Detail" style="margin-bottom:50px; margin-top:50px" ID="Lbl_header" runat="server"  Font-Bold="True" Font-Italic="False" Font-Size="XX-Large" ForeColor="#000099"></asp:Label>            
             <div style="padding:100px; display:flex; flex-direction:column; border:2px solid black; border-radius:2px;">                          
                 <asp:Label ID="Lbl_OrderNo" runat="server" ForeColor="#000066"></asp:Label>                 
                 <asp:Label ID="Lbl_ShopperId" runat="server" ForeColor="#000066"></asp:Label>                 
                 <asp:Label ID="Lbl_ItemCount" runat="server" ForeColor="#000066"></asp:Label>                 
                 <asp:Label ID="Lbl_OrderDate" runat="server" ForeColor="#000066"></asp:Label>                 
                 <asp:Label ID="Lbl_Amount" runat="server" ForeColor="#000066"></asp:Label>                 
             </div>  
             <asp:Button style="margin-bottom:50px; margin-top:50px"  ID="Btn_Order" runat="server" Text="Order" OnClick="Btn_Order_Click" /> 
             <asp:Button style="margin-bottom:50px; margin-top:50px"  ID="Btn_Home" runat="server" Text="Back To Home" OnClick="Btn_Home_Click" /> 
        </div>
    </form>
</body>
</html>
