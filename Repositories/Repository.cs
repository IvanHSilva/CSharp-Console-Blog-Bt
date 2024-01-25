using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class Repository<T> where T : class
{
    private readonly SqlConnection _connection;

    public Repository(SqlConnection connection)
        => _connection = connection;

    public IEnumerable<T> SelectAll()
        => _connection.GetAll<T>();

    public T Select(int id)
        => _connection.Get<T>(id);

    public void Insert(T t)
        => _connection.Insert(t);

    public void Update(T t)
        => _connection.Update(t);

    public void Delete(Role role)
        => _connection.Delete(role);


    public void Delete(int id)
    {
        var role = Select(id);
        _connection.Delete(role);
    }
}
