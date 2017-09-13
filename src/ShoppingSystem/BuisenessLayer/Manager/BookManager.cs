using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingSystem.DataLayer.EFModel;

namespace ShoppingSystem.BuisenessLayer
{
    public class BookManager
    {
        internal int Remove(string bookId)
        {
            using (var ctx = new BookStoreDBEntities())
            {                
                var outBookOrdered = new System.Data.Entity.Core.Objects.ObjectParameter("bookCount", typeof(int));
                ctx.IsBookOrdered(bookId, outBookOrdered);

                var isBookOrdered = Convert.ToInt32(outBookOrdered.Value);
                if (isBookOrdered == 1)
                    return Constants.ResponseMsg.NotRemoved;
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
                    return Constants.ResponseMsg.Removed;
                }
            }
        }

        internal void Add(string bookId, string bookTitle, decimal price)
        {
            using (var ctx = new BookStoreDBEntities())
            {               
                var book = new Book();
                book.BookId = bookId;
                book.BookTitle = bookTitle;
                book.Price = price;
                ctx.Books.Add(book);
                ctx.SaveChanges();              
            }
        }
        
    }
}