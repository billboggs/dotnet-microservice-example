using System.Collections.Generic;
using System.Threading.Tasks;

using Dotnet.Example.Core.Models;

namespace Dotnet.Example.Core.Handlers
{
    public interface ITodoHandler
    {
        Task<List<TodoModel>> GetAllTodos();
        Task<TodoModel> GetFirstTodo();
    }
}