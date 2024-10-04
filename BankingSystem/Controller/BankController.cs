using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Service;
using BankingSystem.Util;

namespace BankingSystem.Controller
{
    public class BankController
    {
        private readonly AccountService _accountService = new AccountService();
        OperationsController operationsController = new OperationsController();
        public void UserChoice()
        {   
            bool breakout = false;
            string accountNumber;
            Console.WriteLine("Press Ctrl+C to Exit the Application");
            while (!breakout)
            {
                Console.WriteLine("Please choose the appropriate option:");
                Console.WriteLine("1) Enter new Bank Account details:");
                Console.WriteLine("2) Display specific Account details:");
                Console.WriteLine("3) Display all records of Account details:");
                Console.WriteLine("4) Delete an Account Detail");
                Console.WriteLine("5) Perform Bank operations");
               
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("you chose to add a bank account:");
                        addAccount();
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("You chose to display a specific account detail");
                            Console.WriteLine("enter the required account number");
                            accountNumber = Console.ReadLine();
                            var result = _accountService.GetAccount(accountNumber);
                            Console.WriteLine(result.ToString());
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        catch(BankingException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

                        break;
                    case "3":
                        Console.WriteLine("You chose to display all records");
                        var accountRecords = _accountService.GetAllAccounts();
                        foreach (var i in accountRecords)
                        {
                            Console.WriteLine(i.Value);
                        }
                        break;
                    case "4":
                        Console.WriteLine("You chose to Delete an bank account");
                        break;
                    case "5":
                        Console.WriteLine("You chose to perform bank operations");
                        Console.WriteLine("enter the account number");
                         accountNumber = Console.ReadLine();
                        if (_accountService.GetAccount(accountNumber) == null)
                        {
                            Console.WriteLine("First create an account then proceed");
                        }
                        else
                        {
                            operationsController.UserChoice();
                        }

                        break;
                }
            }

        }

        private void addAccount()
        {
            try
            {
                Console.WriteLine("Please enter your Full name");
                string name = Console.ReadLine();
                Console.WriteLine("Please enter your Address:");
                string address = Console.ReadLine();
                _accountService.AddAccount(name, address);
            }
            catch (BankingException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
    }
}
