﻿using Pacagroup.Ecommerce.Infrastructure.Data;
using System.Data;

namespace Pacagroup.Ecommerce.Infrastructure.Repository
{
    public abstract class RepositoryBase
    {
        protected IDbConnection _dbConnection;
        protected IDbTransaction? _dbTransaction;

        protected RepositoryBase(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void SetTransaction(IDbTransaction dbTransaction)
        {
            _dbTransaction = dbTransaction;
        }

        public void SetConnection(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
    }
}
