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
    public partial class Cart : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            List<OrderDetail> orderDetails;
            orderDetails = new List<OrderDetail>();
            decimal totalAmt = 0;
            if (this.IsPostBack == false)
            {
                ViewState["pageLoaded"] = true;
                using (DataTable dt = new DataTable())
                {
                    try
                    {
                        dt.Columns.AddRange(new DataColumn[3] { new DataColumn("BookTitle"), new DataColumn("Price"), new DataColumn("Quantity") });
                        using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BookStoreDBConn"].ToString()))
                        {
                            foreach (string key in Session.Keys)
                            {
                                if (key.StartsWith("i") && key.Length > 1)
                                {
                                    string isbn = key.Substring(1, key.Length - 1);
                                    var da = new SqlDataAdapter($"select BookTitle, Price from Books where BookId='{isbn}';", sqlConn);
                                    DataSet dataSet = new DataSet();

                                    da.Fill(dataSet, "Books");
                                    var row = dataSet.Tables["Books"].Rows[0];
                                    var price = decimal.Parse(row["Price"].ToString());
                                    var qty = int.Parse(Session[key].ToString());
                                    totalAmt += price;

                                    orderDetails.Add(new OrderDetail(isbn, price, qty));
                                    dt.Rows.Add(row["BookTitle"], price, qty);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                   

                    GridView_Cart.DataSource = dt;
                    GridView_Cart.DataBind();
                    Lbl_Total_Price.Text = $"Total Amount = {totalAmt}";
                    Session["TotalAmt"] = totalAmt;
                    Session["Order"] = orderDetails;
                    Btn_Order.Enabled = true;
                }
            }
        }
        protected void Btn_Order_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BookStoreDBConn"].ToString()))
                {
                    var orderId = System.Guid.NewGuid();
                    var orderDate = DateTime.Now;
                                        
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand($"insert into Orders values('{orderId}','{orderDate}',{Session["TotalAmt"]});", sqlConn);
                    cmd.ExecuteNonQuery();

                    var orders = Session["Order"] as List<OrderDetail>;
                    foreach (var order in orders)
                    {
                        cmd = new SqlCommand($"insert into OrderDetails values('{orderId}','{order.PID}',{order.Qty},{order.Price});", sqlConn);
                        cmd.ExecuteNonQuery();                        
                    }
                }
                Response.Write("<script>alert('Order confirmed');</script>");
                Btn_Order.Enabled = false;
            }
            catch(Exception ex)
            {

            }           

        }

    }
}