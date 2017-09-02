using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingSystem.Entities;
using System.Xml;
using System.Xml.Linq;
using System.Data;

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
            try
            {
                var file = Server.MapPath("~/DataProvider/InventoryDataProvider.xml");
                XElement bookstore = XElement.Load(file);
                

                int len = HttpContext.Current.Session.Count;
                for (int i = 0; i < len; i++)
                {
                    if (HttpContext.Current.Session["i" + i] is CartItem)
                    {
                        CartItem item = HttpContext.Current.Session["i" + i] as CartItem;

                        var books = bookstore.Elements();
                        foreach (var book in books)
                        {
                            var isbn = book.Element("ISBN");
                            if (isbn.Value == item.Book.Isbn)
                            {
                                var qtyElement = book.Element("Quantity_Available");
                                int qty = int.Parse(qtyElement.Value);
                                if (qty > 0)
                                {
                                    book.SetElementValue("Quantity_Available", qty - 1);
                                }
                                break;
                            }
                        }
                    }
                }
                bookstore.Save(file);
                Response.Write("<script>alert(Order confirmed);</script>");
            }
            catch (Exception ex)
            {

            }

        }
    }
}