using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;



namespace BookShop_CA.Models
{
    public static class BusinessLogic
    {

        public static List<Book> ListBooks()
        {
            using (Mybooks entities = new Mybooks())
            {
                return entities.Books.ToList<Book>();
            }
        }

        public static void DeleteBook(int BookID)
        {
            using (Mybooks entities = new Mybooks())
            {
                Book book = entities.Books.Where(b => b.BookID == BookID).First<Book>();
                entities.Books.Remove(book);
                entities.SaveChanges();
            }
        }

        public static void UpdateBook(int BookID, int bookStock, decimal bookPrice)
        {
            using (Mybooks entities = new Mybooks())
            {
                Book book = entities.Books.Where(b => b.BookID == BookID).First<Book>();
                book.Stock = bookStock;
                book.Price = bookPrice;
                entities.SaveChanges();
            }
        }

        public static Discount GetDiscount()
        {
            using (Mybooks entities = new Mybooks())
            {
                Discount discount = entities.Discounts.First<Discount>();
                return discount;
            }
        }

        public static void UpdateDiscount(DateTime startDate, DateTime endDate, double discountPercentage)
        {
            using (Mybooks entities = new Mybooks())
            {
                Discount discount = entities.Discounts.Where(d => d.SN == 1).First();
                discount.StartDate = startDate;
                discount.EndDate = endDate;
                discount.PercentageDiscount = discountPercentage;
                entities.SaveChanges();
            }
        }

        public static void Addbook(string bookTitle, int categoryID, string ISBN, string author, int stock, decimal bookPrice)
        {
            using (Mybooks entities = new Mybooks())
            {
                Book book = new Book();
                book.Title = bookTitle;
                book.CategoryID = categoryID;
                book.ISBN = ISBN;
                book.Author = author;
                book.Stock = stock;
                book.Price = bookPrice;
                entities.Books.Add(book);
                entities.SaveChanges();
            }
        }

        public static int GetBookID(string ISBN)
        {
            using (Mybooks entities = new Mybooks())
            {
                return entities.Books.Where(b => b.ISBN == ISBN).Select(b => b.BookID).First();
            }
        }

        public static List<Category> BookCategory()
        {
            using (Mybooks entities = new Mybooks())
            {
                return entities.Categories.ToList<Category>();
            }
        }

        public static List<Book> DeleteOrder(List<Book> _bookList, int bookID)
        {
            List<Book> bookList = _bookList;
            Book removeBook = bookList.Where(b => b.BookID == bookID).First<Book>();
            bookList.Remove(removeBook);
            return bookList;
        }

        public static void AddTransaction(List<Book> shoppingCart, string firstName, string lastName, string address, string contactNum)
        {
            using (Mybooks entities = new Mybooks())
            {

                foreach (Book b in shoppingCart)
                {
                    Transaction transaction = new Transaction();
                    int transID = entities.Transactions.OrderByDescending(x => x.TransID).Select(x => x.TransID).First();
                    int newTransID = transID + 1; ;
                    Transaction t = new Transaction
                    {
                        TransID = newTransID,
                        BookID = b.BookID,
                        BookTitle = b.Title,
                        Price = b.Price,
                        DateOfPurchase = DateTime.Today,
                        Address = address,
                        CustomerName = firstName + " " + lastName,
                        ContactNumber = contactNum

                    };
                    Mybooks context = new Mybooks();
                    context.Transactions.Add(t);
                    context.SaveChanges();


                }

            }

        }

    }
}
