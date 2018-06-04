using SimpleWebApp.Services;

namespace SimpleWebApp.MyControllers
{
    public class HelloController
    {
        private readonly IGreetingService _greetingService;
        public HelloController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }
        public string Index(string name) => _greetingService.Greet(name);

    }
}
