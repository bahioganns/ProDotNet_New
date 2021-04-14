using System.Collections.Generic;
using Domain.Models;

namespace DataAccess.Contracts
{
    public interface IVisitorDataAccess
    {
        Domain.Visitor Insert(VisitorUpdateModel visitor);
        Domain.Visitor Get(VisitorIdentityModel id);
        IEnumerable<Domain.Visitor> GetAllVisitors();
        Domain.Visitor Update(VisitorIdentityModel id, VisitorUpdateModel visitor);
        void Delete(VisitorIdentityModel id);
    }
}
