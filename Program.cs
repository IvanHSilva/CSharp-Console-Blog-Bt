using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string connectionString =
            "Data Source=.\\SQLSERVER;Database=Blog;Integrated Security=True;Encrypt=False;";

        static void Main(string[] args)
        {
            SqlConnection connection = new(connectionString);
            connection.Open();
            //ReadUsers();
            //SelectUser(1);

            // User user = new()
            // {
            //     Name = "Davi Henriques",
            //     Email = "davilealhenriques@gmail.com",
            //     PasswordHash = "0145451321654ASGJUYTECSAX",
            //     Bio = "Estudante",
            //     Image = "https://",
            //     Slug = "davi-henriques"
            // };
            // //InsertUser(user);

            User user = new()
            {
                Id = 7,
                Name = "Angela Henriques",
                Email = "angelahenriquessilva@gmail.com",
                PasswordHash = "123545456654ASGJUYTECSAX",
                Bio = "Dona de Casa",
                Image = "https://",
                Slug = "angela-henriques"
            };

            //UpdatetUser(user);

            //DeleteUser(7);
            Console.WriteLine();
            Console.WriteLine($"Usuários:");
            ReadUsers(connection);
            Console.WriteLine();
            Console.WriteLine($"Regras:");
            ReadRoles(connection);
            Console.WriteLine();
            Console.WriteLine($"Tags:");
            ReadTags(connection);
            Console.WriteLine();

            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.SelectAll();

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name} - Id {item.Id}");
                ReadRoles(connection);
            }
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.SelectAll();

            foreach (var item in items)
                Console.WriteLine($"{item.Name} - Id {item.Id}");
        }

        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.SelectAll();

            foreach (var item in items)
                Console.WriteLine($"{item.Name} - Id {item.Id}");
        }
    }
}

