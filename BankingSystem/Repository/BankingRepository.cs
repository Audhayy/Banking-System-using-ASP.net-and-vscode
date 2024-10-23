using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Dto;
using BankingSystem.logger;
using BankingSystem.Model;
using BankingSystem.Util;

namespace BankingSystem.Repository
{
    public class BankingRepository
    {
        static Dictionary<string, Account> _accounts = new();

        private readonly LogHandler _logger = new();
        public void AddAccount(Account account)
        {
            try
            {
                _accounts.Add(account.AccountNumber, account);
                _logger.LogInfo($"Account has been added successfully");


            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning($"Account {account.AccountNumber} with the same number already exist");
                throw new BankingException("Account with the same number already exist", ex);
            }
        }

        public Account DepositIntoAccount(string accountNumber,double amount)
        {
            try
            {
                var details = GetAccount(accountNumber);
                if (details != null)
                {
                    details.balance += amount;
                    return details;
                }
                else
                {
                    throw new InvalidOperationException("Account Not found");
                }
            }
            catch (Exception ex)
            {
                throw new BankingException("Failed to deposit into your account", ex);
            }

        }

        public void WithdrawFromAccount(string accountNumber, double amount)
        {
            try
            {
                var details = GetAccount(accountNumber);
                if (details != null)
                {
                    details.balance = details.balance - amount;
                }
                else
                {
                    throw new InvalidOperationException("Account not found!");
                }
            }
            catch (Exception ex)
            {
                throw new BankingException("Failed to Withdraw from your account", ex);
            }


        }

        public double CheckBalance(string accountNumber)
        {
            try
            {
                var account = GetAccount(accountNumber);
                if (account != null)
                {
                    return account.balance;
                }
                else
                {
                    throw new InvalidOperationException("Account not found!");
                }
            }
            catch (Exception ex)
            {
                throw new BankingException("Failed to Check balance", ex);
            }

            return 0;
        }

        public Account GetAccount(string accountNumber)
        {
            try
            {
                if (_accounts == null)
                {
                    _logger.LogWarning($"Account does not exist");
                    throw new InvalidOperationException("There is no such account Number");
                }
                foreach (var account in _accounts)
                {
                    if (account.Key.Equals(accountNumber))
                    {
                        var acc = account;
                        var value = acc.Value;
                        return value;
                    }
                    else
                    {
                        _logger.LogWarning($"Account does not exist");
                        throw new InvalidOperationException("There is no such account Number");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new BankingException("Failed to get Account from the repository!", ex);
            }

            return new();
        }

        public Dictionary<string,Account> GetAllAccounts()
        {
            try
            {

                return _accounts;
            }
            catch (Exception ex)
            {
                throw new BankingException("Failed to get all accounts ", ex);
            }
        }
    }
}
