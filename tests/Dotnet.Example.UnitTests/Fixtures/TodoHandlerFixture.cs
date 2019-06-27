using System;

using Dotnet.Example.Business.Handlers;
using Dotnet.Example.Core.Handlers;
using Dotnet.Example.Core.Services;
using Moq;

namespace Dotnet.Example.UnitTests.Fixtures
{
    public class TodoHandlerFixture : IDisposable
    {        
        public Mock<ITodoService> TodoService { get; }
        public TodoHandler TodoHandler { get; }

        public TodoHandlerFixture()
        {
            TodoService = new Mock<ITodoService>();
            TodoHandler = new TodoHandler(TodoService.Object);
        }

        public void Dispose()
        {
            // Any cleanup on the objects would go here
        }
    }

}