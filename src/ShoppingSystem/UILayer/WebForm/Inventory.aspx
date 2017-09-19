<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="ShoppingSystem.UILayer.Inventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="inventoryForm" runat="server">
        <div style="display: flex; align-items: center; justify-content: space-between; flex-direction: column;">
            <asp:Label Style="margin-bottom: 50px; margin-top: 50px" ID="LblHeader" runat="server" Text="Book Store" Font-Bold="True" Font-Italic="False" Font-Size="XX-Large" ForeColor="#000099"></asp:Label>
            <asp:GridView ID="gridViewInventory" OnRowCommand="GridViewRowCommand"
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
                            <asp:Label Text="0" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cart" Visible="false">
                        <ItemTemplate>
                            <asp:Button Text="Add" runat="server" CommandName="getItemRow" CommandArgument="<%# Container.DataItemIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Panel ID="choiceControlPanel" runat="server" Style="margin: 20px;">
                <asp:Button Style="margin: 20px;" Text="Shop" ID="btnShop" runat="server" OnClick="BtnShopClick" />
                <asp:Button Style="margin: 20px;" Text="Manage" ID="btnManage" runat="server" OnClick="BtnManageClick" />
            </asp:Panel>

            <asp:Label id="lblStatus" runat="server"></asp:Label>

            <asp:Panel ID="addItemPanel" runat="server" Style="margin: 20px;" Visible="false">
                <asp:Label ID="lblIsbn1" runat="server" Text="ISBN"></asp:Label>
                <asp:TextBox ID="txtIsbn1" runat="server"></asp:TextBox>

                <asp:Label ID="lblTitle" runat="server" Text="Book Title"></asp:Label>
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>

                <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="BtnAddClick" />
            </asp:Panel>

            <asp:Panel ID="removeItemPanel" runat="server" Style="margin: 20px;" Visible="false">
                <asp:Label ID="lblIsbn2" runat="server" Text="ISBN"></asp:Label>
                <asp:TextBox ID="txtIsbn2" runat="server"></asp:TextBox>
                <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="BtnRemoveClick" />
            </asp:Panel>

            <asp:Panel ID="ShoppingControlPanel" runat="server" Style="margin: 20px;" Visible="false">
                <asp:Button Style="margin: 20px;" Text="Checkout" ID="btnCheckout" runat="server" OnClick="BtnCheckoutClick" Enabled="False" />
            </asp:Panel>

            <asp:Panel ID="inventoryUpdatePanel" runat="server" Style="margin: 20px;" Visible="false">
                <asp:Button Style="margin: 20px;" Text="Add To Inventory" ID="btnAddToInventory" runat="server" OnClick="BtnAddToInventoryClick" />
                <asp:Button Style="margin: 20px;" Text="Remove From Inventory" ID="btnRemoveFromInventory" runat="server" OnClick="BtnRemoveFromInventoryClick" />
                <asp:Button Style="margin: 20px;" Text="Update Inventory" ID="btnUpdateInventory" runat="server" OnClick="BtnUpdateInventoryClick" />                
            </asp:Panel>

        </div>
    </form>
</body>
</html>
