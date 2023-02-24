using Api.Models;

namespace Api.DataAccess
{
    internal interface IDataAccess
    {
        public void Add(TodoModel todo);
        public IEnumerable<TodoModel> GetAllTodos();
        public TodoModel GetById(int id);
        public void Update(TodoModel todo);
        public void Delete(TodoModel todo);
        public void DeleteAll();
        public List<TodoModel> GetReference();
    }
}