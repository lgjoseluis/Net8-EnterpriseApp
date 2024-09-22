using System.Data;

using Dapper;

using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Infrastructure.Interface;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly IConnectionFactory _connectionFactory;

    public UserRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public User Authenticate(string userName, string password)
    {
        string command = "UsersGetByUserAndPassword";

        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("UserName", userName);
        parameters.Add("Password", password);

        using (IDbConnection connection = _connectionFactory.GetConnection)
        {
            User user = connection.QuerySingle<User>(command, parameters, commandType: CommandType.StoredProcedure);

            return user;
        }
    }
}
