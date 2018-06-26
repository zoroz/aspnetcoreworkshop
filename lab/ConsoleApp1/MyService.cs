using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ConsoleApp1
{
    public class MyService: IMyService
    {
        private readonly ILogger<MyService> _log;
        private readonly MyOption _option;

        public MyService(IOptions<MyOption> option, ILogger<MyService> log)
        {
            _log = log;
            _option = option.Value;
        }

        public string Hello()
        {
            _log.LogInformation($"We are here with setting {_option.SettingA}");
            return _option.SettingA;
        }
    }

    public interface IMyService
    {
        string Hello();
    }
}
