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

            User user = new()
            {
                Name = "Davi Henriques",
                Email = "davilealhenriques@gmail.com",
                PasswordHash = "0145451321654ASGJUYTECSAX",
                Bio = "Estudante",
                Image = "https://",
                Slug = "davi-henriques"
            };

            Role role = new()
            {
                Name = "Follower",
                Slug = "follower"
            };

            // CreateUser(connection, user);
            // CreateRole(connection, role);
            // CreateUserRole(connection, user, role);
            //UpdatetUser(user);

            //DeleteUser(7);
            Console.WriteLine();

            Console.WriteLine($"Usuários + Regras:");
            ReadUsersWithRoles(connection);

            // Console.WriteLine($"Usuários:");
            // ReadUsers(connection);
            // Console.WriteLine();
            // Console.WriteLine($"Regras:");
            // ReadRoles(connection);
            // Console.WriteLine();
            // Console.WriteLine($"Tags:");
            // ReadTags(connection);
            Console.WriteLine();

            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.SelectAll();

            foreach (var item in items)
                Console.WriteLine($"{item.Name} - Id {item.Id}");
        }

        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            UserRepository repository = new(connection);
            var items = repository.SelectWithRoles();

            foreach (var user in items)
            {
                Console.WriteLine($"{user.Name} - Id {user.Id}");
                foreach (var role in user.Roles)
                    Console.WriteLine($" - {role.Name} - Id {role.Id}");
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

        public static void CreateUser(SqlConnection connection, User user)
        {
            var repository = new Repository<User>(connection);
            repository.Insert(user);
        }

        public static void CreateRole(SqlConnection connection, Role role)
        {
            var repository = new Repository<Role>(connection);
            repository.Insert(role);
        }

        public static void CreateUserRole(SqlConnection connection, User user, Role role)
        {
            UserRepository repository = new(connection);
            repository.AddRole(user, role);
        }
    }
}

