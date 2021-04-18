using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DataAccess.Contracts;
using Domain;
using Domain.Models;
using BusinessLogic.Contracts;
using static BusinessLogic.Contracts.IVisitorServices;

namespace BusinessLogic.Implementations
{
    public class VisitorService : IVisitorCreateService, IVisitorGetService, IVisitorUpdateService, IVisitorDeleteService
    {
        private IVisitorDataAccess VisitorDataAccess { get; }

        public VisitorService(IVisitorDataAccess visitorDataAccess)
        {
            this.VisitorDataAccess = visitorDataAccess;
        }

        public Visitor CreateVisitor(VisitorUpdateModel visitor)
        {
            return this.VisitorDataAccess.Insert(visitor);
        }

        public Visitor GetVisitor(VisitorIdentityModel visitorId)
        {
            return this.VisitorDataAccess.Get(visitorId);
        }

        public IEnumerable<Visitor> GetAllVisitors()
        {
            return this.VisitorDataAccess.GetAllVisitors();
        }

        public Visitor UpdateVisitor(VisitorIdentityModel visitorId, VisitorUpdateModel visitor)
        {
            return this.VisitorDataAccess.Update(visitorId, visitor);
        }

        public void DeleteVisitor(VisitorIdentityModel visitorId)
        {
            this.VisitorDataAccess.Delete(visitorId);
        }

        public void ValidateVisitor(VisitorUpdateModel visitor)
        {
            Regex regex = new Regex("^[0-9]+$");
            if (!regex.Match(visitor.Login).Success)
            {
                throw new ArgumentException("Wrong pass number");
            }
        }
    }
}