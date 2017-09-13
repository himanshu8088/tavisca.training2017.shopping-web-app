<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="ShoppingSystem.UILayer.Inventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="inventoryForm" runat="server">
        <div style="display: flex; align-items: center; justify-content: space-between; flex-direction: column;">
            <asp:Label Style="margin-bottom: 50px; margin-top: 50px" ID="Lbl_header" runat="server" Text="Book Store" Font-Bold="True" Font-Italic="False" Font-Size="XX-Large" ForeColor="#000099"></asp:Label>
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
                            <asp:Label Text="0" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cart" Visible="false">
                        <ItemTemplate>
                            <asp:Button Text="Add" runat="server" CommandName="ItemSelected" CommandArgument="<%# Container.DataItemIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Panel ID="ChoiceControlPanel" runat="server" Style="margin: 20px;">
                <asp:Button Style="margin: 20px;" Text="Shop" ID="Btn_Shop" runat="server" OnClick="Btn_Shop_Click" />
                <asp:Button Style="margin: 20px;" Text="Manage" ID="Btn_Manage" runat="server" OnClick="Btn_Manage_Click" />
            </asp:Panel>

            <asp:Panel ID="AddItemPanel" runat="server" Style="margin: 20px;" Visible="false">
                <asp:Label ID="Lbl_Isbn1" runat="server" Text="ISBN"></asp:Label>
                <asp:TextBox ID="Txt_Isbn1" runat="server"></asp:TextBox>

                <asp:Label ID="Lbl_Title" runat="server" Text="Book Title"></asp:Label>
                <asp:TextBox ID="Txt_Title" runat="server"></asp:TextBox>

                <asp:Label ID="Lbl_Price" runat="server" Text="Price"></asp:Label>
                <asp:TextBox ID="Txt_Price" runat="server"></asp:TextBox>
                <asp:Button ID="Btn_Add" runat="server" Text="Add" OnClick="Btn_Add_Click" />
            </asp:Panel>

            <asp:Panel ID="RemoveItemPanel" runat="server" Style="margin: 20px;" Visible="false">
                <asp:Label ID="Lbl_Isbn2" runat="server" Text="ISBN"></asp:Label>
                <asp:TextBox ID="Txt_Isbn2" runat="server"></asp:TextBox>
                <asp:Button ID="Btn_Remove" runat="server" Text="Remove" OnClick="Btn_Remove_Click" />
            </asp:Panel>

            <asp:Panel ID="ShoppingControlPanel" runat="server" Style="margin: 20px;" Visible="false">
                <asp:Button Style="margin: 20px;" Text="Checkout" ID="Btn_Checkout" runat="server" OnClick="Btn_Checkout_Click" Enabled="False" />
            </asp:Panel>

            <asp:Panel ID="InventoryUpdatePanel" runat="server" Style="margin: 20px;" Visible="false">
                <asp:Button Style="margin: 20px;" Text="Add To Inventory" ID="Btn_Add_To_Inventory" runat="server" OnClick="Btn_Add_To_Inventory_Click" />
                <asp:Button Style="margin: 20px;" Text="Remove From Inventory" ID="Btn_Remove_From_Inventory" runat="server" OnClick="Btn_Remove_From_Inventory_Click" />
            </asp:Panel>

        </div>
    </form>
</body>
</html>
