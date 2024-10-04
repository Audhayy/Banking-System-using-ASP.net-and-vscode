using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        private readonly BankingRepository _bankingRepository = new BankingRepository();
        private readonly AccountGenerator _accountGenerator;

        public AccountService(BankingRepository bankingRepository)
        {
            //_bankingRepository = bankingRepository;
            _accountGenerator = new AccountGenerator(); 
        }

        public AccountService()
        {

        }
        public void AddAccount(string name, string address)
        {

            var AccountNumber = AccountGenerator.GenerateAccountNumber();
            Console.WriteLine("AccountNumber:" +AccountNumber);
            var ifscCode = AccountGenerator.GenerateIFSCCode();
            Console.WriteLine("IFSC:"+ifscCode);

            var id = AccountGenerator.GenerateUserID();

            _bankingRepository.AddAccount(new Account()
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
           return _bankingRepository.GetAllAccounts();
           
        }
        public Account GetAccount(string accountNumber)
        {
            try
            {
                return _bankingRepository.GetAccount(accountNumber);
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (BankingException ex)
            {
                throw ex;
            }
        }
        public Account addDeposit(string accountNumber,string amount)
        {
            if (double.TryParse(amount, out double convertedAmount))
            {
                return _bankingRepository.DepositIntoAccount(accountNumber, convertedAmount);
            }
            else
            {
                throw new BankingException("Could not parse the input provided");
            }
        }
        public bool WithdrawAmount(string accountNumber,string amount)
        {

           
           if(double.TryParse(amount, out double convertedAmount))
           {
               if (_bankingRepository.CheckBalance(accountNumber) > convertedAmount)
               {
                   _bankingRepository.WithdrawFromAccount(accountNumber, convertedAmount);
                   return true;
               }


               return false;
           }
           else
           {
                throw new BankingException("could not parse the input");
           }
        }
        public double analyzeBalance(string accountNumber)
        {
            return _bankingRepository.CheckBalance(accountNumber);
        }

    }
}
