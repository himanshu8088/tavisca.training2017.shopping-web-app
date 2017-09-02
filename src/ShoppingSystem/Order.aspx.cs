using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingSystem
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Order_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert(\"Order Confirm\")</script>");
        }
    }
}