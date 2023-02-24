using Api.Models;

namespace Api.DataAccess
{
    public interface IDataAccess
    {
        public void Add(TodoModel todo);
        public TodoModel GetAllTodos();
        public TodoModel GetById(int id);
        public void Update(TodoModel todo);
        public void Delete(TodoModel todo);
        public void DeleteAll();
    }
}