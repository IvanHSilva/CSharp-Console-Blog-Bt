using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.RoleRepositories;

public class RoleRepository
{
    private readonly SqlConnection _connection;

    public RoleRepository(SqlConnection connection)
        => _connection = connection;

    public IEnumerable<Role> SelectAll()
        => _connection.GetAll<Role>();

    public Role Select(int id)
        => _connection.Get<Role>(id);

    public void Insert(Role role)
        => _connection.Insert(role);

    public void Update(Role role)
        => _connection.Update(role);

    public void Delete(Role role)
        => _connection.Delete(role);


    public void Delete(int id)
    {
        var role = Select(id);
        _connection.Delete(role);
    }
}
