using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BookWcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookService2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BookService2.svc or BookService2.svc.cs at the Solution Explorer and start debugging.
    public class BookService2 : IBookService2
    {
        static IBookRepository repository = new BookRepository();
        public List<Book> GetBookList()
        {
            return repository.GetBooks();
        }

        public Book GetBookId(string id)
        {
            return repository.GetBookById(int.Parse(id));
        }

        public string AddBook(Book book)
        {
            Book newBook = repository.AddNewBook(book);
            return "id =" + newBook.BookId;
        }

        public string UpDateBook(Book book)
        {
            bool deleted = repository.UpDateBook(book);
            if (deleted)
            {
                return "Updated successfully! Book with id=" + book.BookId;
            }
            else
            {
                return "Update false!";
            }
        }

        public string DeleteBook(string id)
        {
            bool deleted = repository.DeleteBook(int.Parse(id));
            if (deleted)
                return "Deleted successfully!";
            else
                return "Delete false!";
        }

    }
}