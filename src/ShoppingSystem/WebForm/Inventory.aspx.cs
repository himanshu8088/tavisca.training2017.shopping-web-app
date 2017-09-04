using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingSystem.Entities;

namespace ShoppingSystem
{
    public partial class Inventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                BindGrid();
            }
        }

        private void BindGrid()
        {
            using (DataSet ds = new DataSet())
            {
                ds.ReadXml(Server.MapPath("~/DataProvider/InventoryDataProvider.xml"));
                GridView_Inventory.DataSource = ds;
                GridView_Inventory.DataBind();
            }
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ItemSelected")
            {
                Btn_View_Cart.Enabled = true;
                int rowIndex = Convert.ToInt32(e.CommandArgument);             
                GridViewRow row = GridView_Inventory.Rows[rowIndex];

                string isbn = row.Cells[1].Text;
                string title = row.Cells[2].Text;
                decimal price = decimal.Parse(row.Cells[3].Text);

                Book book = new Book(isbn, title);
                int itemId = rowIndex + 1;
                CartItem cart = new CartItem(itemId, book, price);
                Session["i"+Session.Count] = cart;
            }
        }

        protected void Btn_View_Cart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForm/Cart.aspx");
        }
    }
}