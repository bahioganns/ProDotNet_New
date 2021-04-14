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
    public class VisitorDataAccess : IVisitorDataAccess
    {
        private BooksAppContext Context { get; }
        private IMapper Mapper { get; }

        public VisitorDataAccess(BooksAppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;

            context.Database.EnsureCreated();
        }

        public Domain.Visitor Insert(VisitorUpdateModel visitor)
        {
            var result = this.Context.Add(this.Mapper.Map<DataAccess.Entities.Visitor>(visitor));

            this.Context.SaveChanges();

            Domain.Visitor res = new Domain.Visitor { Id = result.Entity.Id };
            this.Mapper.Map(result.Entity, res);
            return res;
        }

        public Domain.Visitor Get(VisitorIdentityModel id)
        {
            var result = this.Context.Visitor.Where(u => u.Id == id.Id).First();

            return this.Mapper.Map<Domain.Visitor>(result);
        }

        public IEnumerable<Domain.Visitor> GetAllVisitors()
        {
            var result = this.Context.Visitor;

            return result.Select(x => this.Mapper.Map<Domain.Visitor>(x)).ToList();
        }

        public Domain.Visitor Update(VisitorIdentityModel id, VisitorUpdateModel visitor)
        {
            var existing = this.Context.Visitor.Where(u => u.Id == id.Id).First();

            var result = this.Mapper.Map(visitor, existing);

            this.Context.Update(result);

            this.Context.SaveChanges();

            return this.Mapper.Map<Domain.Visitor>(result);
        }

        public void Delete(VisitorIdentityModel id)
        {
            var existing = this.Context.Visitor.Where(u => u.Id == id.Id).First();

            this.Context.Attach(existing);
            this.Context.Remove(existing);

            this.Context.SaveChanges();
        }
    }
}