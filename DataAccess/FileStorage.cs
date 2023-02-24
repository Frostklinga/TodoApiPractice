using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace Api.DataAccess.FileRepository
{
    public class FileStorage : IDataAccess
    {
        readonly string filePath = @".\";
        readonly string storageFileName = "datastore.json";
        readonly string pathAndFilename;
        List<TodoModel> todoList;
        public FileStorage()
        {
            pathAndFilename = filePath + storageFileName;
            todoList = new List<TodoModel>();
        }
        public void Add(TodoModel todo)
        {
            var todoAsJson = JsonConvert.SerializeObject(todo, Formatting.Indented);
            File.WriteAllText(pathAndFilename, todoAsJson);
        }

        public void Delete(TodoModel todo)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoModel> GetAllTodos()
        {
            var todo1 = new TodoModel("Todo 1", "The first todo", DateTime.Now, 1);
            var todo2 = new TodoModel("Todo 2", "The second todo", DateTime.Now.AddDays(1), 2);
            var todoList = new List<TodoModel>();
            todoList.Add(todo1);
            todoList.Add(todo2);
            return todoList;
        }

        public TodoModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoModel todo)
        {
            throw new NotImplementedException();
        }
    }
}
