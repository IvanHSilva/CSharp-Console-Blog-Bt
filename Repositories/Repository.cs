using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class Repository<T>(SqlConnection connection) where T : class
{
    private readonly SqlConnection _connection = connection;

    public IEnumerable<T> SelectAll()
        => _connection.GetAll<T>();

    public T Select(int id)
        => _connection.Get<T>(id);

    public void Insert(T model)
        => _connection.Insert(model);

    public void Update(T model)
        => _connection.Update(model);

    public void Delete(T model)
        => _connection.Delete(model);

    public void Delete(int id)
    {
        var model = Select(id);
        _connection.Delete(model);
    }
}
