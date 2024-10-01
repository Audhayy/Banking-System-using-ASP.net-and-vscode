using System.Security.Cryptography.X509Certificates;
using BankingSystem.Controller;

namespace BankingSystem
{
    public class Program
    {
        
        static void Main(string[] args)
        {
        BankController bankController = new BankController();
        bankController.UserChoice();
        }
    }
}
