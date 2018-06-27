using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Respository
{
    public class BookRepository : IBookRepository
    {
        public Book GetBook()
        {
            return new Book {Id = "1", Name = "First book", PublishedDate = DateTime.Now};
        }
    }

    public interface IBookRepository
    {
        Book GetBook();
    }
}
