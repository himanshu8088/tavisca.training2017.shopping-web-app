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
            try
            {
                var ds = _provider.GetAll();
                _viewManager.BindGrid(gridViewInventory, ds);
            }
            catch(Exception e)
            {
                Response.Write("<script>alert("+e.Message+");</script>");
            }                        
        }

        protected void GridViewRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "getItemRow")
            {
                btnCheckout.Enabled = true;
                int rowIndex = Int32.Parse((string)e.CommandArgument);
                int qty = 0;

                string qtyVal = _viewManager.GetValue(gridViewInventory, rowIndex, 4);
                int.TryParse(qtyVal, out qty);
                qty = (qty + 1);
                _viewManager.SetValue(gridViewInventory, rowIndex, 4, qty.ToString());

                string isbnVal = _viewManager.GetValue(gridViewInventory, rowIndex, 1);
                _viewManager.SetValue(gridViewInventory, rowIndex, 0, isbnVal);

                Session["i" + isbnVal] = qty;
            }
        }

        protected void BtnCheckoutClick(object sender, EventArgs e)
        {
            Response.Redirect("~/UILayer/WebForm/Cart.aspx");
        }

        protected void BtnShopClick(object sender, EventArgs e)
        {
            ResetPanelVisibility();
            gridViewInventory.Columns[5].Visible = true;
            ShoppingControlPanel.Visible = true;
        }

        protected void BtnManageClick(object sender, EventArgs e)
        {
            ResetPanelVisibility();
            inventoryUpdatePanel.Visible = true;
        }

        protected void BtnAddToInventoryClick(object sender, EventArgs e)
        {
            ResetPanelVisibility();
            addItemPanel.Visible = true;
        }

        protected void BtnRemoveFromInventoryClick(object sender, EventArgs e)
        {
            ResetPanelVisibility();
            removeItemPanel.Visible = true;
        }

        protected void BtnUpdateInventoryClick(object sender, EventArgs e)
        {
            ResetPanelVisibility();
            btnAdd.Text = "Update";
            addItemPanel.Visible = true;
        }

        protected void BtnAddClick(object sender, EventArgs e)
        {
            if (btnAdd.Text.Equals("Add"))
            {
                _bookManager.Add(txtIsbn1.Text, txtTitle.Text, decimal.Parse(txtPrice.Text));
            }
            else
            {
                int statusCode = _bookManager.Update(txtIsbn1.Text, txtTitle.Text, decimal.Parse(txtPrice.Text));
                if (statusCode == BuisenessLayer.Constants.ResultMsg.Fail)
                    ShowStatus(Constants.ErrorMsg.UpdateFail);
            }

            LoadGrid();
        }

        protected void BtnRemoveClick(object sender, EventArgs e)
        {
            int statusCode = _bookManager.Remove(txtIsbn2.Text);
            if (statusCode == BuisenessLayer.Constants.ResultMsg.Fail)
                ShowStatus(Constants.ErrorMsg.DeleteFail);
            LoadGrid();
        }

        private void ShowStatus(string msg)
        {
            lblStatus.Text = msg;           
        }

        private void ResetPanelVisibility()
        {
            ShoppingControlPanel.Visible = false;
            inventoryUpdatePanel.Visible = false;
            addItemPanel.Visible = false;
            removeItemPanel.Visible = false;
            gridViewInventory.Columns[5].Visible = false;
            btnAdd.Text = "Add";
            lblStatus.Text = "";
        }        
    }
}