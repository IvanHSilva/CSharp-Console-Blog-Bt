using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class UserRepository
{
    public IEnumerable<User> SelectAll()
    {
        using var connection = new SqlConnection("");
        return connection.GetAll<User>();
    }
}