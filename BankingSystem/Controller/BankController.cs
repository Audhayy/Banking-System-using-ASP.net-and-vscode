using System;
using BankingSystem.Service;
using BankingSystem.Util;

namespace BankingSystem.Controller
{
    public class BankController
    {
        private readonly AccountService _accountService = new AccountService();
        private readonly OperationsController operationsController = new OperationsController();

        public void UserChoice()
        {
            Console.WriteLine("Press Ctrl+C to Exit the Application");
            DisplayMenu();
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Please choose the appropriate option:");
            Console.WriteLine("1) Enter new Bank Account details:");
            Console.WriteLine("2) Display specific Account details:");
            Console.WriteLine("3) Display all records of Account details:");
            Console.WriteLine("4) Delete an Account Detail");
            Console.WriteLine("5) Perform Bank operations");
            Console.WriteLine("0) Exit");

            var choice = Console.ReadLine();
            HandleUser_Choice(choice);
        }

        private void HandleUser_Choice(string choice)
        {
            switch (choice)
            {
                case "1":
                    AddAccount();
                    break;
                case "2":
                    DisplaySpecificAccount();
                    break;
                case "3":
                    DisplayAllAccounts();
                    break;
                case "4":
                    DeleteAccount();
                    break;
                case "5":
                    PerformBankOperations();
                    break;
                case "0":
                    Console.WriteLine("Exiting the application.");
                    return; // Exit the application
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            // Display the menu again after handling the choice
            DisplayMenu();
        }

        private void AddAccount()
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

        private void DisplaySpecificAccount()
        {
            try
            {
                Console.WriteLine("You chose to display a specific account detail");
                Console.WriteLine("Enter the required account number:");
                string accountNumber = Console.ReadLine();
                var result = _accountService.GetAccount(accountNumber);
                Console.WriteLine(result.ToString());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (BankingException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void DisplayAllAccounts()
        {
            Console.WriteLine("You chose to display all records");
            var accountRecords = _accountService.GetAllAccounts();
            foreach (var account in accountRecords)
            {
                Console.WriteLine(account.Value);
            }
        }

        private void DeleteAccount()
        {
            Console.WriteLine("You chose to delete a bank account.");
            // Implement deletion logic here
        }

        private void PerformBankOperations()
        {
            Console.WriteLine("You chose to perform bank operations");
            Console.WriteLine("Enter the account number:");
            string accountNumber = Console.ReadLine();
            if (_accountService.GetAccount(accountNumber) == null)
            {
                Console.WriteLine("First create an account then proceed");
            }
            else
            {
                operationsController.UserChoice();
            }
        }
    }
}