using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccess.Context;
using DataAccess.Contracts;
using DataAccess.Entities;
using Domain.Contracts;
using Domain.Models;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementations
{

    public class BookDataAccess : IBookDataAccess

    {
        private BooksAppContext Context { get; }
        private IMapper Mapper { get; }

        public BookDataAccess(BooksAppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;

            context.Database.EnsureCreated();
        }

        public Domain.Book Insert(BookUpdateModel book)
        {
            var result = this.Context.Add(this.Mapper.Map<DataAccess.Entities.Book>(book));

            this.Context.SaveChanges();

            Domain.Book res = new Domain.Book { Id = result.Entity.Id };
            this.Mapper.Map(result.Entity, res);
            return res;
        }

        public Domain.Book Get(BookIdentityModel id)
        {
            var result = this.Context.Book.Where(n => n.Id == id.Id).First();

            return this.Mapper.Map<Domain.Book>(result);
        }

        public List<Domain.Book> GetUserBooks(VisitorIdentityModel userId)
        {
            return (this.Context.Book
                                .Where(n => n.VisitorId == userId.Id)
                                .ToList()
                                .Select(x => this.Mapper.Map<Domain.Book>(x))
                                .ToList());
        }

        public Domain.Book Update(BookIdentityModel id, BookUpdateModel book)
        {
            var existing = this.Context.Book.Where(n => n.Id == id.Id).First();

            var result = this.Mapper.Map(book, existing);

            this.Context.Update(result);

            this.Context.SaveChanges();

            return this.Mapper.Map<Domain.Book>(result);
        }

        public void Delete(BookIdentityModel id)
        {
            var existing = this.Context.Book.Where(n => n.Id == id.Id).First();

            this.Context.Attach(existing);
            this.Context.Remove(existing);

            this.Context.SaveChanges();
        }

        public List<Domain.Book> GetVisitorBooks(VisitorIdentityModel visitorId)
        {
            return (this.Context.Book
                                .Where(n => n.VisitorId == visitorId.Id)
                                .ToList()
                                .Select(x => this.Mapper.Map<Domain.Book>(x))
                                .ToList());
        }

    }
}