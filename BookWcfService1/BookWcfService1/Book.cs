﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BookWcfService1
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int BookId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string ISBN { get; set; }

    }

    public interface IBookRepository
    {
        List<Book> GetBooks();
        Book GetBookById(int id);
        Book AddNewBook(Book item);
        bool DeleteBook(int id);
        bool UpDateBook(Book item);
    }

    public class BookRepository: IBookRepository
    {
        private  List<Book> books = new List<Book>();
        private int counter = 1;

        public List<Book> GetBooks()
        {
            return books;
            throw new NotImplementedException();
        }

        public Book GetBookById(int id)
        {
            return books.Find(b => b.BookId == id);
            throw new NotImplementedException();
        }

        public Book AddNewBook(Book item)
        {
            if (item == null)
                throw new NotImplementedException();
            item.BookId = counter++;
            books.Add(item);
            return item;
        }

        public bool DeleteBook(int id)
        {
            int idx = books.FindIndex(b => b.BookId == id);
            if (idx == -1)
            {
                return false;
            }
            books.RemoveAll(b => b.BookId == id);
            return true;
            //throw new NotImplementedException();
        }

        public bool UpDateBook(Book item)
        {
            int idx = books.FindIndex(b => b.BookId == item.BookId);
            if (idx == -1)
            {
                return false;
            }
            books.RemoveAt(idx);
            books.Add(item);
            return true;
            throw new NotImplementedException();
        }
    }
  
}