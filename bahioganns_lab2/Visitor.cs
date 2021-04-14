using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Visitor
    {
        public override string ToString()
        {
            return $"visitor<id={Id}, login='{Login}'>";
        }

        public int Id { get; set; }
        public string Login { get; set; }

        public List<Book> Books { get; } = new List<Book>();
    }
}
