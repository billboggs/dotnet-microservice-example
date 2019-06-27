using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dotnet.Example.Core.Handlers;
using Dotnet.Example.Core.Models;
using Dotnet.Example.Core.Services;

namespace Dotnet.Example.Business.Handlers
{
    public class TodoHandler : ITodoHandler
    {
        public readonly ITodoService _todoService;
        public TodoHandler(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<List<TodoModel>> GetAllTodos()
        {
            return await _todoService.CallTodoApi();
        }

        public async Task<TodoModel> GetFirstTodo()
        {
            var todos = await _todoService.CallTodoApi();
            return todos.FirstOrDefault();
        }
    }
}