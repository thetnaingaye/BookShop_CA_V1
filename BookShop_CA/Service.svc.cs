using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BookShop_CA.Models;

namespace BookShop_CA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public WCF_Book GetBookByTitle(string isbn)
        {
            Book b = BusinessLogic.GetBookByTitle(isbn);
            WCF_Book newBook = new WCF_Book(b.BookID, b.Title, b.CategoryID, b.ISBN, b.Author, b.Stock, b.Price);
            return newBook;

        }

        public List<WCF_Book> GetBooks()
        {
            List<Book> blist = BusinessLogic.ListBooks();
            List<WCF_Book> wcfBlist = new List<WCF_Book>();
            foreach (Book b in blist)
            {
                WCF_Book newBook = new WCF_Book(b.BookID, b.Title, b.CategoryID, b.ISBN, b.Author, b.Stock, b.Price);
                wcfBlist.Add(newBook);
            }

            return wcfBlist;

        }

        public List<WCF_Book> GetBooksByCatId(String CatId)
        {
            List<Book> blist = BusinessLogic.ListBooks();
            List<WCF_Book> wcfBlist = new List<WCF_Book>();
            foreach (Book b in blist)
            {
                if (b.CategoryID.ToString() == CatId)
                {
                    WCF_Book newBook = new WCF_Book(b.BookID, b.Title, b.CategoryID, b.ISBN, b.Author, b.Stock, b.Price);
                    wcfBlist.Add(newBook);
                }

            }

            return wcfBlist;


        }


        // Searching Book accross network
        public List<Book> SearchBooks(String input)
        {
            return SearchSupport.SearchBooks(input);
        }


        //public List<Book> GetBooks()
        //{
        //    return BusinessLogic.ListBooks();
        //}

        //Chang Siang's update book method
        public void UpdateBook(WCF_BookUpdate book)
        {
            int bookId = Int32.Parse(book.BookID);
            int bookStock = Int32.Parse(book.Stock);
            decimal bookPrice = Decimal.Parse(book.Price);
            BusinessLogic.UpdateBook(bookId, bookStock, bookPrice);
        }

    }
}
