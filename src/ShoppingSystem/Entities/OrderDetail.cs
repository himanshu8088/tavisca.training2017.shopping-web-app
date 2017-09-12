using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSystem.Entities
{
    public class OrderDetail
    {
        private decimal _price;
        private string _pid;
        private int _qty;

        public OrderDetail(string pid,decimal price,int qty)
        {
            _pid = pid;
            _price = price;
            _qty = qty;
        }

        public decimal Price { get
            {
                return _price;
            }
        }

        public string PID
        {
            get
            {
                return _pid;
            }
        }

        public int Qty
        {
            get
            {
                return _qty;
            }
        }

    }
}