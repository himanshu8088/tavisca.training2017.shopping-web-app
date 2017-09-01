<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderForm.aspx.cs" Inherits="ShoppingSystem.Purchase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="orderForm" runat="server">
        <div style="display:flex; align-items:center; justify-content:space-between; flex-direction:column;">                
            <asp:Label Text="Billing Detail" style="margin-bottom:50px; margin-top:50px" ID="Lbl_header" runat="server"  Font-Bold="True" Font-Italic="False" Font-Size="XX-Large" ForeColor="#000099"></asp:Label>            
             <div>
                    
             </div>  
             <asp:Button style="margin-bottom:50px; margin-top:50px"  ID="Btn_Order" runat="server" Text="Order" OnClick="Btn_Order_Click" /> 
        </div>
    </form>
</body>
</html>
