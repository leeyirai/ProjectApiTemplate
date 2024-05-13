using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IAccountManager
    {
        Task<IEnumerable<AccountDto>> Query(string id);
        Task<bool> Insert(AccountDto data);
        Task<bool> Update(AccountDto data);
        Task<bool> Delete(string id);
    }
}
