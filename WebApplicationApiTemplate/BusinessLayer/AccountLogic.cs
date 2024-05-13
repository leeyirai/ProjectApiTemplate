using AutoMapper;
using BusinessLayer.Model;
using DataLayer;
using DataLayer.Model;
using Infrastructure.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessLayer
{
    public class AccountLogic : IAccountLogic
    {
        private readonly IAccountManager _accountManager;
        private readonly IMapper _mapper;

        public AccountLogic(IAccountManager accountManager, IMapper mapper)
        {
            _accountManager = accountManager;
            _mapper = mapper;
        }

        public async Task<ApiResponseModel<string>> Delete(string id)
        {
            var result = new ApiResponseModel<string>()
            {
                Success = false,
                Message = "失敗"
            };
            var excute = await _accountManager.Delete(id);
            if (excute)
            {
                result.Success = true;
                result.Message = "成功";
            }

            return result;
        }

        public async Task<ApiResponseModel<string>> Insert(AccountModel data)
        {
            var result = new ApiResponseModel<string>() 
            { 
                Success = false,
                Message = "失敗"
            };
            var excute = await _accountManager.Insert(_mapper.Map<AccountModel, AccountDto>(data));
            if (excute)
            {
                result.Success = true;
                result.Message = "成功";
            }

            return result;
        }

        public async Task<ApiResponseModel<IEnumerable<AccountModel>>> Query(string id)
        {
            var result = new ApiResponseModel<IEnumerable<AccountModel>> ()
            {
                Success = false,
                Message = "失敗"
            };
            var excute = await _accountManager.Query(id);
            if (excute is not null)
            {
                result.Success = true;
                result.Message = "成功";
                result.Data = _mapper.Map<IEnumerable<AccountDto>, IEnumerable<AccountModel>>(excute);
            }

            return result;
        }

        public async Task<ApiResponseModel<string>> Update(AccountModel data)
        {
            var result = new ApiResponseModel<string>()
            {
                Success = false,
                Message = "失敗"
            };
            var excute = await _accountManager.Update(_mapper.Map<AccountModel, AccountDto>(data));
            if (excute)
            {
                result.Success = true;
                result.Message = "成功";
            }

            return result;
        }
    }
}
