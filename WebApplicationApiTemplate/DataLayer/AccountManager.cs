using DataLayer.Model;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataLayer
{
    public class AccountManager : IAccountManager
    {
        private readonly ISqliteInfra _sqliteInfra;

        public AccountManager(ISqliteInfra sqliteInfra)
        {
            _sqliteInfra = sqliteInfra;
        }

        public async Task<bool> Delete(string id)
        {
            var parameters = new Dapper.DynamicParameters();
            var sqlWhere = new StringBuilder();
            var sqlOrderBy = new StringBuilder();

            // var sqlText = " DELETE FROM USER WHERE id = @id";
            sqlWhere.Append(" WHERE id = @id ");
            parameters.Add("id", id);
            var sqlText = @"UPDATE USER SET [Visiable]= 0 ";

            return await _sqliteInfra.Delete(sqlText.ToString() + sqlWhere.ToString() + sqlOrderBy.ToString(), parameters);
        }

        public async Task<bool> Insert(AccountDto data)
        {
            var parameters = new Dapper.DynamicParameters();
            var sqlWhere = new StringBuilder();
            var sqlOrderBy = new StringBuilder();

            var sqlText = @"INSERT INTO USER(
                 [Account]
                ,[Password]
                ,[Name]
                ,[Phone]
                ,[Email]
                ,[Visiable]
                )
                VALUES(
                 @Account
                ,@Password
                ,@Name
                ,@Phone
                ,@Email
                ,1                   
                )";
            return await _sqliteInfra.Insert(sqlText.ToString() + sqlWhere.ToString() + sqlOrderBy.ToString(), data);
        }

        public async Task<IEnumerable<AccountDto>> Query(string id)
        {
            var parameters = new Dapper.DynamicParameters();
            var sqlWhere = new StringBuilder();
            var sqlOrderBy = new StringBuilder();

            sqlWhere.Append(" WHERE Visiable = 1 ");
            if (!string.IsNullOrEmpty(id))
            {
                sqlWhere.Append(" AND id = @id ");
                parameters.Add("id", id);
            }

            var sqlText = @"SELECT 
                id
                ,Account 
                ,Password 
                ,Name
                ,Phone 
                ,Email
                FROM USER
            ";

            sqlOrderBy.Append(" ORDER BY id");

            return await _sqliteInfra.QueryAsync<AccountDto>(sqlText.ToString() + sqlWhere.ToString() + sqlOrderBy.ToString(), parameters);
        }

        public async Task<bool> Update(AccountDto data)
        {
            var parameters = new Dapper.DynamicParameters();
            var sqlWhere = new StringBuilder();
            var sqlOrderBy = new StringBuilder();
            if (data is not null)
            {
                sqlWhere.Append(" WHERE id = @id ");
                parameters.Add("id", data.id);
                var sqlText = @"UPDATE USER SET
                 [Account]=@Account
                ,[Password]=@Password
                ,[Name]=@Name
                ,[Phone]=@Phone
                ,[Email]=@Email";
                return await _sqliteInfra.Update(sqlText.ToString() + sqlWhere.ToString() + sqlOrderBy.ToString(), data);
            }
            else
            {
                return false;
            }
        }
    }
}
