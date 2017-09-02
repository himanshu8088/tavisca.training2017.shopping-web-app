<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="ShoppingSystem.Inventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="inventoryForm" runat="server" >
        <div style="display:flex; align-items:center; justify-content:space-between; flex-direction:column;">                
            <asp:Label style="margin-bottom:50px; margin-top:50px" ID="Lbl_header" runat="server" Text="Book Store" Font-Bold="True" Font-Italic="False" Font-Size="XX-Large" ForeColor="#000099"></asp:Label>            
            <asp:XmlDataSource ID="XmlDataSource" runat="server" DataFile="~/DataProvider/InventoryDataProvider.xml"></asp:XmlDataSource>
            <asp:GridView  ID="GridView" runat="server" DataSourceID="XmlDataSource" BorderStyle="Double" CellPadding="50" CellSpacing="2">                
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chk1" runat="server"/>      
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button style="margin-bottom:50px; margin-top:50px"  ID="Btn_Add_To_Cart" runat="server" Text="Add To Cart" OnClick="Btn_Add_To_Cart_Click" /> 
        </div>          
    </form>
</body>
</html>
