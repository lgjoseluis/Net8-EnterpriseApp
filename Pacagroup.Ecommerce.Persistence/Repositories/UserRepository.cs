using System.Data;

using Dapper;

using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Application.Interface.Persistence;

namespace Pacagroup.Ecommerce.Persistence.Repositories;

public class UserRepository : GenericRepository<Users>, IUserRepository
{
    public UserRepository(IDbConnection dbConnection) : base(dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public Users Authenticate(string userName, string password)
    {
        string command = "UsersGetByUserAndPassword";

        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("UserName", userName);
        parameters.Add("Password", password);

        using (_dbConnection)
        {
            Users user = _dbConnection.QuerySingle<Users>(command, parameters, commandType: CommandType.StoredProcedure);

            return user;
        }
    }
}
