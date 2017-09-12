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
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BookStoreDBConn"].ToString()))
                {
                    var da = new SqlDataAdapter("select * from Books;", sqlConn);
                    using (DataSet ds = new DataSet())
                    {
                        da.Fill(ds);
                        GridView_Inventory.DataSource = ds;
                        GridView_Inventory.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ItemSelected")
            {
                Btn_Checkout.Enabled = true;                
                int rowIndex = Int32.Parse((string)e.CommandArgument); ;
                GridViewRow row = GridView_Inventory.Rows[rowIndex];
                int qty = 0;
                int.TryParse(row.Cells[4].Text, out qty);
                row.Cells[4].Text = "" + (qty + 1);
                row.Cells[0].Text = row.Cells[1].Text;
                Session["i" + row.Cells[0].Text] = row.Cells[4].Text;
            }
        }

        protected void Btn_Checkout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForm/Cart.aspx");
        }
    }
}