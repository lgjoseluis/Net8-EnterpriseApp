
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using System.Data;

using Dapper;
using static Dapper.SqlMapper;

using Pacagroup.Ecommerce.Application.Interface.Persistence;

namespace Pacagroup.Ecommerce.Persistence.Repositories
{
    public class GenericRepository<T> : RepositoryBase, IGenericRepository<T> where T : class
    {
        public GenericRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        #region async methods
        public async Task<bool> InsertAsync(T entity)
        {
            int rowsEffected = 0;
            string queryInsert = CreateQueryInsert();

            rowsEffected = await _dbConnection.ExecuteAsync(queryInsert, entity, _dbTransaction);

            return rowsEffected > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            int rowsEffected = 0;
            string queryUpdate = CreateQueryUpdate();

            rowsEffected = await _dbConnection.ExecuteAsync(queryUpdate, entity, _dbTransaction);

            return rowsEffected > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            int rowsEffected = 0;
            string queryDelete = CreateQueryDeleteById();

            rowsEffected = await _dbConnection.ExecuteAsync(queryDelete, new { Id = id }, _dbTransaction);

            return rowsEffected > 0;
        }

        public async Task<T?> GetAsync(string id)
        {
            string querySelect = CreateQuerySelectById();

            T? entity = await _dbConnection.QueryFirstOrDefaultAsync<T>(querySelect, new { Id = id });

            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            string querySelect = CreateQuerySelectAll();

            IEnumerable<T> entities = await _dbConnection.QueryAsync<T>(querySelect);

            return entities;
        }
        #endregion

        #region prepare query
        private string CreateQueryInsert()
        {
            string tableName = GetTableName();
            string columns = GetColumns(excludeKey: true);
            string properties = GetPropertyNames(excludeKey: true);
            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({properties})";

            return query;
        }

        private string CreateQueryUpdate()
        {
            string? tableName = GetTableName();
            string? keyColumn = GetKeyColumnName();
            string? keyProperty = GetKeyPropertyName();

            StringBuilder query = new StringBuilder();
            query.Append($"UPDATE {tableName} SET ");

            foreach (var property in GetProperties(true))
            {
                var columnAttribute = property.GetCustomAttribute<ColumnAttribute>();

                string propertyName = property.Name;
                string columnName = columnAttribute?.Name ?? propertyName;

                query.Append($"{columnName} = @{propertyName},");
            }

            query.Remove(query.Length - 1, 1);

            query.Append($" WHERE {keyColumn} = @{keyProperty}");

            return query.ToString();
        }

        private string CreateQueryDeleteById()
        {
            string tableName = GetTableName();
            string? keyColumn = GetKeyColumnName();
            string query = $"DELETE FROM* {tableName} WHERE {keyColumn} = @Id";

            return query;
        }

        private string CreateQuerySelectById()
        {
            string tableName = GetTableName();
            string? keyColumn = GetKeyColumnName();
            string query = $"SELECT {GetColumnsAsProperties()} FROM {tableName} WHERE {keyColumn} = @Id";

            return query;
        }

        private string CreateQuerySelectAll()
        {
            string tableName = GetTableName();
            string query = $"SELECT {GetColumnsAsProperties()} FROM {tableName}";

            return query;
        }
        #endregion


        #region private methods
        private string GetTableName()
        {
            var type = typeof(T);
            var tableAttribute = type.GetCustomAttribute<TableAttribute>();
            if (tableAttribute != null)
                return tableAttribute.Name;

            return type.Name;
        }

        private static string? GetKeyColumnName()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object[] keyAttributes = property.GetCustomAttributes(typeof(KeyAttribute), true);

                if (keyAttributes != null && keyAttributes.Length > 0)
                {
                    object[] columnAttributes = property.GetCustomAttributes(typeof(ColumnAttribute), true);

                    if (columnAttributes != null && columnAttributes.Length > 0)
                    {
                        ColumnAttribute columnAttribute = (ColumnAttribute)columnAttributes[0];
                        return columnAttribute?.Name ?? "";
                    }
                    else
                    {
                        return property.Name;
                    }
                }
            }

            return null;
        }

        private string GetColumns(bool excludeKey = false)
        {
            var type = typeof(T);
            var columns = string.Join(", ", type.GetProperties()
                .Where(p => !excludeKey || !p.IsDefined(typeof(KeyAttribute)))
                .Select(p =>
                {
                    var columnAttribute = p.GetCustomAttribute<ColumnAttribute>();
                    return columnAttribute != null ? columnAttribute.Name : p.Name;
                }));

            return columns;
        }

        private string GetColumnsAsProperties(bool excludeKey = false)
        {
            var type = typeof(T);
            var columnsAsProperties = string.Join(", ", type.GetProperties()
                .Where(p => !excludeKey || !p.IsDefined(typeof(KeyAttribute)))
                .Select(p =>
                {
                    var columnAttribute = p.GetCustomAttribute<ColumnAttribute>();
                    return columnAttribute != null ? $"{columnAttribute.Name} AS {p.Name}" : p.Name;
                }));

            return columnsAsProperties;
        }

        private string GetPropertyNames(bool excludeKey = false)
        {
            var properties = typeof(T).GetProperties()
                .Where(p => !excludeKey || p.GetCustomAttribute<KeyAttribute>() == null);

            var values = string.Join(", ", properties.Select(p => $"@{p.Name}"));

            return values;
        }

        private IEnumerable<PropertyInfo> GetProperties(bool excludeKey = false)
        {
            var properties = typeof(T).GetProperties()
                .Where(p => !excludeKey || p.GetCustomAttribute<KeyAttribute>() == null);

            return properties;
        }

        private string? GetKeyPropertyName()
        {
            var properties = typeof(T).GetProperties()
                .Where(p => p.GetCustomAttribute<KeyAttribute>() != null).ToList();

            if (properties.Any())
                return properties.FirstOrDefault()?.Name ?? null;

            return null;
        }
        #endregion

    }
}
