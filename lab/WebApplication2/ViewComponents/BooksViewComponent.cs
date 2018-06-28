using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Respository;

namespace WebApplication2.ViewComponents
{
    public class BooksViewComponent : ViewComponent
    {
        private readonly IBookRepository _repo;

        public BooksViewComponent(IBookRepository repo)
        {
            _repo = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync(
            int maxPriority, bool isDone)
        {
            var items = await _repo.GetBooks();
            return View(items);
        }
    }
}
