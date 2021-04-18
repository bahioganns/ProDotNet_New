using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Models;

namespace BusinessLogic.Contracts
{
    class IVisitorServices
    {
        public interface IVisitorCreateService
        {
            void ValidateVisitor(VisitorUpdateModel visitor);
            Visitor CreateVisitor(VisitorUpdateModel visitor);
        }

        public interface IVisitorGetService
        {
            Visitor GetVisitor(VisitorIdentityModel visitorId);
            IEnumerable<Visitor> GetAllVisitors();
        }

        public interface IVisitorUpdateService
        {
            Visitor UpdateVisitor(VisitorIdentityModel visitorId, VisitorUpdateModel visitor);
        }

        public interface IVisitorDeleteService
        {
            void DeleteVisitor(VisitorIdentityModel visitorId);
        }
    }
}
