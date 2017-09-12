<%@ Page Language="C#"  MaintainScrollPositionOnPostback="true"  AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="ShoppingSystem.Inventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="inventoryForm" runat="server" >
        <div style="display:flex; align-items:center; justify-content:space-between; flex-direction:column;">                
            <asp:Label style="margin-bottom:50px; margin-top:50px" ID="Lbl_header" runat="server" Text="Book Store" Font-Bold="True" Font-Italic="False" Font-Size="XX-Large" ForeColor="#000099"></asp:Label>            
            <asp:GridView ID="GridView_Inventory" OnRowCommand="GridView_RowCommand"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White"
                AlternatingRowStyle-ForeColor="#000"
                runat="server" AutoGenerateColumns="false" 
                BorderStyle="Solid" CellPadding="30">

                <Columns>
                    <asp:TemplateField HeaderText="Isbn" Visible="false">
                        <ItemTemplate>
                            <asp:Label Text="0" runat="server" Visible="false" />                           
                        </ItemTemplate>                        
                    </asp:TemplateField>
                    <asp:BoundField DataField="BookId" HeaderText="ISBN" />
                    <asp:BoundField DataField="BookTitle" HeaderText="Title" />
                    <asp:BoundField DataField="Price" HeaderText="Price(INR)" />                    
                    <asp:TemplateField HeaderText="Quantity" Visible="false">
                        <ItemTemplate>
                            <asp:Label Text="0" runat="server"/>                           
                        </ItemTemplate>                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cart">
                        <ItemTemplate>
                            <asp:Button Text="Add" runat="server" CommandName="ItemSelected" CommandArgument="<%# Container.DataItemIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>                
            </asp:GridView>
            <asp:Button style="margin:50px;" Text="Checkout" ID="Btn_Checkout" runat="server" OnClick="Btn_Checkout_Click" Enabled="False" />
        </div>          
    </form>
</body>
</html>
