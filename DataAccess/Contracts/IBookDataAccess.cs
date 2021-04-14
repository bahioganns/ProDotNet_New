using System.Collections.Generic;
using Domain;
using Domain.Models;

namespace DataAccess.Contracts
{
    public interface IBookDataAccess
    {
        Domain.Book Insert(BookUpdateModel book);
        Domain.Book Get(BookIdentityModel id);
        List<Domain.Book> GetVisitorBooks(VisitorIdentityModel visitorId);
        Domain.Book Update(BookIdentityModel id, BookUpdateModel book);
        void Delete(BookIdentityModel id);
    }
}
