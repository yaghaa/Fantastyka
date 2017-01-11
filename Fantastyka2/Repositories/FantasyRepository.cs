using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Fantastyka2.Models;

namespace Fantastyka2.Repositories
{
    public class FantasyRepository
    {
        private static string _connectionString = "Data Source=.;Initial Catalog=Fantastyka;Integrated Security=True";
        public List<Models.Book> GetAllBooks()
        {
            var resultList = new List<Book>();
            
            string query = @"select [id],[title],[author],[publisher],[category],[price] from Books";

            using (var connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                var dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        var book = new Book();
                        book.Id = dataReader.GetInt32(0);
                        book.Title = dataReader.GetString(1);
                        book.Author = dataReader.GetString(2);
                        book.Publisher = dataReader.GetString(3);
                        book.Category = dataReader.GetString(4);
                        book.Price = dataReader.GetDouble(5);
                        resultList.Add(book);
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            return resultList;
        }

        public void SaveBook(Book book)
        {

            string query = @"insert into Books ([title],[author],[publisher],[category],[price])
                             values(@title, @author, @publisher, @category, @price)";

            using (var connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                // add parameters and their values
                cmd.Parameters.Add("@title", System.Data.SqlDbType.NVarChar, 100).Value = book.Title;
                cmd.Parameters.Add("@author", System.Data.SqlDbType.NVarChar, 100).Value = book.Author;
                cmd.Parameters.Add("@publisher", System.Data.SqlDbType.NVarChar, 100).Value = book.Publisher;
                cmd.Parameters.Add("@category", System.Data.SqlDbType.NVarChar, 100).Value = book.Category;
                cmd.Parameters.Add("@price", System.Data.SqlDbType.Float).Value = book.Price;

                // open connection, execute command and close connection
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Book GetBookForId(int id)
        {
            string query = @"select [title],[author],[publisher],[category],[price] from Books where id=@id";
            Book book = new Book(); ;
            using (var connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                var param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = id;
                cmd.Parameters.Add(param);
                connection.Open();
                var dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        book.Id = id;
                        book.Title = dataReader.GetString(0);
                        book.Author = dataReader.GetString(1);
                        book.Publisher = dataReader.GetString(2);
                        book.Category = dataReader.GetString(3);
                        book.Price = dataReader.GetDouble(4);
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            return book;
        }

        public List<ShoppingCartModel> GetShoppingCartItems(string userId)
        {
            var result = new List<ShoppingCartModel>();

            string query = @"select bookId,amount from ShoppingCart where clientId =@clientId";

            using (var connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                var param = new SqlParameter();
                param.ParameterName ="@clientId";
                param.Value = userId;

                cmd.Parameters.Add(param);
                connection.Open();
                var dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        var book = GetBookForId(dataReader.GetInt32(0));
                        var amount = dataReader.GetInt32(1);

                        var model = new ShoppingCartModel()
                        {
                            Book = book,
                            Amount = amount
                        };
                        result.Add(model);
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            return result;
        }

        public void AddToCart(List<string> ids, string clientId)
        {
            var shoppingCart = GetShoppingCartItems(clientId);
            string queryInsert = @" insert into ShoppingCart (clientId,bookId,amount)
  values(@clientId,@bookId,1)";
            string queryUpdate = @"Update ShoppingCart set amount = amount+1 where clientId= @clientId and bookId = @bookId";

            using (var connection = new SqlConnection(_connectionString))
            {
                foreach (var id in ids)
                {
                    var query="";
                    if (shoppingCart.Any(x => x.Book.Id == Int32.Parse(id)))
                    {
                        query = queryUpdate;
                    }
                    else
                    {
                        query = queryInsert;
                    }


                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        var param = new SqlParameter();
                        param.ParameterName = "@clientId";
                        param.Value = clientId;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@bookId";
                        param.Value = id;
                        cmd.Parameters.Add(param);

                        //cmd.Parameters["@clientId"].Value = clientId;
                        //cmd.Parameters["@bookId"].Value = id;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }

            }
        }
    }
}