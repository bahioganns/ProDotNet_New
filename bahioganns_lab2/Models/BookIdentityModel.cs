using System;
using System.Collections.Generic;
using System.Text;
using Domain.Contracts;

namespace Domain.Models
{
    public class BookIdentityModel: IBookIdentity
    {
        public int Id { get;  }

        public BookIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}
