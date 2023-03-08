using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using DataAccess.Models;
using DataAccess;

namespace DataAccess.FileStorage
{
    public class FileStorage : DataAccessBase
    {
        readonly string filePath = @".\";
        readonly string storageFileName = "datastore.json";
        readonly string pathAndFilename;
        IEnumerable<TodoModel> todoList;
        int index = 0;
        public FileStorage()
        {
            pathAndFilename = filePath + storageFileName;
            var todosFromFile = File.ReadAllText(pathAndFilename);
            todoList = JsonConvert.DeserializeObject<IEnumerable<TodoModel>>(todosFromFile);
            index = todoList.Select(x => x.Id).ToList().Max();
        }

        void SaveToFile()
        {
            var todosAsJson = JsonConvert.SerializeObject(todoList, Formatting.Indented);
            File.WriteAllText(pathAndFilename, todosAsJson);
        }
        public override void Add(TodoModel todo)
        {
            index++;
            todoList.Append(todo);
            SaveToFile();
        }
        public override void Delete(TodoModel todo)
        {
            var removedTodo = todoList.Select(x => x).Where(x => x.Id != todo.Id);
            todoList = removedTodo;
            SaveToFile();
        }
        public override void DeleteAll()
        {
            File.Delete(pathAndFilename);
            File.Create(pathAndFilename);
        }
        public override IEnumerable<TodoModel> GetAllTodos()
        {
            return todoList;
        }
        public override TodoModel GetById(int id)
        {
            return todoList.Single(x => x.Id == id);
        }
        public override void Update(TodoModel todo)
        {
            var id = todo.Id;
            IEnumerable<TodoModel> removedTodoList = todoList.Select(x => x).Where(x => x.Id != id);
            removedTodoList.Append(todo);
            SaveToFile();
        }
    }
}
