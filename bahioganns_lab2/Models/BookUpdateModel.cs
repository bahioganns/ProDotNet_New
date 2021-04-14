using System;
using System.Collections.Generic;
using System.Text;
using Domain.Contracts;

namespace Domain.Models

{
    public class BookUpdateModel: IVisitorContainer
    {
        public string Name { get; set; }
        public string Content { get; set; }

        public int? VisitorId { get; set; }
    }
}
