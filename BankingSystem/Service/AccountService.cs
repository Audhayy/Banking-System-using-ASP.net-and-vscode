using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Model;
using BankingSystem.Repository;
using BankingSystem.Util;

namespace BankingSystem.Service
{
    public class AccountService
    {
        BankingRepository bankingRepository = new BankingRepository();
        public void AddAccount(string name, string address)
        {

            var AccountNumber = AccountGenerator.GenerateAccountNumber();
            Console.WriteLine("AccountNumber:" +AccountNumber);
            var ifscCode = AccountGenerator.GenerateIFSCCode();
            Console.WriteLine("IFSC:"+ifscCode);

            var id = AccountGenerator.GenerateUserID();

            bankingRepository.AddAccount(new Account()
            {
                Name = name,
                Id = id,
                Address = address,
                AccountNumber = AccountNumber,
                IFSCCode = ifscCode,
                balance = 0
                
            });
        }
        public Dictionary<string,Account> GetAllAccounts()
        {
           return bankingRepository.GetAllAccounts();
           
        }
        public Account GetAccount(string accountNumber)
        {
            return bankingRepository.GetAccount(accountNumber);
        }
        public Account addDeposit(string accountNumber,string amount)
        {
            double convertedAmount = Convert.ToDouble(amount);
            return bankingRepository.DepositIntoAccount(accountNumber,convertedAmount);
            
        }
        public bool WithdrawAmount(string accountNumber,string amount)
        {

            double convertedAmount = Convert.ToDouble(amount);
            if (bankingRepository.CheckBalance(accountNumber) > convertedAmount)
            {
                bankingRepository.WithdrawFromAccount(accountNumber, convertedAmount);
                return true;
            }
            return false;
        }
        public double analyzeBalance(string accountNumber)
        {
            return bankingRepository.CheckBalance(accountNumber);
        }

    }
}
