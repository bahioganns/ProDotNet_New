using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Models;

namespace BusinessLogic.Contracts
{
    public class IBookServices
    {
        public interface IBookCreateService
        {
            Book CreateBook(BookUpdateModel book);
        }

        public interface IBookGetService
        {
            List<Book> GetVisitorBooks(VisitorIdentityModel visitorId);
            Book GetBook(BookIdentityModel bookId);
        }

        public interface IBookUpdateService
        {
            Book UpdateBook(BookIdentityModel bookId, BookUpdateModel book);
        }

        public interface IBookDeleteService
        {
            void DeleteBook(BookIdentityModel bookId);
        }
    }
}
