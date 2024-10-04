using BankingSystem.Repository;
using BankingSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Controller
{
    public class OperationsController
    {
        private readonly AccountService _accountService = new AccountService();
     
        public void UserChoice()
        {
            bool breakout = false;
            while (!breakout)
            {
                Console.WriteLine("Please choose the appropriate option:");
                Console.WriteLine("1) Deposit  into account:");
                Console.WriteLine("2) withdraw from account:");
                Console.WriteLine("3) show account balance:");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("you chose to deposit into your account");
                        Console.WriteLine("Enter the account number to which you want to deposit");
                        string? accountNumber = Console.ReadLine();
                        Console.WriteLine("enter the amount to be deposited");
                        var amount = Console.ReadLine();
                        var acc = _accountService.addDeposit(accountNumber, amount);
                        Console.WriteLine(acc.ToString());
                        break;
                    case "2":
                        Console.WriteLine("You chose to withdraw money from your account");
                        Console.WriteLine("enter the required account number");
                        accountNumber = Console.ReadLine();
                        Console.WriteLine("enter the amount to be withdrawn");
                        amount = Console.ReadLine();
                        if (!_accountService.WithdrawAmount(accountNumber, amount))
                        {
                            Console.WriteLine("Insufficient Balance");
                        }
                        break;
                    case "3":
                        Console.WriteLine("You chose to check your balance");
                        Console.WriteLine("enter the required account number");
                        accountNumber = Console.ReadLine();
                        var bal = _accountService.analyzeBalance(accountNumber);
                        Console.WriteLine(bal);
                        break;

                }
            }
        }
    }
}
