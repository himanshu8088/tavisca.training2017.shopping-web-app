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

        protected void Btn_Shop_Click(object sender, EventArgs e)
        {
            ResetPanelVisibility();
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

            using (var ctx=new BookStoreDBEntities())
            {
                var book = new Book();
                book.BookId = Txt_Isbn1.Text;
                book.BookTitle = Txt_Title.Text;
                book.Price = decimal.Parse(Txt_Price.Text);
                ctx.Books.Add(book);
                ctx.SaveChanges();                
            }
        }

        protected void Btn_Remove_Click(object sender, EventArgs e)
        {
            using (var ctx = new BookStoreDBEntities())
            {
                var bookId = Txt_Isbn2.Text;
                var  outBookOrdered = new System.Data.Entity.Core.Objects.ObjectParameter("bookCount", typeof(int));                
                ctx.IsBookOrdered(bookId, outBookOrdered);

                var isBookOrdered = Convert.ToInt32(outBookOrdered.Value);
                if (isBookOrdered == 1)
                    Response.Write("<script>alert(Oops! Sorry cann't remove book.)</script>");
                else
                {                    
                    var books = from book in ctx.Books
                                    where book.BookId.Equals(bookId)
                                    select book;
                    var bookObj = books.SingleOrDefault();
                    if (bookObj != null)
                    {
                        ctx.Books.Remove(bookObj);
                        ctx.SaveChanges();
                    }
                }                    
            }
        }

        private void ResetPanelVisibility()
        {
            ShoppingControlPanel.Visible = false;
            InventoryUpdatePanel.Visible = false;
            AddItemPanel.Visible = false;
            RemoveItemPanel.Visible = false;
        }
    }
}