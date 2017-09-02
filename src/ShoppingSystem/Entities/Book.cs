using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSystem.Entities
{
    public class Book
    {
        public Book(string isbn, string title)
        {
            Isbn = isbn;
            Title = title;            
        }        
        public string Isbn { get;}
        public string Title { get; }        
    }
}