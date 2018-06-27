using Microsoft.AspNetCore.Mvc;
using WebApplication2.Respository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IBookRepository _repo;

        public HomeController(IBookRepository repo)
        {
            _repo = repo;
        }

        // GET: /<controller>/
        public string Index()
        {
            return "Test string";
        }

        [Route("Greeting1/{name?}")]
        public string Greeting1(string name)
        {
            return $"Hello, {name}";
        }

        //[Route("Greeting2", Name="2")]
        //public string Greeting2(string name)
        //{
        //    return $"Greeting2, {name}";
        //}

        [Route("Greeting2/{name}")]
        public string Greeting21(string name)
        {
            return $"Greeting21, {name}";
        }

        [Route("Greeting2", Name="22")]
        public string Greeting22([FromQuery]string name)
        {
            return $"Greeting22, {name}";
        }

        public string Add(int val)
        {
            return $"Int value from add, {val}";
        }

        [Route("GetBook")]
        public IActionResult GetBook()
        {
            return Json(_repo.GetBook());
        }

        [Route("GetBook1")]
        public IActionResult GetBook1(IBookRepository repo)
        {
            return Json(repo.GetBook());
        }


        [Route("RedirectSample")]
        public IActionResult RedirectSample()
        {
            return Redirect("http://www.cninnovation.com");
        }
    }
}
