using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace Api.DataAccess.SqlRepository
{
    public class SqlStorage : DataAccessBase
    {
        public SqlStorage()
        {
            var dbHost = "localhost";
            var dbName = "todos";
            var dbPassword = "Test1234!";
            var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};TrustServerCertificate=True";
            

            try
            {
                var connection = new SqlConnection(connectionString);
                var query = "select * from todos";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
            }
            catch (SqlException sqlE)
            {
                Debug.WriteLine(sqlE.Message);
                throw;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public override void Add(TodoModel todo)
        {
            throw new NotImplementedException();
        }

        public override void Delete(TodoModel todo)
        {
            throw new NotImplementedException();
        }

        public override void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<int, TodoModel> GetAllTodos()
        {
            throw new NotImplementedException();
        }

        public override TodoModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(TodoModel todo)
        {
            throw new NotImplementedException();
        }
    }
}
