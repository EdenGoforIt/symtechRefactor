using refactor_this.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_this.IService
{
    public interface IAccountService
    {
        Account GetById(Guid id);
        List<Account> Get();
        void UpdateOrCreate(Account account); 
        void Delete(Guid id);
    }
}