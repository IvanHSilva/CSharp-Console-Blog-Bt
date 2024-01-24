using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class UserRepository
{
    private readonly SqlConnection _connection;

    public UserRepository(SqlConnection connection)
        => _connection = connection;

    public IEnumerable<User> SelectAll()
        => _connection.GetAll<User>();

    public User Select(int id)
        => _connection.Get<User>(id);

    public void Insert(User user)
        => _connection.Insert(user);

    public void Update(User user)
    => _connection.Update(user);

    public void Delete(User user)
    => _connection.Delete(user);

    public void Delete(int id)
    {
        var user = Select(id);
        _connection.Delete(user);
    }
}
