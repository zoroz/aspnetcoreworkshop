using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Respository;

namespace WebApplication2.Controller
{
    public class ViewsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IBookRepository _repo;

        public ViewsController(IBookRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PassingData1()
        {
            ViewBag.PassingData1 = "jfkghdkfgddhfh PassingData";
            return View();
        }

        public async Task<IActionResult> PassingData2()
        {
            return View(await _repo.GetBook("1"));
        }


        public IActionResult UsingLayout()
        {
            return View();
        }

        public async Task<IActionResult> GetBooks()
        {
            return PartialView(await _repo.GetBook("1"));
        }
    }
}