using AutoMapper;
using BusinessLayer.Model;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapper
{
    public class AccountMapper : Profile
    {
        public AccountMapper()
        {
            CreateMap<AccountModel, AccountDto>().ReverseMap();
        }
    }
}
