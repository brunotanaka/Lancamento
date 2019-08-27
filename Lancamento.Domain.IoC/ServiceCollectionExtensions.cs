using FluentValidation;
using Lancamento.Application.AppServices;
using Lancamento.Application.Models;
using Lancamento.Application.Validators;
using Lancamento.Domain.Interfaces.AppServices;
using Lancamento.Domain.Interfaces.Repositories;
using Lancamento.Domain.Interfaces.Services;
using Lancamento.Domain.Services;
using Lancamento.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;

namespace Lancamento.Domain.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddRepositories();
            services.AddDomainServices();
            services.AddApplicationServices();
        }
        public static void AddMongoDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("MongoDBConnection");
            var url = MongoUrl.Create(connection);

            var settings = new MongoClientSettings()
            {
                Server = url.Server,
                WaitQueueSize = 1000,
                MaxConnectionPoolSize = 1000,
                MaxConnectionIdleTime = TimeSpan.FromSeconds(60)
            };

            var client = new MongoClient(settings);
            var database = client.GetDatabase("lancamentos");

            services.AddSingleton(database);
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryLancamento, RepositoryLancamento>();
        }

        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<ILancamentoService, LancamentoService>();
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ILancamentoAppService, LancamentoAppService>();
        }

        public static void AddValidatorServices(this IServiceCollection services)
        {
            services.AddTransient<IValidator<LancamentoViewModel>, LancamentoValidator>();
        }
    }
}
