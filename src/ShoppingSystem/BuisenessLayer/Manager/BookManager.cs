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
            using (var entities = new BookStoreDBEntities())
            {
                if (IsBookOrdered(entities, bookId) == 1)
                    return Constants.ResultMsg.Fail;
                else
                {
                    var bookObj = GetBook(entities, bookId);
                    if (bookObj != null)
                    {
                        entities.Books.Remove(bookObj);
                        entities.SaveChanges();
                    }
                    return Constants.ResultMsg.Pass;
                }
            }
        }

        internal void Add(string bookId, string bookTitle, decimal price)
        {
            using (var entities = new BookStoreDBEntities())
            {
                if (IsBookExists(entities, bookId) == false)
                {
                    var book = CreateBook(bookId, bookTitle, price);
                    entities.Books.Add(book);
                    entities.SaveChanges();
                }
            }
        }

        private bool IsBookExists(BookStoreDBEntities entities, string bookId)
        {
            var bookCount = (from book in entities.Books
                             where book.BookId.Equals(bookId)
                             select book )
                             .Count();            
            if (bookCount == 0)
                return false;
            return true;
        }

        private Book CreateBook(string bookId, string bookTitle, decimal price)
        {
            var book = new Book();
            book.BookId = bookId;
            book.BookTitle = bookTitle;
            book.Price = price;
            return book;
        }

        private int IsBookOrdered(BookStoreDBEntities entities, string bookId)
        {
            var outBookOrdered = new System.Data.Entity.Core.Objects.ObjectParameter("bookCount", typeof(int));
            entities.IsBookOrdered(bookId, outBookOrdered);
            return Convert.ToInt32(outBookOrdered.Value);
        }

        private Book GetBook(BookStoreDBEntities entities, string bookId)
        {
            var books = from book in entities.Books
                        where book.BookId.Equals(bookId)
                        select book;
            return books.SingleOrDefault();
        }

        internal int Update(string bookId, string bookTitle, decimal price)
        {
            using (var entities = new BookStoreDBEntities())
            {
                if (IsBookOrdered(entities, bookId) == 1)
                    return Constants.ResultMsg.Fail;
                else
                {
                    var bookObj = GetBook(entities, bookId);
                    if (bookObj != null)
                    {
                        entities.Books.Remove(bookObj);
                        var book = CreateBook(bookId, bookTitle, price);
                        entities.Books.Add(book);
                        entities.SaveChanges();
                    }
                    return Constants.ResultMsg.Pass;
                }
            }
        }

    }
}