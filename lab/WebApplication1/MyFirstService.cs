using System.Threading.Tasks;

namespace WebApplication1
{
    public interface IMyFirstService
    {
        Task<string> DoWork();
    }

    public class MyFirstService: IMyFirstService
    {
        public Task<string> DoWork()
        {
            return Task.FromResult("work is done");
        }
    }
}
