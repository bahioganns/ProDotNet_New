using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Models;
using BusinessLogic.Contracts;
using DataAccess.Contracts;
using static BusinessLogic.Contracts.IBookServices;

namespace BusinessLogic.Implementations
{
    public class BookService: IBookCreateService, IBookGetService, IBookUpdateService, IBookDeleteService
    {
        private IBookDataAccess BookDataAccess { get; }

        public BookService(IBookDataAccess bookDataAccess)
        {
            this.BookDataAccess = bookDataAccess;
        }

        public Book CreateBook(BookUpdateModel book)
        {
            return this.BookDataAccess.Insert(book);
        }

        public List<Book> GetVisitorBooks(VisitorIdentityModel visitorId)
        {
            return this.BookDataAccess.GetVisitorBooks(visitorId);
        }

        public Book GetBook(BookIdentityModel bookId)
        {
            return this.BookDataAccess.Get(bookId);
        }

        public Book UpdateBook(BookIdentityModel bookId, BookUpdateModel book)
        {
            return this.BookDataAccess.Update(bookId, book);
        }

        public void DeleteBook(BookIdentityModel bookId)
        {
            this.BookDataAccess.Delete(bookId);
        }
    }
}
