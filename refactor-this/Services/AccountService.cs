using refactor_this.IService;
using refactor_this.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace refactor_this.Services
{
    public class AccountService : IAccountService
    {
        public void UpdateOrCreate(Account account)
        {
            account.Save(); 
        }

        public void Delete(Guid id)
        {
            var account = GetById(id);
            account.Delete();
        }

        public List<Account> Get()
        {
            using (var connection = Helpers.NewConnection())
            {
                SqlCommand command = new SqlCommand($"select * from Accounts", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                var accounts = new List<Account>();
                while (reader.Read())
                {
                    var newAccount = new Account();
                    newAccount.Id = Guid.Parse(reader["Id"].ToString());
                    newAccount.Name = reader["name"].ToString();
                    newAccount.Number = reader["number"].ToString();
                    accounts.Add(newAccount);
                }

                return accounts;
            }
        }

        public Account GetById(Guid id)
        {
            using (var connection = Helpers.NewConnection())
            {
                SqlCommand command = new SqlCommand($"select * from Accounts where Id = '{id}'", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                if (!reader.Read())
                    throw new ArgumentException();

                var account = new Account(id);
                account.Name = reader["Name"].ToString();
                account.Number = reader["Number"].ToString();
                account.Amount = float.Parse(reader["Amount"].ToString());
                return account;
            }
        } 
    }
}