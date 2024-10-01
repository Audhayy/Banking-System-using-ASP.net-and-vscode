using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Util
{

    
        public class AccountGenerator
        {
            private static readonly Random _random = new Random();

            public static string GenerateAccountNumber()
            {
                
                return _random.Next(100, 999).ToString();
            }

            public static string GenerateIFSCCode()
            {
                var bankCode = GetRandomString(3);
                var branchCode = GetRandomString(6); 
                return bankCode + branchCode;
            }

            public static string GenerateUserID()
            {
               
                return GetRandomString(3) + GetRandomNumber(3);
            }

            private static string GetRandomString(int length)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                var stringChars = new char[length];
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[_random.Next(chars.Length)];
                }

                return new string(stringChars);
            }

            private static string GetRandomNumber(int length)
            {
                var number = _random.Next((int)Math.Pow(10, length - 1), (int)Math.Pow(10, length));
                return number.ToString();
            }
        }
    }

