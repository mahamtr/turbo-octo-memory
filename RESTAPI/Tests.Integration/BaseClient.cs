using System;
using System.Net.Http;
using BANKEST2.Api;
using BANKEST2.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Xunit;

namespace IntegrationTesting
{
    public class BaseClient
    {
        protected readonly HttpClient _client;
        public BaseClient()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            //     .WithWebHostBuilder(bu =>
            // {
            //     bu.ConfigureServices(s =>
            //     {
            //         s.RemoveAll(typeof(AppDbContext));
            //         s.AddDbContext<AppDbContext>(o => { o.UseInMemoryDatabase("InMemory"); });
            //     });
            // });
            _client = appFactory.CreateClient();
        }
    }
}