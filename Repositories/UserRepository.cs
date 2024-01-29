using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class UserRepository(SqlConnection connection) : Repository<User>(connection)
{
    private readonly SqlConnection _connection = connection;

    public List<User> SelectWithRoles()
    {

        string query = @"SELECT [Users].*, [Roles].* FROM [Users]
        LEFT JOIN [UsersRoles] On [UsersRoles].[UserId] = [Users].[Id]
        LEFT JOIN [Roles] On [UsersRoles].[RoleId] = [Roles].[Id]";

        List<User> users = [];

        var items = _connection.Query<User, Role, User>(
            query, (user, role) =>
            {
                var usr = users.FirstOrDefault(u => u.Id == user.Id);
                if (usr == null)
                {
                    usr = user;
                    if (role != null)
                        usr.Roles.Add(role);
                    users.Add(usr);
                }
                else
                    usr.Roles.Add(role);

                return user;
            },
            splitOn: "Id"
        );

        return users;
    }

    public void AddRole(User user, Role role)
    {
        if (role != null)
            user.Roles.Add(role);
    }

    public void RemoveRole(User user, Role role)
    {
        if (role != null)
            user.Roles.Remove(role);
    }

}