using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TodoRepository
    {
        List<TodoModel> Todos = new List<TodoModel>();
        public TodoRepository()
        {
        }
        public List<TodoModel> GetReference()
        { 
            return Todos; 
        }
    }
}
