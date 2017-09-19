using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoppingSystem.BuisenessLayer.Provider
{
    public class BookProvider
    {
        internal DataSet GetAll()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da=null;
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BookStoreDBConn"].ToString());
            try
            {               
                sqlConn.Open();
                da= new SqlDataAdapter("select * from Books;", sqlConn);
                da.Fill(ds);                
            }
            catch (Exception ex)
            {
                throw new Exception("Can not get itinerary.");
            }
            finally
            {
                da.Dispose();
                sqlConn.Close();
            }
            return ds;
        }

        internal DataSet GetBookTiltle_Price(string isbn)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter da = null;
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BookStoreDBConn"].ToString());
            try
            {                
                sqlConn.Open();
                da = new SqlDataAdapter($"select BookTitle, Price from Books where BookId='{isbn}';", sqlConn);
                da.Fill(dataSet, "Books");
                da.Dispose();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Can not get itinerary.");
            }
            finally
            {
                da.Dispose();
                sqlConn.Close();
            }
            return dataSet;
        }
    }
}