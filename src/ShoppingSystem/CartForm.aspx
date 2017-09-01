<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartForm.aspx.cs" Inherits="ShoppingSystem.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="cartForm" runat="server">
        <div style="display:flex; align-items:center; justify-content:space-between; flex-direction:column;">                
            <asp:Label Text="Cart Detail" style="margin-bottom:50px; margin-top:50px" ID="Lbl_header" runat="server"  Font-Bold="True" Font-Italic="False" Font-Size="XX-Large" ForeColor="#000099"></asp:Label>            
             <div>
                    
             </div>  
             <asp:Button style="margin-bottom:50px; margin-top:50px"  ID="Btn_Generate_Bill" runat="server" Text="Generate Bill" OnClick="Btn_Generate_Bill_Click" /> 
        </div>
    </form>
</body>
</html>
