using System;
using System.Collections.Generic;

using Dotnet.Example.Business.Handlers;
using Dotnet.Example.Core.Models;
using Dotnet.Example.Core.Services;
using Dotnet.Example.UnitTests.Fixtures;

using AutoFixture;
using AutoFixture.Xunit2;

using Moq;

using Xunit;

namespace Dotnet.Example.UnitTests
{
    public class TodoHandlerTests : IClassFixture<TodoHandlerFixture>
    {
        private readonly TodoHandler _todoHandler;
        public Mock<ITodoService> _todoServiceMoq;

        public TodoHandlerTests(TodoHandlerFixture todoHandlerFixture)
        {
            _todoHandler = todoHandlerFixture.TodoHandler;
            _todoServiceMoq = todoHandlerFixture.TodoService;
        }

        [Fact]
        public void Handler_FirstTodoNotNull()
        {
            var testTodos = SetupHandler();

            var handlerResponse = _todoHandler.GetFirstTodo();

            Assert.NotNull(handlerResponse.Result);
        }

        [Fact]
        public void Handler_OnlyFirstTodoIsReturned()
        {
            var testTodos = SetupHandler();
            var handlerResponse = _todoHandler.GetFirstTodo();

            Assert.True(testTodos[0].Equals(handlerResponse.Result));
        }

        [Fact]
        public void Handler_AllTodosNotNull()
        {
            var testTodos = SetupHandler();

            var handlerResponse = _todoHandler.GetAllTodos();

            Assert.NotNull(handlerResponse.Result);
        }

        [Fact]
        public void Handler_AllTodosReturned()
        {
            var testTodos = SetupHandler();

            var handlerResponse = _todoHandler.GetAllTodos();

            Assert.Equal(testTodos.Count, handlerResponse.Result.Count);
        }

        private List<TodoModel> SetupHandler()
        {
            var fixture = new Fixture();
            fixture.RepeatCount = 10;

            var todos = fixture.Create<List<TodoModel>>();

            _todoServiceMoq.Setup(tsm => tsm.CallTodoApi()).ReturnsAsync(todos);
            return todos;
        }
    }
}
