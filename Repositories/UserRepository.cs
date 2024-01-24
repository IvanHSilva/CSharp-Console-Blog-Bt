using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class UserRepository
{
    private SqlConnection _connection = new("");

    public IEnumerable<User> SelectAll()
        => _connection.GetAll<User>();

    public User Select(int id)
        => _connection.Get<User>(id);

    public void Insert(User user)
        => _connection.Insert(user);

    public void Update(User user)
    => _connection.Update(user);


    public void Delete(int id)
    {
        var user = Select(id);
        _connection.Delete(user);
    }
}