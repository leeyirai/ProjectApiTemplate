using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;

namespace Infrastructure
{
    public class SqliteInfra : ISqliteInfra
    {
        private string _connectionString = "Data Source=db.db;";

        public SqliteInfra()
        {
            this.CreateDatabaseFile();
        }

        private void CreateDatabaseFile()
        {
            if (File.Exists("db.db")) return;
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"CREATE TABLE USER (
                    id INTEGER,
                    Account TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL UNIQUE,
                    Name TEXT NOT NULL UNIQUE,
                    Phone TEXT NOT NULL UNIQUE,
                    Email TEXT NOT NULL UNIQUE,
                    Visiable INTEGER,
                    PRIMARY KEY(id AUTOINCREMENT)
                );";
                command.ExecuteNonQuery();
            }
        }

        public async Task<bool> Delete(string sqlText, DynamicParameters? parameters)
        {
            using var cn = new SqliteConnection(_connectionString);
            var count = await cn.ExecuteAsync(sql: sqlText, commandType: CommandType.Text, param: parameters);
            return count > 0;
        }

        public async Task<bool> Delete(string sqlText, IEnumerable<string> id)
        {
            using var cn = new SqliteConnection(_connectionString);
            var count = await cn.ExecuteAsync(sql: sqlText, commandType: CommandType.Text, param: id);
            return count > 0;
        }

        public async Task<bool> Insert<T>(string sqlText, T data) where T : class
        {
            using var cn = new SqliteConnection(_connectionString);
            var count = await cn.ExecuteAsync(sql: sqlText, commandType: CommandType.Text, param: data);
            return count > 0;
        }

        public async Task<bool> Insert<T>(string sqlText, IEnumerable<T> dataList) where T : class
        {
            using var cn = new SqliteConnection(_connectionString);
            var count = await cn.ExecuteAsync(sql: sqlText, commandType: CommandType.Text, param: dataList);
            return count > 0;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sqlText, DynamicParameters? parameters) where T : class
        {
            using var cn = new SqliteConnection(_connectionString);
            return await cn.QueryAsync<T>(sql: sqlText, commandType: CommandType.Text, param: parameters);
        }

        public async Task<T> QueryFirstOrDefault<T>(string sqlText, DynamicParameters? parameters) where T : class
        {
            using var cn = new SqliteConnection(_connectionString);
            return await cn.QueryFirstOrDefaultAsync<T>(sql: sqlText, commandType: CommandType.Text, param: parameters);
        }

        public async Task<bool> Update<T>(string sqlText, T data) where T : class
        {
            using var cn = new SqliteConnection(_connectionString);
            var count = await cn.ExecuteAsync(sql: sqlText, commandType: CommandType.Text, param: data);
            return count > 0;
        }

        public async Task<bool> Update<T>(string sqlText, IEnumerable<T> dataList) where T : class
        {
            using var cn = new SqliteConnection(_connectionString);
            var count = await cn.ExecuteAsync(sql: sqlText, commandType: CommandType.Text, param: dataList);
            return count > 0;
        }
    }
}
