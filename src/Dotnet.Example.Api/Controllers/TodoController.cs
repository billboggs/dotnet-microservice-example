using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Dotnet.Example.Core.Handlers;
using Dotnet.Example.Core.Models;

using Microsoft.AspNetCore.Mvc;

namespace Dotnet.Example.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public readonly ITodoHandler _todoHandler;

        public TodoController(ITodoHandler todoHandler)
        {
            _todoHandler = todoHandler;
        }

        /// <summary>
        /// Gets all the remaining todos 
        /// </summary>
        /// <returns>Returns all outstanding toods </returns>
        /// <response code="200">Returns the full list of todos</response>
        /// <response code="500">If there is any server side error</response>   
        [Route("all")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var todos = await _todoHandler.GetAllTodos();
                return Ok(todos);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }


        /// <summary>
        /// Gets the first todo from the list of remaining todos
        /// </summary>
        /// <returns>Returns the first todo in the list</returns>
        /// <response code="200">First todo in the list</response>
        /// <response code="500">If there is any server side error</response>    
        [Route("first")]
        [HttpGet]
        public async Task<IActionResult> GetFirstTodo()
        {
            try
            {
                var firstTodo = await _todoHandler.GetFirstTodo();
                return Ok(firstTodo);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
