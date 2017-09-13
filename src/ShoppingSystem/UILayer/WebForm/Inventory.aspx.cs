using System;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingSystem.BuisenessLayer;
using ShoppingSystem.BuisenessLayer.Provider;
using System.Data.SqlClient;
using System.Configuration;

namespace ShoppingSystem.UILayer
{
    public partial class Inventory : System.Web.UI.Page
    {
        private BookManager _bookManager;
        private GridViewManager _viewManager;
        private BookProvider _provider;
        protected void Page_Load(object sender, EventArgs e)
        {
            _bookManager = new BookManager();
            _viewManager = new GridViewManager();
            _provider = new BookProvider();
            if (!IsPostBack)
            {
                Session.Clear();
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            var ds = _provider.GetAll();
            _viewManager.BindGrid(GridView_Inventory, ds);
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ItemSelected")
            {
                Btn_Checkout.Enabled = true;
                int rowIndex = Int32.Parse((string)e.CommandArgument);
                int qty = 0;

                string qtyVal = _viewManager.GetValue(GridView_Inventory, rowIndex, 4);
                int.TryParse(qtyVal, out qty);
                qty = (qty + 1);
                _viewManager.SetValue(GridView_Inventory, rowIndex, 4, qty.ToString());

                string isbnVal = _viewManager.GetValue(GridView_Inventory, rowIndex, 1);
                _viewManager.SetValue(GridView_Inventory, rowIndex, 0, isbnVal);

                Session["i" + isbnVal] = qty;
            }
        }

        protected void Btn_Checkout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UILayer/WebForm/Cart.aspx");
        }

        protected void Btn_Shop_Click(object sender, EventArgs e)
        {            
            ResetPanelVisibility();
            GridView_Inventory.Columns[5].Visible = true;
            ShoppingControlPanel.Visible = true;
        }

        protected void Btn_Manage_Click(object sender, EventArgs e)
        {            
            ResetPanelVisibility();
            InventoryUpdatePanel.Visible = true;
        }

        protected void Btn_Add_To_Inventory_Click(object sender, EventArgs e)
        {
            ResetPanelVisibility();
            AddItemPanel.Visible = true;
        }

        protected void Btn_Remove_From_Inventory_Click(object sender, EventArgs e)
        {
            ResetPanelVisibility();
            RemoveItemPanel.Visible = true;
        }

        protected void Btn_Add_Click(object sender, EventArgs e)
        {
            _bookManager.Add(Txt_Isbn1.Text, Txt_Title.Text, decimal.Parse(Txt_Price.Text));
            LoadGrid();
        }

        protected void Btn_Remove_Click(object sender, EventArgs e)
        {
            int statusCode = _bookManager.Remove(Txt_Isbn2.Text);
            if (statusCode == Constants.ResponseMsg.NotRemoved)
                Response.Write("<script>alert('Sorry can not delete. It is present in order history');</script>");
            else
            {
                LoadGrid();
            }

        }

        private void ResetPanelVisibility()
        {
            ShoppingControlPanel.Visible = false;
            InventoryUpdatePanel.Visible = false;
            AddItemPanel.Visible = false;
            RemoveItemPanel.Visible = false;
            GridView_Inventory.Columns[5].Visible = false;
        }
    }
}