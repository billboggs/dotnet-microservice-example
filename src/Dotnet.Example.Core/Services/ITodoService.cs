using System.Collections.Generic;
using System.Threading.Tasks;

using Dotnet.Example.Core.Models;

namespace Dotnet.Example.Core.Services
{
    public interface ITodoService
    {
        Task<List<TodoModel>> CallTodoApi();
    }
}