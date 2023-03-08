using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Data.Common;
using System.Collections;
using DataAccess.Models;

namespace DataAccess.SqlStorage
{
    public class SqlStorage : DataAccessBase
    {
        const string dbHost = "localhost";
        const string dbName = "todos";
        const string dbPassword = "Test1234!";
        const string connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};TrustServerCertificate=True";
        SqlConnection? sqlConnection = null;

        public SqlStorage()
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
            }
            catch (SqlException sqlE)
            {
                Debug.WriteLine(sqlE.Message);
                throw;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public override void Add(TodoModel todo)
        {
            string insertTodoItemIntoSqlDatabase = "INSERT INTO todos (Title, Content, Created) ";
            string values = $"""
                VALUES 
                    ('{todo.Title}', 
                    '{todo.Content}', 
                    '{todo.Created}');
                """;
            string commandText = insertTodoItemIntoSqlDatabase + values;
            try
            {
                SqlCommand insert = new SqlCommand($"{insertTodoItemIntoSqlDatabase} {values}", sqlConnection);
                var rowsAffected = insert.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public override void Delete(TodoModel todo)
        {
            string deleteTodoItemFromSqlDatabase = "DELETE FROM todos";
            string values = $""" 
                                WHERE 
                                    ID = {todo.Id}
                            """;
            SqlCommand deleteFromTodosWhere = new SqlCommand(deleteTodoItemFromSqlDatabase, sqlConnection);
            var rowsAffected = deleteFromTodosWhere.ExecuteNonQuery();
        }

        public override void DeleteAll()
        {
            string deleteAllTodos = "DELETE FROM todos;";
            SqlCommand deleteFromTodosWhere = new SqlCommand(deleteAllTodos, sqlConnection);
            var rowsAffected = deleteFromTodosWhere.ExecuteNonQuery();
        }

        public override IEnumerable<TodoModel> GetAllTodos()
        {
            string getAllTodos = $"SELECT * FROM todos;";
            var getAllTodosSqlCommand = new SqlCommand(getAllTodos, sqlConnection);
            using (var reader = getAllTodosSqlCommand.ExecuteReader())
            {
                //IEnumerable<TodoModel> todos = null;
                List<TodoModel> todos = new List<TodoModel>();
                while (reader.Read())
                {
                    TodoModel todo = SqlDataParseHelper(reader);
                    todos.Add(todo);
                }
                var test = (IEnumerable<TodoModel>)todos;
                return todos;
            }
        }

        public override TodoModel GetById(int id)
        {
            string getTodoById = $"SELECT * FROM todos WHERE Id = {id};";
            var getTodoByIdSqlCommand = new SqlCommand(getTodoById, sqlConnection);
            TodoModel todo = null;
            using (var reader = getTodoByIdSqlCommand.ExecuteReader())
            {
                if (!reader.HasRows)
                {

                }
                while (reader.Read())
                {
                    todo = SqlDataParseHelper(reader);
                }
            }
            return todo;
        }
        public override void Update(TodoModel todo)
        {
            throw new NotImplementedException();
        }
        TodoModel SqlDataParseHelper(SqlDataReader reader)
        {
            var tableColumns = reader.GetColumnSchema();
            string idColumn = tableColumns.Select(x => x.ColumnName).Where(y => y == "Id").First();
            string titleColumn = tableColumns.Select(x => x.ColumnName).Where(y => y == "Title").First();
            string contentColumn = tableColumns.Select(x => x.ColumnName).Where(y => y == "Content").First();
            string createdColumn = tableColumns.Select(x => x.ColumnName).Where(y => y == "Created").First();

            var title = reader[titleColumn].ToString();
            var content = reader[contentColumn].ToString();
            DateTime.TryParse(reader[createdColumn].ToString(), out DateTime created);
            int.TryParse(reader[idColumn].ToString(), out int id);

            var todo = new TodoModel(title, content, created, id);
            return todo;
        }
    }
}
