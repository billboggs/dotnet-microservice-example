using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Dotnet.Example.Core.Handlers;
using Dotnet.Example.Core.Models;
using Dotnet.Example.Core.Services;

using Newtonsoft.Json;

namespace Dotnet.Example.Business.Services
{
    public class TodoService : ITodoService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TodoService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<TodoModel>> CallTodoApi()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var result = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/todos");
            return JsonConvert.DeserializeObject<List<TodoModel>>(result);
        }
    }
}