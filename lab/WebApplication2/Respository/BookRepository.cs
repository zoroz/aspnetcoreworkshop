using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.ViewComponents;

namespace WebApplication2.Respository
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksContext _context;

        public BookRepository(BooksContext context)
        {
            _context = context;
        }
        public Task<Book> GetBook(string id)
        {
            var set = _context.Set<Book>();
            return set.FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<List<Book>> GetBooks()
        {
            var set = _context.Set<Book>();
            return set.ToListAsync();
        }
    }

    public interface IBookRepository
    {
        Task<Book> GetBook(string id);
        Task<List<Book>> GetBooks();
    }
}
