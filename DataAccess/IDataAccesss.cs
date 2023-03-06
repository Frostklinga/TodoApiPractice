using Api.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.DataAccess
{
    internal interface IDataAccess
    {
        public void Add(TodoModel todo);
        public Dictionary<int, TodoModel> GetAllTodos();
        public TodoModel ?GetById(int id);
        public void Update(TodoModel todo);
        public void Delete(TodoModel todo);
        public void DeleteAll();
    }
}