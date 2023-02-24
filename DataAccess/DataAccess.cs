using Api.DataAccess;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public abstract class DataAccess : IDataAccess
    {
        Dictionary<int,TodoModel> Todos;
        int index = 0;
        public DataAccess()
        {
            Todos = new Dictionary<int, TodoModel>();
        }
        public abstract void Add(TodoModel todo);
        public virtual void Delete(TodoModel todo);
        public virtual void DeleteAll();
        public virtual IEnumerable<TodoModel> GetAllTodos();
        public virtual TodoModel GetById(int id);

        public List<TodoModel> GetReference()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TodoModel todo);
        public static class TodoFactory
        {

        }
    }
}
