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
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack==false)
            {
                ViewState["pageLoaded"] = true;
                using (DataTable dt = new DataTable())
                {
                    dt.Columns.AddRange(new DataColumn[3] { new DataColumn("ISBN"), new DataColumn("Book"), new DataColumn("Price") });
                    int len = HttpContext.Current.Session.Count;
                    for (int i = 0; i < len; i++)
                    {
                        if (HttpContext.Current.Session["i" + i] is CartItem)
                        {
                            CartItem item = HttpContext.Current.Session["i" + i] as CartItem;
                            dt.Rows.Add(item.Book.Isbn, item.Book.Title, item.Price);
                        }                        
                    }
                    GridView_Cart.DataSource = dt;
                    GridView_Cart.DataBind();
                }
            }
                         
         
        }

        protected void Btn_Generate_Bill_Click(object sender, EventArgs e)
        {

            decimal amount = 0;
            CartItem item;

            int len = HttpContext.Current.Session.Count;
            for (int i = 0; i < len; i++)
            {
                if (HttpContext.Current.Session["i" + i] is CartItem)
                {
                    item = HttpContext.Current.Session["i" + i] as CartItem;
                    amount += item.Price;
                }
            }

            Entities.Order order = new Entities.Order(Guid.NewGuid(), len, amount);
            Session["order"] = order;
            Response.Redirect("~/WebForm/Order.aspx");
        }
    }
}