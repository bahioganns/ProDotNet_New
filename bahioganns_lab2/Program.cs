
using System;

namespace Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            Visitor visitor = new Visitor { Id = 123 };
            Book book = new Book { Id = 123, Visitor = visitor};

            Console.WriteLine(visitor);
            Console.WriteLine(book);
        }
    }
}
