using System;
using System.Collections.Generic;
using System.Text;
using Domain.Contracts;

namespace Domain
{
    public class Book: IVisitorContainer
    {
        public override string ToString()
        {
            return $"Book<id={Id}, Visitor_id='{Visitor.Id}', name='{Name}'>";
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public Visitor Visitor { get; set; }
        int? IVisitorContainer.VisitorId => this.Visitor.Id;
    }
}
