using System.Runtime.InteropServices;
using Xunit;
using BankingSystem.Model;
using BankingSystem.Repository;
using BankingSystem.Service;
using BankingSystem.Util;


public class AccountServiceTests
{
    private Account account;
    private BankingRepository _bankingRepository = new BankingRepository();
    private AccountService _accountService = new AccountService();
    private AccountGenerator _accountGenerator = new AccountGenerator();

    [Fact]
    public void AddAccount_AddsAccountToRepository()
    {
        // Arrange
        var name = "John Doe";
        var address = "123 Main St";

        // Act
        _accountService.AddAccount(name, address);

        // Assert
        var accounts = _bankingRepository.GetAllAccounts();
        Assert.NotEmpty(accounts);
        var account = accounts.First().Value;
        Assert.Equal(name, account.Name);
        Assert.Equal(address, account.Address);
        Assert.NotEmpty(account.AccountNumber);
        Assert.NotEmpty(account.IFSCCode);
        Assert.Equal(0, account.balance);
    }
    [Fact]
    public void AddDeposit_IncreasesAccountBalance()
    {
        // Arrange
        var name = "John Doe";
        var address = "123 Main St";
        var depositAmount = 100.0;

        // Act
        _accountService.AddAccount(name, address);
        var accounts = _bankingRepository.GetAllAccounts();
        var account = accounts.First().Value;
        _accountService.addDeposit(account.AccountNumber, depositAmount.ToString());

        // Assert
        var updatedBalance = _bankingRepository.CheckBalance(account.AccountNumber);
        Assert.Equal(depositAmount, updatedBalance);
    }
    [Fact]

    public void ShouldWithdrawAmountFromAccount()
    {
        // Arrange
        var name = "John Doe";
        var address = "123 Main St";
        var initialBalance = 100.0;
        var depositAmount = 30.0;
        var withdrawAmount = 30.0;

        // Act
        _accountService.AddAccount(name, address);
        var accounts = _bankingRepository.GetAllAccounts();
        var account = accounts.First().Value;
        _bankingRepository.DepositIntoAccount(account.AccountNumber, initialBalance);
        _accountService.addDeposit(account.AccountNumber, depositAmount.ToString());
        _accountService.WithdrawAmount(account.AccountNumber, withdrawAmount.ToString());

        // Assert
        var updatedBalance = _bankingRepository.CheckBalance(account.AccountNumber);
        Assert.Equal(initialBalance + depositAmount - withdrawAmount, updatedBalance);
    }
    [Fact]
    public void WarnInputIsInvalid()
    {
        var name = "audhi";
        var address = "123 road";
        _accountService.AddAccount(name, address);
        var accounts = _bankingRepository.GetAllAccounts();
        var account = accounts.First().Value;
        Assert.Throws<BankingException>(() => _accountService.addDeposit(account.AccountNumber, ""));
    }

}