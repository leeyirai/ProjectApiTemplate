using BusinessLayer.Model;
using DataLayer.Model;
using Infrastructure.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IAccountLogic
    {
        Task<ApiResponseModel<IEnumerable<AccountModel>>> Query(string id);
        Task<ApiResponseModel<string>> Insert(AccountModel data);
        Task<ApiResponseModel<string>> Update(AccountModel data);
        Task<ApiResponseModel<string>> Delete(string id);
    }
}
