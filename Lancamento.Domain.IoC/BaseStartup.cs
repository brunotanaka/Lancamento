using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lancamento.Domain.IoC
{
    public class BaseStartup
    {
        private IConfiguration _configuration { get; set; }
        public IConfiguration Configuration
        {
            get => _configuration;
            set => _configuration = value;
        }

        private IServiceProvider _serviceProvider { get; set; }
        public IServiceProvider ServicesProvider
        {
            get => _serviceProvider;
            set => _serviceProvider = value;
        }

        public void Setup()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
