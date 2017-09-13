using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ShoppingSystem.Entities
{
    public class CartItem:ISerializable
    {
        public CartItem(int id,Book book,decimal price)
        {
            ItemId =id;
            Book = book;
            Price = price;
        }

        public int ItemId { get;}
        public Book Book { get;}
        public decimal Price { get; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}