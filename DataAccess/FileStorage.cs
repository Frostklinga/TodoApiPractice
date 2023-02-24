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
    public class FileStorage : DataAccessBase
    {
        readonly string filePath = @".\";
        readonly string storageFileName = "datastore.json";
        readonly string pathAndFilename;
        Dictionary<int,TodoModel> todoList;
        int index = 0;
        public FileStorage()
        {
            pathAndFilename = filePath + storageFileName;
            todoList = new Dictionary<int, TodoModel>();
        }

        void SaveToFile() 
        {
            var todosAsJson = JsonConvert.SerializeObject(todoList, Formatting.Indented);
            File.WriteAllText(pathAndFilename, todosAsJson);
        }
        public override void Add(TodoModel todo)
        {
            index++;
            todoList.Add(index, todo);
            SaveToFile();
        }
        public override void Delete(TodoModel todo)
        {
            todoList.Remove(todo.Id);
            SaveToFile();
        }
        public override void DeleteAll()
        {
            File.Delete(pathAndFilename);
            File.Create(pathAndFilename);
        }
        public override Dictionary<int, TodoModel> GetAllTodos()
        {
            return todoList;
        }
        public override TodoModel GetById(int id)
        {
            return todoList[id];
        }
        public override void Update(TodoModel todo)
        {
            todoList[todo.Id] = todo;
        }
    }
}
