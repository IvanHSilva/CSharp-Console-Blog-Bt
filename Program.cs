using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string connectionString =
            "Data Source=.\\SQLSERVER;Database=Blog;Integrated Security=True;Encrypt=False;";

        static void Main(string[] args)
        {
            ReadUsers();
        }

        public static void ReadUsers()
        {
            Console.Clear();
            Console.WriteLine($"Usuários:");

            using (var connection = new SqlConnection(connectionString))
            {
                var users = connection.GetAll<User>();

                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Name}");
                }
            }

            Console.WriteLine();
        }
    }
}

