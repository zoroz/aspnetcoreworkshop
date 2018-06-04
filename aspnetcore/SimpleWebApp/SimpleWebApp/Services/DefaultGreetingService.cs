namespace SimpleWebApp.Services
{
    public class DefaultGreetingService : IGreetingService
    {
        public string Greet(string name) => $"Hello, {name}";
    }
}
