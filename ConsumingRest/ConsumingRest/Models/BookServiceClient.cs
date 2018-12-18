using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ConsumingRest.Models;
using System.Web;
using System.Web.Script.Serialization;
using ConsumingRest.ServiceReference1;

namespace ConsumingRest.Models
{
    public class BookServiceClient
    {
        BookService2Client client = new BookService2Client();
        ////private string BASE_URL = "http://localhost:1728/BookService2.svc";

        public List<Book> getAllBook()
        {
            var list = client.GetBookList().ToList();
            var rt = new List<Book>();
            list.ForEach(b => rt.Add(new Book()
            {
                BookId = b.BookId,
                ISBN = b.ISBN,
                Title = b.Title
            }));
            return rt;



            //var synsClient = new WebClient();
            //var content = synsClient.DownloadString(BASE_URL + "Books");
            //var json_serialize = new JavaScriptSerializer();
            //return json_serialize.Deserialize<List<Book>>(content);
        }

        public string AddBook(Book newBook)
        {
            var book = new ServiceReference1.Book()
            {
                BookId = newBook.BookId,
                ISBN = newBook.ISBN,
                Title = newBook.Title
            };
            return client.AddBook(book);
        }

        public string DeleteBook(int id)
        {
            return client.DeleteBook(Convert.ToString(id));
        }

        public string Edit(Book newBook)
        {
            var book = new ServiceReference1.Book()
            {
                BookId = newBook.BookId,
                ISBN = newBook.ISBN,
                Title = newBook.Title
            };
            return client.UpDateBook(book);
        }

        public Book FindBook(int? id)
        {
            var findBook = client.GetBookId(Convert.ToString(id));
            var book = new Book();

            book.BookId = findBook.BookId;
            book.Title = findBook.Title;
            book.ISBN = findBook.ISBN;
            return book;
        }
    }

}