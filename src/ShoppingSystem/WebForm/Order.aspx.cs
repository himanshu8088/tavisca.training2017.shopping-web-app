using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingSystem.Entities;

namespace ShoppingSystem
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Entities.Order order = HttpContext.Current.Session["order"] as Entities.Order;
            Lbl_Amount.Text = $"Bill Amount:{order.ChargebleAmount}";
            Lbl_ItemCount.Text = $"Number of Item:{ order.ItemCount}";
            Lbl_OrderDate.Text = $"Order Date:{order.OrderDate}";
            Lbl_OrderNo.Text = $"Order Number:{order.OrderNo}";
            Lbl_ShopperId.Text = $"User Id:{order.ShopperId}";
            
        }

        protected void Btn_Order_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert(\"Order Confirm\")</script>");
        }
    }
}