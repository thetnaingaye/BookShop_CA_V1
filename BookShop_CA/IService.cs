using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BookShop_CA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Books", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_Book> GetBooks();

        [OperationContract]
        [WebGet(UriTemplate = "/Books/{CatId}", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_Book> GetBooksByCatId(string CatId);

        [OperationContract]
        [WebGet(UriTemplate = "/Book/{isbn}", ResponseFormat = WebMessageFormat.Json)]
        WCF_Book GetBookByTitle(string isbn);



        // Searching Book accross network
        [OperationContract]
        [WebGet(UriTemplate = "/search?client={input}", ResponseFormat = WebMessageFormat.Json)]
        List<Models.Book> SearchBooks(String input);

        //[OperationContract]
        //[WebGet(UriTemplate = "/Books", ResponseFormat = WebMessageFormat.Json)]
        //List<Models.Book> GetBooks();

        //Chang Siang method to update book
        [OperationContract]
        [WebInvoke(UriTemplate = "/Books/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void UpdateBook(WCF_BookUpdate book);
        //chang siang ends here
    }

    [DataContract]
    public class WCF_Book
    {
        [DataMember]
        public int BookID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public int CategoryID { get; set; }

        [DataMember]
        public string ISBN { get; set; }

        [DataMember]
        public string Author { get; set; }

        [DataMember]

        public int Stock { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        public WCF_Book(int BookID,string Title,int CategoryID,string ISBN,string Author,int Stock,decimal Price)
        {
            this.BookID = BookID;
            this.Title = Title;
            this.CategoryID = CategoryID;
            this.ISBN = ISBN;
            this.Author = Author;
            this.Stock = Stock;
            this.Price = Price;
        }

    }
    [DataContract]
    public class WCF_BookUpdate
    {
        [DataMember]
        public string BookID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string CategoryID { get; set; }

        [DataMember]
        public string ISBN { get; set; }

        [DataMember]
        public string Author { get; set; }

        [DataMember]

        public string Stock { get; set; }

        [DataMember]
        public string Price { get; set; }

        public WCF_BookUpdate(string BookID, string Title, string CategoryID, string ISBN, string Author, string Stock, string Price)
        {
            this.BookID = BookID;
            this.Title = Title;
            this.CategoryID = CategoryID;
            this.ISBN = ISBN;
            this.Author = Author;
            this.Stock = Stock;
            this.Price = Price;
        }
    }
}