using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoppingSystem.BuisenessLayer.Manager
{
    public class OrderManager
    {
        internal decimal GetPrice(DataSet dataSet)
        {
            var row = GetDataRow(dataSet);
            var price = decimal.Parse(row["Price"].ToString());
            return price;
        }

        internal string GetTitle(DataSet dataSet)
        {
            var row = GetDataRow(dataSet);
            return row["BookTitle"].ToString();
        }

        private DataRow GetDataRow(DataSet dataSet)
        {
            return dataSet.Tables["Books"].Rows[0];
        }

        internal void Save(List<Entities.OrderDetail> orders, string orderAmt)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BookStoreDBConn"].ToString()))
                {
                    var orderId = System.Guid.NewGuid();

                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand($"insert into Orders values('{orderId}',CURRENT_TIMESTAMP,{orderAmt});", sqlConn);
                    cmd.ExecuteNonQuery();


                    foreach (var order in orders)
                    {
                        cmd = new SqlCommand($"insert into OrderDetails values('{orderId}','{order.PID}',{order.Qty},{order.Price});", sqlConn);
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}