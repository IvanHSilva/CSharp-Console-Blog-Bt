using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string connectionString =
            "Data Source=.\\SQLSERVER;Database=Blog;Integrated Security=True;Encrypt=False;";

        static void Main(string[] args)
        {
            Database.Connection = new(connectionString);
            Database.Connection.Open();
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

            Category category = new()
            {
                Name = "Backend",
                Slug = "backend"
            };

            Tag tag = new()
            {
                Name = "C#",
                Slug = "c-sharp"
            };

            Post post = new()
            {
                CategoryId = 1,
                AuthorId = 1,
                Title = "Vantagens da linguagem C#",
                Slug = "vantagens-c-sharp"
            };


            // CreateUser(connection, user);
            // CreateRole(connection, role);
            // CreateUserRole(connection, user, role);
            // CreateCategory(connection, category);
            // CreateTag(connection, tag);
            // CreatePost(connection, post);
            //UpdatetUser(user);

            //DeleteUser(7);
            Console.WriteLine();

            // Console.WriteLine($"Usuários + Regras:");
            // ReadUsersWithRoles(connection);

            // Console.WriteLine($"Usuários:");
            // ReadUsers(connection);
            // Console.WriteLine();
            // Console.WriteLine($"Regras:");
            // ReadRoles(connection);
            // Console.WriteLine();
            // Console.WriteLine($"Tags:");
            // ReadTags(connection);
            Console.WriteLine();
            LoadScreens();
            Console.ReadKey();

            Database.Connection.Close();
        }

        public static void LoadScreens()
        {
            Console.Clear();
            Console.WriteLine("Menu Blog");
            Console.WriteLine("---------");
            Console.WriteLine("1) Usuários");
            Console.WriteLine("2) Perfis");
            Console.WriteLine("3) Categorias");
            Console.WriteLine("4) Tags");
            Console.WriteLine("5) Vincular Usuário e Perfil");
            Console.WriteLine("6) Vincular Post e Tag");
            Console.WriteLine("7) Relatórios");
            Console.WriteLine("0) Sair");
            Console.WriteLine();

            var option = short.Parse(Console.ReadLine()!);
            switch (option)
            {
                //case 1:
                //MenuUserScreen.LoadScreen(); break;
                //case 2:
                //CreateTagScreen.LoadScreen(); break;
                //case 3:
                //UpdateTagScreen.LoadScreen(); break;
                case 4:
                    MenuTagScreen.LoadScreen(); break;
                case 0:
                    Console.Clear(); Environment.Exit(0); break;
                default: LoadScreens(); break;
            }
        }

        public static void ReadUsers()
        {
            var repository = new Repository<User>();
            var items = repository.SelectAll();

            foreach (var item in items)
                Console.WriteLine($"{item.Name} - (Id {item.Id})");
        }

        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            UserRepository repository = new();
            var items = repository.SelectWithRoles();

            foreach (var user in items)
            {
                Console.WriteLine($"{user.Name} - {user.Email} (Id {user.Id})");
                foreach (var role in user.Roles)
                    Console.WriteLine($" - {role.Name} - Id {role.Id}");
            }
        }

        public static void ReadRoles()
        {
            var repository = new Repository<Role>();
            var items = repository.SelectAll();

            foreach (var item in items)
                Console.WriteLine($"{item.Name} - Id {item.Id}");
        }

        public static void ReadTags()
        {
            var repository = new Repository<Tag>();
            var items = repository.SelectAll();

            foreach (var item in items)
                Console.WriteLine($"{item.Name} - Id {item.Id}");
        }

        public static void CreateUser(User user)
        {
            var repository = new Repository<User>();
            repository.Insert(user);
        }

        public static void CreateRole(Role role)
        {
            var repository = new Repository<Role>();
            repository.Insert(role);
        }

        public static void CreateUserRole(User user, Role role)
        {
            UserRepository repository = new();
            repository.AddRole(user, role);
        }

        public static void CreateCategory(Category category)
        {
            var repository = new Repository<Category>();
            repository.Insert(category);
        }

        public static void CreateTag(Tag tag)
        {
            var repository = new Repository<Tag>();
            repository.Insert(tag);
        }

        public static void CreatePost(Post post)
        {
            var repository = new Repository<Post>();
            repository.Insert(post);
        }

        public static void CreatePostTag(Post post, Tag tag)
        {
            //UserRepository repository = new(connection);
            //repository.AddRole(user, role);
        }
    }
}

