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
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BookStoreDBConn"].ToString()))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from Books;", sqlConn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (SqlException ex)
            {

            }
            throw new Exception();
        }

        internal DataSet GetBookTiltle_Price(string isbn)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BookStoreDBConn"].ToString()))
                {
                   
                    var da = new SqlDataAdapter($"select BookTitle, Price from Books where BookId='{isbn}';", sqlConn);
                    DataSet dataSet = new DataSet();
                    da.Fill(dataSet, "Books");
                    return dataSet;
                }
            }
            catch (SqlException ex)
            {

            }
            throw new Exception();
        }
    }
}