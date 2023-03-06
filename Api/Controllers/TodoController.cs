using Microsoft.AspNetCore.Mvc;
using Api.DataAccess;
using Api.DataAccess.FileRepository;
using Api.DataAccess.SqlRepository;
using Api.Models;
using System.Diagnostics;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        DataAccessBase DataRepository { get; set; }
        public TodoController()
        {
            DataRepository = new SqlStorage(); ;
        }
        // GET: api/<TodoController>
        [HttpGet("GetAllTodos")]
        public Dictionary<int,TodoModel> Get()
        {
            var todos = DataRepository.GetAllTodos();
            return todos;
        }

        // GET api/<TodoController>/5
        [HttpGet("GetById")]
        public TodoModel Get(int id)
        {
            try
            {
                return DataRepository.GetById(id);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
        [HttpPost("AddTodo")]
        public void AddTodo([FromBody] TodoModel todo)
        {
            try
            {
                DataRepository.Add(todo);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("DeleteTodo")]
        public void Delete(TodoModel todo)
        {
            try
            {
                DataRepository.Delete(todo);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}
