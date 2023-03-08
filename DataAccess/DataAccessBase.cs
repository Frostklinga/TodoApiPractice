using DataAccess.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public abstract class DataAccessBase : IDataAccess
    {
        public abstract void Add(TodoModel todo);
        public abstract void Delete(TodoModel todo);
        public abstract void DeleteAll();
        public abstract IEnumerable<TodoModel> GetAllTodos();
        public abstract TodoModel? GetById(int id);
        public abstract void Update(TodoModel todo);
        //public Exception EmptyListException = new Exception("The list of todos is empty");
        //public Exception TodoNotFoundException = new Exception("The provied todo item was not found");
    }
}
