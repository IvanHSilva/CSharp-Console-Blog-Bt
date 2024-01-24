using Blog.Models;
using Blog.Repositories;
using Blog.RoleRepositories;
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

            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.SelectAll();

            foreach (var user in users)
                Console.WriteLine($"{user.Name} - Id {user.Id}");
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new RoleRepository(connection);
            var roles = repository.SelectAll();

            foreach (var role in roles)
                Console.WriteLine($"{role.Name} - Id {role.Id}");
        }

        public static void SelectUser(int id)
        {
            Console.Clear();
            Console.WriteLine($"Usuário:");

            using (var connection = new SqlConnection(connectionString))
            {
                var user = connection.Get<User>(id);

                Console.WriteLine($"{user.Name}");
            }

            Console.WriteLine();
        }

        public static void InsertUser(User user)
        {
            Console.Clear();
            Console.WriteLine($"Novo Usuário:");

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Insert(user);

                Console.WriteLine($"{user.Name}");
            }

            Console.WriteLine();
        }

        public static void UpdatetUser(User user)
        {
            Console.Clear();
            Console.WriteLine($"Usuário Atualizado:");
            SelectUser(user.Id);

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Update(user);

                Console.WriteLine($"{user.Name}");
            }

            Console.WriteLine();
        }

        public static void DeleteUser(int id)
        {
            Console.Clear();
            Console.WriteLine($"Usuário Excluído:");

            using (var connection = new SqlConnection(connectionString))
            {
                User user = connection.Get<User>(id);
                connection.Delete(user);

                Console.WriteLine($"{user.Name}");
            }

            Console.WriteLine();
        }
    }
}

