using Microsoft.AspNetCore.Mvc;
using Api.DataAccess;
using Api.DataAccess.FileRepository;
using Api.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        DataAccess DataRepository { get; set; }
        public TodoController()
        {
            DataRepository = new FileStorage(); ;
        }
        // GET: api/<TodoController>
        [HttpGet]
        public IEnumerable<TodoModel> Get()
        {
            var todos = DataRepository.GetAllTodos();
            return todos;
        }

        // GET api/<TodoController>/5
        [HttpGet("{todo}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TodoController>
        //[HttpPost]
        //public void Post([FromBody] TodoModel todo)
        //{
        //}
        [HttpPost]
        public void AddTodo([FromBody] TodoModel todo)
        {
            DataRepository.Add(todo);
        }

        // PUT api/<TodoController>/5
        [HttpPut("{todo}")]
        public void Put(int id, [FromBody] TodoModel todo)
        {
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{todo}")]
        public void Delete(TodoModel todo)
        {
        }
    }
}
