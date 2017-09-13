using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingSystem.Entities;
using System.Data.SqlClient;
using System.Configuration;
using ShoppingSystem.BuisenessLayer.Manager;
using ShoppingSystem.BuisenessLayer.Provider;
namespace ShoppingSystem.UILayer
{
    public partial class Cart : System.Web.UI.Page
    {
        private GridViewManager _viewManager;
        private BookProvider _bookProvider;
        private OrderManager _orderManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            _bookProvider = new BookProvider();
            _viewManager = new GridViewManager();
            _orderManager = new OrderManager();

            List<ShoppingSystem.Entities.OrderDetail> orderDetails;
            orderDetails = new List<ShoppingSystem.Entities.OrderDetail>();
            decimal totalAmt = 0;
            if (this.IsPostBack == false)
            {
                ViewState["pageLoaded"] = true;
                using (DataTable dt = new DataTable())
                {
                    try
                    {
                        dt.Columns.AddRange(new DataColumn[3] { new DataColumn("BookTitle"), new DataColumn("Price"), new DataColumn("Quantity") });
                        foreach (string key in Session.Keys)
                        {
                            if (key.StartsWith("i") && key.Length > 1)
                            {
                                string isbn = key.Substring(1, key.Length - 1);

                                var ds = _bookProvider.GetBookTiltle_Price(isbn);
                                var price = _orderManager.GetPrice(ds);
                                var title = _orderManager.GetTitle(ds);
                                var qty = int.Parse(Session[key].ToString());

                                totalAmt += price;

                                orderDetails.Add(new ShoppingSystem.Entities.OrderDetail(isbn, price, qty));
                                dt.Rows.Add(title, price, qty);
                            }
                        }

                    }
                    catch (Exception ex)
                    {

                    }

                    _viewManager.BindGrid(GridView_Cart, dt);
                    Lbl_Total_Price.Text = $"Total Amount = {totalAmt}";
                    Session["TotalAmt"] = totalAmt;
                    Session["Order"] = orderDetails;
                    Btn_Order.Enabled = true;
                }
            }
        }
        protected void Btn_Order_Click(object sender, EventArgs e)
        {
            var orders = Session["Order"] as List<ShoppingSystem.Entities.OrderDetail>;
            var orderAmt = Session["TotalAmt"];
            OrderManager manager = new OrderManager();
            manager.Save(orders, orderAmt.ToString());
            Response.Write("<script>alert('Order confirmed');</script>");
            Btn_Order.Enabled = false;
        }

    }
}