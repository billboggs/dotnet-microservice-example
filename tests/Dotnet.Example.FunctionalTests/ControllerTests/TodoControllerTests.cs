using System;
using System.Net.Http;
using System.Threading.Tasks;

using Dotnet.Example.Core.Services;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Dotnet.Example.FunctionalTests
{
    public class TodoControllerTests : IClassFixture<WebApplicationFactory<Dotnet.Example.Api.Startup>>
    {
        private readonly WebApplicationFactory<Dotnet.Example.Api.Startup> _webAppFactory;

        public TodoControllerTests(WebApplicationFactory<Dotnet.Example.Api.Startup> webAppFactory)
        {
            _webAppFactory = webAppFactory;
        }

        [Theory]
        [InlineData("/api/v1/todo/all")]
        [InlineData("/api/v1/todo/first")]
        public async Task Get_EndpointsReturnsCorrectContentType(string url)
        {
            var client = CreateTestClient();
            var response = await client.GetAsync(url);

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/api/v1/todo/all")]
        [InlineData("/api/v1/todo/first")]
        public async Task Get_EndpointsReturnsSuccessCode(string url)
        {
            var client = CreateTestClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
        }

        private HttpClient CreateTestClient()
        {
            return _webAppFactory.WithWebHostBuilder(builder =>
                {
                    builder.ConfigureTestServices(services => 
                        {
                            services.AddScoped<ITodoService, TestTodoService>();
                        });
                })
                .CreateClient();
        }
    }
}
