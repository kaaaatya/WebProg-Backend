using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class SearchController : ApiController
    {
        private DBModel db = new DBModel();

        [HttpPost]
        [Route("api/Search")]
        public IEnumerable<Book> SearchBooks(string text)
        {
            string sqlExpression = "Search";

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add("@text", SqlDbType.VarChar);
                command.Parameters["@text"].Value = text;
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                List<Book> Books = new List<Book>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string author = reader.GetString(2);
                        int year = reader.GetInt32(3);
                        Books.Add(new Book()
                        {
                            BookId = id,     
                            BookName = name,     
                            AuthorName= author,
                            PublishingYear = year
                        });
                    }
                }
                reader.Close();
                return Books;
            }
        }
    }
}
