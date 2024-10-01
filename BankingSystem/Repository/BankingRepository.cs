using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Dto;
using BankingSystem.Model;

namespace BankingSystem.Repository
{
    internal class BankingRepository
    {
        static Dictionary<string, Account> _accounts = new();

        public void AddAccount(Account account)
        {
            _accounts.Add(account.AccountNumber, account);
        }

        public Account DepositIntoAccount(string accountNumber,double amount)
        {

            var details = GetAccount(accountNumber);
            if (details != null)
            {
                details.balance += amount;
            }
     

            return null;
        }

        public void WithdrawFromAccount(string accountNumber, double amount)
        {
            var details = GetAccount(accountNumber);
            if (details != null)
            {
                details.balance = details.balance - amount;
            }
            
            
        }

        public double CheckBalance(string accountNumber)
        {
            var account = GetAccount(accountNumber);
            if (account != null)
            {
                return account.balance;
            }
            return 0;
        }

        public Account GetAccount(string accountNumber)
        {
            foreach (var account in _accounts)
            {
                if (account.Key.Equals(accountNumber))
                {
                    var acc = account;
                    var value = acc.Value;
                    return value;
                }
            }

            return null;
        }

        public Dictionary<string,Account> GetAllAccounts()
        {
            return _accounts;
        }
    }
}
