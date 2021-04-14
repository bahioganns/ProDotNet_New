using System;
using System.Collections.Generic;
using System.Text;
using Domain.Contracts;

namespace Domain.Models
{
    public class VisitorIdentityModel: IVisitorIdentity
    {
        public int Id { get; }

        public VisitorIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}
