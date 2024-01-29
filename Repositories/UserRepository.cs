using System.Data;
using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class UserRepositoty(SqlConnection connection) : Repository<User>(connection)
{
    private readonly SqlConnection _connection = connection;


}