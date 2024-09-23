using System.Data;

using Dapper;

using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Infrastructure.Data;
using Pacagroup.Ecommerce.Infrastructure.Interface;

namespace Pacagroup.Ecommerce.Infrastructure.Repository;

public class UserRepository : GenericRepository<Users>, IUserRepository
{
    private readonly DapperContext _context;

    public UserRepository(DapperContext context):base(context)
    {
        _context = context;
    }

    public Users Authenticate(string userName, string password)
    {
        string command = "UsersGetByUserAndPassword";

        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("UserName", userName);
        parameters.Add("Password", password);

        using (IDbConnection connection = _context.CreateConnection())
        {
            Users user = connection.QuerySingle<Users>(command, parameters, commandType: CommandType.StoredProcedure);

            return user;
        }
    }
}
