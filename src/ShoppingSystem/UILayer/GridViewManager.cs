using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using ShoppingSystem.BuisenessLayer.Provider;
namespace ShoppingSystem.UILayer
{
    public class GridViewManager
    {
        internal void BindGrid(GridView view,DataSet ds)
        {                                        
                view.DataSource = ds;
                view.DataBind();            
        }

        internal void BindGrid(GridView view, DataTable dt)
        {
            view.DataSource = dt;
            view.DataBind();
        }

        internal string GetValue(GridView view, int rowIndex, int cellIndex)
        {
            GridViewRow row = view.Rows[rowIndex];
            return row.Cells[cellIndex].Text;
        }

        internal void SetValue(GridView view, int rowIndex, int cellIndex, string value)
        {
            GridViewRow row = view.Rows[rowIndex];
            row.Cells[cellIndex].Text = value;
        }
    }
}