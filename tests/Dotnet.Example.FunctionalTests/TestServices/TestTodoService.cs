using System.Collections.Generic;
using System.Threading.Tasks;

using Dotnet.Example.Core.Models;
using Dotnet.Example.Core.Services;

namespace Dotnet.Example.FunctionalTests
{
    public class TestTodoService : ITodoService
    {
        public Task<List<TodoModel>> CallTodoApi()
        {
            var todoModels = new List<TodoModel>
            {
                new TodoModel
                {
                    UserId = 1,
                    Id = 1,
                    Title = "Title 1",
                    Completed = false
                },
                new TodoModel
                {
                    UserId = 2,
                    Id = 2,
                    Title = "Title 2",
                    Completed = true
                }
            };
            return Task.FromResult<List<TodoModel>>(todoModels);
        }
    }
}