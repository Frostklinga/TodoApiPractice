using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Api.DataAccess.FileRepository
{
    public class FileStorage : IDataAccess
    {
        public readonly string filePath = @".\";
        public readonly string storageFileName = "datastore.json";
        public FileStorage()
        {
            
        }
        public void Add(TodoModel todo)
        {
            var todoAsJson = JsonConvert.SerializeObject(todo, Formatting.Indented);
            File.WriteAllText(filePath, todoAsJson);
        }

        public void Delete(TodoModel todo)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public TodoModel GetAllTodos()
        {
            throw new NotImplementedException();
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
